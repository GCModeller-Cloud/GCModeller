REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/3 12:29:35


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_UniProtKB.mysql

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_feature_site`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_feature_site` (
'''   `uid` int(10) unsigned NOT NULL,
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) DEFAULT NULL,
'''   `type_id` int(10) unsigned NOT NULL,
'''   `type` varchar(45) DEFAULT NULL,
'''   `description` varchar(45) DEFAULT NULL,
'''   `position` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`uid`),
'''   UNIQUE KEY `uid_UNIQUE` (`uid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_feature_site", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_feature_site` (
  `uid` int(10) unsigned NOT NULL,
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) DEFAULT NULL,
  `type_id` int(10) unsigned NOT NULL,
  `type` varchar(45) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `position` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`uid`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class protein_feature_site: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="uid"), XmlAttribute> Public Property uid As Long
    <DatabaseField("hash_code"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code")> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("type_id"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="type_id")> Public Property type_id As Long
    <DatabaseField("type"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="type")> Public Property type As String
    <DatabaseField("description"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="description")> Public Property description As String
    <DatabaseField("position"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="position")> Public Property position As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_feature_site` (`uid`, `hash_code`, `uniprot_id`, `type_id`, `type`, `description`, `position`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_feature_site` (`uid`, `hash_code`, `uniprot_id`, `type_id`, `type`, `description`, `position`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_feature_site` WHERE `uid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_feature_site` SET `uid`='{0}', `hash_code`='{1}', `uniprot_id`='{2}', `type_id`='{3}', `type`='{4}', `description`='{5}', `position`='{6}' WHERE `uid` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_feature_site` WHERE `uid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_feature_site` (`uid`, `hash_code`, `uniprot_id`, `type_id`, `type`, `description`, `position`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, uid, hash_code, uniprot_id, type_id, type, description, position)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{uid}', '{hash_code}', '{uniprot_id}', '{type_id}', '{type}', '{description}', '{position}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_feature_site` (`uid`, `hash_code`, `uniprot_id`, `type_id`, `type`, `description`, `position`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, uid, hash_code, uniprot_id, type_id, type, description, position)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_feature_site` SET `uid`='{0}', `hash_code`='{1}', `uniprot_id`='{2}', `type_id`='{3}', `type`='{4}', `description`='{5}', `position`='{6}' WHERE `uid` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, hash_code, uniprot_id, type_id, type, description, position, uid)
    End Function
#End Region
Public Function Clone() As protein_feature_site
                  Return DirectCast(MyClass.MemberwiseClone, protein_feature_site)
              End Function
End Class


End Namespace
