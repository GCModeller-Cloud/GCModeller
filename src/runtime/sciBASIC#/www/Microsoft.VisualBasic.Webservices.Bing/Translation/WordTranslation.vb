﻿#Region "Microsoft.VisualBasic::4ce8479104a80dbfe9d94f552fa7d280, www\Microsoft.VisualBasic.Webservices.Bing\Translation\WordTranslation.vb"

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

    ' Class WordTranslation
    ' 
    '     Properties: Pronunciation, Translations, Word
    ' 
    '     Function: ToString
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Data.Trinity.NLP
Imports Microsoft.VisualBasic.Serialization.JSON

''' <summary>
''' 单词翻译的结果
''' </summary>
Public Class WordTranslation

    ''' <summary>
    ''' 输入的目标单词
    ''' </summary>
    ''' <returns></returns>
    Public Property Word As String
    ''' <summary>
    ''' 该单词所产生的翻译结果列表
    ''' </summary>
    ''' <returns></returns>
    Public Property Translations As Word()
    Public Property Pronunciation As String()

    Public Overrides Function ToString() As String
        Return $"{Word} -> {Translations.GetJson}"
    End Function
End Class
