﻿#Region "Microsoft.VisualBasic::563ccd976187bf06fd7a189a68d158c4, ..\GCModeller\data\RegulonDatabase\Regtransbase\MySQL\reg_elem_sub_objects.vb"

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

REM  Dump @3/29/2017 10:54:58 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `reg_elem_sub_objects`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reg_elem_sub_objects` (
'''   `pkg_guid` int(11) NOT NULL DEFAULT '0',
'''   `art_guid` int(11) NOT NULL DEFAULT '0',
'''   `parent_guid` int(11) NOT NULL DEFAULT '0',
'''   `parent_type_id` int(11) DEFAULT NULL,
'''   `child_guid` int(11) NOT NULL DEFAULT '0',
'''   `child_type_id` int(11) DEFAULT NULL,
'''   `child_n` int(11) DEFAULT NULL,
'''   `strand` int(1) DEFAULT NULL,
'''   PRIMARY KEY (`parent_guid`,`child_guid`),
'''   KEY `FK_reg_elem_sub_objects-pkg_guid` (`pkg_guid`),
'''   KEY `FK_reg_elem_sub_objects-art_guid` (`art_guid`),
'''   KEY `child_guid` (`child_guid`),
'''   CONSTRAINT `FK_reg_elem_sub_objects-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
'''   CONSTRAINT `FK_reg_elem_sub_objects-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
'''   CONSTRAINT `reg_elem_sub_objects_ibfk_1` FOREIGN KEY (`child_guid`) REFERENCES `obj_name_genomes` (`obj_guid`),
'''   CONSTRAINT `reg_elem_sub_objects_ibfk_2` FOREIGN KEY (`parent_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reg_elem_sub_objects", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `reg_elem_sub_objects` (
  `pkg_guid` int(11) NOT NULL DEFAULT '0',
  `art_guid` int(11) NOT NULL DEFAULT '0',
  `parent_guid` int(11) NOT NULL DEFAULT '0',
  `parent_type_id` int(11) DEFAULT NULL,
  `child_guid` int(11) NOT NULL DEFAULT '0',
  `child_type_id` int(11) DEFAULT NULL,
  `child_n` int(11) DEFAULT NULL,
  `strand` int(1) DEFAULT NULL,
  PRIMARY KEY (`parent_guid`,`child_guid`),
  KEY `FK_reg_elem_sub_objects-pkg_guid` (`pkg_guid`),
  KEY `FK_reg_elem_sub_objects-art_guid` (`art_guid`),
  KEY `child_guid` (`child_guid`),
  CONSTRAINT `FK_reg_elem_sub_objects-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
  CONSTRAINT `FK_reg_elem_sub_objects-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
  CONSTRAINT `reg_elem_sub_objects_ibfk_1` FOREIGN KEY (`child_guid`) REFERENCES `obj_name_genomes` (`obj_guid`),
  CONSTRAINT `reg_elem_sub_objects_ibfk_2` FOREIGN KEY (`parent_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class reg_elem_sub_objects: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pkg_guid"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property pkg_guid As Long
    <DatabaseField("art_guid"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property art_guid As Long
    <DatabaseField("parent_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property parent_guid As Long
    <DatabaseField("parent_type_id"), DataType(MySqlDbType.Int64, "11")> Public Property parent_type_id As Long
    <DatabaseField("child_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property child_guid As Long
    <DatabaseField("child_type_id"), DataType(MySqlDbType.Int64, "11")> Public Property child_type_id As Long
    <DatabaseField("child_n"), DataType(MySqlDbType.Int64, "11")> Public Property child_n As Long
    <DatabaseField("strand"), DataType(MySqlDbType.Int64, "1")> Public Property strand As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `reg_elem_sub_objects` (`pkg_guid`, `art_guid`, `parent_guid`, `parent_type_id`, `child_guid`, `child_type_id`, `child_n`, `strand`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `reg_elem_sub_objects` (`pkg_guid`, `art_guid`, `parent_guid`, `parent_type_id`, `child_guid`, `child_type_id`, `child_n`, `strand`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `reg_elem_sub_objects` WHERE `parent_guid`='{0}' and `child_guid`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `reg_elem_sub_objects` SET `pkg_guid`='{0}', `art_guid`='{1}', `parent_guid`='{2}', `parent_type_id`='{3}', `child_guid`='{4}', `child_type_id`='{5}', `child_n`='{6}', `strand`='{7}' WHERE `parent_guid`='{8}' and `child_guid`='{9}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `reg_elem_sub_objects` WHERE `parent_guid`='{0}' and `child_guid`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, parent_guid, child_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `reg_elem_sub_objects` (`pkg_guid`, `art_guid`, `parent_guid`, `parent_type_id`, `child_guid`, `child_type_id`, `child_n`, `strand`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, pkg_guid, art_guid, parent_guid, parent_type_id, child_guid, child_type_id, child_n, strand)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{pkg_guid}', '{art_guid}', '{parent_guid}', '{parent_type_id}', '{child_guid}', '{child_type_id}', '{child_n}', '{strand}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reg_elem_sub_objects` (`pkg_guid`, `art_guid`, `parent_guid`, `parent_type_id`, `child_guid`, `child_type_id`, `child_n`, `strand`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, pkg_guid, art_guid, parent_guid, parent_type_id, child_guid, child_type_id, child_n, strand)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `reg_elem_sub_objects` SET `pkg_guid`='{0}', `art_guid`='{1}', `parent_guid`='{2}', `parent_type_id`='{3}', `child_guid`='{4}', `child_type_id`='{5}', `child_n`='{6}', `strand`='{7}' WHERE `parent_guid`='{8}' and `child_guid`='{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pkg_guid, art_guid, parent_guid, parent_type_id, child_guid, child_type_id, child_n, strand, parent_guid, child_guid)
    End Function
#End Region
End Class


End Namespace
