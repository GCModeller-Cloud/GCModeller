﻿Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D.g
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Vector.Shapes
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS

Public Module Pyramid

    Public Function Plot(data As IEnumerable(Of PercentageData),
                         Optional size As Size = Nothing,
                         Optional margin As Size = Nothing,
                         Optional bg$ = "white",
                         Optional legendBorder As Border = Nothing,
                         Optional wp# = 0.6) As Bitmap

        Dim array As PercentageData() =
            data _
            .OrderByDescending(Function(x) x.Percentage) _
            .ToArray

        Return GraphicsPlots(size, margin, bg,
                Sub(ByRef g, region)
                    Dim height% = region.PlotRegion.Height
                    Dim width% = region.PlotRegion.Width * wp
                    Dim left! = (region.PlotRegion.Width - width) / 2 + margin.Width
                    Dim tan_ab = height / (width / 2) ' tan(a)
                    Dim right! = (left + width)
                    Dim bottom! = region.PlotRegion.Bottom

                    For Each l As PercentageData In array
                        Dim dh! = height * l.Percentage
                        Dim dw! = dh / tan_ab
                        ' b/| dh |\c
                        ' ---    ---
                        ' a        d
                        Dim a As New Point(left, bottom)
                        Dim b As New Point(left + dw, a.Y - dh)
                        Dim c As New Point(right - dw, b.Y)
                        Dim d As New Point(right, a.Y)

                        Dim path As New GraphicsPath
                        path.AddLine(a, b)
                        path.AddLine(b, c)
                        path.AddLine(c, d)
                        path.AddLine(d, a)
                        path.CloseAllFigures()

                        Call g.FillPath(New SolidBrush(l.Color), path)

                        left += dw
                        bottom -= dh
                        width -= dw * 2
                        right -= dw
                    Next

                    Dim font As New Font(FontFace.MicrosoftYaHei, 20)
                    Dim gr As Graphics = g
                    Dim maxL = data.Select(Function(x) gr.MeasureString(x.Name, font).Width).Max
                    left = size.Width - (margin.Width * 2) - maxL
                    Dim top = margin.Height
                    Dim legends As New List(Of Legend)

                    For Each x As PercentageData In data
                        legends += New Legend With {
                           .color = x.Color.RGBExpression,
                           .style = LegendStyles.Rectangle,
                           .title = x.Name,
                           .fontstyle = CSSFont.GetFontStyle(font.Name, font.Style, font.Size)
                        }
                    Next

                    Call g.DrawLegends(New Point(left, top), legends, ,, legendBorder)
                End Sub)
    End Function
End Module
