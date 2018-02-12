﻿#Region "Microsoft.VisualBasic::5f3407c6cf7421d90535ca5dec6a757f, Microsoft.VisualBasic.Core\ComponentModel\DataStructures\Tree\BinaryTree\Extensions.vb"

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

    '     Module Extensions
    ' 
    '         Function: Add, NameCompare, NameFuzzyMatch
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports sys = System.Math

Namespace ComponentModel.DataStructures.BinaryTree

    Public Module Extensions

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function Add(Of T)(tree As BinaryTree(Of NamedValue(Of T)), node As NamedValue(Of T)) As TreeNode(Of NamedValue(Of T))
            Return tree.insert(node.Name, node)
        End Function

        ''' <summary>
        ''' 字符串名字的比较规则：
        ''' 
        ''' 假若字符串是空值或者空字符串，则该变量小
        ''' 假若字符串相等（忽略大小写），则变量值一样
        ''' 最后逐个字符进行比较，按照字母的charcode大小来比较，第一个charcode大的变量大
        ''' </summary>
        ''' <param name="a$"></param>
        ''' <param name="b$"></param>
        ''' <returns></returns>
        Public Function NameCompare(a$, b$) As Integer
            Dim null1 = String.IsNullOrEmpty(a)
            Dim null2 = String.IsNullOrEmpty(b)

            If null1 AndAlso null2 Then
                Return 0
            ElseIf null1 Then
                Return -1
            ElseIf null2 Then
                Return 1
            ElseIf String.Equals(a, b, StringComparison.OrdinalIgnoreCase) Then
                Return 0
            Else

                Dim minl = sys.Min(a.Length, b.Length)
                Dim c1, c2 As Char

                For i As Integer = 0 To minl - 1
                    c1 = Char.ToLower(a.Chars(i))
                    c2 = Char.ToLower(b.Chars(i))

                    If c1 <> c2 Then
                        Return c1.CompareTo(c2)
                    End If
                Next

                If a.Length < b.Length Then
                    Return -1
                Else
                    Return 1
                End If
            End If
        End Function

        ''' <summary>
        ''' The term index search engine.
        ''' 
        ''' + If the string similarity less than threshold, then will returns negative value
        ''' + If the string similarity greater than threshold, then will returns positive value
        ''' + If the string text equals to other, then will reutrns ZERO
        ''' </summary>
        ''' <param name="a$"></param>
        ''' <param name="b$"></param>
        ''' <returns></returns>
        Public Function NameFuzzyMatch(a$, b$) As Integer
            Dim similarity = Text.Levenshtein.ComputeDistance(a, b)

            If a.TextEquals(b) Then
                Return 0
            ElseIf similarity Is Nothing Then
                Return -1
            ElseIf similarity.MatchSimilarity < 0.6 Then
                Return -1
            Else
                Return 1
            End If
        End Function
    End Module
End Namespace
