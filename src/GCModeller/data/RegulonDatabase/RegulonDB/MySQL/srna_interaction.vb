﻿#Region "Microsoft.VisualBasic::e99e3da588076affd09aff8961c2f3e5, data\RegulonDatabase\RegulonDB\MySQL\srna_interaction.vb"

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

    ' Class srna_interaction
    ' 
    '     Properties: srna_function, srna_gene_id, srna_gene_regulated_id, srna_id, srna_mechanis
    '                 srna_note, srna_posleft, srna_posright, srna_regulation_type, srna_sequence
    '                 srna_tu_regulated_id
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:14 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `srna_interaction`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `srna_interaction` (
'''   `srna_id` char(12) NOT NULL,
'''   `srna_gene_id` char(12) DEFAULT NULL,
'''   `srna_gene_regulated_id` char(12) DEFAULT NULL,
'''   `srna_tu_regulated_id` char(12) DEFAULT NULL,
'''   `srna_function` varchar(2000) DEFAULT NULL,
'''   `srna_posleft` decimal(10,0) DEFAULT NULL,
'''   `srna_posright` decimal(10,0) DEFAULT NULL,
'''   `srna_sequence` varchar(2000) DEFAULT NULL,
'''   `srna_regulation_type` varchar(2000) DEFAULT NULL,
'''   `srna_mechanis` varchar(1000) DEFAULT NULL,
'''   `srna_note` varchar(1000) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("srna_interaction", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `srna_interaction` (
  `srna_id` char(12) NOT NULL,
  `srna_gene_id` char(12) DEFAULT NULL,
  `srna_gene_regulated_id` char(12) DEFAULT NULL,
  `srna_tu_regulated_id` char(12) DEFAULT NULL,
  `srna_function` varchar(2000) DEFAULT NULL,
  `srna_posleft` decimal(10,0) DEFAULT NULL,
  `srna_posright` decimal(10,0) DEFAULT NULL,
  `srna_sequence` varchar(2000) DEFAULT NULL,
  `srna_regulation_type` varchar(2000) DEFAULT NULL,
  `srna_mechanis` varchar(1000) DEFAULT NULL,
  `srna_note` varchar(1000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class srna_interaction: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("srna_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="srna_id")> Public Property srna_id As String
    <DatabaseField("srna_gene_id"), DataType(MySqlDbType.VarChar, "12"), Column(Name:="srna_gene_id")> Public Property srna_gene_id As String
    <DatabaseField("srna_gene_regulated_id"), DataType(MySqlDbType.VarChar, "12"), Column(Name:="srna_gene_regulated_id")> Public Property srna_gene_regulated_id As String
    <DatabaseField("srna_tu_regulated_id"), DataType(MySqlDbType.VarChar, "12"), Column(Name:="srna_tu_regulated_id")> Public Property srna_tu_regulated_id As String
    <DatabaseField("srna_function"), DataType(MySqlDbType.VarChar, "2000"), Column(Name:="srna_function")> Public Property srna_function As String
    <DatabaseField("srna_posleft"), DataType(MySqlDbType.Decimal), Column(Name:="srna_posleft")> Public Property srna_posleft As Decimal
    <DatabaseField("srna_posright"), DataType(MySqlDbType.Decimal), Column(Name:="srna_posright")> Public Property srna_posright As Decimal
    <DatabaseField("srna_sequence"), DataType(MySqlDbType.VarChar, "2000"), Column(Name:="srna_sequence")> Public Property srna_sequence As String
    <DatabaseField("srna_regulation_type"), DataType(MySqlDbType.VarChar, "2000"), Column(Name:="srna_regulation_type")> Public Property srna_regulation_type As String
    <DatabaseField("srna_mechanis"), DataType(MySqlDbType.VarChar, "1000"), Column(Name:="srna_mechanis")> Public Property srna_mechanis As String
    <DatabaseField("srna_note"), DataType(MySqlDbType.VarChar, "1000"), Column(Name:="srna_note")> Public Property srna_note As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `srna_interaction` (`srna_id`, `srna_gene_id`, `srna_gene_regulated_id`, `srna_tu_regulated_id`, `srna_function`, `srna_posleft`, `srna_posright`, `srna_sequence`, `srna_regulation_type`, `srna_mechanis`, `srna_note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `srna_interaction` (`srna_id`, `srna_gene_id`, `srna_gene_regulated_id`, `srna_tu_regulated_id`, `srna_function`, `srna_posleft`, `srna_posright`, `srna_sequence`, `srna_regulation_type`, `srna_mechanis`, `srna_note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `srna_interaction` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `srna_interaction` SET `srna_id`='{0}', `srna_gene_id`='{1}', `srna_gene_regulated_id`='{2}', `srna_tu_regulated_id`='{3}', `srna_function`='{4}', `srna_posleft`='{5}', `srna_posright`='{6}', `srna_sequence`='{7}', `srna_regulation_type`='{8}', `srna_mechanis`='{9}', `srna_note`='{10}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `srna_interaction` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `srna_interaction` (`srna_id`, `srna_gene_id`, `srna_gene_regulated_id`, `srna_tu_regulated_id`, `srna_function`, `srna_posleft`, `srna_posright`, `srna_sequence`, `srna_regulation_type`, `srna_mechanis`, `srna_note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, srna_id, srna_gene_id, srna_gene_regulated_id, srna_tu_regulated_id, srna_function, srna_posleft, srna_posright, srna_sequence, srna_regulation_type, srna_mechanis, srna_note)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{srna_id}', '{srna_gene_id}', '{srna_gene_regulated_id}', '{srna_tu_regulated_id}', '{srna_function}', '{srna_posleft}', '{srna_posright}', '{srna_sequence}', '{srna_regulation_type}', '{srna_mechanis}', '{srna_note}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `srna_interaction` (`srna_id`, `srna_gene_id`, `srna_gene_regulated_id`, `srna_tu_regulated_id`, `srna_function`, `srna_posleft`, `srna_posright`, `srna_sequence`, `srna_regulation_type`, `srna_mechanis`, `srna_note`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, srna_id, srna_gene_id, srna_gene_regulated_id, srna_tu_regulated_id, srna_function, srna_posleft, srna_posright, srna_sequence, srna_regulation_type, srna_mechanis, srna_note)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `srna_interaction` SET `srna_id`='{0}', `srna_gene_id`='{1}', `srna_gene_regulated_id`='{2}', `srna_tu_regulated_id`='{3}', `srna_function`='{4}', `srna_posleft`='{5}', `srna_posright`='{6}', `srna_sequence`='{7}', `srna_regulation_type`='{8}', `srna_mechanis`='{9}', `srna_note`='{10}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
Public Function Clone() As srna_interaction
                  Return DirectCast(MyClass.MemberwiseClone, srna_interaction)
              End Function
End Class


End Namespace
