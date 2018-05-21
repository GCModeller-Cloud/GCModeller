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
''' DROP TABLE IF EXISTS `designelementtuple`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `designelementtuple` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `BioAssayTuple` bigint(20) DEFAULT NULL,
'''   `DesignElement` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_DesignElementTuple1` (`DataSetWID`),
'''   KEY `FK_DesignElementTuple2` (`BioAssayTuple`),
'''   KEY `FK_DesignElementTuple3` (`DesignElement`),
'''   CONSTRAINT `FK_DesignElementTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementTuple2` FOREIGN KEY (`BioAssayTuple`) REFERENCES `bioassaytuple` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_DesignElementTuple3` FOREIGN KEY (`DesignElement`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("designelementtuple", Database:="warehouse", SchemaSQL:="
CREATE TABLE `designelementtuple` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `BioAssayTuple` bigint(20) DEFAULT NULL,
  `DesignElement` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_DesignElementTuple1` (`DataSetWID`),
  KEY `FK_DesignElementTuple2` (`BioAssayTuple`),
  KEY `FK_DesignElementTuple3` (`DesignElement`),
  CONSTRAINT `FK_DesignElementTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementTuple2` FOREIGN KEY (`BioAssayTuple`) REFERENCES `bioassaytuple` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DesignElementTuple3` FOREIGN KEY (`DesignElement`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class designelementtuple: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("BioAssayTuple"), DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayTuple")> Public Property BioAssayTuple As Long
    <DatabaseField("DesignElement"), DataType(MySqlDbType.Int64, "20"), Column(Name:="DesignElement")> Public Property DesignElement As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `designelementtuple` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `designelementtuple` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssayTuple`='{2}', `DesignElement`='{3}' WHERE `WID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `designelementtuple` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{BioAssayTuple}', '{DesignElement}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `designelementtuple` (`WID`, `DataSetWID`, `BioAssayTuple`, `DesignElement`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssayTuple, DesignElement)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `designelementtuple` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssayTuple`='{2}', `DesignElement`='{3}' WHERE `WID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, BioAssayTuple, DesignElement, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As designelementtuple
                         Return DirectCast(MyClass.MemberwiseClone, designelementtuple)
                     End Function
End Class


End Namespace
