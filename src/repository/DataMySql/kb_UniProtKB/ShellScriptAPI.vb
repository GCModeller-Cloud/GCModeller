﻿#Region "Microsoft.VisualBasic::d5788607995b20ac2096fda7c7e46b0b, ..\repository\DataMySql\kb_UniProtKB\ShellScriptAPI.vb"

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

'#Region "Microsoft.VisualBasic::ae8467c73c9b19ae9d7debab80bc3150, ..\GCModeller\analysis\annoTools\DataMySql\UniprotSprot\ShellScriptAPI.vb"

'    ' Author:
'    ' 
'    '       asuka (amethyst.asuka@gcmodeller.org)
'    '       xieguigang (xie.guigang@live.com)
'    '       xie (genetics@smrucc.org)
'    ' 
'    ' Copyright (c) 2016 GPL3 Licensed
'    ' 
'    ' 
'    ' GNU GENERAL PUBLIC LICENSE (GPL3)
'    ' 
'    ' This program is free software: you can redistribute it and/or modify
'    ' it under the terms of the GNU General Public License as published by
'    ' the Free Software Foundation, either version 3 of the License, or
'    ' (at your option) any later version.
'    ' 
'    ' This program is distributed in the hope that it will be useful,
'    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
'    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    ' GNU General Public License for more details.
'    ' 
'    ' You should have received a copy of the GNU General Public License
'    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

'#End Region

'Imports Microsoft.VisualBasic.CommandLine.Reflection
'Imports SMRUCC.genomics.Data

'Namespace UniprotSprot

'    <[Namespace]("annotations.uniprot")>
'    Module UniprotShellScriptAPI

'        Sub New()
'            If Not Settings.Initialized Then
'                Call Settings.Initialize()
'            End If
'        End Sub

'        <ExportAPI("uniprot_sprot.install")>
'        Public Function InstallDatabase(UniprotSprot As String) As Model_Repository.Uniprot()
'            Return DbTools.InstallDatabase(UniprotSprot, Settings.SettingsFile.RepositoryRoot & "/UniprotSprot/")
'        End Function
'    End Module
'End Namespace

