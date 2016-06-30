﻿Imports LANS.SystemsBiology.Assembly.NCBI
Imports LANS.SystemsBiology.Assembly.NCBI.CDD
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports LANS.SystemsBiology.ComponentModel
Imports LANS.SystemsBiology.ProteinModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports System.Runtime.CompilerServices
Imports LANS.SystemsBiology.NCBI.Extensions.LocalBLAST.BLASTOutput

Namespace PfamString

    <PackageNamespace("PfamString.API")>
    Public Module API

        <ExportAPI("FromChouFasman")>
        Public Function FromChouFasman(data As DomainObject) As PfamString
            Dim struct As String = data.Identifier
            struct = Mid(struct, 2, Len(struct) - 2)
            Dim [Structure] As PfamString =
                New PfamString With {
                    .ProteinId = data.Id_Handle,
                    .Description = data.Identifier,
                    .Length = data.Position.FragmentSize,
                    .PfamString = (From i As Integer In struct.Sequence Let c As Char = struct(i) Select String.Format("{0}({1}|{2})", c.ToString, i + 1, i + 2)).ToArray}
            [Structure].Domains = (From c As Char In struct.ToArray Select CStr(c) Distinct).ToArray

            Return [Structure]
        End Function

        ''' <summary>
        '''
        ''' </summary>
        ''' <param name="strValue"></param>
        ''' <param name="normlz">一般是蛋白质的序列长度</param>
        ''' <returns></returns>
        Private Function __getDomainLDM(strValue As String, normlz As Integer) As ProteinModel.DomainObject
            Dim Loc As String = Regex.Match(strValue, "\(\d+\|\d+\)").Value
            Dim id As String = strValue.Replace(Loc, "")
            Dim lociX As Loci.Location = Loci.Location.CreateObject(Mid(Loc, 2, Len(Loc) - 2), "|")
            Dim DomainData As ProteinModel.DomainObject =
                New ProteinModel.DomainObject With {
                    .Identifier = id,
                    .Position = lociX,
                    .Location = New Loci.Position(lociX, normlz)
            }
            Return DomainData
        End Function

        Friend Function __getDomainTrace(strValue As String, normlz As Integer) As ProteinModel.DomainObject
            Try
                Return __getDomainLDM(strValue, normlz)
            Catch ex As Exception
                ex = New Exception(strValue, ex)
                Throw ex
            End Try
        End Function

        ''' <summary>
        ''' <see cref="ProteinModel.DomainObject.Identifier"/>
        ''' </summary>
        ''' <param name="token"></param>
        ''' <returns></returns>
        '''
        <ExportAPI("GET.Domain")>
        Public Function GetDomain(token As String) As ProteinModel.DomainObject
            Return __getDomainTrace(token, 1)
        End Function

        <ExportAPI("Pfam.Token"), Extension>
        Public Function ToPfamStringToken(dat As LANS.SystemsBiology.ProteinModel.DomainObject) As String
            Return String.Format("{0}({1}|{2})", dat.Identifier, dat.Position.Left, dat.Position.Right)
        End Function

        ''' <summary>
        ''' &lt;ID>:&lt;Length>:&lt;pfam-string>
        ''' </summary>
        ''' <param name="view"></param>
        ''' <returns></returns>
        '''
        <ExportAPI("Parser.CLI")>
        Public Function CLIParser(view As String) As PfamString
            Dim Tokens As String() = view.Split(":"c)
            Dim ID As String = Tokens(Scan0)
            Dim Length As Integer = CInt(Val(Tokens(1)))
            Dim Pfam As String() = Tokens(2).Split("+"c)
            Return New PfamString With {
                .ProteinId = ID,
                .Length = Length,
                .PfamString = Pfam,
                .Domains = Pfam,
                .Description = "Auto Generated Data"
            }
        End Function

        <ExportAPI("EvolgeniusView")>
        Public Sub ExportEvolgeniusView(BLASTOutput As BlastPlus.v228, SavedFile As String)
            Dim LQuery = (From Query As BlastPlus.Query
                          In BLASTOutput.Queries
                          Let item = New KeyValuePair(Of Long, Protein)(Query.QueryLength, CreateProteinDescription(Query))
                          Select item
                          Order By item.Value.Identifier Ascending).ToArray

            Dim strData As String() = (From Protein In LQuery Select GenerateData(Protein)).ToArray
            Call IO.File.WriteAllLines(SavedFile, strData)
        End Sub

        Private Function GenerateData(Protein As KeyValuePair(Of Long, Protein)) As String
            Dim sBuilder As StringBuilder = New StringBuilder(2048)
            Call sBuilder.Append(String.Format("{0}    {1} ", Protein.Value.Identifier, Protein.Key))
            For Each Domain In Protein.Value.Domains
                Call sBuilder.Append(String.Format("{0},{1},{2},Pfam-A,,,{3},{4},{5}   ", Domain.Position.Left, Domain.Position.Right, Domain.CommonName, Domain.Identifier, Domain.EValue, Domain.BitScore))
            Next

            Return sBuilder.ToString
        End Function

        <ExportAPI("Analysis"), Extension>
        Public Function Analysis(BLASTOutput As BlastPlus.v228) As Protein()
            Dim LQuery = (From Query In BLASTOutput.Queries Select CreateProteinDescription(Query)).ToArray
            Return LQuery
        End Function

        <ExportAPI("ToPfamString"), Extension>
        Public Function CreatePfamString(BLASTOutput As BlastPlus.v228) As PfamString()
            Dim LQuery = (From Query In BLASTOutput.Queries.AsParallel
                          Let Protein = CreateProteinDescription(Query)
                          Let item = New KeyValuePair(Of Long, Protein)(Query.QueryLength, Protein)
                          Select item
                          Order By item.Value.Identifier Ascending).ToArray
            Dim ChunkBuffer = (From Protein In LQuery
                               Select New PfamString With {
                                   .ProteinId = Protein.Value.Identifier,
                                   .Length = Protein.Key,
                                   .Description = Protein.Value.Description,
                                   .PfamString = CreateDistruction(Protein.Value.Domains),
                                   .Domains = CreateDomainID(Protein.Value.Domains)}).ToArray
            Return ChunkBuffer
        End Function

        <ExportAPI("GET.Domain.Ids"), Extension>
        Public Function CreateDomainID(Domains As IEnumerable(Of ProteinModel.DomainObject)) As String()
            If Domains.IsNullOrEmpty Then
                Return New String() {}
            End If

            Return (From Domain As ProteinModel.DomainObject
                    In Domains
                    Select String.Format("[{0}: {1}]({2}|{3})", Domain.CommonName, Domain.Title, Domain.Position.Left, Domain.Position.Right)).ToArray
        End Function

        <ExportAPI("GET.Distributes"), Extension>
        Public Function CreateDistruction(Domains As IEnumerable(Of ProteinModel.DomainObject)) As String()
            If Domains.IsNullOrEmpty Then
                Return New String() {}
            End If

            Return (From Domain In Domains Select String.Format("{0}({1}|{2})", Domain.Identifier, Domain.Position.Left, Domain.Position.Right)).ToArray
        End Function

        <ExportAPI("Description")>
        Public Function CreateProteinDescription(QueryIteration As BlastPlus.Query) As Protein
            Dim UniqueId As String = QueryIteration.QueryName.Split.First
            Dim Description As String

            If String.Equals(UniqueId, QueryIteration.QueryName, StringComparison.OrdinalIgnoreCase) Then
                Description = ""
            Else
                Description = Mid(QueryIteration.QueryName, Len(UniqueId) + 1).Trim
            End If

            If QueryIteration.SubjectHits.IsNullOrEmpty Then
                Return New Protein With {
                    .Identifier = UniqueId,
                    .Domains = New LANS.SystemsBiology.ProteinModel.DomainObject() {},
                    .SequenceData = "",
                    .Description = Description
                }
            Else
                Dim LQuery = From Hit As NCBI.Extensions.LocalBLAST.BLASTOutput.BlastPlus.SubjectHit
                             In QueryIteration.SubjectHits
                             Where Hit.Length / Val(Hit.LengthHit) > 0.85 AndAlso System.Math.Abs(Hit.LengthHit - Hit.LengthQuery) < 20
                             Let smp = CreateObject(Hit.Name.Replace("gnl|CDD|", ""))
                             Select New LANS.SystemsBiology.ProteinModel.DomainObject(smp) With {
                                 .Position = New ComponentModel.Loci.Location() With {
                                 .Left = Val(Hit.Hsp.First.Query.Left),
                                 .Right = Val(Hit.Hsp.Last.Query.Right)},
                                 .BitScore = Hit.Score.RawScore,
                                 .EValue = Hit.Score.Expect} '

                Dim Domains = LQuery.ToArray
                Dim Protein As New Protein With {
                    .Identifier = UniqueId,
                    .Domains = Domains,
                    .SequenceData = "",
                    .Description = Description
                }
                Return Protein
            End If
        End Function

        Private Function CreateObject(strData As String) As SmpFile
            Dim Tokens As String() = Strings.Split(strData, "|")
            Dim SmpFile As CDD.SmpFile = New SmpFile With {.Id = Tokens.First}
            Dim p As Integer = 1

            SmpFile.Identifier = Tokens.GetItem(p.MoveNext)
            SmpFile.CommonName = Tokens.GetItem(p.MoveNext)
            'SmpFile.Title = Tokens.GetItem(p.MoveNext)
            Call p.MoveNext()
            SmpFile.Describes = Tokens.GetItem(p.MoveNext)
            SmpFile.Title = SmpFile.Describes

            Return SmpFile
        End Function
    End Module
End Namespace