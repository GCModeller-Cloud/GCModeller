﻿Imports System.Text
Imports Microsoft.VisualBasic.Language.UnixBash

Namespace Language

    ''' <summary>
    ''' The base class object in VisualBasic
    ''' </summary>
    Public Interface IClassObject

        ''' <summary>
        ''' The extension property.(为了节省内存的需要，这个附加属性尽量不要被自动初始化)
        ''' </summary>
        ''' <returns></returns>
        Property Extension As ExtendedProps
    End Interface

    ''' <summary>
    ''' <see cref="System.Type"/>
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public Class [Class](Of T) : Inherits ClassObject

        Public ReadOnly Property Type As Type

        ReadOnly __enumsHandler As Func(Of IEnumerable(Of T), T())

        Sub New()
            _Type = GetType(T)
            __enumsHandler = AddressOf Enumerable.ToArray
        End Sub

        Sub New(array As Func(Of IEnumerable(Of T), T()))
            _Type = GetType(T)
            __enumsHandler = array
        End Sub

        Public Overrides Function ToString() As String
            Return Type.FullName
        End Function

        Public Shared Operator <=(cls As [Class](Of T), path As String) As List(Of T)
            Dim source As IEnumerable = CollectionIO.DefaultLoadHandle(cls.Type, path, Encoding.Default)
            Return (From x In source Select DirectCast(x, T)).ToList
        End Operator

        Public Shared Operator >=(cls As [Class](Of T), path As String) As List(Of T)
            Throw New NotSupportedException
        End Operator

        Public Shared Operator <<(cls As [Class](Of T), path As Integer) As List(Of T)
            Dim file As FileHandle = FileHandles.__getHandle(path)
            Return cls <= file.FileName
        End Operator

        ''' <summary>
        ''' ToArray
        ''' </summary>
        ''' <param name="cls"></param>
        ''' <param name="source"></param>
        ''' <returns></returns>
        Public Shared Operator <=(cls As [Class](Of T), source As IEnumerable(Of T)) As T()
            Return cls.__enumsHandler(source)
        End Operator

        Public Shared Operator <=(cls As [Class](Of T), source As IEnumerable(Of IEnumerable(Of T))) As T()
            Return source.MatrixToVector
        End Operator

        Public Shared Operator >=(cls As [Class](Of T), source As IEnumerable(Of IEnumerable(Of T))) As T()
            Throw New NotImplementedException
        End Operator

        Public Shared Operator >=(cls As [Class](Of T), source As IEnumerable(Of T)) As T()
            Throw New NotSupportedException
        End Operator

        Public Shared Function IsNullOrEmpty() As [Class](Of T)
            Return New [Class](Of T)
        End Function

        ''' <summary>
        ''' IsNullOrEmpty
        ''' </summary>
        ''' <param name="cls"></param>
        ''' <param name="source"></param>
        ''' <returns></returns>
        Public Shared Operator Like(cls As [Class](Of T), source As IEnumerable(Of T)) As Boolean
            Return source.IsNullOrEmpty
        End Operator
    End Class
End Namespace