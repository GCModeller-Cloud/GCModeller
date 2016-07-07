﻿#Region "Microsoft.VisualBasic::951b1efe70132d8b71a119d70f9f5f5e, ..\VisualBasic_AppFramework\Microsoft.VisualBasic.Architecture.Framework\Text\TextGrepScriptEngine.vb"

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

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.CommandLine
Imports System.Text.RegularExpressions

Imports TextGrepMethodTokenHandle = System.Collections.Generic.KeyValuePair(Of String(), Microsoft.VisualBasic.Text.TextGrepMethodToken)
Imports Microsoft.VisualBasic.Language

Namespace Text

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="source">文本源</param>
    ''' <param name="paras">脚本命令的参数</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function TextGrepMethodToken(source As String, paras As String()) As String
    Public Delegate Function TextGrepMethod(source As String) As String

    ''' <summary>
    ''' A script object for grep the gene id in the blast output query and subject title.(用于解析基因名称的脚本类，这个对象是在项目的初始阶段，为了方便命令行操作而设置的)
    ''' </summary>
    ''' <remarks></remarks>
    Public NotInheritable Class TextGrepScriptEngine

        Public Shared ReadOnly Property MethodsHash As IReadOnlyDictionary(Of String, TextGrepMethodToken) =
            New SortedDictionary(Of String, TextGrepMethodToken) From {
 _
            {"tokens", AddressOf TextGrepScriptEngine.Tokens},
            {"match", AddressOf TextGrepScriptEngine.Match},
            {"-", AddressOf TextGrepScriptEngine.NoOperation},
            {"replace", AddressOf TextGrepScriptEngine.Replace},
            {"mid", AddressOf TextGrepScriptEngine.MidString},
            {"reverse", AddressOf TextGrepScriptEngine.Reverse}
        }

        ''' <summary>
        ''' Source,Script,ReturnValue
        ''' </summary>
        ''' <remarks></remarks>
        Dim _Operations As TextGrepMethodTokenHandle()
        Dim _Script As String

        ''' <summary>
        ''' 对用户所输入的脚本进行编译，对于内部的空格，请使用单引号'进行分割
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ExportAPI("compile", Info:="", Usage:="script_tokens1;script_tokens2;....", Example:="")>
        Public Shared Function Compile(scriptText As String) As TextGrepScriptEngine
            Dim Script As String() = TryParse(scriptText, TokenDelimited:=";", InnerDelimited:="'"c)
            Dim OperationLQueryBuilder = (From sToken As String In Script
                                          Let tokens As String() = TryParse(sToken, TokenDelimited:=" ", InnerDelimited:="'"c)
                                          Let EntryPoint As String = sToken.Split.First.ToLower
                                          Where MethodsHash.ContainsKey(EntryPoint)
                                          Select New TextGrepMethodTokenHandle(tokens, _MethodsHash(EntryPoint))).ToArray
            If Script.Length > OperationLQueryBuilder.Length Then
                Return Nothing         ' 有非法的命令短语，则为了保护数据的一致性，这个含有错误的语法的脚本是不能够用于操作的，则函数返回空指针
            Else
                Return New TextGrepScriptEngine With {
                ._Script = scriptText,
                ._Operations = OperationLQueryBuilder
            }
            End If
        End Function

        ''' <summary>
        ''' 字符串剪裁操作的函数指针
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Method As TextGrepMethod
            Get
                Return AddressOf Me.Grep
            End Get
        End Property

        ''' <summary>
        ''' 修整目标字符串，按照脚本之中的方法取出所需要的字符串信息
        ''' </summary>
        ''' <param name="source"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Grep(Source As String) As String

            Dim InternalParser As Func(Of String, TextGrepMethodTokenHandle, Integer) =
            Function(sourceText As String, method As TextGrepMethodTokenHandle) As Integer
                Source = method.Value()(sourceText, method.Key) '迭代解析
                Return Len(Source)
            End Function

            Dim OperationInvokeLQuery As Integer() = (From operation As TextGrepMethodTokenHandle
                                                      In _Operations
                                                      Select InternalParser(Source, operation)).ToArray  '这里是迭代计算，所以请不要使用并行拓展
            Return Source
        End Function

        Public Overrides Function ToString() As String
            Return _Script
        End Function

        Protected Friend Sub New()
        End Sub

        <ExportAPI("-", Info:="DO_NOTHING")>
        Private Shared Function NoOperation(source As String, script As String()) As String
            Return source
        End Function

        <ExportAPI("Reverse")>
        Private Shared Function Reverse(source As String, Script As String()) As String
            Return source.Reverse.ToArray
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <param name="Script"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ExportAPI("Tokens", Info:="", Usage:="tokens p_str pointer", Example:="")>
        <ParameterInfo("pointer", False,
        Description:="pointer must be a zero base integer number which is smaller than the tokens array's length; pointer can also be assign of a specific string ""last"" to get the last element and ""first"" to get the first element in the tokens array.")>
        Private Shared Function Tokens(source As String, script As String()) As String
            Dim Delimiter As String = script(1)
            Dim Tstr As String() = Strings.Split(source, Delimiter)

            If String.Equals(script(2), "last", StringComparison.OrdinalIgnoreCase) Then
                Return If(Tstr.IsNullOrEmpty, "", Tstr.Last)
            Else
                Dim p As Integer = CInt(Val(script(2))) ' first指示符被计算为0，所以在这里不需要为first进行额外的处理

                If Tstr.Length - 1 < p OrElse p < 0 Then
                    Return ""
                Else
                    Return If(Tstr.IsNullOrEmpty, "", Tstr(p))
                End If
            End If
        End Function

        <ExportAPI("match", Info:="", Usage:="match pattern", Example:="")>
        Private Shared Function Match(source As String, script As String()) As String
            Dim Pattern As String = script.Last
            Return Regex.Match(source, Pattern).Value
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="ScriptTokens">向量之中的第一个元素为命令的名字，第二个元素为Mid函数的Start参数，第三个元素为Mid函数的Length参数，可以被忽略掉</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ExportAPI("mid", Info:="Substring a token from the input text source.")>
        Private Shared Function MidString(Source As String, ScriptTokens As String()) As String
            Dim Start As Integer = CInt(Val(ScriptTokens(1)))

            If ScriptTokens.Length > 2 Then
                Dim Length As Integer = CInt(Val(ScriptTokens(2)))
                Return Mid(Source, Start, Length)
            Else
                Return Mid(Source, Start)
            End If
        End Function

        <ExportAPI("replace", Usage:="replace <regx_text> <replace_value>")>
        Private Shared Function Replace(source As String, script As String()) As String
            Dim Regx As Regex = New Regex(script(1))
            Dim Matchs = Regx.Matches(source)
            Dim sBuilder As System.Text.StringBuilder = New System.Text.StringBuilder(source)
            Dim NewValue = script(2)
            For Each Value As Match In Matchs
                Call sBuilder.Replace(Value.Value, NewValue)
            Next

            Return sBuilder.ToString
        End Function
    End Class
End Namespace
