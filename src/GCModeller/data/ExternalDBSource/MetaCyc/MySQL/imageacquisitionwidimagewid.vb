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
''' DROP TABLE IF EXISTS `imageacquisitionwidimagewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `imageacquisitionwidimagewid` (
'''   `ImageAcquisitionWID` bigint(20) NOT NULL,
'''   `ImageWID` bigint(20) NOT NULL,
'''   KEY `FK_ImageAcquisitionWIDImageW1` (`ImageAcquisitionWID`),
'''   KEY `FK_ImageAcquisitionWIDImageW2` (`ImageWID`),
'''   CONSTRAINT `FK_ImageAcquisitionWIDImageW1` FOREIGN KEY (`ImageAcquisitionWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ImageAcquisitionWIDImageW2` FOREIGN KEY (`ImageWID`) REFERENCES `image` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("imageacquisitionwidimagewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `imageacquisitionwidimagewid` (
  `ImageAcquisitionWID` bigint(20) NOT NULL,
  `ImageWID` bigint(20) NOT NULL,
  KEY `FK_ImageAcquisitionWIDImageW1` (`ImageAcquisitionWID`),
  KEY `FK_ImageAcquisitionWIDImageW2` (`ImageWID`),
  CONSTRAINT `FK_ImageAcquisitionWIDImageW1` FOREIGN KEY (`ImageAcquisitionWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ImageAcquisitionWIDImageW2` FOREIGN KEY (`ImageWID`) REFERENCES `image` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class imageacquisitionwidimagewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ImageAcquisitionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ImageAcquisitionWID"), XmlAttribute> Public Property ImageAcquisitionWID As Long
    <DatabaseField("ImageWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ImageWID")> Public Property ImageWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `imageacquisitionwidimagewid` WHERE `ImageAcquisitionWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `imageacquisitionwidimagewid` SET `ImageAcquisitionWID`='{0}', `ImageWID`='{1}' WHERE `ImageAcquisitionWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `imageacquisitionwidimagewid` WHERE `ImageAcquisitionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ImageAcquisitionWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ImageAcquisitionWID, ImageWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ImageAcquisitionWID, ImageWID)
        Else
        Return String.Format(INSERT_SQL, ImageAcquisitionWID, ImageWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{ImageAcquisitionWID}', '{ImageWID}')"
        Else
            Return $"('{ImageAcquisitionWID}', '{ImageWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ImageAcquisitionWID, ImageWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `imageacquisitionwidimagewid` (`ImageAcquisitionWID`, `ImageWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ImageAcquisitionWID, ImageWID)
        Else
        Return String.Format(REPLACE_SQL, ImageAcquisitionWID, ImageWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `imageacquisitionwidimagewid` SET `ImageAcquisitionWID`='{0}', `ImageWID`='{1}' WHERE `ImageAcquisitionWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ImageAcquisitionWID, ImageWID, ImageAcquisitionWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As imageacquisitionwidimagewid
                         Return DirectCast(MyClass.MemberwiseClone, imageacquisitionwidimagewid)
                     End Function
End Class


End Namespace
