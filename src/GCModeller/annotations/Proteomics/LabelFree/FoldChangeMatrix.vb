﻿#Region "Microsoft.VisualBasic::26023211b47ae60f945bf57a39419157, annotations\Proteomics\LabelFree\FoldChangeMatrix.vb"

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

    ' Module FoldChangeMatrix
    ' 
    '     Function: (+2 Overloads) iTraqMatrix, iTraqMatrixNormalized, (+2 Overloads) TotalSumNormalize
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports SMRUCC.genomics.GCModeller.Workbench.ExperimentDesigner

''' <summary>
''' 直接进行FoldChange比较的误差会非常大,在这里可以将原始数据进行处理,使用iTraq方法进行数据分析
''' </summary>
Public Module FoldChangeMatrix

    ''' <summary>
    ''' 总峰归一化
    ''' </summary>
    ''' <param name="sample#"></param>
    ''' <returns></returns>
    ''' 
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    <Extension>
    Public Function TotalSumNormalize(sample As Vector) As Double()
        Return sample / sample.Sum
    End Function

    ''' <summary>
    ''' 对原始峰面积矩阵进行总峰归一化
    ''' </summary>
    ''' <param name="rawMatrix"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function TotalSumNormalize(rawMatrix As IEnumerable(Of DataSet)) As IEnumerable(Of DataSet)
        Dim data As DataSet() = rawMatrix.ToArray
        Dim samples = data.PropertyNames
        Dim normalized = samples _
            .ToDictionary(Function(name) name,
                          Function(name)
                              Return TotalSumNormalize(data.Vector(name))
                          End Function)
        Dim index%

        For i As Integer = 0 To data.Length - 1
            index = i

            Yield New DataSet With {
                .ID = data(i).ID,
                .Properties = normalized _
                    .ToDictionary(Function(sample) sample.Key,
                                  Function(sample) sample.Value(index))
            }
        Next
    End Function

    ''' <summary>
    ''' 生成的matrix里面的foldchange结果是``experiment/controls``
    ''' </summary>
    ''' <param name="rawMatrix">原始的峰面积数据</param>
    ''' <param name="analysis"></param>
    ''' <returns></returns>
    ''' 
    <Extension>
    Public Iterator Function iTraqMatrix(rawMatrix As DataSet(),
                                         analysis As (experiments As String(), controls As String()),
                                         Optional normalize As Dictionary(Of String, Double) = Nothing) As IEnumerable(Of DataSet)
        Dim a#, b#
        Dim requireNormalized As Boolean = Not normalize Is Nothing

        For Each protein As DataSet In rawMatrix
            Dim foldChanges As New Dictionary(Of String, Double)

            For Each experiment As String In analysis.experiments
                For Each control As String In analysis.controls
                    If (protein(control)) = 0R Then
                        foldChanges($"{experiment}/{control}") = 0
                    Else
                        If requireNormalized Then
                            a = protein(experiment) / normalize(experiment)
                            b = protein(control) / normalize(control)
                        Else
                            a = protein(experiment)
                            b = protein(control)
                        End If

                        foldChanges($"{experiment}/{control}") = a / b
                    End If
                Next
            Next

            Yield New DataSet With {
                .ID = protein.ID,
                .Properties = foldChanges
            }
        Next
    End Function

    <Extension>
    Public Function iTraqMatrixNormalized(rawMatrix As DataSet(), analysis As (experiments As String(), controls As String())) As IEnumerable(Of DataSet)
        Dim totalSum = (analysis.experiments.AsList + analysis.controls) _
            .ToDictionary(Function(name) name,
                          Function(name)
                              Return rawMatrix.Sum(Function(protein) protein(name))
                          End Function)
        Return rawMatrix.iTraqMatrix(analysis, totalSum)
    End Function

    Public Iterator Function iTraqMatrix(rawMatrix As IEnumerable(Of DataSet),
                                         sampleInfo As SampleGroup(),
                                         analysisDesigners As AnalysisDesigner(),
                                         Optional normalize As Boolean = False) As IEnumerable(Of NamedCollection(Of DataSet))
        Dim groups = sampleInfo _
            .GroupBy(Function(s) s.sample_group) _
            .ToDictionary(Function(g) g.Key,
                          Function(g) g.Select(Function(s) s.sample_name).ToArray)

        With rawMatrix.ToArray
            For Each designer As AnalysisDesigner In analysisDesigners
                Dim controls$() = groups(designer.Controls)
                Dim treatment$() = groups(designer.Treatment)
                Dim matrix As DataSet()

                If normalize Then
                    matrix = .iTraqMatrixNormalized((treatment, controls)) _
                             .ToArray
                Else
                    matrix = .iTraqMatrix((treatment, controls)) _
                             .ToArray
                End If

                Yield New NamedCollection(Of DataSet) With {
                    .Name = designer.Title,
                    .Value = matrix,
                    .Description = designer.ToString
                }
            Next
        End With
    End Function
End Module
