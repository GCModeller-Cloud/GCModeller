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
''' DROP TABLE IF EXISTS `protein_ida`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_ida` (
'''   `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `ida` mediumtext CHARACTER SET latin1 COLLATE latin1_bin,
'''   PRIMARY KEY (`protein_ac`),
'''   CONSTRAINT `fk_protein_ida_p` FOREIGN KEY (`protein_ac`) REFERENCES `protein` (`protein_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_ida", Database:="interpro", SchemaSQL:="
CREATE TABLE `protein_ida` (
  `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `ida` mediumtext CHARACTER SET latin1 COLLATE latin1_bin,
  PRIMARY KEY (`protein_ac`),
  CONSTRAINT `fk_protein_ida_p` FOREIGN KEY (`protein_ac`) REFERENCES `protein` (`protein_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class protein_ida: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("protein_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "6"), Column(Name:="protein_ac"), XmlAttribute> Public Property protein_ac As String
    <DatabaseField("ida"), DataType(MySqlDbType.Text), Column(Name:="ida")> Public Property ida As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `protein_ida` (`protein_ac`, `ida`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `protein_ida` (`protein_ac`, `ida`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `protein_ida` (`protein_ac`, `ida`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `protein_ida` (`protein_ac`, `ida`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `protein_ida` WHERE `protein_ac` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `protein_ida` SET `protein_ac`='{0}', `ida`='{1}' WHERE `protein_ac` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `protein_ida` WHERE `protein_ac` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, protein_ac)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `protein_ida` (`protein_ac`, `ida`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, protein_ac, ida)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `protein_ida` (`protein_ac`, `ida`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, protein_ac, ida)
        Else
        Return String.Format(INSERT_SQL, protein_ac, ida)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{protein_ac}', '{ida}')"
        Else
            Return $"('{protein_ac}', '{ida}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_ida` (`protein_ac`, `ida`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, protein_ac, ida)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `protein_ida` (`protein_ac`, `ida`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, protein_ac, ida)
        Else
        Return String.Format(REPLACE_SQL, protein_ac, ida)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `protein_ida` SET `protein_ac`='{0}', `ida`='{1}' WHERE `protein_ac` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, protein_ac, ida, protein_ac)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As protein_ida
                         Return DirectCast(MyClass.MemberwiseClone, protein_ida)
                     End Function
End Class


End Namespace
