﻿#Region "Microsoft.VisualBasic::e2c64fe4192143ec6da164a7ac605394, ..\repository\DataMySql\kb_UniProtKB\MySQL\protein_subcellular_location.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
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
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/3 3:08:05


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_UniProtKB.mysql

''' <summary>
''' ```SQL
''' 目标蛋白质在细胞质中的亚细胞定位结果
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_subcellular_location`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_subcellular_location` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) DEFAULT NULL,
'''   `location` varchar(45) DEFAULT NULL,
'''   `location_id` int(10) unsigned DEFAULT NULL,
'''   `topology` varchar(45) DEFAULT NULL,
'''   `topology_id` int(10) unsigned DEFAULT NULL,
'''   PRIMARY KEY (`hash_code`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='目标蛋白质在细胞质中的亚细胞定位结果';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_subcellular_location", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_subcellular_location` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) DEFAULT NULL,
  `location` varchar(45) DEFAULT NULL,
  `location_id` int(10) unsigned DEFAULT NULL,
  `topology` varchar(45) DEFAULT NULL,
  `topology_id` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`hash_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='目标蛋白质在细胞质中的亚细胞定位结果';")>
Public Class protein_subcellular_location: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("location"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="location")> Public Property location As String
    <DatabaseField("location_id"), DataType(MySqlDbType.Int64, "10"), Column(Name:="location_id")> Public Property location_id As Long
    <DatabaseField("topology"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="topology")> Public Property topology As String
    <DatabaseField("topology_id"), DataType(MySqlDbType.Int64, "10"), Column(Name:="topology_id")> Public Property topology_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_subcellular_location` (`hash_code`, `uniprot_id`, `location`, `location_id`, `topology`, `topology_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_subcellular_location` (`hash_code`, `uniprot_id`, `location`, `location_id`, `topology`, `topology_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_subcellular_location` WHERE `hash_code` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_subcellular_location` SET `hash_code`='{0}', `uniprot_id`='{1}', `location`='{2}', `location_id`='{3}', `topology`='{4}', `topology_id`='{5}' WHERE `hash_code` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_subcellular_location` WHERE `hash_code` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_subcellular_location` (`hash_code`, `uniprot_id`, `location`, `location_id`, `topology`, `topology_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, location, location_id, topology, topology_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{hash_code}', '{uniprot_id}', '{location}', '{location_id}', '{topology}', '{topology_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_subcellular_location` (`hash_code`, `uniprot_id`, `location`, `location_id`, `topology`, `topology_id`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, location, location_id, topology, topology_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_subcellular_location` SET `hash_code`='{0}', `uniprot_id`='{1}', `location`='{2}', `location_id`='{3}', `topology`='{4}', `topology_id`='{5}' WHERE `hash_code` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, location, location_id, topology, topology_id, hash_code)
    End Function
#End Region
Public Function Clone() As protein_subcellular_location
                  Return DirectCast(MyClass.MemberwiseClone, protein_subcellular_location)
              End Function
End Class


End Namespace

