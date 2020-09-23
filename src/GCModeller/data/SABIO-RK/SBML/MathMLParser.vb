﻿#Region "Microsoft.VisualBasic::b254b435c382c44545396f33beddb7e1, data\SABIO-RK\SBML\MathMLParser.vb"

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

    '     Module MathMLParser
    ' 
    '         Function: ParseMathML
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.MIME.application.xml
Imports Microsoft.VisualBasic.Text
Imports r = System.Text.RegularExpressions.Regex

Namespace SBML

    Public Module MathMLParser

        Const startTag As String = "<listOfFunctionDefinitions"
        Const functionMLPattern As String = "<functionDefinition.+?</functionDefinition>"

        Public Iterator Function ParseMathML(sbmlText As String) As IEnumerable(Of NamedValue(Of XmlElement))
            Dim start = sbmlText.IndexOf(startTag)
            Dim ends = sbmlText.IndexOf("</listOfFunctionDefinitions>")

            sbmlText = sbmlText _
                .Substring(start + startTag.Length + 1, ends - start - startTag.Length - 1) _
                .Trim(" "c, ASCII.TAB, ASCII.CR, ASCII.LF)

            Dim functions As String() = r _
                .Matches(sbmlText, functionMLPattern, RegexICSng) _
                .ToArray
            Dim xml As XmlElement
            Dim id As String
            Dim term As String
            Dim math As XmlElement

            For Each func As String In functions
                xml = XmlElement.ParseXmlText(func)
                id = xml.attributes("id")
                term = xml.attributes.TryGetValue("sboTerm")
                math = xml.getElementsByTagName("math").First

                Yield New NamedValue(Of XmlElement) With {
                    .Name = id,
                    .Description = term,
                    .Value = math
                }
            Next
        End Function
    End Module
End Namespace
