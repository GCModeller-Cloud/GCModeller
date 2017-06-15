﻿Imports System.ComponentModel
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports SMRUCC.genomics.Assembly.Uniprot.XML
Imports SMRUCC.genomics.Data.STRING
Imports SMRUCC.genomics.Model.Network.STRING

Partial Module CLI

    <ExportAPI("/func.rich.string")>
    <Usage("/func.rich.string /in <string_interactions.tsv> /uniprot <uniprot.XML> /DEP <dep.t.test.csv> [/fold <1.5> /out <out.network.DIR>]")>
    <Description("DEPs' functional enrichment network based on string-db exports")>
    Public Function FunctionalNetworkEnrichment(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim uniprot$ = args <= "/uniprot"
        Dim DEP$ = args <= "/DEP"
        Dim fold# = args.GetValue("/fold", 1.5)
        Dim out$ = args.GetValue("/out", [in].TrimSuffix & "-funrich_string/")
        Dim annotations = UniprotXML.Load(uniprot)
        Dim model = [in].LoadTsv(Of InteractExports).BuildModel(annotations)

        Return model.Save(out).CLICode
    End Function
End Module