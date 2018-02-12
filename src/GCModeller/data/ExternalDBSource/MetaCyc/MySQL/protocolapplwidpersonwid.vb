﻿#Region "Microsoft.VisualBasic::6004df71a26c8785e20769cb15b8b344, data\ExternalDBSource\MetaCyc\MySQL\protocolapplwidpersonwid.vb"

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

    ' Class protocolapplwidpersonwid
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:56 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protocolapplwidpersonwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protocolapplwidpersonwid` (
'''   `ProtocolApplicationWID` bigint(20) NOT NULL,
'''   `PersonWID` bigint(20) NOT NULL,
'''   KEY `FK_ProtocolApplWIDPersonWID1` (`ProtocolApplicationWID`),
'''   KEY `FK_ProtocolApplWIDPersonWID2` (`PersonWID`),
'''   CONSTRAINT `FK_ProtocolApplWIDPersonWID1` FOREIGN KEY (`ProtocolApplicationWID`) REFERENCES `parameterizableapplication` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ProtocolApplWIDPersonWID2` FOREIGN KEY (`PersonWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protocolapplwidpersonwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `protocolapplwidpersonwid` (
  `ProtocolApplicationWID` bigint(20) NOT NULL,
  `PersonWID` bigint(20) NOT NULL,
  KEY `FK_ProtocolApplWIDPersonWID1` (`ProtocolApplicationWID`),
  KEY `FK_ProtocolApplWIDPersonWID2` (`PersonWID`),
  CONSTRAINT `FK_ProtocolApplWIDPersonWID1` FOREIGN KEY (`ProtocolApplicationWID`) REFERENCES `parameterizableapplication` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProtocolApplWIDPersonWID2` FOREIGN KEY (`PersonWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class protocolapplwidpersonwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ProtocolApplicationWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ProtocolApplicationWID As Long
    <DatabaseField("PersonWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property PersonWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protocolapplwidpersonwid` WHERE `ProtocolApplicationWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protocolapplwidpersonwid` SET `ProtocolApplicationWID`='{0}', `PersonWID`='{1}' WHERE `ProtocolApplicationWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protocolapplwidpersonwid` WHERE `ProtocolApplicationWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ProtocolApplicationWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ProtocolApplicationWID, PersonWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ProtocolApplicationWID}', '{PersonWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ProtocolApplicationWID, PersonWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protocolapplwidpersonwid` SET `ProtocolApplicationWID`='{0}', `PersonWID`='{1}' WHERE `ProtocolApplicationWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ProtocolApplicationWID, PersonWID, ProtocolApplicationWID)
    End Function
#End Region
End Class


End Namespace
