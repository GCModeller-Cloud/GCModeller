﻿#Region "Microsoft.VisualBasic::2883742c2c817197f632972ac6b98a4e, devenv\TabPages\NCBIViewer\InstallFastaDb.vb"

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

    ' Class InstallFastaDb
    ' 
    '     Constructor: (+2 Overloads) Sub New
    '     Sub: Button1_Click, CheckBox1_CheckedChanged, Install, LinkLabel2_LinkClicked, LoadUninstall
    '          Out2
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic

Public Class InstallFastaDb

    Dim Files As List(Of String)

    Public Sub LoadUninstall(Files As List(Of String))
        For Each File In Files
            Me.CheckedListBox1.Items.Add(String.Format("{0}  [{1}]", File.Replace("\", "/").Split(CChar("/")).Last.Split(CChar(".")).First, FileIO.FileSystem.GetFileInfo(File).Length))
        Next

        Me.Files = Files
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Sub New(Files As List(Of String))
        InitializeComponent()

        Call LoadUninstall(Files)

        AddHandler LinkLabel1.Click, Sub() Call Install()
    End Sub

    Sub Install()
        Out2(String.Format("Select {0} uninstalled database, start to install...", CheckedListBox1.CheckedIndices.Count))

        For Each i As Integer In CheckedListBox1.CheckedIndices
            Dim Process As Microsoft.VisualBasic.CommandLine.IORedirect
            Process = New Microsoft.VisualBasic.CommandLine.IORedirect(LocalBlast.c2, String.Format("build -i ""{0}"" -f fsa", Files(i)))

            AddHandler Process.DataArrival, Sub(s As String) Call Out2(s)
            AddHandler Process.ProcessExit, Sub(c As Integer, s As String) Out2(String.Format("Installation done!  c2 exit code = {0}, exitTime = {1}", c, s))

            Out2(String.Format("[{0}] Start to install database:{1}  {2}", i, vbCrLf, Files(i)))

            Process.Start(WaitForExit:=True)
        Next
    End Sub

    Private Sub Out2(s As String)
        Call Out(s, ConsoleColor.White, "C2", Microsoft.VisualBasic.Logging.MSG_TYPES.INF)
        TextBox1.AppendText(s & vbCrLf)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked)
        Next
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Call LocalBlast.InstallNewDB()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
