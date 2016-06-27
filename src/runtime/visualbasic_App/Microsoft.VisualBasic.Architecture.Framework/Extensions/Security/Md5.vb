﻿
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Linq

Namespace SecurityString

    <PackageNamespace("Md5Hash", Publisher:="Microsoft Corp.", Description:="Represents the abstract class from which all implementations of the System.Security.Cryptography.MD5 hash algorithm inherit.")>
    Public Module MD5Hash

        <ExportAPI("Uid")>
        Public Function NewUid() As String
            Dim input As String = Guid.NewGuid.ToString & Now.ToString
            Return GetMd5Hash(input)
        End Function

        ReadOnly __hashProvider As New Md5HashProvider

        <ExportAPI("Md5")>
        <Extension>
        Public Function GetMd5Hash(input As String) As String
            SyncLock __hashProvider
                Return __hashProvider.GetMd5Hash(input)
            End SyncLock
            '  Return New Md5HashProvider().GetMd5Hash(input)
        End Function

        ''' <summary>
        ''' Gets the hashcode of the input string. (<paramref name="input"/> => <see cref="MD5Hash.GetMd5Hash"/> => <see cref="MD5Hash.ToLong(String)"/>)
        ''' </summary>
        ''' <param name="input">任意字符串</param>
        ''' <returns></returns>
        <ExportAPI("GetHashCode", Info:="Gets the hashcode of the input string.")>
        Public Function GetHashCode(input As String) As Long
            Dim md5 As String = MD5Hash.GetMd5Hash(input)
            Return ToLong(md5)
        End Function

        ''' <summary>
        ''' Gets the hashcode of the input string.
        ''' </summary>
        ''' <returns></returns>
        <ExportAPI("GetHashCode", Info:="Gets the hashcode of the input string.")>
        Public Function GetHashCode(data As Generic.IEnumerable(Of Byte)) As Long
            Return GetMd5Hash(data.ToArray).ToLong
        End Function

        ''' <summary>
        ''' Gets the hashcode of the md5 string.
        ''' </summary>
        ''' <param name="md5">计算所得到的MD5哈希值</param>
        ''' <returns></returns>
        <ExportAPI("As.Long", Info:="Gets the hashcode of the md5 string.")>
        <Extension> Public Function ToLong(md5 As String) As Long
            Dim bytes = StringToByteArray(md5)
            Return ToLong(bytes)
        End Function

        ''' <summary>
        ''' CityHash algorithm for convert the md5 hash value as a <see cref="Int64"/> value.
        ''' </summary>
        ''' <param name="bytes">
        ''' this input value should compute from <see cref="Md5HashProvider.GetMd5Bytes(Byte())"/>
        ''' </param>
        ''' <returns></returns>
        ''' <remarks>
        ''' http://stackoverflow.com/questions/9661227/convert-md5-to-long
        ''' 
        ''' The very best solution I found (based on my needs... mix of speed and good hash function) is Google's CityHash. 
        ''' The input can be any byte array including an MD5 result and the output is an unsigned 64-bit long.
        '''
        ''' CityHash has a very good but Not perfect hash distribution, And Is very fast.
        '''
        ''' I ported CityHash from C++ To C# In half an hour. A Java port should be straightforward too.
        '''
        ''' Just XORing the bits doesn't give as good a distribution (though admittedly that will be very fast).
        '''
        ''' I'm not familiar enough with Java to tell you exactly how to populate a long from a byte array 
        ''' (there could be a good helper I'm not familiar with, or I could get some details of arithmetic 
        ''' in Java wrong). 
        ''' Essentially, though, you'll want to do something like this:
        '''
        ''' Long a = md5[0] * 256 * md5[1] + 256 * 256 * md5[2] + 256 * 256 * 256 * md5[3];
        ''' Long b = md5[4] * 256 * md5[5] + 256 * 256 * md5[6] + 256 * 256 * 256 * md5[7];
        ''' Long result = a ^ b;
        ''' 
        ''' Note I have made no attempt To deal With endianness. If you just care about a consistent hash value, 
        ''' though, endianness should Not matter.
        ''' </remarks>
        <ExportAPI("As.Long")> <Extension>
        Public Function ToLong(bytes As Byte()) As Long
            Dim md5 As Long() = bytes.ToArray(Function(x) CLng(x))
            Dim a As Long = md5(0) * 256 * md5(1) + 256 * 256 * md5(2) + 256 * 256 * 256 * md5(3)
            Dim b As Long = md5(4) * 256 * md5(5) + 256 * 256 * md5(6) + 256 * 256 * 256 * md5(7)
            Dim result As Long = a Xor b

            Return result
        End Function

        ''' <summary>
        ''' 由于md5是大小写无关的，故而在这里都会自动的被转换为小写形式，所以调用这个函数的时候不需要在额外的转换了
        ''' </summary>
        ''' <param name="hex"></param>
        ''' <returns></returns>
        <ExportAPI("As.Bytes")>
        Public Function StringToByteArray(hex As String) As Byte()
            Dim NumberChars As Integer = hex.Length
            Dim bytes As Byte() = New Byte(NumberChars / 2 - 1) {}

            hex = hex.ToLower  ' MD5是大小写无关的

            For i As Integer = 0 To NumberChars - 2 Step 2
                bytes(i / 2) = Convert.ToByte(hex.Substring(i, 2), 16)
            Next
            Return bytes
        End Function

        <ExportAPI("Md5")>
        Public Function GetMd5Hash(input As Byte()) As String
            Return New Md5HashProvider().GetMd5Hash(input)
        End Function

        <Extension>
        Public Function GetMd5Hash2(Of T)(x As T) As String
            Dim raw As String = x.ToString & x.GetHashCode
            Return raw.GetMd5Hash
        End Function

        <Extension>
        Public Function GetMd5Hash(Of T As Language.ClassObject)(x As T) As String
            Dim raw As String = x.__toString & x.GetHashCode
            Return raw.GetMd5Hash
        End Function

        ''' <summary>
        ''' Verify a hash against a string. 
        ''' </summary>
        ''' <param name="input"></param>
        ''' <param name="comparedHash"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("Md5.Verify", Info:="Verify a hash against a string.")>
        Public Function VerifyMd5Hash(input As String, comparedHash As String) As Boolean
            If String.IsNullOrEmpty(input) OrElse String.IsNullOrEmpty(comparedHash) Then
                Return False
            End If

            Dim hashOfInput As String = GetMd5Hash(input)  ' Hash the input. 
            Return String.Equals(hashOfInput, comparedHash, StringComparison.OrdinalIgnoreCase)
        End Function 'VerifyMd5Hash

        ''' <summary>
        ''' 校验两个文件的哈希值是否一致
        ''' </summary>
        ''' <param name="query"></param>
        ''' <param name="subject"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("File.Equals")>
        Public Function VerifyFile(query As String, subject As String) As Boolean
            Return String.Equals(GetFileHashString(query), GetFileHashString(subject))
        End Function

        ''' <summary>
        ''' Get the md5 hash calculation value for a specific file.(获取文件对象的哈希值，请注意，当文件不存在或者文件的长度为零的时候，会返回空字符串)
        ''' </summary>
        ''' <param name="PathUri">The file path of the target file to be calculated.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("File.Md5", Info:="Get the md5 hash calculation value for a specific file.")>
        Public Function GetFileHashString(<Parameter("Path.Uri", "The file path of the target file to be calculated.")> PathUri As String) As String
            If Not PathUri.FileExists OrElse FileIO.FileSystem.GetFileInfo(PathUri).Length = 0 Then
                Return ""
            End If

            Dim ChunkBuffer As Byte() = IO.File.ReadAllBytes(PathUri)
            Return GetMd5Hash(ChunkBuffer)
        End Function

        ''' <summary>
        ''' SHA256 8 bits salt value for the private key.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <ExportAPI("SaltValue", Info:="SHA256 8 bits salt value for the private key.")>
        Public Function SaltValue(value As String) As String
            Dim hash As String = GetMd5Hash(value)
            Dim chars As Char() = New Char() {hash(0), hash(1), hash(3), hash(5), hash(15), hash(23), hash(28), hash(31)}
            Return New String(chars)
        End Function
    End Module
End Namespace