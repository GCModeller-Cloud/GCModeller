REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:39


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace CEG.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `ceg_base`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `ceg_base` (
'''   `access_num` varchar(255) DEFAULT NULL,
'''   `koid` varchar(255) DEFAULT NULL,
'''   `cogid` varchar(255) NOT NULL,
'''   `description` varchar(255) NOT NULL,
'''   `ec` varchar(100) NOT NULL
''' ) ENGINE=MyISAM DEFAULT CHARSET=gb2312;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("ceg_base", Database:="ceg", SchemaSQL:="
CREATE TABLE `ceg_base` (
  `access_num` varchar(255) DEFAULT NULL,
  `koid` varchar(255) DEFAULT NULL,
  `cogid` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `ec` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=gb2312;")>
Public Class ceg_base: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("access_num"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="access_num")> Public Property access_num As String
    <DatabaseField("koid"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="koid")> Public Property koid As String
    <DatabaseField("cogid"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="cogid")> Public Property cogid As String
    <DatabaseField("description"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="description")> Public Property description As String
    <DatabaseField("ec"), NotNull, DataType(MySqlDbType.VarChar, "100"), Column(Name:="ec")> Public Property ec As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `ceg_base` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `ceg_base` SET `access_num`='{0}', `koid`='{1}', `cogid`='{2}', `description`='{3}', `ec`='{4}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `ceg_base` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, access_num, koid, cogid, description, ec)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, access_num, koid, cogid, description, ec)
        Else
        Return String.Format(INSERT_SQL, access_num, koid, cogid, description, ec)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{access_num}', '{koid}', '{cogid}', '{description}', '{ec}')"
        Else
            Return $"('{access_num}', '{koid}', '{cogid}', '{description}', '{ec}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, access_num, koid, cogid, description, ec)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `ceg_base` (`access_num`, `koid`, `cogid`, `description`, `ec`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, access_num, koid, cogid, description, ec)
        Else
        Return String.Format(REPLACE_SQL, access_num, koid, cogid, description, ec)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `ceg_base` SET `access_num`='{0}', `koid`='{1}', `cogid`='{2}', `description`='{3}', `ec`='{4}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As ceg_base
                         Return DirectCast(MyClass.MemberwiseClone, ceg_base)
                     End Function
End Class


End Namespace
