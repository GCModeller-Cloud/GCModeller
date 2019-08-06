﻿#Region "Microsoft.VisualBasic::2973138edf1beb9688e7277ff9156880, Microsoft.VisualBasic.Core\ApplicationServices\Debugger\NETDebugger.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xie (genetics@smrucc.org)
'       xieguigang (xie.guigang@live.com)
' 
' Copyright (c) 2018 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
' 
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



' /********************************************************************************/

' Summaries:

' 
' /********************************************************************************/

#End Region

Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Serialization.BinaryDumping

Namespace ApplicationServices.Debugging

    Public Class HeapSizeOf

        Public ReadOnly Property sizeOf As Long
            Get
                Return byteSize
            End Get
        End Property

        Dim byteSize& = 0
        Dim visitor As New ObjectVisitor() With {.VisitOnlyFields = True}

        Public Sub VisitObject(value As Object, type As Type, memberInfo As MemberInfo, isVisited As Boolean, isValueType As Boolean)
            If value Is Nothing Then
                ' sizeof + 0 bytes
                ' exit recursive visit
                Return
            ElseIf isVisited Then
                ' add sizeof current reference
                ' 4 on 32-bit, 8 on 64-bit
#If X86 Then
                size += 4
#Else
                byteSize += 8
#End If
                ' exit recursive visit
            ElseIf type Is GetType(String) Then
                byteSize += StringByteSize(value)
                ' exit recursive visit
            ElseIf DataFramework.IsPrimitive(type) Then
                ' add byte size and then exit recursive visit
                byteSize += sizeOfPrimitive(type)
            ElseIf isValueType Then
                ' is structure
                ' do recursive visit of this object
                Call visitor.DoVisitObjectFields(value, type, AddressOf VisitObject)
            Else
                ' add current reference
#If X86 Then
                size += 4
#Else
                byteSize += 8
#End If
                ' is class
                ' do recursive visit of this object
                ' required additional process on array
                If type.IsArray Then
                    Call visitor.DoVisitArray(value, AddressOf VisitObject)
                Else
                    Call visitor.DoVisitObjectFields(
                        obj:=value,
                        type:=type,
                        visit:=AddressOf VisitObject
                    )
                End If
            End If
        End Sub

        ''' <summary>
        ''' Find out the size of a .net object
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        Public Shared Function MeasureSize(obj As Object) As Long
            If obj Is Nothing Then
                Return 0
            Else
                Dim type As Type = obj.GetType

                If (Not type Is GetType(String)) AndAlso DataFramework.IsPrimitive(type) Then
                    Return sizeOfPrimitive(type)
                ElseIf type Is GetType(String) Then
                    ' returns the actual byte size of current string
                    ' string in VisualBasic.NET is in unicode encoding
                    Return StringByteSize(obj)
                Else
                    With New HeapSizeOf
                        Call .visitor.DoVisitObjectFields(
                            obj:=obj,
                            type:=obj.GetType,
                            visit:=AddressOf .VisitObject
                        )

                        Return .sizeOf
                    End With
                End If
            End If
        End Function

        ''' <summary>
        ''' Returns the actual byte size of current string
        ''' string in VisualBasic.NET is in unicode encoding
        ''' </summary>
        ''' <param name="str"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function StringByteSize(str As String) As Integer
            Return Encoding.Unicode.GetByteCount(str)
        End Function

        Public Shared Function sizeOfPrimitive(type As Type) As Integer
            Select Case type
                Case GetType(Single), GetType(Integer), GetType(UInt32)
                    Return 4
                Case GetType(Double), GetType(Long), GetType(UInt64)
                    Return 8
                Case GetType(Char), GetType(Short), GetType(UInt16)
                    Return 2
                Case GetType(Byte), GetType(SByte), GetType(Boolean)
                    Return 1
                Case Else
                    Throw New NotImplementedException(type.FullName)
            End Select
        End Function
    End Class
End Namespace
