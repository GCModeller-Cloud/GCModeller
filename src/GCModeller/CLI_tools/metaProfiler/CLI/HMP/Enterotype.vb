﻿Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports SMRUCC.genomics.Analysis.Metagenome

Partial Module CLI

    <ExportAPI("/do.enterotype.cluster")>
    <Description("")>
    <Usage("/do.enterotype.cluster /in <dataset.csv/txt> [/iterations 10000 /parallel /out <clusters.csv>]")>
    Public Function DoEnterotypeCluster(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim iterations% = args("/iterations") Or 10000
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.DoEnterotypeCluster.csv"
        Dim data As DataSet() = DataSet _
            .LoadDataSet([in], tsv:=[in].ExtensionSuffix.TextEquals("txt")) _
            .ToArray
        Dim parallel As Boolean = args("/parallel")
        Dim result = data.JSD(parallel:=parallel).PAMclustering

        Return result.SaveTo(out).CLICode
    End Function
End Module