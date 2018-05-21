REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:14


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
''' DROP TABLE IF EXISTS `databaseidentifier_2_crossreference`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `databaseidentifier_2_crossreference` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `crossReference_rank` int(10) unsigned DEFAULT NULL,
'''   `crossReference` int(10) unsigned DEFAULT NULL,
'''   `crossReference_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `crossReference` (`crossReference`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("databaseidentifier_2_crossreference", Database:="gk_current", SchemaSQL:="
CREATE TABLE `databaseidentifier_2_crossreference` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `crossReference_rank` int(10) unsigned DEFAULT NULL,
  `crossReference` int(10) unsigned DEFAULT NULL,
  `crossReference_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `crossReference` (`crossReference`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class databaseidentifier_2_crossreference: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("crossReference_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="crossReference_rank")> Public Property crossReference_rank As Long
    <DatabaseField("crossReference"), DataType(MySqlDbType.Int64, "10"), Column(Name:="crossReference")> Public Property crossReference As Long
    <DatabaseField("crossReference_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="crossReference_class")> Public Property crossReference_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `databaseidentifier_2_crossreference` (`DB_ID`, `crossReference_rank`, `crossReference`, `crossReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `databaseidentifier_2_crossreference` (`DB_ID`, `crossReference_rank`, `crossReference`, `crossReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `databaseidentifier_2_crossreference` (`DB_ID`, `crossReference_rank`, `crossReference`, `crossReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `databaseidentifier_2_crossreference` (`DB_ID`, `crossReference_rank`, `crossReference`, `crossReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `databaseidentifier_2_crossreference` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `databaseidentifier_2_crossreference` SET `DB_ID`='{0}', `crossReference_rank`='{1}', `crossReference`='{2}', `crossReference_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `databaseidentifier_2_crossreference` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `databaseidentifier_2_crossreference` (`DB_ID`, `crossReference_rank`, `crossReference`, `crossReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, crossReference_rank, crossReference, crossReference_class)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `databaseidentifier_2_crossreference` (`DB_ID`, `crossReference_rank`, `crossReference`, `crossReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, crossReference_rank, crossReference, crossReference_class)
        Else
        Return String.Format(INSERT_SQL, DB_ID, crossReference_rank, crossReference, crossReference_class)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{crossReference_rank}', '{crossReference}', '{crossReference_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `databaseidentifier_2_crossreference` (`DB_ID`, `crossReference_rank`, `crossReference`, `crossReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, crossReference_rank, crossReference, crossReference_class)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `databaseidentifier_2_crossreference` (`DB_ID`, `crossReference_rank`, `crossReference`, `crossReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, crossReference_rank, crossReference, crossReference_class)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, crossReference_rank, crossReference, crossReference_class)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `databaseidentifier_2_crossreference` SET `DB_ID`='{0}', `crossReference_rank`='{1}', `crossReference`='{2}', `crossReference_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, crossReference_rank, crossReference, crossReference_class, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As databaseidentifier_2_crossreference
                         Return DirectCast(MyClass.MemberwiseClone, databaseidentifier_2_crossreference)
                     End Function
End Class


End Namespace
