﻿Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.ChartPlots.BarPlot
Imports Microsoft.VisualBasic.Data.ChartPlots.Statistics
Imports Microsoft.VisualBasic.Data.ChartPlots.Statistics.Heatmap
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports RDotNET.Extensions.VisualBasic.API
Imports SMRUCC.genomics.GCModeller.Workbench.ExperimentDesigner

Partial Module CLI

    <ExportAPI("/significant.difference")>
    <Usage("/significant.difference /in <data.csv> /groups <sampleInfo.csv> [/out <out.csv.DIR>]")>
    <Argument("/in", False, CLITypes.File, PipelineTypes.std_in,
              AcceptTypes:={GetType(DataSet)},
              Extensions:="*.csv",
              Description:="A matrix file that contains the sample data.")>
    <Argument("/groups", False, CLITypes.File,
              AcceptTypes:={GetType(SampleInfo)},
              Extensions:="*.csv",
              Description:="Grouping info of the samples.")>
    Public Function SignificantDifference(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim group$ = args <= "/groups"
        Dim out$ = (args <= "/out") Or $"{in$.TrimSuffix}_{group.BaseName}.significant.difference/".AsDefault
        Dim data As DataSet() = DataSet.LoadDataSet([in]).ToArray
        Dim sampleGroups As NamedCollection(Of SampleInfo)() = group _
            .LoadCsv(Of SampleInfo) _
            .EnsureGroupPaired(allSamples:=data.PropertyNames)

        For Each ga As NamedCollection(Of SampleInfo) In sampleGroups
            Dim labels1$() = ga.Value.Keys

            For Each gb In sampleGroups.Where(Function(g) g.Name <> ga.Name)
                Dim labels2$() = gb.Value.Keys
                Dim result As New List(Of DataSet)
                Dim path$ = $"{out}/{ga.Name.NormalizePathString}-{gb.Name.NormalizePathString}.csv"

                For Each x As DataSet In data
                    Dim va#() = x(labels1)
                    Dim vb#() = x(labels2)
                    Dim pvalue# = Double.NaN

                    Try
                        pvalue = stats.Ttest(va, vb).pvalue
                    Catch ex As Exception
                        Call App.LogException(ex)
                    End Try

                    With New DataSet With {.ID = x.ID}
                        !pvalue = pvalue
                        result += .ref
                    End With
                Next

                Call result.SaveTo(path)
            Next
        Next

        Return 0
    End Function

    <ExportAPI("/box.plot")>
    <Usage("/box.plot /in <data.csv> /groups <sampleInfo.csv> [/out <out.DIR>]")>
    Public Function Boxplot(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim group$ = args <= "/groups"
        Dim out$ = (args <= "/out") Or $"{in$.TrimSuffix}_{group.BaseName}.boxplot/".AsDefault
        Dim data As DataSet() = DataSet.LoadDataSet([in]).ToArray
        Dim sampleGroups = group _
            .LoadCsv(Of SampleInfo) _
            .EnsureGroupPaired(allSamples:=data.PropertyNames) _
            .ToDictionary(Function(g) g.Name,
                          Function(samples)
                              Return samples _
                                  .Value _
                                  .Keys _
                                  .ToArray
                          End Function)

        For Each pathway As DataSet In data
            Dim name$ = pathway.ID
            Dim save$ = $"{out}/{name.NormalizePathString}.png"
            Dim groups = sampleGroups _
                .Select(Function(x)
                            Return New NamedValue(Of Vector) With {
                                .Name = x.Key,
                                .Value = pathway(x.Value).AsVector
                            }
                        End Function) _
                .ToArray
            Dim boxData As New BoxData With {
                .SerialName = name,
                .Groups = groups
            }

            Call boxData.Plot.Save(save)
        Next

        Return 0
    End Function

    <ExportAPI("/heatmap.plot")>
    <Usage("/heatmap.plot /in <data.csv> /groups <sampleInfo.csv> [/tsv /group /title <title> /size <2700,3000> /out <out.DIR>]")>
    Public Function HeatmapPlot(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim group$ = args <= "/groups"
        Dim groupData = args.IsTrue("/group")
        Dim out$ = (args <= "/out") Or $"{in$.TrimSuffix}_{group.BaseName}.heatmap.plot.png".AsDefault
        Dim title$ = (args <= "/title") Or $"Heatmap Plot Of {[in].BaseName}".AsDefault
        Dim size$ = (args <= "/size") Or "2700,3000".AsDefault
        Dim data As DataSet() = DataSet.LoadDataSet([in], tsv:=args.IsTrue("/tsv")).ToArray
        Dim sampleInfo = group.LoadCsv(Of SampleInfo).ToArray
        Dim sampleGroups =
            sampleInfo _
            .EnsureGroupPaired(allSamples:=data.PropertyNames) _
            .ToDictionary(Function(g) g.Name,
                          Function(samples)
                              Return samples _
                                  .Value _
                                  .Keys _
                                  .ToArray
                          End Function)
        Dim colors$() = Designer.GetColors("console.colors") _
            .Select(Function(c) c.ToHtmlColor) _
            .ToArray
        Dim groupColors As New Dictionary(Of String, String)
        Dim matrix As DataSet()

        If Not groupData Then
            For Each groupLabels In sampleGroups.SeqIterator
                For Each label As String In (+groupLabels).Value
                    groupColors.Add(label, colors(groupLabels))
                Next
            Next

            matrix = data _
                .Project(groupColors.Keys.ToArray) _
                .ToArray
        Else

            ' 合并分组之后，绘制分组的颜色没有多大意义了，在这里删除掉
            groupColors = Nothing
            matrix = data _
                .Group(sampleGroups) _
                .ToArray
        End If

        Return Heatmap.Plot(matrix,
                            size:=size,
                            drawScaleMethod:=DrawElements.Rows,
                            min:=0,
                            colLabelFontStyle:=CSSFont.Win7LittleLarge,
                            mapName:=ColorBrewer.SequentialSchemes.YlGnBu9,
                            drawClass:=(Nothing, groupColors),
                            mainTitle:=title) _
            .Save(out) _
            .CLICode
    End Function

    <ExportAPI("/Relative_abundance.barplot")>
    <Usage("/Relative_abundance.barplot /in <dataset.csv> [/group <sample_group.csv> /desc /asc /take <-1> /size <3000,2700> /column.n <default=9> /interval <10px> /out <out.png>]")>
    <Argument("/desc", True, CLITypes.Boolean, Description:="")>
    <Argument("/asc", True, CLITypes.Boolean, Description:="")>
    <Argument("/take", True, CLITypes.Integer,
              AcceptTypes:={GetType(Integer)},
              Description:="")>
    Public Function Relative_abundance_barplot(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = (args <= "/out") Or $"{[in].TrimSuffix}.barplot.png".AsDefault
        Dim isDesc As Boolean = args.IsTrue("/desc")
        Dim isAsc As Boolean = args.IsTrue("/asc")
        Dim sampleGroup = (args <= "/group").LoadCsv(Of SampleGroup)

        ' 如果/desc和/asc这两个开关都开启了的话，则会优先选择/desc，因为倒序的图样式会更好看一些
        If isDesc AndAlso isAsc Then
            Call "``/desc`` and ``/asc`` option are both open, ``/asc`` option will be disabled!".Warning
        End If

        Dim groups = sampleGroup _
            .GroupBy(Function(sample) sample.sample_group) _
            .ToDictionary(Function(g) g.Key,
                          Function(list)
                              Return list _
                                  .Select(Function(sample) sample.sample_name) _
                                  .ToArray
                          End Function)
        Dim data = BarPlotDataExtensions _
            .LoadDataSet([in]) _
            .Normalize

        If groups.Count > 0 Then
            data = data _
                .GroupBy(groups) _
                .Normalize
        End If

        Dim take% = args.GetValue("/take", -1%)

        If take > 0 Then
            data = data.Takes(take)
        End If

        If isDesc Then
            data = data.Desc
        ElseIf isAsc Then
            data = data.Asc
        Else
            ' Do Nothing
        End If

        Dim size$ = (args <= "/size") Or "3000,2700".AsDefault
        Dim internal% = args.GetValue("/interval", 10)
        Dim columnCount% = args.GetValue("/column.n", 9)

        Return StackedBarPlot.Plot(
            data, size:=size, interval:=internal, YaxisTitle:="Relative abundance", columnCount:=columnCount, legendLabelFontCSS:=CSSFont.Win7LargerNormal) _
            .Save(out) _
            .CLICode
    End Function
End Module