﻿#Region "Microsoft.VisualBasic::744083e0b5227326dd960a14fe9662b7, BIOM\BIOM\v1.5.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
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



    ' /********************************************************************************/

    ' Summaries:

    '     Module CDF
    ' 
    '         Function: ReadFile
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Data.IO.netCDF
Imports Microsoft.VisualBasic.Data.IO.netCDF.Components
Imports Microsoft.VisualBasic.Scripting.Runtime

Namespace v15

    ''' <summary>
    ''' BIOM netCDF I/O
    ''' </summary>
    Public Module CDF

        Public Function ReadFile(biom As String) As v10.BIOMDataSet(Of Double)
            Using cdf As New netCDFReader(biom)
                Dim attributes = cdf.globalAttributes _
                    .ToDictionary(Function(a) a.name,
                                  Function(a As attribute)
                                      Return a.getObjectValue
                                  End Function) _
                    .AsCharacter
            End Using
        End Function
    End Module

End Namespace


