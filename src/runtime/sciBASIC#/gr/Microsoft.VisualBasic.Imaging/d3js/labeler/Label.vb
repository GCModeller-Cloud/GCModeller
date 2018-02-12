﻿#Region "Microsoft.VisualBasic::deb04a6d02971b2c8d2193ec45779223, gr\Microsoft.VisualBasic.Imaging\d3js\labeler\Label.vb"

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

    '     Class Label
    ' 
    '         Properties: height, text, width, X, Y
    ' 
    '         Function: ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Runtime.CompilerServices

Namespace d3js.Layout

    Public Class Label

        ''' <summary>
        ''' the x-coordinate of the label.
        ''' </summary>
        ''' <returns></returns>
        Public Property X As Double
        ''' <summary>
        ''' the y-coordinate of the label.
        ''' </summary>
        ''' <returns></returns>
        Public Property Y As Double
        ''' <summary>
        ''' the width of the label (approximating the label as a rectangle).
        ''' </summary>
        ''' <returns></returns>
        Public Property width As Double
        ''' <summary>
        ''' the height of the label (same approximation).
        ''' </summary>
        ''' <returns></returns>
        Public Property height As Double
        ''' <summary>
        ''' the label text.
        ''' </summary>
        ''' <returns></returns>
        Public Property text As String

        Public Overrides Function ToString() As String
            Return $"{text}@({X.ToString("F2")},{Y.ToString("F2")})"
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Narrowing Operator CType(label As Label) As PointF
            Return New PointF With {
                .X = label.X,
                .Y = label.Y
            }
        End Operator
    End Class
End Namespace
