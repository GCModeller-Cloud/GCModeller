﻿#Region "Microsoft.VisualBasic::453f9f2c4fdb4a4f59e34a18b5155f3c, ..\GCModeller\CLI_tools\ProteinInteraction\CLI\LDM\API.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
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

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Linq.Extensions
Imports SMRUCC.genomics
Imports SMRUCC.genomics.Data.Xfam
Imports SMRUCC.genomics.SequenceModel.Patterns.Clustal

Public Module API

    <Extension> Public Function GetPfamString(SRChain As SR(), title As String) As Pfam.PfamString.PfamString
        Dim LQuery = (From ch As SR In SRChain
                      Where Not String.Equals(ch.Block, "*")
                      Select ch
                      Group By ch.Block Into Group).ToArray
        Dim fD = (From x In LQuery Select __AsDomain(x.Group.ToArray)).ToArray
        Dim PfamString As New Pfam.PfamString.PfamString With {
            .ProteinId = title,
            .PfamString = fD.ToArray(Function(x) x.ToString),
            .Length = SRChain.Length,
            .Domains = (From x In fD Select x.Identifier Distinct).ToArray
        }
        Return PfamString
    End Function

    Private Function __AsDomain(srchain As SR()) As ProteinModel.DomainObject
        Dim index As Integer() = srchain.ToArray(Function(x) x.Index)
        Dim pos As ComponentModel.Loci.Location =
            If(index.Length = 1,
            New ComponentModel.Loci.Location(index(Scan0), index(Scan0) + 1),
            New ComponentModel.Loci.Location(index.Min, index.Max))
        srchain = (From x In srchain Select x Order By x.Index Ascending).ToArray
        Return New ProteinModel.DomainObject With {
            .Identifier = New String(srchain.ToArray(Function(x) x.Residue)),
            .Position = pos
        }
    End Function

    <Extension> Public Function ToPfamString(chain As SRChain) As Pfam.PfamString.PfamString
        Return chain.lstSR.GetPfamString(chain.Name)
    End Function

    <Extension> Public Function ToSignature(chain As SRChain) As Signature
        Return Signature.CreateObject(chain)
    End Function
End Module
