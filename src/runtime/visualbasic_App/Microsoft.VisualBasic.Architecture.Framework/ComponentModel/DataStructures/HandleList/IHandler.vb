﻿#Region "d32663d246b27b06088d614d2bb43937, ..\Microsoft.VisualBasic.Architecture.Framework\ComponentModel\DataStructures\HandleList\IHandler.vb"

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
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language

Namespace ComponentModel

    ''' <summary>
    ''' This object gets a object handle value to indicated that the position this object exists 
    ''' in the list collection structure. 
    ''' (这个对象具有一个用于指明该对象在列表对象中的位置的对象句柄值)
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IAddressHandle : Inherits IDisposable, IAddress(Of Integer)
    End Interface

    ''' <summary>
    ''' This object gets a object handle value to indicated that the position this object exists 
    ''' in the list collection structure. 
    ''' (这个对象具有一个用于指明该对象在列表对象中的位置的对象句柄值)
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IAddress(Of T As IComparable)

        ''' <summary>
        ''' The ID that this object in a list instance.
        ''' (本对象在一个列表对象中的位置索引号) 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Address As T
    End Interface

    Public Interface IHashHandle : Inherits IAddressHandle, sIdEnumerable
    End Interface

    Public Class IHashValue(Of T As sIdEnumerable) : Inherits ClassObject
        Implements IHashHandle

        Public Property obj As T

        Public Property Address As Integer Implements IAddressHandle.Address

        Public Property Identifier As String Implements sIdEnumerable.Identifier
            Get
                Return obj.Identifier
            End Get
            Set(value As String)
                obj.Identifier = value
            End Set
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub
    End Class

    Public Module AddressDataExtensions

        <Extension>
        Public Function Vector(Of T As IAddress(Of Integer), TOut)(source As IEnumerable(Of T), length As Integer, getValue As Func(Of T, TOut)) As TOut()
            Dim chunk As TOut() = New TOut(length - 1) {}

            For Each x As T In source
                chunk(x.Address) = getValue(x)
            Next

            Return chunk
        End Function
    End Module
End Namespace
