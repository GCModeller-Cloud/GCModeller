﻿#Region "Microsoft.VisualBasic::56b6b5955adc6d3b918592eaa1ec6da6, ..\GCModeller\data\ExternalDBSource\ChEBI\Tables\compounds.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
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

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:55 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace ChEBI.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `compounds`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `compounds` (
'''   `id` int(11) NOT NULL,
'''   `name` text,
'''   `source` varchar(32) NOT NULL,
'''   `parent_id` int(11) DEFAULT NULL,
'''   `chebi_accession` varchar(30) NOT NULL,
'''   `status` varchar(1) NOT NULL,
'''   `definition` text,
'''   `star` int(11) NOT NULL,
'''   `modified_on` text,
'''   `created_by` text,
'''   PRIMARY KEY (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("compounds", Database:="chebi", SchemaSQL:="
CREATE TABLE `compounds` (
  `id` int(11) NOT NULL,
  `name` text,
  `source` varchar(32) NOT NULL,
  `parent_id` int(11) DEFAULT NULL,
  `chebi_accession` varchar(30) NOT NULL,
  `status` varchar(1) NOT NULL,
  `definition` text,
  `star` int(11) NOT NULL,
  `modified_on` text,
  `created_by` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class compounds: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("name"), DataType(MySqlDbType.Text)> Public Property name As String
    <DatabaseField("source"), NotNull, DataType(MySqlDbType.VarChar, "32")> Public Property source As String
    <DatabaseField("parent_id"), DataType(MySqlDbType.Int64, "11")> Public Property parent_id As Long
    <DatabaseField("chebi_accession"), NotNull, DataType(MySqlDbType.VarChar, "30")> Public Property chebi_accession As String
    <DatabaseField("status"), NotNull, DataType(MySqlDbType.VarChar, "1")> Public Property status As String
    <DatabaseField("definition"), DataType(MySqlDbType.Text)> Public Property definition As String
    <DatabaseField("star"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property star As Long
    <DatabaseField("modified_on"), DataType(MySqlDbType.Text)> Public Property modified_on As String
    <DatabaseField("created_by"), DataType(MySqlDbType.Text)> Public Property created_by As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `compounds` (`id`, `name`, `source`, `parent_id`, `chebi_accession`, `status`, `definition`, `star`, `modified_on`, `created_by`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `compounds` (`id`, `name`, `source`, `parent_id`, `chebi_accession`, `status`, `definition`, `star`, `modified_on`, `created_by`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `compounds` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `compounds` SET `id`='{0}', `name`='{1}', `source`='{2}', `parent_id`='{3}', `chebi_accession`='{4}', `status`='{5}', `definition`='{6}', `star`='{7}', `modified_on`='{8}', `created_by`='{9}' WHERE `id` = '{10}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `compounds` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `compounds` (`id`, `name`, `source`, `parent_id`, `chebi_accession`, `status`, `definition`, `star`, `modified_on`, `created_by`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, name, source, parent_id, chebi_accession, status, definition, star, modified_on, created_by)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{name}', '{source}', '{parent_id}', '{chebi_accession}', '{status}', '{definition}', '{star}', '{modified_on}', '{created_by}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `compounds` (`id`, `name`, `source`, `parent_id`, `chebi_accession`, `status`, `definition`, `star`, `modified_on`, `created_by`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, name, source, parent_id, chebi_accession, status, definition, star, modified_on, created_by)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `compounds` SET `id`='{0}', `name`='{1}', `source`='{2}', `parent_id`='{3}', `chebi_accession`='{4}', `status`='{5}', `definition`='{6}', `star`='{7}', `modified_on`='{8}', `created_by`='{9}' WHERE `id` = '{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, name, source, parent_id, chebi_accession, status, definition, star, modified_on, created_by, id)
    End Function
#End Region
End Class


End Namespace
