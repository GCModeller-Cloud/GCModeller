﻿#Region "Microsoft.VisualBasic::1ff6d585b5c471e35e106e7ac7908575, ..\sciBASIC#\Microsoft.VisualBasic.Core\ComponentModel\DataStructures\LoopArray.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
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

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace ComponentModel.DataStructures

    ''' <summary>
    ''' Infinite loop iterates of the target element collection.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public Class LoopArray(Of T) : Implements IEnumerable(Of T)

        Dim __innerArray As T()
        Dim __p As Integer

        Public ReadOnly Property Buffer As T()
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return __innerArray
            End Get
        End Property

        Public ReadOnly Property Length As Integer
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return __innerArray.Length
            End Get
        End Property

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Sub New(source As IEnumerable(Of T))
            __innerArray = source.ToArray
        End Sub

        ''' <summary>
        ''' Gets the next elements in the array, is move to end, then the index will moves to the array begining position.
        ''' </summary>
        ''' <returns></returns>
        Public Function [Next]() As T
            If __p < __innerArray.Length - 1 Then
                __p += 1
            Else
                __p = 0
            End If

            Return __innerArray(__p)
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub [Set](i%)
            __p = i%
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub Reset()
            __p = 0
        End Sub

        Public Overrides Function ToString() As String
            Return __innerArray.Take(10).ToArray.GetJson
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="delta%">The pointer move delta</param>
        ''' <returns></returns>
        Public Function [GET](delta%) As T
            __p += delta

            If __p >= 0 Then
                If __p <= __innerArray.Length - 1 Then
                    ' 正常的下标范围内，不需要进行任何处理
                Else
                    __p = __p - __innerArray.Length
                End If
            Else
                __p = __innerArray.Length + __p
            End If

            Return __innerArray(__p)
        End Function

        Public Shared Narrowing Operator CType(array As LoopArray(Of T)) As T()
            Return array.Buffer
        End Operator

        Public Shared Widening Operator CType(array As T()) As LoopArray(Of T)
            Return New LoopArray(Of T)(array)
        End Operator

        Dim _break As Boolean

        ''' <summary>
        ''' Exit the Infinite loop iterator <see cref="GetEnumerator()"/>
        ''' </summary>
        Public Sub Break()
            _break = True
        End Sub

        ''' <summary>
        ''' Infinite loop iterates of the target element collection.
        ''' </summary>
        ''' <returns></returns>
        Public Iterator Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            _break = False

            Do While Not _break
                Yield [Next]()
            Loop
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
    End Class
End Namespace
