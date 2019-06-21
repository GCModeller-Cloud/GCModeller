﻿#Region "Microsoft.VisualBasic::c87ec1722a2965ddc2ee3740587e4f1a, Bio.Assembly\Assembly\KEGG\DBGET\LinkDB\GenericParser.vb"

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

'     Module GenericParser
' 
'         Function: LinkDbEntries
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.Text.Parser.HtmlParser
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports SMRUCC.genomics.ComponentModel

Namespace Assembly.KEGG.DBGET.LinkDB

    ''' <summary>
    ''' 通用化的linkdb数据解析器
    ''' </summary>
    Public Class GenericParser : Inherits WebQuery(Of String)

        Const regexpLine$ = "<a href="".+?"">.+?</a>.+?$"

        Public Sub New(<CallerMemberName>
                       Optional cache As String = Nothing,
                       Optional interval As Integer = -1,
                       Optional offline As Boolean = False)

            MyBase.New(url:=Function(strUrl) strUrl,
                       contextGuid:=AddressOf queryArguments,
                       parser:=AddressOf ParsePage,
                       prefix:=AddressOf argumentPrefix,
                       cache:=cache,
                       interval:=interval,
                       offline:=offline
                   )
        End Sub

        Public Shared Function LinkDbEntries(url$, Optional cache$ = "./.kegg/linkdb/", Optional offline As Boolean = False) As KeyValuePair()
            Static handlers As New Dictionary(Of String, GenericParser)

            Dim query As GenericParser = handlers.ComputeIfAbsent(
                key:=cache,
                lazyValue:=Function()
                               Return New GenericParser(cache,, offline)
                           End Function)

            Return query.Query(Of KeyValuePair())(url, ".html")
        End Function

        Private Shared Function queryArguments(url As String) As String
            Throw New NotImplementedException
        End Function

        Private Shared Function argumentPrefix(arg As String) As String
            Throw New NotImplementedException
        End Function

        Private Shared Function ParsePage(html$, null As Type) As Object
            Return LinkDbEntries(Strings.Split(html, Modules.SEPERATOR).Last).ToArray
        End Function

        Private Shared Iterator Function LinkDbEntries(html As String) As IEnumerable(Of KeyValuePair)
            Dim links$() = Regex _
                .Matches(html, regexpLine, RegexICMul) _
                .ToArray

            For Each line As String In links.Take(links.Length - 1)
                Dim entry As String = Regex.Match(line, ">.+?</a>").Value.GetValue
                Dim description As String = Strings.Split(line, "</a>").Last.Trim
                Dim out As New KeyValuePair With {
                    .Key = entry,
                    .Value = description
                }

                Yield out
            Next
        End Function
    End Class
End Namespace
