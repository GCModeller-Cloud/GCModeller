﻿#Region "Microsoft.VisualBasic::7084181b314ed199dab69445ddc1fa86, Data_science\Darwinism\NonlinearGrid\TopologyInference\GA\Environment.vb"

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

' Class Environment
' 
'     Properties: Cacheable
' 
'     Constructor: (+1 Overloads) Sub New
'     Function: Calculate
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.MachineLearning.Darwinism.GAF
Imports Microsoft.VisualBasic.MachineLearning.StoreProcedure
Imports Microsoft.VisualBasic.Math.LinearAlgebra

Public Structure TrainingSet

    Dim X As Vector
    Dim Y As Double
    Dim targetID As String

End Structure

Public Class Environment : Implements Fitness(Of Genome)

    Dim matrix As TrainingSet()
    Dim fitness As EvaluateFitness

    Public ReadOnly Property Cacheable As Boolean Implements Fitness(Of Genome).Cacheable
        Get
            Return False
        End Get
    End Property

    Sub New(trainingSet As IEnumerable(Of Sample), method As FitnessMethods)
        matrix = trainingSet _
            .Select(Function(sample)
                        Return New TrainingSet With {
                            .X = sample.status.vector.AsVector,
                            .Y = sample.target(Scan0),
                            .targetID = sample.target(Scan0).ToString
                        }
                    End Function) _
            .ToArray
        fitness = method.GetMethod
    End Sub

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function Calculate(chromosome As Genome) As Double Implements Fitness(Of Genome).Calculate
        Return fitness(chromosome, matrix)
    End Function
End Class
