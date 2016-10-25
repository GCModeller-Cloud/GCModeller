' *****************************************************************************
' Copyright 2012 Yuriy Lagodiuk
' 
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
' 
'   http://www.apache.org/licenses/LICENSE-2.0
' 
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions and
' limitations under the License.
' *****************************************************************************

Imports Microsoft.VisualBasic.DataMining.GAF.Helper
Imports Microsoft.VisualBasic.Linq

Namespace GAF

    Public Class GeneticAlgorithm(Of C As Chromosome(Of C), T As IComparable(Of T))

        Const ALL_PARENTAL_CHROMOSOMES As Integer = Integer.MaxValue

        ReadOnly _chromosomesComparator As ChromosomesComparator(Of C, T)
        Friend ReadOnly _fitnessFunc As Fitness(Of C, T)

        ''' <summary>
        ''' listeners of genetic algorithm iterations (handle callback afterwards)
        ''' </summary>
        ReadOnly iterationListeners As New List(Of IterartionListener(Of C, T))

        Dim _terminate As Boolean = False

        Public Sub New(population As Population(Of C), fitnessFunc As Fitness(Of C, T))
            Me._Population = population
            Me._fitnessFunc = fitnessFunc
            Me._chromosomesComparator = New ChromosomesComparator(Of C, T)(Me)
            Me._Population.SortPopulationByFitness(_chromosomesComparator)
        End Sub

        Public Sub Evolve()
            Dim parentPopulationSize As Integer = Population.Size
            Dim newPopulation As New Population(Of C)()
            Dim i As Integer = 0

            Do While (i < parentPopulationSize) AndAlso (i < ParentChromosomesSurviveCount)
                newPopulation.Add(Population(i)) ' �ɵ�ԭ�е���Ⱥ
                i += 1
            Loop

            ' �µ�ͻ�����Ⱥ
            For Each c As C In parentPopulationSize% _
                .Sequence _
                .AsParallel _
                .Select(AddressOf __iterate) _
                .IteratesALL ' ���л�����ÿһ��ͻ�����

                Call newPopulation.Add(c)
            Next

            newPopulation.SortPopulationByFitness(_chromosomesComparator)  ' ͨ��fitness��������������
            newPopulation.Trim(parentPopulationSize)                       ' ���õ�����Ķ��󣬴ﵽ��̭��Ч��
            _Population = newPopulation                                    ' ����Ⱥ����ɵ���Ⱥ
        End Sub

        ''' <summary>
        ''' ���л�����֮�еĵ�������
        ''' </summary>
        ''' <param name="i%"></param>
        ''' <returns></returns>
        Private Iterator Function __iterate(i%) As IEnumerable(Of C)
            Dim chromosome As C = Population(i)
            Dim mutated As C = chromosome.Mutate()   ' ͻ��
            Dim rnd As New Random
            Dim otherChromosome As C = Population.Random(rnd)  ' ͻ�����������������ӽ�
            Dim crossovered As IList(Of C) = mutated.Crossover(otherChromosome) ' chromosome.Crossover(otherChromosome)

            ' --------- ���޸ĵ�
            otherChromosome = Population.Random(rnd)
            crossovered = crossovered.Join(chromosome.Crossover(otherChromosome))
            ' ---------

            Yield mutated

            For Each c As C In crossovered
                Yield c
            Next
        End Function

        Public Sub Evolve(count As Integer)
            _terminate = False

            For i As Integer = 0 To count - 1
                If _terminate Then
                    Exit For
                End If

                Call Evolve()
                _Iteration = i

                For Each l As IterartionListener(Of C, T) In iterationListeners
                    Call l.Update(Me)
                Next
            Next
        End Sub

        Public ReadOnly Property Iteration As Integer

        Public Sub Terminate()
            Me._terminate = True
        End Sub

        Public ReadOnly Property Population As Population(Of C)

        Public ReadOnly Property Best As C
            Get
                Return Population(0)
            End Get
        End Property

        Public ReadOnly Property Worst As C
            Get
                Return Population(Population.Size - 1)
            End Get
        End Property

        ''' <summary>
        ''' Number of parental chromosomes, which survive (and move to new
        ''' population)
        ''' </summary>
        ''' <returns></returns>
        Public Property ParentChromosomesSurviveCount As Integer = ALL_PARENTAL_CHROMOSOMES

        Public Sub addIterationListener(listener As IterartionListener(Of C, T))
            Me.iterationListeners.Add(listener)
        End Sub

        Public Sub removeIterationListener(listener As IterartionListener(Of C, T))
            iterationListeners.Remove(listener)
        End Sub

        Public Function Fitness(chromosome As C) As T
            Return _chromosomesComparator.fit(chromosome)
        End Function

        ''' <summary>
        ''' Clear the internal cache
        ''' </summary>
        Public Sub Clear()
            _chromosomesComparator.clearCache()
        End Sub
    End Class
End Namespace