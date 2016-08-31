﻿#Region "Microsoft.VisualBasic::acce0c56d8ecb55403c7754f39903a79, ..\visualbasic_App\Datavisualization\Microsoft.VisualBasic.Imaging\Drawing2D\VectorElements\Box.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2016 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Language

Namespace Drawing2D.VectorElements

    Public Class Box : Inherits LayoutsElement

        Sub New(Location As Point, Size As Size, GDI As GDIPlusDeviceHandle, Color As Color)
            Call MyBase.New(GDI, Location)
        End Sub

        Protected Overloads Overrides Sub InvokeDrawing()

        End Sub

        Public Overrides ReadOnly Property Size As Size
            Get

            End Get
        End Property
    End Class

    ''' <summary>
    ''' 按照任意角度旋转的箭头对象
    ''' </summary>
    Public Class Arrow : Inherits LayoutsElement

        ''' <summary>
        ''' 箭头的头部占据整个长度的百分比
        ''' </summary>
        ''' <returns></returns>
        Public Property HeadLengthPercentage As Double = 0.15
        ''' <summary>
        ''' 箭头的主体部分占据整个高度的百分比
        ''' </summary>
        ''' <returns></returns>
        Public Property BodyHeightPercentage As Double = 0.85

        Public Property Color As Color
        Public Property BodySize As Size
        Public Property DirectionLeft As Boolean

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Location">箭头头部的位置</param>
        ''' <param name="Size">高度和宽度</param>
        ''' <param name="GDI"></param>
        ''' <param name="Color">填充的颜色</param>
        Sub New(Location As Point, Size As Size, GDI As GDIPlusDeviceHandle, Color As Color)
            Call MyBase.New(GDI, Location)
            Me.Color = Color
            Me.BodySize = Size
        End Sub

        Sub New(source As Arrow, GDI As GDIPlusDeviceHandle)
            Call MyBase.New(GDI, source.Location)
            Call Microsoft.VisualBasic.Serialization.ShadowCopy(source, Me)
        End Sub

        ''' <summary>
        ''' 返回图形上面的绘图的大小，而非箭头本身的大小
        ''' </summary>
        ''' <returns></returns>
        Public Overrides ReadOnly Property Size As Size
            Get
                Return BodySize
            End Get
        End Property

        Protected ReadOnly Property HeadLength As Integer
            Get
                Return HeadLengthPercentage * BodySize.Width
            End Get
        End Property

        Protected ReadOnly Property HeadSemiHeight As Integer
            Get
                Return (BodySize.Height * (1 - BodyHeightPercentage)) / 2
            End Get
        End Property

        ''' <summary>
        ''' 忽略了箭头的方向，本箭头对象存粹的在进行图形绘制的时候的左右的位置
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Left As Integer
            Get
                Return {Location.X, Location.X + If(Not DirectionLeft, 1, -1) * BodySize.Width}.Min
            End Get
        End Property
        ''' <summary>
        ''' 忽略了箭头的方向，本箭头对象存粹的在进行图形绘制的时候的左右的位置
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Right As Integer
            Get
                Return {Location.X, Location.X + If(Not DirectionLeft, 1, -1) * BodySize.Width}.Max
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{Left} ==> {Right}; // length={BodySize.ToString}"
        End Function

        ''' <summary>
        '''  /|_____
        ''' /       |
        ''' \       |
        '''  \|-----
        ''' </summary>
        Protected Overrides Sub InvokeDrawing()
            Dim Path As System.Drawing.Drawing2D.GraphicsPath = New GraphicsPath

            Dim Direction As Integer = If(DirectionLeft, 1, -1)
            Dim Top As Integer = Me.Location.Y - BodySize.Height / 2
            Dim Left = Me.Location.X
            Dim Right = Left + Direction * BodySize.Width
            Dim Bottom = Top + BodySize.Height
            Dim prePoint As New Value(Of Point)


            Call Path.AddLine(Me.Location, prePoint = New Point(Left + Direction * HeadLength, Top))                        '/
            Call Path.AddLine(prePoint.value, prePoint = New Point(Left + Direction * HeadLength, Top + HeadSemiHeight))    ' |
            Call Path.AddLine(prePoint.value, prePoint = New Point(Right, Top + HeadSemiHeight))                            '  ----
            Call Path.AddLine(prePoint.value, prePoint = New Point(Right, Bottom - HeadSemiHeight))                         '      |
            Call Path.AddLine(prePoint.value, prePoint = New Point(Left + Direction * HeadLength, Bottom - HeadSemiHeight)) '  ----
            Call Path.AddLine(prePoint.value, prePoint = New Point(Left + Direction * HeadLength, Bottom))                  ' |
            Call Path.AddLine(prePoint.value, Me.Location)                                                                  '\
            Call Path.CloseFigure()

            Call Me._GDIDevice.Graphics.FillPath(New SolidBrush(Me.Color), Path)
        End Sub
    End Class
End Namespace
