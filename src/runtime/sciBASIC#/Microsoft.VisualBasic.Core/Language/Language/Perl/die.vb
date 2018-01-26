﻿#Region "Microsoft.VisualBasic::3baf0fa2864e286cb6e73df3c71a75c9, ..\sciBASIC#\Microsoft.VisualBasic.Core\Language\Language\Perl\die.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
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

Imports Microsoft.VisualBasic.Emit.Delegates
Imports Microsoft.VisualBasic.Language.Default
Imports Microsoft.VisualBasic.Linq

Namespace Language.Perl

    Public Structure ExceptionHandler

        Dim Message$
        Dim failure As Assert(Of Object)

        ''' <summary>
        ''' Returns True means test failure
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        Public Shared Function [Default](obj As Object) As Boolean
            If obj Is Nothing Then
                Return True
            End If

            With obj.GetType

                If .ref Is GetType(Boolean) Then
                    Return False = DirectCast(obj, Boolean)

                    ' 对于字符串而言，判断是否为空的标准则是看字符串是否为空或者空字符串
                ElseIf .ref Is GetType(String) Then
                    Return String.IsNullOrEmpty(DirectCast(obj, String))

                ElseIf .IsInheritsFrom(GetType(Array)) Then
                    Return DirectCast(obj, Array).Length = 0

                ElseIf .ImplementInterface(GetType(IEnumerable)) Then
                    Return DirectCast(obj, IEnumerable).ToArray(Of Object).Length = 0

                ElseIf .ImplementInterface(GetType(IsEmpty)) Then
                    Return DirectCast(obj, IsEmpty).IsEmpty

                ElseIf .ref Is GetType(TimeSpan) Then
                    Return DirectCast(obj, TimeSpan) = TimeSpan.Zero

                Else
                    Return False ' False表示没有错误
                End If
            End With
        End Function

        ''' <summary>
        ''' Perl like exception handler syntax for testing the result is failure or not?
        ''' </summary>
        ''' <param name="result"></param>
        ''' <param name="h"></param>
        ''' <returns></returns>
        Public Shared Operator Or(result As Object, h As ExceptionHandler) As Object
            If h.failure(result) Then
                Throw New Exception(h.Message)
            Else
                Return result
            End If
        End Operator
    End Structure
End Namespace
