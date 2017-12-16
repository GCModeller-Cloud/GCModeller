﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports SMRUCC.genomics.Analysis.Metagenome.gast
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput.BlastPlus
Imports SMRUCC.genomics.Metagenomics

Namespace greengenes

    Public Module Extensions

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="blastn"></param>
        ''' <param name="OTUs"></param>
        ''' <param name="taxonomy"></param>
        ''' <returns></returns>
        ''' <remarks>使用gast最多只能够注释到species，不能够具体的注释到某一个菌株？？</remarks>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function OTUgreengenesTaxonomy(blastn As IEnumerable(Of Query),
                                              OTUs As Dictionary(Of String, NamedValue(Of Integer)),
                                              taxonomy As Dictionary(Of String, otu_taxonomy),
                                              Optional min_pct# = 0.97) As IEnumerable(Of gastOUT)

            Return blastn.gastTaxonomyInternal(
                getTaxonomy:=Function(hitName)
                                 Return New gast.Taxonomy(taxonomy(hitName).ToString)
                             End Function,
                getOTU:=OTUs,
                min_pct:=min_pct
            )
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Iterator Public Function OTUgreengenesTaxonomyTreeAssign(blastn As IEnumerable(Of Query),
                                                                 OTUs As Dictionary(Of String, NamedValue(Of Integer)),
                                                                 taxonomy As Dictionary(Of String, otu_taxonomy),
                                                                 Optional min_pct# = 0.97,
                                                                 Optional skipNoResult As Boolean = True) As IEnumerable(Of gastOUT)
            For Each query As Query In blastn
                If Not OTUs.ContainsKey(query.QueryName) Then
                    Continue For
                Else
                    Dim result As gastOUT = query.TreeAssign(OTUs(query.QueryName), taxonomy, min_pct)

                    If result.rank <> "NA" Then
                        Yield result
                    Else
                        If Not skipNoResult Then
                            Yield result
                        End If
                    End If
                End If
            Next
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="align"></param>
        ''' <param name="OTU"></param>
        ''' <param name="taxonomy"></param>
        ''' <param name="min_pct#">
        ''' ``[0-1]`` or ``[0-100]``
        ''' 
        ''' 0.97 equals to 97
        ''' </param>
        ''' <returns></returns>
        <Extension>
        Public Function TreeAssign(align As Query, OTU As NamedValue(Of Integer), taxonomy As Dictionary(Of String, otu_taxonomy), Optional min_pct# = 0.05) As gastOUT
            Dim hits = align _
                .SubjectHits _
                .Select(Function(h) taxonomy(h.Name)) _
                .ToArray
            Dim tax_counts%() = Nothing
            Dim minrank$ = Nothing
            Dim tree As TaxonomyTree = TaxonomyTree.BuildTree(
                hits:=hits.Select(Function(t) t.Taxonomy),
                taxa_counts:=tax_counts,
                minrank:=minrank
            )
            Dim cutoff% = If(min_pct > 1, min_pct / 100, min_pct) * hits.Length
            Dim n As New List(Of Integer)
            Dim assign As TaxonomyTree = Nothing

            Do While True
                ' 遍历整颗树，取hits最大的分支作为最终的赋值结果
                tree = tree _
                    .Childs _
                    .OrderByDescending(Function(t) t.hits) _
                    .First
                n += tree.hits

                If tree.hits < cutoff AndAlso assign Is Nothing Then
                    ' 因为假若需要知道所有ranks的数量分布的话
                    ' 在这里达到cutoff之后还不能够立刻退出
                    assign = tree.Parent
                End If

                If tree.Childs = 0 Then
                    ' 物种的比对注释结果一直到最低端的species都还具有高于cutoff的支持度
                    ' 则assign此时仍然是空的，需要在这里判断一下，否则后面的代码会出现空引用错误
                    If assign Is Nothing Then
                        assign = tree
                    End If
                    Exit Do
                End If
            Loop

            Dim rank As TaxonomyRanks

            Call assign.GetDepth(rank)

            Dim taxonomyString$ = DirectCast(assign, gast.Taxonomy) _
                .BIOMTaxonomyString _
                .Trim(";"c)
            Dim pcts As Vector = Vector.round((New Vector(n) / hits.Length), 2) * 100
            Dim result As New gastOUT With {
                .taxonomy = taxonomyString,
                .counts = OTU.Value,
                .minrank = minrank,
                .read_id = OTU.Name,
                .refhvr_ids = align.QueryName,
                .max_pcts = pcts.JoinBy(";"),
                .refssu_count = hits.Length,
                .taxa_counts = tax_counts.JoinBy(";"),
                .na_pcts = (100 - pcts).JoinBy(";"),
                .rank = rank.ToString,
                .vote = n.JoinBy(";")
            }

            Return result
        End Function
    End Module
End Namespace