﻿Imports System.ComponentModel
Imports Microsoft.VisualBasic.DataVisualization.Network.Canvas
Imports SMRUCC.genomics.Analysis.SSystem
Imports SMRUCC.genomics.Analysis.SSystem.Script

Public Class FormCanvas

    Dim WithEvents canvas As New Canvas
    Dim engine As Engine

    Private Sub FormCanvas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Controls.Add(canvas)
        canvas.Dock = DockStyle.Fill
        canvas.AutoRotate = False
        canvas.ShowLabel = True
        engine = New Engine(canvas)
    End Sub

    Private Sub LoadPLASScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadPLASScriptToolStripMenuItem.Click
        Using open As New OpenFileDialog With {.Filter = "Script text file(*.txt;*.plas)|*.txt;*.plas"}
            If open.ShowDialog = DialogResult.OK Then
                Dim model As Script.Model = Script.ScriptCompiler.Compile(open.FileName)
                engine.RunModel(model)
            End If
        End Using
    End Sub

    Private Sub LoadMetaCycSBMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadMetaCycSBMLToolStripMenuItem.Click
        Using open As New OpenFileDialog With {.Filter = "SBML(*.xml;*.sbml)|*.xml;*.sbml"}
            If open.ShowDialog = DialogResult.OK Then
                Dim model As Script.Model = SBML.Compile(open.FileName)
                engine.RunModel(model)
            End If
        End Using
    End Sub

    Private Sub FormCanvas_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        engine.dispose
        canvas.Dispose()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        canvas.ViewDistance = TrackBar1.Value
    End Sub
End Class