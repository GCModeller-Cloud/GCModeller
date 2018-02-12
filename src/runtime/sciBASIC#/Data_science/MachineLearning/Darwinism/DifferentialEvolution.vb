﻿#Region "Microsoft.VisualBasic::156f7241766307b5e965b6826c723c38, Data_science\MachineLearning\Darwinism\DifferentialEvolution.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:

    '     Interface IIndividual
    ' 
    '         Function: Yield
    ' 
    '         Sub: Put
    ' 
    '     Module DifferentialEvolution
    ' 
    '         Function: RMS
    '         Delegate Function
    ' 
    '             Function: __subPopulationEvolute, Evolution, GetPopulation
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.TagData
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MachineLearning.Darwinism
Imports Microsoft.VisualBasic.MachineLearning.Darwinism.GAF.Helper.ListenerHelper
Imports Microsoft.VisualBasic.MachineLearning.Darwinism.Models
Imports Microsoft.VisualBasic.Math

Namespace Darwinism

    Public Interface IIndividual : Inherits Chromosome(Of IIndividual), ICloneable
        Function Yield(i%) As Double
        Sub Put(i%, value#)
    End Interface

    ''' <summary>
    ''' In evolutionary computation, differential evolution (DE) is a method that optimizes a problem by 
    ''' iteratively trying to improve a candidate solution with regard to a given measure of quality. 
    ''' Such methods are commonly known as metaheuristics as they make few or no assumptions about the 
    ''' problem being optimized and can search very large spaces of candidate solutions. However, 
    ''' metaheuristics such as DE do not guarantee an optimal solution is ever found.
    ''' 
    ''' DE Is used For multidimensional real-valued functions but does Not use the gradient Of the problem 
    ''' being optimized, which means DE does Not require For the optimization problem To be differentiable 
    ''' As Is required by classic optimization methods such As gradient descent And quasi-newton methods. 
    ''' DE can therefore also be used On optimization problems that are Not even continuous, are noisy, 
    ''' change over time, etc.[1]
    ''' 
    ''' DE optimizes a problem by maintaining a population Of candidate solutions And creating New candidate 
    ''' solutions by combining existing ones according To its simple formulae, And Then keeping whichever 
    ''' candidate solution has the best score Or fitness On the optimization problem at hand. In this way 
    ''' the optimization problem Is treated As a black box that merely provides a measure Of quality given 
    ''' a candidate solution And the gradient Is therefore Not needed.
    ''' 
    ''' DE Is originally due To Storn And Price.[2][3] Books have been published On theoretical And practical 
    ''' aspects Of Using DE In parallel computing, multiobjective optimization, constrained optimization, 
    ''' And the books also contain surveys of application areas.[4][5][6][7] Excellent surveys on the 
    ''' multi-faceted research aspects of DE can be found in journal articles Like.[8][9]
    ''' </summary>
    Public Module DifferentialEvolution

        Public Function RMS(a#(), b#()) As Double
            Dim sum#
            Dim n% = a.Length

            For i As Integer = 0 To n - 1
                sum += (a(i) - b(i)) ^ 2
            Next

            Return Math.Sqrt(sum)
        End Function

        Public Delegate Function [New](Of Individual As IIndividual)(seed As Random) As Individual

        ''' <summary>
        ''' Initialize population with individuals that have been initialized with uniform random noise
        ''' uniform noise means random value inside your search space
        ''' </summary>
        ''' <param name="__new"></param>
        ''' <param name="PopulationSize%"></param>
        ''' <returns></returns>
        ''' 
        <Extension>
        Public Function GetPopulation(Of Individual As IIndividual)(
                                              __new As [New](Of Individual),
                                              Optional PopulationSize% = 20,
                                              Optional randomGenerator As IRandomSeeds = Nothing) As List(Of Individual)

            Dim population As New List(Of Individual)
            Dim rand As Random = If(
                randomGenerator Is Nothing,
                New Random,
                randomGenerator())

            For i As Integer = 0 To PopulationSize - 1
                population += __new(seed:=rand)
            Next

            Return population
        End Function

        Const MaxIteratesReach$ = "Max iterates number was reached, Darwinism.DE fitting loop exit..."

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <typeparam name="Individual"></typeparam>
        ''' <param name="target"></param>
        ''' <param name="[new]">How to creates a new <typeparamref name="Individual"/></param>
        ''' <param name="N%">dimensionality of problem, means how many variables problem has.</param>
        ''' <param name="threshold#"></param>
        ''' <param name="maxIterations%"></param>
        ''' <param name="F">differential weight [0,2]</param>
        ''' <param name="CR">crossover probability [0,1]</param>
        ''' <param name="PopulationSize%"></param>
        ''' <returns></returns>
        Public Function Evolution(Of Individual As IIndividual)(
                                         target As Func(Of Individual, Double),
                                          [new] As [New](Of Individual),
                                           N%,
                                         Optional F# = 1,
                                         Optional CR# = 0.5,
                                         Optional threshold# = 0.1,
                                         Optional maxIterations% = 500000,
                                         Optional PopulationSize% = 20,
                                         Optional iteratePrints As Action(Of outPrint) = Nothing,
                                         Optional parallel As Boolean = False,
                                         Optional randomGenerator As IRandomSeeds = Nothing) As Individual

            ' linked list that has our population inside

            Dim bestFit# = Integer.MaxValue
            Dim fitnessFunction As Func(Of Individual, Double) =
                AddressOf New FitnessPool(Of Individual, Double)(target).Fitness
            Dim i As int = Scan0

            If randomGenerator Is Nothing Then
                randomGenerator = Function() New Random
            End If

            Dim random As Random = randomGenerator()
            Dim population As Individual() = [new] _
                .GetPopulation(PopulationSize, randomGenerator) _
                .ToArray

            ' main loop of evolution.
            If parallel Then
                Dim parts% = PopulationSize / App.CPUCoreNumbers

                Call $"Differential Evolution kernel have {App.CPUCoreNumbers}(=> {PopulationSize}/{parts}) CPU core for parallel computing.".Warning

                Do While (++i < maxIterations)
                    Dim subPopulates As Individual()() = population.Split(parts)
                    Dim LQuery = LinqAPI.Exec(Of DoubleTagged(Of Individual())) <=
 _
                        From subPop As Individual()
                        In subPopulates.AsParallel
                        Select subPop.__subPopulationEvolute(
                            bestFit:=bestFit,
                            CR:=CR,
                            F:=F,
                            fitnessFunction:=fitnessFunction,
                            iteratePrints:=iteratePrints,
                            iterates:=i,
                            N:=N,
                            randomGenerator:=randomGenerator)

                    bestFit = LQuery.Min(Function(x) x.Tag)
                    population = LQuery _
                        .Select(Function(x) x.value) _
                        .IteratesALL _
                        .Shuffles

                    If bestFit <= threshold Then
                        Call MaxIteratesReach.Warning
                        Exit Do
                    Else
                        Call Console.Write(".")
                    End If
                Loop

            Else

                Do While (++i < maxIterations)
                    Dim iter As DoubleTagged(Of Individual()) =
                        population.__subPopulationEvolute(
                        F:=F,
                        bestFit:=bestFit,
                        CR:=CR,
                        fitnessFunction:=fitnessFunction,
                        iteratePrints:=iteratePrints,
                        iterates:=i,
                        N:=N,
                        randomGenerator:=randomGenerator)

                    bestFit = iter.Tag

                    If bestFit <= threshold Then
                        Call MaxIteratesReach.Warning
                        Exit Do
                    Else
                        Call Console.Write(".")
                    End If
                Loop
            End If

            ' find best candidate solution
            Dim bestFitness As Individual = [new](random)
            i = 0
            Do While (++i < PopulationSize)
                Dim candidate As Individual = population(i.value - 1)
                If (fitnessFunction(bestFitness) > fitnessFunction(candidate)) Then
                    bestFitness = candidate
                End If
            Loop

            ' Returns your solution
            Return bestFitness
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <typeparam name="Individual"></typeparam>
        ''' <param name="population"></param>
        ''' <param name="F#"></param>
        ''' <param name="N%"></param>
        ''' <param name="CR#"></param>
        ''' <param name="bestFit#"></param>
        ''' <param name="iterates%">i</param>
        ''' <param name="iteratePrints"></param>
        ''' <param name="fitnessFunction"></param>
        ''' <returns></returns>
        <Extension>
        Private Function __subPopulationEvolute(Of Individual As IIndividual)(
                                                   population As Individual(),
                                                   F#, N%, CR#,
                                                   bestFit#,
                                                   iterates%,
                                                iteratePrints As Action(Of outPrint),
                                              fitnessFunction As Func(Of Individual, Double),
                                              randomGenerator As IRandomSeeds) As DoubleTagged(Of Individual())
            Dim random As Random = randomGenerator()
            Dim populationSize% = population.Length

            For i As Integer = 0 To populationSize - 1
                ' calculate New candidate solution

                ' pick random point from population
                Dim x = Math.Floor(random.NextDouble * (populationSize - 1))
                Dim a, b, c As Integer

                ' pick three different random points from population
                Do While (a = x)
                    a = Math.Floor(random.NextDouble * (populationSize - 1))
                Loop
                Do While (b = x OrElse b = a)
                    b = Math.Floor(random.NextDouble * (populationSize - 1))
                Loop
                Do While (c = x OrElse c = a OrElse c = b)
                    c = Math.Floor(random.NextDouble * (populationSize - 1))
                Loop

                ' Pick a random index [0-Dimensionality]
                Dim R = random.Next(N)

                ' Compute the agent's new position
                Dim original As Individual = population(x)
                Dim candidate As Individual = DirectCast(original.Clone, Individual)

                Dim individual1 As Individual = population(a)
                Dim individual2 As Individual = population(b)
                Dim individual3 As Individual = population(c)

                ' if(i==R | i<CR)
                ' candidate=a+f*(b-c)
                ' else
                ' candidate=x
                If random.NextDouble < CR Then
                    ' 当群体内的染色体全部都是一样的参数的时候，在这里会无法产生突变
                    ' 所以需要在这里添加一个随机数来解决这个问题
                    ' 假设数量级很大的话，这里是否需要通过log10来取指数进行突变？
                    'Dim raw = individual1.Yield(R)
                    'Dim mutate# = Math.Log10(Math.Abs(raw)) + F * (Math.Log10(Math.Abs(individual2.Yield(R))) - Math.Log10(Math.Abs(individual3.Yield(R))))
                    'mutate = raw + If(random.NextBoolean, 1, -1) * 10 ^ mutate
                    Dim mutate# = individual1.Yield(R) + F * (individual2.Yield(R) - individual3.Yield(R))
                    mutate *= random.NextDouble
                    Call candidate.Put(R, mutate)
                End If ' else isn't needed because we cloned original to candidate

                ' see if Is better than original, if so replace
                Dim originalFitness# = fitnessFunction(original)
                Dim candidateFitness# = fitnessFunction(candidate)

                If (originalFitness > candidateFitness) Then
                    population(x) = candidate

                    If bestFit > candidateFitness Then
                        bestFit = candidateFitness

                        Dim out As New outPrint With {
                            .fit = bestFit,
                            .chromosome = candidate.ToString,
                            .iter = iterates
                        }
                        If Not iteratePrints Is Nothing Then
                            SyncLock iteratePrints
                                Call iteratePrints(out)
                            End SyncLock
#Const DEBUG = 1
#If DEBUG Then
                            Call Console.WriteLine(out.ToString)
#End If
                        Else
                            Call Console.WriteLine(out.ToString)
                        End If
                    End If
                End If
            Next

            Return New DoubleTagged(Of Individual()) With {
                .Tag = bestFit,
                .value = population
            }
        End Function
    End Module
End Namespace
