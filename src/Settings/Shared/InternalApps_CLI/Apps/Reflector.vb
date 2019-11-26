﻿Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.InteropService
Imports Microsoft.VisualBasic.ApplicationServices

' Microsoft VisualBasic CommandLine Code AutoGenerator
' assembly: ..\bin\Reflector.exe

' 
'  // 
'  // SMRUCC genomics GCModeller Programs Profiles Manager
'  // 
'  // VERSION:   3.3277.7268.38152
'  // ASSEMBLY:  Settings, Version=3.3277.7268.38152, Culture=neutral, PublicKeyToken=null
'  // COPYRIGHT: Copyright © SMRUCC genomics. 2014
'  // GUID:      a554d5f5-a2aa-46d6-8bbb-f7df46dbbe27
'  // BUILT:     11/24/2019 8:47:12 AM
'  // 
' 
' 
' 
' 
' SYNOPSIS
' Settings command [/argument argument-value...] [/@set environment-variable=value...]
' 
' All of the command that available in this program has been list below:
' 
'  /union:              Union all of the sql file in the target directory into a one big sql text file.
' 
' 
' API list that with functional grouping
' 
' 1. MySQL documentation tool
' 
' 
'    /MySQL.Markdown:     Generates the SDK document of your mysql database.
' 
' 
' 2. MySQL ORM code solution tool
' 
' 
'    --export.dump:       Scans for the table schema sql files in a directory and converts these sql file
'                         as visualbasic source code.
'    --reflects:          Automatically generates visualbasic source code from the MySQL database schema
'                         dump.
' 
' 
' ----------------------------------------------------------------------------------------------------
' 
'    1. You can using "Settings ??<commandName>" for getting more details command help.
'    2. Using command "Settings /CLI.dev [---echo]" for CLI pipeline development.
'    3. Using command "Settings /i" for enter interactive console mode.

Namespace GCModellerApps


''' <summary>
'''
''' </summary>
'''
Public Class Reflector : Inherits InteropService

    Public Const App$ = "Reflector.exe"

    Sub New(App$)
        MyBase._executableAssembly = App$
    End Sub

     <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Shared Function FromEnvironment(directory As String) As Reflector
          Return New Reflector(App:=directory & "/" & Reflector.App)
     End Function

''' <summary>
''' ```bash
''' /MySQL.Markdown /sql &lt;database.sql/std_in&gt; [/toc /out &lt;out.md/std_out&gt;]
''' ```
''' Generates the SDK document of your mysql database.
''' </summary>
'''
Public Function MySQLMarkdown(sql As String, Optional out As String = "", Optional toc As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/MySQL.Markdown")
    Call CLI.Append(" ")
    Call CLI.Append("/sql " & """" & sql & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If toc Then
        Call CLI.Append("/toc ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /union /in &lt;directory&gt; [/out &lt;out.sql&gt;]
''' ```
''' Union all of the sql file in the target directory into a one big sql text file.
''' </summary>
'''
Public Function [Union]([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/union")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --export.dump [-o &lt;out_dir&gt; /namespace &lt;namespace&gt; --dir &lt;source_dir&gt;]
''' ```
''' Scans for the table schema sql files in a directory and converts these sql file as visualbasic source code.
''' </summary>
'''
Public Function ExportDumpDir(Optional o As String = "", Optional [namespace] As String = "", Optional dir As String = "") As Integer
    Dim CLI As New StringBuilder("--export.dump")
    Call CLI.Append(" ")
    If Not o.StringEmpty Then
            Call CLI.Append("-o " & """" & o & """ ")
    End If
    If Not [namespace].StringEmpty Then
            Call CLI.Append("/namespace " & """" & [namespace] & """ ")
    End If
    If Not dir.StringEmpty Then
            Call CLI.Append("--dir " & """" & dir & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --reflects /sql &lt;sql_path/std_in&gt; [-o &lt;output_path&gt; /namespace &lt;namespace&gt; --language &lt;php/visualbasic, default=visualbasic&gt; /split]
''' ```
''' Automatically generates visualbasic source code from the MySQL database schema dump.
''' </summary>
'''
Public Function ReflectsConvert(sql As String, Optional o As String = "", Optional [namespace] As String = "", Optional language As String = "visualbasic", Optional split As Boolean = False) As Integer
    Dim CLI As New StringBuilder("--reflects")
    Call CLI.Append(" ")
    Call CLI.Append("/sql " & """" & sql & """ ")
    If Not o.StringEmpty Then
            Call CLI.Append("-o " & """" & o & """ ")
    End If
    If Not [namespace].StringEmpty Then
            Call CLI.Append("/namespace " & """" & [namespace] & """ ")
    End If
    If Not language.StringEmpty Then
            Call CLI.Append("--language " & """" & language & """ ")
    End If
    If split Then
        Call CLI.Append("/split ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function
End Class
End Namespace
