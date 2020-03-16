﻿Imports System.IO
Imports Microsoft.VisualBasic.Data.IO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Net.Http
Imports Microsoft.VisualBasic.Text.Parser.HtmlParser
Imports XmlOffset = SMRUCC.genomics.GCModeller.ModellingEngine.IO.vcXML.XML.offset

Namespace vcXML

    Public Class Reader : Implements IDisposable

        Dim fs As StreamReader
        ''' <summary>
        ''' [module -> [type -> offset]]
        ''' </summary>
        Dim index As Dictionary(Of String, Dictionary(Of String, List(Of XmlOffset)))
        Dim entities As Dictionary(Of String, Dictionary(Of String, String()))
        Dim hash As String

        Public ReadOnly Property basename As String

        Public ReadOnly Property allFrames As XmlOffset()
            Get
                Return index.Values _
                    .IteratesALL _
                    .Values _
                    .IteratesALL _
                    .ToArray
            End Get
        End Property

        Sub New(file As String)
            fs = file.OpenReader()
            fs.BaseStream.Seek(-128, SeekOrigin.End)
            basename = file.BaseName

            Call loadOffsets()
        End Sub

        Public Function getStreamIndex(name As String) As Dictionary(Of String, List(Of XmlOffset))
            If Not index.ContainsKey(name) Then
                Throw New MissingPrimaryKeyException(name)
            Else
                Return index(name)
            End If
        End Function

        Public Function getStreamEntities(module$, type$) As String()
            Return entities([module])(type)
        End Function

        Public Function getFrameVector(offset As Long) As Double()
            Dim line As Value(Of String) = ""

            fs.BaseStream.Position = offset
            fs.DiscardBufferedData()

            Do While Not (line = fs.ReadLine).StringEmpty
                If InStr(line.Value, "<vector") > 0 Then
                    Exit Do
                End If
            Loop

            Dim buffer As Byte() = line.Value.GetValue.DoCall(AddressOf decodeBuffer)
            Dim vector As Double() = buffer _
                .Split(8) _
                .Select(Function(bits)
                            Return BitConverter.ToDouble(bits, Scan0)
                        End Function) _
                .ToArray

            Return vector
        End Function

        Private Sub loadOffsets()
            Dim line As Value(Of String) = ""
            Dim content = fs.ReadToEnd
            Dim i As Long = content _
                .Match("<indexOffset>\d+</indexOffset>") _
                .GetValue _
                .DoCall(AddressOf Long.Parse)

            hash = content.Match("<md5>.+</md5>", RegexICSng).GetValue
            fs.BaseStream.Seek(i, SeekOrigin.Begin)
            index = New Dictionary(Of String, Dictionary(Of String, List(Of XmlOffset)))
            entities = New Dictionary(Of String, Dictionary(Of String, String()))

            Call parseFrameIndex(fs.ReadLine)
            Call parseEntityIndex(fs.ReadLine)
        End Sub

        Private Sub parseEntityIndex(content As String)
            Dim line As Value(Of String) = ""
            Dim module$
            Dim type$
            Dim numOfFrames As Integer = content.attr("size").DoCall(AddressOf Integer.Parse)
            Dim attrs As Dictionary(Of String, String)
            Dim buffer As Byte()
            Dim offset As XmlOffset
            Dim tmpOffsets As New List(Of XmlOffset)

            Do While numOfFrames > 0 AndAlso Not (line = fs.ReadLine).StringEmpty
                attrs = line.Value _
                   .TagAttributes _
                   .ToDictionary(Function(a) a.Name,
                                 Function(a)
                                     Return a.Value
                                 End Function)
                [module] = attrs!module
                [type] = attrs!content_type
                offset = New XmlOffset With {
                    .offset = line.Value _
                        .GetValue _
                        .DoCall(AddressOf Long.Parse),
                    .content_type = type,
                    .id = Integer.Parse(attrs!id),
                    .[module] = [module]
                }

                tmpOffsets.Add(offset)
                numOfFrames -= 1
            Loop

            For Each offset In tmpOffsets
                [module] = offset.module
                type = offset.content_type

                If Not entities.ContainsKey([module]) Then
                    entities.Add([module], New Dictionary(Of String, String()))
                End If

                fs.BaseStream.Position = offset.offset
                fs.DiscardBufferedData()

                buffer = fs.ReadLine.GetValue.DoCall(AddressOf decodeBuffer)

                Using reader As New BinaryDataReader(New MemoryStream(buffer))
                    Dim id As New List(Of String)

                    Do While Not reader.EndOfStream
                        id.Add(reader.ReadString(BinaryStringFormat.ByteLengthPrefix))
                    Loop

                    entities([module]).Add(type, id.ToArray)
                End Using
            Next
        End Sub

        Private Function decodeBuffer(data As String) As Byte()
            Dim buffer As Byte() = data.Base64RawBytes.UnGzipStream.ToArray

            If BitConverter.IsLittleEndian Then
                Array.Reverse(buffer)
            End If

            Return buffer
        End Function

        Private Sub parseFrameIndex(content As String)
            Dim numOfFrames As Integer = content.attr("size").DoCall(AddressOf Integer.Parse)
            Dim module$
            Dim type$
            Dim attrs As Dictionary(Of String, String)
            Dim offset As XmlOffset
            Dim line As Value(Of String) = ""

            Do While numOfFrames > 0 AndAlso Not (line = fs.ReadLine).StringEmpty
                attrs = line.Value _
                    .TagAttributes _
                    .ToDictionary(Function(a) a.Name,
                                  Function(a)
                                      Return a.Value
                                  End Function)
                [module] = attrs!module
                [type] = attrs!content_type

                If Not index.ContainsKey([module]) Then
                    index.Add([module], New Dictionary(Of String, List(Of XmlOffset)))
                End If
                If Not index([module]).ContainsKey(type) Then
                    index([module]).Add(type, New List(Of XmlOffset))
                End If

                numOfFrames -= 1
                offset = New XmlOffset With {
                    .offset = line.Value _
                        .GetValue _
                        .DoCall(AddressOf Long.Parse),
                    .content_type = type,
                    .id = Integer.Parse(attrs!id),
                    .[module] = [module],
                    .tick = Integer.Parse(attrs!tick)
                }
                index([module])(type).Add(offset)
            Loop

            Call fs.ReadLine()
        End Sub

        Public Overrides Function ToString() As String
            Return $"{basename} ({hash})"
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    Call fs.Close()
                    Call fs.Dispose()
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
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
End Namespace