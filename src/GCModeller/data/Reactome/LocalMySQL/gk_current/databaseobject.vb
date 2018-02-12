﻿#Region "Microsoft.VisualBasic::1453a9b10c4462134be5e4278ea0d648, data\Reactome\LocalMySQL\gk_current\databaseobject.vb"

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

    ' Class databaseobject
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
''' DROP TABLE IF EXISTS `databaseobject`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `databaseobject` (
'''   `DB_ID` int(10) NOT NULL AUTO_INCREMENT,
'''   `_Protege_id` varchar(255) DEFAULT NULL,
'''   `__is_ghost` enum('TRUE') DEFAULT NULL,
'''   `_class` varchar(64) DEFAULT NULL,
'''   `_displayName` text,
'''   `_timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   `created` int(10) unsigned DEFAULT NULL,
'''   `created_class` varchar(64) DEFAULT NULL,
'''   `stableIdentifier` int(10) unsigned DEFAULT NULL,
'''   `stableIdentifier_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `_Protege_id` (`_Protege_id`),
'''   KEY `__is_ghost` (`__is_ghost`),
'''   KEY `_class` (`_class`),
'''   KEY `_timestamp` (`_timestamp`),
'''   KEY `created` (`created`),
'''   KEY `stableIdentifier` (`stableIdentifier`),
'''   FULLTEXT KEY `_Protege_id_fulltext` (`_Protege_id`),
'''   FULLTEXT KEY `_class_fulltext` (`_class`),
'''   FULLTEXT KEY `_displayName` (`_displayName`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=8835475 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("databaseobject", Database:="gk_current", SchemaSQL:="
CREATE TABLE `databaseobject` (
  `DB_ID` int(10) NOT NULL AUTO_INCREMENT,
  `_Protege_id` varchar(255) DEFAULT NULL,
  `__is_ghost` enum('TRUE') DEFAULT NULL,
  `_class` varchar(64) DEFAULT NULL,
  `_displayName` text,
  `_timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created` int(10) unsigned DEFAULT NULL,
  `created_class` varchar(64) DEFAULT NULL,
  `stableIdentifier` int(10) unsigned DEFAULT NULL,
  `stableIdentifier_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `_Protege_id` (`_Protege_id`),
  KEY `__is_ghost` (`__is_ghost`),
  KEY `_class` (`_class`),
  KEY `_timestamp` (`_timestamp`),
  KEY `created` (`created`),
  KEY `stableIdentifier` (`stableIdentifier`),
  FULLTEXT KEY `_Protege_id_fulltext` (`_Protege_id`),
  FULLTEXT KEY `_class_fulltext` (`_class`),
  FULLTEXT KEY `_displayName` (`_displayName`)
) ENGINE=MyISAM AUTO_INCREMENT=8835475 DEFAULT CHARSET=latin1;")>
Public Class databaseobject: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("_Protege_id"), DataType(MySqlDbType.VarChar, "255")> Public Property _Protege_id As String
    <DatabaseField("__is_ghost"), DataType(MySqlDbType.String)> Public Property __is_ghost As String
    <DatabaseField("_class"), DataType(MySqlDbType.VarChar, "64")> Public Property _class As String
    <DatabaseField("_displayName"), DataType(MySqlDbType.Text)> Public Property _displayName As String
    <DatabaseField("_timestamp"), NotNull, DataType(MySqlDbType.DateTime)> Public Property _timestamp As Date
    <DatabaseField("created"), DataType(MySqlDbType.Int64, "10")> Public Property created As Long
    <DatabaseField("created_class"), DataType(MySqlDbType.VarChar, "64")> Public Property created_class As String
    <DatabaseField("stableIdentifier"), DataType(MySqlDbType.Int64, "10")> Public Property stableIdentifier As Long
    <DatabaseField("stableIdentifier_class"), DataType(MySqlDbType.VarChar, "64")> Public Property stableIdentifier_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `databaseobject` (`_Protege_id`, `__is_ghost`, `_class`, `_displayName`, `_timestamp`, `created`, `created_class`, `stableIdentifier`, `stableIdentifier_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `databaseobject` (`_Protege_id`, `__is_ghost`, `_class`, `_displayName`, `_timestamp`, `created`, `created_class`, `stableIdentifier`, `stableIdentifier_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `databaseobject` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `databaseobject` SET `DB_ID`='{0}', `_Protege_id`='{1}', `__is_ghost`='{2}', `_class`='{3}', `_displayName`='{4}', `_timestamp`='{5}', `created`='{6}', `created_class`='{7}', `stableIdentifier`='{8}', `stableIdentifier_class`='{9}' WHERE `DB_ID` = '{10}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `databaseobject` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `databaseobject` (`_Protege_id`, `__is_ghost`, `_class`, `_displayName`, `_timestamp`, `created`, `created_class`, `stableIdentifier`, `stableIdentifier_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, _Protege_id, __is_ghost, _class, _displayName, DataType.ToMySqlDateTimeString(_timestamp), created, created_class, stableIdentifier, stableIdentifier_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{_Protege_id}', '{__is_ghost}', '{_class}', '{_displayName}', '{_timestamp}', '{created}', '{created_class}', '{stableIdentifier}', '{stableIdentifier_class}', '{9}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `databaseobject` (`_Protege_id`, `__is_ghost`, `_class`, `_displayName`, `_timestamp`, `created`, `created_class`, `stableIdentifier`, `stableIdentifier_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, _Protege_id, __is_ghost, _class, _displayName, DataType.ToMySqlDateTimeString(_timestamp), created, created_class, stableIdentifier, stableIdentifier_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `databaseobject` SET `DB_ID`='{0}', `_Protege_id`='{1}', `__is_ghost`='{2}', `_class`='{3}', `_displayName`='{4}', `_timestamp`='{5}', `created`='{6}', `created_class`='{7}', `stableIdentifier`='{8}', `stableIdentifier_class`='{9}' WHERE `DB_ID` = '{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, _Protege_id, __is_ghost, _class, _displayName, DataType.ToMySqlDateTimeString(_timestamp), created, created_class, stableIdentifier, stableIdentifier_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
