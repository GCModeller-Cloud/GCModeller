﻿#Region "Microsoft.VisualBasic::4d7eb389619c7bbfb795477151a3444b, vcellkit\Debugger\Debugger.vb"

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

' Module Debugger
' 
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Text.Xml.HtmlBuilder
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Core
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Engine
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Engine.Definitions
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Engine.ModelLoader
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Model

<Package("vcellkit.debugger", Category:=APICategories.ResearchTools)>
Module Debugger

    <ExportAPI("vcell.summary")>
    Public Sub createDynamicsSummary(inits As Definition, model As CellularModule, dir As String)
        ' do initialize of the virtual cell engine
        ' and then load virtual cell model into 
        ' engine kernel
        Dim loader As Loader = Nothing
        Dim vcell As Vessel = New Engine(
                def:=inits,
                dynamics:=New FluxBaseline,
                iterations:=0,
                showProgress:=False
            ) _
            .LoadModel(model, getLoader:=loader) _
            .getCore
        Dim fluxIndex = loader.GetFluxIndex
        Dim channels As Dictionary(Of String, Channel) = vcell.Channels.ToDictionary(Function(r) r.ID)

        For Each region In fluxIndex
            Call channels _
                .Takes(region.Value) _
                .summaryReport(region.Key) _
                .SaveTo($"{dir}/{region.Key}.html")
        Next
    End Sub

    <Extension>
    Private Function summaryReport(reactions As IEnumerable(Of Channel), regionName$) As String
        Dim summaryList As New List(Of String)

        For Each reaction As Channel In reactions
            summaryList.Add(reaction.summaryOf)
        Next

        Return sprintf(<html>
                           <head>
                               <title><%= regionName %></title>
                           </head>
                           <body>
                               <h1><%= regionName %></h1>
                               <hr/>

                               <div>%s</div>
                           </body>
                       </html>, summaryList.JoinBy(vbCrLf))
    End Function

    <Extension>
    Private Function summaryOf(rxn As Channel) As String

    End Function
End Module
