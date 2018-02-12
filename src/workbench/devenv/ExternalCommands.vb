﻿#Region "Microsoft.VisualBasic::c95c5f884df712132d695d7b9656757f, devenv\ExternalCommands.vb"

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

    ' Module ExternalCommands
    ' 
    '     Sub: Build
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ConsoleDevice.STDIO

Module ExternalCommands

    Private ReadOnly Reengineering As String = My.Application.Info.DirectoryPath & "/c2.exe"

    Public Sub Build(File As String, SaveFile As String)
        Dim FileFormat As String
        If String.Equals(System.IO.Path.GetExtension(File), ".gbk") Then
            FileFormat = "-f gbk"
        Else
            FileFormat = "-f fsa"
        End If
        Dim Arguments As String = String.Format("build -i ""{0}"" -o ""{1}"" {2} -p T", File, SaveFile, FileFormat)
        Out(String.Format("Start external command to build a fasta sequence database:{0}{1}", vbCrLf,
                          String.Format("{0} {1}", Reengineering, Arguments)), ConsoleColor.Green, "LocalBLAST")
        Call Microsoft.VisualBasic.Interaction.Shell(Format("%s %s", Reengineering, Arguments))
    End Sub
End Module
