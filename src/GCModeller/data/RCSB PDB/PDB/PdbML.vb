﻿#Region "Microsoft.VisualBasic::202a4796340c8b9c86f10912624a2d62, ..\GCModeller\data\RCSB PDB\PDB\PdbML.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
' 
' Copyright (c) 2016 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
' 
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
' 
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
' 
' You should have received a copy of the GNU General Public License
' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.DocumentFormat
Imports Microsoft.VisualBasic.DocumentFormat.RDF.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace PDBML

    ''' <summary>
    ''' ##### PDBML/XML File Format
    ''' 
    ''' The ``Protein Data Bank Markup Language (PDBML)`` provides a representation of PDB data in XML 
    ''' format. 
    ''' The description of this format is provided in XML schema of the PDB Exchange Data Dictionary. 
    ''' This schema is produced by direct translation of the mmCIF format PDB Exchange Data Dictionary. 
    ''' Other data dictionaries used by the PDB have been electronically translated into XML/XSD schemas.
    ''' 
    ''' Further information and related resources are available at http://pdbml.pdb.org/.
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot("datablock", DataType:="datablock", Namespace:="http://pdbml.pdb.org/schema/pdbx-v40.xsd")>
    Public Class PdbML

        <XmlAttribute> Public Property datablockName As String
        <XmlElement("atom_siteCategory")> Public Property AtomSiteCategory As atom.siteCategory
        <XmlElement("entity_polyCategory")> Public Property entityPolyCategory As entity_polyCategory

        <XmlType("entity_polyCategory", Namespace:="http://pdbml.pdb.org/schema/pdbx-v40.xsd", IncludeInSchema:=True)>
        Public Class entity_polyCategory

            <XmlElement("entity_poly", Namespace:="http://pdbml.pdb.org/schema/pdbx-v40.xsd")> Public Property entity_polyes As entity_poly()

            Public Class entity_poly
                <XmlAttribute("entity_id")> Public Property entity_id As Integer
                ' <PDBx:nstd_linkage>no</PDBx:nstd_linkage>
                ' <PDBx:nstd_monomer>no</PDBx:nstd_monomer>
                Public Property pdbx_seq_one_letter_code As String
                Public Property pdbx_seq_one_letter_code_can As String
                Public Property pdbx_strand_id As String
                Public Property type As String
            End Class
        End Class
    End Class

    Public MustInherit Class PDBx

        <XmlAttribute> Public Property id As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class

    Namespace atom

        <XmlType("atom_site")>
        Public Class Site : Inherits PDBx

            <XmlElement("B_iso_or_equiv")> Public Property B_iso_or_equiv As String
            <XmlElement("Cartn_x")> Public Property Cartn_x As String
            <XmlElement("Cartn_y")> Public Property Cartn_y As String
            <XmlElement("Cartn_z")> Public Property Cartn_z As String
            <XmlElement("auth_asym_id")> Public Property auth_asym_id As String
            <XmlElement("auth_atom_id")> Public Property auth_atom_id As String
            <XmlElement("auth_comp_id")> Public Property auth_comp_id As String
            <XmlElement("auth_seq_id")> Public Property auth_seq_id As String
            <XmlElement("group_PDB")> Public Property group_PDB As String
            '<XmlElement("label_alt_id")> xsi:nil="true"/>
            <XmlElement("label_asym_id")> Public Property label_asym_id As String
            <XmlElement("label_atom_id")> Public Property label_atom_id As String
            <XmlElement("label_comp_id")> Public Property label_comp_id As String
            <XmlElement("label_entity_id")> Public Property label_entity_id As String
            <XmlElement("label_seq_id")> Public Property label_seq_id As String
            <XmlElement("occupancy")> Public Property occupancy As String
            <XmlElement("pdbx_PDB_model_num")> Public Property pdbx_PDB_model_num As String
            <XmlElement("type_symbol")> Public Property type_symbol As String
        End Class

        <XmlType("atom_site_anisotrop")>
        Public Class anisotrop : Inherits PDBx

            Public Property U11 As String
            Public Property U12 As String
            Public Property U13 As String
            Public Property U22 As String
            Public Property U23 As String
            Public Property U33 As String
            Public Property pdbx_auth_asym_id As String
            Public Property pdbx_auth_atom_id As String
            Public Property pdbx_auth_comp_id As String
            Public Property pdbx_auth_seq_id As String
            ' <PDBx:pdbx_label_alt_id xsi : nil="true" />
            Public Property pdbx_label_asym_id As String
            Public Property pdbx_label_atom_id As String
            Public Property pdbx_label_comp_id As String
            Public Property pdbx_label_seq_id As String
            Public Property type_symbol As String
        End Class

        <XmlType("atom_siteCategory")> Public Class siteCategory

            <XmlElement("atom_site")>
            Public Property atom_sites As atom.Site()
        End Class

        <XmlType("atom_site_anisotropCategory")> Public Class anisotropCategory

            <XmlElement("atom_site_anisotrop")>
            Public Property atom_site_anisotrop As anisotrop()
        End Class
    End Namespace
End Namespace
