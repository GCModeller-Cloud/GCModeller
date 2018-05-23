REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:38


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
''' DROP TABLE IF EXISTS `db_users`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `db_users` (
'''   `id` int(11) NOT NULL DEFAULT '0',
'''   `user_role_id` int(11) DEFAULT NULL,
'''   `name` varchar(20) DEFAULT NULL,
'''   `full_name` varchar(100) DEFAULT NULL,
'''   `phone` varchar(100) DEFAULT '',
'''   `email` varchar(100) DEFAULT '',
'''   `fl_active` int(1) DEFAULT NULL,
'''   PRIMARY KEY (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("db_users", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `db_users` (
  `id` int(11) NOT NULL DEFAULT '0',
  `user_role_id` int(11) DEFAULT NULL,
  `name` varchar(20) DEFAULT NULL,
  `full_name` varchar(100) DEFAULT NULL,
  `phone` varchar(100) DEFAULT '',
  `email` varchar(100) DEFAULT '',
  `fl_active` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class db_users: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="id"), XmlAttribute> Public Property id As Long
    <DatabaseField("user_role_id"), DataType(MySqlDbType.Int64, "11"), Column(Name:="user_role_id")> Public Property user_role_id As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "20"), Column(Name:="name")> Public Property name As String
    <DatabaseField("full_name"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="full_name")> Public Property full_name As String
    <DatabaseField("phone"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="phone")> Public Property phone As String
    <DatabaseField("email"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="email")> Public Property email As String
    <DatabaseField("fl_active"), DataType(MySqlDbType.Int64, "1"), Column(Name:="fl_active")> Public Property fl_active As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `db_users` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `db_users` SET `id`='{0}', `user_role_id`='{1}', `name`='{2}', `full_name`='{3}', `phone`='{4}', `email`='{5}', `fl_active`='{6}' WHERE `id` = '{7}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `db_users` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, user_role_id, name, full_name, phone, email, fl_active)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, user_role_id, name, full_name, phone, email, fl_active)
        Else
        Return String.Format(INSERT_SQL, id, user_role_id, name, full_name, phone, email, fl_active)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{id}', '{user_role_id}', '{name}', '{full_name}', '{phone}', '{email}', '{fl_active}')"
        Else
            Return $"('{id}', '{user_role_id}', '{name}', '{full_name}', '{phone}', '{email}', '{fl_active}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, id, user_role_id, name, full_name, phone, email, fl_active)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `db_users` (`id`, `user_role_id`, `name`, `full_name`, `phone`, `email`, `fl_active`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, user_role_id, name, full_name, phone, email, fl_active)
        Else
        Return String.Format(REPLACE_SQL, id, user_role_id, name, full_name, phone, email, fl_active)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `db_users` SET `id`='{0}', `user_role_id`='{1}', `name`='{2}', `full_name`='{3}', `phone`='{4}', `email`='{5}', `fl_active`='{6}' WHERE `id` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, user_role_id, name, full_name, phone, email, fl_active, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As db_users
                         Return DirectCast(MyClass.MemberwiseClone, db_users)
                     End Function
End Class


End Namespace
