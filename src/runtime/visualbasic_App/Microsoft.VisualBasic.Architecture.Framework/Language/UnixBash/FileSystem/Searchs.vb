﻿Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Language.UnixBash

    Public Module FileSystemAPI

        ''' <summary>
        ''' ls -l -ext("*.xml") &lt;= DIR,  The filesystem search proxy
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property ls As New Search
        ''' <summary>
        ''' Long name(DIR+fiename), if not only file name.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property l As New SearchOpt(SearchOpt.Options.LongName)
        ''' <summary>
        ''' 递归的搜索
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property r As New SearchOpt(SearchOpt.Options.Recursive)
        ''' <summary>
        ''' Searching the directory, if this parameter is not presents, then returns search file.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property lsDIR As New SearchOpt(SearchOpt.Options.Directory)

        ''' <summary>
        ''' 可以使用这个来限定文件或者文件夹对象的搜索范围
        ''' </summary>
        ''' <param name="__wildcards">可以为文件拓展或者对文件名的通配符的表达式，假若这个是空的，则会默认搜索所有文件*.*</param>
        ''' <returns></returns>
        Public Function wildcards(ParamArray __wildcards As String()) As SearchOpt
            Dim opt As New SearchOpt(SearchOpt.Options.Ext)

            If __wildcards.IsNullOrEmpty Then
                __wildcards = {"*.*"}
            End If

            For Each s As String In __wildcards
                Call opt.wildcards.Add(s)
            Next

            Return opt
        End Function

        Public Function DIRHandle(res As String) As Integer
            Return OpenHandle(res)
        End Function
    End Module

    Public Class Search : Implements ICloneable

        Dim __opts As New Dictionary(Of SearchOpt.Options, SearchOpt)

        Public Overrides Function ToString() As String
            Return __opts.GetJson
        End Function

        Public Function Clone() As Object Implements ICloneable.Clone
            Return New Search With {
                .__opts = New Dictionary(Of SearchOpt.Options, SearchOpt)(__opts)
            }
        End Function

        ''' <summary>
        ''' Add a search options
        ''' </summary>
        ''' <param name="ls"></param>
        ''' <param name="l"></param>
        ''' <returns></returns>
        Public Shared Operator -(ls As Search, l As SearchOpt) As Search
            If l.opt <> SearchOpt.Options.None Then
                Dim clone As Search = DirectCast(ls.Clone, Search)
                Call clone.__opts.Add(l.opt, l)
                Return clone
            Else
                Return ls
            End If
        End Operator

        Public ReadOnly Property SearchType As FileIO.SearchOption
            Get
                Dim opt As FileIO.SearchOption = FileIO.SearchOption.SearchTopLevelOnly
                If __opts.ContainsKey(SearchOpt.Options.Recursive) Then
                    Return FileIO.SearchOption.SearchAllSubDirectories
                Else
                    Return opt
                End If
            End Get
        End Property

        Public ReadOnly Property wildcards As String()
            Get
                If Not __opts.ContainsKey(SearchOpt.Options.Ext) Then
                    Return Nothing
                Else
                    Return __opts(SearchOpt.Options.Ext).wildcards.ToArray
                End If
            End Get
        End Property

        ''' <summary>
        ''' Search the files in the specific directory
        ''' </summary>
        ''' <param name="ls"></param>
        ''' <param name="DIR"></param>
        ''' <returns></returns>
        Public Shared Operator <<(ls As Search, DIR As Integer) As IEnumerable(Of String)
            Dim url As String = __getHandle(DIR).FileName
            Return ls < url
        End Operator

        ''' <summary>
        ''' Search the files in the specific directory
        ''' </summary>
        ''' <param name="ls"></param>
        ''' <param name="DIR"></param>
        ''' <returns></returns>
        Public Shared Operator <(ls As Search, DIR As String) As IEnumerable(Of String)
            Return ls <= DIR
        End Operator

        ''' <summary>
        ''' Search the files in the specific directory
        ''' </summary>
        ''' <param name="ls"></param>
        ''' <param name="DIR"></param>
        ''' <returns></returns>
        Public Overloads Shared Operator <=(ls As Search, DIR As String) As IEnumerable(Of String)
            Dim l As Boolean = ls.__opts.ContainsKey(SearchOpt.Options.LongName)

            If ls.__opts.ContainsKey(SearchOpt.Options.Directory) Then
                Dim res As IEnumerable(Of String) = FileIO.FileSystem.GetDirectories(DIR, ls.SearchType, ls.wildcards)

                If l Then
                    Return res
                Else
                    Return res.ToArray(Function(s) s.BaseName)
                End If
            Else
                Dim res As IEnumerable(Of String) = FileIO.FileSystem.GetFiles(DIR, ls.SearchType, ls.wildcards)

                If l Then
                    Return res
                Else
                    Return (From path As String In res Select path.Replace("\", "/").Split("/"c).Last).ToArray
                End If
            End If
        End Operator

        Public Shared Operator >(ls As Search, DIR As String) As IEnumerable(Of String)
            Throw New NotSupportedException
        End Operator

        Public Shared Operator >=(ls As Search, DIR As String) As IEnumerable(Of String)
            Throw New NotSupportedException
        End Operator
    End Class

    Public Structure SearchOpt

        Dim opt As Options
        Dim value As String
        Dim wildcards As List(Of String)

        Sub New(opt As Options, s As String)
            Me.opt = opt
            Me.value = s
            Me.wildcards = New List(Of String)
        End Sub

        Sub New(opt As Options)
            Call Me.New(opt, "")
        End Sub

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        Public Enum Options
            None
            Ext
            LongName
            ''' <summary>
            ''' List directories, not files listing.
            ''' </summary>
            Directory
            ''' <summary>
            ''' 递归搜索所有的文件夹
            ''' </summary>
            Recursive
        End Enum
    End Structure
End Namespace