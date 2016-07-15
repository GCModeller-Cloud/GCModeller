﻿#Region "Microsoft.VisualBasic::0a77b0934dce26c73bbbe96e3108240a, ..\Microsoft.VisualBasic.Architecture.Framework\ComponentModel\DataSource\DataFramework.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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

Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization

Namespace ComponentModel.DataSourceModel

    ''' <summary>
    ''' Driver abstract model
    ''' </summary>
    Public Interface IObjectModel_Driver

        ''' <summary>
        ''' Start run this driver object.
        ''' </summary>
        ''' <returns></returns>
        Function Run() As Integer
    End Interface

    ''' <summary>
    ''' 在目标对象中必须要具有一个属性有自定义属性<see cref="DataFrameColumnAttribute"></see>
    ''' </summary>
    ''' <remarks></remarks>
    Public Module DataFramework

        Public Enum PropertyAccessibilityControls As Byte
            Readable = 2
            Writeable = 4
            ReadWrite = Readable And Writeable
        End Enum

        ''' <summary>
        ''' Controls for <see cref="PropertyAccessibilityControls"/> on <see cref="PropertyInfo"/>
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Flags As IReadOnlyDictionary(Of PropertyAccessibilityControls, Func(Of PropertyInfo, Boolean)) =
            New Dictionary(Of PropertyAccessibilityControls, Func(Of PropertyInfo, Boolean)) From {
 _
                {PropertyAccessibilityControls.Readable, Function(p) p.CanRead},
                {PropertyAccessibilityControls.ReadWrite, Function(p) p.CanRead AndAlso p.CanWrite},
                {PropertyAccessibilityControls.Writeable, Function(p) p.CanWrite}
        }

        Public Function Schema(Of T)(flag As PropertyAccessibilityControls) As Dictionary(Of String, PropertyInfo)
            Return GetType(T).Schema(flag)
        End Function

        <Extension>
        Public Function Schema(type As Type,
                               flag As PropertyAccessibilityControls,
                               Optional binds As BindingFlags =
                               BindingFlags.Public Or BindingFlags.Instance) As Dictionary(Of String, PropertyInfo)
            Dim props As PropertyInfo() =
                type.GetProperties(binds)
            Return props.Where(Flags(flag)) _
                .ToDictionary(Function(x) x.Name)
        End Function

#If NET_40 = 0 Then

        ''' <summary>
        ''' Converts the .NET primitive types from string.(将字符串数据类型转换为其他的数据类型)
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PrimitiveFromString As Dictionary(Of Type, __StringTypeCaster) =
            New Dictionary(Of Type, __StringTypeCaster) From {
 _
                {GetType(String), Function(strValue As String) strValue},
                {GetType(Boolean), AddressOf getBoolean},
                {GetType(DateTime), Function(strValue As String) CType(strValue, DateTime)},
                {GetType(Double), AddressOf Val},
                {GetType(Integer), Function(strValue As String) CInt(strValue)},
                {GetType(Long), Function(strValue As String) CLng(strValue)},
                {GetType(Single), Function(s) CSng(Val(s))},
                {GetType(Char), Function(s) s.FirstOrDefault}
        }

        ''' <summary>
        ''' Object <see cref="Object.ToString"/> methods.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property ToStrings As Dictionary(Of Type, __LDMStringTypeCastHandler) =
            New Dictionary(Of Type, __LDMStringTypeCastHandler) From {
 _
                {GetType(String), AddressOf DataFramework.__toStringInternal},
                {GetType(Boolean), AddressOf DataFramework.ValueToString},
                {GetType(DateTime), AddressOf DataFramework.ValueToString},
                {GetType(Double), AddressOf DataFramework.ValueToString},
                {GetType(Integer), AddressOf DataFramework.ValueToString},
                {GetType(Long), AddressOf DataFramework.ValueToString},
                {GetType(Byte), AddressOf DataFramework.ValueToString},
                {GetType(ULong), AddressOf DataFramework.ValueToString},
                {GetType(UInteger), AddressOf DataFramework.ValueToString},
                {GetType(Short), AddressOf DataFramework.ValueToString},
                {GetType(UShort), AddressOf DataFramework.ValueToString},
                {GetType(Char), AddressOf DataFramework.__toStringInternal},
                {GetType(Single), AddressOf DataFramework.ValueToString},
                {GetType(SByte), AddressOf DataFramework.ValueToString}
        }

        Public Delegate Function CTypeDynamics(obj As Object, ConvertType As Type) As Object
#End If

        ''' <summary>
        ''' Call <see cref="Object.ToString"/> of the value types
        ''' </summary>
        ''' <param name="x">Object should be <see cref="ValueType"/></param>
        ''' <returns></returns>
        Public Function ValueToString(x As Object) As String
            Return x.ToString
        End Function

        ''' <summary>
        ''' 出现错误的时候总是会返回空字符串的
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        Friend Function __toStringInternal(obj As Object) As String
            If obj Is Nothing Then
                Return ""
            Else
                Try
                    Return obj.ToString
                Catch ex As Exception
                    Call App.LogException(ex)
                    Return ""
                End Try
            End If
        End Function

        ''' <summary>
        ''' Convert target data object collection into a datatable for the data source of the <see cref="System.Windows.Forms.DataGridView"></see>>.
        ''' (将目标对象集合转换为一个数据表对象，用作DataGridView控件的数据源)
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="source"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateObject(Of T)(source As IEnumerable(Of T)) As DataTable
            Dim Columns = __initSchema(GetType(T))
            Dim DataTable As DataTable = New DataTable

            For Each column In Columns.Values
                Call DataTable.Columns.Add(
                    column.Identity,
                    column.Property.PropertyType)
            Next

            Dim fields As IEnumerable(Of BindProperty(Of DataFrameColumnAttribute)) =
                Columns.Values

            For Each row As T In source
                Dim LQuery As Object() =
                    LinqAPI.Exec(Of Object) <= From column As BindProperty(Of DataFrameColumnAttribute)
                                               In fields
                                               Select column.Property.GetValue(row, Nothing)
                Call DataTable.Rows.Add(LQuery)
            Next

            Return DataTable
        End Function

        ''' <summary>
        ''' Retrive data from a specific datatable object.(从目标数据表中获取数据)
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="DataTable"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetValue(Of T)(DataTable As DataTable) As T()
            Dim Columns = __initSchema(GetType(T))
            Dim rtvlData As T() = New T(DataTable.Rows.Count - 1) {}
            Dim i As Integer = 0

            Dim Schema As List(Of KeyValuePair(Of Integer, PropertyInfo)) =
                New List(Of KeyValuePair(Of Integer, PropertyInfo))
            For Each column As DataColumn In DataTable.Columns
                Dim LQuery As BindProperty(Of DataFrameColumnAttribute) =
                    LinqAPI.DefaultFirst(Of BindProperty(Of DataFrameColumnAttribute)) <=
                        From schemaColumn As BindProperty(Of DataFrameColumnAttribute)
                        In Columns.Values
                        Where String.Equals(schemaColumn.Identity, column.ColumnName)
                        Select schemaColumn

                If Not LQuery.IsNull Then
                    Call Schema.Add(New KeyValuePair(Of Integer, PropertyInfo)(column.Ordinal, LQuery.Property))
                End If
            Next

            For Each row As DataRow In DataTable.Rows
                Dim obj As T = Activator.CreateInstance(Of T)()
                For Each column In Schema
                    Dim value = row.Item(column.Key)
                    If IsDBNull(value) OrElse value Is Nothing Then
                        Continue For
                    End If
                    Call column.Value.SetValue(obj, value, Nothing)
                Next

                rtvlData(i) = obj
                i += 1
            Next
            Return rtvlData
        End Function

        Private Function __initSchema(type As Type) As Dictionary(Of String, BindProperty(Of DataFrameColumnAttribute))
            Dim DataColumnType As Type = GetType(DataFrameColumnAttribute)
            Dim props As PropertyInfo() = type.GetProperties
            Dim Columns = (From [property] As PropertyInfo
                           In props
                           Let attrs As Object() = [property].GetCustomAttributes(DataColumnType, True)
                           Where Not attrs.IsNullOrEmpty
                           Select colMaps =
                               DirectCast(attrs.First, DataFrameColumnAttribute), [property]
                           Order By colMaps.Index Ascending).ToList

            For Each column In Columns
                If String.IsNullOrEmpty(column.colMaps.Name) Then
                    Call column.colMaps.SetNameValue(column.property.Name)
                End If
            Next

            Dim UnIndexColumn = (From col
                                 In Columns
                                 Where col.colMaps.Index <= 0
                                 Select col  ' 未建立索引的对象按照名称排序
                                 Order By col.colMaps.Name Ascending).ToArray ' 由于在后面会涉及到修改list对象，所以在这里使用ToArray来隔绝域list的关系，避免出现冲突

            For Each col In UnIndexColumn
                Call Columns.Remove(col)
                Call Columns.Add(col) '将未建立索引的对象放置到列表的最末尾
            Next

            Return Columns.ToDictionary(
                Function(x) x.colMaps.Name,
                Function(x) New BindProperty(Of DataFrameColumnAttribute)(x.colMaps, x.property))
        End Function
    End Module
End Namespace
