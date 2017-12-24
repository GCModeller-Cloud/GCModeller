﻿#Region "Microsoft.VisualBasic::418a8906801db35ae1e499df0381c803, ..\GCModeller\data\RegulonDatabase\RegulonDB\MySQL\attenuator_terminator.vb"

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

REM  Dump @3/29/2017 11:24:24 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `attenuator_terminator`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `attenuator_terminator` (
'''   `a_terminator_id` varchar(12) NOT NULL,
'''   `a_terminator_type` varchar(25) DEFAULT NULL,
'''   `a_terminator_posleft` decimal(10,0) DEFAULT NULL,
'''   `a_terminator_posright` decimal(10,0) DEFAULT NULL,
'''   `a_terminator_energy` decimal(7,2) DEFAULT NULL,
'''   `a_terminator_sequence` varchar(200) DEFAULT NULL,
'''   `a_terminator_attenuator_id` varchar(12) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("attenuator_terminator", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `attenuator_terminator` (
  `a_terminator_id` varchar(12) NOT NULL,
  `a_terminator_type` varchar(25) DEFAULT NULL,
  `a_terminator_posleft` decimal(10,0) DEFAULT NULL,
  `a_terminator_posright` decimal(10,0) DEFAULT NULL,
  `a_terminator_energy` decimal(7,2) DEFAULT NULL,
  `a_terminator_sequence` varchar(200) DEFAULT NULL,
  `a_terminator_attenuator_id` varchar(12) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class attenuator_terminator: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("a_terminator_id"), NotNull, DataType(MySqlDbType.VarChar, "12")> Public Property a_terminator_id As String
    <DatabaseField("a_terminator_type"), DataType(MySqlDbType.VarChar, "25")> Public Property a_terminator_type As String
    <DatabaseField("a_terminator_posleft"), DataType(MySqlDbType.Decimal)> Public Property a_terminator_posleft As Decimal
    <DatabaseField("a_terminator_posright"), DataType(MySqlDbType.Decimal)> Public Property a_terminator_posright As Decimal
    <DatabaseField("a_terminator_energy"), DataType(MySqlDbType.Decimal)> Public Property a_terminator_energy As Decimal
    <DatabaseField("a_terminator_sequence"), DataType(MySqlDbType.VarChar, "200")> Public Property a_terminator_sequence As String
    <DatabaseField("a_terminator_attenuator_id"), DataType(MySqlDbType.VarChar, "12")> Public Property a_terminator_attenuator_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `attenuator_terminator` (`a_terminator_id`, `a_terminator_type`, `a_terminator_posleft`, `a_terminator_posright`, `a_terminator_energy`, `a_terminator_sequence`, `a_terminator_attenuator_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `attenuator_terminator` (`a_terminator_id`, `a_terminator_type`, `a_terminator_posleft`, `a_terminator_posright`, `a_terminator_energy`, `a_terminator_sequence`, `a_terminator_attenuator_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `attenuator_terminator` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `attenuator_terminator` SET `a_terminator_id`='{0}', `a_terminator_type`='{1}', `a_terminator_posleft`='{2}', `a_terminator_posright`='{3}', `a_terminator_energy`='{4}', `a_terminator_sequence`='{5}', `a_terminator_attenuator_id`='{6}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `attenuator_terminator` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `attenuator_terminator` (`a_terminator_id`, `a_terminator_type`, `a_terminator_posleft`, `a_terminator_posright`, `a_terminator_energy`, `a_terminator_sequence`, `a_terminator_attenuator_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, a_terminator_id, a_terminator_type, a_terminator_posleft, a_terminator_posright, a_terminator_energy, a_terminator_sequence, a_terminator_attenuator_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{a_terminator_id}', '{a_terminator_type}', '{a_terminator_posleft}', '{a_terminator_posright}', '{a_terminator_energy}', '{a_terminator_sequence}', '{a_terminator_attenuator_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `attenuator_terminator` (`a_terminator_id`, `a_terminator_type`, `a_terminator_posleft`, `a_terminator_posright`, `a_terminator_energy`, `a_terminator_sequence`, `a_terminator_attenuator_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, a_terminator_id, a_terminator_type, a_terminator_posleft, a_terminator_posright, a_terminator_energy, a_terminator_sequence, a_terminator_attenuator_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `attenuator_terminator` SET `a_terminator_id`='{0}', `a_terminator_type`='{1}', `a_terminator_posleft`='{2}', `a_terminator_posright`='{3}', `a_terminator_energy`='{4}', `a_terminator_sequence`='{5}', `a_terminator_attenuator_id`='{6}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
End Class


End Namespace
