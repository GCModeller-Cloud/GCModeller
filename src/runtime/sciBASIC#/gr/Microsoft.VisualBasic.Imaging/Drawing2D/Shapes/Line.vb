﻿#Region "Microsoft.VisualBasic::5af9f6299c35cd27556143bcdeb2f30d, gr\Microsoft.VisualBasic.Imaging\Drawing2D\Shapes\Line.vb"

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

    '     Class Line
    ' 
    '         Properties: A, Alpha, B, Center, Length
    '                     Size, Stroke
    ' 
    '         Constructor: (+4 Overloads) Sub New
    '         Function: Draw, GetIntersectLocation, ParallelShift, QuadraticBelzier, ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Math2D
Imports Microsoft.VisualBasic.Imaging.LayoutModel
Imports Microsoft.VisualBasic.Imaging.Math2D
Imports Microsoft.VisualBasic.Math

Namespace Drawing2D.Shapes

    Public Class Line : Inherits Shape

        Public Property Stroke As Pen

        Public ReadOnly Property A As PointF
        Public ReadOnly Property B As PointF

        Public Overrides ReadOnly Property Size As Size
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return New Size With {
                    .Width = A.X - B.X,
                    .Height = A.Y - B.Y
                }
            End Get
        End Property

        ''' <summary>
        ''' 线段的长度
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Length As Double
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return Math.Sqrt((A.X - B.X) ^ 2 + (A.Y - B.Y) ^ 2)
            End Get
        End Property

        ''' <summary>
        ''' 返回线段和X轴的夹角，夹角值为弧度值
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Alpha As Double
            Get
                Dim dx! = B.X - Me.A.X
                Dim dy! = B.Y - Me.A.Y
                Dim cos = dx / Math.Sqrt(dx ^ 2 + dy ^ 2)
                Dim a = Arccos(cos)

                If dy < 0 Then
                    ' y 小于零的时候是第三和第4象限的
                    ' cos(170) = cos(190)
                    ' 则假设通过判断这个y坐标值知道点是在第三和第四象限
                    ' 那么 190 = 180 + (180-170)
                    '      350 = 180 + (180-10)
                    a = PI + (PI - a)
                End If

                Return a
            End Get
        End Property

        Public ReadOnly Property Center As PointF
            Get
                Dim x! = (A.X + B.X) / 2
                Dim y! = (A.Y + B.Y) / 2
                Return New PointF(x, y)
            End Get
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="a">在进行位移的时候，这两个点之间的相对位置不会发生改变</param>
        ''' <param name="b"></param>
        ''' <param name="c"></param>
        ''' <param name="width"></param>
        ''' <remarks></remarks>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Sub New(a As PointF, b As PointF, c As Color, width%)
            Call Me.New(a, b, pen:=New Pen(New SolidBrush(c), width))
        End Sub

        Sub New(a As PointF, b As PointF, pen As Pen)
            Call MyBase.New(a.ToPoint)

            Me.A = a
            Me.B = b
            Me.Stroke = pen
        End Sub

        Sub New(x1#, y1#, x2#, y2#)
            Call Me.New(New PointF(x1, y1), New PointF(x2, y2))
        End Sub

        Sub New(a As PointF, b As PointF)
            Call Me.New(a, b, Color.Black, 1)
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function GetIntersectLocation(rect As Rectangle2D) As Point2D
            Return rect.intersectLine(A.X, A.Y, B.X, B.Y)
        End Function

        Public Overrides Function ToString() As String
            Return $"[{A.X}, {A.Y}] --> [{B.X}, {B.Y}] alpha:{Alpha.ToDegrees} degree"
        End Function

        Public Overrides Function Draw(ByRef g As IGraphics, Optional overridesLoci As Point = Nothing) As RectangleF
            Dim rect As RectangleF = MyBase.Draw(g, overridesLoci)
            Call g.DrawLine(Stroke, A, B)
            Return rect
        End Function

        ''' <summary>
        ''' 对这条线段进行平行位移
        ''' </summary>
        ''' <param name="d#">位移的距离</param>
        ''' <returns></returns>
        Public Function ParallelShift(d#) As Line
            With Stroke
                Dim color As Color = DirectCast(.Brush, SolidBrush).Color
                Dim dx = d * Sin(Alpha)
                Dim dy = d * Cos(Alpha)
                Dim offset As New Point(dx, -dy)

                Return New Line(
                    A.OffSet2D(offset),
                    B.OffSet2D(offset),
                    color, .Width
                )
            End With
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function QuadraticBelzier(c1 As PointF, c2 As PointF, endPoint As PointF, Optional vertices% = 100) As IEnumerable(Of PointF)
            Return {c1, c2, endPoint}.BezierCurve(vertices)
        End Function
    End Class
End Namespace
