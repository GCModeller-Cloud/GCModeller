REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:38


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `helices`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `helices` (
'''   `helix_guid` int(11) NOT NULL DEFAULT '0',
'''   `pkg_guid` int(11) NOT NULL DEFAULT '0',
'''   `art_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` varchar(50) DEFAULT NULL,
'''   `fl_real_name` int(1) DEFAULT NULL,
'''   `genome_guid` int(11) DEFAULT NULL,
'''   `sec_struct_guid` int(11) DEFAULT NULL,
'''   `pos_from1` int(11) DEFAULT NULL,
'''   `pos_to1` int(11) DEFAULT NULL,
'''   `pos_from2` int(11) DEFAULT NULL,
'''   `pos_to2` int(11) DEFAULT NULL,
'''   `descript` blob,
'''   PRIMARY KEY (`helix_guid`),
'''   KEY `FK_helices-pkg_guid` (`pkg_guid`),
'''   KEY `FK_helices-art_guid` (`art_guid`),
'''   KEY `FK_helices-genome_guid` (`genome_guid`),
'''   KEY `FK_helices-sec_struct_guid` (`sec_struct_guid`),
'''   CONSTRAINT `FK_helices-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
'''   CONSTRAINT `FK_helices-genome_guid` FOREIGN KEY (`genome_guid`) REFERENCES `dict_genomes` (`genome_guid`),
'''   CONSTRAINT `FK_helices-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
'''   CONSTRAINT `FK_helices-sec_struct_guid` FOREIGN KEY (`sec_struct_guid`) REFERENCES `sec_structures` (`sec_struct_guid`),
'''   CONSTRAINT `helices_ibfk_1` FOREIGN KEY (`sec_struct_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("helices", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `helices` (
  `helix_guid` int(11) NOT NULL DEFAULT '0',
  `pkg_guid` int(11) NOT NULL DEFAULT '0',
  `art_guid` int(11) NOT NULL DEFAULT '0',
  `name` varchar(50) DEFAULT NULL,
  `fl_real_name` int(1) DEFAULT NULL,
  `genome_guid` int(11) DEFAULT NULL,
  `sec_struct_guid` int(11) DEFAULT NULL,
  `pos_from1` int(11) DEFAULT NULL,
  `pos_to1` int(11) DEFAULT NULL,
  `pos_from2` int(11) DEFAULT NULL,
  `pos_to2` int(11) DEFAULT NULL,
  `descript` blob,
  PRIMARY KEY (`helix_guid`),
  KEY `FK_helices-pkg_guid` (`pkg_guid`),
  KEY `FK_helices-art_guid` (`art_guid`),
  KEY `FK_helices-genome_guid` (`genome_guid`),
  KEY `FK_helices-sec_struct_guid` (`sec_struct_guid`),
  CONSTRAINT `FK_helices-art_guid` FOREIGN KEY (`art_guid`) REFERENCES `articles` (`art_guid`),
  CONSTRAINT `FK_helices-genome_guid` FOREIGN KEY (`genome_guid`) REFERENCES `dict_genomes` (`genome_guid`),
  CONSTRAINT `FK_helices-pkg_guid` FOREIGN KEY (`pkg_guid`) REFERENCES `packages` (`pkg_guid`),
  CONSTRAINT `FK_helices-sec_struct_guid` FOREIGN KEY (`sec_struct_guid`) REFERENCES `sec_structures` (`sec_struct_guid`),
  CONSTRAINT `helices_ibfk_1` FOREIGN KEY (`sec_struct_guid`) REFERENCES `obj_name_genomes` (`obj_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class helices: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("helix_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="helix_guid"), XmlAttribute> Public Property helix_guid As Long
    <DatabaseField("pkg_guid"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="pkg_guid")> Public Property pkg_guid As Long
    <DatabaseField("art_guid"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="art_guid")> Public Property art_guid As Long
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="name")> Public Property name As String
    <DatabaseField("fl_real_name"), DataType(MySqlDbType.Int64, "1"), Column(Name:="fl_real_name")> Public Property fl_real_name As Long
    <DatabaseField("genome_guid"), DataType(MySqlDbType.Int64, "11"), Column(Name:="genome_guid")> Public Property genome_guid As Long
    <DatabaseField("sec_struct_guid"), DataType(MySqlDbType.Int64, "11"), Column(Name:="sec_struct_guid")> Public Property sec_struct_guid As Long
    <DatabaseField("pos_from1"), DataType(MySqlDbType.Int64, "11"), Column(Name:="pos_from1")> Public Property pos_from1 As Long
    <DatabaseField("pos_to1"), DataType(MySqlDbType.Int64, "11"), Column(Name:="pos_to1")> Public Property pos_to1 As Long
    <DatabaseField("pos_from2"), DataType(MySqlDbType.Int64, "11"), Column(Name:="pos_from2")> Public Property pos_from2 As Long
    <DatabaseField("pos_to2"), DataType(MySqlDbType.Int64, "11"), Column(Name:="pos_to2")> Public Property pos_to2 As Long
    <DatabaseField("descript"), DataType(MySqlDbType.Blob), Column(Name:="descript")> Public Property descript As Byte()
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `helices` (`helix_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `sec_struct_guid`, `pos_from1`, `pos_to1`, `pos_from2`, `pos_to2`, `descript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `helices` (`helix_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `sec_struct_guid`, `pos_from1`, `pos_to1`, `pos_from2`, `pos_to2`, `descript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `helices` (`helix_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `sec_struct_guid`, `pos_from1`, `pos_to1`, `pos_from2`, `pos_to2`, `descript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `helices` (`helix_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `sec_struct_guid`, `pos_from1`, `pos_to1`, `pos_from2`, `pos_to2`, `descript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `helices` WHERE `helix_guid` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `helices` SET `helix_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `name`='{3}', `fl_real_name`='{4}', `genome_guid`='{5}', `sec_struct_guid`='{6}', `pos_from1`='{7}', `pos_to1`='{8}', `pos_from2`='{9}', `pos_to2`='{10}', `descript`='{11}' WHERE `helix_guid` = '{12}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `helices` WHERE `helix_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, helix_guid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `helices` (`helix_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `sec_struct_guid`, `pos_from1`, `pos_to1`, `pos_from2`, `pos_to2`, `descript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, helix_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, sec_struct_guid, pos_from1, pos_to1, pos_from2, pos_to2, descript)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `helices` (`helix_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `sec_struct_guid`, `pos_from1`, `pos_to1`, `pos_from2`, `pos_to2`, `descript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, helix_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, sec_struct_guid, pos_from1, pos_to1, pos_from2, pos_to2, descript)
        Else
        Return String.Format(INSERT_SQL, helix_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, sec_struct_guid, pos_from1, pos_to1, pos_from2, pos_to2, descript)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{helix_guid}', '{pkg_guid}', '{art_guid}', '{name}', '{fl_real_name}', '{genome_guid}', '{sec_struct_guid}', '{pos_from1}', '{pos_to1}', '{pos_from2}', '{pos_to2}', '{descript}')"
        Else
            Return $"('{helix_guid}', '{pkg_guid}', '{art_guid}', '{name}', '{fl_real_name}', '{genome_guid}', '{sec_struct_guid}', '{pos_from1}', '{pos_to1}', '{pos_from2}', '{pos_to2}', '{descript}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `helices` (`helix_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `sec_struct_guid`, `pos_from1`, `pos_to1`, `pos_from2`, `pos_to2`, `descript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, helix_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, sec_struct_guid, pos_from1, pos_to1, pos_from2, pos_to2, descript)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `helices` (`helix_guid`, `pkg_guid`, `art_guid`, `name`, `fl_real_name`, `genome_guid`, `sec_struct_guid`, `pos_from1`, `pos_to1`, `pos_from2`, `pos_to2`, `descript`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, helix_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, sec_struct_guid, pos_from1, pos_to1, pos_from2, pos_to2, descript)
        Else
        Return String.Format(REPLACE_SQL, helix_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, sec_struct_guid, pos_from1, pos_to1, pos_from2, pos_to2, descript)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `helices` SET `helix_guid`='{0}', `pkg_guid`='{1}', `art_guid`='{2}', `name`='{3}', `fl_real_name`='{4}', `genome_guid`='{5}', `sec_struct_guid`='{6}', `pos_from1`='{7}', `pos_to1`='{8}', `pos_from2`='{9}', `pos_to2`='{10}', `descript`='{11}' WHERE `helix_guid` = '{12}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, helix_guid, pkg_guid, art_guid, name, fl_real_name, genome_guid, sec_struct_guid, pos_from1, pos_to1, pos_from2, pos_to2, descript, helix_guid)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As helices
                         Return DirectCast(MyClass.MemberwiseClone, helices)
                     End Function
End Class


End Namespace
