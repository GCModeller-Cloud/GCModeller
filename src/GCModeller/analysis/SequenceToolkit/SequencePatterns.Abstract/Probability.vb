﻿#Region "Microsoft.VisualBasic::993f3dbec9c3075a22fdc1442b0bd53d, analysis\SequenceToolkit\SequencePatterns.Abstract\Probability.vb"

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

    ' Class Probability
    ' 
    '     Properties: pvalue, region, score
    ' 
    '     Function: patternString, ToString
    '     Structure Residue
    ' 
    '         Properties: frequency, index, isEmpty
    ' 
    '         Function: Max, ToString
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq

''' <summary>
''' The PWM model
''' </summary>
Public Class Probability

    Public Property region As Residue()
    Public Property pvalue As Double
    Public Property score As Double

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Overrides Function ToString() As String
        Return patternString() & $" @ {score}, pvalue={pvalue.ToString("G4")}"
    End Function

    Public Function patternString() As String
        Return region _
           .Select(Function(r) r.ToString) _
           .JoinBy("")
    End Function

    Public Structure Residue

        Public Property frequency As Dictionary(Of Char, Double)
        Public Property index As Integer

        Default Public ReadOnly Property getFrequency(base As Char) As Double
            Get
                Return _frequency(base)
            End Get
        End Property

        Public ReadOnly Property isEmpty As Boolean
            Get
                If frequency.IsNullOrEmpty Then
                    Return True
                ElseIf frequency.Values.All(Function(p) p = 0.0) Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overrides Function ToString() As String
            Dim max As Double = -99999
            Dim maxChar As Char

            For Each b In frequency
                If b.Value > max Then
                    max = b.Value
                    maxChar = b.Key
                End If
            Next

            If max >= 0.5 Then
                Return Char.ToUpper(maxChar)
            Else
                Return Char.ToLower(maxChar)
            End If
        End Function

        Public Shared Function Max(r As Residue) As Char
            With r.frequency.ToArray
                If .Values.All(Function(p) p = 0R) Then
                    Return "-"c
                Else
                    Return .ByRef(Which.Max(.Values)) _
                           .Key
                End If
            End With
        End Function
    End Structure
End Class
