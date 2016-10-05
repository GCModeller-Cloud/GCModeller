﻿Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.Text

Public Class ReaderProvider
    Implements IDisposable

    Public ReadOnly Property URI As String

    ReadOnly __bufferedReader As BinaryDataReader
    ReadOnly __encoding As Encoding

    Public ReadOnly Property Length As Long
        Get
            Return FileIO.FileSystem.GetFileInfo(URI).Length
        End Get
    End Property

    Sub New(path$, Optional encoding As Encodings = Encodings.ASCII, Optional buffered& = 1024 * 1024 * 10)
        URI = path$
        __encoding = encoding.GetEncodings

        If FileIO.FileSystem.GetFileInfo(path).Length <= buffered Then
            Dim byts As Byte() = FileIO.FileSystem.ReadAllBytes(path)   ' 文件数据将会被缓存
            __bufferedReader = New BinaryDataReader(New MemoryStream(byts), __encoding)
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="run">
    ''' 请不要在这里面执行<see cref="BinaryDataReader.Close()"/>或者<see cref="BinaryDataReader.Dispose()"/>
    ''' </param>
    Public Sub Read(run As Action(Of BinaryDataReader))
        If __bufferedReader Is Nothing Then
            Using file As New FileStream(
                URI,
                mode:=FileMode.Open,
                access:=FileAccess.Read,
                share:=FileShare.Read), reader As New BinaryDataReader(file, __encoding)

                Call run(reader)
            End Using
        Else
            SyncLock __bufferedReader
                Call run(__bufferedReader)
                Call __bufferedReader.Seek(Scan0, SeekOrigin.Begin)
            End SyncLock
        End If
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                If Not __bufferedReader Is Nothing Then
                    Call __bufferedReader.Dispose()
                End If
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class