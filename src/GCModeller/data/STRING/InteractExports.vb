﻿Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Data.STRING.StringDB.Tsv

''' <summary>
''' 对于<see cref="LinkAction"/>和<see cref="linksDetail"/>而言，都是从ftp服务器上面下载的结果数据
''' 这个tsv文件则是搜索蛋白质网络结果之后的export下载数据的文件格式读取对象
''' </summary>
Public Class InteractExports

    <Column("#node1")>
    Public Property node1 As String
    Public Property node2 As String
    Public Property node1_string_internal_id As String
    Public Property node2_string_internal_id As String
    Public Property node1_external_id As String
    Public Property node2_external_id As String
    Public Property neighborhood_on_chromosome As String
    Public Property gene_fusion As String
    Public Property phylogenetic_cooccurrence As String
    Public Property homology As String
    Public Property coexpression As String
    Public Property experimentally_determined_interaction As String
    Public Property database_annotated As String
    Public Property automated_textmining As String
    Public Property combined_score As String

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function

    Public Shared Function ImportsTsv(tsv$) As InteractExports()
        Return DataImports.ImportsTsv(Of InteractExports)(tsv.ReadAllLines)
    End Function
End Class
