﻿#Region "Microsoft.VisualBasic::feb7015aca3e9d14b69435f1032daf01, data\KEGG\jp_kegg2\xref_pathway_modules.vb"

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

    ' Class xref_pathway_modules
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
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `xref_pathway_modules`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `xref_pathway_modules` (
'''   `pathway` int(11) NOT NULL,
'''   `module` int(11) NOT NULL,
'''   `KO` varchar(45) DEFAULT NULL,
'''   `name` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`pathway`,`module`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("xref_pathway_modules", Database:="jp_kegg2", SchemaSQL:="
CREATE TABLE `xref_pathway_modules` (
  `pathway` int(11) NOT NULL,
  `module` int(11) NOT NULL,
  `KO` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`pathway`,`module`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class xref_pathway_modules: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pathway"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="pathway")> Public Property pathway As Long
    <DatabaseField("module"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="module")> Public Property [module] As Long
    <DatabaseField("KO"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="KO")> Public Property KO As String
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="name")> Public Property name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `xref_pathway_modules` (`pathway`, `module`, `KO`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `xref_pathway_modules` (`pathway`, `module`, `KO`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `xref_pathway_modules` WHERE `pathway`='{0}' and `module`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `xref_pathway_modules` SET `pathway`='{0}', `module`='{1}', `KO`='{2}', `name`='{3}' WHERE `pathway`='{4}' and `module`='{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `xref_pathway_modules` WHERE `pathway`='{0}' and `module`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, pathway, [module])
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `xref_pathway_modules` (`pathway`, `module`, `KO`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, pathway, [module], KO, name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{pathway}', '{[module]}', '{KO}', '{name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `xref_pathway_modules` (`pathway`, `module`, `KO`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, pathway, [module], KO, name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `xref_pathway_modules` SET `pathway`='{0}', `module`='{1}', `KO`='{2}', `name`='{3}' WHERE `pathway`='{4}' and `module`='{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pathway, [module], KO, name, pathway, [module])
    End Function
#End Region
Public Function Clone() As xref_pathway_modules
                  Return DirectCast(MyClass.MemberwiseClone, xref_pathway_modules)
              End Function
End Class


End Namespace
