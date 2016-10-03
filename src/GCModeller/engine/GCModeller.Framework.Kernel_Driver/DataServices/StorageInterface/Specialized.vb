﻿#Region "Microsoft.VisualBasic::5a4734aef8232559d06e4f8384e2762c, ..\GCModeller\engine\GCModeller.Framework.Kernel_Driver\DataServices\StorageInterface\Specialized.vb"

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

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Data.csv.DocumentStream
Imports Microsoft.VisualBasic.Data.csv.Extensions
Imports Microsoft.VisualBasic.Scripting.MetaData

Namespace DataStorage.FileModel

    Public Class CHUNK_BUFFER_TransitionStates : Inherits DataSerials(Of Boolean)
    End Class

    Public Class CHUNK_BUFFER_EntityQuantities : Inherits DataSerials(Of Double)
    End Class

    ''' <summary>
    ''' Inherits DataSerials(Of Integer)
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CHUNK_BUFFER_StateEnumerations : Inherits DataSerials(Of Integer)
        Public Overrides Function ToString() As String
            Return Me.UniqueId & "  " & String.Join("; ", Me.Samples)
        End Function
    End Class

End Namespace
