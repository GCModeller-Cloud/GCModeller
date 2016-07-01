﻿#Region "679471ffaa65aadb598ed81ffb2d42f5, ..\Math\Arithmetic.Expression\MetaExpression.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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

Imports System.Xml.Serialization

Namespace Types

    ''' <summary>
    ''' 在<see cref="SimpleExpression.Calculator"></see>之中由于移位操作的需要，需要使用类对象可以修改属性的特性来进行正常的计算，所以请不要修改为Structure类型
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MetaExpression

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute> Public Property [Operator] As Char

        ''' <summary>
        ''' 自动根据类型来计算出结果
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute> Public Property LEFT As Double
            Get
                If __left Is Nothing Then
                    Return _left
                Else
                    Return __left()
                End If
            End Get
            Set(value As Double)
                _left = value
                __left = Nothing
            End Set
        End Property

        Public ReadOnly Property IsNumber As Boolean
            Get
                Return __left Is Nothing
            End Get
        End Property

        Public ReadOnly Property IsExpression As Boolean
            Get
                Return Not __left Is Nothing
            End Get
        End Property

        Dim _left As Double
        Dim __left As Func(Of Double)

        Sub New()
        End Sub

        Sub New(n As Double, o As Char)
            LEFT = n
            [Operator] = o
        End Sub

        Sub New(n As Double)
            LEFT = n
        End Sub

        Sub New(handle As Func(Of Double))
            __left = handle
        End Sub

        Sub New(simple As SimpleExpression)
            Call Me.New(AddressOf simple.Evaluate)
        End Sub

        Public Overrides Function ToString() As String
            If __left Is Nothing Then
                Return String.Format("{0} {1}", LEFT, [Operator])
            Else
                Return $"{__left.ToString} {[Operator]}"
            End If
        End Function
    End Class
End Namespace
