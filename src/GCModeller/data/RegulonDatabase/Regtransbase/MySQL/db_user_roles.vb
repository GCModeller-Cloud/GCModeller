REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:11


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
''' DROP TABLE IF EXISTS `db_user_roles`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `db_user_roles` (
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   `role_name` varchar(50) DEFAULT NULL,
'''   PRIMARY KEY (`id`)
''' ) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("db_user_roles", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `db_user_roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;")>
Public Class db_user_roles: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="id"), XmlAttribute> Public Property id As Long
    <DatabaseField("role_name"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="role_name")> Public Property role_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `db_user_roles` (`role_name`) VALUES ('{0}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `db_user_roles` (`id`, `role_name`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `db_user_roles` (`role_name`) VALUES ('{0}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `db_user_roles` (`id`, `role_name`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `db_user_roles` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `db_user_roles` SET `id`='{0}', `role_name`='{1}' WHERE `id` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `db_user_roles` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `db_user_roles` (`id`, `role_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, role_name)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `db_user_roles` (`id`, `role_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, role_name)
        Else
        Return String.Format(INSERT_SQL, role_name)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{role_name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `db_user_roles` (`id`, `role_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, role_name)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `db_user_roles` (`id`, `role_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, role_name)
        Else
        Return String.Format(REPLACE_SQL, role_name)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `db_user_roles` SET `id`='{0}', `role_name`='{1}' WHERE `id` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, role_name, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As db_user_roles
                         Return DirectCast(MyClass.MemberwiseClone, db_user_roles)
                     End Function
End Class


End Namespace
