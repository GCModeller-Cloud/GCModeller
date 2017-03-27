Namespace Scripting

    ''' <summary>
    ''' ���ģ��֮�а�����һϵ�еĳ��԰�ȫ�Ķ�һЩ���������ͽ�������ת������
    ''' </summary>
    Public Module NumberConversionRoutines

        Public Function CDblSafe(strWork As String) As Double
            Dim dblValue As Double = 0

            If Double.TryParse(strWork, dblValue) Then
                Return dblValue
            Else
                Return 0
            End If
        End Function

        Public Function CShortSafe(dblWork As Double) As Int16
            If dblWork <= 32767 And dblWork >= -32767 Then
                Return CShort(dblWork)
            Else
                If dblWork < 0 Then
                    Return -32767
                Else
                    Return 32767
                End If
            End If
        End Function

        Public Function CShortSafe(strWork As String) As Int16
            Dim dblValue As Double = 0

            If Double.TryParse(strWork, dblValue) Then
                Return CShortSafe(dblValue)
            ElseIf strWork.ToLower() = "true" Then
                Return -1
            Else
                Return 0
            End If
        End Function

        Public Function CIntSafe(dblWork As Double) As Int32
            If dblWork <= Integer.MaxValue And dblWork >= Integer.MinValue Then
                Return CInt(dblWork)
            Else
                If dblWork < 0 Then
                    Return Integer.MinValue
                Else
                    Return Integer.MaxValue
                End If
            End If
        End Function

        Public Function CIntSafe(strWork As String) As Int32
            Dim dblValue As Double = 0

            If Double.TryParse(strWork, dblValue) Then
                Return CIntSafe(dblValue)
            ElseIf strWork.ToLower() = "true" Then
                Return -1
            Else
                Return 0
            End If
        End Function

        ''' <summary>
        ''' ���Խ��������Ͱ�ȫ��ת��Ϊ�ַ���ֵ
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        Public Function CStrSafe(obj As Object, Optional default$ = "") As String
            Try
                If obj Is Nothing Then
                    Return String.Empty
                ElseIf Convert.IsDBNull(obj) Then
                    Return String.Empty
                Else
                    ' ��Ϊ������ܻᶨ����NarrowingΪString���͵Ĳ��������������������CStr�����������ǵ���ToString����
                    Return CStr(obj)
                End If
            Catch ex As Exception
                Try
                    ' �����Cstr�Ƿ�Ҳ�����ToString����
                    Return obj.ToString
                Catch ex2 As Exception
                    Return [default]
                End Try
            End Try
        End Function

        Public Function IsNumber(strValue As String) As Boolean
            Try
                Return Double.TryParse(strValue, 0)
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Module
End Namespace