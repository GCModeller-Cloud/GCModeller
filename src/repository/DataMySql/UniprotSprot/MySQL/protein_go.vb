REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/2 23:51:59


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_UniProtKB

''' <summary>
''' ```SQL
''' 对蛋白质的GO功能注释的信息关联表
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_go`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_go` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) NOT NULL,
'''   `go_id` int(10) unsigned NOT NULL,
'''   PRIMARY KEY (`hash_code`,`go_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='对蛋白质的GO功能注释的信息关联表';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_go", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_go` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) NOT NULL,
  `go_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`hash_code`,`go_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='对蛋白质的GO功能注释的信息关联表';")>
Public Class protein_go: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), NotNull, DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("go_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="go_id"), XmlAttribute> Public Property go_id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_go` (`hash_code`, `uniprot_id`, `go_id`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_go` (`hash_code`, `uniprot_id`, `go_id`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_go` WHERE `hash_code`='{0}' and `go_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_go` SET `hash_code`='{0}', `uniprot_id`='{1}', `go_id`='{2}' WHERE `hash_code`='{3}' and `go_id`='{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_go` WHERE `hash_code`='{0}' and `go_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code, go_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_go` (`hash_code`, `uniprot_id`, `go_id`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, go_id)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{hash_code}', '{uniprot_id}', '{go_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_go` (`hash_code`, `uniprot_id`, `go_id`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, go_id)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_go` SET `hash_code`='{0}', `uniprot_id`='{1}', `go_id`='{2}' WHERE `hash_code`='{3}' and `go_id`='{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, go_id, hash_code, go_id)
    End Function
#End Region
Public Function Clone() As protein_go
                  Return DirectCast(MyClass.MemberwiseClone, protein_go)
              End Function
End Class


End Namespace
