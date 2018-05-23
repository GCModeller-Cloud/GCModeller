REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:40


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `interactionparticipant`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `interactionparticipant` (
'''   `InteractionWID` bigint(20) NOT NULL,
'''   `OtherWID` bigint(20) NOT NULL,
'''   `Coefficient` smallint(6) DEFAULT NULL,
'''   KEY `PR_INTERACTIONWID_OTHERWID` (`InteractionWID`,`OtherWID`),
'''   CONSTRAINT `FK_InteractionParticipant1` FOREIGN KEY (`InteractionWID`) REFERENCES `interaction` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("interactionparticipant", Database:="warehouse", SchemaSQL:="
CREATE TABLE `interactionparticipant` (
  `InteractionWID` bigint(20) NOT NULL,
  `OtherWID` bigint(20) NOT NULL,
  `Coefficient` smallint(6) DEFAULT NULL,
  KEY `PR_INTERACTIONWID_OTHERWID` (`InteractionWID`,`OtherWID`),
  CONSTRAINT `FK_InteractionParticipant1` FOREIGN KEY (`InteractionWID`) REFERENCES `interaction` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class interactionparticipant: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("InteractionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="InteractionWID"), XmlAttribute> Public Property InteractionWID As Long
    <DatabaseField("OtherWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="OtherWID"), XmlAttribute> Public Property OtherWID As Long
    <DatabaseField("Coefficient"), DataType(MySqlDbType.Int64, "6"), Column(Name:="Coefficient")> Public Property Coefficient As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `interactionparticipant` (`InteractionWID`, `OtherWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `interactionparticipant` (`InteractionWID`, `OtherWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `interactionparticipant` (`InteractionWID`, `OtherWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `interactionparticipant` (`InteractionWID`, `OtherWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `interactionparticipant` WHERE `InteractionWID`='{0}' and `OtherWID`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `interactionparticipant` SET `InteractionWID`='{0}', `OtherWID`='{1}', `Coefficient`='{2}' WHERE `InteractionWID`='{3}' and `OtherWID`='{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `interactionparticipant` WHERE `InteractionWID`='{0}' and `OtherWID`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, InteractionWID, OtherWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `interactionparticipant` (`InteractionWID`, `OtherWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, InteractionWID, OtherWID, Coefficient)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `interactionparticipant` (`InteractionWID`, `OtherWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, InteractionWID, OtherWID, Coefficient)
        Else
        Return String.Format(INSERT_SQL, InteractionWID, OtherWID, Coefficient)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{InteractionWID}', '{OtherWID}', '{Coefficient}')"
        Else
            Return $"('{InteractionWID}', '{OtherWID}', '{Coefficient}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `interactionparticipant` (`InteractionWID`, `OtherWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, InteractionWID, OtherWID, Coefficient)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `interactionparticipant` (`InteractionWID`, `OtherWID`, `Coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, InteractionWID, OtherWID, Coefficient)
        Else
        Return String.Format(REPLACE_SQL, InteractionWID, OtherWID, Coefficient)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `interactionparticipant` SET `InteractionWID`='{0}', `OtherWID`='{1}', `Coefficient`='{2}' WHERE `InteractionWID`='{3}' and `OtherWID`='{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, InteractionWID, OtherWID, Coefficient, InteractionWID, OtherWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As interactionparticipant
                         Return DirectCast(MyClass.MemberwiseClone, interactionparticipant)
                     End Function
End Class


End Namespace
