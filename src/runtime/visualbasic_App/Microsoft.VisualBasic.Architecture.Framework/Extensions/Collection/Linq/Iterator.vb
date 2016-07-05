﻿#Region "11411d2fbec95cd256120ed384120c1a, ..\Microsoft.VisualBasic.Architecture.Framework\Extensions\Collection\Linq\Iterator.vb"

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

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Linq

    Public Module IteratorExtensions

        ''' <summary>
        ''' Iterates all of the objects in the source sequence with collection index position.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="source">the source sequence</param>
        ''' <param name="offset"></param>
        ''' <returns></returns>
        <Extension>
        Public Iterator Function SeqIterator(Of T)(source As IEnumerable(Of T), Optional offset As Integer = 0) As IEnumerable(Of SeqValue(Of T))
            If Not source.IsNullOrEmpty Then
                Dim idx As Integer = offset

                For Each x As T In source
                    Yield New SeqValue(Of T)(idx, x)
                    idx += 1
                Next
            End If
        End Function

        <Extension>
        Public Iterator Function SeqIterator(Of T1, T2)(seqFrom As IEnumerable(Of T1),
                                                        follows As IEnumerable(Of T2),
                                                        Optional offset As Integer = 0) As IEnumerable(Of SeqValue(Of T1, T2))
            Dim x As T1() = seqFrom.ToArray
            Dim y As T2() = follows.ToArray

            For i As Integer = 0 To x.Length - 1
                Yield New SeqValue(Of T1, T2)(i + offset, x(i), y.Get(i))
            Next
        End Function
    End Module

    Public Structure SeqValue(Of T1, T2) : Implements IAddressHandle

        Public Property Pos As Integer
        Public Property obj As T1
        Public Property Follow As T2

        Private Property Address As Integer Implements IAddressHandle.Address
            Get
                Return CLng(Pos)
            End Get
            Set(value As Integer)
                Pos = CInt(value)
            End Set
        End Property

        Sub New(i As Integer, x As T1, y As T2)
            Pos = i
            obj = x
            Follow = y
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub
    End Structure

    Public Structure SeqValue(Of T) : Implements IAddressHandle

        ''' <summary>
        ''' The position of this object value in the original sequence.
        ''' </summary>
        ''' <returns></returns>
        Public Property i As Integer
        ''' <summary>
        ''' The Object data
        ''' </summary>
        ''' <returns></returns>
        Public Property obj As T

        Private Property Address As Integer Implements IAddressHandle.Address
            Get
                Return CLng(i)
            End Get
            Set
                i = CInt(Value)
            End Set
        End Property

        Sub New(i As Integer, x As T)
            Me.i = i
            obj = x
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetJson(False)
        End Function

        Public Shared Narrowing Operator CType(x As SeqValue(Of T)) As T
            Return x.obj
        End Operator

        Public Shared Narrowing Operator CType(x As SeqValue(Of T)) As Integer
            Return x.i
        End Operator

        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub
    End Structure

    ''' <summary>
    ''' Exposes the enumerator, which supports a simple iteration over a collection of
    ''' a specified type.To browse the .NET Framework source code for this type, see
    ''' the Reference Source.
    ''' (使用这个的原因是系统自带的<see cref="IEnumerable(Of T)"/>在Xml序列化之中的支持不太好)
    ''' </summary>
    ''' <typeparam name="T">The type of objects to enumerate.This type parameter is covariant. That is, you
    ''' can use either the type you specified or any type that is more derived. For more
    ''' information about covariance and contravariance, see Covariance and Contravariance
    ''' in Generics.</typeparam>
    Public Interface IIterator(Of T)

        ''' <summary>
        ''' Returns an enumerator that iterates through the collection.
        ''' </summary>
        ''' <returns>An enumerator that can be used to iterate through the collection.</returns>
        Function GetEnumerator() As IEnumerator(Of T)

        ''' <summary>
        ''' Returns an enumerator that iterates through a collection.
        ''' </summary>
        ''' <returns>An System.Collections.IEnumerator object that can be used to iterate through
        ''' the collection.</returns>
        Function IGetEnumerator() As IEnumerator
    End Interface
End Namespace
