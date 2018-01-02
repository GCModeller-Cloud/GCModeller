﻿#Region "Microsoft.VisualBasic::99e639c9cce0d4e448b01e8d4492460c, ..\GCModeller\data\RegulonDatabase\Regprecise\WebServices\WebParser\WebAPI.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2018 GPL3 Licensed
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

Imports System.Text.RegularExpressions
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices.Debugging.Logging
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Terminal.ProgressBar
Imports Microsoft.VisualBasic.Text.HtmlParser
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports SMRUCC.genomics.Data.Regprecise.Regulator
Imports SMRUCC.genomics.SequenceModel
Imports r = System.Text.RegularExpressions.Regex

Namespace Regprecise

    <Package("Regprecise.WebAPI",
                      Category:=APICategories.UtilityTools,
                      Description:="Tools API for download and search RegPrecise database.",
                      Publisher:="")>
    Public Module WebAPI

        <ExportAPI("Regulon.Downloads")>
        Public Function DownloadRegulon(url As String) As Regulon
            Dim html As String = Regex.Match(url.GET, "<table class=""stattbl"".+?</table>", RegexOptions.Singleline).Value
            html = Regex.Match(html, "<tbody>.+</tbody>", RegexOptions.Singleline).Value

            Dim Items As String() = (From match As Match
                                     In Regex.Matches(html, "<tr .+?</tr>", RegexOptions.Singleline + RegexOptions.IgnoreCase)
                                     Select match.Value).ToArray
            Dim Regulators As Regulator() = New Regulator(Items.Length - 1) {}

            For i As Integer = 0 To Regulators.Length - 1
                Dim strData As String = Items(i)
                Regulators(i) = Regulator.CreateObject(strData)
            Next

            Return New Regulon With {
                .regulators = Regulators
            }
        End Function

        <ExportAPI("Get.RegulatedGenes")>
        Public Function GetRegulates(url As String) As RegulatedGene()
            Dim page As String = url.GET
            Return RegulatedGene.DocParser(doc:=page)
        End Function

        <ExportAPI("Regulator.Creates")>
        Public Function CreateRegulator(Family As String,
                                        Bacteria As String,
                                        RegulatorSites As FASTA.FastaFile,
                                        RegulatorId As String) As Regulator
            Dim regSites = (From FastaObject As FastaReaders.Site
                            In FastaReaders.Site.CreateObject(RegulatorSites)
                            Select FastaObject.ToFastaObject).ToArray
            Dim Regulator As Regulator = New Regulator With {
                .Family = Family,
                .LocusTag = New KeyValuePair With {.Key = RegulatorId},
                .Regulog = New KeyValuePair With {
                    .Key = String.Format("{0} - {1}", Family, Bacteria)
                },
                .Type = Regulator.Types.TF,
                .Regulator = New KeyValuePair With {.Key = RegulatorId},
                .RegulatorySites = regSites
            }
            Return Regulator
        End Function

        <ExportAPI("Get.sId")>
        Public Function GetsId(strData As String) As String
            Dim Id As String = Mid(strData, InStr(strData, """>") + 2)
            If String.IsNullOrEmpty(Trim(Id)) Then
                Return ""
            Else
                Id = Mid(Id, 1, Len(Id) - 4)
                Return Id
            End If
        End Function

        <ExportAPI("s.ToType")>
        Public Function ToType(type As String) As Types
            If String.Equals(type, "tf", StringComparison.OrdinalIgnoreCase) Then
                Return Types.TF
            ElseIf String.Equals(type, "rna", StringComparison.OrdinalIgnoreCase) Then
                Return Types.RNA
            Else
                Return Types.NotSpecific
            End If
        End Function

        Public Const TABLE_REGEX As String = "<table class=""stattbl"">.+</table>"
        Public Const browse_genomes$ = "http://regprecise.lbl.gov/RegPrecise/browse_genomes.jsp"

        <ExportAPI("Regprecise.Downloads")>
        Public Function Download(<Parameter("DIR.Export")> Optional EXPORT$ = "./") As TranscriptionFactors
            Call "Start to fetch regprecise genome information....".__DEBUG_ECHO

            Dim html$ = Regex.Match(browse_genomes.GET, TABLE_REGEX, RegexOptions.Singleline).Value
            Dim list$() = r _
                .Matches(html, "<tr .+?</tr>", RegexOptions.Singleline + RegexOptions.IgnoreCase) _
                .ToArray
            Dim genomes As BacteriaGenome() = New BacteriaGenome(list.Length - 1) {}

            Call $"{genomes.Length} bacteria genome are ready to download!".__DEBUG_ECHO

            Using progress As New ProgressBar("Download regprecise database...")
                Dim tick As New ProgressProvider(total:=list.Length)
                Dim ETA$
                Dim message$

                For i As Integer = 0 To genomes.Length - 1
                    genomes(i) = __download(list(i), EXPORT)
                    ETA = tick.ETA(progress.ElapsedMilliseconds).FormatTime
                    message = $"{genomes(i).genome.name}  ETA: {ETA}"
                    progress.SetProgress(tick.StepProgress, message)
                    Thread.Sleep(60 * 1000)
                Next
            End Using

            Return New TranscriptionFactors With {
                .genomes = genomes,
                .update = Now.ToShortDateString
            }
        End Function

        Private Function __download(entryHref As String, EXPORT As String) As BacteriaGenome
            Dim strData As String = Regex.Match(entryHref, "href="".+?"">.+?</a>").Value
            Dim Entry As KeyValuePair = KeyValuePair.CreateObject(GetsId(strData), "http://regprecise.lbl.gov/RegPrecise/" & strData.href)
            Dim SavePath As String = String.Format("{0}/{1}.xml", EXPORT, Entry.Key.NormalizePathString)

            If FileIO.FileSystem.FileExists(SavePath) AndAlso
                FileIO.FileSystem.GetFileInfo(SavePath).Length > 1024 Then
                Dim ExistsData = SavePath.LoadXml(Of BacteriaGenome)()
                ''有些数据由于解析的缘故，是错误的，故而在这里需要进行校验：后续的过程之中可以将这部分的校验代码进行删除
                'Dim LQuery = (From item In ExistsData.Regulons.Regulators
                '              Let EmptyValues = (From site In item.RegulatorySites Where site.Position = 0 Select site).ToArray
                '              Where EmptyValues.IsNullOrEmpty = False Select EmptyValues).ToArray.MatrixToVector
                'If Not LQuery.IsNullOrEmpty Then
                '    GoTo RE_DOWNLOAD       '这里的数据是错误的，需要进行重新下载
                'End If

                Return ExistsData
            End If

RE_DOWNLOAD:
            Dim BacteriaGenome As BacteriaGenome = New BacteriaGenome With {
                .genome = New WebServices.JSONLDM.genome With {
                    .name = Entry.Key
                }
            }
            BacteriaGenome.regulons = WebAPI.DownloadRegulon(Entry.Value)
            Call BacteriaGenome.GetXml.SaveTo(SavePath)

            Return BacteriaGenome
        End Function

        ''' <summary>
        ''' 从KEGG数据库中下载调控因子的蛋白质序列
        ''' </summary>
        ''' <param name="Regprecise"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("Regulators.Downloads",
                   Info:="Downloads the protein sequence of the regulators which is archives in Regprecise database.")>
        Public Function DownloadRegulatorSequence(Regprecise As TranscriptionFactors, DownloadDIR As String) As FASTA.FastaFile
            Dim FileData As FASTA.FastaFile = New FASTA.FastaFile
            Using ErrLog As New LogFile($"{DownloadDIR}/DownloadError_{Now.ToString.NormalizePathString}.log")
                For Each Bacteria As BacteriaGenome In Regprecise.genomes
                    Dim downloads = (From regulator As Regulator
                                     In Bacteria.regulons.regulators
                                     Let fa As FASTA.FastaToken = __downloads(regulator, Bacteria, ErrLog, DownloadDIR)
                                     Where Not fa Is Nothing
                                     Select fa).ToArray
                    Call FileData.AddRange(downloads)
                Next
            End Using

            Return FileData
        End Function

        Private Function __downloads(regulator As Regulator,
                                     genome As BacteriaGenome,
                                     ErrLog As LogFile,
                                     DownloadDIR As String) As FASTA.FastaToken

            If regulator.Type = Regulator.Types.RNA Then
                Return Nothing
            End If

            If String.IsNullOrEmpty(regulator.LocusTag.Key) Then
                Dim exMsg As String = $"[null_LOCUS_ID] [Regulog={regulator.Regulog.Key}] [Bacteria={genome.genome.name}]" & vbCrLf
                Call ErrLog.WriteLine(exMsg, "", MSG_TYPES.INF)
                Return Nothing
            End If

            Dim FastaSaved As String = String.Format("{0}/{1}.fasta", DownloadDIR, regulator.LocusTag.Key)
            Dim FastaObject = RegulatorDownloads(regulator, genome, ErrLog, DownloadDIR, FastaSaved)
            Return FastaObject
        End Function
    End Module
End Namespace
