﻿#Region "Microsoft.VisualBasic::f70a35c0d656d3f22776ed4989c26ab6, Data_science\Visualization\Plots\BarPlot\Data\BarDataSample.vb"

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

    '     Class BarDataSample
    ' 
    '         Properties: data, StackedSum, Tag
    ' 
    '         Function: ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace BarPlot.Data

    ''' <summary>
    ''' Named value of double vector.
    ''' </summary>
    Public Class BarDataSample : Implements INamedValue

        ''' <summary>
        ''' 分组名称
        ''' </summary>
        ''' <returns></returns>
        Public Property Tag As String Implements INamedValue.Key
        ''' <summary>
        ''' 当前分组下的每一个序列的数据值
        ''' </summary>
        ''' <returns></returns>
        Public Property data As Double()

        ''' <summary>
        ''' The sum of <see cref="data"/>
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property StackedSum As Double
            Get
                Return data.Sum
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class
End Namespace
