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
''' DROP TABLE IF EXISTS `protein_accpair`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_accpair` (
'''   `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `secondary_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   PRIMARY KEY (`protein_ac`,`secondary_ac`),
'''   CONSTRAINT `fk_accpair$primary` FOREIGN KEY (`protein_ac`) REFERENCES `protein` (`protein_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_accpair", Database:="interpro", SchemaSQL:="
CREATE TABLE `protein_accpair` (
  `protein_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `secondary_ac` varchar(6) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  PRIMARY KEY (`protein_ac`,`secondary_ac`),
  CONSTRAINT `fk_accpair$primary` FOREIGN KEY (`protein_ac`) REFERENCES `protein` (`protein_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class protein_accpair: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("protein_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "6"), Column(Name:="protein_ac"), XmlAttribute> Public Property protein_ac As String
    <DatabaseField("secondary_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "6"), Column(Name:="secondary_ac"), XmlAttribute> Public Property secondary_ac As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `protein_accpair` (`protein_ac`, `secondary_ac`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `protein_accpair` (`protein_ac`, `secondary_ac`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `protein_accpair` (`protein_ac`, `secondary_ac`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `protein_accpair` (`protein_ac`, `secondary_ac`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `protein_accpair` WHERE `protein_ac`='{0}' and `secondary_ac`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `protein_accpair` SET `protein_ac`='{0}', `secondary_ac`='{1}' WHERE `protein_ac`='{2}' and `secondary_ac`='{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `protein_accpair` WHERE `protein_ac`='{0}' and `secondary_ac`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, protein_ac, secondary_ac)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `protein_accpair` (`protein_ac`, `secondary_ac`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, protein_ac, secondary_ac)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `protein_accpair` (`protein_ac`, `secondary_ac`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, protein_ac, secondary_ac)
        Else
        Return String.Format(INSERT_SQL, protein_ac, secondary_ac)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{protein_ac}', '{secondary_ac}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_accpair` (`protein_ac`, `secondary_ac`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, protein_ac, secondary_ac)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `protein_accpair` (`protein_ac`, `secondary_ac`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, protein_ac, secondary_ac)
        Else
        Return String.Format(REPLACE_SQL, protein_ac, secondary_ac)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `protein_accpair` SET `protein_ac`='{0}', `secondary_ac`='{1}' WHERE `protein_ac`='{2}' and `secondary_ac`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, protein_ac, secondary_ac, protein_ac, secondary_ac)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As protein_accpair
                         Return DirectCast(MyClass.MemberwiseClone, protein_accpair)
                     End Function
End Class


End Namespace
