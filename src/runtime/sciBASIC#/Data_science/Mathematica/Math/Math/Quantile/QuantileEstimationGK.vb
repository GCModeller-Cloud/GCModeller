﻿#Region "Microsoft.VisualBasic::03e76218133e6625d786c5afd72b0cc0, Data_science\Mathematica\Math\Math\Quantile\QuantileEstimationGK.vb"

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

    '     Class QuantileEstimationGK
    ' 
    '         Function: Query, ToString
    ' 
    '         Sub: compress, (+2 Overloads) Insert, New
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Text
Imports Microsoft.VisualBasic.Serialization.JSON
Imports sys = System.Math

'
'   Copyright 2012 Andrew Wang (andrew@umbrant.com)
'
'   Licensed under the Apache License, Version 2.0 (the "License");
'   you may not use this file except in compliance with the License.
'   You may obtain a copy of the License at
'
'       http://www.apache.org/licenses/LICENSE-2.0
'
'   Unless required by applicable law or agreed to in writing, software
'   distributed under the License is distributed on an "AS IS" BASIS,
'   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'   See the License for the specific language governing permissions and
'   limitations under the License.
'

Namespace Quantile

    ''' <summary>
    ''' Implementation of the Greenwald and Khanna algorithm for streaming
    ''' calculation of epsilon-approximate quantiles.
    ''' 
    ''' See: 
    ''' 
    ''' > Greenwald and Khanna, "Space-efficient online computation of quantile summaries" in SIGMOD 2001
    ''' </summary>
    Public Class QuantileEstimationGK

        ''' <summary>
        ''' Acceptable % error in percentile estimate
        ''' </summary>
        ReadOnly epsilon As Double
        ''' <summary>
        ''' Total number of items in stream
        ''' </summary>
        Dim count As Integer = 0
        ''' <summary>
        ''' Threshold to trigger a compaction
        ''' </summary>
        ReadOnly compact_size As Integer

        ''' <summary>
        ''' Implementation of the Greenwald and Khanna algorithm for streaming
        ''' calculation of epsilon-approximate quantiles.
        ''' </summary>
        ''' <param name="epsilon">Acceptable % error in percentile estimate</param>
        ''' <param name="compact_size">Threshold to trigger a compaction</param>
        Public Sub New(epsilon#, compact_size%, Optional data As IEnumerable(Of Double) = Nothing)
            Me.compact_size = compact_size
            Me.epsilon = epsilon

            If Not data Is Nothing Then
                For Each x As Double In data
                    Call Insert(x)
                Next
            End If
        End Sub

        Dim sample As New List(Of X)

        Public Overrides Function ToString() As String
            Return seq(0, 1, 0.1) _
                .ToDictionary(Function(pct) (100 * pct).ToString("F2") & "%",
                              Function(pct) Query(pct).ToString("F2")) _
                .GetJson
        End Function

        Public Sub Insert(v&)
            Call Insert(CDbl(v))
        End Sub

        Public Sub Insert(v#)
            Dim idx As Integer = 0

            For Each i As X In sample
                If i.value > v Then Exit For
                idx += 1
            Next

            Dim delta As Integer

            If idx = 0 OrElse idx = sample.Count Then
                delta = 0
            Else
                delta = CInt(Fix(sys.Floor(2 * epsilon * count)))
            End If

            Call sample.Insert(idx, New X(v, 1, delta))

            If sample.Count > compact_size Then
                ' printList()
                compress()
                ' printList()
            End If

            Me.count += 1
        End Sub

        Private Sub compress()
            Dim removed As Integer = 0

            For i As Integer = 0 To sample.Count - 2
                If i = sample.Count OrElse i + 1 = sample.Count Then
                    Exit For
                End If

                Dim x As X = sample(i)
                Dim x1 As X = sample(i + 1)

                ' Merge the items together if we don't need it to maintain the
                ' error bound
                If x.g + x1.g + x1.delta <= sys.Floor(2 * epsilon * count) Then
                    x1.g += x.g
                    sample.RemoveAt(i)
                    removed += 1
                End If
            Next
        End Sub

        ''' <summary>
        ''' 使用数量百分比来获取得到对应的阈值，<paramref name="quantile"/>为0-1之间的百分比值
        ''' </summary>
        ''' <param name="quantile#">0-1之间的百分比值</param>
        ''' <returns>阈值</returns>
        Public Function Query(quantile#) As Double
            Dim rankMin As Integer = 0
            Dim desired As Integer = CInt(Fix(quantile * count))

            For i As Integer = 1 To sample.Count - 1
                Dim prev As X = sample(i - 1)
                Dim cur As X = sample(i)

                rankMin += prev.g

                If rankMin + cur.g + cur.delta > desired + (2 * epsilon * count) Then
                    Return prev.value
                End If
            Next

            ' edge case of wanting max value
            Return sample(sample.Count - 1).value
        End Function
    End Class
End Namespace
