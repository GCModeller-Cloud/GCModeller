﻿#Region "Microsoft.VisualBasic::91eec5ba99a712c811a6ce5075400008, ..\visualbasic_App\Microsoft.VisualBasic.Architecture.Framework\ComponentModel\System.Collections.Generic\Dictionary(Of T, V).vb"

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

Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language

''' <summary>
''' Represents a collection of keys and values.To browse the .NET Framework source
''' code for this type, see the Reference Source.
''' </summary>
''' <typeparam name="V"></typeparam>
Public Class Dictionary(Of V As sIdEnumerable) : Inherits SortedDictionary(Of String, V)

    Sub New()
        Call MyBase.New
    End Sub

    ''' <summary>
    ''' Initializes a new instance of the System.Collections.Generic.SortedDictionary`2
    ''' class that contains elements copied from the specified System.Collections.Generic.IDictionary`2
    ''' and uses the default System.Collections.Generic.IComparer`1 implementation for
    ''' the key type.
    ''' </summary>
    ''' <param name="source">
    ''' The System.Collections.Generic.IDictionary`2 whose elements are copied to the
    ''' new System.Collections.Generic.SortedDictionary`2.
    ''' </param>
    Sub New(source As Dictionary(Of String, V))
        Call MyBase.New(source)
    End Sub

    Sub New(source As IEnumerable(Of V))
        Call Me.New

        For Each x As V In source
            Call Add(x)
        Next
    End Sub

    Public Function GetValueList() As List(Of V)
        Return Values.ToList
    End Function

    ''' <summary>
    ''' Adds an element with the specified key and value into the System.Collections.Generic.SortedDictionary`2.
    ''' </summary>
    ''' <param name="item"></param>
    Public Overloads Sub Add(item As V)
        Call MyBase.Add(item.Identifier, item)
    End Sub

    Public Sub AddRange(source As IEnumerable(Of V))
        For Each x As V In source
            Call MyBase.Add(x.Identifier, x)
        Next
    End Sub

    Public Sub InsertOrUpdate(x As V)
        If Me.ContainsKey(x.Identifier) Then
            Me(x.Identifier) = x
        Else
            Call MyBase.Add(x.Identifier, x)
        End If
    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="name">不区分大小写的</param>
    ''' <returns></returns>
    Public Function Find(name As String) As V
        If MyBase.ContainsKey(name) Then
            Return Me(name)
        Else
            Dim key As New Value(Of String)

            If Me.ContainsKey(key = name.ToLower) Then
                Return Me(name)
            ElseIf Me.ContainsKey(key = name.ToUpper) Then
                Return Me(name)
            Else
                Return Nothing
            End If
        End If
    End Function

    ''' <summary>
    ''' If the value is not found in the hash directionary, then the default value will be returns, and the default value is nothing.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="[default]"></param>
    ''' <param name="success">可能value本身就是空值，所以在这里使用这个参数来判断是否存在</param>
    ''' <returns></returns>
    Public Function SafeGetValue(name As String,
                                 Optional ByRef [default] As V = Nothing,
                                 Optional ByRef success As Boolean = False) As V
        Dim x As V = Nothing

        success = MyBase.TryGetValue(name, x)

        If success Then
            Return x
        Else
            Return [default]
        End If
    End Function

    ''' <summary>
    ''' Gets the value associated with the specified key.
    ''' </summary>
    ''' <param name="name">The key of the value to get.</param>
    ''' <param name="success">true if the System.Collections.Generic.SortedDictionary`2 contains an element
    ''' with the specified key; otherwise, false.</param>
    ''' <returns>When this method returns, the value associated with the specified key, if the
    ''' key is found; otherwise, the default value for the type of the value parameter.</returns>
    Public Overloads Function TryGetValue(name As String, Optional ByRef success As Boolean = True) As V
        Dim value As V = Nothing
        success = MyBase.TryGetValue(name, value)
        Return value
    End Function

    ''' <summary>
    ''' 假若目标元素不存在于本字典之中，则会返回False
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    Public Overloads Function Remove(x As V) As Boolean
        If Me.ContainsKey(x.Identifier) Then
            Return Me.Remove(x.Identifier)
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Adds an element with the specified key and value into the System.Collections.Generic.SortedDictionary`2.
    ''' </summary>
    ''' <param name="hash"></param>
    ''' <param name="item"></param>
    ''' <returns></returns>
    Public Shared Operator +(hash As Dictionary(Of V), item As V) As Dictionary(Of V)
        Call hash.Add(item)
        Return hash
    End Operator

    ''' <summary>
    ''' Find a variable in the hash table
    ''' </summary>
    ''' <param name="hash"></param>
    ''' <param name="uid"></param>
    ''' <returns></returns>
    Public Shared Operator ^(hash As Dictionary(Of V), uid As String) As V
        If hash.ContainsKey(uid) Then
            Return hash(uid)
        Else
            Return Nothing
        End If
    End Operator

    Public Shared Operator -(hash As Dictionary(Of V), id As String) As Dictionary(Of V)
        Call hash.Remove(id)
        Return hash
    End Operator

    Public Shared Widening Operator CType(source As System.Collections.Generic.List(Of V)) As Dictionary(Of V)
        Return source.ToDictionary
    End Operator

    Public Shared Widening Operator CType(source As V()) As Dictionary(Of V)
        Return source.ToDictionary
    End Operator

    Public Shared Narrowing Operator CType(source As Dictionary(Of V)) As List(Of V)
        Return New List(Of V)(source.Values)
    End Operator

    ''' <summary>
    ''' Get value by key.
    ''' </summary>
    ''' <param name="hash"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Public Shared Operator <=(hash As Dictionary(Of V), key As String) As V
        Return hash(key)
    End Operator

    Public Shared Operator >=(hash As Dictionary(Of V), null As String) As V
        Throw New NotSupportedException
    End Operator

    Public Shared Operator &(hash As Dictionary(Of V), null As String) As Boolean
        Return hash.ContainsKey(null)
    End Operator
End Class
