﻿#Region "Microsoft.VisualBasic::8114877a960ffc7b2ca91679b1afa96d, treeTest.vb"

    ' Author:
    ' 
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 


    ' Source file summaries:

    ' Module treeTest
    ' 
    '     Sub: Main
    ' 
    ' 

#End Region

#Region "Microsoft.VisualBasic::9756da122d5c75de635b0950ca67a476, core.test"

    ' Author:
    ' 
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 


    ' Source file summaries:

    ' Module treeTest
    ' 
    '     Sub: Main
    ' 
    ' 

#End Region

#Region "Microsoft.VisualBasic::80a3b9fac91571dcd682961d3f81301c, core.test"

    ' Author:
    ' 
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 


    ' Source file summaries:

    ' Module treeTest
    ' 
    '     Sub: Main
    ' 
    ' 
    ' 

#End Region

Imports System.Threading
Imports Microsoft.VisualBasic.ComponentModel.DataStructures.BinaryTree

Module treeTest
    Sub Main()
        Dim tree As New BinaryTree(Of String)

        For i As Integer = 0 To 100
            Dim s = RandomASCIIString(10).MD5.Substring(0, 6)

            Thread.Sleep(10)

            Call tree.insert(s, s)
        Next


        Pause()
    End Sub
End Module


