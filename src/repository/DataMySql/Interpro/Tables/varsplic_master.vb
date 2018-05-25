REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:37


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
''' DROP TABLE IF EXISTS `varsplic_master`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `varsplic_master` (
'''   `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `variant` int(3) DEFAULT NULL,
'''   `crc64` varchar(16) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `length` int(5) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("varsplic_master", Database:="interpro", SchemaSQL:="
CREATE TABLE `varsplic_master` (
  `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `variant` int(3) DEFAULT NULL,
  `crc64` varchar(16) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `length` int(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class varsplic_master: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("protein_ac"), DataType(MySqlDbType.VarChar, "6"), Column(Name:="protein_ac")> Public Property protein_ac As String
    <DatabaseField("variant"), DataType(MySqlDbType.Int64, "3"), Column(Name:="variant")> Public Property [variant] As Long
    <DatabaseField("crc64"), DataType(MySqlDbType.VarChar, "16"), Column(Name:="crc64")> Public Property crc64 As String
    <DatabaseField("length"), DataType(MySqlDbType.Int64, "5"), Column(Name:="length")> Public Property length As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `varsplic_master` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `varsplic_master` SET `protein_ac`='{0}', `variant`='{1}', `crc64`='{2}', `length`='{3}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `varsplic_master` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, protein_ac, [variant], crc64, length)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, protein_ac, [variant], crc64, length)
        Else
        Return String.Format(INSERT_SQL, protein_ac, [variant], crc64, length)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{protein_ac}', '{[variant]}', '{crc64}', '{length}')"
        Else
            Return $"('{protein_ac}', '{[variant]}', '{crc64}', '{length}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, protein_ac, [variant], crc64, length)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `varsplic_master` (`protein_ac`, `variant`, `crc64`, `length`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, protein_ac, [variant], crc64, length)
        Else
        Return String.Format(REPLACE_SQL, protein_ac, [variant], crc64, length)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `varsplic_master` SET `protein_ac`='{0}', `variant`='{1}', `crc64`='{2}', `length`='{3}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As varsplic_master
                         Return DirectCast(MyClass.MemberwiseClone, varsplic_master)
                     End Function
End Class


End Namespace
