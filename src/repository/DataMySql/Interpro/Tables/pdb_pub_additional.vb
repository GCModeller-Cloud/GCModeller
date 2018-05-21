REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:10


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `pdb_pub_additional`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pdb_pub_additional` (
'''   `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `pub_id` varchar(11) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   KEY `fk_pdbpubadd$entry_ac` (`entry_ac`),
'''   KEY `fk_pdbpubadd$pub_id` (`pub_id`),
'''   CONSTRAINT `fk_pdbpubadd$entry_ac` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_pdbpubadd$pub_id` FOREIGN KEY (`pub_id`) REFERENCES `pub` (`pub_id`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pdb_pub_additional", Database:="interpro", SchemaSQL:="
CREATE TABLE `pdb_pub_additional` (
  `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `pub_id` varchar(11) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  KEY `fk_pdbpubadd$entry_ac` (`entry_ac`),
  KEY `fk_pdbpubadd$pub_id` (`pub_id`),
  CONSTRAINT `fk_pdbpubadd$entry_ac` FOREIGN KEY (`entry_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_pdbpubadd$pub_id` FOREIGN KEY (`pub_id`) REFERENCES `pub` (`pub_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class pdb_pub_additional: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9"), Column(Name:="entry_ac"), XmlAttribute> Public Property entry_ac As String
    <DatabaseField("pub_id"), NotNull, DataType(MySqlDbType.VarChar, "11"), Column(Name:="pub_id")> Public Property pub_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `pdb_pub_additional` WHERE `entry_ac` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `pdb_pub_additional` SET `entry_ac`='{0}', `pub_id`='{1}' WHERE `entry_ac` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `pdb_pub_additional` WHERE `entry_ac` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry_ac)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_ac, pub_id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, entry_ac, pub_id)
        Else
        Return String.Format(INSERT_SQL, entry_ac, pub_id)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry_ac}', '{pub_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_ac, pub_id)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `pdb_pub_additional` (`entry_ac`, `pub_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, entry_ac, pub_id)
        Else
        Return String.Format(REPLACE_SQL, entry_ac, pub_id)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `pdb_pub_additional` SET `entry_ac`='{0}', `pub_id`='{1}' WHERE `entry_ac` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry_ac, pub_id, entry_ac)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As pdb_pub_additional
                         Return DirectCast(MyClass.MemberwiseClone, pdb_pub_additional)
                     End Function
End Class


End Namespace
