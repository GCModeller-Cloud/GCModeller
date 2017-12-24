﻿#Region "Microsoft.VisualBasic::b257baa49e54304446185e51cbd94bc7, ..\sciBASIC#\Data_science\DataMining\network\Extensions.vb"

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

Imports System.IO
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.DataMining.KMeans
Imports Microsoft.VisualBasic.Language

Public Module Extensions

    ''' <summary>
    ''' 假若有很多个节点的话，则进行聚类会得到很多的属性，但是想要加载的数据
    ''' 只有ID和cluster结果等非附加属性部分，则这个时候可以使用这个函数进行快速加载
    ''' </summary>
    ''' <param name="path$"></param>
    ''' <returns></returns>
    Public Iterator Function ClusterResultFastLoad(path$) As IEnumerable(Of EntityClusterModel)
        Using reader As StreamReader = path.OpenReader
            Dim header As New RowObject(reader.ReadLine)
            Dim cluster% = header.IndexOf(NameOf(EntityClusterModel.Cluster))
            Dim name% = header.IndexOf(NameOf(EntityClusterModel.ID))
            Dim row As New Value(Of RowObject)

            Do While Not reader.EndOfStream
                Yield New EntityClusterModel With {
                    .ID = (row = New RowObject(reader.ReadLine))(name),
                    .Cluster = (+row)(cluster)
                }
            Loop
        End Using
    End Function
End Module
