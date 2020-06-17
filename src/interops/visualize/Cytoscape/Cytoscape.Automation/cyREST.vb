﻿Imports System.Net.Sockets
Imports Flute.Http.Core
Imports Flute.Http.FileSystem
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Net.Protocols.ContentTypes
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.genomics.Visualize.Cytoscape.CytoscapeGraphView.Cyjs
Imports SMRUCC.genomics.Visualize.Cytoscape.Tables

Public MustInherit Class cyREST : Implements IDisposable

    Protected Shared ReadOnly virtualFilesystem As New FileHost(8887)

    Private disposedValue As Boolean

    Public Shared Function addUploadFile(file As String) As String
        Return virtualFilesystem.addUploadFile(file)
    End Function

    Public MustOverride Function layouts() As String()

    ''' <summary>
    ''' Returns a list of all networks as names and their corresponding SUIDs.
    ''' </summary>
    ''' <returns></returns>
    Public MustOverride Function networksNames() As String()

    ''' <summary>
    ''' Creates a new network in the current session from a file or URL source.
    ''' </summary>
    ''' <returns></returns>
    Public MustOverride Function putNetwork(network As [Variant](Of Cyjs, SIF()), Optional collection$ = Nothing, Optional title$ = Nothing) As NetworkReference()
    Public MustOverride Function applyLayout(network As Integer, Optional algorithm As String = "force-directed") As String

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Shared Sub Close()
        Call virtualFilesystem.Dispose()
    End Sub
End Class

' [{"source":"http://localhost:8887/tmp0000b/upload.json","networkSUID":[445]}]"

Public Class NetworkReference
    Public Property source As String
    Public Property networkSUID As String()
End Class

''' <summary>
''' local file reference for cytoscape automation
''' </summary>
Public Class FileReference
    Public Property source_location As String
    Public Property source_method As String = "GET"
    Public Property ndex_uuid As String = "12345"
End Class

Public Class FileHost : Inherits HttpServer

    ReadOnly virtual As New FileSystem(App.CurrentDirectory)

    Public Sub New(port As Integer, Optional threads As Integer = -1)
        MyBase.New(port, threads)
    End Sub

    Public Function addUploadFile(file As String) As String
        Dim res As String = "/" & file.GetFullPath.Replace(":/", "/").Split("/"c).Select(AddressOf UrlEncode).JoinBy("/")
        Call virtual.AddMapping(res, file)
        Return $"http://localhost:{localPort}{res}"
    End Function

    Public Function addUploadData(data As String, ext$) As String
        Dim res As String = App.NextTempName & $"/upload.{ext}"
        Dim type As ContentType

        Select Case ext.ToLower
            Case "json"
                type = New ContentType With {.Details = MIME.Json, .MIMEType = MIME.Json}
            Case "txt", "sif"
                type = New ContentType With {.Details = "plain/text", .MIMEType = "plain/text"}
            Case Else
                Throw New NotImplementedException(ext)
        End Select

        Call virtual.AddCache(res, Encodings.UTF8WithoutBOM.CodePage.GetBytes(data), type)
        Return $"http://localhost:{localPort}/{res}"
    End Function

    Public Overrides Sub handleGETRequest(p As HttpProcessor)
        Dim path As String = p.http_url
        Dim handler = p.openResponseStream

        If virtual.FileExists(path) Then
            Call handler.WriteHeader(virtual.GetContentType(path).MIMEType, virtual.GetFileSize(path))
            Call p.openResponseStream.Write(virtual.GetByteBuffer(path))
        Else
            Call p.openResponseStream.WriteError(404, "invalid file")
        End If
    End Sub

    Public Overrides Sub handlePOSTRequest(p As HttpProcessor, inputData As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub handleOtherMethod(p As HttpProcessor)
        Throw New NotImplementedException()
    End Sub

    Protected Overrides Function getHttpProcessor(client As TcpClient, bufferSize As Integer) As HttpProcessor
        Return New HttpProcessor(client, Me, bufferSize)
    End Function
End Class

Namespace Upload

    Public Class CyjsUpload

        Public Property data As cyjsdata
        Public Property elements As networkElement

        Sub New(cyjs As Cyjs)
            data = New cyjsdata
            elements = New networkElement With {
                .edges = cyjs.elements.edges.Select(Function(a) New cyjsedge With {.data = New edgeData2 With {.interaction = a.data.interaction, .source = a.data.source, .target = a.data.target}}).ToArray,
                .nodes = cyjs.elements.nodes.Select(Function(a) New cyjsNode With {.data = New nodeData2 With {.common = a.data.common, .id = a.data.id}}).ToArray
            }
        End Sub

    End Class

    Public Class networkElement
        Public Property nodes As cyjsNode()
        Public Property edges As cyjsedge()
    End Class

    Public Class cyjsNode
        Public Property data As nodeData2
    End Class

    Public Class cyjsedge
        Public Property data As edgeData2
    End Class

    Public Class edgeData2
        Public Property source As String
        Public Property target As String
        Public Property interaction As String
    End Class

    Public Class nodeData2
        Public Property id As String
        Public Property common As String
    End Class

    Public Class cyjsdata
        Public Property name As String = App.NextTempName
    End Class
End Namespace

Public Enum formats
    ''' <summary>
    ''' SIF format
    ''' </summary>
    egdeList
    ''' <summary>
    ''' cx format
    ''' </summary>
    cx
    ''' <summary>
    ''' cytoscape.js format
    ''' </summary>
    json
End Enum