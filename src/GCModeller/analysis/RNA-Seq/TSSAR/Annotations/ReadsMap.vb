﻿Imports System.Drawing
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic
Imports Oracle.Java.IO.Properties.Reflector
Imports LANS.SystemsBiology.Toolkits.RNA_Seq.BOW
Imports LANS.SystemsBiology.ComponentModel.Loci
Imports LANS.SystemsBiology.Assembly.NCBI.GenBank
Imports Microsoft.VisualBasic.ComponentModel
Imports LANS.SystemsBiology.Toolkits.RNA_Seq.BOW.DocumentFormat.SAM.DocumentElements
Imports LANS.SystemsBiology.Assembly.NCBI.GenBank.TabularFormat
Imports LANS.SystemsBiology.AnalysisTools.DataVisualization
Imports LANS.SystemsBiology.AnalysisTools.DataVisualization.ChromosomeMap
Imports LANS.SystemsBiology.Assembly.DOOR
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Linq

''' <summary>
''' 统计一个rna-seq文库之中的每一个碱基的频数
''' </summary>
''' 
<[Namespace]("ReadsMap")>
Public Module ReadsMap

    ''' <summary>
    ''' 获取目标Read片段的最左端的碱基位点的位置
    ''' </summary>
    ''' <param name="Read"></param>
    ''' <returns></returns>
    Public Function Left(Read As AlignmentReads) As Integer
        If Read.Strand = Strands.Forward Then
            Return Read.POS
        ElseIf Read.Strand = Strands.Reverse Then
            Return Read.POS - Read.Length
        Else
            Return Read.POS
        End If
    End Function

    Public Function OrderReads(data As IEnumerable(Of AlignmentReads)) As AlignmentReads()
        Dim LQuery = (From Read In data.AsParallel Select n_Left = Left(Read), Read Order By n_Left Ascending).ToArray
        data = (From Read In LQuery Select Read.Read).ToArray
        Return data
    End Function

    ''' <summary>
    ''' 绘制一段区域内的核酸序列之中的每一个碱基至上的Reads的频数
    ''' </summary>
    ''' <param name="SAM"></param>
    ''' <param name="RangeStart"></param>
    ''' <param name="RangeEnds"></param>
    ''' <param name="PTT"></param>
    ''' <param name="Config"></param>
    ''' <returns></returns>
    ''' 
    <ExportAPI("Map.Drawing")>
    Public Function MapDrawing(SAM As DocumentFormat.SAM.SAM,
                               <Parameter("Range.Start")> RangeStart As Long,
                               <Parameter("Range.Ends")> RangeEnds As Long,
                               PTT As PTT,
                               Config As ChromosomeMap.Configurations) As Image

        '筛选出符合范围限制内的所有的Reads
        Dim Ranges As New NucleotideLocation(RangeStart, RangeEnds, False)
        Dim Reads = (From Read In SAM.AlignmentsReads.AsParallel Where Read.RangeAt(Ranges) Select Read).ToArray

        Dim ScreeningGenes = (From Gene As ComponentModels.GeneBrief
                              In PTT.GeneObjects
                              Where Gene.Location.LociIsContact(Ranges)
                              Select Gene).ToArray '筛选出在该区域内的所有的基因对象的定义数据

        Config.LineLength = Ranges.FragmentSize / ChromosomeMap.DrawingDevice.MB_UNIT
        Config.Resolution = $"{Ranges.FragmentSize + Config.Margin * 4},{Config.Margin * 2}"

        '频数统计
        Dim HistoneGram = Ranges.GetResiduesLoci.ToDictionary(Function(i) i, Function(i) New Value(Of Integer))
        Dim LQuery = (From Read In Reads.AsParallel
                      Let loci = CreateLoci(Read).GetResiduesLoci
                      Select (From i As Long In loci Where HistoneGram.ContainsKey(i) Select i).ToArray)

        For Each ReadCoverage In LQuery
            For Each Loci In ReadCoverage
                HistoneGram(Loci).Value += 1
            Next
        Next

        Call Console.WriteLine("{0} genes was selected from ranges {1}", ScreeningGenes.Count, Ranges.ToString)

        '首先在这里生成基因组片段的绘图模型
        Dim Model = ChromesomeMapAPI.FromPttElements(ScreeningGenes, Config, Ranges.FragmentSize)
        'Dim Device = LANS.SystemsBiology.AnalysisTools.DataVisualization.ChromosomeMap.CreateDevice(Config)
        'Dim res = Device.InvokeDrawing(Model).Value.First

        Dim Gr = New Size(Ranges.FragmentSize + Config.Margin * 4, Config.Margin * 2 * 4 + 2 * Config.Margin).CreateGDIDevice

        'Call Gr.Gr_Device.DrawImage(res, 0, CSng(Gr.Height - res.Height))

        Dim Max = (From point In HistoneGram.Values Select point.Value).ToArray.Max
        Dim d As Integer = Gr.Height - 2 * Config.Margin
        Dim LinePen As New Pen(Color.Black)
        Dim x As Integer = Config.Margin
        Dim bottom = Gr.Height - Config.Margin * 2 * 4
        Dim ConfData = Config.ToConfigurationModel
        Dim ModelHash = (From Gene In Model.GeneObjects Select Gene Order By Gene.Left Ascending).ToDictionary(Function(Gene) CLng(Gene.Left))
        Dim PreRight As Integer = ModelHash.First.Value.Left + 5
        Dim Level As Integer

        For Each Point In HistoneGram
            Call Gr.Graphics.DrawLine(LinePen, New Point(x, bottom), New Point(x, bottom - bottom * (Point.Value.Value / d)))
            x += 1

            If ModelHash.ContainsKey(Point.Key) Then
                Dim GeneObject = ModelHash(Point.Key)

                Call Console.WriteLine("  > Drawing gene for   " & GeneObject.ToString)

                If GeneObject.Left < PreRight Then
                    Level += 1
                Else
                    Level = 0
                End If

                If GeneObject.Left > PreRight Then PreRight = GeneObject.Right

                GeneObject.Height = Config.GeneObjectHeight

                Dim drawingSize = GeneObject.Draw(Gr:=Gr.Graphics,
                                            Location:=New Point(x, bottom + Config.GeneObjectHeight + Level * 110),
                                            ConvertFactor:=1,
                                            RightLimited:=GeneObject.Right + 2, conf:=ConfData)

                'TSS的位置大概在ATG上有的54bp的位置
                Dim x1 = x + GeneObject.Direction * 60

                Call Gr.Graphics.FillRectangle(Brushes.Black, New Rectangle(x, bottom, 20, 20))
                Call Gr.Graphics.DrawString("TSS-" & GeneObject.LocusTag,
                                             New Font(FontFace.MicrosoftYaHei, 10),
                                             Brushes.Black,
                                             New Point(x1, bottom + 40))

                Call Gr.Graphics.DrawLine(LinePen, New Point(x, bottom), New Point(x, bottom + 20))
                Call Gr.Graphics.DrawLine(LinePen, New Point(GeneObject.Right, bottom), New Point(GeneObject.Right, bottom + 20))
                Call Gr.Graphics.DrawString(GeneObject.LocusTag, New Font(FontFace.MicrosoftYaHei, 12), Brushes.Black, New Point(x, bottom + 20))
            End If
        Next

        Call Gr.Graphics.DrawString(HistoneGram.First.Key, New Font(FontFace.MicrosoftYaHei, 12), Brushes.Black, New Point(Config.Margin, bottom))
        Call Gr.Graphics.DrawString(HistoneGram.Last.Key, New Font(FontFace.MicrosoftYaHei, 12), Brushes.Black, New Point(x, bottom))

        Return Gr.ImageResource
    End Function

    ''' <summary>
    ''' 使用这个函数进行绘图设备的配置参数的读取操作
    ''' </summary>
    ''' <param name="file"></param>  
    ''' <returns></returns>
    <ExportAPI("Read.TXT.Drawing_Config")>
    Public Function LoadConfig(File As String) As Configurations
        If Not File.FileExists Then
            Return ChromesomeMapAPI.GetDefaultConfiguration(File)
        Else
            Return File.LoadConfiguration(Of Configurations)()
        End If
    End Function

    Private Function CreateLoci(Read As AlignmentReads) As NucleotideLocation
        Return New NucleotideLocation(Read.POS, Read.POS + Read.Length, ComplementStrand:=Not Read.Strand = Strands.Forward)
    End Function

    <ExportAPI("TSS.rdDepth")>
    Public Function TSSStatics(SAM As DocumentFormat.SAM.SAM, PTT As PTT, Optional Debug As Boolean = False, Optional DOOR As DOOR = Nothing) As DocumentStream.File
        Dim TSSPossibleLocation = (From Gene As ComponentModels.GeneBrief
                                       In PTT.GeneObjects
                                   Let Loci = GetLocation(Gene)
                                   Select strand = Gene.Location.Strand,
                                       ID = Gene.Synonym,
                                       Loci,
                                       LociSequence = Loci.GetResiduesLoci).ToArray
        '频数统计
        Dim HistoneGram = (From loci
                           In TSSPossibleLocation.AsParallel
                           Select loci.LociSequence).MatrixAsIterator _
                                                    .Distinct _
                                                    .ToDictionary(Function(i) i,
                                                                  Function(i) New Value(Of Integer))
        Dim LQuery = From read As AlignmentReads
                     In SAM.AlignmentsReads.AsParallel
                     Let loci As Integer() = CreateLoci(read).GetResiduesLoci
                     Select (From i As Long
                             In loci
                             Where HistoneGram.ContainsKey(i)
                             Select i).ToArray

        For Each ReadCoverage As Long() In LQuery
            For Each Loci In ReadCoverage
                HistoneGram(Loci).Value += 1
            Next
        Next

        '将位点还原为标签
        Dim DipartsHistone = (From Loc In TSSPossibleLocation Select Loc.strand, Loc.Loci.UserTag, ID = Loc.ID, HisData = Reads(Loc.LociSequence, HistoneGram)).ToArray
        '生成CSV文档
        Dim Df As New Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.File
        Dim OperonPromoterGene As String() = Nothing

        If Not DOOR Is Nothing Then
            OperonPromoterGene = (From operon In DOOR.DOOROperonView.Operons Select operon.InitialX.Synonym).ToArray
        End If

        If Debug Then

            '包含有额外的位置标签信息

            For Each Loci In DipartsHistone

                Dim row1 = New List(Of String)

                If Not DOOR Is Nothing Then
                    Call row1.Add("")
                End If

                Call row1.AddRange((From p In If(Loci.strand = Strands.Forward, Loci.HisData.Reverse, Loci.HisData) Select CStr(p.Key)).ToArray)

                Dim row2 = New List(Of String)

                If Not DOOR Is Nothing Then
                    If Array.IndexOf(OperonPromoterGene, Loci.ID) > -1 Then
                        Call row2.Add("*")
                    Else
                        Call row2.Add("")
                    End If
                End If
                Call row2.Add(Loci.UserTag)

                Call row2.AddRange((From p In If(Loci.strand = Strands.Forward, Loci.HisData.Reverse, Loci.HisData) Select CStr(p.Value)).ToArray)

                Call Df.Add(row1)
                Call Df.Add(row2)
                Call Df.AppendLine()

            Next

        Else

            For Each Loci In DipartsHistone

                Dim row2 = New List(Of String)

                If Not DOOR Is Nothing Then
                    If Array.IndexOf(OperonPromoterGene, Loci.ID) > -1 Then
                        Call row2.Add("*")
                    Else
                        Call row2.Add("")
                    End If
                End If
                Call row2.Add(Loci.UserTag)

                Call row2.AddRange((From p In If(Loci.strand = Strands.Forward, Loci.HisData.Reverse, Loci.HisData) Select CStr(p.Value)).ToArray)

                Call Df.Add(row2)

            Next


        End If

        Return Df
    End Function

    Private Function Reads(LociSequence As Integer(), HistoneGram As Dictionary(Of Integer, Value(Of Integer))) As Dictionary(Of Integer, Integer)
        Dim LQuery = From i As Integer
                     In LociSequence
                     Select i,
                         hisData = HistoneGram(i)
        Return LQuery.ToDictionary(Function(x) x.i, Function(x) x.hisData.Value)
    End Function

    Private Function GetLocation(GeneObject As TabularFormat.ComponentModels.GeneBrief) As NucleotideLocation
        Return New NucleotideLocation(
            GeneObject.Location.GetUpStreamLoci(CUInt(150)),
            GeneObject.Location.Start,
            GeneObject.Location.Strand = Strands.Reverse) With {.UserTag = $"{GeneObject.Synonym} {GeneObject.Location.ToString}"}
    End Function

End Module