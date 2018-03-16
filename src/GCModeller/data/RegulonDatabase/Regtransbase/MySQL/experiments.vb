﻿#Region "Microsoft.VisualBasic::118ef59dfee46d60ded6316129351e91, data\RegulonDatabase\Regtransbase\MySQL\experiments.vb"

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

    ' Class experiments
    ' 
    '     Properties: art_guid, descript, exp_guid, last_update, pkg_guid
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:17 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `experiments`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `experiments` (
'''   `exp_guid` int(11) NOT NULL DEFAULT '0',
'''   `pkg_guid` int(11) NOT NULL DEFAULT '0',
'''   `art_guid` int(11) NOT NULL DEFAULT '0',
'''   `descript` blob,
'''   `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`exp_guid`),
'''   KEY `FK_experiments-pkg_guid` (`pkg_guid`),
'''   KEY `FK_experiments-art_guid` (`art_guid`),
'''   CONSTRAINT `FK_experiments-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
'''   CONSTRAINT `FK_experiments-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("experiments", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `experiments` (
  `exp_guid` int(11) NOT NULL DEFAULT '0',
  `pkg_guid` int(11) NOT NULL DEFAULT '0',
  `art_guid` int(11) NOT NULL DEFAULT '0',
  `descript` blob,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`exp_guid`),
  KEY `FK_experiments-pkg_guid` (`pkg_guid`),
  KEY `FK_experiments-art_guid` (`art_guid`),
  CONSTRAINT `FK_experiments-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
  CONSTRAINT `FK_experiments-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class experiments: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("exp_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="exp_guid"), XmlAttribute> Public Property exp_guid As Long
    <DatabaseField("pkg_guid"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="pkg_guid")> Public Property pkg_guid As Long
    <DatabaseField("art_guid"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="art_guid")> Public Property art_guid As Long
    <DatabaseField("descript"), DataType(MySqlDbType.Blob), Column(Name:="descript")> Public Property descript As Byte()
    <DatabaseField("last_update"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="last_update")> Public Property last_update As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `experiments` (`exp_guid`, `pkg_guid`, `art_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `experiments` (`exp_guid`, `pkg_guid`, `art_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `experiments` WHERE `exp_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `experiments` SET `exp_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `descript`='{3}', `last_update`='{4}' WHERE `exp_guid` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `experiments` WHERE `exp_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, exp_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `experiments` (`exp_guid`, `pkg_guid`, `art_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, exp_guid, pkg_guid, art_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update))
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{exp_guid}', '{pkg_guid}', '{art_guid}', '{descript}', '{last_update}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `experiments` (`exp_guid`, `pkg_guid`, `art_guid`, `descript`, `last_update`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, exp_guid, pkg_guid, art_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update))
    End Function
''' <summary>
''' ```SQL
''' UPDATE `experiments` SET `exp_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `descript`='{3}', `last_update`='{4}' WHERE `exp_guid` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, exp_guid, pkg_guid, art_guid, descript, MySqlScript.ToMySqlDateTimeString(last_update), exp_guid)
    End Function
#End Region
Public Function Clone() As experiments
                  Return DirectCast(MyClass.MemberwiseClone, experiments)
              End Function
End Class


End Namespace

