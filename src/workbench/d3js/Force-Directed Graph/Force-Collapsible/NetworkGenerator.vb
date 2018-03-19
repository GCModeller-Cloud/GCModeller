﻿#Region "Microsoft.VisualBasic::5131f0c9b1d473b98bbdc350e0b7bb6d, d3js\Force-Directed Graph\Force-Collapsible\NetworkGenerator.vb"

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

    ' Module NetworkGenerator
    ' 
    '     Function: FromNetwork, (+2 Overloads) FromRegulations, LoadJson
    ' 
    ' Class Regulation
    ' 
    '     Properties: MotifFamily, ORF_ID, Regulator
    ' 
    '     Function: ToString
    ' 
    ' Structure out
    ' 
    '     Properties: links, nodes
    ' 
    '     Function: ToString
    ' 
    ' Class node
    ' 
    '     Properties: Address, group, name, size, type
    ' 
    '     Function: ToString
    ' 
    '     Sub: (+2 Overloads) Dispose
    ' 
    ' Class link
    ' 
    '     Properties: source, target, value
    ' 
    '     Function: ToString
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Data.visualize.Network
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

''' <summary>
''' Network visualization model json data generator.
''' </summary>
Public Module NetworkGenerator

    ''' <summary>
    ''' Creates network data from network model
    ''' </summary>
    ''' <param name="net"></param>
    ''' <returns></returns>
    <Extension>
    Public Function FromNetwork(net As FileStream.Network) As String
        Dim types As String() = net.Nodes.Select(Function(x) x.NodeType).Distinct.ToArray
        Dim nodes As node() = LinqAPI.Exec(Of node) <=
 _
            From x As FileStream.Node
            In net.Nodes
            Select New node With {
                .name = x.Identifier,
                .group = Array.IndexOf(types, x.NodeType),
                .type = x.NodeType,
                .size = net.Links(x.Identifier)
            }
        nodes = nodes.AddHandle

        Dim nodeHash = nodes.ToDictionary
        Dim links As link() =
            LinqAPI.Exec(Of link) <= From edge As NetworkEdge
                                     In net.Edges
                                     Select New link With {
                                         .source = nodeHash(edge.FromNode).Address,
                                         .target = nodeHash(edge.ToNode).Address,
                                         .value = edge.Confidence
                                     }
        Dim json As String = New out With {
            .nodes = nodes,
            .links = links
        }.GetJson
        Return json
    End Function

    ''' <summary>
    ''' Build network json data from the bacterial transcription regulation network
    ''' </summary>
    ''' <param name="regs"></param>
    ''' <returns></returns>
    <Extension>
    Public Function FromRegulations(regs As IEnumerable(Of Regulation)) As String
        Dim nodes As String() =
            LinqAPI.Exec(Of String) <= From x As Regulation
                                       In regs
                                       Select {x.ORF_ID, x.Regulator}
        Dim net As New FileStream.Network
        Dim nodesHash = (From x As Regulation
                         In regs
                         Select x
                         Group x By x.ORF_ID Into Group) _
                              .ToDictionary(Function(x) x.ORF_ID,
                                            Function(x) (From g As Regulation
                                                         In x.Group
                                                         Select g
                                                         Group g By g.MotifFamily Into Count
                                                         Order By Count Descending).First.MotifFamily)

        For Each tf As String In regs.Select(Function(x) x.Regulator).Distinct
            If nodesHash.ContainsKey(tf) Then
                Call nodesHash.Remove(tf)
            End If
            Call nodesHash.Add(tf, NameOf(tf))
        Next

        net += nodes.Distinct.ToArray(Function(x) New FileStream.Node(x, nodesHash(x)))
        net += From o In (From x As Regulation
                          In regs
                          Select x
                          Group x By x.GetJson Into Group)
               Let edge As Regulation = o.Group.First
               Let n As Integer = o.Group.Count
               Select New NetworkEdge(edge.Regulator, edge.ORF_ID, n)

        Return net.FromNetwork
    End Function

    ''' <summary>
    ''' Build network json data from the bacterial transcription regulation network
    ''' </summary>
    ''' <param name="regs">The raw csv document file path.</param>
    ''' <returns></returns>
    Public Function FromRegulations(regs As String) As String
        Dim json As String =
            regs.LoadCsv(Of Regulation).FromRegulations()
        Return json
    End Function

    Public Function LoadJson(netDIR As String) As String
        Dim net As FileStream.Network =
            FileStream.Network.Load(netDIR)
        Dim json As String = FromNetwork(net)
        Return json
    End Function
End Module

Public Class Regulation
    <Column("ORF ID")> Public Property ORF_ID As String
    Public Property MotifFamily As String
    Public Property Regulator As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class

''' <summary>
''' helper class for json text generation 
''' </summary>
Public Structure out

    ''' <summary>
    ''' 网络之中的节点对象
    ''' </summary>
    ''' <returns></returns>
    Public Property nodes As node()
    ''' <summary>
    ''' 节点之间的边链接
    ''' </summary>
    ''' <returns></returns>
    Public Property links As link()

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Structure

Public Class node : Implements IAddressHandle, sIdEnumerable

    Public Property name As String Implements sIdEnumerable.Identifier
    Public Property group As Integer
    Public Property size As Integer
    Public Property type As String

    Public Property Address As Integer Implements IAddressHandle.Address

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class

Public Class link
    Public Property source As Integer
    Public Property target As Integer
    Public Property value As Integer

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class
