﻿#Region "Microsoft.VisualBasic::0ac56e019e9f6e4ccebfc5cd3c2275df, ..\sciBASIC#\CLI_tools\vbproj\Template\Project.vb"

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

Imports System.Text
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Text
Imports Microsoft.VisualBasic.Text.Xml

Public Class Project : Implements ISaveHandle

    <XmlAttribute> Public Property ToolsVersion As String
    <XmlAttribute> Public Property DefaultTargets As String

    <XmlElement("Import")>
    Public Property [Imports] As Import()

    <XmlElement("PropertyGroup")>
    Public Property PropertyGroups As PropertyGroup()
    <XmlElement("ItemGroup")>
    Public Property ItemGroups As ItemGroup()
    <XmlElement("Target")>
    Public Property Targets As Target()

    Public Function GetProfile(condition As String) As PropertyGroup
        Return LinqAPI.DefaultFirst(Of PropertyGroup) _
 _
        () <= From x As PropertyGroup
              In PropertyGroups
              Where Not x.Condition.StringEmpty AndAlso
                  condition.TextEquals(x.Condition)
              Select x

    End Function

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function

    Public Shared Function RemoveNamespace(xml As String) As String
        Dim doc As New XmlDoc(xml)
        doc.xmlns.xmlns = Nothing
        xml = doc.ToString
        Return xml
    End Function

    Const xmlns$ = "http://schemas.microsoft.com/developer/msbuild/2003"

    Public Function Save(Optional path As String = "", Optional encoding As Encoding = Nothing) As Boolean Implements ISaveHandle.Save
        Dim xml As New XmlDoc(GetXml)
        xml.xmlns.xmlns = Project.xmlns
        xml.xmlns.xsd = ""
        xml.xmlns.xsi = ""
        xml.encoding = XmlEncodings.UTF8
        xml.standalone = True
        Return xml.ToString.SaveTo(path, encoding)
    End Function

    Public Function Save(Optional path As String = "", Optional encoding As Encodings = Encodings.UTF8) As Boolean Implements ISaveHandle.Save
        Return Save(path, encoding.CodePage)
    End Function
End Class

Public Class Target
    <XmlAttribute> Public Property Name As String
End Class

Public Class Import

    <XmlAttribute> Public Property Project As String
    <XmlAttribute> Public Property Condition As String
    <XmlAttribute> Public Property Label As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class

Public Class ConditionValue

    <XmlAttribute>
    Public Property Condition As String
    <XmlText>
    Public Property value As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class
