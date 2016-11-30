﻿#Region "Microsoft.VisualBasic::f283fa779b7d780e9d5dd7ea25b47efd, ..\sciBASIC#\Microsoft.VisualBasic.Architecture.Framework\Scripting\Casting.vb"

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

Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Text

Namespace Scripting

    ''' <summary>
    ''' Methods for convert the <see cref="System.String"/> to some .NET data types.
    ''' </summary>
    Public Module Casting

        ''' <summary>
        ''' DirectCast(obj, T)
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        <Extension> Public Function [As](Of T)(obj) As T
            If obj Is Nothing Then
                Return Nothing
            End If
            Return DirectCast(obj, T)
        End Function

        ''' <summary>
        ''' Will processing value NaN automatically and strip for the comma.
        ''' </summary>
        ''' <param name="s"></param>
        ''' <returns></returns>
        Public Function ParseNumeric(s As String) As Double
            If String.IsNullOrEmpty(s) Then
                Return 0R
            ElseIf String.Equals(s, "NaN", StringComparison.Ordinal) Then
                Return Double.NaN
            End If
            s = s.Replace(",", "")
            If s.Last = "%"c Then
                Return Conversion.Val(Mid(s, 1, s.Length - 1)) / 100  ' 百分比
            Else
                Return Conversion.Val(s)
            End If
        End Function

        Public Function CastChar(obj As String) As Char
            Return If(String.IsNullOrEmpty(obj), ASCII.NUL, obj.First)
        End Function

        ''' <summary>
        ''' 出错会返回默认是0
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        Public Function CastInteger(obj As String) As Integer
            Return CInt(ParseNumeric(obj))
        End Function

        Public Function CastLong(obj As String) As Long
            Return CLng(ParseNumeric(obj))
        End Function

        Public Function CastCharArray(obj As String) As Char()
            Return obj.ToArray
        End Function

        Public Function CastDate(obj As String) As DateTime
            Return DateTime.Parse(obj)
        End Function

        Public Function CastStringBuilder(obj As String) As StringBuilder
            Return New StringBuilder(obj)
        End Function

        ''' <summary>
        ''' <see cref="CommandLine.TryParse"/>
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        Public Function CastCommandLine(obj As String) As CommandLine.CommandLine
            Return CommandLine.TryParse(obj)
        End Function

        ''' <summary>
        ''' <see cref="LoadImage"/>
        ''' </summary>
        ''' <param name="path"></param>
        ''' <returns></returns>
        Public Function CastImage(path As String) As Image
            Return LoadImage(path)
        End Function

        Public Function CastFileInfo(path As String) As FileInfo
            Return FileIO.FileSystem.GetFileInfo(path)
        End Function

        Public Function CastGDIPlusDeviceHandle(path As String) As GDIPlusDeviceHandle
            Return GDIPlusDeviceHandleFromImageFile(path)
        End Function

        Public Function CastFont(face As String) As Font
            Return New Font(face, 10)
        End Function

        Public Function CastIPEndPoint(addr As String) As System.Net.IPEndPoint
            Return New Net.IPEndPoint(addr).GetIPEndPoint
        End Function

        Public Function CastLogFile(path As String) As Logging.LogFile
            Return New Logging.LogFile(path)
        End Function

        Public Function CastProcess(exe As String) As Process
            Return Process.Start(exe)
        End Function

        Public Function CastSingle(n As String) As Single
            Return CSng(ParseNumeric(n))
        End Function

        Public Function CastRegexOptions(name As String) As RegexOptions
            If String.Equals(name, RegexExtensions.NameOf.Compiled, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.Compiled
            ElseIf String.Equals(name, RegexExtensions.NameOf.CultureInvariant, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.CultureInvariant
            ElseIf String.Equals(name, RegexExtensions.NameOf.ECMAScript, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.ECMAScript
            ElseIf String.Equals(name, RegexExtensions.NameOf.ExplicitCapture, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.ExplicitCapture
            ElseIf String.Equals(name, RegexExtensions.NameOf.IgnoreCase, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.IgnoreCase
            ElseIf String.Equals(name, RegexExtensions.NameOf.IgnorePatternWhitespace, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.IgnorePatternWhitespace
            ElseIf String.Equals(name, RegexExtensions.NameOf.Multiline, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.Multiline
            ElseIf String.Equals(name, RegexExtensions.NameOf.RightToLeft, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.RightToLeft
            ElseIf String.Equals(name, RegexExtensions.NameOf.Singleline, StringComparison.OrdinalIgnoreCase) Then
                Return RegexOptions.Singleline
            Else
                Return RegexOptions.None
            End If
        End Function
    End Module
End Namespace
