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
''' DROP TABLE IF EXISTS `bassaymappingwidbassaymapwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bassaymappingwidbassaymapwid` (
'''   `BioAssayMappingWID` bigint(20) NOT NULL,
'''   `BioAssayMapWID` bigint(20) NOT NULL,
'''   KEY `FK_BAssayMappingWIDBAssayMap1` (`BioAssayMappingWID`),
'''   KEY `FK_BAssayMappingWIDBAssayMap2` (`BioAssayMapWID`),
'''   CONSTRAINT `FK_BAssayMappingWIDBAssayMap1` FOREIGN KEY (`BioAssayMappingWID`) REFERENCES `bioassaymapping` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BAssayMappingWIDBAssayMap2` FOREIGN KEY (`BioAssayMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bassaymappingwidbassaymapwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `bassaymappingwidbassaymapwid` (
  `BioAssayMappingWID` bigint(20) NOT NULL,
  `BioAssayMapWID` bigint(20) NOT NULL,
  KEY `FK_BAssayMappingWIDBAssayMap1` (`BioAssayMappingWID`),
  KEY `FK_BAssayMappingWIDBAssayMap2` (`BioAssayMapWID`),
  CONSTRAINT `FK_BAssayMappingWIDBAssayMap1` FOREIGN KEY (`BioAssayMappingWID`) REFERENCES `bioassaymapping` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BAssayMappingWIDBAssayMap2` FOREIGN KEY (`BioAssayMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class bassaymappingwidbassaymapwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("BioAssayMappingWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayMappingWID"), XmlAttribute> Public Property BioAssayMappingWID As Long
    <DatabaseField("BioAssayMapWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayMapWID")> Public Property BioAssayMapWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `bassaymappingwidbassaymapwid` WHERE `BioAssayMappingWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `bassaymappingwidbassaymapwid` SET `BioAssayMappingWID`='{0}', `BioAssayMapWID`='{1}' WHERE `BioAssayMappingWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `bassaymappingwidbassaymapwid` WHERE `BioAssayMappingWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioAssayMappingWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, BioAssayMappingWID, BioAssayMapWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, BioAssayMappingWID, BioAssayMapWID)
        Else
        Return String.Format(INSERT_SQL, BioAssayMappingWID, BioAssayMapWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{BioAssayMappingWID}', '{BioAssayMapWID}')"
        Else
            Return $"('{BioAssayMappingWID}', '{BioAssayMapWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, BioAssayMappingWID, BioAssayMapWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, BioAssayMappingWID, BioAssayMapWID)
        Else
        Return String.Format(REPLACE_SQL, BioAssayMappingWID, BioAssayMapWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `bassaymappingwidbassaymapwid` SET `BioAssayMappingWID`='{0}', `BioAssayMapWID`='{1}' WHERE `BioAssayMappingWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, BioAssayMappingWID, BioAssayMapWID, BioAssayMappingWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As bassaymappingwidbassaymapwid
                         Return DirectCast(MyClass.MemberwiseClone, bassaymappingwidbassaymapwid)
                     End Function
End Class


End Namespace
