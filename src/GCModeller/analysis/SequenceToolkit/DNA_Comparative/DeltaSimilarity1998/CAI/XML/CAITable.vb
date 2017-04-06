﻿#Region "Microsoft.VisualBasic::8d506a6173ccf97feefabaa003cc3863, ..\GCModeller\analysis\SequenceToolkit\DNA_Comparative\Sigma\CAI\CAITable.vb"

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

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq

Namespace DeltaSimilarity1998.CAI.XML

    ''' <summary>
    ''' codon adaptation index profile table
    ''' </summary>
    Public Class CAITable : Inherits ClassObject

        <XmlAttribute> Public Property CAI As Double

        Public Property BiasTable As CodonFrequencyCAI()

        ''' <summary>
        ''' 对<see cref="BiasTable"></see>进行展开
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetCodonBiasList() As KeyValuePair(Of Char, CodonBias)()
            Return BiasTable _
                .Select(Function(subItem)
                            Return subItem _
                                .BiasFrequency _
                                .Select(Function(bfrq) New KeyValuePair(Of Char, CodonBias)(
                                    subItem.AminoAcid,
                                    bfrq))
                        End Function) _
                .IteratesALL _
                .ToArray
        End Function

        Sub New()
        End Sub

        Sub New(Model As RelativeCodonBiases)
            CAI = Model.CAI
            BiasTable = LinqAPI.Exec(Of CodonFrequencyCAI) <=
 _
            From c As CodonFrequency
            In Model.CodonFrequencyStatics.Values
            Select New CodonFrequencyCAI With {
                .AminoAcid = c.AminoAcid,
                .BiasFrequency = c _
                    .BiasFrequency _
                    .Select(Function(cfrq) New CodonBias(cfrq.Key, cfrq.Value)) _
                    .ToArray,
                .BiasFrequencyProfile = c _
                    .BiasFrequencyProfile _
                    .Values _
                    .ToArray
            }
        End Sub
    End Class
End Namespace