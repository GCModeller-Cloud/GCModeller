﻿Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Data.csv

''' <summary>
''' ```
''' <see cref="Controls"/> / <see cref="Treatment"/>
''' ```
''' 这个对象描述了如何设计一个比对计算实验分析
''' </summary>
<Template(ExperimentDesigner)>
Public Class AnalysisDesigner

    <XmlAttribute("control")>
    Public Property Controls As String
    <XmlAttribute("treatment")>
    Public Property Treatment As String
    <XmlText>
    Public Property Note As String

    ''' <summary>
    ''' 对于iTraq实验数据而言，这里是具体的样品的编号的比对
    ''' 对于LabelFree实验数据而言，由于需要手工计算FC值，所以在这里比对的是样品的组别名称
    ''' </summary>
    ''' <returns></returns>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Overrides Function ToString() As String
        Return $"{Controls}/{Treatment}"
    End Function

    Public Function Swap() As AnalysisDesigner
        Return New AnalysisDesigner With {
            .Controls = Treatment,
            .Treatment = Controls
        }
    End Function
End Class