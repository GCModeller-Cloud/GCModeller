﻿Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Public Structure HashValue : Implements sIdEnumerable

    Public Property Identifier As String Implements sIdEnumerable.Identifier
    Public Property value As String

    Sub New(name As String, value As String)
        Me.Identifier = name
        Me.value = value
    End Sub

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function

    Public Shared Operator +(hash As Dictionary(Of String, String), tag As HashValue) As Dictionary(Of String, String)
        Call hash.Add(tag.Identifier, tag.value)
        Return hash
    End Operator
End Structure
