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
''' DROP TABLE IF EXISTS `strand_d_tmp`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `strand_d_tmp` (
'''   `st_id` decimal(10,0) NOT NULL,
'''   `strand_name` varchar(10) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("strand_d_tmp", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `strand_d_tmp` (
  `st_id` decimal(10,0) NOT NULL,
  `strand_name` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class strand_d_tmp: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("st_id"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="st_id")> Public Property st_id As Decimal
    <DatabaseField("strand_name"), DataType(MySqlDbType.VarChar, "10"), Column(Name:="strand_name")> Public Property strand_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `strand_d_tmp` (`st_id`, `strand_name`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `strand_d_tmp` (`st_id`, `strand_name`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `strand_d_tmp` (`st_id`, `strand_name`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `strand_d_tmp` (`st_id`, `strand_name`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `strand_d_tmp` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `strand_d_tmp` SET `st_id`='{0}', `strand_name`='{1}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `strand_d_tmp` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `strand_d_tmp` (`st_id`, `strand_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, st_id, strand_name)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `strand_d_tmp` (`st_id`, `strand_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, st_id, strand_name)
        Else
        Return String.Format(INSERT_SQL, st_id, strand_name)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{st_id}', '{strand_name}')"
        Else
            Return $"('{st_id}', '{strand_name}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `strand_d_tmp` (`st_id`, `strand_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, st_id, strand_name)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `strand_d_tmp` (`st_id`, `strand_name`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, st_id, strand_name)
        Else
        Return String.Format(REPLACE_SQL, st_id, strand_name)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `strand_d_tmp` SET `st_id`='{0}', `strand_name`='{1}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As strand_d_tmp
                         Return DirectCast(MyClass.MemberwiseClone, strand_d_tmp)
                     End Function
End Class


End Namespace
