﻿#Region "Microsoft.VisualBasic::bad69891bcaf749b9a7e0e2c2517cbe5, data\Reactome\LocalMySQL\gk_current\entityfunctionalstatus_2_functionalstatus.vb"

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

    ' Class entityfunctionalstatus_2_functionalstatus
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 9:40:27 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `entityfunctionalstatus_2_functionalstatus`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `entityfunctionalstatus_2_functionalstatus` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `functionalStatus_rank` int(10) unsigned DEFAULT NULL,
'''   `functionalStatus` int(10) unsigned DEFAULT NULL,
'''   `functionalStatus_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `functionalStatus` (`functionalStatus`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("entityfunctionalstatus_2_functionalstatus", Database:="gk_current", SchemaSQL:="
CREATE TABLE `entityfunctionalstatus_2_functionalstatus` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `functionalStatus_rank` int(10) unsigned DEFAULT NULL,
  `functionalStatus` int(10) unsigned DEFAULT NULL,
  `functionalStatus_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `functionalStatus` (`functionalStatus`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class entityfunctionalstatus_2_functionalstatus: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("functionalStatus_rank"), DataType(MySqlDbType.Int64, "10")> Public Property functionalStatus_rank As Long
    <DatabaseField("functionalStatus"), DataType(MySqlDbType.Int64, "10")> Public Property functionalStatus As Long
    <DatabaseField("functionalStatus_class"), DataType(MySqlDbType.VarChar, "64")> Public Property functionalStatus_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `entityfunctionalstatus_2_functionalstatus` (`DB_ID`, `functionalStatus_rank`, `functionalStatus`, `functionalStatus_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `entityfunctionalstatus_2_functionalstatus` (`DB_ID`, `functionalStatus_rank`, `functionalStatus`, `functionalStatus_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `entityfunctionalstatus_2_functionalstatus` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `entityfunctionalstatus_2_functionalstatus` SET `DB_ID`='{0}', `functionalStatus_rank`='{1}', `functionalStatus`='{2}', `functionalStatus_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `entityfunctionalstatus_2_functionalstatus` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `entityfunctionalstatus_2_functionalstatus` (`DB_ID`, `functionalStatus_rank`, `functionalStatus`, `functionalStatus_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, functionalStatus_rank, functionalStatus, functionalStatus_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{functionalStatus_rank}', '{functionalStatus}', '{functionalStatus_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `entityfunctionalstatus_2_functionalstatus` (`DB_ID`, `functionalStatus_rank`, `functionalStatus`, `functionalStatus_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, functionalStatus_rank, functionalStatus, functionalStatus_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `entityfunctionalstatus_2_functionalstatus` SET `DB_ID`='{0}', `functionalStatus_rank`='{1}', `functionalStatus`='{2}', `functionalStatus_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, functionalStatus_rank, functionalStatus, functionalStatus_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
