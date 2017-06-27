﻿#Region "Microsoft.VisualBasic::7ca00a359758d1e9fe3766b1b7ba8954, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\API\is.vb"

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

Imports RDotNET.Extensions.VisualBasic.SymbolBuilder

Namespace API.is

    Public Module [is]

#Region "stats"

        ''' <summary>
        ''' as.ts and is.ts coerce an object to a time-series and test whether an object is a time series.
        ''' </summary>
        ''' <param name="x">an arbitrary R object.</param>
        ''' <returns>
        ''' ``is.ts`` tests if an object is a time series. It is generic: you can write methods to handle 
        ''' specific classes of objects, see InternalMethods.
        ''' </returns>
        Public Function ts(x As String) As Boolean
            Return $"is.ts({x})".__call.AsBoolean
        End Function
#End Region

#Region "base"

        ''' <summary>
        ''' is.vector returns TRUE if x is a vector of the specified mode having no attributes other than names. 
        ''' It returns FALSE otherwise.
        ''' </summary>
        ''' <param name="x$"></param>
        ''' <param name="mode$"></param>
        ''' <returns></returns>
        Public Function vector(x$, Optional mode$ = "any") As String
            Dim var$ = App.NextTempName

            SyncLock R
                With R
                    .call = $"{var} <- is.vector({x}, mode = {Rstring(mode)})"
                End With
            End SyncLock

            Return var
        End Function

#End Region
    End Module
End Namespace
