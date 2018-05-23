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
''' DROP TABLE IF EXISTS `parameters`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `parameters` (
'''   `parameter` varchar(64) NOT NULL,
'''   `value` longblob,
'''   PRIMARY KEY (`parameter`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("parameters", Database:="gk_current", SchemaSQL:="
CREATE TABLE `parameters` (
  `parameter` varchar(64) NOT NULL,
  `value` longblob,
  PRIMARY KEY (`parameter`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class parameters: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("parameter"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "64"), Column(Name:="parameter"), XmlAttribute> Public Property parameter As String
    <DatabaseField("value"), DataType(MySqlDbType.Blob), Column(Name:="value")> Public Property value As Byte()
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `parameters` (`parameter`, `value`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `parameters` (`parameter`, `value`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `parameters` (`parameter`, `value`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `parameters` (`parameter`, `value`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `parameters` WHERE `parameter` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `parameters` SET `parameter`='{0}', `value`='{1}' WHERE `parameter` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `parameters` WHERE `parameter` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, parameter)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `parameters` (`parameter`, `value`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, parameter, value)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `parameters` (`parameter`, `value`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, parameter, value)
        Else
        Return String.Format(INSERT_SQL, parameter, value)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{parameter}', '{value}')"
        Else
            Return $"('{parameter}', '{value}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `parameters` (`parameter`, `value`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, parameter, value)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `parameters` (`parameter`, `value`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, parameter, value)
        Else
        Return String.Format(REPLACE_SQL, parameter, value)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `parameters` SET `parameter`='{0}', `value`='{1}' WHERE `parameter` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, parameter, value, parameter)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As parameters
                         Return DirectCast(MyClass.MemberwiseClone, parameters)
                     End Function
End Class


End Namespace
