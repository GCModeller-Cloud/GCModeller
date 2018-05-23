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
''' DROP TABLE IF EXISTS `protocolapplwidpersonwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protocolapplwidpersonwid` (
'''   `ProtocolApplicationWID` bigint(20) NOT NULL,
'''   `PersonWID` bigint(20) NOT NULL,
'''   KEY `FK_ProtocolApplWIDPersonWID1` (`ProtocolApplicationWID`),
'''   KEY `FK_ProtocolApplWIDPersonWID2` (`PersonWID`),
'''   CONSTRAINT `FK_ProtocolApplWIDPersonWID1` FOREIGN KEY (`ProtocolApplicationWID`) REFERENCES `parameterizableapplication` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ProtocolApplWIDPersonWID2` FOREIGN KEY (`PersonWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protocolapplwidpersonwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `protocolapplwidpersonwid` (
  `ProtocolApplicationWID` bigint(20) NOT NULL,
  `PersonWID` bigint(20) NOT NULL,
  KEY `FK_ProtocolApplWIDPersonWID1` (`ProtocolApplicationWID`),
  KEY `FK_ProtocolApplWIDPersonWID2` (`PersonWID`),
  CONSTRAINT `FK_ProtocolApplWIDPersonWID1` FOREIGN KEY (`ProtocolApplicationWID`) REFERENCES `parameterizableapplication` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProtocolApplWIDPersonWID2` FOREIGN KEY (`PersonWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class protocolapplwidpersonwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ProtocolApplicationWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ProtocolApplicationWID"), XmlAttribute> Public Property ProtocolApplicationWID As Long
    <DatabaseField("PersonWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="PersonWID")> Public Property PersonWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `protocolapplwidpersonwid` WHERE `ProtocolApplicationWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `protocolapplwidpersonwid` SET `ProtocolApplicationWID`='{0}', `PersonWID`='{1}' WHERE `ProtocolApplicationWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `protocolapplwidpersonwid` WHERE `ProtocolApplicationWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ProtocolApplicationWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ProtocolApplicationWID, PersonWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ProtocolApplicationWID, PersonWID)
        Else
        Return String.Format(INSERT_SQL, ProtocolApplicationWID, PersonWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{ProtocolApplicationWID}', '{PersonWID}')"
        Else
            Return $"('{ProtocolApplicationWID}', '{PersonWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ProtocolApplicationWID, PersonWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `protocolapplwidpersonwid` (`ProtocolApplicationWID`, `PersonWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ProtocolApplicationWID, PersonWID)
        Else
        Return String.Format(REPLACE_SQL, ProtocolApplicationWID, PersonWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `protocolapplwidpersonwid` SET `ProtocolApplicationWID`='{0}', `PersonWID`='{1}' WHERE `ProtocolApplicationWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ProtocolApplicationWID, PersonWID, ProtocolApplicationWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As protocolapplwidpersonwid
                         Return DirectCast(MyClass.MemberwiseClone, protocolapplwidpersonwid)
                     End Function
End Class


End Namespace
