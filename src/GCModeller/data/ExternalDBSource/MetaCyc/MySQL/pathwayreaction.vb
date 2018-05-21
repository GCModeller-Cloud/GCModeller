REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:13


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
''' DROP TABLE IF EXISTS `pathwayreaction`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pathwayreaction` (
'''   `PathwayWID` bigint(20) NOT NULL,
'''   `ReactionWID` bigint(20) NOT NULL,
'''   `PriorReactionWID` bigint(20) DEFAULT NULL,
'''   `Hypothetical` char(1) NOT NULL,
'''   KEY `PR_PATHWID_REACTIONWID` (`PathwayWID`,`ReactionWID`),
'''   KEY `FK_PathwayReaction3` (`PriorReactionWID`),
'''   CONSTRAINT `FK_PathwayReaction1` FOREIGN KEY (`PathwayWID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_PathwayReaction3` FOREIGN KEY (`PriorReactionWID`) REFERENCES `reaction` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pathwayreaction", Database:="warehouse", SchemaSQL:="
CREATE TABLE `pathwayreaction` (
  `PathwayWID` bigint(20) NOT NULL,
  `ReactionWID` bigint(20) NOT NULL,
  `PriorReactionWID` bigint(20) DEFAULT NULL,
  `Hypothetical` char(1) NOT NULL,
  KEY `PR_PATHWID_REACTIONWID` (`PathwayWID`,`ReactionWID`),
  KEY `FK_PathwayReaction3` (`PriorReactionWID`),
  CONSTRAINT `FK_PathwayReaction1` FOREIGN KEY (`PathwayWID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_PathwayReaction3` FOREIGN KEY (`PriorReactionWID`) REFERENCES `reaction` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class pathwayreaction: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("PathwayWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="PathwayWID"), XmlAttribute> Public Property PathwayWID As Long
    <DatabaseField("ReactionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ReactionWID"), XmlAttribute> Public Property ReactionWID As Long
    <DatabaseField("PriorReactionWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="PriorReactionWID")> Public Property PriorReactionWID As Long
    <DatabaseField("Hypothetical"), NotNull, DataType(MySqlDbType.VarChar, "1"), Column(Name:="Hypothetical")> Public Property Hypothetical As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `pathwayreaction` WHERE `PathwayWID`='{0}' and `ReactionWID`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `pathwayreaction` SET `PathwayWID`='{0}', `ReactionWID`='{1}', `PriorReactionWID`='{2}', `Hypothetical`='{3}' WHERE `PathwayWID`='{4}' and `ReactionWID`='{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `pathwayreaction` WHERE `PathwayWID`='{0}' and `ReactionWID`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, PathwayWID, ReactionWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical)
        Else
        Return String.Format(INSERT_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{PathwayWID}', '{ReactionWID}', '{PriorReactionWID}', '{Hypothetical}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `pathwayreaction` (`PathwayWID`, `ReactionWID`, `PriorReactionWID`, `Hypothetical`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical)
        Else
        Return String.Format(REPLACE_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `pathwayreaction` SET `PathwayWID`='{0}', `ReactionWID`='{1}', `PriorReactionWID`='{2}', `Hypothetical`='{3}' WHERE `PathwayWID`='{4}' and `ReactionWID`='{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, PathwayWID, ReactionWID, PriorReactionWID, Hypothetical, PathwayWID, ReactionWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As pathwayreaction
                         Return DirectCast(MyClass.MemberwiseClone, pathwayreaction)
                     End Function
End Class


End Namespace
