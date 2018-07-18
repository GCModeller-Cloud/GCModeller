﻿#Region "Microsoft.VisualBasic::654fc608ec0958e734726e2741104ac8, Data_science\Mathematica\Plot\test\timeRangesTest.vb"

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

    ' Module timeRangesTest
    ' 
    '     Sub: Main
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Data.ChartPlots.Statistics.TimeTrends
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Text

Module timeRangesTest

    Sub Main()
        Dim avg = DataSet.LoadDataSet("D:\GCModeller\src\runtime\sciBASIC#\Data_science\Mathematica\Plot\data\history.average.csv", encoding:=TextEncodings.UTF8)
        Dim range = DataSet.LoadDataSet("D:\GCModeller\src\runtime\sciBASIC#\Data_science\Mathematica\Plot\data\history.range.csv", encoding:=TextEncodings.UTF8).ToDictionary
        Dim data = avg _
            .Select(Function(d)
                        Dim r As DataSet = range(d.ID)

                        Return New TimePoint With {
                            .[date] = Date.Parse(d.ID),
                            .average = d!value,
                            .range = {r!min, r!max}
                        }
                    End Function) _
            .ToArray

        Call data.Plot(dateFormat:=Function(d) $"{d.Year}/{d.Month.FormatZero("00")}").Save("D:\GCModeller\src\runtime\sciBASIC#\Data_science\Mathematica\Plot\data\history.range.jpg")
    End Sub
End Module

