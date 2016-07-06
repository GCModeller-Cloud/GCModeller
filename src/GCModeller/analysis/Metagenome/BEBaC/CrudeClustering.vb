﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Parallel.Linq

Namespace BEBaC

    Public Module CrudeClustering

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="s"></param>
        ''' <param name="kmax"></param>
        ''' <param name="n">原始输入的序列的总数</param>
        ''' <returns></returns>
        <Extension>
        Public Iterator Function RandomClustering(s As IEnumerable(Of I3merVector), kmax As Integer, n As Integer) As IEnumerable(Of Cluster)
            For Each x As I3merVector() In TaskPartitions.SplitIterator(s, n / kmax)
                Yield New Cluster With {
                    .members = New List(Of I3merVector)(x)
                }
            Next
        End Function

        ''' <summary>
        ''' Apply each of the four search operators described below
        ''' to the the current partition S in a random order. Then, if
        ''' the resulting partition leads To a higher marginal likelihood, 
        ''' update the current partition S, otherwise keep
        ''' the current partition. If all operators fail To update the
        ''' current partition, then Stop And Set the best partition S'
        ''' as the current partition S.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' + In a random order relocate all vectors in a pregroup
        '''   to another cluster that leads to the maximal increase
        '''   in the marginal likelihood. The option of moving vectors 
        '''   into an empty cluster is also considered, unless the 
        '''   total number Of clusters exceeds Kmax.
        ''' + In a random order, merge the two clusters which leads 
        '''   to the maximum increase in the marginal likelihood. 
        '''   This operator considers also merging of singleton clusters
        '''   (only one pregroup in the cluster) that might be generated 
        '''   by the other operators.
        ''' + In a random order, split each cluster into two subclusters 
        '''   using complete linkage clustering algorithm, where the 
        '''   distance between two pregroups are calculated As the average 
        '''   linear correlation coefficient between vectors In the two 
        '''   pregroups. Then Try reassigning Each subcluster To another 
        '''   cluster including empty clusters. Choose the split And 
        '''   reassignment that leads To the maximal increase In the 
        '''   marginal likelihood(5).
        ''' + In a random order, split each cluster into m subclusters 
        '''   using complete linkage clustering algorithm as described 
        '''   in operator (iii), where m=min(20, nPregroup/5) And 
        '''   nPregroup Is the total number Of pregroups In the cluster. 
        '''   Then Try to reassign each subcluster to another cluster; 
        '''   choose the split And reassignment that leads To the maximal 
        '''   increase In the marginal likelihood.
        ''' </remarks>
        Public Function StochasticSearch()

        End Function
    End Module

    Public Class I3merVector : Inherits ClassObject
        Public Property Name As String
        Public Property Vector As Dictionary(Of I3Mers, Integer)
    End Class

    Public Class Cluster

        Public Property members As List(Of I3merVector)

        Public Function PartitionProbability() As Double
            Return members.PartitionProbability
        End Function
    End Class
End Namespace