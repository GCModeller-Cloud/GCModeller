REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:41


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `physicalentity_2_name`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `physicalentity_2_name` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `name_rank` int(10) unsigned DEFAULT NULL,
'''   `name` text,
'''   KEY `DB_ID` (`DB_ID`),
'''   FULLTEXT KEY `name` (`name`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("physicalentity_2_name", Database:="gk_current", SchemaSQL:="
CREATE TABLE `physicalentity_2_name` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `name_rank` int(10) unsigned DEFAULT NULL,
  `name` text,
  KEY `DB_ID` (`DB_ID`),
  FULLTEXT KEY `name` (`name`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class physicalentity_2_name: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("name_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="name_rank")> Public Property name_rank As Long
    <DatabaseField("name"), DataType(MySqlDbType.Text), Column(Name:="name")> Public Property name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `physicalentity_2_name` (`DB_ID`, `name_rank`, `name`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `physicalentity_2_name` (`DB_ID`, `name_rank`, `name`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `physicalentity_2_name` (`DB_ID`, `name_rank`, `name`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `physicalentity_2_name` (`DB_ID`, `name_rank`, `name`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `physicalentity_2_name` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `physicalentity_2_name` SET `DB_ID`='{0}', `name_rank`='{1}', `name`='{2}' WHERE `DB_ID` = '{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `physicalentity_2_name` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `physicalentity_2_name` (`DB_ID`, `name_rank`, `name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, name_rank, name)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `physicalentity_2_name` (`DB_ID`, `name_rank`, `name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, name_rank, name)
        Else
        Return String.Format(INSERT_SQL, DB_ID, name_rank, name)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{DB_ID}', '{name_rank}', '{name}')"
        Else
            Return $"('{DB_ID}', '{name_rank}', '{name}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `physicalentity_2_name` (`DB_ID`, `name_rank`, `name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, name_rank, name)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `physicalentity_2_name` (`DB_ID`, `name_rank`, `name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, name_rank, name)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, name_rank, name)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `physicalentity_2_name` SET `DB_ID`='{0}', `name_rank`='{1}', `name`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, name_rank, name, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As physicalentity_2_name
                         Return DirectCast(MyClass.MemberwiseClone, physicalentity_2_name)
                     End Function
End Class


End Namespace
