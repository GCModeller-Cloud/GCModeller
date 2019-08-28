﻿#Region "Microsoft.VisualBasic::e0d8a2953bb41e4991cf4aefc94f653f, Bio.Assembly\Assembly\KEGG\DBGET\Objects\KEGGOrganism\EntryAPI.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xie (genetics@smrucc.org)
'       xieguigang (xie.guigang@live.com)
' 
' Copyright (c) 2018 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
' 
' 
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
' 
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
' 
' You should have received a copy of the GNU General Public License
' along with this program. If not, see <http://www.gnu.org/licenses/>.



' /********************************************************************************/

' Summaries:

'     Module EntryAPI
' 
'         Properties: Resources
' 
'         Constructor: (+1 Overloads) Sub New
'         Function: __fillClass, __loadList, FromResource, GetKEGGSpeciesCode, GetOrganismList
'                   GetOrganismListFromResource, GetValue
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Text.Levenshtein
Imports r = System.Text.RegularExpressions.Regex

Namespace Assembly.KEGG.DBGET.bGetObject.Organism

    ''' <summary>
    ''' 
    ''' </summary>
    <Package("KEGG.DBGET.spEntry",
                      Publisher:="amethyst.asuka@gcmodeller.org",
                      Url:=EntryAPI.WEB_URL,
                      Category:=APICategories.UtilityTools,
                      Description:="KEGG Organisms: Complete Genomes")>
    Public Module EntryAPI

        Public ReadOnly Property Resources As KEGGOrganism

        ''' <summary>
        ''' {brief_sp, <see cref="organism"/>}
        ''' </summary>
        ReadOnly OrgCodes As Dictionary(Of String, Organism)

        Sub New()
            Try
                Dim mgr As New ResourcesSatellite(GetType(EntryAPI).Assembly)
                Resources = htmlParserInternal(mgr.GetString("KEGG_Organism_Complete_Genomes"))
                OrgCodes = Resources _
                    .ToArray _
                    .ToDictionary(Function(x) x.KEGGId)
            Catch ex As Exception
                Call App.LogException(ex)
                Call ex.PrintException
            End Try
        End Sub

        ''' <summary>
        ''' Gets the organism value from the KEGG database through the brief code, 
        ''' if the data is not exists in the database, Nothing will be returns.
        ''' </summary>
        ''' <param name="sp">The organism brief code in the KEGG database</param>
        ''' <returns></returns>
        Public Function GetValue(sp As String) As Organism
            If OrgCodes.ContainsKey(sp) Then
                Return OrgCodes(sp)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' 通过本地资源从基因组全名之中得到KEGG之中的三字母的简写代码
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("KEGG.spCode",
                   Info:="Convert the species genome full name into the KEGG 3 letters briefly code.")>
        Public Function GetKEGGSpeciesCode(Name As String) As Organism
            Dim LQuery = LinqAPI.Exec(Of (org As Organism, dist As DistResult)) _
 _
                () <= From org As Organism
                      In Resources _
                          .ToArray _
                          .AsParallel
                      Let dist As DistResult = LevenshteinDistance.ComputeDistance(Name, org.Species) ' StatementMatches.Match(Name, x.Species)
                      Where Not dist Is Nothing AndAlso dist.NumMatches >= 2
                      Order By dist.MatchSimilarity Descending
                      Select (org, dist)

            If LQuery.IsNullOrEmpty OrElse LQuery.First.dist.MatchSimilarity < 0.9 Then
                Call VBDebugger.Warning($"Could not found any entry for ""{Name}"" from KEGG...")
                Return Nothing
            Else
                Dim first = LQuery.First.org
                Return first
            End If
        End Function

        ''' <summary>
        ''' Load KEGG organism list from the internal resource.
        ''' </summary>
        ''' <returns></returns>
        <ExportAPI("list.Load", Info:="Load KEGG organism list from the internal resource.")>
        Public Function GetOrganismListFromResource() As KEGGOrganism
            Dim res As New ResourcesSatellite(GetType(EntryAPI).Assembly)
            Dim html As String = res.GetString("KEGG_Organism_Complete_Genomes")
            Return htmlParserInternal(html)
        End Function

        Public Const WEB_URL As String = "http://www.genome.jp/kegg/catalog/org_list.html"
        Public Const DELIMITER As String = "</td>"
        Public Const CELL As String = "<tr .+?</tr>"

        Private Function htmlParserInternal(html As String) As KEGGOrganism
            Dim rows As String() = r.Matches(html, CELL, RegexICSng).ToArray.Skip(1).ToArray
            Dim eulst As Organism() = New Organism(rows.Length - 1) {}
            Dim i As Integer
            Dim prlst As Prokaryote() = New Prokaryote(rows.Length - i) {}

            For i = 0 To rows.Length - 1
                eulst(i) = Organism.parseObjectText(rows(i))

                If eulst(i) Is Nothing Then
                    Exit For
                End If
            Next

            Dim j As Integer
            For i = i + 1 To rows.Length - 1
                prlst(j) = New Prokaryote(rows(i))
                j += 1
            Next

            Return New KEGGOrganism With {
                .Eukaryotes = eulst.trimOrganism.fillTaxonomyClass,
                .Prokaryote = prlst.trimOrganism.fillTaxonomyClass
            }
        End Function

        <Extension>
        Private Function trimOrganism(orgs As IEnumerable(Of Prokaryote)) As IEnumerable(Of Prokaryote)
            Return From org As Prokaryote
                   In orgs
                   Where Not org Is Nothing
                   Select DirectCast(org.Trim, Prokaryote)
        End Function

        <Extension>
        Private Function trimOrganism(orgs As IEnumerable(Of Organism)) As IEnumerable(Of Organism)
            Return From org As Organism
                   In orgs
                   Where Not org Is Nothing
                   Select org.Trim
        End Function

        ''' <summary>
        ''' 从上往下填充物种分类信息
        ''' </summary>
        ''' <param name="eukaryotes"></param>
        ''' <returns></returns>
        <Extension>
        Private Function fillTaxonomyClass(eukaryotes As IEnumerable(Of Organism)) As Organism()
            Dim phylum As String = ""
            Dim [class] As String = ""
            Dim fillList As New List(Of Organism)

            For Each organism As Organism In eukaryotes
                If Not String.IsNullOrEmpty(organism.Class) Then
                    [class] = organism.Class
                Else
                    organism.Class = [class]
                End If

                If Not String.IsNullOrEmpty(organism.Phylum) Then
                    phylum = organism.Phylum
                Else
                    organism.Phylum = phylum
                End If
            Next

            Return fillList.ToArray
        End Function

        <Extension>
        Private Function fillTaxonomyClass(prokaryote As IEnumerable(Of Prokaryote)) As Prokaryote()
            Dim kingdom As String = ""
            Dim phylum$ = ""
            Dim [class] = ""
            Dim fillList As New List(Of Prokaryote)

            For Each organism As Prokaryote In prokaryote
                If Not String.IsNullOrEmpty(organism.Class) Then
                    [class] = organism.Class
                Else
                    organism.Class = [class]
                End If
                If Not String.IsNullOrEmpty(organism.Phylum) Then
                    phylum = organism.Phylum
                Else
                    organism.Phylum = phylum
                End If
                If Not String.IsNullOrEmpty(organism.Kingdom) Then
                    kingdom = organism.Kingdom
                Else
                    organism.Kingdom = kingdom
                End If
            Next

            Return fillList
        End Function

        ''' <summary>
        ''' Data from the external resources.
        ''' </summary>
        ''' <param name="url">
        ''' By default is fetch from kegg web server for gets the latest KEGG organism list from query the KEGG database.
        ''' </param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("list.Get", Info:="Gets the latest KEGG organism list from query the KEGG database.")>
        Public Function FromResource(Optional url$ = WEB_URL) As KEGGOrganism
            Return htmlParserInternal(html:=url.GET)
        End Function
    End Module
End Namespace
