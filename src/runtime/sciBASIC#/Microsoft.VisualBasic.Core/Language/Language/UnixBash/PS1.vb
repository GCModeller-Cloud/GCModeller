﻿#Region "Microsoft.VisualBasic::634dbe616b698b47e77bc25d42608aa9, Microsoft.VisualBasic.Core\Language\Language\UnixBash\PS1.vb"

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

    '     Class PS1
    ' 
    '         Function: A, d, Fedora12, n, r
    '                   T, tl, ToString, u, v
    '                   W, wl
    ' 
    '         Sub: (+2 Overloads) New
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ApplicationServices

Namespace Language.UnixBash

    ''' <summary>
    ''' PS (Prompt Sign)
    ''' </summary>
    Public Class PS1 : Inherits BaseClass

        ''' <summary>
        ''' ``\H`` 完整的主机名称
        ''' </summary>
        Shared ReadOnly H As String
        ''' <summary>
        ''' ``\h`` 仅取主机名称的第一个名字
        ''' </summary>
        Shared ReadOnly hl As String

        Shared Sub New()
            H = Environment.MachineName
            If H Is Nothing Then
                H = ""
            End If
            hl = H.Split("."c).FirstOrDefault
            If hl Is Nothing Then
                hl = ""
            End If
        End Sub

        ReadOnly __ps1 As Func(Of String)

        Const ps_regx As String = "\\[dHhtTAuvwW#$]"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ps1"></param>
        ''' <remarks>
        ''' Example as:
        ''' 
        ''' ```vbnet
        ''' ' Fedora 12
        ''' PS1='[\u@\h \w \A #\#]\$ '
        ''' ```
        ''' </remarks>
        Sub New(ps1 As String)
            ps1 = ps1.Replace("\\", "\/")

            Dim ms As String() = Regex.Matches(ps1, ps_regx).ToArray

            ps1 = ps1.Replace("\/", "\")

            __ps1 = Function() As String
                        Dim sb As New StringBuilder(ps1)

                        For Each s As String In ms
                            Call sb.Replace(s, __pss(s)())
                        Next

                        Return sb.ToString
                    End Function
        End Sub

        ''' <summary>
        ''' Fedora 12 PS1 variable of the bash shell: ``[\u@\h \w \A #\#]\$ ``
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function Fedora12() As PS1
            Return New PS1("[\u@\h \w \A #\#]\$ ")
        End Function

        ReadOnly __pss As Dictionary(Of String, Func(Of String)) =
            New Dictionary(Of String, Func(Of String)) From {
 _
                {"\d", AddressOf d},
                {"\H", Function() H},
                {"\h", Function() hl},
                {"\t", AddressOf tl},
                {"\T", AddressOf T},
                {"\A", AddressOf A},
                {"\u", AddressOf u},
                {"\v", AddressOf v},
                {"\w", AddressOf wl},
                {"\W", AddressOf W},
                {"\#", AddressOf n},
                {"\$", AddressOf r}
            }

        ''' <summary>
        ''' Display the commandline prompt.
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Return __ps1()
        End Function

        Dim __n As Integer

        ''' <summary>
        ''' ``\#`` 下达的第几个指令。
        ''' </summary>
        ''' <returns></returns>
        Public Function n() As String
            __n += 1
            Return __n.ToString
        End Function

        ''' <summary>
        ''' ``\$`` 提示字符，如果是``root``时，提示字符为``#``，否则就是``$``。
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function r() As String
            Dim wk As String = FileIO.FileSystem.CurrentDirectory
            If String.Equals(wk, "/") OrElse String.Equals(wk, "C:\", StringComparison.OrdinalIgnoreCase) Then
                Return "#"
            Else
                Return "$"
            End If
        End Function

        ''' <summary>
        ''' ``\T`` 显示时间, 12 小时的时间格式!
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function T() As String
            Dim dt As Date = Now
            Return $"{dt.Hour}:{dt.Minute}:{dt.Second}"
        End Function

        ''' <summary>
        ''' ``\t`` 显示时间, 为 24 小时格式, 如: ``HH:MM:SS``
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function tl() As String
            Dim dt As Date = Now
            Return $"{dt.Hour}:{dt.Minute}:{dt.Second}"
        End Function

        ''' <summary>
        ''' ``\A`` 显示时间, 24小时格式: ``HH:MM``
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function A() As String
            Dim dt As Date = Now
            Return $"{dt.Hour}:{dt.Minute}"
        End Function

        ''' <summary>
        ''' ``\u`` 目前使用者的账号名称
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function u() As String
            Return Environment.UserName
        End Function

        Shared ReadOnly __version As String = ApplicationDetails.GetProductVersion(GetType(PS1).Assembly)

        ''' <summary>
        ''' ``\v`` ``BASH``的版本信息
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function v() As String
            Return __version
        End Function

        ''' <summary>
        ''' ``\w`` 完整的工作目录名称。家目录会以``~``取代
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function wl() As String
            Return FileIO.FileSystem.CurrentDirectory
        End Function

        ''' <summary>
        ''' ``\W`` 利用``<see cref="basename"/>``取得工作目录名称，所以仅会列出最后一个目录名。
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function W() As String
            Return FileIO.FileSystem.CurrentDirectory.BaseName
        End Function

        ''' <summary>
        ''' ``\d`` 代表日期, 格式为``Weekday Month Date``, 例如``Mon Aug 1``
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function d() As String
            Dim dt As Date = Now
            Dim w As String = WeekdayName(Weekday(dt), FirstDayOfWeekValue:=FirstDayOfWeek.Sunday)
            Dim m As String = MonthName(dt.Month)
            Return $"{w} {m} {dt.Day}"
        End Function
    End Class
End Namespace
