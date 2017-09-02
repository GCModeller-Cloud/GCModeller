﻿#Region "Microsoft.VisualBasic::fe2d634446b449939ef65242bf937b8a, ..\repository\DataMySql\kb_UniProtKB\MySQL\protein_structures.vb"

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
''' 主要是pdb结构记录数据
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_structures`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_structures` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) NOT NULL,
'''   `pdb_id` varchar(45) DEFAULT NULL,
'''   `method` varchar(45) DEFAULT NULL,
'''   `resolution` varchar(45) DEFAULT NULL,
'''   `chains` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`hash_code`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='主要是pdb结构记录数据';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_structures", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_structures` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) NOT NULL,
  `pdb_id` varchar(45) DEFAULT NULL,
  `method` varchar(45) DEFAULT NULL,
  `resolution` varchar(45) DEFAULT NULL,
  `chains` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`hash_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='主要是pdb结构记录数据';")>
Public Class protein_structures: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("pdb_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="pdb_id")> Public Property pdb_id As String
    <DatabaseField("method"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="method")> Public Property method As String
    <DatabaseField("resolution"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="resolution")> Public Property resolution As String
    <DatabaseField("chains"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="chains")> Public Property chains As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_structures` (`hash_code`, `uniprot_id`, `pdb_id`, `method`, `resolution`, `chains`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_structures` (`hash_code`, `uniprot_id`, `pdb_id`, `method`, `resolution`, `chains`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_structures` WHERE `hash_code` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_structures` SET `hash_code`='{0}', `uniprot_id`='{1}', `pdb_id`='{2}', `method`='{3}', `resolution`='{4}', `chains`='{5}' WHERE `hash_code` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_structures` WHERE `hash_code` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_structures` (`hash_code`, `uniprot_id`, `pdb_id`, `method`, `resolution`, `chains`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, pdb_id, method, resolution, chains)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{hash_code}', '{uniprot_id}', '{pdb_id}', '{method}', '{resolution}', '{chains}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_structures` (`hash_code`, `uniprot_id`, `pdb_id`, `method`, `resolution`, `chains`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, pdb_id, method, resolution, chains)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_structures` SET `hash_code`='{0}', `uniprot_id`='{1}', `pdb_id`='{2}', `method`='{3}', `resolution`='{4}', `chains`='{5}' WHERE `hash_code` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, pdb_id, method, resolution, chains, hash_code)
    End Function
#End Region
Public Function Clone() As protein_structures
                  Return DirectCast(MyClass.MemberwiseClone, protein_structures)
              End Function
End Class


End Namespace

