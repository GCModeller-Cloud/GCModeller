﻿#Region "Microsoft.VisualBasic::e293feae61f009fb199588008ad07d00, Data_science\MachineLearning\MachineLearning\SVM\SVMExtensions.vb"

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

    '     Module SVMExtensions
    ' 
    '         Function: ComputeHashcode, ComputeHashcode2, (+4 Overloads) IsEqual, Truncate
    ' 
    '         Sub: SwapIndex
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports stdNum = System.Math

Namespace SVM

    <HideModuleName>
    Friend Module SVMExtensions

        Private Const PRECISION As Double = 1000000.0

        <Extension()>
        Public Function Truncate(ByVal x As Double) As Double
            Return stdNum.Round(x * PRECISION) / PRECISION
        End Function

        <Extension()>
        Public Sub SwapIndex(Of T)(ByVal list As T(), ByVal i As Integer, ByVal j As Integer)
            Dim tmp = list(i)
            list(i) = list(j)
            list(j) = tmp
        End Sub

        <Extension()>
        Public Function IsEqual(Of T)(ByVal lhs As T()(), ByVal rhs As T()()) As Boolean
            If lhs.Length <> rhs.Length Then Return False

            For i = 0 To lhs.Length - 1
                If Not lhs(i).IsEqual(rhs(i)) Then Return False
            Next

            Return True
        End Function

        <Extension()>
        Public Function IsEqual(Of T)(ByVal lhs As T(), ByVal rhs As T()) As Boolean
            If lhs.Length <> rhs.Length Then Return False

            For i = 0 To lhs.Length - 1
                If Not lhs(i).Equals(rhs(i)) Then Return False
            Next

            Return True
        End Function

        <Extension()>
        Public Function IsEqual(ByVal lhs As Double(), ByVal rhs As Double()) As Boolean
            If lhs.Length <> rhs.Length Then Return False

            For i = 0 To lhs.Length - 1
                Dim x As Double = lhs(i).Truncate()
                Dim y As Double = rhs(i).Truncate()
                If x <> y Then Return False
            Next

            Return True
        End Function

        <Extension()>
        Public Function IsEqual(ByVal lhs As Double()(), ByVal rhs As Double()()) As Boolean
            If lhs.Length <> rhs.Length Then Return False

            For i = 0 To lhs.Length - 1
                If Not lhs(i).IsEqual(rhs(i)) Then Return False
            Next

            Return True
        End Function

        <Extension()>
        Friend Function ComputeHashcode(Of T)(ByVal array As T()) As Integer
            Return array.Sum(Function(o) o.GetHashCode())
        End Function

        <Extension()>
        Friend Function ComputeHashcode2(Of T)(ByVal array As T()()) As Integer
            Return array.Sum(Function(o) o.ComputeHashcode())
        End Function
    End Module
End Namespace

