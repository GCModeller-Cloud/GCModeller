﻿#Region "Microsoft.VisualBasic::f5b91455254db6e8f3918e0a345d4cbf, ..\Microsoft.VisualBasic.Architecture.Framework\Extensions\StringHelpers\StringHelpers.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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

Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Terminal
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel

''' <summary>
''' The extensions module for facilities the string operations.
''' </summary>
<PackageNamespace("StringHelpers", Publisher:="amethyst.asuka@gcmodeller.org", Url:="http://gcmodeller.org")>
Public Module StringHelpers

    <Extension>
    Public Function CharString(chs As IEnumerable(Of Char)) As String
        Return New String(chs.ToArray)
    End Function

    '
    ' Summary:
    '     Replaces the format item in a specified string with the string representation
    '     of a corresponding object in a specified array.
    '
    ' Parameters:
    '   format:
    '     A composite format string.
    '
    '   args:
    '     An object array that contains zero or more objects to format.
    '
    ' Returns:
    '     A copy of format in which the format items have been replaced by the string representation
    '     of the corresponding objects in args.
    '
    ' Exceptions:
    '   T:System.ArgumentNullException:
    '     format or args is null.
    '
    '   T:System.FormatException:
    '     format is invalid.-or- The index of a format item is less than zero, or greater
    '     than or equal to the length of the args array.

    ''' <summary>
    ''' Replaces the format item in a specified string with the string representation
    ''' of a corresponding object in a specified array.
    ''' </summary>
    ''' <param name="s">A composite format string.</param>
    ''' <param name="args">An object array that contains zero or more objects to format.</param>
    ''' <returns>A copy of format in which the format items have been replaced by the string representation
    ''' of the corresponding objects in args.</returns>
    <Extension>
    Public Function sFormat(s As String, ParamArray args As Object()) As String
        Return String.Format(s, args)
    End Function

    ''' <summary>
    ''' this is to emulate what's evailable in PHP
    ''' </summary>
    ''' 
    <Extension>
    Public Function RepeatString(text As String, count As Integer) As String
        Dim sb = New StringBuilder(text.Length * count)
        For i As Integer = 0 To count - 1
            Call sb.Append(text)
        Next
        Return sb.ToString()
    End Function

    ''' <summary>
    ''' tagName{<paramref name="delimiter"/>}value
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="delimiter"></param>
    ''' <param name="trim">Needs Removes all leading and trailing white-space characters from 
    ''' the current <see cref="System.String"/> object.</param>
    ''' <returns></returns>
    <Extension>
    Public Function GetTagValue(s As String, Optional delimiter As String = " ", Optional trim As Boolean = False) As NamedValue(Of String)
        Dim p As Integer = InStr(s, delimiter, CompareMethod.Text)
        If p = 0 Then
            Return New NamedValue(Of String)("", s)
        Else
            Dim key As String = Mid(s, 1, p - delimiter.Length)
            Dim value As String = Mid(s, p + delimiter.Length)

            If trim Then
                value = value.Trim
            End If

            Return New NamedValue(Of String)(key, value)
        End If
    End Function

    ''' <summary>
    ''' Shortcuts for method <see cref="String.Equals"/>(s1, s2, <see cref="StringComparison.OrdinalIgnoreCase"/>)
    ''' </summary>
    ''' <param name="s1"></param>
    ''' <param name="s2"></param>
    ''' <returns></returns>
    <Extension>
    Public Function TextEquals(s1 As String, s2 As String) As Boolean
        Return String.Equals(s1, s2, StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' <see cref="RegexOptions.IgnoreCase"/> + <see cref="RegexOptions.Singleline"/> 
    ''' </summary>
    Public Const RegexICSng As RegexOptions = RegexOptions.IgnoreCase + RegexOptions.Singleline

    ''' <summary>
    ''' <see cref="RegexOptions.IgnoreCase"/> + <see cref="RegexOptions.Multiline"/> 
    ''' </summary>
    Public Const RegexICMul As RegexOptions = RegexOptions.IgnoreCase + RegexOptions.Multiline

    ''' <summary>
    ''' <paramref name="s"/> Is Nothing, <see cref="String.IsNullOrEmpty"/>, <see cref="String.IsNullOrWhiteSpace"/>
    ''' </summary>
    ''' <param name="s">The input test string</param>
    ''' <returns></returns>
    <Extension> Public Function IsBlank(s As String) As Boolean
        If s Is Nothing OrElse
            String.IsNullOrEmpty(s) OrElse
            String.IsNullOrWhiteSpace(s) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Call <see cref="StringBuilder.Remove"/>(<see cref="StringBuilder.Length"/> - 1, 1) for removes the last character in the string sequence.
    ''' </summary>
    ''' <param name="s"></param>
    <Extension> Public Sub RemoveLast(s As StringBuilder)
        Call s.Remove(s.Length - 1, 1)
    End Sub

    ''' <summary>
    ''' Returns a reversed version of String s.
    ''' </summary>
    ''' <param name="sb"></param>
    ''' <returns></returns>
    <Extension> Public Function Reverse(ByRef sb As StringBuilder) As StringBuilder
        Dim s As String = New String(sb.ToString.Reverse.ToArray)
        sb = New StringBuilder(s)
        Return sb
    End Function

    ''' <summary>
    ''' Returns a reversed version of String s.
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    Public Function Reverse(s As String) As String
        Return New String(s.Reverse.ToArray)
    End Function

    Public ReadOnly Property StrictCompares As StringComparison = StringComparison.Ordinal
    ''' <summary>
    ''' String compares with ignored chars' case.(忽略大小写为非严格的比较)
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property NonStrictCompares As StringComparison = StringComparison.OrdinalIgnoreCase

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="len"></param>
    ''' <returns></returns>
    <ExportAPI("s.Parts")>
    Public Function Parts(s As String, len As String) As String
        Dim sbr As New StringBuilder
        Call Parts(s, len, sbr)
        Return sbr.ToString
    End Function

    Public Sub Parts(s As String, len As String, ByRef sbr As StringBuilder)
        Do While Not String.IsNullOrEmpty(s)
            Call sbr.Append(Mid(s, 1, len))
            s = Mid(s, len + 1)
            If String.IsNullOrEmpty(s) Then
                Return
            End If
            Dim fs As Integer = InStr(s, " ")

            If fs = 0 Then
                Call sbr.AppendLine(s)
                Return
            End If

            Dim Firts As String = Mid(s, 1, fs - 1)
            s = Mid(s, fs + 1)
            Call sbr.AppendLine(Firts)
        Loop
    End Sub

    ''' <summary>
    ''' Regex expression for parsing E-Mail URL
    ''' </summary>
    Const REGEX_EMAIL As String = "[a-z0-9\._-]+@[a-z0-9\._-]+"
    ''' <summary>
    ''' Regex exprression for parsing the http/ftp URL
    ''' </summary>
    Const REGEX_URL As String = "(ftp|http(s)?)[:]//[a-z0-9\.-_]+\.[a-z]+/*[^""]*"

    <ExportAPI("Parsing.E-Mails")>
    Public Function GetEMails(s As String) As String()
        Dim values As String() = Regex.Matches(s, REGEX_EMAIL, RegexOptions.IgnoreCase Or RegexOptions.Singleline).ToArray
        Return values
    End Function

    <ExportAPI("Parsing.URLs")>
    Public Function GetURLs(s As String) As String()
        Dim values As String() = Regex.Matches(s, REGEX_URL, RegexOptions.IgnoreCase Or RegexOptions.Singleline).ToArray
        Return values
    End Function

    ''' <summary>
    ''' Counts the specific char that appeared in the input string.
    ''' (计数在字符串之中所出现的指定的字符的出现的次数)
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="ch"></param>
    ''' <returns></returns>
    '''
    <ExportAPI("Count", Info:="Counting the specific char in the input string value.")>
    <Extension> Public Function Count(str As String, ch As Char) As Integer
        If String.IsNullOrEmpty(str) Then
            Return 0
        End If

        Dim LQuery = (From chr As Char In str Where ch = chr Select 1).ToArray
        Return LQuery.Length
    End Function

    ''' <summary>
    ''' 获取""或者其他字符所包围的字符串的值
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="wrapper"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI("Wrapper.Trim")>
    <Extension> Public Function GetString(s As String, Optional wrapper As Char = """"c) As String
        If String.IsNullOrEmpty(s) OrElse Len(s) = 1 Then
            Return s
        End If
        If s.First = wrapper AndAlso s.Last = wrapper Then
            Return Mid(s, 2, Len(s) - 2)
        Else
            Return s
        End If
    End Function

    <ExportAPI("Get.Stackvalue")>
    <Extension>
    Public Function GetStackValue(s_Data As String, left As String, right As String) As String
        If Len(s_Data) < 2 Then
            Return ""
        End If

        Dim p As Integer = InStr(s_Data, left) + 1
        Dim q As Integer = InStrRev(s_Data, right)

        If p = 0 Or q = 0 Then
            Return s_Data
        ElseIf p >= q Then
            Return ""
        Else
            s_Data = Mid(s_Data, p, q - p)
            Return s_Data
        End If
    End Function

    <ExportAPI("FormatZero")>
    <Extension> Public Function FormatZero(n As Integer, Optional fill As String = "00") As String
        Dim s = n.ToString
        Dim d = Len(fill) - Len(s)

        If d < 0 Then
            Return s
        Else
            Return Mid(fill, 1, d) & s
        End If
    End Function

    ''' <summary>
    ''' 求交集
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI("Intersection")>
    <Extension> Public Function Intersection(source As IEnumerable(Of IEnumerable(Of String))) As String()
        Dim union As New List(Of String)

        source = (From line As IEnumerable(Of String)
                  In source
                  Select (From s As String
                          In line
                          Select s
                          Distinct
                          Order By s Ascending).ToArray).ToArray

        For Each line As String() In source
            union += line
        Next

        union = (From s As String
                 In union
                 Select s
                 Distinct
                 Order By s Ascending).ToList  '获取并集，接下来需要从并集之中去除在两个集合之中都不存在的

        For Each Line As IEnumerable(Of String) In source
            For Each row In source       '遍历每一个集合
                Dim LQuery As IEnumerable(Of String) = From s As String
                                                       In row
                                                       Where Array.IndexOf(Line, s) = -1
                                                       Select s
                For Each s As String In LQuery
                    Call union.Remove(s) '假若line之中存在不存在的元素，则从并集之中移除
                Next
            Next
        Next

        Return union.ToArray
    End Function

    ''' <summary>
    ''' 求交集
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI("Intersection")>
    Public Function Intersection(ParamArray values As String()()) As String()
        Return values.Intersection
    End Function

    <ExportAPI("Matched?")>
    <Extension> Public Function Matches(str As String, regex As String) As Boolean
        Return RegularExpressions.Regex.Match(str, regex).Success
    End Function

    ''' <summary>
    ''' Searches the specified input string for the first occurrence of the specified regular expression.
    ''' </summary>
    ''' <param name="input">The string to search for a match.</param>
    ''' <param name="pattern">The regular expression pattern to match.</param>
    ''' <param name="options"></param>
    ''' <returns></returns>
    <ExportAPI("Regex", Info:="Searches the specified input string for the first occurrence of the specified regular expression.")>
    <Extension> Public Function Match(<Parameter("input", "The string to search for a match.")> input As String,
                                      <Parameter("Pattern", "The regular expression pattern to match.")> pattern As String,
                                      Optional options As RegexOptions = RegexOptions.Multiline) As String
        Return Regex.Match(input, pattern, options).Value
    End Function

    <ExportAPI("Match")>
    <Extension> Public Function Match(input As Match, pattern As String, Optional options As RegexOptions = RegexOptions.Multiline) As String
        Return Regex.Match(input.Value, pattern, options).Value
    End Function

    <Extension>
    <ExportAPI("Write.Dictionary")>
    Public Function SaveTo(dict As IDictionary(Of String, String), path As String) As Boolean
        Dim values As String() = dict.ToArray(Function(x) x.Key & vbTab & x.Value)
        Return values.SaveTo(path)
    End Function

    ''' <summary>
    ''' Count the string value numbers.(请注意，这个函数是倒序排序的)
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI("Tokens.Count", Info:="Count the string value numbers.")>
    <Extension> Public Function CountTokens(source As IEnumerable(Of String), Optional IgnoreCase As Boolean = False) As Dictionary(Of String, Integer)
        If Not IgnoreCase Then ' 大小写敏感
            Return (From s As String
                    In source
                    Select s
                    Group s By s Into Count) _
                         .ToDictionary(Function(x) x.s,
                                       Function(x) x.Count)
        End If

        Dim Uniques = (From s As String
                       In (From strValue As String In source Select strValue Distinct).ToArray
                       Let data As String = s
                       Select UNIQUE_KEY = s.ToLower, data
                       Group By UNIQUE_KEY Into Group).ToArray
        Dim ChunkList As List(Of KeyValuePair(Of String, Integer)) = New List(Of KeyValuePair(Of String, Integer))

        Dim LQuery = (From ustr In Uniques
                      Let s As String = ustr.UNIQUE_KEY
                      Let Count As Integer = (From str As String In source Where String.Equals(str, s, StringComparison.OrdinalIgnoreCase) Select 1).Count
                      Let original As String() = (From nn In ustr.Group Select nn.data).ToArray
                      Let key As String = original((ustr.Group.Count - 1) * Rnd())
                      Select key,
                          Count
                      Order By Count Descending) _
                              .ToDictionary(Function(x) x.key,
                                            Function(x) x.Count)
        Return LQuery
    End Function

    ''' <summary>
    ''' This method is used to replace most calls to the Java String.split method.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="regexDelimiter"></param>
    ''' <param name="trimTrailingEmptyStrings"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    <ExportAPI("StringsSplit", Info:="This method is used to replace most calls to the Java String.split method.")>
    <Extension> Public Function StringSplit(Source As String, RegexDelimiter As String, Optional TrimTrailingEmptyStrings As Boolean = False) As String()
        Dim splitArray As String() = Regex.Split(Source, RegexDelimiter)

        If Not TrimTrailingEmptyStrings OrElse splitArray.Length <= 1 Then Return splitArray

        For i As Integer = splitArray.Length To 1 Step -1

            If splitArray(i - 1).Length > 0 Then
                If i < splitArray.Length Then
                    Call Array.Resize(splitArray, i)
                End If

                Exit For
            End If
        Next

        Return splitArray
    End Function

    ''' <summary>
    ''' String collection tokens by a certain delimiter string element.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="delimiter">
    ''' Using String.Equals function to determined this delimiter 
    ''' </param>
    ''' <returns></returns>
    <Extension> Public Iterator Function Split(source As IEnumerable(Of String), delimiter As String) As IEnumerable(Of String())
        Dim list As New List(Of String)

        For Each line As String In source
            If String.Equals(delimiter, line, StringComparison.Ordinal) Then
                Yield list.ToArray
                Call list.Clear()
            Else
                Call list.Add(line)
            End If
        Next

        If list.Count > 0 Then
            Yield list.ToArray
        End If
    End Function

    ''' <summary>
    ''' String compares using <see cref="system.String.Equals"/>, if the target value could not be located, then -1 will be return from this function.
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <param name="Text"></param>
    ''' <param name="caseSensitive"></param>
    ''' <returns></returns>
    <ExportAPI("Located", Info:="String compares using String.Equals")>
    <Extension> Public Function Located(collection As IEnumerable(Of String), Text As String, Optional caseSensitive As Boolean = True) As Integer
        Dim Method = If(caseSensitive, StringComparison.Ordinal, StringComparison.OrdinalIgnoreCase)
        Dim Len As Integer = collection.Count - 1
        Dim array = collection.ToArray '为了保证性能的需要，这里的代码会比较复杂

        For i As Integer = 0 To Len
            If String.Equals(array(i), Text, Method) Then
                Return i
            End If
        Next

        Return -1
    End Function

    ''' <summary>
    ''' Search the string by keyword in a string collection. Unlike search function <see cref="StringHelpers.Located(IEnumerable(Of String), String, Boolean)"/>
    ''' using function <see cref="String.Equals"/> function to search string, this function using <see cref="Strings.InStr(String, String, CompareMethod)"/>
    ''' to search the keyword.
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="keyword"></param>
    ''' <param name="caseSensitive"></param>
    ''' <returns>返回第一个找到关键词的行数，没有找到则返回-1</returns>
    <ExportAPI("Lookup", Info:="Search the string by keyword in a string collection.")>
    <Extension>
    Public Function Lookup(source As IEnumerable(Of String), keyword As String, Optional caseSensitive As Boolean = True) As Integer
        Dim method As CompareMethod = If(caseSensitive, CompareMethod.Binary, CompareMethod.Text)
        Dim i As Integer

        For Each line As String In source
            If InStr(line, keyword, method) > 0 Then
                Return i
            Else
                i += 1
            End If
        Next

        Return -1
    End Function

    ''' <summary>
    ''' 判断目标字符串是否与字符串参数数组之中的任意一个字符串相等，大小写不敏感，假若没有相等的字符串，则会返回空字符串，假若找到了相等的字符串，则会返回该字符串
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="compareTo"></param>
    ''' <returns></returns>
    <Extension>
    <ExportAPI("Equals.Any")>
    Public Function EqualsAny(source As String, ParamArray compareTo As String()) As String
        Dim index As Integer = compareTo.Located(source, False)
        If index = -1 Then
            Return ""
        Else
            Return compareTo(index)
        End If
    End Function

    ''' <summary>
    ''' 查找到任意一个既返回位置，大小写不敏感，假若查找不到，则返回-1值，判断是否查找成功，可以使用 &lt;0 来完成，
    ''' 因为是通过InStr来完成的，所以查找成功的时候，最小的值是1，即字符串序列的第一个位置，也是元素0位置
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="find"></param>
    ''' <returns></returns>
    <ExportAPI("InStr.Any")>
    <Extension> Public Function InStrAny(source As String, ParamArray find As String()) As Integer
        For Each Token As String In find
            Dim idx As Integer = Strings.InStr(source, Token, CompareMethod.Text)
            If idx > 0 Then
                Return idx
            End If
        Next

        Return -1
    End Function

    ''' <summary>
    ''' Line tokens. ==> Parsing the text into lines by using <see cref="vbCr"/>, <see cref="vbLf"/>.
    ''' (函数对文本进行分行操作，由于在Windows(<see cref="VbCrLf"/>)和
    ''' Linux(<see cref="vbCr"/>, <see cref="vbLf"/>)平台上面所生成的文本文件的换行符有差异，
    ''' 所以可以使用这个函数来进行统一的分行操作)
    ''' </summary>
    ''' <param name="__text"></param>
    ''' <returns></returns>
    ''' <param name="trim">
    ''' Set <see cref="System.Boolean.FalseString"/> to avoid a reader bug in the csv data reader <see cref="BufferedStream"/>
    ''' </param>
    <ExportAPI("lTokens")>
    <Extension> Public Function lTokens(__text As String, Optional trim As Boolean = True) As String()
        If String.IsNullOrEmpty(__text) Then
            Return New String() {}
        End If

        Dim lf As Boolean = InStr(__text, vbLf) > 0
        Dim cr As Boolean = InStr(__text, vbCr) > 0

        If Not (cr OrElse lf) Then  ' 没有分行符，则只有一行
            Return New String() {__text}
        End If

        If lf AndAlso cr Then
            If trim Then  ' 假若将这个换行替换掉，在Csv文件读取模块会出现bug。。。。。不清楚是怎么回事
                __text = __text.Replace(vbCr, "")
            End If
            Return Text.Splitter.Split(__text, vbLf, True)
        End If

        If lf Then
            Return Text.Splitter.Split(__text, vbLf, True)
        End If

        Return Text.Splitter.Split(__text, vbCr, True)
    End Function

    ''' <summary>
    ''' 判断这个字符串集合是否为空集合，函数会首先按照常规的集合为空进行判断，然后假若不为空的话，假若只含有一个元素并且该唯一的元素的值为空字符串，则也认为这个字符串集合为空集合
    ''' </summary>
    ''' <param name="values"></param>
    ''' <param name="strict">FALSE 为非严谨，只进行常规判断，TRUE 为严谨模式，会假若不为空的话，假若只含有一个元素并且该唯一的元素的值为空字符串，则也认为这个字符串集合为空集合</param>
    ''' <returns></returns>
    <ExportAPI("IsNullOrEmpty")>
    Public Function IsNullOrEmpty(values As IEnumerable(Of String), Optional strict As Boolean = False) As Boolean
        If Not strict Then
            Return Extensions.IsNullOrEmpty(values)
        End If

        If values.IsNullOrEmpty Then
            Return True
        End If

        If values.Count = 1 AndAlso String.IsNullOrEmpty(values.First) Then
            Return True
        End If

        Return False
    End Function
End Module
