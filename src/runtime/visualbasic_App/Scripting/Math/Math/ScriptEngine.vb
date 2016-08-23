﻿#Region "Microsoft.VisualBasic::c3adae39788d3fb7b8d5f6c03c22f0f0, ..\visualbasic_App\Scripting\Math\Math\ScriptEngine.vb"

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

Public Module ScriptEngine

    ''' <summary>
    ''' The default expression engine.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Expression As Expression =
        Mathematical.Expression.DefaultEngine

    ''' <summary>
    ''' all of the commands are stored at here
    ''' </summary>
    ''' <remarks>
    ''' .quit for do nothing and end of this program.
    ''' </remarks>
    Public ReadOnly Property StatementEngine As Dictionary(Of String, Action(Of String)) =
        New Dictionary(Of String, Action(Of String)) From {
            {"const", AddressOf Expression.Constant.Add},
            {"function", AddressOf Expression.Functions.Add},
            {"func", AddressOf Expression.Functions.Add},
            {"var", AddressOf Expression.Variables.Set},
            {".quit", Sub(NULL As String) NULL = Nothing}}

    Public ReadOnly Property Scripts As New Hashtable

    Public Function Shell(statement As String) As String
        Dim Token As String = statement.Split.First.ToLower

        If InStr(statement, "<-") Then  'This is a value assignment statement
            Call Expression.Variables.AssignValue(statement)
            Return String.Empty
        End If

        If StatementEngine.ContainsKey(Token) Then
            Call StatementEngine(Token)(Mid(statement, Len(Token) + 1).Trim)
            Return String.Empty
        Else  'if the statement input from the user is not appears in the engine dictionary, then maybe is a mathematics expression. 
            Dim Result As Double = Expression.Evaluate(statement)
            Expression.Variables.Set("$", Result)  'You can treat the variable 'last' as a system variable for return the result of a multiple function script in the future of this feature will add to this module.

            Return Result
        End If
    End Function

    ''' <summary>
    ''' Set variable value
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="expr"></param>
    Public Sub SetVariable(Name As String, expr As String)
        Call Expression.Variables.Set(Name, expr)
    End Sub

    ''' <summary>
    ''' Add constant object
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="expr"></param>
    Public Sub AddConstant(Name As String, expr As String)
        Call Expression.Constant.Add(Name, expr)
    End Sub
End Module
