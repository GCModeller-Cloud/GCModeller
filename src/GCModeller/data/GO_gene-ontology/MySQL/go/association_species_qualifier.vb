REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @9/5/2016 7:59:33 AM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `association_species_qualifier`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `association_species_qualifier` (
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   `association_id` int(11) NOT NULL,
'''   `species_id` int(11) DEFAULT NULL,
'''   PRIMARY KEY (`id`),
'''   KEY `association_id` (`association_id`),
'''   KEY `species_id` (`species_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("association_species_qualifier", Database:="go", SchemaSQL:="
CREATE TABLE `association_species_qualifier` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `association_id` int(11) NOT NULL,
  `species_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `association_id` (`association_id`),
  KEY `species_id` (`species_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class association_species_qualifier: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("association_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property association_id As Long
    <DatabaseField("species_id"), DataType(MySqlDbType.Int64, "11")> Public Property species_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `association_species_qualifier` (`association_id`, `species_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `association_species_qualifier` (`association_id`, `species_id`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `association_species_qualifier` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `association_species_qualifier` SET `id`='{0}', `association_id`='{1}', `species_id`='{2}' WHERE `id` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `association_species_qualifier` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `association_species_qualifier` (`association_id`, `species_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, association_id, species_id)
    End Function
''' <summary>
''' ```SQL
''' REPLACE INTO `association_species_qualifier` (`association_id`, `species_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, association_id, species_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `association_species_qualifier` SET `id`='{0}', `association_id`='{1}', `species_id`='{2}' WHERE `id` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, association_id, species_id, id)
    End Function
#End Region
End Class


End Namespace
