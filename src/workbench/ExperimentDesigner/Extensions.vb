﻿Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Linq

Public Module Extensions

    <Extension>
    Public Function ToCategory(sampleInfo As IEnumerable(Of SampleInfo)) As Dictionary(Of NamedCollection(Of String))
        Return sampleInfo _
            .GroupBy(Function(sample) sample.sample_group) _
            .Select(Function(group)
                        Return New NamedCollection(Of String) With {
                            .Name = group.Key,
                            .Value = group.SampleNames
                        }
                    End Function) _
            .ToDictionary
    End Function

    <Extension>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function SampleNames(sampleInfo As IEnumerable(Of SampleInfo)) As String()
        Return sampleInfo.Select(Function(sample) sample.sample_name).ToArray
    End Function

    ''' <summary>
    ''' ``<see cref="SampleInfo.ID"/> -> <see cref="SampleInfo.sample_group"/>``
    ''' </summary>
    ''' <param name="sampleInfo"></param>
    ''' <returns></returns>
    <Extension>
    Public Function SampleGroupInfo(sampleInfo As IEnumerable(Of SampleInfo)) As Dictionary(Of String, String)
        Return sampleInfo.ToDictionary(
            Function(sample) sample.ID,
            Function(sample) sample.sample_group)
    End Function

    <Extension>
    Public Function SampleGroupColor(sampleInfo As IEnumerable(Of SampleInfo)) As Dictionary(Of String, Color)

    End Function

    ''' <summary>
    ''' 将组别比对标记转换为样品比对标记
    ''' </summary>
    ''' <param name="sampleInfo"></param>
    ''' <param name="analysis">
    ''' <see cref="AnalysisDesigner.Controls"/>和<see cref="AnalysisDesigner.Experimental"/>都是组别名称
    ''' </param>
    ''' <returns>
    ''' 经过这个函数转换之后，<see cref="AnalysisDesigner.Controls"/>和<see cref="AnalysisDesigner.Experimental"/>
    ''' 都分别被转换为样品标记了
    ''' </returns>
    ''' <remarks>
    ''' 例如，存在下面的样品信息
    ''' 
    ''' + PCCa组	
    '''   + M-P-CCa1
    '''	  + M-P-CCa2
    '''	  + M-P-CCa3
    ''' 
    ''' + PCCaT组	
    '''   + M-P-CCaT1
    '''	  + M-P-CCaT2
    '''	  + M-P-CCaT3
    '''	
    ''' 而实验数据分析设计则是：``PCCa组 vs PCCaT组``
    ''' 
    ''' 故而需要使用这个函数将组别标记转换为实际计算分析所要使用到的样品标记
    ''' </remarks>
    <Extension>
    Public Function DataAnalysisDesign(sampleInfo As IEnumerable(Of SampleInfo), analysis As IEnumerable(Of AnalysisDesigner)) As Dictionary(Of String, AnalysisDesigner())
        Dim sampleGroups = sampleInfo _
            .GroupBy(Function(label) label.sample_group) _
            .ToDictionary(Function(x) x.Key,
                          Function(g) g.ToArray)
        Dim designs = analysis.ToDictionary(
            Function(name) name.ToString,
            Function(designer)
                Dim control = sampleGroups(designer.Controls)
                Dim experimentals = sampleGroups(designer.Experimental)

                ' 对照 vs 处理 
                Return control _
                    .Select(Function(c)
                                Return experimentals _
                                    .Select(Function(e)
                                                Return New AnalysisDesigner With {
                                                    .Controls = c.sample_name,
                                                    .Experimental = e.sample_name
                                                }
                                            End Function)
                            End Function) _
                    .IteratesALL _
                    .ToArray
            End Function)

        Return designs
    End Function
End Module