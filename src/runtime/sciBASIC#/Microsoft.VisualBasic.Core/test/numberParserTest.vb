﻿Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Module numberParserTest

    Sub Main()
        Dim dbl1 = "-4.6465E+465"
        Dim dbl2 = "553453453445"
        Dim dbl3 = ".423423"
        Dim dbl4 = "+.364534e53"
        Dim invalidDbl = "244.24.234"

        Call Console.WriteLine(IsDoubleNumber(dbl1))
        Call Console.WriteLine(IsDoubleNumber(dbl2))
        Call Console.WriteLine(IsDoubleNumber(dbl3))
        Call Console.WriteLine(IsDoubleNumber(dbl4))
        Call Console.WriteLine(IsDoubleNumber(invalidDbl))


        Dim int1 = "654646"
        Dim int2 = "+5453"
        Dim int3 = "-3434534"
        Dim invalidInt = "-3E-10"

        Call Console.WriteLine(IsInteger(int1))
        Call Console.WriteLine(IsInteger(int2))
        Call Console.WriteLine(IsInteger(int3))
        Call Console.WriteLine(IsInteger(invalidInt))


        Call New Action(AddressOf testInt).BENCHMARK
        Call New Action(AddressOf testInt2).BENCHMARK

        Pause()
    End Sub

    Private Sub testInt2()
        Dim test As Boolean

        For i As Integer = 0 To 100000000
            test = Regex.Match("234234233", "\d+").Success = "234234233"
        Next
    End Sub

    Private Sub testInt()
        Dim test As Boolean

        For i As Integer = 0 To 100000000
            test = IsInteger("234234233")
        Next
    End Sub

    <Extension>
    Public Function IsDoubleNumber(num As String) As Boolean
        Dim dotCheck As Boolean = False
        Dim c As Char = num(Scan0)
        Dim offset As Integer = 0

        If c = "-"c OrElse c = "+"c Then
            ' check for number sign symbol
            '
            ' +3.0
            ' -3.0
            offset = 1
        ElseIf c = "."c Then
            ' check for 
            ' 
            ' .1 (0.1)
            offset = 1
            dotCheck = True
        End If

        For i As Integer = offset To num.Length - 1
            c = num(i)

            If Not (c >= ZERO AndAlso c <= NINE) Then
                If c = "."c Then
                    If dotCheck Then
                        Return False
                    Else
                        dotCheck = True
                    End If
                ElseIf c = "E"c OrElse c = "e"c Then
                    Return IsInteger(num, i + 1)
                End If
            End If
        Next

        Return True
    End Function

    Const ZERO As Char = "0"c
    Const NINE As Char = "9"c

    Public Function IsInteger(num As String, Optional offset As Integer = 0) As Boolean
        Dim c As Char = num(Scan0)

        ' check for number sign symbol
        If c = "-"c OrElse c = "+"c Then
            offset += 1
        End If

        For i As Integer = offset To num.Length - 1
            c = num(i)

            If Not (c >= ZERO AndAlso c <= NINE) Then
                Return False
            End If
        Next

        Return True
    End Function
End Module
