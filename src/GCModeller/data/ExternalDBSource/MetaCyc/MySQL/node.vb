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
''' DROP TABLE IF EXISTS `node`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `node` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `BioAssayDataCluster_Nodes` bigint(20) DEFAULT NULL,
'''   `Node_Nodes` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Node1` (`DataSetWID`),
'''   KEY `FK_Node3` (`BioAssayDataCluster_Nodes`),
'''   KEY `FK_Node4` (`Node_Nodes`),
'''   CONSTRAINT `FK_Node1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Node3` FOREIGN KEY (`BioAssayDataCluster_Nodes`) REFERENCES `bioassaydatacluster` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Node4` FOREIGN KEY (`Node_Nodes`) REFERENCES `node` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("node", Database:="warehouse", SchemaSQL:="
CREATE TABLE `node` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `BioAssayDataCluster_Nodes` bigint(20) DEFAULT NULL,
  `Node_Nodes` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Node1` (`DataSetWID`),
  KEY `FK_Node3` (`BioAssayDataCluster_Nodes`),
  KEY `FK_Node4` (`Node_Nodes`),
  CONSTRAINT `FK_Node1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Node3` FOREIGN KEY (`BioAssayDataCluster_Nodes`) REFERENCES `bioassaydatacluster` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Node4` FOREIGN KEY (`Node_Nodes`) REFERENCES `node` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class node: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("BioAssayDataCluster_Nodes"), DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayDataCluster_Nodes")> Public Property BioAssayDataCluster_Nodes As Long
    <DatabaseField("Node_Nodes"), DataType(MySqlDbType.Int64, "20"), Column(Name:="Node_Nodes")> Public Property Node_Nodes As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `node` (`WID`, `DataSetWID`, `BioAssayDataCluster_Nodes`, `Node_Nodes`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `node` (`WID`, `DataSetWID`, `BioAssayDataCluster_Nodes`, `Node_Nodes`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `node` (`WID`, `DataSetWID`, `BioAssayDataCluster_Nodes`, `Node_Nodes`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `node` (`WID`, `DataSetWID`, `BioAssayDataCluster_Nodes`, `Node_Nodes`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `node` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `node` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssayDataCluster_Nodes`='{2}', `Node_Nodes`='{3}' WHERE `WID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `node` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `node` (`WID`, `DataSetWID`, `BioAssayDataCluster_Nodes`, `Node_Nodes`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssayDataCluster_Nodes, Node_Nodes)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `node` (`WID`, `DataSetWID`, `BioAssayDataCluster_Nodes`, `Node_Nodes`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, BioAssayDataCluster_Nodes, Node_Nodes)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssayDataCluster_Nodes, Node_Nodes)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{WID}', '{DataSetWID}', '{BioAssayDataCluster_Nodes}', '{Node_Nodes}')"
        Else
            Return $"('{WID}', '{DataSetWID}', '{BioAssayDataCluster_Nodes}', '{Node_Nodes}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `node` (`WID`, `DataSetWID`, `BioAssayDataCluster_Nodes`, `Node_Nodes`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssayDataCluster_Nodes, Node_Nodes)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `node` (`WID`, `DataSetWID`, `BioAssayDataCluster_Nodes`, `Node_Nodes`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, BioAssayDataCluster_Nodes, Node_Nodes)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssayDataCluster_Nodes, Node_Nodes)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `node` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssayDataCluster_Nodes`='{2}', `Node_Nodes`='{3}' WHERE `WID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, BioAssayDataCluster_Nodes, Node_Nodes, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As node
                         Return DirectCast(MyClass.MemberwiseClone, node)
                     End Function
End Class


End Namespace
