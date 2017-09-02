﻿#Region "Microsoft.VisualBasic::7c58e0612ab40c66367837b247b87788, ..\repository\DataMySql\kb_UniProtKB\MySQL\protein_alternative_name.vb"

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
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_alternative_name`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_alternative_name` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) NOT NULL,
'''   `name` varchar(45) NOT NULL,
'''   `fullName` varchar(45) DEFAULT NULL,
'''   `shortName1` varchar(45) DEFAULT NULL,
'''   `shortName2` varchar(45) DEFAULT NULL,
'''   `shortName3` varchar(45) DEFAULT NULL,
'''   `shortName4` varchar(45) DEFAULT NULL,
'''   `shortName5` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`hash_code`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_alternative_name", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_alternative_name` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `fullName` varchar(45) DEFAULT NULL,
  `shortName1` varchar(45) DEFAULT NULL,
  `shortName2` varchar(45) DEFAULT NULL,
  `shortName3` varchar(45) DEFAULT NULL,
  `shortName4` varchar(45) DEFAULT NULL,
  `shortName5` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`hash_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class protein_alternative_name: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("name"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="name")> Public Property name As String
    <DatabaseField("fullName"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="fullName")> Public Property fullName As String
    <DatabaseField("shortName1"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="shortName1")> Public Property shortName1 As String
    <DatabaseField("shortName2"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="shortName2")> Public Property shortName2 As String
    <DatabaseField("shortName3"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="shortName3")> Public Property shortName3 As String
    <DatabaseField("shortName4"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="shortName4")> Public Property shortName4 As String
    <DatabaseField("shortName5"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="shortName5")> Public Property shortName5 As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_alternative_name` (`hash_code`, `uniprot_id`, `name`, `fullName`, `shortName1`, `shortName2`, `shortName3`, `shortName4`, `shortName5`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_alternative_name` (`hash_code`, `uniprot_id`, `name`, `fullName`, `shortName1`, `shortName2`, `shortName3`, `shortName4`, `shortName5`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_alternative_name` WHERE `hash_code` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_alternative_name` SET `hash_code`='{0}', `uniprot_id`='{1}', `name`='{2}', `fullName`='{3}', `shortName1`='{4}', `shortName2`='{5}', `shortName3`='{6}', `shortName4`='{7}', `shortName5`='{8}' WHERE `hash_code` = '{9}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_alternative_name` WHERE `hash_code` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_alternative_name` (`hash_code`, `uniprot_id`, `name`, `fullName`, `shortName1`, `shortName2`, `shortName3`, `shortName4`, `shortName5`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, name, fullName, shortName1, shortName2, shortName3, shortName4, shortName5)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{hash_code}', '{uniprot_id}', '{name}', '{fullName}', '{shortName1}', '{shortName2}', '{shortName3}', '{shortName4}', '{shortName5}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_alternative_name` (`hash_code`, `uniprot_id`, `name`, `fullName`, `shortName1`, `shortName2`, `shortName3`, `shortName4`, `shortName5`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, name, fullName, shortName1, shortName2, shortName3, shortName4, shortName5)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_alternative_name` SET `hash_code`='{0}', `uniprot_id`='{1}', `name`='{2}', `fullName`='{3}', `shortName1`='{4}', `shortName2`='{5}', `shortName3`='{6}', `shortName4`='{7}', `shortName5`='{8}' WHERE `hash_code` = '{9}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, name, fullName, shortName1, shortName2, shortName3, shortName4, shortName5, hash_code)
    End Function
#End Region
Public Function Clone() As protein_alternative_name
                  Return DirectCast(MyClass.MemberwiseClone, protein_alternative_name)
              End Function
End Class


End Namespace

