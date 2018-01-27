﻿#Region "Microsoft.VisualBasic::d60b5092ff24efe90ccad2304182f870, ..\sciBASIC#\gr\Microsoft.VisualBasic.Imaging\SVG\XML\Image.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
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

Imports System.Drawing
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS
Imports Microsoft.VisualBasic.Net.Http

Namespace SVG.XML

    ''' <summary>
    ''' Does SVG support embedding of bitmap images?
    ''' 
    ''' + http://stackoverflow.com/questions/6249664/does-svg-support-embedding-of-bitmap-images
    ''' </summary>
    Public Class Image : Implements CSSLayer

        <XmlAttribute> Public Property x As Single
        <XmlAttribute> Public Property y As Single
        <XmlAttribute> Public Property width As String
        <XmlAttribute> Public Property height As String

        <XmlAttribute("href", [Namespace]:=SVGWriter.Xlink)>
        Public Property data As String
        <XmlAttribute("z-index")>
        Public Property zIndex As Integer Implements CSSLayer.zIndex

        ''' <summary>
        ''' ``data:image/png;base64,...``
        ''' </summary>
        Const base64Header As String = "data:image/png;base64,"

        Public Function GetGDIObject() As Bitmap
            Return Base64Codec.GetImage(Mid(data, base64Header.Length + 1))
        End Function

        Sub New()
        End Sub

        Sub New(image As Bitmap, Optional size As Size = Nothing)
            Call Me.New(image, New SizeF(size.Width, size.Height))
        End Sub

        Sub New(image As Drawing.Image, Optional size As SizeF = Nothing)
            data = base64Header & image.ToBase64String
            If size.IsEmpty Then
                size = image.Size
            End If
            width = size.Width
            height = size.Height
        End Sub

        Sub New(url As String, Optional size As Size = Nothing)
            Call Me.New(MapNetFile(url).LoadImage, size)
        End Sub

        Public Overrides Function ToString() As String
            Return $"<image x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" xlink:href=""{data}"">"
        End Function

        Public Function SaveAs(fileName As String, Optional format As ImageFormats = ImageFormats.Png) As Boolean
            Return GetGDIObject.SaveAs(fileName, format)
        End Function

        Public Shared Operator +(img As Image, offset As PointF) As Image
            img = DirectCast(img.MemberwiseClone, Image)
            img.x += offset.X
            img.y += offset.Y
            Return img
        End Operator
    End Class
End Namespace
