﻿#Region "Microsoft.VisualBasic::b86fa0c924835c3624ed7137c1e5b3c4, ..\GCModeller\data\ExternalDBSource\MetaCyc\MySQL\quanttypewidconfidenceindwid.vb"

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

REM  Dump @3/29/2017 8:48:56 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `quanttypewidconfidenceindwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `quanttypewidconfidenceindwid` (
'''   `QuantitationTypeWID` bigint(20) NOT NULL,
'''   `ConfidenceIndicatorWID` bigint(20) NOT NULL,
'''   KEY `FK_QuantTypeWIDConfidenceInd1` (`QuantitationTypeWID`),
'''   KEY `FK_QuantTypeWIDConfidenceInd2` (`ConfidenceIndicatorWID`),
'''   CONSTRAINT `FK_QuantTypeWIDConfidenceInd1` FOREIGN KEY (`QuantitationTypeWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantTypeWIDConfidenceInd2` FOREIGN KEY (`ConfidenceIndicatorWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("quanttypewidconfidenceindwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `quanttypewidconfidenceindwid` (
  `QuantitationTypeWID` bigint(20) NOT NULL,
  `ConfidenceIndicatorWID` bigint(20) NOT NULL,
  KEY `FK_QuantTypeWIDConfidenceInd1` (`QuantitationTypeWID`),
  KEY `FK_QuantTypeWIDConfidenceInd2` (`ConfidenceIndicatorWID`),
  CONSTRAINT `FK_QuantTypeWIDConfidenceInd1` FOREIGN KEY (`QuantitationTypeWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_QuantTypeWIDConfidenceInd2` FOREIGN KEY (`ConfidenceIndicatorWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class quanttypewidconfidenceindwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("QuantitationTypeWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeWID As Long
    <DatabaseField("ConfidenceIndicatorWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ConfidenceIndicatorWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `quanttypewidconfidenceindwid` (`QuantitationTypeWID`, `ConfidenceIndicatorWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `quanttypewidconfidenceindwid` (`QuantitationTypeWID`, `ConfidenceIndicatorWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `quanttypewidconfidenceindwid` WHERE `QuantitationTypeWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `quanttypewidconfidenceindwid` SET `QuantitationTypeWID`='{0}', `ConfidenceIndicatorWID`='{1}' WHERE `QuantitationTypeWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `quanttypewidconfidenceindwid` WHERE `QuantitationTypeWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, QuantitationTypeWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `quanttypewidconfidenceindwid` (`QuantitationTypeWID`, `ConfidenceIndicatorWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, QuantitationTypeWID, ConfidenceIndicatorWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{QuantitationTypeWID}', '{ConfidenceIndicatorWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `quanttypewidconfidenceindwid` (`QuantitationTypeWID`, `ConfidenceIndicatorWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, QuantitationTypeWID, ConfidenceIndicatorWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `quanttypewidconfidenceindwid` SET `QuantitationTypeWID`='{0}', `ConfidenceIndicatorWID`='{1}' WHERE `QuantitationTypeWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, QuantitationTypeWID, ConfidenceIndicatorWID, QuantitationTypeWID)
    End Function
#End Region
End Class


End Namespace
