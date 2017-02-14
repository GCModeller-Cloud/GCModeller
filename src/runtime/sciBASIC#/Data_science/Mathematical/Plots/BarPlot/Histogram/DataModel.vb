﻿Imports System.Drawing
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.Ranges
Imports Microsoft.VisualBasic.ComponentModel.TagData
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Mathematical
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace BarPlot.Histogram

    ''' <summary>
    ''' {x, y}
    ''' </summary>
    ''' <remarks>
    ''' <see cref="x1"/>到<see cref="x2"/>之间的距离是直方图的宽度
    ''' </remarks>
    Public Structure HistogramData

        Public x1#, x2#, y#

        ''' <summary>
        ''' delta between <see cref="x1"/> and <see cref="x2"/>
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property width As Double
            Get
                Return x2# - x1#
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Structure

    Public Class HistogramGroup : Inherits ProfileGroup

        Public Property Samples As HistProfile()

        Sub New()
        End Sub

        Sub New(data As IEnumerable(Of HistProfile))
            Samples = data
            Serials = data _
                .ToArray(Function(x) New NamedValue(Of Color) With {
                    .Name = x.legend.title,
                    .Value = x.legend.color.ToColor
                })
        End Sub
    End Class

    ''' <summary>
    ''' The histogram serial data.
    ''' </summary>
    Public Structure HistProfile

        ''' <summary>
        ''' The legend plot definition
        ''' </summary>
        Public legend As Legend
        Public data As HistogramData()

        ''' <summary>
        ''' 仅仅在这里初始化了<see cref="data"/>
        ''' </summary>
        ''' <param name="range"></param>
        ''' <param name="func"></param>
        ''' <param name="steps#"></param>
        Sub New(range As DoubleRange, func As Func(Of Double, Double), Optional steps# = 0.01)
            Me.New(range.seq(steps).Select(func), range)
        End Sub

        ''' <summary>
        ''' 仅仅在这里初始化了<see cref="data"/>
        ''' </summary>
        ''' <param name="data"></param>
        ''' <param name="xrange"></param>
        Sub New(data As IEnumerable(Of Double), xrange As DoubleRange)
            Dim array#() = data.ToArray
            Dim delta# = xrange.Length / array.Length
            Dim x As New Value(Of Double)(xrange.Min)

            Me.data = LinqAPI.Exec(Of HistogramData) <=
 _
                From n As Double
                In array
                Let x1 As Double = x
                Let x2 As Double = (x = x.value + delta)
                Where Not n.IsNaNImaginary
                Select New HistogramData With {
                    .x1 = x1,
                    .x2 = x2,
                    .y = n
                }
        End Sub

        ''' <summary>
        ''' Tag值为直方图的高，value值为直方图的平均值连线
        ''' </summary>
        ''' <param name="hist"></param>
        Sub New(hist As Dictionary(Of Double, IntegerTagged(Of Double)), step!)
            data = hist.ToArray(
                Function(range) New HistogramData With {
                    .x1 = range.Key,
                    .x2 = .x1 + step!,
                    .y = range.Value.Tag
                })
        End Sub
    End Structure
End Namespace