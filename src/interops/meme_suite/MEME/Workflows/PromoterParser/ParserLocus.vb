﻿Imports SMRUCC.genomics.Assembly.DOOR

Namespace Workflows.PromoterParser

    Public Delegate Function IGetLocusTag(locus As String) As String()

    Public Enum GetLocusTags
        locus
        UniDOOR
        DOOR_InitX
    End Enum

    Public Module ParserLocus

        ''' <summary>
        ''' locus/union/initx
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        Public Function [GetType](name As String) As GetLocusTags
            Select Case name.ToLower
                Case "locus"
                    Return GetLocusTags.locus
                Case "union"
                    Return GetLocusTags.UniDOOR
                Case "initx"
                    Return GetLocusTags.DOOR_InitX
                Case Else
                    Throw New NotImplementedException(name)
            End Select
        End Function

        Public Function CreateMethod(DOOR As DOOR, type As GetLocusTags) As IGetLocusTag
            Select Case type
                Case GetLocusTags.locus
                    Return AddressOf __locusItSelf
                Case GetLocusTags.UniDOOR
                    Return AddressOf New __DOORHelper(DOOR).UniDOOR
                Case GetLocusTags.DOOR_InitX
                    Return AddressOf New __DOORHelper(DOOR).InitX
                Case Else
                    Throw New NotSupportedException
            End Select
        End Function

        Private Class __DOORHelper

            ReadOnly __DOOR As DOOR

            Sub New(DOOR As DOOR)
                __DOOR = DOOR
            End Sub

            ''' <summary>
            ''' 返回基因以及操纵子的第一个基因，在返回的数据之中操纵子的第一个基因总是在第一个元素之中的
            ''' </summary>
            ''' <param name="locus"></param>
            ''' <returns></returns>
            Public Function UniDOOR(locus As String) As String()
                Return {__initX(locus), locus}
            End Function

            Private Function __initX(locus As String) As String
                Dim gene As GeneBrief = __DOOR.GetGene(locus)
                If gene Is Nothing Then
                    Call $"locus_id {locus} not contains in database???".__DEBUG_ECHO
                    Return locus
                End If
                Dim operon As Operon = __DOOR.DOOROperonView.GetOperon(gene.OperonID)
                Dim firstGene As GeneBrief = operon.InitialX
                Return firstGene.Synonym
            End Function

            Public Function InitX(locus As String) As String()
                Return {__initX(locus)}
            End Function
        End Class

        Private Function __locusItSelf(s As String) As String()
            Return {s}
        End Function
    End Module
End Namespace