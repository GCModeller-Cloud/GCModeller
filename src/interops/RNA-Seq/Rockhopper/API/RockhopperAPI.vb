﻿#Region "Microsoft.VisualBasic::5e93834497b3a0253ae1aa5f833c8091, RNA-Seq\Rockhopper\API\RockhopperAPI.vb"

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

    '     Module RockhopperAPI
    ' 
    '         Function: BatchAnalysis, CliCommon, DE_NOVO_ASSEMBLY, DifferentExpressionTesting, DifferentTSSs
    '                   GenerateModelData, GenerateRow, GetTranscript, Install, KEGGAnalysis
    '                   (+2 Overloads) LengthDistributions, LoadOperonsAsDoor, LoadTranscriptResult, OperonDiffTest, ParsingRegionSequence
    '                   RockhopperExternalCli, SaveData, SaveDifferent, TransFasta, TransFastaBatch
    '                   TSSsCategories
    ' 
    '         Sub: RunProgram
    '         Structure GeneStructures
    ' 
    '             Properties: _5UTR, PromoterBox, TSSs, TTSs
    ' 
    '             Function: Load, (+2 Overloads) Save
    ' 
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Linq
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.DocumentFormat.Csv.Extensions
Imports LANS.SystemsBiology.ComponentModel
Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat.FastaObjects
Imports LANS.SystemsBiology.SequenceModel.FASTA
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat
Imports LANS.SystemsBiology.Assembly.DOOR
Imports LANS.SystemsBiology.SequenceModel.NucleotideModels

Namespace AnalysisAPI

    <[PackageNamespace]("Rockhopper",
                        Description:="Computational analysis of bacterial RNA-Seq data",
                        Publisher:="McClure, R.<br />
Balasubramanian, D.<br />
Sun, Y.<br />
Bobrovskyy, M.<br />
Sumby, P.<br />
Genco, C. A.<br />
Vanderpool, C. K.<br />
Tjaden, B.",
                        Cites:="McClure, R., et al. (2013). ""Computational analysis of bacterial RNA-Seq data."" Nucleic Acids Res 41(14): e140.
<p>	Recent advances in high-throughput RNA sequencing (RNA-seq) have enabled tremendous leaps forward in our understanding of bacterial transcriptomes. However, computational methods for analysis of bacterial transcriptome data have not kept pace with the large and growing data sets generated by RNA-seq technology. Here, we present new algorithms, specific to bacterial gene structures and transcriptomes, for analysis of RNA-seq data. The algorithms are implemented in an open source software system called Rockhopper that supports various stages of bacterial RNA-seq data analysis, including aligning sequencing reads to a genome, constructing transcriptome maps, quantifying transcript abundance, testing for differential gene expression, determining operon structures and visualizing results. We demonstrate the performance of Rockhopper using 2.1 billion sequenced reads from 75 RNA-seq experiments conducted with Escherichia coli, Neisseria gonorrhoeae, Salmonella enterica, Streptococcus pyogenes and Xenorhabdus nematophila. We find that the transcriptome maps generated by our algorithms are highly accurate when compared with focused experimental data from E. coli and N. gonorrhoeae, and we validate our system's ability to identify novel small RNAs, operons and transcription start sites. Our results suggest that Rockhopper can be used for efficient and accurate analysis of bacterial RNA-seq data, and that it can aid with elucidation of bacterial transcriptomes.

",
                        Url:="http://cs.wellesley.edu/~btjaden/Rockhopper")>
    Public Module RockhopperAPI

        <ExportAPI("Length-Distrib")>
        Public Function LengthDistributions(Fasta As LANS.SystemsBiology.SequenceModel.FASTA.FastaFile) As Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.File
            Dim LQuery = (From Token In Fasta.AsParallel
                          Select Token.Length
                          Group Length By Length Into Count).ToArray.ToDictionary(Function(obj) obj.Length, elementSelector:=Function(obj) obj.Count)
            Dim Max = LQuery.Keys.Max
            Dim CsvRow = New String() {"Counts"}.Join((From i As Integer In Max.Sequence Select CStr(If(LQuery.ContainsKey(i), LQuery(key:=i), 0))).ToArray).ToCsvRow
            Dim Csv = New Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.File
            Call Csv.Add(New String() {"Length"}.Join((From i As Integer In Max.Sequence Select CStr(i)).ToArray).ToCsvRow)
            Call Csv.Add(CsvRow)
            Return Csv
        End Function

        <ExportAPI("Length-Distrib")>
        Public Function LengthDistributions(<Parameter("Dir.Source")> DIR As String,
                                            <Parameter("Filter")> Optional FilterKey As String = "*.fasta",
                                            Optional Max As Integer = 1000,
                                            Optional delta As Integer = 10) As DocumentStream.File

            Dim Entries = (From pathEntry As NamedValue(Of String)
                           In DIR.LoadEntryList(FilterKey).AsParallel
                           Select Name = pathEntry.Name,
                               Path = pathEntry.x,
                               Fasta = FastaFile.Read(pathEntry.x)).ToArray
            Dim LQuery = (From Entry
                          In Entries.AsParallel
                          Select Entry.Name,
                              Parent = FileIO.FileSystem.GetDirectoryInfo(FileIO.FileSystem.GetParentPath(Entry.Path)).Name,
                              distr = (From fa As FastaToken
                                       In Entry.Fasta
                                       Select fa.Length
                                       Group Length By Length Into Count) _
                                            .ToDictionary(Function(x) x.Length,
                                                          Function(x) x.Count)).ToArray
            Dim mxTmp As Integer = (From x
                                    In LQuery
                                    Select mmm = (From nnn As KeyValuePair(Of Integer, Integer)
                                                  In x.distr
                                                  Select nnn.Key).Max).Max
            Max = If(mxTmp > Max, Max, mxTmp)
            Dim Csv As New DocumentStream.File
            Dim temp As New List(Of String)

            For i As Integer = 0 To Max Step delta
                Call temp.Add(i)
            Next

            Call Csv.Add(New String() {"Length"}.Join(temp).ToCsvRow)
            Call Csv.AppendRange((From File In LQuery
                                  Select New String() {File.Name & "/" & File.Parent}.Join(GenerateRow(File.distr, Max, delta)).ToCsvRow).ToArray)
            Return Csv
        End Function

        Private Function GenerateRow(hash As Dictionary(Of Integer, Integer), Max As Integer, Delkta As Integer) As List(Of String)
            Dim List As New List(Of String)
            Dim pre As Integer = 0

            For i As Integer = Delkta To Max Step Delkta
                Dim index = i
                Dim LQuery = (From item In hash Where item.Key.RangesAt(pre, index) Select item.Value).ToArray.Sum
                Call List.Add(CStr(LQuery))

                pre = i
            Next

            Return List
        End Function

        <ExportAPI("CreateModel")>
        Public Function GenerateModelData(data As IEnumerable(Of TSSAR.Reads.GeneAssociationView), PTT As PTT) As Transcripts()
            Return Transcripts.FromReadsMap(data, PTT)
        End Function

        <ExportAPI("Write.Csv.Transcripts")>
        Public Function SaveData(data As IEnumerable(Of Transcripts), SaveTo As String) As Boolean
            Return data.SaveTo(SaveTo, False)
        End Function

        <ExportAPI("Rockhopper.jar.install")>
        Public Function Install(jar As String) As Boolean

            If String.IsNullOrEmpty(jar) OrElse Not jar.FileExists Then
                Call Console.WriteLine($"[DEBUG {Now.ToString}]  {jar} is not a valid path!")
                Return False
            End If

            Using Settings = Toolkits.RNA_Seq.Rockhopper.Settings.Session.Initialize
                Settings.Rockhopper = FileIO.FileSystem.GetFileInfo(jar).FullName
            End Using

            Return True
        End Function

        ''' <summary>
        ''' 批量导出来之后在批量的和基因组序列进行blastn比对，之后根据位置找出可能的基因和假定的基因
        ''' </summary>
        ''' <param name="SourceDir"></param>
        ''' <param name="ExportDir"></param>
        ''' <returns></returns>
        <ExportAPI("TransFasta")>
        Public Function TransFastaBatch(<Parameter("Dir.Source")> SourceDir As String,
                                        <Parameter("Dir.Export")> ExportDir As String) As Boolean
            Dim LQuery = (From pathEntry As String
                          In FileIO.FileSystem.GetFiles(SourceDir, FileIO.SearchOption.SearchAllSubDirectories, "*transcripts.txt").AsParallel
                          Let Fasta = Rockhopper.AnalysisAPI.DeNovolTranscript.LoadDocument(pathEntry)
                          Let Name = FileIO.FileSystem.GetFileInfo(pathEntry).Directory.Name
                          Select Fasta, Name).ToArray
            For Each item In LQuery
                Call item.Fasta.Save($"{ExportDir}/{item.Name}.fasta")
            Next
            Return True
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="denovol">Rockhopper de novol ===> transcripts.txt</param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("TransFasta", Info:="Transfer the rockhopper de novol result as a fasta sequence file.")>
        Public Function TransFasta(denovol As String, Optional Saved As String = "") As FastaFile
            Dim Fasta = Rockhopper.AnalysisAPI.DeNovolTranscript.LoadDocument(denovol)
            If Not String.IsNullOrEmpty(Saved) Then
                Call Fasta.Save(Saved)
            End If
            Return Fasta
        End Function

        ''' <summary>
        ''' 从头装配
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' EXAMPLE EXECUTION: DE NOVO ASSEMBLY WITH PAIRED-END READS
        '''
        ''' java Rockhopper &lt;options> aerobic_replicate1_pairedend1.fastq%aerobic_replicate1_pairedend2.fastq,aerobic_replicate2_pairedend1.fastq%aerobic_replicate2_pairedend2.fastq anaerobic_replicate1_pairedend1.fastq%anaerobic_replicate1_pairedend2.fastq,anaerobic_replicate2_pairedend1.fastq%anaerobic_replicate2_pairedend2.fastq
        ''' </remarks>
        <ExportAPI("Rockhopper", Info:="DE NOVO ASSEMBLY WITH PAIRED-END READS, " &
                                     "Computational analysis of bacterial RNA-Seq data. please notice that this function required of the java and rockhopper.jar program was installed on your computer system.")>
        Public Function DE_NOVO_ASSEMBLY(<Parameter("Fastaq")> Fastaq As IEnumerable(Of String()),
                                         <Parameter("Dir.Out", "The directory which is the data output dir of the rockhopper analysis")> Optional Output As String = "") As Integer

            Dim RockhopperJar As String = ""
            Dim Java As String = ""
            Dim Tmp As Integer

            If CliCommon(Java, RockhopperJar).ShadowCopy(Tmp) <> 0 Then
                Return Tmp
            End If

            '对外部的Rockhopper进行命令行调用
            Dim cli As String = $"-Xmx1200m -cp {RockhopperJar.CliPath} Rockhopper -SAM -TIME "
            If Not String.IsNullOrEmpty(Output) Then
                cli &= $"-o {Output.CliPath} "
                Call FileIO.FileSystem.CreateDirectory(Output)
            End If

            cli &= """" & String.Join(",", (From Token In Fastaq Select $"{Token(0).CliPath}%%{Token(1).CliPath}").ToArray) & """"

            Dim Folk = New CommandLine.IORedirectFile(Java, cli)
            Dim rtvl As Integer = Folk.Run()

            Call Console.WriteLine()
            Call Console.WriteLine(Folk.StandardOutput)

            Return rtvl
        End Function

        Private Function CliCommon(ByRef Java As String, ByRef RockhopperJar As String) As Integer
            Using Settings = Rockhopper.Settings.Session.Initialize
                Java = Settings.Java
                RockhopperJar = Settings.Rockhopper
            End Using

            If Not RockhopperJar.FileExists Then
                Call Console.WriteLine($"[DEBUG {Now.ToString}] The invoked jar executable assembly file ""{RockhopperJar}""  is not exists on your filesystem!")
                Return -1
            End If

            If Not Java.FileExists Then
                Call Console.WriteLine($"[DEBUG] {Now.ToString} The required java environment is not exists on {Java.CliPath}!")
                Return -2
            End If

            Return 0
        End Function

        ''' <summary>
        ''' Rockhopper from external executable assembly
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' java Rockhopper &lt;options> -g genome_DIR1,genome_DIR2 aerobic_replicate1_pairedend1.fastq%aerobic_replicate1_pairedend2.fastq,aerobic_replicate2_pairedend1.fastq%aerobic_replicate2_pairedend2.fastq anaerobic_replicate1_pairedend1.fastq%anaerobic_replicate1_pairedend2.fastq,anaerobic_replicate2_pairedend1.fastq%anaerobic_replicate2_pairedend2.fastq
        ''' </remarks>
        <ExportAPI("Rockhopper",
                   Info:="Computational analysis of bacterial RNA-Seq data. please notice that this function required of the java and rockhopper.jar program was installed on your computer system.")>
        Public Function RockhopperExternalCli(<Parameter("Dir.PTT", "The directory which contains the ptt genome annotation file downloaded from ncbi website.")> PTT As String,
                                              <Parameter("Fastaq", "If the data is the paired-end type, then each token in this parameter should at least have 2 elements, else at least 1 element for single-end data.")>
                                                               Fastaq As IEnumerable(Of String()),
                                              <Parameter("Dir.Out", "The directory which is the data output dir of the rockhopper analysis")> Optional Output As String = "") As Integer
            Dim RockhopperJar As String = ""
            Dim Java As String = ""
            Dim Tmp As Integer

            If CliCommon(Java, RockhopperJar).ShadowCopy(Tmp) <> 0 Then
                Return Tmp
            End If

            '对外部的Rockhopper进行命令行调用
            Dim cli As String = $"-Xmx1200m -cp {RockhopperJar.CliPath} Rockhopper -SAM -TIME "
            If Not String.IsNullOrEmpty(Output) Then
                cli &= $"-o {Output.CliPath} "
                Call FileIO.FileSystem.CreateDirectory(Output)
            End If

            cli &= $"-g {PTT.CliPath} "
            If Fastaq.First.Count > 1 Then '双向测序的Reads数据，则只取两个值就够了
                cli &= """" & String.Join(",", (From Token In Fastaq Select $"{Token(0).CliPath}%%{Token(1).CliPath}").ToArray) & """"
            Else                           '单向测序的数据，则只取第一个值就可以了
                cli &= """" & String.Join(",", (From Token In Fastaq Select Token(0).CliPath).ToArray) & """"
            End If

            Dim Folk = New CommandLine.IORedirectFile(Java, cli)
            Dim rtvl As Integer = Folk.Run()

            Call Console.WriteLine()
            Call Console.WriteLine(Folk.StandardOutput)

            Return rtvl
        End Function

        <ExportAPI("Run.Analysis")>
        Public Sub RunProgram(argv As IEnumerable(Of String))
            Call Rockhopper.Java.CLI_API.Main(argv)
        End Sub

        <ExportAPI("Load.Transcripts")>
        Public Function LoadTranscriptResult(Path As String) As Transcripts()
            Return AnalysisAPI.TSSsAnalysis.LoadResult(Path)
        End Function

        <ExportAPI("Load.Operons")>
        Public Function LoadOperonsAsDoor(Path As String, PTT As PTT) As DOOR

            Dim PredictedData As Operon()
            Try
                PredictedData = AnalysisAPI.LoadOperonResult(Path)
            Catch ex As Exception
                Call Console.WriteLine("[EXCEPTION] " & Path.ToFileURL)
                Throw
            Finally
                Call Console.WriteLine("Trimming data.....")
            End Try
            PredictedData = AnalysisAPI.SubstituteID(PredictedData, PTT)
            Dim Door = AnalysisAPI.GenerateDoorOperon(PredictedData, PTT)
            Return Door
        End Function

        ''' <summary>
        ''' 假若所返回的字符串数组是空的，则说明两个条件下的数据都是一致的
        ''' </summary>
        ''' <param name="Condition1"></param>
        ''' <param name="Condition2"></param>
        ''' <returns></returns>
        <ExportAPI("Diff.Operons", Info:="This function returns the operons genes where it is different between two conditions. If the return list is empty, that means the two condition prediction result is consists.")>
        Public Function OperonDiffTest(Condition1 As DOOR, Condition2 As DOOR) As String()
            Dim Test1 = (From Operon In Condition1.DOOROperonView.Operons Select Operon.TestGuid Order By TestGuid Ascending).ToArray
            Dim Test2 = (From Operon In Condition2.DOOROperonView.Operons Select Operon.TestGuid Order By TestGuid Ascending).ToList
            Dim LQuery = (From Operon In Test1.AsParallel Where Test2.IndexOf(Operon) = -1 Select Operon).ToArray

            Return LQuery
        End Function

        <ExportAPI("RegionSequence.Parsed",
                   Info:="If some sequence is not appeared in the output fasta, it may be the sequence length of the object is smaller then 6")>
        Public Function ParsingRegionSequence(data As IEnumerable(Of Transcripts), Genome As FastaToken, Export As String) As Boolean

            Dim ASCII = System.Text.Encoding.ASCII
            Dim gStructure = New GeneStructures With {
                .PromoterBox = AnalysisAPI.TSSsAnalysis.ParsingPromoterBox(data.ToArray, Genome),
                ._5UTR = AnalysisAPI.TSSsAnalysis.Parsing5UTR(data.ToArray, Genome),
                .TTSs = AnalysisAPI.TSSsAnalysis.ParsingTTSs(data.ToArray, Genome),
                .TSSs = AnalysisAPI.TSSsAnalysis.ParsingTSSs(data.ToArray, Genome)}

            Return gStructure.Save(Export, ASCII)
        End Function

        Public Structure GeneStructures : Implements ISaveHandle

            Public Property PromoterBox As LANS.SystemsBiology.SequenceModel.FASTA.FastaFile
            Public Property _5UTR As LANS.SystemsBiology.SequenceModel.FASTA.FastaFile
            Public Property TTSs As LANS.SystemsBiology.SequenceModel.FASTA.FastaFile
            Public Property TSSs As LANS.SystemsBiology.SequenceModel.FASTA.FastaFile

            Public Function Save(Optional ExportDir As String = "", Optional encoding As Encoding = Nothing) As Boolean Implements ISaveHandle.Save
                If encoding Is Nothing Then encoding = System.Text.Encoding.ASCII
                If String.IsNullOrEmpty(ExportDir) Then ExportDir = "./"

                Dim a = PromoterBox.Save(ExportDir & "/PromoterBox.fasta", encoding)
                Dim b = _5UTR.Save(ExportDir & "/5_UTR.fasta", encoding)
                Dim c = TTSs.Save(ExportDir & "/TTSs.fasta", encoding)
                Dim d = TSSs.Save(ExportDir & "/TSSs.fasta", encoding)

                Return a AndAlso b AndAlso c
            End Function

            Public Shared Function Load(Dir As String) As GeneStructures
                Dim gStructure As GeneStructures = New GeneStructures With {
                    .PromoterBox = LANS.SystemsBiology.SequenceModel.FASTA.FastaFile.Read(Dir & "/PromoterBox.fasta"),
                    .TSSs = LANS.SystemsBiology.SequenceModel.FASTA.FastaFile.Read(Dir & "/TSSs.fasta"),
                    .TTSs = LANS.SystemsBiology.SequenceModel.FASTA.FastaFile.Read(Dir & "/TTSs.fasta"),
                    ._5UTR = LANS.SystemsBiology.SequenceModel.FASTA.FastaFile.Read(Dir & "/5_UTR.fasta")
                }
                Return gStructure
            End Function

            Public Function Save(Optional Path As String = "", Optional encoding As Encodings = Encodings.UTF8) As Boolean Implements ISaveHandle.Save
                Return Save(Path, encoding.GetEncodings)
            End Function
        End Structure

        ''' <summary>
        ''' 差异表达基因前面的调控位点的分析
        ''' 
        ''' 发生变化
        '''	    表达量变高;
        '''	    表达量降低.
        ''' 
        ''' 没有发生变化
        ''' 	始终高表达;
        ''' 	始终低表达;
        ''' 	都没有表达.
        ''' </summary>
        ''' <returns></returns>
        ''' 
        <ExportAPI("Expr.Different")>
        Public Function DifferentExpressionTesting(Condition1 As System.Collections.Generic.IEnumerable(Of Transcripts),
                                                   Condition2 As System.Collections.Generic.IEnumerable(Of Transcripts),
                                                   Genome As LANS.SystemsBiology.SequenceModel.FASTA.FastaToken,
                                                   Export As String) As Boolean
            Dim LQuery = (From Tr In Condition1.AsParallel Let Tr2 = GetTranscript(Tr.Synonym, Condition2)
                          Where Not Tr2 Is Nothing'生成用于进行差异表达计算
                          Select cd1 = Tr, cd2 = Tr2, dExpr = 2 ^ (-1 * (Tr.Expression - Tr2.Expression))).ToArray
            '进行差异性的分组
            Dim dUp = (From item In LQuery.AsParallel Where item.dExpr >= 2 Select item).ToArray
            Dim dDown = (From item In LQuery.AsParallel Where item.dExpr <= 0.1 Select item).ToArray
            Dim NoChanges = (From item In LQuery.AsParallel Where Not (item.dExpr >= 2 OrElse item.dExpr <= 0.1) Select item).ToArray '后面的等级映射过程由于需要进行位置的一一对应，所以不可以再使用并行拓展
            Dim LvMappingOfNoChanges = (From item In NoChanges Select {item.cd1.Expression, item.cd2.Expression}).ToArray.MatrixToList.GenerateMapping(100)     '进行等级映射
            Dim ChunkTemp = LvMappingOfNoChanges.Split(parTokens:=2)

            For i As Integer = 0 To ChunkTemp.Count - 1
                Dim element = NoChanges(i)
                Dim exprData = ChunkTemp(i)
                element.cd1.Expression = exprData(0)
                element.cd2.Expression = exprData(1)
            Next

            '高表达： 等级在85以上
            '低表达： 等级在20到85之间
            '没有表达： 等级在20一下

            Dim HighLevel = (From item In NoChanges Where 0.5 * (item.cd1.Expression + item.cd2.Expression) >= 85 Select item).ToArray
            Dim LowLevel = (From item In NoChanges Let dddd = 0.5 * (item.cd1.Expression + item.cd2.Expression) Where dddd >= 20 AndAlso dddd < 85 Select item).ToArray
            Dim NoExpression = (From item In NoChanges Where 0.5 * (item.cd1.Expression + item.cd2.Expression) < 20 Select item).ToArray

            '分别导出序列数据，进行特征分析
            Dim Dir As String

            Dir = Export & "/Up/" : Call ParsingRegionSequence((From item In dUp Select item.cd1).ToArray.Join((From item In dUp Select item.cd2).ToArray), Genome, Dir)
            Dir = Export & "/Down/" : Call ParsingRegionSequence((From item In dDown Select item.cd1).ToArray.Join((From item In dDown Select item.cd2).ToArray), Genome, Dir)
            Dir = (Export & "/NoChanges/").ShadowCopy(Export)
            Dir = Export & "/HighLevel/" : Call ParsingRegionSequence((From item In HighLevel Select item.cd1).ToArray.Join((From item In HighLevel Select item.cd2).ToArray), Genome, Dir)
            Dir = Export & "/LowLevel/" : Call ParsingRegionSequence((From item In LowLevel Select item.cd1).ToArray.Join((From item In LowLevel Select item.cd2).ToArray), Genome, Dir)
            Dir = Export & "/NoExpression/" : Call ParsingRegionSequence(data:=(From item In NoExpression Select item.cd1).ToArray.Join((From item In NoExpression Select item.cd2).ToArray), Genome:=Genome, Export:=Dir)

            Return True
        End Function

        Private Function GetTranscript(ID As String, Data As System.Collections.Generic.IEnumerable(Of Transcripts)) As Transcripts
            Dim LQuery = (From Tr In Data Where String.Equals(ID, Tr.Synonym) Select Tr).ToArray
            Return LQuery.FirstOrDefault
        End Function

        <ExportAPI("TSSs.Different")>
        Public Function DifferentTSSs(condition1 As IEnumerable(Of Transcripts), condition2 As IEnumerable(Of Transcripts), KEGG As String) As TSSsDifferent()
            Dim KEGG_data = (From xml As String In FileIO.FileSystem.GetFiles(KEGG, FileIO.SearchOption.SearchAllSubDirectories, "*.xml").AsParallel Select xml.LoadXml(Of LANS.SystemsBiology.Assembly.KEGG.DBGET.bGetObject.Pathway)).ToArray
            Return AnalysisAPI.TSSsAnalysis.DifferentTSSs(condition1.ToArray, condition2.ToArray, KEGG_data)
        End Function

        <ExportAPI("Write.Csv.Different")>
        Public Function SaveDifferent(data As IEnumerable(Of TSSsDifferent), SaveTo As String) As Boolean
            Return data.SaveTo(SaveTo, False)
        End Function

        <ExportAPI("KEGG.Different")>
        Public Function KEGGAnalysis(TSSS As IEnumerable(Of TSSsDifferent), KEGG As String) As DocumentStream.File
            Return AnalysisAPI.TSSsAnalysis.KEGGDifferent(TSSS.ToArray, (From xml As String In FileIO.FileSystem.GetFiles(KEGG, FileIO.SearchOption.SearchAllSubDirectories, "*.xml").AsParallel Select xml.LoadXml(Of LANS.SystemsBiology.Assembly.KEGG.DBGET.bGetObject.Pathway)).ToArray)
        End Function

        <ExportAPI("TSSs.Category")>
        Public Function TSSsCategories(TSSs As IEnumerable(Of Rockhopper.AnalysisAPI.Transcripts), PTT As PTT, Optional Fasta As FastaToken = Nothing) As DocumentStream.File
            Dim Reader As SegmentReader = Nothing

            If Not Fasta Is Nothing Then
                Reader = New SequenceModel.NucleotideModels.SegmentReader(Fasta)
            End If

            Dim LQuery = (From Transcript As Rockhopper.AnalysisAPI.Transcripts In TSSs.AsParallel
                          Let GetCategory = Function() As KeyValuePair(Of Rockhopper.AnalysisAPI.Transcripts.Categories, LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat.ComponentModels.GeneBrief)
                                                Dim RelatedGene As LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat.ComponentModels.GeneBrief = Nothing
                                                Dim cat = TSSsCategory.Category(Transcript, PTT, Reader, RelatedGene)
                                                Return New KeyValuePair(Of Rockhopper.AnalysisAPI.Transcripts.Categories, LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat.ComponentModels.GeneBrief)(cat, RelatedGene)
                                            End Function()
                          Select Loci = Transcript.GetTULoci.ToString,
                              Transcript.Synonym,
                              Category = GetCategory.Key.ToString,
                              Transcript.ATG,
                              Transcript.TGA,
                              Transcript.Strand,
                              TSSLoci = Transcript.TSSs,
                              Transcript.TTSs,
                              Transcript.Minus35BoxLoci,
                              Transcript.Leaderless,
                              Transcript.Is_sRNA,
                              Transcript.IsRNA,
                              Transcript.IsPredictedRNA,
                              RelatedGeneID = GetCategory.Value.Synonym,
                              RelatedGeneStrand = GetCategory.Value.Location.Strand.ToString,
                              RelatedGeneLoci = GetCategory.Value.Location.ToString
                              ).ToArray
            Dim ChunkBuffer = LQuery.ToCsvDoc(False)
            Return ChunkBuffer
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="SourceDir"></param>
        ''' <param name="PTT"></param>
        ''' <param name="Door"></param>
        ''' <param name="Fasta">整个基因组的核酸序列</param>
        ''' <param name="Split"></param>
        ''' <returns></returns>
        <ExportAPI("TSSs.BatchAnalysis")>
        Public Function BatchAnalysis(SourceDir As String,
                                      PTT As PTT,
                                      Door As DOOR,
                                      Optional Fasta As FastaToken = Nothing,
                                      Optional Split As Boolean = False) As DocumentStream.File

            Call Console.WriteLine("The target source directory is " & SourceDir)

            Dim Files = (From path As String
                         In FileIO.FileSystem.GetFiles(SourceDir, FileIO.SearchOption.SearchAllSubDirectories, "*_transcripts.txt")
                         Let parent As String = FileIO.FileSystem.GetDirectoryInfo(FileIO.FileSystem.GetParentPath(path)).Name
                         Select parent, path).ToArray
            Call Console.WriteLine($"Get {Files.Count } data entries....")
            Dim LQuery = (From file In Files.AsParallel
                          Select file, dataChunk = AnalysisAPI.TSSsAnalysis.LoadResult(file.path)).ToArray
            Dim Operons = (From path As String In FileIO.FileSystem.GetFiles(SourceDir, FileIO.SearchOption.SearchAllSubDirectories, "*_operons.txt")
                           Let parent As String = FileIO.FileSystem.GetDirectoryInfo(FileIO.FileSystem.GetParentPath(path)).Name
                           Select parent, Operon = RockhopperAPI.LoadOperonsAsDoor(path, PTT)).ToArray.ToDictionary(Function(obj) obj.parent)

            '将Transcripts和Operon集合在一起
            Dim GroupData = (From transcript In LQuery Select transcript.file, transcript.dataChunk, operon = Operons(transcript.file.parent)).ToArray
            Dim DoorOperonView = Door.DOOROperonView
            Dim Reader As LANS.SystemsBiology.SequenceModel.NucleotideModels.SegmentReader = Nothing

            If Not Fasta Is Nothing Then
                Reader = New SequenceModel.NucleotideModels.SegmentReader(Fasta)
            End If

            Dim ResultLQuery = (From file In GroupData.AsParallel
                                Let predictedOperons = file.operon.Operon.DOOROperonView
                                Let path As String = SourceDir & "/" & FileIO.FileSystem.GetDirectoryInfo(file.file.parent).Name & ".csv"
                                Let ChunkBuffer = (From Transcript As Rockhopper.AnalysisAPI.Transcripts In file.dataChunk.AsParallel
                                                   Let DoorObject = Door.GetGene(Transcript.Synonym)
                                                   Let predictedOperon = file.operon.Operon.GetGene(Transcript.Synonym)
                                                   Let GetCategory = Function() As KeyValuePair(Of Rockhopper.AnalysisAPI.Transcripts.Categories, LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat.ComponentModels.GeneBrief)
                                                                         Dim RelatedGene As LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat.ComponentModels.GeneBrief = Nothing
                                                                         Dim cat = TSSsCategory.Category(Transcript, PTT, Reader, RelatedGene)
#Const DEBUG = 1
#If DEBUG Then
                                                                         If RelatedGene Is Nothing Then
                                                                             Call Console.WriteLine($"[ERROR] null related gene data at {Transcript.ToString}// category ===> {cat.ToString}")
                                                                         End If
#End If
                                                                         Return New KeyValuePair(Of Rockhopper.AnalysisAPI.Transcripts.Categories, LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat.ComponentModels.GeneBrief)(cat, RelatedGene)
                                                                     End Function()
                                                   Let CategoryEn = GetCategory.Key
                                                   Select Loci = Transcript.GetTULoci.ToString,
                                          Transcript.Synonym,
                                          Category = CategoryEn.ToString,
                                          CategoryEn,
                                          Transcript.ATG,
                                          Transcript.TGA,
                                          Transcript.Strand,
                                          TSSLoci = Transcript.TSSs,
                                          ATG_Dist = If(Transcript.ATG > 0 And Transcript.TSSs > 0, (Transcript.TSSs - Transcript.ATG) * If(String.Equals(Transcript.Strand, "+"), -1, 1), -1),
                                          Transcript.TTSs,
                                          Transcript.Minus35BoxLoci,
                                          Transcript.Leaderless,
                                          Transcript.Is_sRNA,
                                          Transcript.IsRNA,
                                          Transcript.IsPredictedRNA,
                                          predictedOperon = If(predictedOperon Is Nothing, "", predictedOperon.OperonID),
                                          isPredictedOperonPromoter = If(predictedOperon Is Nothing, False, predictedOperons(predictedOperon.OperonID).InitialX.Synonym.Equals(Transcript.Synonym)),
                                          DoorID = If(DoorObject Is Nothing, "", DoorObject.OperonID),
                                          IsDoorPromoter = If(DoorObject Is Nothing, False, DoorOperonView(DoorObject.OperonID).InitialX.Synonym.Equals(Transcript.Synonym)),
                                          Condition = file.file.parent,
                                                         RelatedGeneID = GetCategory.Value.Synonym,
                              RelatedGeneStrand = GetCategory.Value.Location.Strand.ToString,
                              RelatedGeneLoci = GetCategory.Value.Location.ToString,
                                                       MTU_Length = Transcript.TranscriptLength).ToArray
                                Let SplitSaved = Function() As Integer
                                                     If Split Then
                                                         Dim Csv = ChunkBuffer.ToCsvDoc(False)
                                                         Dim saved = Csv.Save(path, False)
                                                     End If

                                                     Return 0
                                                 End Function()
                                Select ChunkBuffer).ToArray.MatrixToList

            Call Console.WriteLine("Distinct group data....")
            '去除掉重复的无前导序列的mrna的数据
            Dim DistinctGroup = (From item In ResultLQuery.AsParallel Let guid = item.Loci & item.Synonym & item.Category Select guid, item Group By guid Into Group).ToArray
            ResultLQuery = (From item In DistinctGroup Select item.Group.First.item).ToList

            Call Console.WriteLine("Create classes distribution views....")
            '汇总长度分布
            Dim Classesss = (From transcript In ResultLQuery.AsParallel
                             Where transcript.CategoryEn = Transcripts.Categories.lmTSS OrElse
                                 transcript.CategoryEn = Transcripts.Categories.seTSS OrElse
                                 transcript.CategoryEn = Transcripts.Categories.mTSS OrElse
                                 transcript.CategoryEn = Transcripts.Categories.pmTSS OrElse
                                 transcript.CategoryEn = Transcripts.Categories.ULmTSS
                             Select transcript
                             Group transcript By transcript.CategoryEn Into Group).ToArray
            Dim DistanceView = (From type In Classesss.AsParallel
                                Let data = (From d As Integer In 500.Sequence Select distance = d, (From transcript In type.Group Where transcript.ATG_Dist = d Select 1).ToArray.Count).ToArray
                                Let rowCells = New String() {type.CategoryEn.ToString}.Join((From nnn In data Select CStr(nnn.Count)).ToArray)
                                Select rowCells.ToCsvRow).ToArray
            Call CType(DistanceView, Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.File).Save(SourceDir & "/DistanceView.csv", False)
            Call Console.WriteLine("Write summary result....")

            Dim CsvResult = ResultLQuery.ToCsvDoc(False)
            Call CsvResult.Save(SourceDir & "/RockhopperResult.csv", False)
            Call Console.WriteLine("Job Done!")

            Return CsvResult
        End Function
    End Module
End Namespace
