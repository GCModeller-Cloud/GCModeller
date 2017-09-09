﻿#Region "Microsoft.VisualBasic::9e50b1a4d8f91494f84c18bc3f762715, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\CommandLine\CLITools.vb"

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

Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports StringList = System.Collections.Generic.IEnumerable(Of String)

Namespace CommandLine

    ''' <summary>
    ''' CLI parser and <see cref="CommandLine"/> object creates.
    ''' </summary>
    <Package("CommandLine",
                        Url:="http://gcmodeller.org",
                        Publisher:="xie.guigang@gcmodeller.org",
                        Description:="",
                        Revision:=52)>
    Public Module CLITools

        ''' <summary>
        ''' Parsing parameters from a specific tokens.
        ''' (从给定的词组之中解析出参数的结构)
        ''' </summary>
        ''' <param name="tokens">个数为偶数的，但是假若含有开关的时候，则可能为奇数了</param>
        ''' <param name="IncludeLogicSW">返回来的列表之中是否包含有逻辑开关</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Extension> Public Function CreateParameterValues(tokens$(),
                                                          IncludeLogicSW As Boolean,
                                                          Optional note$ = Nothing) As List(Of NamedValue(Of String))

            Dim list As New List(Of NamedValue(Of String))

            If tokens.IsNullOrEmpty Then
                Return list
            ElseIf tokens.Length = 1 Then

                If IsPossibleLogicFlag(tokens(Scan0)) AndAlso
                    IncludeLogicSW Then

                    list += New NamedValue(Of String)(tokens(Scan0), CStr(True), note)
                Else
                    Return list
                End If
            End If

            '下面都是多余或者等于两个元素的情况

            For i As Integer = 0 To tokens.Length - 1 '数目多于一个的

                Dim [Next] As Integer = i + 1

                If [Next] = tokens.Length Then  '这个元素是开关，已经到达最后则没有了，跳出循环
                    If IsPossibleLogicFlag(tokens(i)) AndAlso IncludeLogicSW Then
                        list += New NamedValue(Of String)(tokens(i), True, note)
                    End If

                    Exit For
                End If

                Dim s As String = tokens([Next])

                If IsPossibleLogicFlag(s) Then  '当前的这个元素是开关，下一个也是开关开头，则本元素肯定是一个开关
                    If IncludeLogicSW Then
                        list += New NamedValue(Of String)(tokens(i), True, note)
                    End If
                    Continue For
                Else  '下一个元素不是开关，则当前元素为一个参数名，则跳过下一个元素
                    Dim key As String = tokens(i).ToLower
                    list += New NamedValue(Of String)(key, s, note)

                    i += 1
                End If
            Next

            Return list
        End Function

        ''' <summary>
        ''' Get all of the logical parameters from the input tokens
        ''' </summary>
        ''' <param name="tokens">要求第一个对象不能够是命令的名称</param>
        ''' <returns></returns>
        <Extension> Public Function GetLogicalArguments(tokens$(), ByRef SingleValue$) As String()
            If tokens.IsNullOrEmpty Then
                Return New String() {}
            ElseIf tokens.Length = 1 Then  '只有一个元素，则肯定为开关
                Return {tokens(0)}
            End If

            Dim tkList As New List(Of String)

            For i As Integer = 0 To tokens.Length - 1 '数目多于一个的

                Dim [Next] As Integer = i + 1

                If [Next] = tokens.Length Then
                    If IsPossibleLogicFlag(obj:=tokens(i)) Then
                        tkList += tokens(i)  '
                    End If

                    Exit For
                End If

                Dim s As String = tokens([Next])

                If IsPossibleLogicFlag(obj:=s) Then  '当前的这个元素是开关，下一个也是开关开头，则本元素肯定是一个开关
                    If IsPossibleLogicFlag(obj:=tokens(i)) Then
                        tkList += tokens(i)
                    Else

                        If i = 0 Then
                            SingleValue = tokens(i)
                        End If

                    End If
                Else  '下一个元素不是开关，则当前元素为一个参数名，则跳过下一个元素
                    i += 1
                End If

            Next

            Return (From s As String In tkList Select s.ToLower).ToArray
        End Function

        ''' <summary>
        ''' Try parsing the cli command string from the string value.(尝试着从文本行之中解析出命令行参数信息)
        ''' </summary>
        ''' <param name="args">The commandline arguments which is user inputs from the terminal.</param>
        ''' <param name="DuplicatedAllowed">Allow the duplicated command parameter argument name in the input, 
        ''' default is not allowed the duplication.(是否允许有重复名称的参数名出现，默认是不允许的)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ExportAPI("TryParse", Info:="Try parsing the cli command String from the String value.")>
        Public Function TryParse(args As StringList, Optional DuplicatedAllowed As Boolean = False) As CommandLine
            Dim tokens$() = args.SafeQuery.ToArray
            Dim singleValue As String = ""

            If tokens.Length = 0 Then
                Return New CommandLine
            End If

            Dim CLI As New CommandLine With {
                .Name = tokens(Scan0).ToLower,
                .Tokens = tokens,
                .BoolFlags = tokens.Skip(1).ToArray.GetLogicalArguments(singleValue),
                ._CLICommandArgvs = Join(tokens)
            }

            CLI.SingleValue = SingleValue
            If CLI.Parameters.Length = 1 AndAlso
                String.IsNullOrEmpty(CLI.SingleValue) Then
                CLI.SingleValue = CLI.Parameters(0)
            End If

            If tokens.Length > 1 Then
                CLI.__arguments = tokens.Skip(1).ToArray.CreateParameterValues(False)

                Dim Dk As String() = __checkKeyDuplicated(CLI.__arguments)

                If Not DuplicatedAllowed AndAlso Not Dk.IsNullOrEmpty Then
                    Dim Key As String = String.Join(", ", Dk)
                    Dim msg As String = String.Format(EX_KEY_DUPLICATED, Key, String.Join(" ", tokens.Skip(1).ToArray))

                    Throw New Exception(msg)
                End If
            End If

            Return CLI
        End Function

        Const EX_KEY_DUPLICATED As String = "The command line switch key ""{0}"" Is already been added! Here Is your input data:  CMD {1}."

        Private Function __checkKeyDuplicated(source As IEnumerable(Of NamedValue(Of String))) As String()
            Dim LQuery = (From param As NamedValue(Of String)
                          In source
                          Select param.Name.ToLower
                          Group By ToLower Into Group).ToArray

            Return LinqAPI.Exec(Of String) <= From group
                                              In LQuery
                                              Where group.Group.Count > 1
                                              Select group.ToLower
        End Function

        ''' <summary>
        ''' Gets the commandline object for the current program.
        ''' </summary>
        ''' <returns></returns>
        <ExportAPI("args", Info:="Gets the commandline object for the current program.")>
        Public Function Args() As CommandLine
            Return App.CommandLine
        End Function

        ''' <summary>
        ''' Try parsing the cli command string from the string value.
        ''' (尝试着从文本行之中解析出命令行参数信息，假若value里面有空格，则必须要将value添加双引号)
        ''' </summary>
        ''' <param name="CLI">The commandline arguments which is user inputs from the terminal.</param>
        ''' <param name="duplicateAllowed">Allow the duplicated command parameter argument name in the input, 
        ''' default is not allowed the duplication.(是否允许有重复名称的参数名出现，默认是不允许的)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("TryParse", Info:="Try parsing the cli command String from the String value.")>
        Public Function TryParse(<Parameter("CLI", "The CLI arguments that inputs from the console by user.")> CLI$,
                                 <Parameter("Duplicates.Allowed")> Optional duplicateAllowed As Boolean = False) As CommandLine

            If String.IsNullOrEmpty(CLI) Then
                Return New CommandLine
            Else
#If DEBUG Then
                Call CLI.__DEBUG_ECHO
#End If
            End If

            Dim Tokens As String() = CLITools.GetTokens(CLI)
            Dim args As CommandLine = TryParse(Tokens, duplicateAllowed)
            args._CLICommandArgvs = CLI

            Return args
        End Function

        ''' <summary>
        ''' Is this string tokens is a possible <see cref="Boolean"/> value flag
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        <ExportAPI("IsPossibleBoolFlag?")>
        Public Function IsPossibleLogicFlag(obj As String) As Boolean
            If obj.Contains(" ") Then
                Return False
            End If
            If IsNumeric(obj) Then
                Return False
            End If
            If obj.Count("/"c) > 1 Then
                Return False ' Linux上面全路径总是从/，即根目录开始的
            End If

            Return obj.StartsWith("-") OrElse
                obj.StartsWith("/")
        End Function

        ''' <summary>
        ''' Is this token value string is a number?
        ''' </summary>
        ''' <param name="str"></param>
        ''' <returns></returns>
        <ExportAPI("IsNumeric", Info:="Is this token value string is a number?")>
        Public Function IsNumeric(str As String) As Boolean
            str = str.GetString("""")
            Dim s As String = Regex.Match(str, "[-]?\d*(\.\d+)?([eE][-]?\d*)?").Value
            Return String.Equals(str, s)
        End Function

        ''' <summary>
        ''' ReGenerate the cli command line argument string text.(重新生成命令行字符串)
        ''' </summary>
        ''' <param name="tokens">If the token value have a space character, then this function will be wrap that token with quot character automatically.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("Join",
                   Info:="ReGenerate the cli command line argument string text. 
                   NOTE: If the token have a space character, then this function will be wrap that token with quot character automatically.")>
        Public Function Join(tokens As IEnumerable(Of String)) As String
            If tokens.IsNullOrEmpty Then
                Return ""
            Else
                Return String.Join(" ", tokens.ToArray(AddressOf __innerWrapper))
            End If
        End Function

        Private Function __innerWrapper(Token As String) As String
            If InStr(Token, " ") > 0 Then

                If Token.First = """"c AndAlso Token.Last = """"c Then
                    Return Token
                Else
                    Return $"""{Token}"""
                End If
            Else
                Return Token
            End If
        End Function

        ''' <summary>
        ''' A regex expression string that use for split the commandline text.
        ''' (用于分析命令行字符串的正则表达式)
        ''' </summary>
        ''' <remarks></remarks>
        Public Const SPLIT_REGX_EXPRESSION As String = "\s+(?=(?:[^""]|""[^""]*"")*$)"
        Public Const QUOT As Char = """"c

        ''' <summary>
        ''' Try parse the argument tokens which comes from the user input commandline string. 
        ''' (尝试从用户输入的命令行字符串之中解析出所有的参数)
        ''' </summary>
        ''' <param name="CLI"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("Tokens")>
        Public Function GetTokens(CLI As String) As String()
            If String.IsNullOrEmpty(CLI) Then
                Return New String() {""}
            Else
                CLI = CLI.Trim
            End If

            ' 由于在前面App位置已经将应用程序的路径去除了，所以这里已经不需要了，只需要直接解析即可

            'If Not Environment.OSVersion.Platform = PlatformID.Win32NT Then
            '    'LINUX下面的命令行会将程序集的完整路径也传递进来
            '    Dim l As Integer = Len(Application.ExecutablePath)
            '    CLI = Mid(CLI, l + 2).Trim

            '    If String.IsNullOrEmpty(CLI) Then  '在linux下面没有传递进来任何参数，则返回空集合
            '        Return New String() {""}
            '    End If
            'End If

            Dim tokens$() = Regex.Split(CLI, SPLIT_REGX_EXPRESSION)
            tokens = tokens _
                .TakeWhile(Function(Token)
                               Return Not String.IsNullOrEmpty(Token.Trim)
                           End Function) _
                .ToArray

            For i As Integer = 0 To tokens.Length - 1
                Dim s As String = tokens(i)
                If s.First = QUOT AndAlso s.Last = QUOT Then    '消除单词单元中的双引号
                    tokens(i) = Mid(s, 2, Len(s) - 2)
                End If
            Next

            Return tokens
        End Function

        ''' <summary>
        ''' 会对%进行替换的
        ''' </summary>
        Const TokenSplitRegex As String = "(?=(?:[^%]|%[^%]*%)*$)"

        ''' <summary>
        ''' 尝试从输入的语句之中解析出词法单元，注意，这个函数不是处理从操作系统所传递进入的命令行语句
        ''' </summary>
        ''' <param name="CommandLine"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("TryParse")>
        Public Function TryParse(CommandLine As String, TokenDelimited As String, InnerDelimited As Char) As String()
            If String.IsNullOrEmpty(CommandLine) Then
                Return New String() {""}
            End If

            Dim RegxPattern As String = TokenDelimited & TokenSplitRegex.Replace("%"c, InnerDelimited)
            Dim Tokens = Regex.Split(CommandLine, RegxPattern)
            For i As Integer = 0 To Tokens.Length - 1
                Dim s As String = Tokens(i)
                If s.First = InnerDelimited AndAlso s.Last = InnerDelimited Then    '消除单词单元中的双引号
                    Tokens(i) = Mid(s, 2, Len(s) - 2)
                End If
            Next

            Return Tokens
        End Function

        ''' <summary>
        ''' Creates command line object from a set obj <see cref="KeyValuePair(Of String, String)"/>
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="args"></param>
        ''' <param name="bFlags"></param>
        ''' <returns></returns>
        <ExportAPI("CreateObject")>
        Public Function CreateObject(name$, args As IEnumerable(Of KeyValuePair(Of String, String)), Optional bFlags As IEnumerable(Of String) = Nothing) As CommandLine
            Dim parameters As New List(Of NamedValue(Of String))
            Dim Tokens As New List(Of String) From {name}

            For Each Item As KeyValuePair(Of String, String) In args
                Dim key As String = Item.Key.ToLower
                Dim param As New NamedValue(Of String)(key, Item.Value)
                Call parameters.Add(param)
                Call Tokens.AddRange(New String() {key, Item.Value})
            Next

            Return New CommandLine With {
                .Name = name,
                .__arguments = parameters,
                .Tokens = Tokens.Join(bFlags).ToArray,
                .BoolFlags = If(bFlags.IsNullOrEmpty, New String() {}, bFlags.ToArray)
            }
        End Function

        ''' <summary>
        ''' Trim the CLI argument name its prefix symbols.
        ''' (修剪命令行参数名称的前置符号)
        ''' </summary>
        ''' <param name="argName"></param>
        ''' <returns></returns>
        <ExportAPI("Trim.Prefix.BoolFlag")>
        <Extension>
        Public Function TrimParamPrefix(argName$) As String
            If argName.StartsWith("--") Then
                Return Mid(argName, 3)
            ElseIf argName.StartsWith("-") OrElse argName.StartsWith("\") OrElse argName.StartsWith("/") Then
                Return Mid(argName, 2)
            Else
                Return argName
            End If
        End Function

        ''' <summary>
        ''' 请注意，这个是有方向性的，由于是依照参数1来进行比较的，假若args2里面的参数要多于第一个参数，但是第一个参数里面的所有参数值都可以被参数2完全比对得上的话，就认为二者是相等的
        ''' </summary>
        ''' <param name="args1"></param>
        ''' <param name="args2"></param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("CLI.Equals")>
        Public Function Equals(args1 As CommandLine, args2 As CommandLine) As Boolean
            If Not String.Equals(args1.Name, args2.Name, StringComparison.OrdinalIgnoreCase) Then
                Return False
            End If

            For Each bFlag As String In args1.BoolFlags
                If Not args2.GetBoolean(bFlag) Then
                    Return False
                End If
            Next

            For Each arg As NamedValue(Of String) In args1.__arguments
                Dim value2 As String = args2(arg.Name)
                If Not String.Equals(value2, arg.Value, StringComparison.OrdinalIgnoreCase) Then
                    Return False
                End If
            Next

            Return True
        End Function

        <Extension>
        Public Function SingleValueOrStdIn(args As CommandLine) As String
            If Not String.IsNullOrEmpty(args.SingleValue) Then
                Return args.SingleValue
            Else
                Dim reader As New StreamReader(Console.OpenStandardInput)
                Return reader.ReadToEnd
            End If
        End Function
    End Module
End Namespace
