﻿#Region "Microsoft.VisualBasic::ddab0d403f549c1ee2b97b0178e99f2d, data\RegulonDatabase\RegulonDB\MySQL\t_factor_d_tmp.vb"

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

    ' Class t_factor_d_tmp
    ' 
    '     Properties: t_factor_id, t_factor_key_id_org, t_factor_name, t_factor_site_group, t_factor_site_length
    '                 tf_id
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:14 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `t_factor_d_tmp`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `t_factor_d_tmp` (
'''   `tf_id` decimal(10,0) NOT NULL,
'''   `t_factor_id` char(12) NOT NULL,
'''   `t_factor_name` varchar(255) DEFAULT NULL,
'''   `t_factor_site_length` decimal(10,0) DEFAULT NULL,
'''   `t_factor_key_id_org` char(5) NOT NULL,
'''   `t_factor_site_group` decimal(10,0) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("t_factor_d_tmp", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `t_factor_d_tmp` (
  `tf_id` decimal(10,0) NOT NULL,
  `t_factor_id` char(12) NOT NULL,
  `t_factor_name` varchar(255) DEFAULT NULL,
  `t_factor_site_length` decimal(10,0) DEFAULT NULL,
  `t_factor_key_id_org` char(5) NOT NULL,
  `t_factor_site_group` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class t_factor_d_tmp: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("tf_id"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="tf_id")> Public Property tf_id As Decimal
    <DatabaseField("t_factor_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="t_factor_id")> Public Property t_factor_id As String
    <DatabaseField("t_factor_name"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="t_factor_name")> Public Property t_factor_name As String
    <DatabaseField("t_factor_site_length"), DataType(MySqlDbType.Decimal), Column(Name:="t_factor_site_length")> Public Property t_factor_site_length As Decimal
    <DatabaseField("t_factor_key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5"), Column(Name:="t_factor_key_id_org")> Public Property t_factor_key_id_org As String
    <DatabaseField("t_factor_site_group"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="t_factor_site_group")> Public Property t_factor_site_group As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `t_factor_d_tmp` (`tf_id`, `t_factor_id`, `t_factor_name`, `t_factor_site_length`, `t_factor_key_id_org`, `t_factor_site_group`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `t_factor_d_tmp` (`tf_id`, `t_factor_id`, `t_factor_name`, `t_factor_site_length`, `t_factor_key_id_org`, `t_factor_site_group`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `t_factor_d_tmp` WHERE ;</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `t_factor_d_tmp` SET `tf_id`='{0}', `t_factor_id`='{1}', `t_factor_name`='{2}', `t_factor_site_length`='{3}', `t_factor_key_id_org`='{4}', `t_factor_site_group`='{5}' WHERE ;</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `t_factor_d_tmp` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `t_factor_d_tmp` (`tf_id`, `t_factor_id`, `t_factor_name`, `t_factor_site_length`, `t_factor_key_id_org`, `t_factor_site_group`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, tf_id, t_factor_id, t_factor_name, t_factor_site_length, t_factor_key_id_org, t_factor_site_group)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{tf_id}', '{t_factor_id}', '{t_factor_name}', '{t_factor_site_length}', '{t_factor_key_id_org}', '{t_factor_site_group}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `t_factor_d_tmp` (`tf_id`, `t_factor_id`, `t_factor_name`, `t_factor_site_length`, `t_factor_key_id_org`, `t_factor_site_group`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, tf_id, t_factor_id, t_factor_name, t_factor_site_length, t_factor_key_id_org, t_factor_site_group)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `t_factor_d_tmp` SET `tf_id`='{0}', `t_factor_id`='{1}', `t_factor_name`='{2}', `t_factor_site_length`='{3}', `t_factor_key_id_org`='{4}', `t_factor_site_group`='{5}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region
Public Function Clone() As t_factor_d_tmp
                  Return DirectCast(MyClass.MemberwiseClone, t_factor_d_tmp)
              End Function
End Class


End Namespace
