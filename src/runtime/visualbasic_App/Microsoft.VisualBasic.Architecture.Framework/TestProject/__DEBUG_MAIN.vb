﻿#Region "Microsoft.VisualBasic::de9a141b17421c8e48ef70e5c7a0219b, ..\visualbasic_App\Microsoft.VisualBasic.Architecture.Framework\TestProject\__DEBUG_MAIN.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2016 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports System.Drawing
Imports System.Runtime.Serialization
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps
Imports Microsoft.VisualBasic.ComponentModel.Settings.Inf
Imports Microsoft.VisualBasic.Extensions
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash
Imports Microsoft.VisualBasic.Linq
'Imports Microsoft.VisualBasic.MemoryDump
Imports Microsoft.VisualBasic.Net
Imports Microsoft.VisualBasic.Scripting
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Terminal
'Imports Microsoft.VisualBasic.Webservices

Module __DEBUG_MAIN

    <ParameterInfo("", True, AcceptTypes:={GetType(String), GetType(Boolean), GetType(NamedValue(Of Double))})>
    Private Sub TestExtensionProperty()
        Dim x As New ClassObject
        Dim n As Long = x.Uid  ' The init value is zero

        Call n.__DEBUG_ECHO

        ' Assign value to this extension property
        x.Uid.value = RandomDouble() * 1000000000000L

        ' display the extension property value
        Call x.Uid.__DEBUG_ECHO
        Call Pause()

        Call RunApp("F:\VisualBasic_AppFramework\Microsoft.VisualBasic.Architecture.Framework\TestProject\Test2\bin\Debug\Test2.exe", cs:=True)
    End Sub

    Public Function tt() As Tuple
        Return New Tuple <= New With {
            .FirstName = 123,
            .Middle = 222,
            .LastName = "12313"
        }
    End Function


    '  Public Sub ttttt(p As (x  as integer , y As Integer))

    '  End Sub

    Function Main(args As String()) As Integer

        Dim bitmap As Image = Image.FromFile("G:\GCModeller\src\runtime\visualbasic_App\Microsoft.VisualBasic.Architecture.Framework\Extensions\Image\f13e6388b975d9434ad9e1a41272d242_1_orig.jpg")
        Dim binbitmap = bitmap.GetBinaryBitmap
        Call binbitmap.SaveAs("G:\GCModeller\src\runtime\visualbasic_App\Microsoft.VisualBasic.Architecture.Framework\Extensions\Image\lena.binary.png", ImageFormats.Jpeg)
        binbitmap = bitmap.GetBinaryBitmap(BinarizationStyles.SparseGray)
        Call binbitmap.SaveAs("G:\GCModeller\src\runtime\visualbasic_App\Microsoft.VisualBasic.Architecture.Framework\Extensions\Image\lena.gray.png", ImageFormats.Jpeg)
        Pause()
        Dim jsSchema As New Microsoft.VisualBasic.Serialization.JSON.Schema With {
            .title = "Example Schema",
            .type = "object",
            .properties = {
                New [Property] With {
                    .name = "firstName",
                    .type = "string"
                },
                New [Property] With {
                    .name = "lastName",
                    .type = "string"
                },
                New [Property] With {
                    .name = "age",
                    .type = "integer",
                    .description = "Age in years"
                }
            },
            .required = {"firstName", "lastName"}
        }


        Dim jsons = jsSchema.ToString

        Dim schemasss = jsons.LoadObject(Of Schema)()

        Try
            Throw New NotSupportedException
        Catch ex As Exception
            Call App.LogException(ex)
        End Try
        Pause()

        Dim t As Object = tt()
        '  Dim vars As Value(Of Object) = New With {.dsada = 4444}

        Call $"{t.FirstName}, ".__DEBUG_ECHO

        '   Dim rss = Google.News.RSS.GetCurrent("zika", "http://127.0.0.1:8087")

        '   Call rss.GetXml.__DEBUG_ECHO

        Pause()

        Dim prox As New System.Net.WebProxy
        prox.Address = New Uri("http://127.0.0.1:8087")
        prox.Credentials = New System.Net.NetworkCredential()

        Dim str As New System.Net.WebClient
        str.Proxy = prox
        Dim Coder As String = str.DownloadString("http://news.google.com/news?pz=1&cf=all&ned=us&hl=en&as_maxm=11&q=allintitle:+zika&as_qdr=a&as_drrb=q&as_mind=26&as_minm=10&cf=all&as_maxd=25&scoring=n&output=rss")

        Coder.__DEBUG_ECHO



        Call New Shell(PS1.Fedora12, AddressOf System.Console.WriteLine).Run()


        Dim iii = SoftwareToolkits.LicenseMgr.Template
        iii.RootDIR = "G:\VisualBasic_AppFramework\Microsoft.VisualBasic.Architecture.Framework"


        Call SoftwareToolkits.LicenseMgr.Insert("G:\VisualBasic_AppFramework\Microsoft.VisualBasic.Architecture.Framework\Tools\SoftwareToolkits\LicenseMgr.vb", iii)

        Dim fff = SoftwareToolkits.LicenseMgr.Inserts(iii)

        Call this.__DEBUG_ECHO

        Dim type As Type = GetType(dddddFile)

        Call Scripting.Actives.DisplType(type).__DEBUG_ECHO

        Call Pause()

        Call TestExtensionProperty()

        Call VBDebugger.Warning("ddddddddd")
        Call VBDebugger.PrintException("123123123", Reflection.MethodBase.GetCurrentMethod.GetFullName)
        Call VBDebugger.__DEBUG_ECHO("sfsdddddddddddddddd")

        Dim files As String() = LinqAPI.Exec(Of String) <= From path As String
                                                           In ls - l - r - wildcards("*.txt") <= "D:\MyDocuments"
                                                           Where (grep * "/\*.../\*" <= path).IsNullOrEmpty
                                                           Select path


        Call New ssfsfs With {.dddd = Now.ToString, .dssssddd = RandomDouble(), .xdddd = 345}.WriteClass("~/test.ini")

        Dim nnndasdasd As dddddFile = IOProvider.LoadProfile(Of dddddFile)

        Dim n As New ProgressBar("Console ProgressBar Testing.")
        Dim i As Integer = 0

        Do While True
            n.Step()
            n.SetProgress(i.MoveNext, "Current Processing: " & SecurityString.GetMd5Hash(RandomDouble))
            Threading.Thread.Sleep(1000)
        Loop

        Dim shell As New ExternalCall("C:\Perl64\bin\perl.exe")

        Dim val = shell.Shell("F:\VisualBasic_AppFramework\Microsoft.VisualBasic.Architecture.Framework\Scripting\test.pl")


        Dim list = Microsoft.VisualBasic.Parallel.ParallelLoading.Load(Of ParallelLoadingTest)({"a"})



        Dim nnnnnnnnnnnnnn = 50.Sequence

        Dim ddddss = nnnnnnnnnnnnnn.Split(3)






        Dim dn = New DomainName("http://anotherdomain.org/home")
        dn = New DomainName("www.subdomain.anothersubdomain.maindomain.com/something/")
        dn = New DomainName("http://sub.domain.com/somefolder/index.html")

        Dim task = New CommandLine.IORedirectFile("E:\GCModeller\GCModeller\.cache\SHOAL.EXE\TmoD\meme.exe", "E:\sigma\sigma\150.fasta -dna -evt 10", {New KeyValuePair(Of String, String)("MEME_DIRECTORY", "E:\GCModeller\GCModeller\.cache\SHOAL.EXE\TmoD")})
        Call task.Run()

        Call System.Console.WriteLine(task.StandardOutput)

        Try
            '   Call New TcpSynchronizationServicesSocket(Function(s As String, ad As Net.IPEndPoint) As String
            ' MsgBox(ad.ToString & "  ----> " & s)
            '  Return Len(s)
            '    End Function, 1234).Run()
        Catch ex As Exception

            '   Call New Threading.Thread(Sub() MsgBox(ex.ToString & "  =====>  " & AsynInvoke.LocalClient(1234).SendMessage(ex.ToString))).Start()
            '      Call New Threading.Thread(Sub() MsgBox("2nd    =========>     " & Microsoft.VisualBasic.WrapperClassTools.Net.AsynchronousClient.LocalClient(1234).SendMessage("sdjkfghdskjgvbjkfdzbgvkdf"))).Start()

        End Try


        System.Console.ReadLine()


        'Dim reply As String = New DotNET_Wrapper.Tools.TCPSocket.AsynchronousClient("120.26.42.138", 80).SendMessage("1234567890", 3000)

        'If Not String.Equals(reply, "OK") Then

        '    Call New DotNET_Wrapper.Tools.TCPSocket.AsynchronousSocketListener(Function(str As String, remote As Net.IPEndPoint) As String
        '                                                                           If String.Equals(str, "1234567890") Then Return "OK"
        '                                                                           remote.Port = 80

        '                                                                           Call (Sub()
        '                                                                                     Call New ConsoleDevice.Utility.ConsoleProcessBusyIndicator().Start()
        '                                                                                     Call Threading.Thread.Sleep(10 * 1000)
        '                                                                                     Call System.Console.WriteLine("Start to send message.... to  " & remote.ToString)
        '                                                                                     Call System.Console.WriteLine(New DotNET_Wrapper.Tools.TCPSocket.AsynchronousClient(remote).SendMessage("HTTP/1.1 200 OK (CRLF)"))
        '                                                                                     Call System.Console.WriteLine(New DotNET_Wrapper.Tools.TCPSocket.AsynchronousClient(remote).SendMessage("POST fdsfsdfsd"))
        '                                                                                 End Sub).BeginInvoke(Nothing, Nothing)

        '                                                                           Call System.Console.WriteLine(">>>>>>   " & remote.ToString)

        '                                                                           Return remote.ToString
        '                                                                       End Function, 80).Run()
        'Else

        '    reply = New DotNET_Wrapper.Tools.TCPSocket.AsynchronousClient("120.26.42.138", 80).SendMessage("POST 1 90", 3000)
        '    Call System.Console.WriteLine(reply)

        '    Call New DotNET_Wrapper.Tools.TCPSocket.AsynchronousSocketListener(Function(str As String, remote As Net.IPEndPoint) As String
        '                                                                           Call System.Console.WriteLine(str)
        '                                                                           Call System.Console.WriteLine(remote.ToString)

        '                                                                           Return "desfgdsfgsdklgfjsldkfds"
        '                                                                       End Function, 80).Run()
        '    MsgBox("ok")
        'End If










        Dim del = Sub(s As String, g As Integer) Call System.Console.WriteLine(s)
        Dim ttt As System.Type = del.GetType

        Dim invoke = (From item In ttt.GetMethods Where String.Equals(item.Name, "Invoke") Select item).ToArray.FirstOrDefault

        If invoke Is Nothing Then
            '目标对象不是一个Delegate函数指针
        Else
            Dim returnType = invoke.ReturnType       '生成函数签名
        End If


        Dim ss As String = IO.File.ReadAllText("0.823528468608856_blast_out_parse_error")

        ss = ss.Replace(NIL, " ")

        Dim Console As InteractiveDevice = New InteractiveDevice With {.PromptText = "#"}

        Do While True
            Call Console.PrintPrompted()
            Dim s As String = Console.ReadLine
            Call Console.WriteLine("   ------> ""{0}""", s)
        Loop
    End Function
End Module

<ClassName("df-ini")>
Public Class ssfsfs
    <DataFrameColumn("123")> Public Property dddd As String
    <DataFrameColumn("1ff23")> Public Property xdddd As Integer
    <DataFrameColumn("9x-123")> Public Property dssssddd As Double
End Class


<IniMapIO("~/test.ini")>
Public Class dddddFile
    Public Property a As ssfsfs

    Public Property nnn As Date
    Public Property ddddddd As Test

End Class
Public Class Test
    <DumpNode> Private ArrayData As String() = New String() {"23234", "!!!!!!!!", "aaaaaaaaaaaa", "*&$^$%^#$%@#$%$#@$@"}
    <DumpNode> Private dded As KeyValuePair(Of Integer, Integer) = New KeyValuePair(Of Integer, Integer)(41, 23)
    <DumpNode> Private ddeddd As KeyValuePair(Of Integer, Integer)() = New KeyValuePair(Of Integer, Integer)() {New KeyValuePair(Of Integer, Integer)(-41, -7723)}
    <DumpNode> Public Property nnn As Integer = 3456
    <DumpNode> Protected Friend fieldsssss As Double = 342342.23443
    <DumpNode> Dim aaaa As Integer()() = New Integer()() {New Integer() {1, 2, 3, 4}, New Integer() {5, 4, 3, 3333}}
    <DumpNode> Dim sdfsdfsd As dddd() = New dddd() {New dddd, New dddd}
    <DumpNode> Public Property axfsdfsdfsd As Double() = New Double() {21343332, 365.9, 21312.333}
    <DumpNode> Public Property sdfsdfsdfsdfs As dddd = New dddd
    <DumpNode> Public Property listExample As List(Of Double) = New List(Of Double) From {1, 2, 3, 4, 5.0R}
    <DumpNode> Public Property asdsadasdada As Dictionary(Of String, String) = New Dictionary(Of String, String) From {{"24234,", -36}, {3344.24323, "xsfsfsfsdf"}}
    <DumpNode> Public Property zzzz As qqq() = New qqq() {qqq.c, qqq.c, qqq.c}
End Class

Public Class dddd
    <DumpNode> Dim sdfsd As String = "4353453453werwfsdfsdfsdfds"
    <DumpNode> Private ArEEEEEEEEEEEEEEEEEEE As String() = New String() {"23234", "!!!!!!!!", "aaaaaaaaaaaa", "*&$^$%^#$%@#$%$#@$@"}
    <DumpNode> Public Property dsdfsd As String = Now.ToString
    <DumpNode> Public Property axfsdfsdfsd As Double() = New Double() {21342, 365.9, 21312.333}
    <DumpNode> Dim sfsdddddddddd As List(Of sdfsd(Of Double, Double)) = New List(Of sdfsd(Of Double, Double)) From {New sdfsd(Of Double, Double) With {.dsadas = 3534, .safsdfsdf = 45555},
                                                                                                                    New sdfsd(Of Double, Double) With {.dsadas = 3444534, .safsdfsdf = 45555},
                                                                                                                    New sdfsd(Of Double, Double) With {.dsadas = -83534, .safsdfsdf = -145555}}
End Class

Public Class qqq : Inherits sdfsd(Of Integer, String)
    <DumpNode> Dim ddddddd As Integer = -10

    Public Shared Function c() As qqq
        Return New qqq With {.dsadas = 4234, .safsdfsdf = "sajksfhskjfs"}
    End Function
End Class

Public Class sdfsd(Of T1, T3)
    <DumpNode> Public Property dsadas As T1
    <DumpNode> Public Property safsdfsdf As T3
    <DumpNode> Protected ffff As String = Now.ToString
End Class
