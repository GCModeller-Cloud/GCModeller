﻿#Region "Microsoft.VisualBasic::43621f51970d1f3450f7e67a56030ba6, data\ExternalDBSource\MetaCyc\MySQL\arraydesignwidreportergroupwid.vb"

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

    ' Class arraydesignwidreportergroupwid
    ' 
    '     Properties: ArrayDesignWID, ReporterGroupWID
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:19 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `arraydesignwidreportergroupwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `arraydesignwidreportergroupwid` (
'''   `ArrayDesignWID` bigint(20) NOT NULL,
'''   `ReporterGroupWID` bigint(20) NOT NULL,
'''   KEY `FK_ArrayDesignWIDReporterGro1` (`ArrayDesignWID`),
'''   KEY `FK_ArrayDesignWIDReporterGro2` (`ReporterGroupWID`),
'''   CONSTRAINT `FK_ArrayDesignWIDReporterGro1` FOREIGN KEY (`ArrayDesignWID`) REFERENCES `arraydesign` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ArrayDesignWIDReporterGro2` FOREIGN KEY (`ReporterGroupWID`) REFERENCES `designelementgroup` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("arraydesignwidreportergroupwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `arraydesignwidreportergroupwid` (
  `ArrayDesignWID` bigint(20) NOT NULL,
  `ReporterGroupWID` bigint(20) NOT NULL,
  KEY `FK_ArrayDesignWIDReporterGro1` (`ArrayDesignWID`),
  KEY `FK_ArrayDesignWIDReporterGro2` (`ReporterGroupWID`),
  CONSTRAINT `FK_ArrayDesignWIDReporterGro1` FOREIGN KEY (`ArrayDesignWID`) REFERENCES `arraydesign` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ArrayDesignWIDReporterGro2` FOREIGN KEY (`ReporterGroupWID`) REFERENCES `designelementgroup` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class arraydesignwidreportergroupwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ArrayDesignWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ArrayDesignWID"), XmlAttribute> Public Property ArrayDesignWID As Long
    <DatabaseField("ReporterGroupWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ReporterGroupWID")> Public Property ReporterGroupWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `arraydesignwidreportergroupwid` (`ArrayDesignWID`, `ReporterGroupWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `arraydesignwidreportergroupwid` (`ArrayDesignWID`, `ReporterGroupWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `arraydesignwidreportergroupwid` WHERE `ArrayDesignWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `arraydesignwidreportergroupwid` SET `ArrayDesignWID`='{0}', `ReporterGroupWID`='{1}' WHERE `ArrayDesignWID` = '{2}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `arraydesignwidreportergroupwid` WHERE `ArrayDesignWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ArrayDesignWID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `arraydesignwidreportergroupwid` (`ArrayDesignWID`, `ReporterGroupWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ArrayDesignWID, ReporterGroupWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ArrayDesignWID}', '{ReporterGroupWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `arraydesignwidreportergroupwid` (`ArrayDesignWID`, `ReporterGroupWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ArrayDesignWID, ReporterGroupWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `arraydesignwidreportergroupwid` SET `ArrayDesignWID`='{0}', `ReporterGroupWID`='{1}' WHERE `ArrayDesignWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ArrayDesignWID, ReporterGroupWID, ArrayDesignWID)
    End Function
#End Region
Public Function Clone() As arraydesignwidreportergroupwid
                  Return DirectCast(MyClass.MemberwiseClone, arraydesignwidreportergroupwid)
              End Function
End Class


End Namespace
