﻿#Region "Microsoft.VisualBasic::5140a0510ea203e3e27533184a0d1f0f, Microsoft.VisualBasic.Core\Scripting\ScriptBuilder.vb"

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

    '     Class ScriptBuilder
    ' 
    '         Properties: Preview, Script
    ' 
    '         Function: AppendLine, Replace, (+2 Overloads) Save, ToString
    ' 
    '         Sub: (+4 Overloads) New
    ' 
    '         Operators: +
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Text

Namespace Scripting.SymbolBuilder

    ''' <summary>
    ''' 对<see cref="StringBuilder"/>对象的拓展，添加了操作符凭借字符串，从而能够让生成代码的操作更加的方便
    ''' </summary>
    Public Class ScriptBuilder : Implements ISaveHandle

        Public ReadOnly Property Script As StringBuilder

        ''' <summary>
        ''' The variable in target script text should be in format like: ``{$name}``
        ''' </summary>
        ''' <param name="name"></param>
        Default Public WriteOnly Property Assign(name As String) As String
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Set
                Call Script.Replace($"{{${name}}}", Value)
            End Set
        End Property

        ''' <summary>
        ''' Equals to <see cref="StringBuilder.ToString()"/>
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Preview As String
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return Script.ToString
            End Get
        End Property

        Sub New(sb As StringBuilder)
            Script = sb
        End Sub

        Sub New(capacity As Integer)
            Script = New StringBuilder(capacity)
        End Sub

        Sub New()
            Call Me.New(capacity:=1024)
        End Sub

        Sub New(script$)
            Call Me.New(New StringBuilder(script))
        End Sub

        Public Function Replace(key$, value$) As ScriptBuilder
            Call Script.Replace(key, value)
            Return Me
        End Function

        ''' <summary>
        ''' Display the string text in the <see cref="StringBuilder"/> object.
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Return Script.ToString
        End Function

        ''' <summary>
        ''' Appends a copy of the specified string followed by the default line terminator
        ''' to the end of the current <see cref="ScriptBuilder"/> object.
        ''' </summary>
        ''' <param name="line$">The string to append.</param>
        ''' <returns>A reference to this instance after the append operation has completed.</returns>
        Public Function AppendLine(Optional line$ = "") As ScriptBuilder
            Call Script.AppendLine(line)
            Return Me
        End Function

        ''' <summary>
        ''' <see cref="StringBuilder.ToString()"/>
        ''' </summary>
        ''' <param name="sb"></param>
        ''' <returns></returns>
        Public Shared Narrowing Operator CType(sb As ScriptBuilder) As String
            Return sb.Script.ToString
        End Operator

        ''' <summary>
        ''' <see cref="StringBuilder.Append"/>
        ''' </summary>
        ''' <param name="sb"></param>
        ''' <param name="s"></param>
        ''' <returns></returns>
        Public Shared Operator &(sb As ScriptBuilder, s As String) As ScriptBuilder
            Call sb.Script.Append(s)
            Return sb
        End Operator

        ''' <summary>
        ''' <see cref="StringBuilder.AppendLine"/>
        ''' </summary>
        ''' <param name="sb"></param>
        ''' <param name="s"></param>
        ''' <returns></returns>
        Public Shared Operator +(sb As ScriptBuilder, s As String) As ScriptBuilder
            Call sb.Script.AppendLine(s)
            Return sb
        End Operator

        Public Function Save(Optional path As String = "", Optional encoding As Encoding = Nothing) As Boolean Implements ISaveHandle.Save
            Return Script.ToString.SaveTo(path, encoding)
        End Function

        Public Function Save(Optional path As String = "", Optional encoding As Encodings = Encodings.UTF8) As Boolean Implements ISaveHandle.Save
            Return Script.ToString.SaveTo(path, encoding.CodePage)
        End Function
    End Class
End Namespace
