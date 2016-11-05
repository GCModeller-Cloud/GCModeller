﻿#Region "Microsoft.VisualBasic::3c68e94ebdd48db0de52bb477b771639, ..\visualbasic_App\Microsoft.VisualBasic.Architecture.Framework\Extensions\Math\StatisticsMathExtensions\EnumerableStatsMedian.vb"

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

Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.CompilerServices

Namespace Mathematical.StatisticsMathExtensions

    Public Module EnumerableStatsMedian
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Decimal values.
        '
        ' Parameters:
        '   source:
        '     A sequence of nullable System.Decimal values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        <Extension>
        Public Function Median(source As IEnumerable(Of System.Nullable(Of Decimal))) As System.Nullable(Of Decimal)
            Dim values As IEnumerable(Of Decimal) = source.Coalesce()

            If values.Any() Then
                Return values.Median()
            End If

            Return Nothing
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Decimal values.
        '
        ' Parameters:
        '   source:
        '     A sequence of System.Decimal values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        <Extension>
        Public Function Median(source As IEnumerable(Of Decimal)) As Decimal
            Dim sortedList = From number In source Order By number Select number

            Dim count As Integer = sortedList.Count()
            Dim itemIndex As Integer = count \ 2

            If count Mod 2 = 0 Then
                ' Even number of items.
                Return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2
            End If

            ' Odd number of items.
            Return sortedList.ElementAt(itemIndex)
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Double values.
        '
        ' Parameters:
        '   source:
        '     A sequence of nullable System.Double values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        <Extension>
        Public Function Median(source As IEnumerable(Of System.Nullable(Of Double))) As System.Nullable(Of Double)
            Dim values As IEnumerable(Of Double) = source.Coalesce()
            If values.Any() Then
                Return values.Median()
            End If

            Return Nothing
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Double values.
        '
        ' Parameters:
        '   source:
        '     A sequence of System.Double values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        <Extension>
        Public Function Median(source As IEnumerable(Of Double)) As Double
            Dim sortedList = From number In source Order By number Select number

            Dim count As Integer = sortedList.Count()
            Dim itemIndex As Integer = count \ 2

            If count Mod 2 = 0 Then
                ' Even number of items.
                Return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2
            End If

            ' Odd number of items.
            Return sortedList.ElementAt(itemIndex)
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Single values.
        '
        ' Parameters:
        '   source:
        '     A sequence of nullable System.Single values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        <Extension>
        Public Function Median(source As IEnumerable(Of System.Nullable(Of Single))) As System.Nullable(Of Single)
            Dim values As IEnumerable(Of Single) = source.Coalesce()
            If values.Any() Then
                Return values.Median()
            End If

            Return Nothing
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Single values.
        '
        ' Parameters:
        '   source:
        '     A sequence of System.Single values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        <Extension>
        Public Function Median(source As IEnumerable(Of Single)) As Single
            Dim sortedList = From number In source Order By number Select number

            Dim count As Integer = sortedList.Count()
            Dim itemIndex As Integer = count \ 2

            If count Mod 2 = 0 Then
                ' Even number of items.
                Return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2
            End If

            ' Odd number of items.
            Return sortedList.ElementAt(itemIndex)
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Int32 values.
        '
        ' Parameters:
        '   source:
        '     A sequence of nullable System.Int32values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        <Extension>
        Public Function Median(source As IEnumerable(Of System.Nullable(Of Integer))) As System.Nullable(Of Double)
            Dim values As IEnumerable(Of Integer) = source.Coalesce()
            If values.Any() Then
                Return values.Median()
            End If

            Return Nothing
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Int32 values.
        '
        ' Parameters:
        '   source:
        '     A sequence of System.Int32 values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        <Extension>
        Public Function Median(source As IEnumerable(Of Integer)) As Double
            Dim sortedList = From number In source Order By number Select CDbl(number)

            Dim count As Integer = sortedList.Count()
            Dim itemIndex As Integer = count \ 2

            If count Mod 2 = 0 Then
                ' Even number of items.
                Return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2
            End If

            ' Odd number of items.
            Return sortedList.ElementAt(itemIndex)
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Int64 values.
        '
        ' Parameters:
        '   source:
        '     A sequence of nullable System.Int64 values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        <Extension>
        Public Function Median(source As IEnumerable(Of System.Nullable(Of Long))) As System.Nullable(Of Double)
            Dim values As IEnumerable(Of Long) = source.Coalesce()
            If values.Any() Then
                Return values.Median()
            End If

            Return Nothing
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Int64 values.
        '
        ' Parameters:
        '   source:
        '     A sequence of System.Int64 values to calculate the Median of.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        <Extension>
        Public Function Median(source As IEnumerable(Of Long)) As Double
            Dim sortedList = From number In source Order By number Select CDbl(number)

            Dim count As Integer = sortedList.Count()
            Dim itemIndex As Integer = count \ 2

            If count Mod 2 = 0 Then
                ' Even number of items.
                Return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2
            End If

            ' Odd number of items.
            Return sortedList.ElementAt(itemIndex)
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Decimal values that
        '     are obtained by invoking a transform function on each element of the input
        '     sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, System.Nullable(Of Decimal))) As System.Nullable(Of Decimal)
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Decimal values that are obtained
        '     by invoking a transform function on each element of the input sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values that are used to calculate an Median.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Decimal.MaxValue.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Decimal)) As Decimal
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Double values that
        '     are obtained by invoking a transform function on each element of the input
        '     sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, System.Nullable(Of Double))) As System.Nullable(Of Double)
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Double values that are obtained
        '     by invoking a transform function on each element of the input sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Double)) As Double
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Single values that
        '     are obtained by invoking a transform function on each element of the input
        '     sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, System.Nullable(Of Single))) As System.Nullable(Of Single)
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Single values that are obtained
        '     by invoking a transform function on each element of the input sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Single)) As Single
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Int32 values that are
        '     obtained by invoking a transform function on each element of the input sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, System.Nullable(Of Integer))) As System.Nullable(Of Double)
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Int32 values that are obtained
        '     by invoking a transform function on each element of the input sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Integer)) As Double
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of nullable System.Int64 values that are
        '     obtained by invoking a transform function on each element of the input sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values, or null if the source sequence is
        '     empty or contains only values that are null.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, System.Nullable(Of Long))) As System.Nullable(Of Double)
            Return source.[Select](selector).Median()
        End Function
        '
        ' Summary:
        '     Computes the Median of a sequence of System.Int64 values that are obtained
        '     by invoking a transform function on each element of the input sequence.
        '
        ' Parameters:
        '   source:
        '     A sequence of values to calculate the Median of.
        '
        '   selector:
        '     A transform function to apply to each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        ' Returns:
        '     The Median of the sequence of values.
        '
        ' Exceptions:
        '   System.ArgumentNullException:
        '     source or selector is null.
        '
        '   System.InvalidOperationException:
        '     source contains no elements.
        '
        '   System.OverflowException:
        '     The sum of the elements in the sequence is larger than System.Int64.MaxValue.
        <Extension>
        Public Function Median(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Long)) As Double
            Return source.[Select](selector).Median()
        End Function
    End Module
End Namespace