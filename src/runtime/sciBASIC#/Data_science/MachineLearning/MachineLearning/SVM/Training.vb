﻿' 
' * SVM.NET Library
' * Copyright (C) 2008 Matthew Johnson
' * 
' * This program is free software: you can redistribute it and/or modify
' * it under the terms of the GNU General Public License as published by
' * the Free Software Foundation, either version 3 of the License, or
' * (at your option) any later version.
' * 
' * This program is distributed in the hope that it will be useful,
' * but WITHOUT ANY WARRANTY; without even the implied warranty of
' * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' * GNU General Public License for more details.
' * 
' * You should have received a copy of the GNU General Public License
' * along with this program.  If not, see <http://www.gnu.org/licenses/>.



Imports System.Runtime.InteropServices
Imports stdNum = System.Math

Namespace SVM
    ''' <summary>
    ''' Class containing the routines to train SVM models.
    ''' </summary>
    Public Module Training
        ''' <summary>
        ''' Whether the system will output information to the console during the training process.
        ''' </summary>
        Public Property IsVerbose As Boolean
            Get
                Return Procedures.IsVerbose
            End Get
            Set(ByVal value As Boolean)
                Procedures.IsVerbose = value
            End Set
        End Property

        Private Function doCrossValidation(ByVal problem As Problem, ByVal parameters As Parameter, ByVal nr_fold As Integer) As Double
            Dim i As Integer
            Dim target = New Double(problem.Count - 1) {}
            svm_cross_validation(problem, parameters, nr_fold, target)
            Dim total_correct = 0
            Dim total_error As Double = 0
            Dim sumv As Double = 0, sumy As Double = 0, sumvv As Double = 0, sumyy As Double = 0, sumvy As Double = 0

            If parameters.SvmType = SvmType.EPSILON_SVR OrElse parameters.SvmType = SvmType.NU_SVR Then
                For i = 0 To problem.Count - 1
                    Dim y = problem.Y(i)
                    Dim v = target(i)
                    total_error += (v - y) * (v - y)
                    sumv += v
                    sumy += y
                    sumvv += v * v
                    sumyy += y * y
                    sumvy += v * y
                Next

                Return (problem.Count * sumvy - sumv * sumy) / (stdNum.Sqrt(problem.Count * sumvv - sumv * sumv) * stdNum.Sqrt(problem.Count * sumyy - sumy * sumy))
            Else

                For i = 0 To problem.Count - 1
                    If target(i) = problem.Y(i) Then Threading.Interlocked.Increment(total_correct)
                Next
            End If

            Return total_correct / problem.Count
        End Function

        Public Sub SetRandomSeed(ByVal seed As Integer)
            Procedures.setRandomSeed(seed)
        End Sub

        ''' <summary>
        ''' Legacy.  Allows use as if this was svm_train.  See libsvm documentation for details on which arguments to pass.
        ''' </summary>
        ''' <param name="args"></param>
        <Obsolete("Provided only for legacy compatibility, use the other Train() methods")>
        Public Sub Train(ParamArray args As String())
            Dim parameters As Parameter = Nothing
            Dim problem As Problem = Nothing
            Dim crossValidation As Boolean
            Dim nrfold As Integer
            Dim modelFilename As String = Nothing
            parseCommandLine(args, parameters, problem, crossValidation, nrfold, modelFilename)

            If crossValidation Then
                PerformCrossValidation(problem, parameters, nrfold)
            Else
                Model.Write(modelFilename, Train(problem, parameters))
            End If
        End Sub

        ''' <summary>
        ''' Performs cross validation.
        ''' </summary>
        ''' <param name="problem">The training data</param>
        ''' <param name="parameters">The parameters to test</param>
        ''' <param name="nrfold">The number of cross validations to use</param>
        ''' <returns>The cross validation score</returns>
        Public Function PerformCrossValidation(ByVal problem As Problem, ByVal parameters As Parameter, ByVal nrfold As Integer) As Double
            Dim [error] = svm_check_parameter(problem, parameters)

            If Equals([error], Nothing) Then
                Return doCrossValidation(problem, parameters, nrfold)
            Else
                Throw New Exception([error])
            End If
        End Function

        ''' <summary>
        ''' Trains a model using the provided training data and parameters.
        ''' </summary>
        ''' <param name="problem">The training data</param>
        ''' <param name="parameters">The parameters to use</param>
        ''' <returns>A trained SVM Model</returns>
        Public Function Train(ByVal problem As Problem, ByVal parameters As Parameter) As Model
            Dim [error] = svm_check_parameter(problem, parameters)

            If Equals([error], Nothing) Then
                Return svm_train(problem, parameters)
            Else
                Throw New Exception([error])
            End If
        End Function

        Private Sub parseCommandLine(ByVal args As String(), <Out> ByRef parameters As Parameter, <Out> ByRef problem As Problem, <Out> ByRef crossValidation As Boolean, <Out> ByRef nrfold As Integer, <Out> ByRef modelFilename As String)
            Dim i As Integer
            parameters = New Parameter()
            ' default values

            crossValidation = False
            nrfold = 0

            ' parse options
            For i = 0 To args.Length - 1
                If args(i)(0) <> "-"c Then Exit For
                Threading.Interlocked.Increment(i)

                Select Case args(i - 1)(1)
                    Case "s"c
                        parameters.SvmType = CType(Integer.Parse(args(i)), SvmType)
                    Case "t"c
                        parameters.KernelType = CType(Integer.Parse(args(i)), KernelType)
                    Case "d"c
                        parameters.Degree = Integer.Parse(args(i))
                    Case "g"c
                        parameters.Gamma = Double.Parse(args(i))
                    Case "r"c
                        parameters.Coefficient0 = Double.Parse(args(i))
                    Case "n"c
                        parameters.Nu = Double.Parse(args(i))
                    Case "m"c
                        parameters.CacheSize = Double.Parse(args(i))
                    Case "c"c
                        parameters.C = Double.Parse(args(i))
                    Case "e"c
                        parameters.EPS = Double.Parse(args(i))
                    Case "p"c
                        parameters.P = Double.Parse(args(i))
                    Case "h"c
                        parameters.Shrinking = Integer.Parse(args(i)) = 1
                    Case "b"c
                        parameters.Probability = Integer.Parse(args(i)) = 1
                    Case "v"c
                        crossValidation = True
                        nrfold = Integer.Parse(args(i))

                        If nrfold < 2 Then
                            Throw New ArgumentException("n-fold cross validation: n must >= 2")
                        End If

                    Case "w"c
                        parameters.Weights(Integer.Parse(args(i - 1).Substring(2))) = Double.Parse(args(1))
                    Case Else
                        Throw New ArgumentException("Unknown Parameter")
                End Select
            Next

            ' determine filenames

            If i >= args.Length Then Throw New ArgumentException("No input file specified")
            problem = Problem.Read(args(i))
            If parameters.Gamma = 0 Then parameters.Gamma = 1.0 / problem.MaxIndex

            If i < args.Length - 1 Then
                modelFilename = args(i + 1)
            Else
                Dim p = args(i).LastIndexOf("/"c) + 1
                modelFilename = args(i).Substring(p) & ".model"
            End If
        End Sub
    End Module
End Namespace
