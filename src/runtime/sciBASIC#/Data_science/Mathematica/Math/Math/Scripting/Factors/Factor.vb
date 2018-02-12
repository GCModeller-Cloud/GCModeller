﻿#Region "Microsoft.VisualBasic::26727e2f455de79829db004f5e78d17e, Data_science\Mathematica\Math\Math\Scripting\Factors\Factor.vb"

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

    '     Class Factor
    ' 
    '         Properties: FactorValue
    ' 
    '         Function: ToString
    ' 
    '         Sub: (+2 Overloads) New
    ' 
    '     Class Factors
    ' 
    '         Function: GetFactors
    ' 
    '         Sub: New
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Language

Namespace Scripting

    ''' <summary>
    ''' R language like string factor
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public Class Factor(Of T As IComparable(Of T)) : Inherits float
        Implements Value(Of T).IValueOf

        Public Property FactorValue As T Implements Value(Of T).IValueOf.Value

        Sub New()
        End Sub

        Sub New(value As T, factor#)
            Me.Value = factor
            Me.FactorValue = value
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overrides Function ToString() As String
            Return FactorValue.ToString
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overloads Shared Narrowing Operator CType(factor As Factor(Of T)) As T
            Return factor.FactorValue
        End Operator
    End Class

    Public Class Factors(Of T As IComparable(Of T)) : Inherits Index(Of T)

        Sub New(ParamArray list As T())
            Call MyBase.New(list)
        End Sub

        Public Iterator Function GetFactors() As IEnumerable(Of Factor(Of T))
            For Each i In MyBase.Map
                Yield New Factor(Of T) With {
                    .FactorValue = i.Key,
                    .Value = i.Value
                }
            Next
        End Function
    End Class
End Namespace
