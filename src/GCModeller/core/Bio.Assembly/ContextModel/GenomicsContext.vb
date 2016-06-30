﻿#Region "Microsoft.VisualBasic::6b40cb8ea434027fcc94071076943488, ..\Bio.Assembly\ContextModel\GenomicsContext.vb"

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

Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat.ComponentModels
Imports SMRUCC.genomics.ComponentModel
Imports SMRUCC.genomics.ComponentModel.Loci

Namespace ContextModel

    Public Interface IGenomicsContextProvider(Of T As IGeneBrief)

        ''' <summary>
        ''' Listing all of the features loci sites on the genome. 
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property AllFeatures As T()
        Default ReadOnly Property Feature(locus_tag As String) As T

        Function GetByName(locus_tag As String) As T

        ''' <summary>
        ''' 获取某一个位点在位置上有相关联系的基因
        ''' </summary>
        ''' <param name="loci"></param>
        ''' <param name="unstrand"></param>
        ''' <param name="ATGDist"></param>
        ''' <returns></returns>
        Function GetRelatedGenes(loci As NucleotideLocation,
                                 Optional unstrand As Boolean = False,
                                 Optional ATGDist As Integer = 500) As Relationship(Of T)()

        ''' <summary>
        ''' Gets all of the feature sites on the specific <see cref="Strands"/> nucleotide sequence
        ''' </summary>
        ''' <param name="strand"></param>
        ''' <returns></returns>
        Function GetStrandFeatures(strand As Strands) As T()
    End Interface
End Namespace