﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream.Generic
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Core

Module VCellNetwork

    <Extension>
    Public Function CreateGraph(vcell As Vessel) As NetworkGraph
        Dim g As New NetworkGraph
        Dim processNode As Node

        For Each mass As Factor In vcell.MassEnvironment
            g.AddNode(New Node With {.label = mass.ID})
        Next

        For Each process As Channel In vcell.Channels
            processNode = g.AddNode(New Node With {.label = process.ID})

            For Each mass In process.GetReactants
                Call New Edge With {
                    .U = g.GetElementByID(mass.Mass.ID),
                    .V = processNode,
                    .weight = mass.Coefficient,
                    .ID = $"{process.ID}.reactant"，
                    .data = New EdgeData With {
                        .Properties = New Dictionary(Of String, String) From {
                            {NamesOf.REFLECTION_ID_MAPPING_INTERACTION_TYPE, "reaction"}
                        },
                        .label = process.ID
                    }
                }.DoCall(AddressOf g.AddEdge)
            Next
            For Each mass In process.GetProducts
                Call New Edge With {
                    .U = processNode,
                    .V = g.GetElementByID(mass.Mass.ID),
                    .weight = mass.Coefficient,
                    .ID = $"{process.ID}.product"，
                    .data = New EdgeData With {
                        .Properties = New Dictionary(Of String, String) From {
                            {NamesOf.REFLECTION_ID_MAPPING_INTERACTION_TYPE, "reaction"}
                        },
                        .label = process.ID
                    }
                }.DoCall(AddressOf g.AddEdge)
            Next
            For Each factor In process.forward.activation
                Call New Edge With {
                    .U = g.GetElementByID(factor.Mass.ID),
                    .V = processNode,
                    .weight = factor.Coefficient,
                    .ID = $"{process.ID}.forward.activedBy.{factor.Mass.ID}"，
                    .data = New EdgeData With {
                        .Properties = New Dictionary(Of String, String) From {
                            {NamesOf.REFLECTION_ID_MAPPING_INTERACTION_TYPE, "forward.activation"}
                        },
                        .label = process.ID
                    }
                }.DoCall(AddressOf g.AddEdge)
            Next
            For Each factor In process.forward.inhibition
                Call New Edge With {
                    .U = g.GetElementByID(factor.Mass.ID),
                    .V = processNode,
                    .weight = factor.Coefficient,
                    .ID = $"{process.ID}.forward.inhibitedBy.{factor.Mass.ID}"，
                    .data = New EdgeData With {
                        .Properties = New Dictionary(Of String, String) From {
                            {NamesOf.REFLECTION_ID_MAPPING_INTERACTION_TYPE, "forward.inhibition"}
                        },
                        .label = process.ID
                    }
                }.DoCall(AddressOf g.AddEdge)
            Next
            For Each factor In process.reverse.activation
                Call New Edge With {
                    .U = g.GetElementByID(factor.Mass.ID),
                    .V = processNode,
                    .weight = factor.Coefficient,
                    .ID = $"{process.ID}.reverse.activedBy.{factor.Mass.ID}"，
                    .data = New EdgeData With {
                        .Properties = New Dictionary(Of String, String) From {
                            {NamesOf.REFLECTION_ID_MAPPING_INTERACTION_TYPE, "reverse.activation"}
                        },
                        .label = process.ID
                    }
                }.DoCall(AddressOf g.AddEdge)
            Next
            For Each factor In process.reverse.inhibition
                Call New Edge With {
                    .U = g.GetElementByID(factor.Mass.ID),
                    .V = processNode,
                    .weight = factor.Coefficient,
                    .ID = $"{process.ID}.reverse.inhibitedBy.{factor.Mass.ID}"，
                    .data = New EdgeData With {
                        .Properties = New Dictionary(Of String, String) From {
                            {NamesOf.REFLECTION_ID_MAPPING_INTERACTION_TYPE, "reverse.inhibition"}
                        },
                        .label = process.ID
                    }
                }.DoCall(AddressOf g.AddEdge)
            Next
        Next

        Return g
    End Function
End Module
