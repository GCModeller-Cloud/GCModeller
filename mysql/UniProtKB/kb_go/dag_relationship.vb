REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/8/31 23:26:08


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace mysql

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `dag_relationship`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dag_relationship` (
'''   `id` int(10) unsigned NOT NULL,
'''   `relationship` varchar(45) DEFAULT NULL,
'''   `relationship_id` int(10) unsigned NOT NULL,
'''   `term_id` int(10) unsigned NOT NULL,
'''   `name` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`id`,`term_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dag_relationship", Database:="kb_go", SchemaSQL:="
CREATE TABLE `dag_relationship` (
  `id` int(10) unsigned NOT NULL,
  `relationship` varchar(45) DEFAULT NULL,
  `relationship_id` int(10) unsigned NOT NULL,
  `term_id` int(10) unsigned NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`term_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class dag_relationship: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="id"), XmlAttribute> Public Property id As Long
    <DatabaseField("relationship"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="relationship")> Public Property relationship As String
    <DatabaseField("relationship_id"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="relationship_id")> Public Property relationship_id As Long
    <DatabaseField("term_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="term_id"), XmlAttribute> Public Property term_id As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="name")> Public Property name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dag_relationship` (`id`, `relationship`, `relationship_id`, `term_id`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dag_relationship` (`id`, `relationship`, `relationship_id`, `term_id`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dag_relationship` WHERE `id`='{0}' and `term_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dag_relationship` SET `id`='{0}', `relationship`='{1}', `relationship_id`='{2}', `term_id`='{3}', `name`='{4}' WHERE `id`='{5}' and `term_id`='{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dag_relationship` WHERE `id`='{0}' and `term_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id, term_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dag_relationship` (`id`, `relationship`, `relationship_id`, `term_id`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, relationship, relationship_id, term_id, name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{id}', '{relationship}', '{relationship_id}', '{term_id}', '{name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dag_relationship` (`id`, `relationship`, `relationship_id`, `term_id`, `name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, relationship, relationship_id, term_id, name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dag_relationship` SET `id`='{0}', `relationship`='{1}', `relationship_id`='{2}', `term_id`='{3}', `name`='{4}' WHERE `id`='{5}' and `term_id`='{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, relationship, relationship_id, term_id, name, id, term_id)
    End Function
#End Region
Public Function Clone() As dag_relationship
                  Return DirectCast(MyClass.MemberwiseClone, dag_relationship)
              End Function
End Class


End Namespace
