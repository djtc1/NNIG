using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Chart3DLib
{
    public class ChartStyle2D
    {
        private Chart3D chart3d;
        private Rectangle chartArea;
        private Rectangle plotArea;
        private Color chartBackColor;
        private Color chartBorderColor;
        private Color plotBackColor = Color.White;
        private Color plotBorderColor = Color.Black;
 
        public ChartStyle2D(Chart3D ct3d)
        {
            chart3d = ct3d;
            chartArea = chart3d.ClientRectangle;
            plotArea = chartArea;
            chartBackColor = chart3d.BackColor;
            chartBorderColor = chart3d.BackColor;
        }

        public Color ChartBackColor
        {
            get { return chartBackColor; }
            set { chartBackColor = value; }
        }

        public Color ChartBorderColor
        {
            get { return chartBorderColor; }
            set { chartBorderColor = value; }
        }

        public Rectangle ChartArea
        {
            get { return chartArea; }
            set { chartArea = value; }
        }

        public Color PlotBackColor
        {
            get { return plotBackColor; }
            set { plotBackColor = value; }
        }

        public Color PlotBorderColor
        {
            get { return plotBorderColor; }
            set { plotBorderColor = value; }
        }

        public Rectangle PlotArea
        {
            get { return plotArea; }
            set { plotArea = value; }
        }

        public void AddChartStyle2D(Graphics g, ChartStyle cs3d, Axes ax, Grid gd, 
            ChartLabels cl)
        {
            SetPlotArea(g, cs3d, cl, ax);
            Pen aPen = new Pen(Color.Black, 1f);

            SizeF tickFontSize = g.MeasureString("A", cl.TickFont);
            // Create vertical gridlines:
            float fX, fY;
            if (gd.IsYGrid == true)
            {
                aPen = new Pen(gd.GridStyle.LineColor, 1f);
                aPen.DashStyle = gd.GridStyle.Pattern;
                for (fX = ax.XMin + ax.XTick; fX < ax.XMax; fX += ax.XTick)
                {
                    g.DrawLine(aPen, Point2D(new PointF(fX, ax.YMin), ax),
                        Point2D(new PointF(fX, ax.YMax), ax));
                }
            }

            // Create horizontal gridlines:
            if (gd.IsXGrid == true)
            {
                aPen = new Pen(gd.GridStyle.LineColor, 1f);
                aPen.DashStyle = gd.GridStyle.Pattern;
                for (fY = ax.YMin + ax.YTick; fY < ax.YMax; fY += ax.YTick)
                {
                    g.DrawLine(aPen, Point2D(new PointF(ax.XMin, fY),ax),
                        Point2D(new PointF(ax.XMax, fY),ax));
                }
            }

            // Create the x-axis tick marks:
            for (fX = ax.XMin; fX <= ax.XMax; fX += ax.XTick)
            {
                PointF yAxisPoint = Point2D(new PointF(fX, ax.YMin), ax);
                g.DrawLine(Pens.Black, yAxisPoint, new PointF(yAxisPoint.X,
                                   yAxisPoint.Y - 5f));
            }

            // Create the y-axis tick marks:
            for (fY = ax.YMin; fY <= ax.YMax; fY += ax.YTick)
            {
                PointF xAxisPoint = Point2D(new PointF(ax.XMin, fY), ax);
                g.DrawLine(Pens.Black, xAxisPoint,
                    new PointF(xAxisPoint.X + 5f, xAxisPoint.Y));
            }
            aPen.Dispose();
        }

        private void AddLabels(Graphics g, ChartStyle cs3d, ChartLabels cl, Axes ax)
        {
            float xOffset = ChartArea.Width / 30.0f;
            float yOffset = ChartArea.Height / 30.0f;
            SizeF labelFontSize = g.MeasureString("A", cl.LabelFont);
            SizeF titleFontSize = g.MeasureString("A", cl.TitleFont);
            SizeF tickFontSize = g.MeasureString("A", cl.TickFont);

            SolidBrush aBrush = new SolidBrush(cl.TickFontColor);
            StringFormat sFormat = new StringFormat();

            // Create the x-axis tick marks:
            aBrush = new SolidBrush(cl.TickFontColor);
            for (float fX = ax.XMin; fX <= ax.XMax; fX += ax.XTick)
            {
                PointF yAxisPoint = Point2D(new PointF(fX, ax.YMin), ax);
                sFormat.Alignment = StringAlignment.Far;
                SizeF sizeXTick = g.MeasureString(fX.ToString(), cl.TickFont);
                g.DrawString(fX.ToString(), cl.TickFont, aBrush,
                    new PointF(yAxisPoint.X + sizeXTick.Width / 2,
                    yAxisPoint.Y + 4f), sFormat);
            }

            // Create the y-axis tick marks:
            for (float fY = ax.YMin; fY <= ax.YMax; fY += ax.YTick)
            {
                PointF xAxisPoint = Point2D(new PointF(ax.XMin, fY), ax);
                sFormat.Alignment = StringAlignment.Far;
                g.DrawString(fY.ToString(), cl.TickFont, aBrush,
                    new PointF(xAxisPoint.X - 3f,
                    xAxisPoint.Y - tickFontSize.Height / 2), sFormat);
            }

            // Add horizontal axis label:
            aBrush = new SolidBrush(cl.LabelFontColor);
            SizeF stringSize = g.MeasureString(cl.XLabel, cl.LabelFont);
            g.DrawString(cl.XLabel, cl.LabelFont, aBrush,
                new Point(PlotArea.X + PlotArea.Width / 2 -
                (int)stringSize.Width / 2, ChartArea.Bottom -
                (int)yOffset - (int)labelFontSize.Height));

            // Add y-axis label:
            sFormat.Alignment = StringAlignment.Center;
            stringSize = g.MeasureString(cl.YLabel, cl.LabelFont);
            // Save the state of the current Graphics object
            GraphicsState gState = g.Save();
            g.TranslateTransform(xOffset, yOffset + titleFontSize.Height
                + yOffset / 3 + PlotArea.Height / 2);
            g.RotateTransform(-90);
            g.DrawString(cl.YLabel, cl.LabelFont, aBrush, 0, 0, sFormat);
            // Restore it:
            g.Restore(gState);

            // Add title:
            aBrush = new SolidBrush(cl.TitleColor);
            stringSize = g.MeasureString(cl.Title, cl.TitleFont);
            if (cl.Title.ToUpper() != "NO TITLE" && cl.Title!="")
            {
                g.DrawString(cl.Title, cl.TitleFont, aBrush,
                    new Point(PlotArea.X + PlotArea.Width / 2 -
                    (int)stringSize.Width / 2, ChartArea.Top + (int)yOffset));
            }
            aBrush.Dispose();
        }

        private void SetPlotArea(Graphics g, ChartStyle cs3d, ChartLabels cl, Axes ax)
        {
            // Draw chart area:
            SolidBrush aBrush = new SolidBrush(ChartBackColor);
            Pen aPen = new Pen(ChartBorderColor, 2);
            g.FillRectangle(aBrush, ChartArea);
            g.DrawRectangle(aPen, ChartArea);

            // Set PlotArea:
            float xOffset = ChartArea.Width / 30.0f;
            float yOffset = ChartArea.Height / 30.0f;
            SizeF labelFontSize = g.MeasureString("A", cl.LabelFont);
            SizeF titleFontSize = g.MeasureString("A", cl.TitleFont);
            if (cl.Title.ToUpper() == "NO TITLE" || cl.Title=="")
            {
                titleFontSize.Width = 8f;
                titleFontSize.Height = 8f;
            }
            float xSpacing = xOffset / 3.0f;
            float ySpacing = yOffset / 3.0f;
            SizeF tickFontSize = g.MeasureString("A", cl.TickFont);
            float tickSpacing = 2f;
            SizeF yTickSize = g.MeasureString(ax.YMin.ToString(), cl.TickFont);
            for (float yTick = ax.YMin; yTick <= ax.YMax; yTick += ax.YTick)
            {
                SizeF tempSize = g.MeasureString(yTick.ToString(), cl.TickFont);
                if (yTickSize.Width < tempSize.Width)
                {
                    yTickSize = tempSize;
                }
            }
            float leftMargin = xOffset + labelFontSize.Width +
                        xSpacing + yTickSize.Width + tickSpacing;
            float rightMargin = 2 * xOffset;
            float topMargin = yOffset + titleFontSize.Height + ySpacing;
            float bottomMargin = yOffset + labelFontSize.Height +
                        ySpacing + tickSpacing + tickFontSize.Height;

            // Define the plot area:
            int plotX = ChartArea.X + (int)leftMargin;
            int plotY = ChartArea.Y + (int)topMargin;
            int plotWidth = ChartArea.Width - (int)leftMargin - (int)rightMargin;
            int plotHeight = ChartArea.Height - (int)topMargin - (int)bottomMargin;
            plotArea.X = plotX;
            plotArea.Y = plotY;
            if (cs3d.IsColorBar)
                plotArea.Width = 25 * plotWidth / 30;
            else
                plotArea.Width = plotWidth;
            plotArea.Height = plotHeight;

            // Draw plot area:
            aBrush = new SolidBrush(PlotBackColor);
            aPen = new Pen(PlotBorderColor, 1);
            g.FillRectangle(aBrush, PlotArea);
            g.DrawRectangle(aPen, PlotArea);

            AddLabels(g, cs3d, cl, ax);
        }

        public PointF Point2D(PointF pt, Axes ax)
        {
            PointF aPoint = new PointF();
            /*if (pt.X < ax.XMin || pt.X > ax.XMax ||
                pt.Y < ax.YMin || pt.Y > ax.YMax)
            {
                pt.X = Single.NaN;
                pt.Y = Single.NaN;
            }*/
            aPoint.X = plotArea.X + (pt.X - ax.XMin) *
                plotArea.Width / (ax.XMax - ax.XMin);
            aPoint.Y = plotArea.Bottom - (pt.Y - ax.YMin) *
                plotArea.Height / (ax.YMax - ax.YMin);
            return aPoint;
        }
    }
}
