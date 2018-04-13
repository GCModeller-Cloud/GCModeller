﻿#Region "Microsoft.VisualBasic::17516d799da8137359d32076c4c3a9d3, data\Reactome\LocalMySQL\gk_current_dn\reactionlikeevent_to_physicalentity.vb"

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

    ' Class reactionlikeevent_to_physicalentity
    ' 
    '     Properties: physicalEntityId, reactionLikeEventId
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:23 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current_dn

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `reactionlikeevent_to_physicalentity`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reactionlikeevent_to_physicalentity` (
'''   `reactionLikeEventId` int(32) NOT NULL DEFAULT '0',
'''   `physicalEntityId` int(32) NOT NULL DEFAULT '0',
'''   PRIMARY KEY (`reactionLikeEventId`,`physicalEntityId`),
'''   KEY `physicalEntityId` (`physicalEntityId`),
'''   CONSTRAINT `ReactionLikeEvent_To_PhysicalEntity_ibfk_1` FOREIGN KEY (`reactionLikeEventId`) REFERENCES `reactionlikeevent` (`id`),
'''   CONSTRAINT `ReactionLikeEvent_To_PhysicalEntity_ibfk_2` FOREIGN KEY (`physicalEntityId`) REFERENCES `physicalentity` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' -- Dumping events for database 'gk_current_dn'
''' --
''' 
''' --
''' -- Dumping routines for database 'gk_current_dn'
''' --
''' /*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
''' 
''' /*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
''' /*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
''' /*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
''' /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
''' /*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
''' /*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
''' /*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
''' 
''' -- Dump completed on 2017-03-29 21:34:53
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reactionlikeevent_to_physicalentity", Database:="gk_current_dn", SchemaSQL:="
CREATE TABLE `reactionlikeevent_to_physicalentity` (
  `reactionLikeEventId` int(32) NOT NULL DEFAULT '0',
  `physicalEntityId` int(32) NOT NULL DEFAULT '0',
  PRIMARY KEY (`reactionLikeEventId`,`physicalEntityId`),
  KEY `physicalEntityId` (`physicalEntityId`),
  CONSTRAINT `ReactionLikeEvent_To_PhysicalEntity_ibfk_1` FOREIGN KEY (`reactionLikeEventId`) REFERENCES `reactionlikeevent` (`id`),
  CONSTRAINT `ReactionLikeEvent_To_PhysicalEntity_ibfk_2` FOREIGN KEY (`physicalEntityId`) REFERENCES `physicalentity` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class reactionlikeevent_to_physicalentity: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("reactionLikeEventId"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32"), Column(Name:="reactionLikeEventId"), XmlAttribute> Public Property reactionLikeEventId As Long
    <DatabaseField("physicalEntityId"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32"), Column(Name:="physicalEntityId"), XmlAttribute> Public Property physicalEntityId As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `reactionlikeevent_to_physicalentity` (`reactionLikeEventId`, `physicalEntityId`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `reactionlikeevent_to_physicalentity` (`reactionLikeEventId`, `physicalEntityId`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `reactionlikeevent_to_physicalentity` WHERE `reactionLikeEventId`='{0}' and `physicalEntityId`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `reactionlikeevent_to_physicalentity` SET `reactionLikeEventId`='{0}', `physicalEntityId`='{1}' WHERE `reactionLikeEventId`='{2}' and `physicalEntityId`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `reactionlikeevent_to_physicalentity` WHERE `reactionLikeEventId`='{0}' and `physicalEntityId`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, reactionLikeEventId, physicalEntityId)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `reactionlikeevent_to_physicalentity` (`reactionLikeEventId`, `physicalEntityId`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, reactionLikeEventId, physicalEntityId)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{reactionLikeEventId}', '{physicalEntityId}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reactionlikeevent_to_physicalentity` (`reactionLikeEventId`, `physicalEntityId`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, reactionLikeEventId, physicalEntityId)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `reactionlikeevent_to_physicalentity` SET `reactionLikeEventId`='{0}', `physicalEntityId`='{1}' WHERE `reactionLikeEventId`='{2}' and `physicalEntityId`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, reactionLikeEventId, physicalEntityId, reactionLikeEventId, physicalEntityId)
    End Function
#End Region
Public Function Clone() As reactionlikeevent_to_physicalentity
                  Return DirectCast(MyClass.MemberwiseClone, reactionlikeevent_to_physicalentity)
              End Function
End Class


End Namespace
