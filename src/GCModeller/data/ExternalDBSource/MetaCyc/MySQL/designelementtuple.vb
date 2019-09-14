﻿#Region "Microsoft.VisualBasic::0b5f3975ea7428ecce9a920c27660a21, ExternalDBSource\MetaCyc\MySQL\designelementtuple.vb"

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

    ' Class designelementtuple
    ' 
    '     Properties: BioAssayTuple, DataSetWID, DesignElement, WID
    ' 
    '     Function: Clone, GetDeleteSQL, GetDumpInsertValue, (+2 Overloads) GetInsertSQL, (+2 Overloads) GetReplaceSQL
    '               GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:40


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
''' DROP TABLE IF EXISTS `designelementtuple`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `designelementtuple` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `BioAssayTuple` bigint(20) DEFAULT NULL,
'''   `DesignElement` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_DesignElementTuple1` (`DataSetWID`),
'''   KEY `FK_DesignElementTuple2` (`BioAssayTuple`),
'''   KEY `FK_DesignElementTuple3` (`DesignElement`),
'''   CONSTRAINT `FK_DesignElementTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementTuple2` FOREIGN KEY (`BioAssayTuple`) REFERENCES `bioassaytuple` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementTuple3` FOREIGN KEY (`DesignElement`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("designelementtuple", Database:="warehouse", SchemaSQL:="
CREATE TABLE `designelementtuple` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `BioAssayTuple` bigint(20) DEFAULT NULL,
  `DesignElement` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_DesignElementTuple1` (`DataSetWID`),
  KEY `FK_DesignElementTuple2` (`BioAssayTuple`),
  KEY `FK_DesignElementTuple3` (`DesignElement`),
  CONSTRAINT `FK_DesignElementTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementTuple2` FOREIGN KEY (`BioAssayTuple`) REFERENCES `bioassaytuple` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementTuple3` FOREIGN KEY (`DesignElement`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class designelementtuple: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("BioAssayTuple"), DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayTuple")> Public Property BioAssayTuple As Long
    <DatabaseField("DesignElement"), DataType(MySqlDbType.Int64, "20"), Column(Name:="DesignElement")> Public Property DesignElement As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `designelementtuple` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `designelementtuple` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssayTuple`='{2}', `DesignElement`='{3}' WHERE `WID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `designelementtuple` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{WID}', '{DataSetWID}', '{BioAssayTuple}', '{DesignElement}')"
        Else
            Return $"('{WID}', '{DataSetWID}', '{BioAssayTuple}', '{DesignElement}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `designelementtuple` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssayTuple`='{2}', `DesignElement`='{3}' WHERE `WID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, BioAssayTuple, DesignElement, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As designelementtuple
                         Return DirectCast(MyClass.MemberwiseClone, designelementtuple)
                     End Function
End Class


End Namespace
