REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:52 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `method2pub`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `method2pub` (
'''   `pub_id` varchar(11) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `method_ac` varchar(25) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   PRIMARY KEY (`method_ac`,`pub_id`),
'''   KEY `fk_method2pub$pub_id` (`pub_id`),
'''   CONSTRAINT `fk_method2pub$method` FOREIGN KEY (`method_ac`) REFERENCES `method` (`method_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_method2pub$pub_id` FOREIGN KEY (`pub_id`) REFERENCES `pub` (`pub_id`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("method2pub", Database:="interpro", SchemaSQL:="
CREATE TABLE `method2pub` (
  `pub_id` varchar(11) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `method_ac` varchar(25) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  PRIMARY KEY (`method_ac`,`pub_id`),
  KEY `fk_method2pub$pub_id` (`pub_id`),
  CONSTRAINT `fk_method2pub$method` FOREIGN KEY (`method_ac`) REFERENCES `method` (`method_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_method2pub$pub_id` FOREIGN KEY (`pub_id`) REFERENCES `pub` (`pub_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class method2pub: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pub_id"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "11")> Public Property pub_id As String
    <DatabaseField("method_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "25")> Public Property method_ac As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `method2pub` (`pub_id`, `method_ac`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `method2pub` (`pub_id`, `method_ac`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `method2pub` WHERE `method_ac`='{0}' and `pub_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `method2pub` SET `pub_id`='{0}', `method_ac`='{1}' WHERE `method_ac`='{2}' and `pub_id`='{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `method2pub` WHERE `method_ac`='{0}' and `pub_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, method_ac, pub_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `method2pub` (`pub_id`, `method_ac`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, pub_id, method_ac)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{pub_id}', '{method_ac}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `method2pub` (`pub_id`, `method_ac`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, pub_id, method_ac)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `method2pub` SET `pub_id`='{0}', `method_ac`='{1}' WHERE `method_ac`='{2}' and `pub_id`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pub_id, method_ac, method_ac, pub_id)
    End Function
#End Region
End Class


End Namespace
