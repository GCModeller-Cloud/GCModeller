﻿Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.ChartPlots.Statistics
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Math.LinearAlgebra
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
End Module