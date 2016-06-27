﻿Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace ComponentModel.Ranges

    Public Class RangeList(Of T As IComparable, V) : Inherits List(Of RangeTagValue(Of T, V))

        Sub New()
            MyBase.New(128)
        End Sub

        Public Function [Select](x As T) As RangeTagValue(Of T, V)
            Dim LQuery As RangeTagValue(Of T, V) =
                LinqAPI.DefaultFirst(Of RangeTagValue(Of T, V)) <=
                From r As RangeTagValue(Of T, V)
                In Me.AsQueryable
                Where r.IsInside(x)
                Select r

            Return LQuery
        End Function

        Public Function SelectValue(x As T, Optional [throw] As Boolean = True, Optional ByRef success As Boolean = False) As V
            Dim n As RangeTagValue(Of T, V) = [Select](x)
            If n Is Nothing Then
                If [throw] Then
                    Throw New DataException($"{x.GetJson} is not in any ranges!")
                Else
                    Return Nothing
                End If
            Else
                success = True
                Return n.Value
            End If
        End Function

        Public Function SelectValue(x As T, [default] As Func(Of T, V)) As V
            Dim success As Boolean = False
            Dim v As V = SelectValue(x, [throw]:=False, success:=success)

            If success Then
                Return v
            Else
                Return [default](x)
            End If
        End Function

        Public ReadOnly Iterator Property Values As IEnumerable(Of V)
            Get
                For Each x As RangeTagValue(Of T, V) In Me
                    Yield x.Value
                Next
            End Get
        End Property

        Public ReadOnly Iterator Property Keys As IEnumerable(Of Range(Of T))
            Get
                For Each x As RangeTagValue(Of T, V) In Me
                    Yield x
                Next
            End Get
        End Property
    End Class

    Public Class OrderSelector(Of T As IComparable)

        ReadOnly _source As T()
        ReadOnly _direct As String

        Public ReadOnly Property Desc As Boolean

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="asc">当这个参数为真的时候</param>
        Sub New(source As IEnumerable(Of T), Optional asc As Boolean = True)
            If asc Then
                _source = source.OrderBy(Function(x) x).ToArray
                _direct = " -> "
            Else
                _source = source.OrderByDescending(Function(x) x).ToArray
                _direct = " <- "
            End If

            Desc = Not asc
        End Sub

        Public Overrides Function ToString() As String
            Return $"[{_direct}] {GetType(T).ToString}"
        End Function

        ''' <summary>
        ''' 直到当前元素大于指定值
        ''' </summary>
        ''' <param name="n"></param>
        ''' <returns></returns>
        Public Iterator Function SelectUntilGreaterThan(n As T) As IEnumerable(Of T)
            For Each x In _source
                If Language.LessThanOrEquals(x, n) Then
                    Yield x
                Else
                    Exit For   ' 由于是经过排序了的，所以在这里不再小于的话，则后面的元素都不会再比他小了
                End If
            Next
        End Function

        ''' <summary>
        ''' 直到当前元素小于指定值
        ''' </summary>
        ''' <param name="n"></param>
        ''' <returns></returns>
        Public Iterator Function SelectUntilLessThan(n As T) As IEnumerable(Of T)
            For Each x In _source
                If Language.GreaterThanOrEquals(x, n) Then
                    Yield x
                Else
                    Exit For
                End If
            Next
        End Function
    End Class

    Public Structure IntTag(Of T)
        Implements IComparable

        Public ReadOnly n As Integer
        Public ReadOnly x As T

        Sub New(x As T, getInt As Func(Of T, Integer))
            Me.x = x
            Me.n = getInt(x)
        End Sub

        Sub New(n As Integer)
            Me.n = n
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
            If obj Is Nothing Then
                Return 1
            Else
                If TypeOf obj Is Integer Then
                    Return n.CompareTo(DirectCast(obj, Integer))
                ElseIf TypeOf obj Is IntTag(Of T) Then
                    Return n.CompareTo(DirectCast(obj, IntTag(Of T)).n)
                Else
                    Return 0
                End If
            End If
        End Function

        Public Shared Function OrderSelector(source As IEnumerable(Of T),
                                             getInt As Func(Of T, Integer),
                                             Optional asc As Boolean = True) As OrderSelector(Of IntTag(Of T))
            Dim array As IEnumerable(Of IntTag(Of T)) = source.Select(Function(x) New IntTag(Of T)(x, getInt))
            Dim selects As New OrderSelector(Of IntTag(Of T))(array, asc)
            Return selects
        End Function

        Public Shared Widening Operator CType(n As Integer) As IntTag(Of T)
            Return New IntTag(Of T)(n)
        End Operator
    End Structure
End Namespace