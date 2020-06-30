﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.ChartPlots
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.DataMining.KMeans
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Scripting.Runtime
Imports SMRUCC.genomics.Analysis.HTS.DataFrame

''' <summary>
''' 表达模式聚类
''' </summary>
Public Module ExpressionPatterns

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="matrix"></param>
    ''' <param name="dim">``[row, columns]``</param>
    ''' <returns></returns>
    ''' 
    <Extension>
    Public Function KMeansCluster(matrix As Matrix, [dim] As Integer()) As Matrix()()
        Dim nsize As Integer = [dim](Scan0) * [dim](1)
        Dim sampleNames = matrix.sampleID
        Dim clusters = matrix.expression _
            .AsParallel _
            .Select(Function(gene)
                        Dim vector As New Dictionary(Of String, Double)

                        For i As Integer = 0 To sampleNames.Length - 1
                            Call vector.Add(sampleNames(i), gene.experiments(i))
                        Next

                        Return New DataSet With {.ID = gene.geneID, .Properties = vector}
                    End Function) _
            .ToKMeansModels _
            .Kmeans(expected:=nsize)

        Return clusters.populatePartitions([dim], sampleNames).ToArray
    End Function

    <Extension>
    Private Iterator Function populatePartitions(clusters As IEnumerable(Of EntityClusterModel), dim%(), sampleNames As String()) As IEnumerable(Of Matrix())
        Dim row As New List(Of Matrix)

        For Each cluster In clusters.GroupBy(Function(c) c.Cluster)
            Dim matrix = New Matrix With {
                .sampleID = sampleNames,
                .expression = cluster _
                    .Select(Function(a)
                                Return New DataFrameRow With {
                                    .geneID = a.ID,
                                    .experiments = sampleNames _
                                        .Select(Function(name) a(name)) _
                                        .ToArray
                                }
                            End Function) _
                    .ToArray
            }

            row += matrix

            If row = [dim](1) Then
                Yield row.PopAll
            End If
        Next

        If row > 0 Then
            Yield row.PopAll
        End If
    End Function

    Public Function DrawMatrix(raw As Matrix,
                               Optional dim$ = "3,3",
                               Optional size$ = "2400,2100",
                               Optional padding$ = g.DefaultPadding,
                               Optional bg$ = "white") As GraphicsData

        Dim matrix As Matrix()() = raw.KMeansCluster(dim$.SizeParser.ToArray)

        Return g.GraphicsPlots(
            size:=size.SizeParser,
            padding:=padding,
            bg:=bg,
            plotAPI:=Sub(ByRef g As IGraphics, canvas As GraphicsRegion)

                         Dim x!
                         Dim y! = canvas.PlotRegion.Top
                         Dim w = canvas.PlotRegion.Width / matrix(Scan0).Length
                         Dim h = canvas.PlotRegion.Height / matrix.Length
                         Dim scatterData As SerialData

                         For Each row In matrix

                             x = canvas.PlotRegion.Left

                             For Each col In row

                                 padding = $"padding: {y}px {canvas.Width - x + w}px {canvas.Height - y + h}px {x}"
                                 x += w

                                 Call Scatter.Plot({scatterData}, size, padding, bg)

                             Next

                             y += h
                         Next

                     End Sub)
    End Function
End Module
