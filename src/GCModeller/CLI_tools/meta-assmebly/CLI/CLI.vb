﻿#Region "Microsoft.VisualBasic::793b11e27e8e1bbb48dc3242193a76a6, ..\CLI_tools\meta-assmebly\CLI\CLI.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2016 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Language
Imports SMRUCC.genomics.Analysis.Metagenome.UPGMATree
Imports SMRUCC.genomics.Assembly.NCBI.Taxonomy

Module CLI

    <ExportAPI("/UPGMA.Tree")>
    <Usage("/UPGMA.Tree /in <in.csv> [/out <>]")>
    <Argument("/in", False, CLITypes.File, PipelineTypes.std_in,
              AcceptTypes:={GetType(DataSet)},
              Description:="The input matrix in csv table format for build and visualize as a UPGMA Tree.")>
    Public Function UPGMATree(args As CommandLine) As Integer
        Dim data As IEnumerable(Of DataSet) = DataSet.LoadDataSet(args <= "/in")
        Dim tree As Taxa = data.BuildTree
        Dim out$ = (args <= "/out") Or ((args <= "/in").TrimSuffix & ".txt").AsDefault

        With tree.ToString
            Call .__INFO_ECHO
            Call .SaveTo(out)
        End With

        Return 0
    End Function

    <ExportAPI("/LefSe.Matrix")>
    <Description("Processing the relative aboundance matrix to the input format file as it describ: http://huttenhower.sph.harvard.edu/galaxy/root?tool_id=lefse_upload")>
    <Usage("/LefSe.Matrix /in <Species_abundance.csv> /ncbi_taxonomy <NCBI_taxonomy> [/all_rank /out <out.tsv>]")>
    Public Function LefSeMatrix(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim ncbi_taxonomy$ = args <= "/ncbi_taxonomy"
        Dim out As String = (args <= "/out") Or ([in].TrimSuffix & "_" & ncbi_taxonomy.BaseName & ".tsv").AsDefault
        Dim taxonomy As New NcbiTaxonomyTree(ncbi_taxonomy)
        Dim taxid = names.BuildTaxiIDFinder(ncbi_taxonomy & "/names.dmp")
        Dim aboundance = DataSet.LoadDataSet([in]).ToArray
        Dim std As Boolean = Not args.IsTrue("/all_rank")

        For Each sp As DataSet In aboundance
            Dim name$ = sp.ID
            Dim names = taxid(name)

            If Not names.IsNullOrEmpty Then
                Dim tax_id% = names _
                    .Where(Function(x) x.name_class = "scientific name") _
                    .FirstOrDefault _
                   ?.tax_id

                Dim tree = taxonomy.GetAscendantsWithRanksAndNames(taxid:=tax_id, only_std_ranks:=std)
                sp.ID = TaxonomyNode.Taxonomy(tree, delimiter:="|")
            End If
        Next

        Return aboundance.SaveTo(out, tsv:=True)
    End Function
End Module

