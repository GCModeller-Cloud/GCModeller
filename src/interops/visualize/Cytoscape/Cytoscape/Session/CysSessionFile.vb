﻿Imports Microsoft.VisualBasic.ApplicationServices.Zip
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MIME.application.xml
Imports SMRUCC.genomics.Visualize.Cytoscape.CytoscapeGraphView.XGMML.File

Namespace Session

    '<XmlRoot("graph", [Namespace]:="http://www.cs.rpi.edu/XGMML")>
    'Public Class NetworkCollection

    '    <XmlAttribute> Public Property id As String
    '    <XmlAttribute> Public Property label As String

    '    Public Property att As att

    '    <XmlNamespaceDeclarations()>
    '    Public xmlns As XmlSerializerNamespaces

    '    Sub New()
    '        xmlns = New XmlSerializerNamespaces

    '        xmlns.Add("cy", XGMMLgraph.xmlnsCytoscape)
    '        xmlns.Add("rdf", RDFEntity.XmlnsNamespace)
    '        xmlns.Add("xlink", "http://www.w3.org/1999/xlink")
    '        xmlns.Add("dc", XGMMLgraph.xmlns_dc)
    '    End Sub
    'End Class

    'Public Class att
    '    <XmlElement("graph")>
    '    Public Property graphs As XGMMLgraph()
    'End Class

    ''' <summary>
    ''' ``*.cys`` cytoscape session file reader model
    ''' </summary>
    Public Class CysSessionFile

        ''' <summary>
        ''' the original *.cys session file location.
        ''' </summary>
        Public ReadOnly source As String

        ReadOnly tempDir As String

        Private Sub New(tempDir As String, cys As String)
            Me.tempDir = tempDir
            Me.source = cys
        End Sub

        Public Function GetSessionInfo() As virtualColumn()
            Return ($"{tempDir}/tables/cytables.xml") _
                .LoadXml(Of cyTables) _
                .AsEnumerable _
                .ToArray
        End Function

        Public Iterator Function GetNetworks() As IEnumerable(Of NamedCollection(Of String))
            Dim xml As XmlElement
            Dim collection As String
            Dim networkNames As New List(Of String)

            For Each file As String In $"{tempDir}/networks".ListFiles("*.xgmml")
                xml = file.ReadAllText.DoCall(AddressOf XmlElement.ParseXmlText)
                collection = xml.attributes("label")
                xml = xml.getElementsByTagName("att").First

                For Each graph In xml.getElementsByTagName("graph")
                    networkNames.Add(graph.attributes("label"))
                Next

                Yield New NamedCollection(Of String) With {
                    .name = collection,
                    .value = networkNames.PopAll
                }
            Next
        End Function

        ''' <summary>
        ''' 加载一个已经具有网络布局信息的网络模型
        ''' </summary>
        ''' <returns></returns>
        Public Function GetLayoutedGraph(Optional collection$ = Nothing, Optional name$ = Nothing) As NetworkGraph
            Dim network As XGMMLgraph = combineViewAndNetwork(collection, name)
        End Function

        Private Function combineViewAndNetwork(collection$, name$) As XGMMLgraph

        End Function

        Public Shared Function Open(cys As String) As CysSessionFile
            Dim temp As String = App.GetAppSysTempFile(".zip", App.PID, "cytoscape_")

            Call UnZip.ImprovedExtractToDirectory(cys, temp, Overwrite.Always, extractToFlat:=False)

            Return New CysSessionFile(temp.ListDirectory.First, cys)
        End Function
    End Class
End Namespace