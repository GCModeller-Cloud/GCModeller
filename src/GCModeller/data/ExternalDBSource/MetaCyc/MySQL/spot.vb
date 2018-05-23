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
''' DROP TABLE IF EXISTS `spot`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `spot` (
'''   `WID` bigint(20) NOT NULL,
'''   `SpotId` varchar(25) DEFAULT NULL,
'''   `MolecularWeightEst` float DEFAULT NULL,
'''   `PIEst` varchar(50) DEFAULT NULL,
'''   `DatasetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Spot` (`DatasetWID`),
'''   CONSTRAINT `FK_Spot` FOREIGN KEY (`DatasetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("spot", Database:="warehouse", SchemaSQL:="
CREATE TABLE `spot` (
  `WID` bigint(20) NOT NULL,
  `SpotId` varchar(25) DEFAULT NULL,
  `MolecularWeightEst` float DEFAULT NULL,
  `PIEst` varchar(50) DEFAULT NULL,
  `DatasetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Spot` (`DatasetWID`),
  CONSTRAINT `FK_Spot` FOREIGN KEY (`DatasetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class spot: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("SpotId"), DataType(MySqlDbType.VarChar, "25"), Column(Name:="SpotId")> Public Property SpotId As String
    <DatabaseField("MolecularWeightEst"), DataType(MySqlDbType.Double), Column(Name:="MolecularWeightEst")> Public Property MolecularWeightEst As Double
    <DatabaseField("PIEst"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="PIEst")> Public Property PIEst As String
    <DatabaseField("DatasetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DatasetWID")> Public Property DatasetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `spot` (`WID`, `SpotId`, `MolecularWeightEst`, `PIEst`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `spot` (`WID`, `SpotId`, `MolecularWeightEst`, `PIEst`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `spot` (`WID`, `SpotId`, `MolecularWeightEst`, `PIEst`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `spot` (`WID`, `SpotId`, `MolecularWeightEst`, `PIEst`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `spot` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `spot` SET `WID`='{0}', `SpotId`='{1}', `MolecularWeightEst`='{2}', `PIEst`='{3}', `DatasetWID`='{4}' WHERE `WID` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `spot` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `spot` (`WID`, `SpotId`, `MolecularWeightEst`, `PIEst`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, SpotId, MolecularWeightEst, PIEst, DatasetWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `spot` (`WID`, `SpotId`, `MolecularWeightEst`, `PIEst`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, SpotId, MolecularWeightEst, PIEst, DatasetWID)
        Else
        Return String.Format(INSERT_SQL, WID, SpotId, MolecularWeightEst, PIEst, DatasetWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{WID}', '{SpotId}', '{MolecularWeightEst}', '{PIEst}', '{DatasetWID}')"
        Else
            Return $"('{WID}', '{SpotId}', '{MolecularWeightEst}', '{PIEst}', '{DatasetWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `spot` (`WID`, `SpotId`, `MolecularWeightEst`, `PIEst`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, SpotId, MolecularWeightEst, PIEst, DatasetWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `spot` (`WID`, `SpotId`, `MolecularWeightEst`, `PIEst`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, SpotId, MolecularWeightEst, PIEst, DatasetWID)
        Else
        Return String.Format(REPLACE_SQL, WID, SpotId, MolecularWeightEst, PIEst, DatasetWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `spot` SET `WID`='{0}', `SpotId`='{1}', `MolecularWeightEst`='{2}', `PIEst`='{3}', `DatasetWID`='{4}' WHERE `WID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, SpotId, MolecularWeightEst, PIEst, DatasetWID, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As spot
                         Return DirectCast(MyClass.MemberwiseClone, spot)
                     End Function
End Class


End Namespace
