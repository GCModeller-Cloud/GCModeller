REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:39


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace ChEBI.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `default_structures`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `default_structures` (
'''   `id` int(11) NOT NULL,
'''   `structure_id` int(11) NOT NULL,
'''   PRIMARY KEY (`id`),
'''   KEY `FK_STRUCTURES_TO_DEFAULT_STRUC` (`structure_id`),
'''   CONSTRAINT `FK_STRUCTURES_TO_DEFAULT_STRUC` FOREIGN KEY (`structure_id`) REFERENCES `structures` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("default_structures", Database:="chebi", SchemaSQL:="
CREATE TABLE `default_structures` (
  `id` int(11) NOT NULL,
  `structure_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_STRUCTURES_TO_DEFAULT_STRUC` (`structure_id`),
  CONSTRAINT `FK_STRUCTURES_TO_DEFAULT_STRUC` FOREIGN KEY (`structure_id`) REFERENCES `structures` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class default_structures: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="id"), XmlAttribute> Public Property id As Long
    <DatabaseField("structure_id"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="structure_id")> Public Property structure_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `default_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `default_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `default_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `default_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `default_structures` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `default_structures` SET `id`='{0}', `structure_id`='{1}' WHERE `id` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `default_structures` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `default_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, structure_id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `default_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, structure_id)
        Else
        Return String.Format(INSERT_SQL, id, structure_id)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{id}', '{structure_id}')"
        Else
            Return $"('{id}', '{structure_id}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `default_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, structure_id)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `default_structures` (`id`, `structure_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, structure_id)
        Else
        Return String.Format(REPLACE_SQL, id, structure_id)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `default_structures` SET `id`='{0}', `structure_id`='{1}' WHERE `id` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, structure_id, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As default_structures
                         Return DirectCast(MyClass.MemberwiseClone, default_structures)
                     End Function
End Class


End Namespace
