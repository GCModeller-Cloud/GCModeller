﻿Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv.Extensions
Imports Microsoft.VisualBasic.DataVisualization.Network.Abstract
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel

Namespace FileStream

    Public MustInherit Class INetComponent : Inherits DynamicPropertyBase(Of String)

        <Meta(GetType(String))>
        Public Overrides Property Properties As Dictionary(Of String, String)
            Get
                Return MyBase.Properties
            End Get
            Set(value As Dictionary(Of String, String))
                MyBase.Properties = value
            End Set
        End Property

        Public Sub Add(key As String, value As String)
            Call Properties.Add(key, value)
        End Sub
    End Class

    ''' <summary>
    ''' An node entity in the target network.(这个对象里面包含了网络之中的节点的实体的最基本的定义：节点的标识符以及节点的类型)
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Node : Inherits INetComponent
        Implements sIdEnumerable
        Implements INode

        ''' <summary>
        ''' 这个节点的标识符
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Property Identifier As String Implements sIdEnumerable.Identifier, INode.Identifier
        ''' <summary>
        ''' Node data groups identifier.(这个节点的分组类型的定义)
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Property NodeType As String Implements INode.NodeType

        Public Overrides Function ToString() As String
            Return Identifier
        End Function

        Sub New()
        End Sub

        Sub New(sId As String)
            Identifier = sId
        End Sub

        Sub New(sid As String, type As String)
            Call Me.New(sid)
            NodeType = type
        End Sub

        Public Function CopyTo(Of T As Node)() As T
            Dim NewNode As T = Activator.CreateInstance(Of T)()
            NewNode.Identifier = Identifier
            NewNode.NodeType = NodeType

            Return NewNode
        End Function
    End Class
End Namespace