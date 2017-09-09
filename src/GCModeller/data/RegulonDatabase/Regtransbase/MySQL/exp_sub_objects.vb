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
''' DROP TABLE IF EXISTS `exp_sub_objects`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `exp_sub_objects` (
'''   `pkg_guid` int(11) NOT NULL DEFAULT '0',
'''   `art_guid` int(11) NOT NULL DEFAULT '0',
'''   `exp_guid` int(11) NOT NULL DEFAULT '0',
'''   `obj_guid` int(11) NOT NULL DEFAULT '0',
'''   `obj_type_id` int(11) DEFAULT NULL,
'''   `order_num` int(11) DEFAULT NULL,
'''   `strand` int(1) DEFAULT NULL,
'''   PRIMARY KEY (`exp_guid`,`obj_guid`),
'''   KEY `FK_exp_sub_objects-pkg_guid` (`pkg_guid`),
'''   KEY `FK_exp_sub_objects-art_guid` (`art_guid`),
'''   KEY `obj_guid` (`obj_guid`),
'''   CONSTRAINT `FK_exp_sub_objects-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
'''   CONSTRAINT `FK_exp_sub_objects-exp_guid` FOREIGN KEY (`exp_guid`) REFERENCES `experiments` (`exp_guid`),
'''   CONSTRAINT `FK_exp_sub_objects-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
'''   CONSTRAINT `exp_sub_objects_ibfk_1` FOREIGN KEY (`obj_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("exp_sub_objects", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `exp_sub_objects` (
  `pkg_guid` int(11) NOT NULL DEFAULT '0',
  `art_guid` int(11) NOT NULL DEFAULT '0',
  `exp_guid` int(11) NOT NULL DEFAULT '0',
  `obj_guid` int(11) NOT NULL DEFAULT '0',
  `obj_type_id` int(11) DEFAULT NULL,
  `order_num` int(11) DEFAULT NULL,
  `strand` int(1) DEFAULT NULL,
  PRIMARY KEY (`exp_guid`,`obj_guid`),
  KEY `FK_exp_sub_objects-pkg_guid` (`pkg_guid`),
  KEY `FK_exp_sub_objects-art_guid` (`art_guid`),
  KEY `obj_guid` (`obj_guid`),
  CONSTRAINT `FK_exp_sub_objects-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
  CONSTRAINT `FK_exp_sub_objects-exp_guid` FOREIGN KEY (`exp_guid`) REFERENCES `experiments` (`exp_guid`),
  CONSTRAINT `FK_exp_sub_objects-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
  CONSTRAINT `exp_sub_objects_ibfk_1` FOREIGN KEY (`obj_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class exp_sub_objects: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pkg_guid"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property pkg_guid As Long
    <DatabaseField("art_guid"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property art_guid As Long
    <DatabaseField("exp_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property exp_guid As Long
    <DatabaseField("obj_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property obj_guid As Long
    <DatabaseField("obj_type_id"), DataType(MySqlDbType.Int64, "11")> Public Property obj_type_id As Long
    <DatabaseField("order_num"), DataType(MySqlDbType.Int64, "11")> Public Property order_num As Long
    <DatabaseField("strand"), DataType(MySqlDbType.Int64, "1")> Public Property strand As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `exp_sub_objects` (`pkg_guid`, `art_guid`, `exp_guid`, `obj_guid`, `obj_type_id`, `order_num`, `strand`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `exp_sub_objects` (`pkg_guid`, `art_guid`, `exp_guid`, `obj_guid`, `obj_type_id`, `order_num`, `strand`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `exp_sub_objects` WHERE `exp_guid`='{0}' and `obj_guid`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `exp_sub_objects` SET `pkg_guid`='{0}', `art_guid`='{1}', `exp_guid`='{2}', `obj_guid`='{3}', `obj_type_id`='{4}', `order_num`='{5}', `strand`='{6}' WHERE `exp_guid`='{7}' and `obj_guid`='{8}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `exp_sub_objects` WHERE `exp_guid`='{0}' and `obj_guid`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, exp_guid, obj_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `exp_sub_objects` (`pkg_guid`, `art_guid`, `exp_guid`, `obj_guid`, `obj_type_id`, `order_num`, `strand`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, pkg_guid, art_guid, exp_guid, obj_guid, obj_type_id, order_num, strand)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{pkg_guid}', '{art_guid}', '{exp_guid}', '{obj_guid}', '{obj_type_id}', '{order_num}', '{strand}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `exp_sub_objects` (`pkg_guid`, `art_guid`, `exp_guid`, `obj_guid`, `obj_type_id`, `order_num`, `strand`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, pkg_guid, art_guid, exp_guid, obj_guid, obj_type_id, order_num, strand)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `exp_sub_objects` SET `pkg_guid`='{0}', `art_guid`='{1}', `exp_guid`='{2}', `obj_guid`='{3}', `obj_type_id`='{4}', `order_num`='{5}', `strand`='{6}' WHERE `exp_guid`='{7}' and `obj_guid`='{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pkg_guid, art_guid, exp_guid, obj_guid, obj_type_id, order_num, strand, exp_guid, obj_guid)
    End Function
#End Region
End Class


End Namespace
