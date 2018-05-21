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
''' DROP TABLE IF EXISTS `pfam_clan_data`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pfam_clan_data` (
'''   `clan_id` varchar(15) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `name` varchar(50) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `description` varchar(75) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   PRIMARY KEY (`clan_id`,`name`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pfam_clan_data", Database:="interpro", SchemaSQL:="
CREATE TABLE `pfam_clan_data` (
  `clan_id` varchar(15) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `name` varchar(50) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `description` varchar(75) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  PRIMARY KEY (`clan_id`,`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class pfam_clan_data: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("clan_id"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "15"), Column(Name:="clan_id"), XmlAttribute> Public Property clan_id As String
    <DatabaseField("name"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "50"), Column(Name:="name"), XmlAttribute> Public Property name As String
    <DatabaseField("description"), DataType(MySqlDbType.VarChar, "75"), Column(Name:="description")> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `pfam_clan_data` (`clan_id`, `name`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `pfam_clan_data` (`clan_id`, `name`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `pfam_clan_data` (`clan_id`, `name`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `pfam_clan_data` (`clan_id`, `name`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `pfam_clan_data` WHERE `clan_id`='{0}' and `name`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `pfam_clan_data` SET `clan_id`='{0}', `name`='{1}', `description`='{2}' WHERE `clan_id`='{3}' and `name`='{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `pfam_clan_data` WHERE `clan_id`='{0}' and `name`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, clan_id, name)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `pfam_clan_data` (`clan_id`, `name`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, clan_id, name, description)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `pfam_clan_data` (`clan_id`, `name`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, clan_id, name, description)
        Else
        Return String.Format(INSERT_SQL, clan_id, name, description)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{clan_id}', '{name}', '{description}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pfam_clan_data` (`clan_id`, `name`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, clan_id, name, description)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `pfam_clan_data` (`clan_id`, `name`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, clan_id, name, description)
        Else
        Return String.Format(REPLACE_SQL, clan_id, name, description)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `pfam_clan_data` SET `clan_id`='{0}', `name`='{1}', `description`='{2}' WHERE `clan_id`='{3}' and `name`='{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, clan_id, name, description, clan_id, name)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As pfam_clan_data
                         Return DirectCast(MyClass.MemberwiseClone, pfam_clan_data)
                     End Function
End Class


End Namespace
