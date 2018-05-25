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
''' DROP TABLE IF EXISTS `bioassaymapping`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bioassaymapping` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_BioAssayMapping1` (`DataSetWID`),
'''   CONSTRAINT `FK_BioAssayMapping1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bioassaymapping", Database:="warehouse", SchemaSQL:="
CREATE TABLE `bioassaymapping` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_BioAssayMapping1` (`DataSetWID`),
  CONSTRAINT `FK_BioAssayMapping1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class bioassaymapping: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `bioassaymapping` (`WID`, `DataSetWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `bioassaymapping` (`WID`, `DataSetWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `bioassaymapping` (`WID`, `DataSetWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `bioassaymapping` (`WID`, `DataSetWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `bioassaymapping` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `bioassaymapping` SET `WID`='{0}', `DataSetWID`='{1}' WHERE `WID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `bioassaymapping` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `bioassaymapping` (`WID`, `DataSetWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `bioassaymapping` (`WID`, `DataSetWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{WID}', '{DataSetWID}')"
        Else
            Return $"('{WID}', '{DataSetWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaymapping` (`WID`, `DataSetWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaymapping` (`WID`, `DataSetWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `bioassaymapping` SET `WID`='{0}', `DataSetWID`='{1}' WHERE `WID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As bioassaymapping
                         Return DirectCast(MyClass.MemberwiseClone, bioassaymapping)
                     End Function
End Class


End Namespace
