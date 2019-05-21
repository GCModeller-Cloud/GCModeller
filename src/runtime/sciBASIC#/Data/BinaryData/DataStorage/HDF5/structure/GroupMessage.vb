﻿#Region "Microsoft.VisualBasic::51552d98f89a498ff29d21fdacc19659, mime\application%netcdf\HDF5\structure\GroupMessage.vb"

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

    '     Class GroupMessage
    ' 
    '         Properties: address, bTreeAddress, nameHeapAddress
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Sub: printValues
    ' 
    ' 
    ' /********************************************************************************/

#End Region

'
' * Mostly copied from NETCDF4 source code.
' * refer : http://www.unidata.ucar.edu
' * 
' * Modified by iychoi@email.arizona.edu
' 


Imports Microsoft.VisualBasic.Data.IO.HDF5.IO

Namespace HDF5.[Structure]

    ''' <summary>
    ''' The Symbol Table Message
    ''' </summary>
    Public Class GroupMessage : Inherits HDF5Ptr

        Private m_bTreeAddress As Long
        Private m_nameHeapAddress As Long

        Public Sub New([in] As BinaryReader, sb As Superblock, address As Long)
            Call MyBase.New(address)

            [in].offset = address

            Me.m_bTreeAddress = ReadHelper.readO([in], sb)
            Me.m_nameHeapAddress = ReadHelper.readO([in], sb)
        End Sub

        ''' <summary>
        ''' This value is the address of the v1 B-tree containing the symbol table 
        ''' entries for the group.
        ''' </summary>
        ''' <returns></returns>
        Public Overridable ReadOnly Property bTreeAddress() As Long
            Get
                Return Me.m_bTreeAddress
            End Get
        End Property

        ''' <summary>
        ''' This value is the address of the local heap containing the link names 
        ''' for the symbol table entries for the group.
        ''' </summary>
        ''' <returns></returns>
        Public Overridable ReadOnly Property nameHeapAddress() As Long
            Get
                Return Me.m_nameHeapAddress
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{MyBase.ToString} {bTreeAddress} -> {nameHeapAddress}"
        End Function

        Public Overridable Sub printValues()
            Console.WriteLine("GroupMessage >>>")
            Console.WriteLine("address : " & Me.m_address)
            Console.WriteLine("btree address : " & Me.m_bTreeAddress)
            Console.WriteLine("nameheap address : " & Me.m_nameHeapAddress)
            Console.WriteLine("GroupMessage <<<")
        End Sub

    End Class

End Namespace
