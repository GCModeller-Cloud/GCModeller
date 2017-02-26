﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel

Namespace Assembly.Uniprot.XML

    Public Module Extensions

        <Extension> Public Function proteinFullName(protein As entry) As String
            If protein.protein Is Nothing Then
                Return ""
            Else
                Return protein.protein.FullName
            End If
        End Function

        <Extension> Public Function ORF(protein As entry) As String
            If protein.gene Is Nothing OrElse Not protein.gene.HaveKey("ORF") Then
                Return Nothing
            Else
                Return protein.gene.ORF.First
            End If
        End Function

        Public Function Term2Gene(uniprotXML As UniprotXML, type$) As IDMap()

        End Function
    End Module
End Namespace