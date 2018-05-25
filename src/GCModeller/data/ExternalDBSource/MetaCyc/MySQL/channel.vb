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
''' DROP TABLE IF EXISTS `channel`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `channel` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Channel1` (`DataSetWID`),
'''   CONSTRAINT `FK_Channel1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("channel", Database:="warehouse", SchemaSQL:="
CREATE TABLE `channel` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Channel1` (`DataSetWID`),
  CONSTRAINT `FK_Channel1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class channel: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Identifier")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Name")> Public Property Name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `channel` (`WID`, `DataSetWID`, `Identifier`, `Name`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `channel` (`WID`, `DataSetWID`, `Identifier`, `Name`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `channel` (`WID`, `DataSetWID`, `Identifier`, `Name`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `channel` (`WID`, `DataSetWID`, `Identifier`, `Name`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `channel` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `channel` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}' WHERE `WID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `channel` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `channel` (`WID`, `DataSetWID`, `Identifier`, `Name`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Identifier, Name)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `channel` (`WID`, `DataSetWID`, `Identifier`, `Name`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, Identifier, Name)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, Identifier, Name)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{WID}', '{DataSetWID}', '{Identifier}', '{Name}')"
        Else
            Return $"('{WID}', '{DataSetWID}', '{Identifier}', '{Name}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `channel` (`WID`, `DataSetWID`, `Identifier`, `Name`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Identifier, Name)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `channel` (`WID`, `DataSetWID`, `Identifier`, `Name`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, Identifier, Name)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Identifier, Name)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `channel` SET `WID`='{0}', `DataSetWID`='{1}', `Identifier`='{2}', `Name`='{3}' WHERE `WID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Identifier, Name, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As channel
                         Return DirectCast(MyClass.MemberwiseClone, channel)
                     End Function
End Class


End Namespace
