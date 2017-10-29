﻿#Region "Microsoft.VisualBasic::be8539d53d21392cc1ad57e163220850, ..\sciBASIC#\Data\DataFrame.Extensions\Templates\TemplateHelper.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
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

Imports System.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Scripting

Public Module TemplateHelper

    ''' <summary>
    ''' 扫描目标文件夹之中的所有.NET assembly，然后将<see cref="TemplateAttribute"/>所标记出来的
    ''' 模板类保存到<paramref name="save"/>文件夹之中对应的csv。
    ''' </summary>
    ''' <param name="DIR$"></param>
    ''' <param name="save$"></param>
    ''' <returns></returns>
    Public Function ScanTemplates(DIR$, save$) As Dictionary(Of String, Type)
        Dim typeTable As New Dictionary(Of String, Type)

        For Each dll$ In ls - l - r - {"*.dll", "*.exe"} <= DIR
            Dim assm As Assembly = Assembly.LoadFile(dll)
            Dim types = assm.GetTypes _
                .Select(Function(t) (t.GetCustomAttribute(Of TemplateAttribute), t)) _
                .Where(Function(t) Not t.Item1 Is Nothing)

            For Each t In types
                Dim fileName$ = t.Item1.AliasName Or t.Item2.Name.AsDefault
                Dim path$ = $"{save}/{t.Item1.Category}/{fileName}.csv"
                Dim template As IEnumerable(Of Object) = {
                    Activity.ActiveObject(t.Item2)
                }

                Call template.SaveTo(path)
                Call typeTable.Add(t.Item1.Category & "/" & fileName, t.Item2)
            Next
        Next

        Return typeTable
    End Function
End Module
