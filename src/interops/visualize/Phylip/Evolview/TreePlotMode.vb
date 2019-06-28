﻿#Region "Microsoft.VisualBasic::8103f5e681ef5fa81df38380eb894ddb, Phylip\Evolview\TreePlotMode.vb"

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

    '     Enum TreePlotMode
    ' 
    '         CIRCULAR_CLADOGRAM, CIRCULAR_PHYLOGRAM, RADIAL_CLADOGRAM, RECT_CLADOGRAM, RECT_PHYLOGRAM
    '         SLANTED_CLADOGRAM_MIDDLE, SLANTED_CLADOGRAM_NORMAL, SLANTED_CLADOGRAM_RECT
    ' 
    '  
    ' 
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Namespace Evolview

    Public Enum TreePlotMode
        RECT_CLADOGRAM
        RECT_PHYLOGRAM
        SLANTED_CLADOGRAM_RECT
        SLANTED_CLADOGRAM_MIDDLE
        SLANTED_CLADOGRAM_NORMAL
        CIRCULAR_PHYLOGRAM
        CIRCULAR_CLADOGRAM
        RADIAL_CLADOGRAM
    End Enum

End Namespace
