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
''' DROP TABLE IF EXISTS `reactionlikeevent`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reactionlikeevent` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `isChimeric` enum('TRUE','FALSE') DEFAULT NULL,
'''   `systematicName` text,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `isChimeric` (`isChimeric`),
'''   FULLTEXT KEY `systematicName` (`systematicName`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reactionlikeevent", Database:="gk_current", SchemaSQL:="
CREATE TABLE `reactionlikeevent` (
  `DB_ID` int(10) unsigned NOT NULL,
  `isChimeric` enum('TRUE','FALSE') DEFAULT NULL,
  `systematicName` text,
  PRIMARY KEY (`DB_ID`),
  KEY `isChimeric` (`isChimeric`),
  FULLTEXT KEY `systematicName` (`systematicName`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class reactionlikeevent: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("isChimeric"), DataType(MySqlDbType.String), Column(Name:="isChimeric")> Public Property isChimeric As String
    <DatabaseField("systematicName"), DataType(MySqlDbType.Text), Column(Name:="systematicName")> Public Property systematicName As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `reactionlikeevent` (`DB_ID`, `isChimeric`, `systematicName`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `reactionlikeevent` (`DB_ID`, `isChimeric`, `systematicName`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `reactionlikeevent` (`DB_ID`, `isChimeric`, `systematicName`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `reactionlikeevent` (`DB_ID`, `isChimeric`, `systematicName`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `reactionlikeevent` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `reactionlikeevent` SET `DB_ID`='{0}', `isChimeric`='{1}', `systematicName`='{2}' WHERE `DB_ID` = '{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `reactionlikeevent` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `reactionlikeevent` (`DB_ID`, `isChimeric`, `systematicName`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, isChimeric, systematicName)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `reactionlikeevent` (`DB_ID`, `isChimeric`, `systematicName`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, isChimeric, systematicName)
        Else
        Return String.Format(INSERT_SQL, DB_ID, isChimeric, systematicName)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{isChimeric}', '{systematicName}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reactionlikeevent` (`DB_ID`, `isChimeric`, `systematicName`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, isChimeric, systematicName)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `reactionlikeevent` (`DB_ID`, `isChimeric`, `systematicName`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, isChimeric, systematicName)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, isChimeric, systematicName)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `reactionlikeevent` SET `DB_ID`='{0}', `isChimeric`='{1}', `systematicName`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, isChimeric, systematicName, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As reactionlikeevent
                         Return DirectCast(MyClass.MemberwiseClone, reactionlikeevent)
                     End Function
End Class


End Namespace
