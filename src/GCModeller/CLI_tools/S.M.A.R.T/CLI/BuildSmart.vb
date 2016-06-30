﻿Imports LANS.SystemsBiology.AnalysisTools.ProteinTools.Family.FileSystem
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.Linq.Extensions

Partial Module CLI

    <ExportAPI("-buildsmart")>
    Public Function BuildSmart(CommandLine As Microsoft.VisualBasic.CommandLine.CommandLine) As Integer
        Call Console.WriteLine("BuildSmart [version {0}]" & vbCrLf & "Program for build smart analysis database." & vbCrLf, My.Application.Info.Version.ToString)

        Call Console.WriteLine("Input the CDD source directory:")
        Call Console.Write("> ")
        Dim Dir As String

READ_CDD_DIR:
        Dir = Console.ReadLine
        If Not FileIO.FileSystem.DirectoryExists(Dir) Then
            Call Console.Write("The specific directory is not exists on the file system, try again:" & vbCrLf & "> ")
            GoTo READ_CDD_DIR
        End If

        Call Console.WriteLine("Input the CDD database output directory:")
        Call Console.Write("> ")

        Dim ExportDir As String = Console.ReadLine

        Call FileIO.FileSystem.CreateDirectory(Dir)
        Call LANS.SystemsBiology.Assembly.NCBI.CDD.DbFile.BuildDb(Dir, ExportDir)

        Return 0
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("--Export.Domains", Usage:="--Export.Domains /in <pfam-string.csv>")>
    Public Function ExportRegpreciseDomains(args As CommandLine.CommandLine) As Integer
        Dim input = args("/in").LoadCsv(Of Sanger.Pfam.PfamString.PfamString)
        Dim Domains = (From x As Sanger.Pfam.PfamString.PfamString
                       In input
                       Where Not StringHelpers.IsNullOrEmpty(x.Domains)
                       Select x.Domains.ToArray(Function(name) name.Split(":"c).First)).ToArray.MatrixToList.Distinct.ToArray

        Domains = (From name As String In Domains Select name Order By name Ascending).ToArray

        Dim Pfam = New LANS.SystemsBiology.Assembly.NCBI.CDD.Database(GCModeller.FileSystem.RepositoryRoot & "/CDD/").DomainInfo.Pfam
        Dim DomainPn = Domains.ToArray(Function(x) Pfam(x))

        Return DomainPn.SaveTo(args("/in").TrimFileExt & "-Domain.Pn.csv")
    End Function

    ''' <summary>
    ''' 建立蛋白质家族数据库
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("--Family.Domains", Usage:="--Family.Domains /regprecise <regulators.fasta> /pfam <pfam-string.csv>",
               Info:="Build the Family database for the protein family annotation by MPAlignment.")>
    Public Function FamilyDomains(args As CommandLine.CommandLine) As Integer
        Dim inFile As String = args("/regprecise")
        Dim regprecise = LANS.SystemsBiology.DatabaseServices.Regprecise.FastaReaders.Regulator.LoadDocument(inFile).ToDictionary(Function(x) x.KEGG)
        Dim pfam = args("/pfam").LoadCsv(Of Sanger.Pfam.PfamString.PfamString)
        Dim FamilyDb = Family.API.FamilyDomains(regprecise, pfam)
        Dim Name As String = IO.Path.GetFileNameWithoutExtension(inFile)
        Return Family.SaveRepository(FamilyDb, Name).CLICode
    End Function

    ''' <summary>
    ''' 手工建立家族数据库
    ''' </summary>
    ''' <returns></returns>
    ''' 
    <ExportAPI("--manual-Build", Usage:="--manual-Build /pfam-string <pfam-string.csv> /name <familyName>")>
    Public Function ManualBuild(args As CommandLine.CommandLine) As Integer
        Dim PfamString = args("/pfam-string").LoadCsv(Of Sanger.Pfam.PfamString.PfamString)
        Dim Name As String = args("/name")
        Dim result = New Family.FileSystem.Database().ManualAdd(Name, PfamString)
        Call $"Add new database {result.ToFileURL}...".__DEBUG_ECHO
        Return 0
    End Function

    ''' <summary>
    ''' 使用MPAlignment方法进行家族注释
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("--Family.Align", Usage:="--Family.Align /query <pfam-string.csv> [/threshold 0.65 /mp 0.65 /Name <null>]",
               Info:="Family Annotation by MPAlignment")>
    <ParameterInfo("/Name", True,
                          Description:="The database name of the aligned subject, if this value is empty or not exists in the source, then the entired Family database will be used.")>
    Public Function FamilyClassify(args As CommandLine.CommandLine) As Integer
        Dim Query = args("/query").LoadCsv(Of Sanger.Pfam.PfamString.PfamString)
        Dim Threshold As Double = args.GetValue("/threshold", 0.65)
        Dim MpTh As Double = args.GetValue("/mp", 0.65)
        Dim Name As String = args("/Name")
        Dim result = Family.FamilyAlign(Query, Threshold, MpTh, DbName:=Name)
        Dim path As String = If(String.IsNullOrEmpty(Name),
            args("/query").TrimFileExt & ".Family.Csv",
            $"{args("/query").TrimFileExt}__vs.{Name}.Family.Csv")
        Return result.SaveTo(path).CLICode
    End Function

    <ExportAPI("--Family.Stat", Usage:="--Family.Stat /in <anno_out.csv>")>
    Public Function FamilyStat(args As CommandLine.CommandLine) As Integer
        Dim input As String = args("/in")
        Dim out = Family.FamilyStat(input.LoadCsv(Of Family.AnnotationOut))
        Return out.Save(input.TrimFileExt & ".FamilyStat.csv", System.Text.Encoding.ASCII)
    End Function
End Module