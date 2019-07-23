﻿#Region "Microsoft.VisualBasic::679f37232d839b0731209665afe32b3b, ApplicationServices\Debugger\Exception\ExceptionData.vb"

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

'     Class ExceptionData
' 
'         Properties: Message, StackTrace, TypeFullName
' 
'         Function: CreateInstance, GetCurrentStackTrace, ToString
' 
'     Class StackFrame
' 
'         Properties: File, Line, Method
' 
'         Function: Parser, ToString
' 
'     Class Method
' 
'         Properties: [Module], [Namespace], Method
' 
'         Constructor: (+1 Overloads) Sub New
'         Function: ToString
' 
' 
' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Text

Namespace ApplicationServices.Debugging.Diagnostics

    Public Class ExceptionData

        Public Property TypeFullName As String
        Public Property Message As String()
        Public Property StackTrace As StackFrame()

        ''' <summary>
        ''' Create exception object for throw exception expression
        ''' </summary>
        ''' <returns></returns>
        Public Function Exception() As Exception
            Return New Exception(Message.JoinBy(ASCII.LF)) With {
                .Source = StackTrace.JoinBy(ASCII.LF)
            }
        End Function

        Public Overrides Function ToString() As String
            Return TypeFullName
        End Function

        Public Shared Function CreateFromObject(ex As Exception) As ExceptionData
            Return New ExceptionData With {
                .Message = ex.Message.LineTokens,
                .TypeFullName = ex.GetType.FullName,
                .StackTrace = ParseStackTrace(ex.StackTrace)
            }
        End Function

        Public Shared Function CreateInstance(messages$(), stackTrace$(), type$) As ExceptionData
            Return New ExceptionData With {
                .TypeFullName = type,
                .Message = messages,
                .StackTrace = stackTrace _
                    .Select(AddressOf StackFrame.Parser) _
                    .ToArray
            }
        End Function

        Public Shared Function ParseStackTrace(stackTrace As String) As StackFrame()
            Return stackTrace _
                .LineTokens _
                .Where(Function(s) Not s.StringEmpty) _
                .Skip(3) _
                .Select(Function(s)
                            s = Mid(s, 6).Trim
                            Return StackFrame.Parser(s)
                        End Function) _
                .ToArray
        End Function

        ''' <summary>
        ''' Parsing <see cref="Environment.StackTrace"/>, gets current stack trace information.
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetCurrentStackTrace() As StackFrame()
            Return ParseStackTrace(Environment.StackTrace)
        End Function
    End Class
End Namespace
