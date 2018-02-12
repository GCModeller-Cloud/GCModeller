﻿#Region "Microsoft.VisualBasic::38bf0cb3ab16de32f41d92f8dc9ac2a1, data\RegulonDatabase\RegulonDB\MySQL\transcription_factor.vb"

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

    ' Class transcription_factor
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:24:24 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `transcription_factor`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `transcription_factor` (
'''   `transcription_factor_id` char(12) NOT NULL,
'''   `transcription_factor_name` varchar(255) NOT NULL,
'''   `site_length` decimal(10,0) DEFAULT NULL,
'''   `symmetry` varchar(50) DEFAULT NULL,
'''   `transcription_factor_family` varchar(250) DEFAULT NULL,
'''   `tf_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL,
'''   `transcription_factor_note` longtext,
'''   `connectivity_class` varchar(100) DEFAULT NULL,
'''   `sensing_class` varchar(100) DEFAULT NULL,
'''   `consensus_sequence` varchar(255) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("transcription_factor", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `transcription_factor` (
  `transcription_factor_id` char(12) NOT NULL,
  `transcription_factor_name` varchar(255) NOT NULL,
  `site_length` decimal(10,0) DEFAULT NULL,
  `symmetry` varchar(50) DEFAULT NULL,
  `transcription_factor_family` varchar(250) DEFAULT NULL,
  `tf_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL,
  `transcription_factor_note` longtext,
  `connectivity_class` varchar(100) DEFAULT NULL,
  `sensing_class` varchar(100) DEFAULT NULL,
  `consensus_sequence` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class transcription_factor: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("transcription_factor_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property transcription_factor_id As String
    <DatabaseField("transcription_factor_name"), NotNull, DataType(MySqlDbType.VarChar, "255")> Public Property transcription_factor_name As String
    <DatabaseField("site_length"), DataType(MySqlDbType.Decimal)> Public Property site_length As Decimal
    <DatabaseField("symmetry"), DataType(MySqlDbType.VarChar, "50")> Public Property symmetry As String
    <DatabaseField("transcription_factor_family"), DataType(MySqlDbType.VarChar, "250")> Public Property transcription_factor_family As String
    <DatabaseField("tf_internal_comment"), DataType(MySqlDbType.Text)> Public Property tf_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5")> Public Property key_id_org As String
    <DatabaseField("transcription_factor_note"), DataType(MySqlDbType.Text)> Public Property transcription_factor_note As String
    <DatabaseField("connectivity_class"), DataType(MySqlDbType.VarChar, "100")> Public Property connectivity_class As String
    <DatabaseField("sensing_class"), DataType(MySqlDbType.VarChar, "100")> Public Property sensing_class As String
    <DatabaseField("consensus_sequence"), DataType(MySqlDbType.VarChar, "255")> Public Property consensus_sequence As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `transcription_factor` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `transcription_factor` SET `transcription_factor_id`='{0}', `transcription_factor_name`='{1}', `site_length`='{2}', `symmetry`='{3}', `transcription_factor_family`='{4}', `tf_internal_comment`='{5}', `key_id_org`='{6}', `transcription_factor_note`='{7}', `connectivity_class`='{8}', `sensing_class`='{9}', `consensus_sequence`='{10}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `transcription_factor` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, transcription_factor_id, transcription_factor_name, site_length, symmetry, transcription_factor_family, tf_internal_comment, key_id_org, transcription_factor_note, connectivity_class, sensing_class, consensus_sequence)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{transcription_factor_id}', '{transcription_factor_name}', '{site_length}', '{symmetry}', '{transcription_factor_family}', '{tf_internal_comment}', '{key_id_org}', '{transcription_factor_note}', '{connectivity_class}', '{sensing_class}', '{consensus_sequence}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, transcription_factor_id, transcription_factor_name, site_length, symmetry, transcription_factor_family, tf_internal_comment, key_id_org, transcription_factor_note, connectivity_class, sensing_class, consensus_sequence)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `transcription_factor` SET `transcription_factor_id`='{0}', `transcription_factor_name`='{1}', `site_length`='{2}', `symmetry`='{3}', `transcription_factor_family`='{4}', `tf_internal_comment`='{5}', `key_id_org`='{6}', `transcription_factor_note`='{7}', `connectivity_class`='{8}', `sensing_class`='{9}', `consensus_sequence`='{10}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
