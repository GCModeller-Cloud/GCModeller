REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @9/5/2016 7:59:33 AM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `gene_product`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gene_product` (
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   `symbol` varchar(128) NOT NULL,
'''   `dbxref_id` int(11) NOT NULL,
'''   `species_id` int(11) DEFAULT NULL,
'''   `type_id` int(11) DEFAULT NULL,
'''   `full_name` text,
'''   PRIMARY KEY (`id`),
'''   UNIQUE KEY `dbxref_id` (`dbxref_id`),
'''   UNIQUE KEY `g0` (`id`),
'''   KEY `type_id` (`type_id`),
'''   KEY `g1` (`symbol`),
'''   KEY `g2` (`dbxref_id`),
'''   KEY `g3` (`species_id`),
'''   KEY `g4` (`id`,`species_id`),
'''   KEY `g5` (`dbxref_id`,`species_id`),
'''   KEY `g6` (`id`,`dbxref_id`),
'''   KEY `g7` (`id`,`species_id`),
'''   KEY `g8` (`id`,`dbxref_id`,`species_id`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gene_product", Database:="go", SchemaSQL:="
CREATE TABLE `gene_product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `symbol` varchar(128) NOT NULL,
  `dbxref_id` int(11) NOT NULL,
  `species_id` int(11) DEFAULT NULL,
  `type_id` int(11) DEFAULT NULL,
  `full_name` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `dbxref_id` (`dbxref_id`),
  UNIQUE KEY `g0` (`id`),
  KEY `type_id` (`type_id`),
  KEY `g1` (`symbol`),
  KEY `g2` (`dbxref_id`),
  KEY `g3` (`species_id`),
  KEY `g4` (`id`,`species_id`),
  KEY `g5` (`dbxref_id`,`species_id`),
  KEY `g6` (`id`,`dbxref_id`),
  KEY `g7` (`id`,`species_id`),
  KEY `g8` (`id`,`dbxref_id`,`species_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class gene_product: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("symbol"), NotNull, DataType(MySqlDbType.VarChar, "128")> Public Property symbol As String
    <DatabaseField("dbxref_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property dbxref_id As Long
    <DatabaseField("species_id"), DataType(MySqlDbType.Int64, "11")> Public Property species_id As Long
    <DatabaseField("type_id"), DataType(MySqlDbType.Int64, "11")> Public Property type_id As Long
    <DatabaseField("full_name"), DataType(MySqlDbType.Text)> Public Property full_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gene_product` (`symbol`, `dbxref_id`, `species_id`, `type_id`, `full_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gene_product` (`symbol`, `dbxref_id`, `species_id`, `type_id`, `full_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gene_product` WHERE `id` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gene_product` SET `id`='{0}', `symbol`='{1}', `dbxref_id`='{2}', `species_id`='{3}', `type_id`='{4}', `full_name`='{5}' WHERE `id` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `gene_product` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `gene_product` (`symbol`, `dbxref_id`, `species_id`, `type_id`, `full_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, symbol, dbxref_id, species_id, type_id, full_name)
    End Function
''' <summary>
''' ```SQL
''' REPLACE INTO `gene_product` (`symbol`, `dbxref_id`, `species_id`, `type_id`, `full_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, symbol, dbxref_id, species_id, type_id, full_name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `gene_product` SET `id`='{0}', `symbol`='{1}', `dbxref_id`='{2}', `species_id`='{3}', `type_id`='{4}', `full_name`='{5}' WHERE `id` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, symbol, dbxref_id, species_id, type_id, full_name, id)
    End Function
#End Region
End Class


End Namespace
