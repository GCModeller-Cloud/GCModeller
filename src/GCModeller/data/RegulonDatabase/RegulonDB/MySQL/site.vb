REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:36


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `site`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `site` (
'''   `site_id` char(12) NOT NULL,
'''   `site_posleft` decimal(10,0) NOT NULL,
'''   `site_posright` decimal(10,0) NOT NULL,
'''   `site_sequence` varchar(100) DEFAULT NULL,
'''   `site_note` varchar(2000) DEFAULT NULL,
'''   `site_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL,
'''   `site_length` decimal(10,0) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("site", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `site` (
  `site_id` char(12) NOT NULL,
  `site_posleft` decimal(10,0) NOT NULL,
  `site_posright` decimal(10,0) NOT NULL,
  `site_sequence` varchar(100) DEFAULT NULL,
  `site_note` varchar(2000) DEFAULT NULL,
  `site_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL,
  `site_length` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class site: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("site_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="site_id")> Public Property site_id As String
    <DatabaseField("site_posleft"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="site_posleft")> Public Property site_posleft As Decimal
    <DatabaseField("site_posright"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="site_posright")> Public Property site_posright As Decimal
    <DatabaseField("site_sequence"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="site_sequence")> Public Property site_sequence As String
    <DatabaseField("site_note"), DataType(MySqlDbType.VarChar, "2000"), Column(Name:="site_note")> Public Property site_note As String
    <DatabaseField("site_internal_comment"), DataType(MySqlDbType.Text), Column(Name:="site_internal_comment")> Public Property site_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5"), Column(Name:="key_id_org")> Public Property key_id_org As String
    <DatabaseField("site_length"), DataType(MySqlDbType.Decimal), Column(Name:="site_length")> Public Property site_length As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `site` (`site_id`, `site_posleft`, `site_posright`, `site_sequence`, `site_note`, `site_internal_comment`, `key_id_org`, `site_length`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `site` (`site_id`, `site_posleft`, `site_posright`, `site_sequence`, `site_note`, `site_internal_comment`, `key_id_org`, `site_length`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `site` (`site_id`, `site_posleft`, `site_posright`, `site_sequence`, `site_note`, `site_internal_comment`, `key_id_org`, `site_length`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `site` (`site_id`, `site_posleft`, `site_posright`, `site_sequence`, `site_note`, `site_internal_comment`, `key_id_org`, `site_length`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `site` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `site` SET `site_id`='{0}', `site_posleft`='{1}', `site_posright`='{2}', `site_sequence`='{3}', `site_note`='{4}', `site_internal_comment`='{5}', `key_id_org`='{6}', `site_length`='{7}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `site` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `site` (`site_id`, `site_posleft`, `site_posright`, `site_sequence`, `site_note`, `site_internal_comment`, `key_id_org`, `site_length`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, site_id, site_posleft, site_posright, site_sequence, site_note, site_internal_comment, key_id_org, site_length)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `site` (`site_id`, `site_posleft`, `site_posright`, `site_sequence`, `site_note`, `site_internal_comment`, `key_id_org`, `site_length`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, site_id, site_posleft, site_posright, site_sequence, site_note, site_internal_comment, key_id_org, site_length)
        Else
        Return String.Format(INSERT_SQL, site_id, site_posleft, site_posright, site_sequence, site_note, site_internal_comment, key_id_org, site_length)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{site_id}', '{site_posleft}', '{site_posright}', '{site_sequence}', '{site_note}', '{site_internal_comment}', '{key_id_org}', '{site_length}')"
        Else
            Return $"('{site_id}', '{site_posleft}', '{site_posright}', '{site_sequence}', '{site_note}', '{site_internal_comment}', '{key_id_org}', '{site_length}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `site` (`site_id`, `site_posleft`, `site_posright`, `site_sequence`, `site_note`, `site_internal_comment`, `key_id_org`, `site_length`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, site_id, site_posleft, site_posright, site_sequence, site_note, site_internal_comment, key_id_org, site_length)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `site` (`site_id`, `site_posleft`, `site_posright`, `site_sequence`, `site_note`, `site_internal_comment`, `key_id_org`, `site_length`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, site_id, site_posleft, site_posright, site_sequence, site_note, site_internal_comment, key_id_org, site_length)
        Else
        Return String.Format(REPLACE_SQL, site_id, site_posleft, site_posright, site_sequence, site_note, site_internal_comment, key_id_org, site_length)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `site` SET `site_id`='{0}', `site_posleft`='{1}', `site_posright`='{2}', `site_sequence`='{3}', `site_note`='{4}', `site_internal_comment`='{5}', `key_id_org`='{6}', `site_length`='{7}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As site
                         Return DirectCast(MyClass.MemberwiseClone, site)
                     End Function
End Class


End Namespace
