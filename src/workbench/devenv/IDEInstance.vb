﻿#Region "Microsoft.VisualBasic::6dd245a2bf3e4c38167da092e191056a, ..\workbench\devenv\IDEInstance.vb"

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

''' <summary>
''' 本对象是传递进入插件模块之中的用于存储本IDE程序内所有对外开放的对象的容器
''' </summary>
''' <remarks></remarks>
Public Class IDEInstance

    ''' <summary>
    ''' IDE的配置数据文件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Settings As Settings.Programs.IDE
        Get
            Return Program.Dev2Profile
        End Get
    End Property

    Public ReadOnly Property IDE As FormMain
        Get
            Return Program.IDE
        End Get
    End Property

    Public Sub Out(s As String, Optional Color As ConsoleColor = ConsoleColor.White,
        Optional [Object] As String = Strings.Modeller,
        Optional Type As Microsoft.VisualBasic.Logging.MSG_TYPES = Microsoft.VisualBasic.Logging.MSG_TYPES.INF)
        Call Program.Out(s, Color, [Object], Type)
    End Sub

    Public Sub IDEStatueText(s As String, Optional Color As Drawing.Color = Nothing)
        Call Program.IDEStatueText(s, Color)
    End Sub
End Class
