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
''' DROP TABLE IF EXISTS `softwarewidcontactwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `softwarewidcontactwid` (
'''   `SoftwareWID` bigint(20) NOT NULL,
'''   `ContactWID` bigint(20) NOT NULL,
'''   KEY `FK_SoftwareWIDContactWID1` (`SoftwareWID`),
'''   KEY `FK_SoftwareWIDContactWID2` (`ContactWID`),
'''   CONSTRAINT `FK_SoftwareWIDContactWID1` FOREIGN KEY (`SoftwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_SoftwareWIDContactWID2` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("softwarewidcontactwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `softwarewidcontactwid` (
  `SoftwareWID` bigint(20) NOT NULL,
  `ContactWID` bigint(20) NOT NULL,
  KEY `FK_SoftwareWIDContactWID1` (`SoftwareWID`),
  KEY `FK_SoftwareWIDContactWID2` (`ContactWID`),
  CONSTRAINT `FK_SoftwareWIDContactWID1` FOREIGN KEY (`SoftwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_SoftwareWIDContactWID2` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class softwarewidcontactwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("SoftwareWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="SoftwareWID"), XmlAttribute> Public Property SoftwareWID As Long
    <DatabaseField("ContactWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ContactWID")> Public Property ContactWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `softwarewidcontactwid` WHERE `SoftwareWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `softwarewidcontactwid` SET `SoftwareWID`='{0}', `ContactWID`='{1}' WHERE `SoftwareWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `softwarewidcontactwid` WHERE `SoftwareWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, SoftwareWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, SoftwareWID, ContactWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, SoftwareWID, ContactWID)
        Else
        Return String.Format(INSERT_SQL, SoftwareWID, ContactWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{SoftwareWID}', '{ContactWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, SoftwareWID, ContactWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, SoftwareWID, ContactWID)
        Else
        Return String.Format(REPLACE_SQL, SoftwareWID, ContactWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `softwarewidcontactwid` SET `SoftwareWID`='{0}', `ContactWID`='{1}' WHERE `SoftwareWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, SoftwareWID, ContactWID, SoftwareWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As softwarewidcontactwid
                         Return DirectCast(MyClass.MemberwiseClone, softwarewidcontactwid)
                     End Function
End Class


End Namespace
