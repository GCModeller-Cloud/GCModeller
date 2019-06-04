﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Math.Correlations

''' <summary>
''' Protocol module to produce enterotype clusters
''' </summary>
Public Module Enterotype

    ''' <summary>
    ''' First, the abundances of classified genera are used to produce a JSD matrix between samples.
    ''' </summary>
    ''' <param name="abundances"></param>
    ''' <returns>A JSD correlation matrix between samples.</returns>
    <Extension>
    Public Iterator Function JSD(abundances As IEnumerable(Of DataSet)) As IEnumerable(Of DataSet)
        Dim matrix As DataSet() = abundances.ToArray
        Dim taxonomy As String() = matrix.PropertyNames
        Dim jsdMatrix = From sample As DataSet
                        In matrix.AsParallel
                        Let P As Double() = sample(taxonomy)
                        Let jsdi As Dictionary(Of String, Double) = matrix.ToDictionary(
                            Function(another) another.ID,
                            Function(another)
                                Dim Q As Double() = another(taxonomy)
                                Return Correlations.JSD(P, Q)
                            End Function)
                        Select New DataSet With {
                            .ID = sample.ID,
                            .Properties = jsdi
                        }

        For Each sample As DataSet In jsdMatrix
            Yield sample
        Next
    End Function
End Module
