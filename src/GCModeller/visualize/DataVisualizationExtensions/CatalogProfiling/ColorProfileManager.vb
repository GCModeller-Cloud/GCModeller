﻿#Region "Microsoft.VisualBasic::ad3826dd2647cf1b55b800098a75c269, visualize\DataVisualizationExtensions\CatalogProfiling\ColorProfileManager.vb"

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

    '     Module Extensions
    ' 
    '         Function: GetColors
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic
Imports Microsoft.VisualBasic.Linq

Namespace CatalogProfiling

    <HideModuleName>
    Module Extensions

        ''' <summary>
        ''' 根据用户所输入的名称字符串生成<see cref="ValueScaleColorProfile"/>或者<see cref="CategoryColorProfile"/>颜色管理器
        ''' </summary>
        ''' <param name="profile"></param>
        ''' <param name="colorSchema">
        ''' 如果需要生成<see cref="ValueScaleColorProfile"/>颜色管理器，字符串的格式应该是``scale(color_term)``
        ''' </param>
        ''' <returns></returns>
        <Extension>
        Public Function GetColors(profile As Dictionary(Of String, NamedValue(Of Double)()), colorSchema$, Optional logarithm# = 2) As ColorProfile
            Dim colors As ColorProfile

            If colorSchema.IsPattern("scale\(.+\)") Then
                colorSchema = colorSchema.GetStackValue("(", ")")
                colors = profile.Values _
                    .IteratesALL _
                    .DoCall(Function(data)
                                Return New ValueScaleColorProfile(data, colorSchema, 30, logarithm:=logarithm)
                            End Function)
            Else
                Dim category As New Dictionary(Of String, String)

                For Each profileGroup In profile
                    For Each term As NamedValue(Of Double) In profileGroup.Value
                        category(term.Name) = profileGroup.Key
                    Next
                Next

                colors = New CategoryColorProfile(category, colorSchema)
            End If

            Return colors
        End Function
    End Module
End Namespace
