﻿Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.Default
Imports SMRUCC.genomics.SequenceModel.NucleotideModels

Namespace DNAOrigami

    ''' <summary>
    ''' evaluate scaffold orthogonality
    ''' 
    ''' This script analyses orthogonality of two DNA-Origami scaffold strands.
    ''' Multiple criteria For orthogonality Of the two sequences can be specified
    ''' to determine the level of orthogonality. The script Is inteded to be easily
    ''' applicable for a broad untrained audience, weherefore it only relies on
    ''' standard packages And elaborate input processing.
    ''' </summary>
    Public Module ScaffoldOrthogonality

        ''' <summary>
        ''' Check orthogonality of 2 dna-sequences and output relevant data.
        ''' </summary>
        ''' <param name="sc1"></param>
        ''' <param name="sc2"></param>
        ''' <param name="project"></param>
        ''' <returns></returns>
        Public Function CheckOrtho(sc1 As String, sc2 As String, Optional project As Project = Nothing) As Output
            Dim count As Double
            Dim count_RC As Double
            Dim n_count As New List(Of Double)
            Dim n_count_RC As New List(Of Double)
            Dim sc1Full As String
            Dim sc2Full As String

            Static defaultArguments As [Default](Of Project) = New Project()

            project = project Or defaultArguments
            count_RC = If(project.get_rev_compl, 0, Double.NaN)
            sc1 = sc1.ToUpper
            sc2 = sc2.ToUpper

            With circulariseScaffold(project, sc1, sc2)
                sc1Full = .Item1
                sc2Full = .Item2
            End With

            For i As Integer = 0 To sc1.Length - 1
                Dim repeat_count = 0
                Dim repeat_count_RC = 0
                Dim sc1_seg = sc1Full.Substring(i, project.n)

                For j As Integer = 0 To sc2.Length - 1
                    Dim sc2_seg = sc2Full.Substring(j, project.n)

                    If isMatch(sc1_seg, sc2_seg, project) Then
                        count += 1
                        repeat_count += 1
                    End If

                    If project.get_rev_compl Then
                        Dim sc2_seg_RC = NucleicAcid.Complement(sc2Full.Substring(i, project.n).Reverse.CharString)

                        If isMatch(sc1_seg, sc2_seg_RC, project) Then
                            count_RC += 1
                            repeat_count_RC += 1
                        End If
                    End If
                Next

                If repeat_count > 1 Then
                    n_count.Add(repeat_count)
                End If
                If repeat_count_RC > 1 Then
                    n_count_RC.Add(repeat_count_RC)
                End If
            Next

            Dim count_corrected = count - (n_count.Sum - n_count.Count)
            Dim count_revcompl_corrected = count_RC - (n_count_RC.Sum - n_count_RC.Count)

            Return New Output With {
                .count = count,
                .count_corrected = count_corrected,
                .count_revcompl = count_RC,
                .count_revcompl_corrected = count_revcompl_corrected,
                .n_count = n_count.ToArray,
                .n_count_revcompl = n_count_RC.ToArray
            }
        End Function

        Private Function circulariseScaffold(project As Project, sc1 As String, sc2 As String) As (String, String)
            If project.is_linear Then
                Return (sc1, sc2)
            Else
                sc1 = sc1 & sc1.Substring(project.n)
                sc2 = sc2 & sc2.Substring(project.n)

                Return (sc1, sc2)
            End If
        End Function

        Private Function isMatch(seg1 As String, seg2 As String, project As Project) As Boolean
            Return seg1 = seg2 And Len(seg1) = project.n
        End Function
    End Module
End Namespace