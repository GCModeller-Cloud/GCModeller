﻿Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Text

Namespace Ptf

    ''' <summary>
    ''' the GCModeller protein annotation tabular format file.
    ''' </summary>
    Public Class PtfFile : Implements ISaveHandle

        Public Property attributes As Dictionary(Of String, String)
        Public Property proteins As ProteinAnnotation()

        Public Overrides Function ToString() As String
            Return attributes.GetJson
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overloads Shared Function ToString(protein As ProteinAnnotation) As String
            Return Document.asLineText(protein)
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function Load(file As String) As PtfFile
            Return Document.ParseDocument(file)
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function ReadAnnotations(file As Stream) As IEnumerable(Of ProteinAnnotation)
            Return Document.IterateAnnotations(file)
        End Function

        Public Function Save(path As String, encoding As Encoding) As Boolean Implements ISaveHandle.Save
            Using output As New StreamWriter(path.Open(doClear:=True), encoding) With {
                .NewLine = ASCII.LF
            }
                Call Document.writeTabular(Me, output)
            End Using

            Return True
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function Save(path As String, Optional encoding As Encodings = Encodings.UTF8) As Boolean Implements ISaveHandle.Save
            Return Save(path, encoding.CodePage)
        End Function
    End Class
End Namespace