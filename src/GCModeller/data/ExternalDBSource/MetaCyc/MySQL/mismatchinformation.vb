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
''' DROP TABLE IF EXISTS `mismatchinformation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `mismatchinformation` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `CompositePosition` bigint(20) DEFAULT NULL,
'''   `FeatureInformation` bigint(20) DEFAULT NULL,
'''   `StartCoord` smallint(6) DEFAULT NULL,
'''   `NewSequence` varchar(255) DEFAULT NULL,
'''   `ReplacedLength` smallint(6) DEFAULT NULL,
'''   `ReporterPosition` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_MismatchInformation1` (`DataSetWID`),
'''   KEY `FK_MismatchInformation2` (`CompositePosition`),
'''   KEY `FK_MismatchInformation3` (`FeatureInformation`),
'''   KEY `FK_MismatchInformation4` (`ReporterPosition`),
'''   CONSTRAINT `FK_MismatchInformation1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_MismatchInformation2` FOREIGN KEY (`CompositePosition`) REFERENCES `sequenceposition` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_MismatchInformation3` FOREIGN KEY (`FeatureInformation`) REFERENCES `featureinformation` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_MismatchInformation4` FOREIGN KEY (`ReporterPosition`) REFERENCES `sequenceposition` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("mismatchinformation", Database:="warehouse", SchemaSQL:="
CREATE TABLE `mismatchinformation` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `CompositePosition` bigint(20) DEFAULT NULL,
  `FeatureInformation` bigint(20) DEFAULT NULL,
  `StartCoord` smallint(6) DEFAULT NULL,
  `NewSequence` varchar(255) DEFAULT NULL,
  `ReplacedLength` smallint(6) DEFAULT NULL,
  `ReporterPosition` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_MismatchInformation1` (`DataSetWID`),
  KEY `FK_MismatchInformation2` (`CompositePosition`),
  KEY `FK_MismatchInformation3` (`FeatureInformation`),
  KEY `FK_MismatchInformation4` (`ReporterPosition`),
  CONSTRAINT `FK_MismatchInformation1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_MismatchInformation2` FOREIGN KEY (`CompositePosition`) REFERENCES `sequenceposition` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_MismatchInformation3` FOREIGN KEY (`FeatureInformation`) REFERENCES `featureinformation` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_MismatchInformation4` FOREIGN KEY (`ReporterPosition`) REFERENCES `sequenceposition` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class mismatchinformation: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("CompositePosition"), DataType(MySqlDbType.Int64, "20"), Column(Name:="CompositePosition")> Public Property CompositePosition As Long
    <DatabaseField("FeatureInformation"), DataType(MySqlDbType.Int64, "20"), Column(Name:="FeatureInformation")> Public Property FeatureInformation As Long
    <DatabaseField("StartCoord"), DataType(MySqlDbType.Int64, "6"), Column(Name:="StartCoord")> Public Property StartCoord As Long
    <DatabaseField("NewSequence"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="NewSequence")> Public Property NewSequence As String
    <DatabaseField("ReplacedLength"), DataType(MySqlDbType.Int64, "6"), Column(Name:="ReplacedLength")> Public Property ReplacedLength As Long
    <DatabaseField("ReporterPosition"), DataType(MySqlDbType.Int64, "20"), Column(Name:="ReporterPosition")> Public Property ReporterPosition As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `mismatchinformation` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `mismatchinformation` SET `WID`='{0}', `DataSetWID`='{1}', `CompositePosition`='{2}', `FeatureInformation`='{3}', `StartCoord`='{4}', `NewSequence`='{5}', `ReplacedLength`='{6}', `ReporterPosition`='{7}' WHERE `WID` = '{8}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `mismatchinformation` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{WID}', '{DataSetWID}', '{CompositePosition}', '{FeatureInformation}', '{StartCoord}', '{NewSequence}', '{ReplacedLength}', '{ReporterPosition}')"
        Else
            Return $"('{WID}', '{DataSetWID}', '{CompositePosition}', '{FeatureInformation}', '{StartCoord}', '{NewSequence}', '{ReplacedLength}', '{ReporterPosition}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `mismatchinformation` (`WID`, `DataSetWID`, `CompositePosition`, `FeatureInformation`, `StartCoord`, `NewSequence`, `ReplacedLength`, `ReporterPosition`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `mismatchinformation` SET `WID`='{0}', `DataSetWID`='{1}', `CompositePosition`='{2}', `FeatureInformation`='{3}', `StartCoord`='{4}', `NewSequence`='{5}', `ReplacedLength`='{6}', `ReporterPosition`='{7}' WHERE `WID` = '{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, CompositePosition, FeatureInformation, StartCoord, NewSequence, ReplacedLength, ReporterPosition, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As mismatchinformation
                         Return DirectCast(MyClass.MemberwiseClone, mismatchinformation)
                     End Function
End Class


End Namespace
