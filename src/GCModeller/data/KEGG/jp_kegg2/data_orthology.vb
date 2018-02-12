﻿#Region "Microsoft.VisualBasic::978ae085cd84171832845db12e4ef5c6, data\KEGG\jp_kegg2\data_orthology.vb"

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

    ' Class data_orthology
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @6/3/2017 9:51:53 AM


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace mysql

''' <summary>
''' ```SQL
''' KEGG基因直系同源数据
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `data_orthology`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `data_orthology` (
'''   `uid` int(11) NOT NULL,
'''   `KEGG` varchar(45) NOT NULL COMMENT 'KO编号',
'''   `name` varchar(45) DEFAULT NULL,
'''   `definition` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`uid`),
'''   UNIQUE KEY `uid_UNIQUE` (`uid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='KEGG基因直系同源数据';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("data_orthology", Database:="jp_kegg2", SchemaSQL:="
CREATE TABLE `data_orthology` (
  `uid` int(11) NOT NULL,
  `KEGG` varchar(45) NOT NULL COMMENT 'KO编号',
  `name` varchar(45) DEFAULT NULL,
  `definition` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`uid`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='KEGG基因直系同源数据';")>
Public Class data_orthology: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="uid")> Public Property uid As Long
''' <summary>
''' KO编号
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("KEGG"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="KEGG")> Public Property KEGG As String
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="name")> Public Property name As String
    <DatabaseField("definition"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="definition")> Public Property definition As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `data_orthology` (`uid`, `KEGG`, `name`, `definition`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `data_orthology` (`uid`, `KEGG`, `name`, `definition`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `data_orthology` WHERE `uid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `data_orthology` SET `uid`='{0}', `KEGG`='{1}', `name`='{2}', `definition`='{3}' WHERE `uid` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `data_orthology` WHERE `uid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `data_orthology` (`uid`, `KEGG`, `name`, `definition`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, uid, KEGG, name, definition)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{uid}', '{KEGG}', '{name}', '{definition}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `data_orthology` (`uid`, `KEGG`, `name`, `definition`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, uid, KEGG, name, definition)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `data_orthology` SET `uid`='{0}', `KEGG`='{1}', `name`='{2}', `definition`='{3}' WHERE `uid` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, KEGG, name, definition, uid)
    End Function
#End Region
Public Function Clone() As data_orthology
                  Return DirectCast(MyClass.MemberwiseClone, data_orthology)
              End Function
End Class


End Namespace
