﻿#Region "Microsoft.VisualBasic::9db4496c54d7a56ac01516f0dc171af4, ..\Microsoft.VisualBasic.Architecture.Framework\Extensions\Image\Bitmap\hBitmap.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
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

Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices

Namespace Imaging

    ''' <summary>
    ''' 线程不安全的图片数据对象
    ''' </summary>
    Public Class hBitmap : Inherits Emit.Marshal.Byte
        Implements IDisposable
        Implements IEnumerable(Of Color)

        ReadOnly __source As Bitmap
        ReadOnly __handle As BitmapData

        Protected Sub New(ptr As IntPtr,
                      byts As Integer,
                      raw As Bitmap,
                      handle As BitmapData)
            Call MyBase.New(ptr, byts)

            __source = raw
            __handle = handle

            Width = raw.Width
            Height = raw.Height
            Size = New Size(Width, Height)
        End Sub

        Public ReadOnly Property Width As Integer
        Public ReadOnly Property Height As Integer
        Public ReadOnly Property Size As Size

        ''' <summary>
        ''' Gets a copy of the original raw image value that which constructed this bitmap object class
        ''' </summary>
        ''' <returns></returns>
        Public Function GetImage() As Bitmap
            Return DirectCast(__source.Clone, Bitmap)
        End Function

        ''' <summary>
        ''' 返回第一个元素的位置
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns>B, G, R</returns>
        Public Function GetIndex(x As Integer, y As Integer) As Integer
            y = y * (Width * 4)
            x = x * 4
            Return x + y
        End Function

        ''' <summary>
        ''' Gets the color of the specified pixel in this System.Drawing.Bitmap.
        ''' </summary>
        ''' <param name="x">The x-coordinate of the pixel to retrieve.</param>
        ''' <param name="y">The y-coordinate of the pixel to retrieve.</param>
        ''' <returns>A System.Drawing.Color structure that represents the color of the specified pixel.</returns>
        Public Function GetPixel(x As Integer, y As Integer) As Color
            Dim i As Integer = GetIndex(x, y)
            Dim iR As Byte = __innerRaw(i + 2)
            Dim iG As Byte = __innerRaw(i + 1)
            Dim iB As Byte = __innerRaw(i + 0)

            Return Color.FromArgb(CInt(iR), CInt(iG), CInt(iB))
        End Function

        ''' <summary>
        ''' Sets the color of the specified pixel in this System.Drawing.Bitmap.(这个函数线程不安全)
        ''' </summary>
        ''' <param name="x">The x-coordinate of the pixel to set.</param>
        ''' <param name="y">The y-coordinate of the pixel to set.</param>
        ''' <param name="color">
        ''' A System.Drawing.Color structure that represents the color to assign to the specified
        ''' pixel.</param>
        Public Sub SetPixel(x As Integer, y As Integer, color As Color)
            Dim i As Integer = GetIndex(x, y)
            __innerRaw(i + 2) = color.R
            __innerRaw(i + 1) = color.G
            __innerRaw(i + 0) = color.B
        End Sub

        ''' <summary>
        ''' 这个函数会自动复制原始图片数据里面的东西的
        ''' </summary>
        ''' <param name="res"></param>
        ''' <returns></returns>
        Public Shared Function FromImage(res As Image) As hBitmap
            Return hBitmap.FromBitmap(New Bitmap(res))
        End Function

        Public Shared Function FromBitmap(curBitmap As Bitmap) As hBitmap
            ' Lock the bitmap's bits.  
            Dim rect As New Rectangle(0, 0, curBitmap.Width, curBitmap.Height)
            Dim bmpData As BitmapData =
            curBitmap.LockBits(rect, ImageLockMode.ReadWrite, curBitmap.PixelFormat)
            ' Get the address of the first line.
            Dim ptr As IntPtr = bmpData.Scan0
            ' Declare an array to hold the bytes of the bitmap.
            Dim bytes As Integer = Math.Abs(bmpData.Stride) * curBitmap.Height

            Return New hBitmap(ptr, bytes, curBitmap, bmpData)
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            Call Write()
            Call __source.UnlockBits(__handle)
        End Sub

        Public Iterator Function GetEnumerator() As IEnumerator(Of Color) Implements IEnumerable(Of Color).GetEnumerator
            For Each x As Color In __innerRaw.Colors
                Yield x
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
    End Class
End Namespace
