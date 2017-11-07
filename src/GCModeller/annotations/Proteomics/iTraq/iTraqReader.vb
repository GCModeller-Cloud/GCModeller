﻿Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language

''' <summary>
''' iTraq data reader.(iTraq蛋白组下机数据转录原始结果文件的数据模型)
''' </summary>
Public Class iTraqReader : Inherits DataSet
    Implements INamedValue

    <Column("Accession")>
    Public Overrides Property ID As String Implements IKeyedEntity(Of String).Key
    Public Property Description As String
    Public Property Score As String
    Public Property Coverage As String

    <Column("# Proteins")> Public Property Proteins As String
    <Column("# Unique Peptides")> Public Property UniquePeptides As String
    <Column("# Peptides")> Public Property Peptides As String
    <Column("# PSMs")> Public Property PSMs As String
    <Column("# AAs")> Public Property AAs As String
    <Column("MW [kDa]")> Public Property MW As String
    <Column("calc. pI")> Public Property calcPI As String

    Public Overrides Function ToString() As String
        Return $"{ID} {Description}"
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="symbols">已经经过了<see cref="Combinations"/>操作之后的结果</param>
    ''' <returns></returns>
    Public Function GetSampleGroups(symbols As IEnumerable(Of iTraqSymbols)) As Dictionary(Of SampleValue)
        Dim groups As New List(Of SampleValue)
        Dim count$
        Dim var$

        For Each group As iTraqSymbols In symbols
            If Properties.ContainsKey(group.Symbol) Then
                count = group.Symbol & " Count"
                var = group.Symbol & " Variability [%]"

                ' FoldChange
                ' 因为这里主要是为了获取FoldChange数据，所以对于其他的可能不存在的数据就直接忽略掉了
                groups += New SampleValue With {
                    .Group = group.AnalysisID,
                    .Count = Properties.TryGetValue(count),
                    .FoldChange = Properties(group.Symbol),
                    .Variability = Properties.TryGetValue(var)
                }
            End If
        Next

        Return groups.ToDictionary
    End Function

    Public Structure SampleValue : Implements INamedValue

        Public Property Group As String Implements IKeyedEntity(Of String).Key

        Dim FoldChange#
        Dim Count%
        Dim Variability#

        Public Iterator Function PopulateData() As IEnumerable(Of KeyValuePair(Of String, Double))
            Yield New KeyValuePair(Of String, Double)(Group, FoldChange)
            Yield New KeyValuePair(Of String, Double)(Group & " Count", Count)
            Yield New KeyValuePair(Of String, Double)(Group & " Variability [%]", Variability)
        End Function

        Public Overrides Function ToString() As String
            Return $"{Group}: foldChange={FoldChange}, count={Count}, variability={Variability}"
        End Function
    End Structure
End Class
