﻿#Region "Microsoft.VisualBasic::ec240826c20e533620defc129b57953f, ..\VisualBasic_AppFramework\Microsoft.VisualBasic.Architecture.Framework\Language\Linq.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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

Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language.LinqAPIHelpers
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Parallel.Linq
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Language

    ''' <summary>
    ''' Language syntax extension for the Linq expression in VisualBasic language
    ''' </summary>
    Public Module LinqAPI

        ''' <summary>
        ''' Initializes a new instance of the <see cref="List"/>`1 class that
        ''' contains elements copied from the specified collection and has sufficient capacity
        ''' to accommodate the number of elements copied.
        ''' </summary>
        Public Function MakeList(Of T)() As ListHelper(Of T)
            Return New ListHelper(Of T)
        End Function

        ''' <summary>
        ''' Execute a linq expression. Creates an array from a <see cref="IEnumerable(Of T)"/>.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <returns>An array that contains the elements from the input sequence.</returns>
        Public Function Exec(Of T)() As ExecHelper(Of T)
            Return New ExecHelper(Of T)
        End Function

        Public Function DefaultFirst(Of T)(Optional [default] As T = Nothing) As FirstOrDefaultHelper(Of T)
            Return New FirstOrDefaultHelper(Of T)([default])
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <typeparam name="T">Is the type of linq source</typeparam>
        ''' <typeparam name="V">Is the type of value output</typeparam>
        ''' <param name="source"></param>
        ''' <returns></returns>
        Public Function Exec(Of T, V)(source As IEnumerable(Of T)) As ToArrayHelper(Of T, V)
            Return New ToArrayHelper(Of T, V)(source)
        End Function

        Public Function BuildHash(Of T, V, [In])(keys As Func(Of [In], T), values As Func(Of [In], V)) As BuildHashHelper(Of T, V, [In])
            Return New BuildHashHelper(Of T, V, [In])(keys, values)
        End Function

        Public Function BuildHash(Of T, [In])(keys As Func(Of [In], T)) As BuildHashHelper(Of T, [In], [In])
            Return New BuildHashHelper(Of T, [In], [In])(keys, Function(x) x)
        End Function

        Public Function BuildHash(Of T As sIdEnumerable)() As BuildHashHelper(Of String, T, T)
            Return New BuildHashHelper(Of String, T, T)(Function(x) x.Identifier, Function(x) x)
        End Function

        Public Function Takes(Of T)(n As Integer) As TakeHelper(Of T)
            Return New TakeHelper(Of T)(n)
        End Function

        Public Function LQuery(Of T, out)(task As Func(Of T, out), Optional partTokens As Integer = 20000) As LQueryHelper(Of T, out)
            Return New LQueryHelper(Of T, out) With {
                .task = task,
                .partTokens = partTokens
            }
        End Function
    End Module

    Namespace LinqAPIHelpers

        Public Structure LQueryHelper(Of T, out)

            Dim task As Func(Of T, out)
            Dim partTokens As Integer

            Public Overloads Shared Operator <=(helper As LQueryHelper(Of T, out), source As IEnumerable(Of T)) As out()
                Return LQuerySchedule.LQuery(source, helper.task, 20000000, helper.partTokens).ToArray
            End Operator

            Public Overloads Shared Operator >=(helper As LQueryHelper(Of T, out), source As IEnumerable(Of T)) As out()
                Throw New NotSupportedException
            End Operator

            Public Overloads Shared Operator <=(helper As LQueryHelper(Of T, out), source As IEnumerable(Of IEnumerable(Of T))) As out()
                Return helper <= source.MatrixAsIterator
            End Operator

            Public Overloads Shared Operator >=(helper As LQueryHelper(Of T, out), source As IEnumerable(Of IEnumerable(Of T))) As out()
                Throw New NotSupportedException
            End Operator
        End Structure

        Public Structure TakeHelper(Of T)

            Public ReadOnly Property n As Integer

            Sub New(n As Integer)
                Me.n = n
            End Sub

            Public Overrides Function ToString() As String
                Return Me.GetJson
            End Function

            Public Overloads Shared Operator <=(num As TakeHelper(Of T), source As IEnumerable(Of T)) As IEnumerable(Of T)
                Return source.Take(num.n)
            End Operator

            Public Overloads Shared Operator >=(num As TakeHelper(Of T), source As IEnumerable(Of T)) As IEnumerable(Of T)
                Throw New NotSupportedException
            End Operator
        End Structure

        ' Summary:
        '     Creates a System.Collections.Generic.Dictionary`2 from an System.Collections.Generic.IEnumerable`1
        '     according to specified key selector and element selector functions.
        '
        ' Parameters:
        '   source:
        '     An System.Collections.Generic.IEnumerable`1 to create a System.Collections.Generic.Dictionary`2
        '     from.
        '
        '   keySelector:
        '     A function to extract a key from each element.
        '
        '   elementSelector:
        '     A transform function to produce a result element value from each element.
        '
        ' Type parameters:
        '   TSource:
        '     The type of the elements of source.
        '
        '   TKey:
        '     The type of the key returned by keySelector.
        '
        '   TElement:
        '     The type of the value returned by elementSelector.
        '
        ' Returns:
        '     A System.Collections.Generic.Dictionary`2 that contains values of type TElement
        '     selected from the input sequence.
        '
        ' Exceptions:
        '   T:System.ArgumentNullException:
        '     source or keySelector or elementSelector is null.-or-keySelector produces a key
        '     that is null.
        '
        '   T:System.ArgumentException:
        '     keySelector produces duplicate keys for two elements.
        Public Structure BuildHashHelper(Of T, V, [In])

            ReadOnly __keys As Func(Of [In], T)
            ReadOnly __values As Func(Of [In], V)

            Sub New(k As Func(Of [In], T), v As Func(Of [In], V))
                __keys = k
                __values = v
            End Sub

            Public Shared Operator <=(cls As BuildHashHelper(Of T, V, [In]), linq As IEnumerable(Of [In])) As Dictionary(Of T, V)
                Return linq.ToDictionary(cls.__keys, cls.__values)
            End Operator

            Public Shared Operator >=(cls As BuildHashHelper(Of T, V, [In]), linq As IEnumerable(Of [In])) As Dictionary(Of T, V)
                Throw New NotSupportedException
            End Operator
        End Structure

        Public Structure ListHelper(Of T)

            ''' <summary>
            ''' Initializes a new instance of the <see cref="List"/>`1 class that
            ''' contains elements copied from the specified collection and has sufficient capacity
            ''' to accommodate the number of elements copied.
            ''' </summary>
            ''' <param name="linq">The collection whose elements are copied to the new list.</param>
            ''' <returns></returns>
            Public Shared Operator <=(cls As ListHelper(Of T), linq As IEnumerable(Of T)) As List(Of T)
                Return linq.ToList
            End Operator

            Public Shared Operator >=(cls As ListHelper(Of T), linq As IEnumerable(Of T)) As List(Of T)
                Throw New NotSupportedException
            End Operator

            ''' <summary>
            ''' Initializes a new instance of the <see cref="List"/>`1 class that
            ''' contains elements copied from the specified collection and has sufficient capacity
            ''' to accommodate the number of elements copied.
            ''' </summary>
            ''' <param name="linq">The collection whose elements are copied to the new list.</param>
            ''' <returns></returns>
            Public Shared Operator <=(cls As ListHelper(Of T), linq As IEnumerable(Of IEnumerable(Of T))) As List(Of T)
                Return linq.MatrixToList
            End Operator

            Public Shared Operator >=(cls As ListHelper(Of T), linq As IEnumerable(Of IEnumerable(Of T))) As List(Of T)
                Throw New NotSupportedException
            End Operator

            ''' <summary>
            ''' Initializes a new instance of the <see cref="List"/>`1 class that
            ''' contains elements copied from the specified collection and has sufficient capacity
            ''' to accommodate the number of elements copied.
            ''' </summary>
            ''' <param name="linq">The collection whose elements are copied to the new list.</param>
            ''' <returns></returns>
            Public Shared Operator <=(cls As ListHelper(Of T), linq As IEnumerable(Of IEnumerable(Of IEnumerable(Of T)))) As List(Of T)
                Return linq.MatrixAsIterator.MatrixToList
            End Operator

            Public Shared Operator >=(cls As ListHelper(Of T), linq As IEnumerable(Of IEnumerable(Of IEnumerable(Of T)))) As List(Of T)
                Throw New NotSupportedException
            End Operator
        End Structure

        ''' <summary>
        ''' Execute a linq expression. Creates an array from a <see cref="System.Collections.Generic.IEnumerable(Of T)"/>.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        Public Structure ExecHelper(Of T)

            ''' <summary>
            ''' Creates an array from a <see cref="System.Collections.Generic.IEnumerable(Of T)"/>.
            ''' </summary>
            ''' <param name="cls"></param>
            ''' <param name="linq">
            ''' An <see cref="System.Collections.Generic.IEnumerable(Of T)"/> to create an array from.
            ''' </param>
            ''' <returns>An array that contains the elements from the input sequence.</returns>
            Public Shared Operator <=(cls As ExecHelper(Of T), linq As IEnumerable(Of T)) As T()
                Return linq.ToArray
            End Operator

            Public Shared Operator >=(cls As ExecHelper(Of T), linq As IEnumerable(Of T)) As T()
                Throw New NotSupportedException
            End Operator

            ''' <summary>
            ''' Creates an array from a <see cref="System.Collections.Generic.IEnumerable(Of T)"/>.
            ''' </summary>
            ''' <param name="cls"></param>
            ''' <param name="linq">
            ''' An <see cref="System.Collections.Generic.IEnumerable(Of T)"/> to create an array from.
            ''' </param>
            ''' <returns>An array that contains the elements from the input sequence.</returns>
            Public Shared Operator <=(cls As ExecHelper(Of T), linq As IEnumerable(Of IEnumerable(Of T))) As T()
                Return linq.MatrixToVector
            End Operator

            Public Shared Operator >=(cls As ExecHelper(Of T), linq As IEnumerable(Of IEnumerable(Of T))) As T()
                Throw New NotSupportedException
            End Operator
        End Structure

        Public Structure FirstOrDefaultHelper(Of T)

            ReadOnly __default As T

            Sub New(__default As T)
                Me.__default = __default
            End Sub

            ''' <summary>
            ''' Exec ToArray
            ''' </summary>
            ''' <param name="cls"></param>
            ''' <param name="linq"></param>
            ''' <returns></returns>
            Public Shared Operator <=(cls As FirstOrDefaultHelper(Of T), linq As IEnumerable(Of T)) As T
                Return linq.DefaultFirst(cls.__default)
            End Operator

            Public Shared Operator >=(cls As FirstOrDefaultHelper(Of T), linq As IEnumerable(Of T)) As T
                Throw New NotSupportedException
            End Operator
        End Structure

        ''' <summary>
        ''' Execute a linq expression. Creates an array from a <see cref="System.Collections.Generic.IEnumerable(Of T)"/>.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        Public Structure ToArrayHelper(Of T, V)

            Private __source As IEnumerable(Of T)

            Sub New(source As IEnumerable(Of T))
                __source = source
            End Sub

            ''' <summary>
            ''' Exec ToArray
            ''' </summary>
            ''' <param name="cls"></param>
            ''' <param name="linq"></param>
            ''' <returns></returns>
            Public Shared Operator <=(cls As ToArrayHelper(Of T, V), linq As Func(Of T, V)) As V()
                Return (From x As T In cls.__source Select linq(x)).ToArray
            End Operator

            Public Shared Operator >=(cls As ToArrayHelper(Of T, V), linq As Func(Of T, V)) As V()
                Throw New NotSupportedException
            End Operator

            ''' <summary>
            ''' Exec ToArray
            ''' </summary>
            ''' <param name="cls"></param>
            ''' <param name="linq"></param>
            ''' <returns></returns>
            Public Shared Operator <=(cls As ToArrayHelper(Of T, V), linq As Func(Of T, Integer, V)) As V()
                Return (From x As SeqValue(Of T)
                    In cls.__source.SeqIterator
                        Select linq(x.obj, x.i)).ToArray
            End Operator

            Public Shared Operator >=(cls As ToArrayHelper(Of T, V), linq As Func(Of T, Integer, V)) As V()
                Throw New NotSupportedException
            End Operator
        End Structure
    End Namespace
End Namespace
