﻿Imports System.Text
Imports System.Text.RegularExpressions
Imports LANS.SystemsBiology.Assembly.RCSB.PDB.Keywords

Public Class PDB : Inherits Microsoft.VisualBasic.ComponentModel.ITextFile

    Public Const REGEX_HEAD As String = "[A-Z]+\s+(\d+)?\s"

    Public Property Header As Header
    Public Property Title As Title
    Public Property Compound As Compound
    Public Property Source As Source
    Public Property Keywords As Keywords.Keywords
    Public Property Author As Author
    Public Property Journal As Journal
    Public Property Remark As Remark
    Public Property Sequence As Sequence
    Public Property AtomStructures As Atom
        Get
            Return _atomStructuresData
        End Get
        Set(value As Atom)
            _atomStructuresData = value
            _AASeqLoader = New Microsoft.VisualBasic.ComponentModel.LazyLoader(Of AminoAcid(), Atom)(value, AddressOf AminoAcid.SequenceGenerator)
        End Set
    End Property

    Dim _atomStructuresData As Atom
    Dim _AASeqLoader As Microsoft.VisualBasic.ComponentModel.LazyLoader(Of AminoAcid(), Atom)

    Public ReadOnly Property MaxSpace As Keywords.Point3D
        Get
            Dim XLQuery = (From Atom In AtomStructures.Atoms Select Atom.Location.X).ToArray.Max
            Dim YLQuery = (From Atom In AtomStructures.Atoms Select Atom.Location.Y).ToArray.Max
            Dim ZLQuery = (From Atom In AtomStructures.Atoms Select Atom.Location.Z).ToArray.Max
            Return New Point3D With {.X = XLQuery, .Y = YLQuery, .Z = ZLQuery}
        End Get
    End Property

    Public ReadOnly Property MinSpace As Keywords.Point3D
        Get
            Dim XLQuery = (From Atom In AtomStructures.Atoms Select Atom.Location.X).ToArray.Min
            Dim YLQuery = (From Atom In AtomStructures.Atoms Select Atom.Location.Y).ToArray.Min
            Dim ZLQuery = (From Atom In AtomStructures.Atoms Select Atom.Location.Z).ToArray.Min
            Return New Point3D With {.X = XLQuery, .Y = YLQuery, .Z = ZLQuery}
        End Get
    End Property

    ''' <summary>
    ''' 已经经过了排序操作了的
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AminoAcidSequenceData As AminoAcid()
        Get
            Return _AASeqLoader.Value
        End Get
    End Property

    Protected Friend Sub New()
    End Sub

    ''' <summary>
    ''' 加载一个蛋白质的三维空间结构的数据文件
    ''' </summary>
    ''' <param name="Path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Load(Path As String) As PDB
        Dim strDatas As String() = IO.File.ReadAllLines(Path)
        Dim PDBItems = LoadDocument(strDatas)
        Dim pdbFile As PDB = New PDB

        pdbFile._Header = New Header(Keyword.GetData(Keyword.KEYWORD_HEADER, PDBItems))
        pdbFile.AtomStructures = New Atom(Keyword.GetData(Keyword.KEYWORD_ATOM, PDBItems))

        Return pdbFile
    End Function

    Public Overloads Shared Widening Operator CType(Path As String) As PDB
        Return PDB.Load(Path)
    End Operator

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>{Head, value}</remarks>
    Public Shared Function LoadDocument(strDataLines As String()) As KeyValuePair(Of String, String)()
        Dim LQuery = (From strData As String In strDataLines.AsParallel
                      Let head As String = Regex.Match(strData, REGEX_HEAD).Value
                      Let value As String = Mid(strData, Len(head) + 1).Trim
                      Let item = New KeyValuePair(Of String, String)(head, value)
                      Where Not String.IsNullOrEmpty(head)
                      Select item
                      Order By item.Key Ascending).ToArray
        Return LQuery
    End Function

    Public Overrides Function Save(Optional FilePath As String = "", Optional Encoding As Encoding = Nothing) As Boolean
        Throw New NotImplementedException()
    End Function
End Class