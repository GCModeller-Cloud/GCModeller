﻿#Region "Microsoft.VisualBasic::02e00a07d06b9656359c1d5e7ff455cf, ..\GCModeller\data\Reactome\LocalMySQL\gk_current\event.vb"

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

REM  Dump @3/29/2017 9:40:27 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `event`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `event` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `_doRelease` enum('TRUE','FALSE') DEFAULT NULL,
'''   `definition` text,
'''   `evidenceType` int(10) unsigned DEFAULT NULL,
'''   `evidenceType_class` varchar(64) DEFAULT NULL,
'''   `goBiologicalProcess` int(10) unsigned DEFAULT NULL,
'''   `goBiologicalProcess_class` varchar(64) DEFAULT NULL,
'''   `releaseDate` date DEFAULT NULL,
'''   `releaseStatus` text,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `_doRelease` (`_doRelease`),
'''   KEY `evidenceType` (`evidenceType`),
'''   KEY `goBiologicalProcess` (`goBiologicalProcess`),
'''   KEY `releaseDate` (`releaseDate`),
'''   FULLTEXT KEY `definition` (`definition`),
'''   FULLTEXT KEY `releaseStatus` (`releaseStatus`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("event", Database:="gk_current", SchemaSQL:="
CREATE TABLE `event` (
  `DB_ID` int(10) unsigned NOT NULL,
  `_doRelease` enum('TRUE','FALSE') DEFAULT NULL,
  `definition` text,
  `evidenceType` int(10) unsigned DEFAULT NULL,
  `evidenceType_class` varchar(64) DEFAULT NULL,
  `goBiologicalProcess` int(10) unsigned DEFAULT NULL,
  `goBiologicalProcess_class` varchar(64) DEFAULT NULL,
  `releaseDate` date DEFAULT NULL,
  `releaseStatus` text,
  PRIMARY KEY (`DB_ID`),
  KEY `_doRelease` (`_doRelease`),
  KEY `evidenceType` (`evidenceType`),
  KEY `goBiologicalProcess` (`goBiologicalProcess`),
  KEY `releaseDate` (`releaseDate`),
  FULLTEXT KEY `definition` (`definition`),
  FULLTEXT KEY `releaseStatus` (`releaseStatus`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class [event]: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("_doRelease"), DataType(MySqlDbType.String)> Public Property _doRelease As String
    <DatabaseField("definition"), DataType(MySqlDbType.Text)> Public Property definition As String
    <DatabaseField("evidenceType"), DataType(MySqlDbType.Int64, "10")> Public Property evidenceType As Long
    <DatabaseField("evidenceType_class"), DataType(MySqlDbType.VarChar, "64")> Public Property evidenceType_class As String
    <DatabaseField("goBiologicalProcess"), DataType(MySqlDbType.Int64, "10")> Public Property goBiologicalProcess As Long
    <DatabaseField("goBiologicalProcess_class"), DataType(MySqlDbType.VarChar, "64")> Public Property goBiologicalProcess_class As String
    <DatabaseField("releaseDate"), DataType(MySqlDbType.DateTime)> Public Property releaseDate As Date
    <DatabaseField("releaseStatus"), DataType(MySqlDbType.Text)> Public Property releaseStatus As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `event` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `event` SET `DB_ID`='{0}', `_doRelease`='{1}', `definition`='{2}', `evidenceType`='{3}', `evidenceType_class`='{4}', `goBiologicalProcess`='{5}', `goBiologicalProcess_class`='{6}', `releaseDate`='{7}', `releaseStatus`='{8}' WHERE `DB_ID` = '{9}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `event` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, DataType.ToMySqlDateTimeString(releaseDate), releaseStatus)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{_doRelease}', '{definition}', '{evidenceType}', '{evidenceType_class}', '{goBiologicalProcess}', '{goBiologicalProcess_class}', '{releaseDate}', '{releaseStatus}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `event` (`DB_ID`, `_doRelease`, `definition`, `evidenceType`, `evidenceType_class`, `goBiologicalProcess`, `goBiologicalProcess_class`, `releaseDate`, `releaseStatus`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, DataType.ToMySqlDateTimeString(releaseDate), releaseStatus)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `event` SET `DB_ID`='{0}', `_doRelease`='{1}', `definition`='{2}', `evidenceType`='{3}', `evidenceType_class`='{4}', `goBiologicalProcess`='{5}', `goBiologicalProcess_class`='{6}', `releaseDate`='{7}', `releaseStatus`='{8}' WHERE `DB_ID` = '{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, _doRelease, definition, evidenceType, evidenceType_class, goBiologicalProcess, goBiologicalProcess_class, DataType.ToMySqlDateTimeString(releaseDate), releaseStatus, DB_ID)
    End Function
#End Region
End Class


End Namespace
