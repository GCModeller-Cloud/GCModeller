REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:15


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current_dn

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `physicalentityhierarchy`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `physicalentityhierarchy` (
'''   `physicalEntityId` int(32) NOT NULL DEFAULT '0',
'''   `childPhysicalEntityId` int(32) NOT NULL DEFAULT '0',
'''   PRIMARY KEY (`physicalEntityId`,`childPhysicalEntityId`),
'''   CONSTRAINT `PhysicalEntityHierarchy_ibfk_1` FOREIGN KEY (`physicalEntityId`) REFERENCES `physicalentity` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("physicalentityhierarchy", Database:="gk_current_dn", SchemaSQL:="
CREATE TABLE `physicalentityhierarchy` (
  `physicalEntityId` int(32) NOT NULL DEFAULT '0',
  `childPhysicalEntityId` int(32) NOT NULL DEFAULT '0',
  PRIMARY KEY (`physicalEntityId`,`childPhysicalEntityId`),
  CONSTRAINT `PhysicalEntityHierarchy_ibfk_1` FOREIGN KEY (`physicalEntityId`) REFERENCES `physicalentity` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class physicalentityhierarchy: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("physicalEntityId"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32"), Column(Name:="physicalEntityId"), XmlAttribute> Public Property physicalEntityId As Long
    <DatabaseField("childPhysicalEntityId"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "32"), Column(Name:="childPhysicalEntityId"), XmlAttribute> Public Property childPhysicalEntityId As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `physicalentityhierarchy` WHERE `physicalEntityId`='{0}' and `childPhysicalEntityId`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `physicalentityhierarchy` SET `physicalEntityId`='{0}', `childPhysicalEntityId`='{1}' WHERE `physicalEntityId`='{2}' and `childPhysicalEntityId`='{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `physicalentityhierarchy` WHERE `physicalEntityId`='{0}' and `childPhysicalEntityId`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, physicalEntityId, childPhysicalEntityId)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, physicalEntityId, childPhysicalEntityId)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, physicalEntityId, childPhysicalEntityId)
        Else
        Return String.Format(INSERT_SQL, physicalEntityId, childPhysicalEntityId)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{physicalEntityId}', '{childPhysicalEntityId}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, physicalEntityId, childPhysicalEntityId)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `physicalentityhierarchy` (`physicalEntityId`, `childPhysicalEntityId`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, physicalEntityId, childPhysicalEntityId)
        Else
        Return String.Format(REPLACE_SQL, physicalEntityId, childPhysicalEntityId)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `physicalentityhierarchy` SET `physicalEntityId`='{0}', `childPhysicalEntityId`='{1}' WHERE `physicalEntityId`='{2}' and `childPhysicalEntityId`='{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, physicalEntityId, childPhysicalEntityId, physicalEntityId, childPhysicalEntityId)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As physicalentityhierarchy
                         Return DirectCast(MyClass.MemberwiseClone, physicalentityhierarchy)
                     End Function
End Class


End Namespace
