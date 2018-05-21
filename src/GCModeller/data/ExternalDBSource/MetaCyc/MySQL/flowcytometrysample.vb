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
''' DROP TABLE IF EXISTS `flowcytometrysample`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `flowcytometrysample` (
'''   `WID` bigint(20) NOT NULL,
'''   `BioSourceWID` bigint(20) DEFAULT NULL,
'''   `FlowCytometryProbeWID` bigint(20) DEFAULT NULL,
'''   `MeasurementWID` bigint(20) DEFAULT NULL,
'''   `ManufacturerWID` bigint(20) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FlowCytometrySample_DWID` (`DataSetWID`),
'''   KEY `FK_FlowCytometrySample1` (`BioSourceWID`),
'''   KEY `FK_FlowCytometrySample2` (`FlowCytometryProbeWID`),
'''   KEY `FK_FlowCytometrySample3` (`MeasurementWID`),
'''   KEY `FK_FlowCytometrySample4` (`ManufacturerWID`),
'''   CONSTRAINT `FK_FlowCytometrySample1` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FlowCytometrySample2` FOREIGN KEY (`FlowCytometryProbeWID`) REFERENCES `flowcytometryprobe` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FlowCytometrySample3` FOREIGN KEY (`MeasurementWID`) REFERENCES `measurement` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FlowCytometrySample4` FOREIGN KEY (`ManufacturerWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FlowCytometrySampleDS` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("flowcytometrysample", Database:="warehouse", SchemaSQL:="
CREATE TABLE `flowcytometrysample` (
  `WID` bigint(20) NOT NULL,
  `BioSourceWID` bigint(20) DEFAULT NULL,
  `FlowCytometryProbeWID` bigint(20) DEFAULT NULL,
  `MeasurementWID` bigint(20) DEFAULT NULL,
  `ManufacturerWID` bigint(20) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FlowCytometrySample_DWID` (`DataSetWID`),
  KEY `FK_FlowCytometrySample1` (`BioSourceWID`),
  KEY `FK_FlowCytometrySample2` (`FlowCytometryProbeWID`),
  KEY `FK_FlowCytometrySample3` (`MeasurementWID`),
  KEY `FK_FlowCytometrySample4` (`ManufacturerWID`),
  CONSTRAINT `FK_FlowCytometrySample1` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FlowCytometrySample2` FOREIGN KEY (`FlowCytometryProbeWID`) REFERENCES `flowcytometryprobe` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FlowCytometrySample3` FOREIGN KEY (`MeasurementWID`) REFERENCES `measurement` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FlowCytometrySample4` FOREIGN KEY (`ManufacturerWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FlowCytometrySampleDS` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class flowcytometrysample: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("BioSourceWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="BioSourceWID")> Public Property BioSourceWID As Long
    <DatabaseField("FlowCytometryProbeWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="FlowCytometryProbeWID")> Public Property FlowCytometryProbeWID As Long
    <DatabaseField("MeasurementWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="MeasurementWID")> Public Property MeasurementWID As Long
    <DatabaseField("ManufacturerWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="ManufacturerWID")> Public Property ManufacturerWID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `flowcytometrysample` (`WID`, `BioSourceWID`, `FlowCytometryProbeWID`, `MeasurementWID`, `ManufacturerWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `flowcytometrysample` (`WID`, `BioSourceWID`, `FlowCytometryProbeWID`, `MeasurementWID`, `ManufacturerWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `flowcytometrysample` (`WID`, `BioSourceWID`, `FlowCytometryProbeWID`, `MeasurementWID`, `ManufacturerWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `flowcytometrysample` (`WID`, `BioSourceWID`, `FlowCytometryProbeWID`, `MeasurementWID`, `ManufacturerWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `flowcytometrysample` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `flowcytometrysample` SET `WID`='{0}', `BioSourceWID`='{1}', `FlowCytometryProbeWID`='{2}', `MeasurementWID`='{3}', `ManufacturerWID`='{4}', `DataSetWID`='{5}' WHERE `WID` = '{6}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `flowcytometrysample` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `flowcytometrysample` (`WID`, `BioSourceWID`, `FlowCytometryProbeWID`, `MeasurementWID`, `ManufacturerWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, BioSourceWID, FlowCytometryProbeWID, MeasurementWID, ManufacturerWID, DataSetWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `flowcytometrysample` (`WID`, `BioSourceWID`, `FlowCytometryProbeWID`, `MeasurementWID`, `ManufacturerWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, BioSourceWID, FlowCytometryProbeWID, MeasurementWID, ManufacturerWID, DataSetWID)
        Else
        Return String.Format(INSERT_SQL, WID, BioSourceWID, FlowCytometryProbeWID, MeasurementWID, ManufacturerWID, DataSetWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{BioSourceWID}', '{FlowCytometryProbeWID}', '{MeasurementWID}', '{ManufacturerWID}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `flowcytometrysample` (`WID`, `BioSourceWID`, `FlowCytometryProbeWID`, `MeasurementWID`, `ManufacturerWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, BioSourceWID, FlowCytometryProbeWID, MeasurementWID, ManufacturerWID, DataSetWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `flowcytometrysample` (`WID`, `BioSourceWID`, `FlowCytometryProbeWID`, `MeasurementWID`, `ManufacturerWID`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, BioSourceWID, FlowCytometryProbeWID, MeasurementWID, ManufacturerWID, DataSetWID)
        Else
        Return String.Format(REPLACE_SQL, WID, BioSourceWID, FlowCytometryProbeWID, MeasurementWID, ManufacturerWID, DataSetWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `flowcytometrysample` SET `WID`='{0}', `BioSourceWID`='{1}', `FlowCytometryProbeWID`='{2}', `MeasurementWID`='{3}', `ManufacturerWID`='{4}', `DataSetWID`='{5}' WHERE `WID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, BioSourceWID, FlowCytometryProbeWID, MeasurementWID, ManufacturerWID, DataSetWID, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As flowcytometrysample
                         Return DirectCast(MyClass.MemberwiseClone, flowcytometrysample)
                     End Function
End Class


End Namespace
