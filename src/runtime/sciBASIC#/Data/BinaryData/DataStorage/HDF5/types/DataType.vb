﻿#Region "Microsoft.VisualBasic::b41e08db65075c3547d4b13bd38a446f, Data\BinaryData\DataStorage\HDF5\types\DataType.vb"

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

    '     Class DataType
    ' 
    '         Properties: [class], size, version
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Data.IO.HDF5.device

Namespace HDF5.type

    Public MustInherit Class DataType

        Public Property version As Integer
        Public Property [class] As DataTypes

        ''' <summary>
        ''' 数据元素<see cref="DataTypes"/>的单位大小
        ''' </summary>
        ''' <returns></returns>
        Public Property size As Integer

        Public MustOverride ReadOnly Property TypeInfo As System.Type

    End Class
End Namespace
