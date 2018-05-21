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
''' DROP TABLE IF EXISTS `dataexternal`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dataexternal` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `DataFormat` varchar(255) DEFAULT NULL,
'''   `DataFormatInfoURI` varchar(255) DEFAULT NULL,
'''   `FilenameURI` varchar(255) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_DataExternal1` (`DataSetWID`),
'''   CONSTRAINT `FK_DataExternal1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dataexternal", Database:="warehouse", SchemaSQL:="
CREATE TABLE `dataexternal` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `DataFormat` varchar(255) DEFAULT NULL,
  `DataFormatInfoURI` varchar(255) DEFAULT NULL,
  `FilenameURI` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_DataExternal1` (`DataSetWID`),
  CONSTRAINT `FK_DataExternal1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class dataexternal: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("DataFormat"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="DataFormat")> Public Property DataFormat As String
    <DatabaseField("DataFormatInfoURI"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="DataFormatInfoURI")> Public Property DataFormatInfoURI As String
    <DatabaseField("FilenameURI"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="FilenameURI")> Public Property FilenameURI As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `dataexternal` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `dataexternal` SET `WID`='{0}', `DataSetWID`='{1}', `DataFormat`='{2}', `DataFormatInfoURI`='{3}', `FilenameURI`='{4}' WHERE `WID` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `dataexternal` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{DataFormat}', '{DataFormatInfoURI}', '{FilenameURI}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `dataexternal` (`WID`, `DataSetWID`, `DataFormat`, `DataFormatInfoURI`, `FilenameURI`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `dataexternal` SET `WID`='{0}', `DataSetWID`='{1}', `DataFormat`='{2}', `DataFormatInfoURI`='{3}', `FilenameURI`='{4}' WHERE `WID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, DataFormat, DataFormatInfoURI, FilenameURI, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As dataexternal
                         Return DirectCast(MyClass.MemberwiseClone, dataexternal)
                     End Function
End Class


End Namespace
