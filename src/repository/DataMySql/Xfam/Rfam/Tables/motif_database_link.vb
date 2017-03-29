REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:55:32 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `motif_database_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `motif_database_link` (
'''   `motif_acc` varchar(7) NOT NULL,
'''   `db_id` tinytext NOT NULL,
'''   `comment` tinytext,
'''   `db_link` tinytext NOT NULL,
'''   `other_params` tinytext,
'''   KEY `motif_acc` (`motif_acc`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("motif_database_link", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `motif_database_link` (
  `motif_acc` varchar(7) NOT NULL,
  `db_id` tinytext NOT NULL,
  `comment` tinytext,
  `db_link` tinytext NOT NULL,
  `other_params` tinytext,
  KEY `motif_acc` (`motif_acc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class motif_database_link: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("motif_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7")> Public Property motif_acc As String
    <DatabaseField("db_id"), NotNull, DataType(MySqlDbType.Text)> Public Property db_id As String
    <DatabaseField("comment"), DataType(MySqlDbType.Text)> Public Property comment As String
    <DatabaseField("db_link"), NotNull, DataType(MySqlDbType.Text)> Public Property db_link As String
    <DatabaseField("other_params"), DataType(MySqlDbType.Text)> Public Property other_params As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `motif_database_link` (`motif_acc`, `db_id`, `comment`, `db_link`, `other_params`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `motif_database_link` (`motif_acc`, `db_id`, `comment`, `db_link`, `other_params`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `motif_database_link` WHERE `motif_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `motif_database_link` SET `motif_acc`='{0}', `db_id`='{1}', `comment`='{2}', `db_link`='{3}', `other_params`='{4}' WHERE `motif_acc` = '{5}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `motif_database_link` WHERE `motif_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, motif_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `motif_database_link` (`motif_acc`, `db_id`, `comment`, `db_link`, `other_params`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, motif_acc, db_id, comment, db_link, other_params)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{motif_acc}', '{db_id}', '{comment}', '{db_link}', '{other_params}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `motif_database_link` (`motif_acc`, `db_id`, `comment`, `db_link`, `other_params`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, motif_acc, db_id, comment, db_link, other_params)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `motif_database_link` SET `motif_acc`='{0}', `db_id`='{1}', `comment`='{2}', `db_link`='{3}', `other_params`='{4}' WHERE `motif_acc` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, motif_acc, db_id, comment, db_link, other_params, motif_acc)
    End Function
#End Region
End Class


End Namespace
