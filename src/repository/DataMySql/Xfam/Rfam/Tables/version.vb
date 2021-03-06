REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:34


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `version`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `version` (
'''   `rfam_release` double(4,1) NOT NULL,
'''   `rfam_release_date` date NOT NULL,
'''   `number_families` int(10) NOT NULL,
'''   `embl_release` tinytext NOT NULL,
'''   PRIMARY KEY (`rfam_release`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("version", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `version` (
  `rfam_release` double(4,1) NOT NULL,
  `rfam_release_date` date NOT NULL,
  `number_families` int(10) NOT NULL,
  `embl_release` tinytext NOT NULL,
  PRIMARY KEY (`rfam_release`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class version: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("rfam_release"), PrimaryKey, NotNull, DataType(MySqlDbType.Double), Column(Name:="rfam_release"), XmlAttribute> Public Property rfam_release As Double
    <DatabaseField("rfam_release_date"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="rfam_release_date")> Public Property rfam_release_date As Date
    <DatabaseField("number_families"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="number_families")> Public Property number_families As Long
    <DatabaseField("embl_release"), NotNull, DataType(MySqlDbType.Text), Column(Name:="embl_release")> Public Property embl_release As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `version` WHERE `rfam_release` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `version` SET `rfam_release`='{0}', `rfam_release_date`='{1}', `number_families`='{2}', `embl_release`='{3}' WHERE `rfam_release` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `version` WHERE `rfam_release` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, rfam_release)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, rfam_release, MySqlScript.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, rfam_release, MySqlScript.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release)
        Else
        Return String.Format(INSERT_SQL, rfam_release, MySqlScript.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{rfam_release}', '{rfam_release_date}', '{number_families}', '{embl_release}')"
        Else
            Return $"('{rfam_release}', '{rfam_release_date}', '{number_families}', '{embl_release}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, rfam_release, MySqlScript.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, rfam_release, MySqlScript.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release)
        Else
        Return String.Format(REPLACE_SQL, rfam_release, MySqlScript.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `version` SET `rfam_release`='{0}', `rfam_release_date`='{1}', `number_families`='{2}', `embl_release`='{3}' WHERE `rfam_release` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, rfam_release, MySqlScript.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release, rfam_release)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As version
                         Return DirectCast(MyClass.MemberwiseClone, version)
                     End Function
End Class


End Namespace
