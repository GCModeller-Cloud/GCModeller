﻿#Region "Microsoft.VisualBasic::7fcc9d024b07357353ddd681a28a6080, Microsoft.VisualBasic.Core\ComponentModel\ValuePair\NamedTuple.vb"

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

    '     Class NamedTuple
    ' 
    '         Properties: Item1, Item2, Name
    ' 
    '         Function: AsTuple, ToString
    ' 
    '         Sub: (+3 Overloads) New
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository

Namespace ComponentModel

    Public Class NamedTuple(Of T) : Implements INamedValue

        Public Property Name As String Implements IKeyedEntity(Of String).Key
        Public Property Item1 As T
        Public Property Item2 As T

        Sub New()
        End Sub

        Sub New(item1 As T, item2 As T)
            Me.Item1 = item1
            Me.Item2 = item2
        End Sub

        Sub New(name$, item1 As T, item2 As T)
            Me.New(item1, item2)
            Me.Name = name
        End Sub

        Public Function AsTuple() As NamedValue(Of (T, T))
            Return New NamedValue(Of (T, T)) With {
                .Name = Name,
                .Value = (Item1, Item2)
            }
        End Function

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
End Namespace
