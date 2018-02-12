﻿#Region "Microsoft.VisualBasic::e405bac50dde3a087f4cb30b181b5f9b, mime\text%yaml\Syntax\NamedTagHandle.vb"

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

    '     Class NamedTagHandle
    ' 
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Collections.Generic
Imports System.Text

Namespace Syntax
    Public Class NamedTagHandle
        Inherits TagHandle
        Public Name As New List(Of Char)()

    End Class
End Namespace
