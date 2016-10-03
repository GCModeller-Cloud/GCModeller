﻿#Region "Microsoft.VisualBasic::ad2f6099f8a464704c9015978f334421, ..\R.Bioconductor\RDotNET\R.NET\Diagnostics\DataFrameColumnDisplay.vb"

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

Imports System.Diagnostics
Imports System.Linq

Imports RDotNET.SymbolicExpressionExtension
Imports RDotNET.REngineExtension

Namespace Diagnostics
	<DebuggerDisplay("{Display,nq}")> _
	Friend Class DataFrameColumnDisplay
		<DebuggerBrowsable(DebuggerBrowsableState.Never)> _
		Private ReadOnly data As DataFrame

		<DebuggerBrowsable(DebuggerBrowsableState.Never)> _
		Private ReadOnly columnIndex As Integer

		Public Sub New(data As DataFrame, columnIndex As Integer)
			Me.data = data
			Me.columnIndex = columnIndex
		End Sub

		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden)> _
		Public ReadOnly Property Value() As Object()
			Get
				Dim column = Me.data(Me.columnIndex)
				Return If(column.IsFactor(), column.AsFactor().GetFactors(), column.ToArray())
			End Get
		End Property

		<DebuggerBrowsable(DebuggerBrowsableState.Never)> _
		Public ReadOnly Property Display() As String
			Get
				Dim column = Me.data(Me.columnIndex)
				Dim names = Me.data.ColumnNames
				If names Is Nothing OrElse names(Me.columnIndex) Is Nothing Then
					Return [String].Format("NA ({0})", column.Type)
				Else
					Return [String].Format("""{0}"" ({1})", names(Me.columnIndex), column.Type)
				End If
			End Get
		End Property
	End Class
End Namespace
