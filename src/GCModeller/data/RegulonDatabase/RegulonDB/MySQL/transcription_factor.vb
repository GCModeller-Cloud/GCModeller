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
''' DROP TABLE IF EXISTS `transcription_factor`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `transcription_factor` (
'''   `transcription_factor_id` char(12) NOT NULL,
'''   `transcription_factor_name` varchar(255) NOT NULL,
'''   `site_length` decimal(10,0) DEFAULT NULL,
'''   `symmetry` varchar(50) DEFAULT NULL,
'''   `transcription_factor_family` varchar(250) DEFAULT NULL,
'''   `tf_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL,
'''   `transcription_factor_note` longtext,
'''   `connectivity_class` varchar(100) DEFAULT NULL,
'''   `sensing_class` varchar(100) DEFAULT NULL,
'''   `consensus_sequence` varchar(255) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("transcription_factor", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `transcription_factor` (
  `transcription_factor_id` char(12) NOT NULL,
  `transcription_factor_name` varchar(255) NOT NULL,
  `site_length` decimal(10,0) DEFAULT NULL,
  `symmetry` varchar(50) DEFAULT NULL,
  `transcription_factor_family` varchar(250) DEFAULT NULL,
  `tf_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL,
  `transcription_factor_note` longtext,
  `connectivity_class` varchar(100) DEFAULT NULL,
  `sensing_class` varchar(100) DEFAULT NULL,
  `consensus_sequence` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class transcription_factor: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("transcription_factor_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="transcription_factor_id")> Public Property transcription_factor_id As String
    <DatabaseField("transcription_factor_name"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="transcription_factor_name")> Public Property transcription_factor_name As String
    <DatabaseField("site_length"), DataType(MySqlDbType.Decimal), Column(Name:="site_length")> Public Property site_length As Decimal
    <DatabaseField("symmetry"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="symmetry")> Public Property symmetry As String
    <DatabaseField("transcription_factor_family"), DataType(MySqlDbType.VarChar, "250"), Column(Name:="transcription_factor_family")> Public Property transcription_factor_family As String
    <DatabaseField("tf_internal_comment"), DataType(MySqlDbType.Text), Column(Name:="tf_internal_comment")> Public Property tf_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5"), Column(Name:="key_id_org")> Public Property key_id_org As String
    <DatabaseField("transcription_factor_note"), DataType(MySqlDbType.Text), Column(Name:="transcription_factor_note")> Public Property transcription_factor_note As String
    <DatabaseField("connectivity_class"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="connectivity_class")> Public Property connectivity_class As String
    <DatabaseField("sensing_class"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="sensing_class")> Public Property sensing_class As String
    <DatabaseField("consensus_sequence"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="consensus_sequence")> Public Property consensus_sequence As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `transcription_factor` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `transcription_factor` SET `transcription_factor_id`='{0}', `transcription_factor_name`='{1}', `site_length`='{2}', `symmetry`='{3}', `transcription_factor_family`='{4}', `tf_internal_comment`='{5}', `key_id_org`='{6}', `transcription_factor_note`='{7}', `connectivity_class`='{8}', `sensing_class`='{9}', `consensus_sequence`='{10}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `transcription_factor` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, transcription_factor_id, transcription_factor_name, site_length, symmetry, transcription_factor_family, tf_internal_comment, key_id_org, transcription_factor_note, connectivity_class, sensing_class, consensus_sequence)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, transcription_factor_id, transcription_factor_name, site_length, symmetry, transcription_factor_family, tf_internal_comment, key_id_org, transcription_factor_note, connectivity_class, sensing_class, consensus_sequence)
        Else
        Return String.Format(INSERT_SQL, transcription_factor_id, transcription_factor_name, site_length, symmetry, transcription_factor_family, tf_internal_comment, key_id_org, transcription_factor_note, connectivity_class, sensing_class, consensus_sequence)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{transcription_factor_id}', '{transcription_factor_name}', '{site_length}', '{symmetry}', '{transcription_factor_family}', '{tf_internal_comment}', '{key_id_org}', '{transcription_factor_note}', '{connectivity_class}', '{sensing_class}', '{consensus_sequence}')"
        Else
            Return $"('{transcription_factor_id}', '{transcription_factor_name}', '{site_length}', '{symmetry}', '{transcription_factor_family}', '{tf_internal_comment}', '{key_id_org}', '{transcription_factor_note}', '{connectivity_class}', '{sensing_class}', '{consensus_sequence}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, transcription_factor_id, transcription_factor_name, site_length, symmetry, transcription_factor_family, tf_internal_comment, key_id_org, transcription_factor_note, connectivity_class, sensing_class, consensus_sequence)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `transcription_factor` (`transcription_factor_id`, `transcription_factor_name`, `site_length`, `symmetry`, `transcription_factor_family`, `tf_internal_comment`, `key_id_org`, `transcription_factor_note`, `connectivity_class`, `sensing_class`, `consensus_sequence`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, transcription_factor_id, transcription_factor_name, site_length, symmetry, transcription_factor_family, tf_internal_comment, key_id_org, transcription_factor_note, connectivity_class, sensing_class, consensus_sequence)
        Else
        Return String.Format(REPLACE_SQL, transcription_factor_id, transcription_factor_name, site_length, symmetry, transcription_factor_family, tf_internal_comment, key_id_org, transcription_factor_note, connectivity_class, sensing_class, consensus_sequence)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `transcription_factor` SET `transcription_factor_id`='{0}', `transcription_factor_name`='{1}', `site_length`='{2}', `symmetry`='{3}', `transcription_factor_family`='{4}', `tf_internal_comment`='{5}', `key_id_org`='{6}', `transcription_factor_note`='{7}', `connectivity_class`='{8}', `sensing_class`='{9}', `consensus_sequence`='{10}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As transcription_factor
                         Return DirectCast(MyClass.MemberwiseClone, transcription_factor)
                     End Function
End Class


End Namespace
