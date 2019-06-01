﻿#Region "Microsoft.VisualBasic::95fdc4d337a43bf02da1429d26ca88c3, GSEA\GSEA\Cluster.vb"

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

    ' Class Cluster
    ' 
    '     Properties: description, ID, members, names
    ' 
    '     Function: Intersect, ToString
    ' 
    ' Class Background
    ' 
    '     Properties: build, clusters, comments, name
    ' 
    '     Function: ToString
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.ComponentModel.DBLinkBuilder

''' <summary>
''' 主要是KEGG代谢途径，也可以是其他的具有生物学意义的聚类结果
''' </summary>
Public Class Cluster : Implements INamedValue

    ''' <summary>
    ''' 代谢途径的编号或者其他的标识符
    ''' </summary>
    ''' <returns></returns>
    <XmlAttribute>
    Public Property ID As String Implements IKeyedEntity(Of String).Key
    Public Property names As String
    <XmlElement>
    Public Property description As String

    ''' <summary>
    ''' 当前的这个聚类之中的基因列表
    ''' </summary>
    ''' <returns></returns>
    Public Property members As Synonym()

    Dim index As Index(Of String)

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function Intersect(list As IEnumerable(Of String)) As IEnumerable(Of String)
        If index Is Nothing Then
            index = members _
                .Select(Function(name) name.AsEnumerable) _
                .IteratesALL _
                .Distinct _
                .ToArray
        End If

        Return index.Intersect(collection:=list)
    End Function

    Public Overrides Function ToString() As String
        Return ID
    End Function
End Class

''' <summary>
''' 假设基因组是有许多个功能聚类的集合构成的
''' </summary>
<XmlRoot("background", [Namespace]:="http://gcmodeller.org/GSEA/background.xml")>
Public Class Background : Inherits XmlDataModel
    Implements INamedValue

    Public Property name As String Implements IKeyedEntity(Of String).Key
    Public Property comments As String
    Public Property build As Date = Now

    <XmlElement>
    Public Property clusters As Cluster()

    Public Overrides Function ToString() As String
        Return name
    End Function
End Class
