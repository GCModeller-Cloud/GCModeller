﻿Imports LANS.SystemsBiology.Assembly.DOOR
Imports LANS.SystemsBiology.ComponentModel.Loci
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic

Namespace Operon

    ''' <summary>
    ''' 根据转录组数据来修正操纵子
    ''' </summary>
    ''' <remarks></remarks>
    <[PackageNamespace]("Operon.Corrects", Category:=APICategories.UtilityTools, Description:="Corrects the DOOR operon data based on the RNA-Seq data.")>
    Public Module Corrects

        ''' <summary>
        ''' 由于假设认为DOOR里面的operon是依照基因组上面的位置来作为一个计算因素的，所以在这里的预测数据在物理位置上面都是满足的，假若基因不是一个operon里面的，则只需要分割operon就好了
        ''' </summary>
        ''' <param name="PCC"></param>
        ''' <param name="DOOR"></param>
        ''' <param name="pccCutoff">应该是一个正数</param>
        ''' <returns></returns>
        <ExportAPI("DOOR.Operon.Correct")>
        Public Function CorrectDoorOperon(PCC As PccMatrix,
                                          DOOR As DOOR,
                                          <Parameter("Cutoff.PCC", "value should be positive")>
                                          Optional pccCutoff As Double = 0.45) As LANS.SystemsBiology.Assembly.DOOR.Operon()
            Dim parallel As Boolean = True
#If DEBUG Then
            parallel = False
#End If
            Dim LQuery = DOOR.DOOROperonView.Operons.ToArray(Function(operon) __correctOperon(operon, PCC, pccCutoff))  ' 首先假设Door数据库之中的操纵子之中的基因之间的距离是合理的正确的
            Dim lstCorrected As LANS.SystemsBiology.Assembly.DOOR.Operon() =
                (From x In LQuery.MatrixToList Select x Order By x.Key Ascending).ToArray
            Return lstCorrected
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Operon"></param>
        ''' <returns></returns>
        Private Function __correctOperon(Operon As LANS.SystemsBiology.Assembly.DOOR.Operon,
                                         PCC As PccMatrix,
                                         pccCut As Double) As LANS.SystemsBiology.Assembly.DOOR.Operon()
            If Operon.NumOfGenes = 1 Then
                Return New LANS.SystemsBiology.Assembly.DOOR.Operon() {Operon}
            Else
                Dim source As GeneBrief()
                If Operon.Strand = Strands.Forward Then
                    source = (From x In Operon.Value Select x Order By x.Location.Left Ascending).ToArray
                Else
                    source = (From x In Operon.Value Select x Order By x.Location.Right Descending).ToArray
                End If
                Return __splitOperon(Operon.OperonID, source, Operon.InitialX, 1, pccCut, PCC)
            End If
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Operon"></param>
        ''' <param name="idx">参数请从1开始设置</param>
        ''' <param name="structGenes">在递归的最开始阶段需要根据链的方向进行排序操作的</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function __splitOperon(Operon As String, structGenes As GeneBrief(), Initial As GeneBrief,
                                       idx As Integer,
                                       cutoff As Double,
                                       PccMatrix As PccMatrix) As LANS.SystemsBiology.Assembly.DOOR.Operon()
            Dim cLst As List(Of LANS.SystemsBiology.Assembly.DOOR.Operon) =
                New List(Of LANS.SystemsBiology.Assembly.DOOR.Operon)

            For i As Integer = 0 To structGenes.Length - 1
                Dim Pcc As Double = PccMatrix.GetValue(structGenes(i).Synonym, Initial.Synonym)

                If Pcc < 0 OrElse Pcc < cutoff Then 'Operon之中的第一个基因和其他的基因之间的Pcc必须要大于0
                    Dim newPart As GeneBrief() = structGenes.Take(i).ToArray
                    Dim newOperon As LANS.SystemsBiology.Assembly.DOOR.Operon =
                        New LANS.SystemsBiology.Assembly.DOOR.Operon($"{Operon}.{idx}", newPart)

                    Call cLst.Add(newOperon)

                    idx += 1
                    newPart = structGenes.Skip(i).ToArray

                    If Not newPart.IsNullOrEmpty Then
                        Call cLst.AddRange(__splitOperon(Operon, newPart, newPart.First, idx, cutoff, PccMatrix))
                    End If

                    Exit For
                End If
            Next

            If cLst.IsNullOrEmpty Then ' 原先的数据没有错误，则返回原来的数据
                If idx > 1 Then
                    Operon = $"{Operon}.{idx}"
                End If
                Dim opr As New LANS.SystemsBiology.Assembly.DOOR.Operon(Operon, structGenes)
                Return {opr}
            End If

            Return cLst.ToArray
        End Function
    End Module
End Namespace