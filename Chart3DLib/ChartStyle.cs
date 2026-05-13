using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Chart3DLib
{
    public class ChartStyle
    {
        private Chart3D chart3d;
        private bool isColorBar = false;

        public ChartStyle(Chart3D ct3d)
        {
            chart3d = ct3d;
        }

        public bool IsColorBar
        {
            get { return isColorBar; }
            set { isColorBar = value; }
        }

        private Point3[] CoordinatesOfChartBox(Axes ax, ViewAngle va)
        {
            // Create coordinate of the axes:
            Point3[] pta = new Point3[8];
            pta[0] = new Point3(ax.XMax, ax.YMin, ax.ZMin, 1);
            pta[1] = new Point3(ax.XMin, ax.YMin, ax.ZMin, 1);
            pta[2] = new Point3(ax.XMin, ax.YMax, ax.ZMin, 1);
            pta[3] = new Point3(ax.XMin, ax.YMax, ax.ZMax, 1);
            pta[4] = new Point3(ax.XMin, ax.YMin, ax.ZMax, 1);
            pta[5] = new Point3(ax.XMax, ax.YMin, ax.ZMax, 1);
            pta[6] = new Point3(ax.XMax, ax.YMax, ax.ZMax, 1);
            pta[7] = new Point3(ax.XMax, ax.YMax, ax.ZMin, 1);

            Point3[] pts = new Point3[4];
            int[] npts = new int[4] { 0, 1, 2, 3 };
            if (va.Elevation >= 0)
            {
                if (va.Azimuth >= -180 && va.Azimuth < -90)
                {
                    npts = new int[4] { 1, 2, 7, 6 };
                }
                else if (va.Azimuth >= -90 && va.Azimuth < 0)
                {
                    npts = new int[4] { 0, 1, 2, 3 };
                }
                else if (va.Azimuth >= 0 && va.Azimuth < 90)
                {
                    npts = new int[4] { 7, 0, 1, 4 };
                }
                else if (va.Azimuth >= 90 && va.Azimuth <= 180)
                {
                    npts = new int[4] { 2, 7, 0, 5 };
                }
            }
            else if (va.Elevation < 0)
            {
                if (va.Azimuth >= -180 && va.Azimuth < -90)
                {
                    npts = new int[4] { 1, 0, 7, 6 };
                }
                else if (va.Azimuth >= -90 && va.Azimuth < 0)
                {
                    npts = new int[4] { 0, 7, 2, 3 };
                }
                else if (va.Azimuth >= 0 && va.Azimuth < 90)
                {
                    npts = new int[4] { 7, 2, 1, 4 };
                }
                else if (va.Azimuth >= 90 && va.Azimuth <= 180)
                {
                    npts = new int[4] { 2, 1, 0, 5 };
                }

            }

            for (int i = 0; i < 4; i++)
            {
                pts[i] = pta[npts[i]];
            }
            return pts;
        }

        public void AddChartStyle(Graphics g, Axes ax, ViewAngle va, Grid gd, ChartLabels cl)
        {
            AddTicks(g, ax, va, cl);
            AddGrids(g, ax, va, gd, cl);
            AddAxes(g, ax, va, cl);
            AddLabels(g, ax, va, cl);
        }

        private void AddAxes(Graphics g, Axes ax, ViewAngle va, ChartLabels cl)
        {
            Matrix3 m = Matrix3.AzimuthElevation(va.Elevation, va.Azimuth);
            Point3[] pts = CoordinatesOfChartBox(ax, va);
            Pen aPen = new Pen(ax.AxisStyle.LineColor, ax.AxisStyle.Thickness);
            aPen.DashStyle = ax.AxisStyle.Pattern;
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Transform(m, chart3d, ax, this, cl);
            }
            g.DrawLine(aPen, pts[0].X, pts[0].Y, pts[1].X, pts[1].Y);
            g.DrawLine(aPen, pts[1].X, pts[1].Y, pts[2].X, pts[2].Y);
            g.DrawLine(aPen, pts[2].X, pts[2].Y, pts[3].X, pts[3].Y);
            aPen.Dispose();
        }

        private void AddTicks(Graphics g, Axes ax, ViewAngle va, ChartLabels cl)
        {
            Matrix3 m = Matrix3.AzimuthElevation(va.Elevation, va.Azimuth);
            Point3[] pta = new Point3[2];
            Point3[] pts = CoordinatesOfChartBox(ax, va); ;
            Pen aPen = new Pen(ax.AxisStyle.LineColor, ax.AxisStyle.Thickness);
            aPen.DashStyle = ax.AxisStyle.Pattern;

            // Add x ticks:
            float offset = (ax.YMax - ax.YMin) / 30.0f;
            float ticklength = offset;
            for (float x = ax.XMin; x <= ax.XMax; x = x + ax.XTick)
            {
                if (va.Elevation >= 0)
                {
                    if (va.Azimuth >= -90 && va.Azimuth < 90)
                        ticklength = -offset;
                }
                else if (va.Elevation < 0)
                {
                    if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                        va.Azimuth >= 90 && va.Azimuth <= 180)
                        ticklength = -(ax.YMax - ax.YMin) / 30;
                }
                pta[0] = new Point3(x, pts[1].Y + ticklength, pts[1].Z, pts[1].W);
                pta[1] = new Point3(x, pts[1].Y, pts[1].Z, pts[1].W);
                for (int i = 0; i < pta.Length; i++)
                {
                    pta[i].Transform(m, chart3d, ax, this, cl);
                }
                g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
            }

            // Add y ticks:
            offset = (ax.XMax - ax.XMin) / 30.0f;
            ticklength = offset;
            for (float y = ax.YMin; y <= ax.YMax; y = y + ax.YTick)
            {
                pts = CoordinatesOfChartBox(ax, va); ;
                if (va.Elevation >= 0)
                {
                    if (va.Azimuth >= -180 && va.Azimuth < 0)
                        ticklength = -offset;
                }
                else if (va.Elevation < 0)
                {
                    if (va.Azimuth >= 0 && va.Azimuth < 180)
                        ticklength = -offset;
                }
                pta[0] = new Point3(pts[1].X + ticklength, y, pts[1].Z, pts[1].W);
                pta[1] = new Point3(pts[1].X, y, pts[1].Z, pts[1].W);
                for (int i = 0; i < pta.Length; i++)
                {
                    pta[i].Transform(m, chart3d, ax, this, cl);
                }
                g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
            }

            float xoffset = (ax.XMax - ax.XMin) / 45.0f;
            float yoffset = (ax.YMax - ax.YMin) / 20.0f;
            float xticklength = xoffset;
            float yticklength = yoffset;
            for (float z = ax.ZMin; z <= ax.ZMax; z = z + ax.ZTick)
            {
                if (va.Elevation >= 0)
                {
                    if (va.Azimuth >= -180 && va.Azimuth < -90)
                    {
                        xticklength = 0;
                        yticklength = yoffset;
                    }
                    else if (va.Azimuth >= -90 && va.Azimuth < 0)
                    {
                        xticklength = xoffset;
                        yticklength = 0;
                    }
                    else if (va.Azimuth >= 0 && va.Azimuth < 90)
                    {
                        xticklength = 0;
                        yticklength = -yoffset;
                    }
                    else if (va.Azimuth >= 90 && va.Azimuth <= 180)
                    {
                        xticklength = -xoffset;
                        yticklength = 0;
                    }
                }
                else if (va.Elevation < 0)
                {
                    if (va.Azimuth >= -180 && va.Azimuth < -90)
                    {
                        yticklength = 0;
                        xticklength = xoffset;
                    }
                    else if (va.Azimuth >= -90 && va.Azimuth < 0)
                    {
                        yticklength = -yoffset;
                        xticklength = 0;
                    }
                    else if (va.Azimuth >= 0 && va.Azimuth < 90)
                    {
                        yticklength = 0;
                        xticklength = -xoffset;
                    }
                    else if (va.Azimuth >= 90 && va.Azimuth <= 180)
                    {
                        yticklength = yoffset;
                        xticklength = 0;
                    }
                }
                pta[0] = new Point3(pts[2].X, pts[2].Y, z, pts[2].W);
                pta[1] = new Point3(pts[2].X + yticklength,
                    pts[2].Y + xticklength, z, pts[2].W);
                for (int i = 0; i < pta.Length; i++)
                {
                    pta[i].Transform(m, chart3d, ax, this, cl);
                }
                g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
            }
            aPen.Dispose();
        }

        private void AddGrids(Graphics g, Axes ax, ViewAngle va, Grid gd, ChartLabels cl)
        {
            Matrix3 m = Matrix3.AzimuthElevation(va.Elevation, va.Azimuth);
            Point3[] pta = new Point3[3];
            Point3[] pts = CoordinatesOfChartBox(ax, va);
            Pen aPen = new Pen(gd.GridStyle.LineColor, gd.GridStyle.Thickness);
            aPen.DashStyle = gd.GridStyle.Pattern;

            // Draw x gridlines:
            if (gd.IsXGrid)
            {
                for (float x = ax.XMin; x <= ax.XMax; x = x + ax.XTick)
                {
                    pts = CoordinatesOfChartBox(ax, va);
                    pta[0] = new Point3(x, pts[1].Y, pts[1].Z, pts[1].W);
                    if (va.Elevation >= 0)
                    {
                        if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                            (va.Azimuth >= 0 && va.Azimuth < 90))
                        {
                            pta[1] = new Point3(x, pts[0].Y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(x, pts[0].Y, pts[3].Z, pts[1].W);
                        }
                        else
                        {
                            pta[1] = new Point3(x, pts[2].Y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(x, pts[2].Y, pts[3].Z, pts[1].W);

                        }
                    }
                    else if (va.Elevation < 0)
                    {
                        if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                            (va.Azimuth >= 0 && va.Azimuth < 90))
                        {
                            pta[1] = new Point3(x, pts[2].Y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(x, pts[2].Y, pts[3].Z, pts[1].W);

                        }
                        else
                        {
                            pta[1] = new Point3(x, pts[0].Y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(x, pts[0].Y, pts[3].Z, pts[1].W);
                        }
                    }
                    for (int i = 0; i < pta.Length; i++)
                    {
                        pta[i].Transform(m, chart3d, ax, this, cl);
                    }
                    g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                    g.DrawLine(aPen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                }
            }
            // Draw y gridlines:
            if (gd.IsYGrid)
            {
                for (float y = ax.YMin; y <= ax.YMax; y = y + ax.YTick)
                {
                    pts = CoordinatesOfChartBox(ax, va);
                    pta[0] = new Point3(pts[1].X, y, pts[1].Z, pts[1].W);
                    if (va.Elevation >= 0)
                    {
                        if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                            (va.Azimuth >= 0 && va.Azimuth < 90))
                        {
                            pta[1] = new Point3(pts[2].X, y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(pts[2].X, y, pts[3].Z, pts[1].W);
                        }
                        else
                        {
                            pta[1] = new Point3(pts[0].X, y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(pts[0].X, y, pts[3].Z, pts[1].W);
                        }
                    }
                    if (va.Elevation < 0)
                    {
                        if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                            (va.Azimuth >= 0 && va.Azimuth < 90))
                        {
                            pta[1] = new Point3(pts[0].X, y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(pts[0].X, y, pts[3].Z, pts[1].W);

                        }
                        else
                        {
                            pta[1] = new Point3(pts[2].X, y, pts[1].Z, pts[1].W);
                            pta[2] = new Point3(pts[2].X, y, pts[3].Z, pts[1].W);
                        }
                    }
                    for (int i = 0; i < pta.Length; i++)
                    {
                        pta[i].Transform(m, chart3d, ax, this, cl);
                    }
                    g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                    g.DrawLine(aPen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                }
            }

            // Draw Z gridlines:
            if (gd.IsZGrid)
            {
                for (float z = ax.ZMin; z <= ax.ZMax; z = z + ax.ZTick)
                {
                    pts = CoordinatesOfChartBox(ax, va);
                    pta[0] = new Point3(pts[2].X, pts[2].Y, z, pts[2].W);
                    if (va.Elevation >= 0)
                    {
                        if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                            (va.Azimuth >= 0 && va.Azimuth < 90))
                        {
                            pta[1] = new Point3(pts[2].X, pts[0].Y, z, pts[1].W);
                            pta[2] = new Point3(pts[0].X, pts[0].Y, z, pts[1].W);
                        }
                        else
                        {
                            pta[1] = new Point3(pts[0].X, pts[2].Y, z, pts[1].W);
                            pta[2] = new Point3(pts[0].X, pts[1].Y, z, pts[1].W);
                        }
                    }
                    if (va.Elevation < 0)
                    {
                        if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                            (va.Azimuth >= 0 && va.Azimuth < 90))
                        {
                            pta[1] = new Point3(pts[0].X, pts[2].Y, z, pts[1].W);
                            pta[2] = new Point3(pts[0].X, pts[0].Y, z, pts[1].W);

                        }
                        else
                        {
                            pta[1] = new Point3(pts[2].X, pts[0].Y, z, pts[1].W);
                            pta[2] = new Point3(pts[0].X, pts[0].Y, z, pts[1].W);
                        }
                    }
                    for (int i = 0; i < pta.Length; i++)
                    {
                        pta[i].Transform(m, chart3d, ax, this, cl);
                    }
                    g.DrawLine(aPen, pta[0].X, pta[0].Y, pta[1].X, pta[1].Y);
                    g.DrawLine(aPen, pta[1].X, pta[1].Y, pta[2].X, pta[2].Y);
                }
            }

        }

        private void AddLabels(Graphics g, Axes ax, ViewAngle va, ChartLabels cl)
        {
            Matrix3 m = Matrix3.AzimuthElevation(va.Elevation, va.Azimuth);
            Point3 pt = new Point3();
            Point3[] pts = CoordinatesOfChartBox(ax, va);
            SolidBrush aBrush = new SolidBrush(cl.LabelFontColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            // Add x tick labels:
            float offset = (ax.YMax - ax.YMin) / 20;
            float labelSpace = offset;
            for (float x = ax.XMin + ax.XTick; x < ax.XMax; x = x + ax.XTick)
            {
                if (va.Elevation >= 0)
                {
                    if (va.Azimuth >= -90 && va.Azimuth < 90)
                        labelSpace = -offset;
                }
                else if (va.Elevation < 0)
                {
                    if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                        va.Azimuth >= 90 && va.Azimuth <= 180)
                        labelSpace = -offset;
                }
                pt = new Point3(x, pts[1].Y + labelSpace, pts[1].Z, pts[1].W);
                pt.Transform(m, chart3d, ax, this, cl);
                g.DrawString(x.ToString(), cl.TickFont, aBrush,
                    new PointF(pt.X, pt.Y), sf);
            }

            // Add y tick labels:
            offset = (ax.XMax - ax.XMin) / 20;
            labelSpace = offset;
            for (float y = ax.YMin + ax.YTick; y < ax.YMax; y = y + ax.YTick)
            {
                pts = CoordinatesOfChartBox(ax, va);
                if (va.Elevation >= 0)
                {
                    if (va.Azimuth >= -180 && va.Azimuth < 0)
                        labelSpace = -offset;
                }
                else if (va.Elevation < 0)
                {
                    if (va.Azimuth >= 0 && va.Azimuth < 180)
                        labelSpace = -offset;
                }
                pt = new Point3(pts[1].X + labelSpace, y, pts[1].Z, pts[1].W);
                pt.Transform(m, chart3d, ax, this, cl);
                g.DrawString(y.ToString(), cl.TickFont, aBrush,
                    new PointF(pt.X, pt.Y), sf);

            }

            // Add z tick labels:
            float xoffset = (ax.XMax - ax.XMin) / 30.0f;
            float yoffset = (ax.YMax - ax.YMin) / 15.0f;
            float xlabelSpace = xoffset;
            float ylabelSpace = yoffset;
            SizeF s = g.MeasureString("A", cl.TickFont);
            for (float z = ax.ZMin; z <= ax.ZMax; z = z + ax.ZTick)
            {
                sf.Alignment = StringAlignment.Far;
                pts = CoordinatesOfChartBox(ax, va);
                if (va.Elevation >= 0)
                {
                    if (va.Azimuth >= -180 && va.Azimuth < -90)
                    {
                        xlabelSpace = 0;
                        ylabelSpace = yoffset;
                    }
                    else if (va.Azimuth >= -90 && va.Azimuth < 0)
                    {
                        xlabelSpace = xoffset;
                        ylabelSpace = 0;
                    }
                    else if (va.Azimuth >= 0 && va.Azimuth < 90)
                    {
                        xlabelSpace = 0;
                        ylabelSpace = -yoffset;
                    }
                    else if (va.Azimuth >= 90 && va.Azimuth <= 180)
                    {
                        xlabelSpace = -xoffset;
                        ylabelSpace = 0;
                    }
                }
                else if (va.Elevation < 0)
                {
                    if (va.Azimuth >= -180 && va.Azimuth < -90)
                    {
                        ylabelSpace = 0;
                        xlabelSpace = xoffset;
                    }
                    else if (va.Azimuth >= -90 && va.Azimuth < 0)
                    {
                        ylabelSpace = -yoffset;
                        xlabelSpace = 0;
                    }
                    else if (va.Azimuth >= 0 && va.Azimuth < 90)
                    {
                        ylabelSpace = 0;
                        xlabelSpace = -xoffset;
                    }
                    else if (va.Azimuth >= 90 && va.Azimuth <= 180)
                    {
                        ylabelSpace = yoffset;
                        xlabelSpace = 0;
                    }
                }

                pt = new Point3(pts[2].X + ylabelSpace,
                    pts[2].Y + xlabelSpace, z, pts[2].W);
                pt.Transform(m, chart3d, ax, this, cl);
                g.DrawString(z.ToString(), cl.TickFont, aBrush,
                    new PointF(pt.X - labelSpace, pt.Y - s.Height / 2), sf);
            }

            // Add Title:
            sf.Alignment = StringAlignment.Center;
            aBrush = new SolidBrush(cl.TitleColor);
            if (cl.Title != "No Title" && cl.Title != "")
            {
                g.DrawString(cl.Title, cl.TitleFont, aBrush,
                    new PointF(chart3d.Width / 2, chart3d.Height / 30), sf);
            }
            aBrush.Dispose();

            // Add x axis label:
            offset = (ax.YMax - ax.YMin) / 3;
            labelSpace = offset;
            sf.Alignment = StringAlignment.Center;
            aBrush = new SolidBrush(cl.LabelFontColor);
            float offset1 = (ax.XMax - ax.XMin) / 10;
            float xc = offset1;
            if (va.Elevation >= 0)
            {
                if (va.Azimuth >= -90 && va.Azimuth < 90)
                    labelSpace = -offset;
                if (va.Azimuth >= 0 && va.Azimuth <= 180)
                    xc = -offset1;
            }
            else if (va.Elevation < 0)
            {
                if ((va.Azimuth >= -180 && va.Azimuth < -90) ||
                    va.Azimuth >= 90 && va.Azimuth <= 180)
                    labelSpace = -offset;
                if (va.Azimuth >= -180 && va.Azimuth <= 0)
                    xc = -offset1;
            }
            Point3[] pta = new Point3[2];
            pta[0] = new Point3(ax.XMin, pts[1].Y + labelSpace, pts[1].Z, pts[1].W);
            pta[1] = new Point3((ax.XMin + ax.XMax) / 2 - xc, pts[1].Y + labelSpace,
                pts[1].Z, pts[1].W);
            pta[0].Transform(m, chart3d, ax, this, cl);
            pta[1].Transform(m, chart3d, ax, this, cl);
            float theta = (float)Math.Atan((pta[1].Y - pta[0].Y) / (pta[1].X - pta[0].X));
            theta = theta * 180 / (float)Math.PI;
            GraphicsState gs = g.Save();
            g.TranslateTransform(pta[1].X, pta[1].Y);
            g.RotateTransform(theta);
            g.DrawString(cl.XLabel, cl.LabelFont, aBrush,
                new PointF(0, 0), sf);
            g.Restore(gs);

            // Add y axis label:
            offset = (ax.XMax - ax.XMin) / 3;
            offset1 = (ax.YMax - ax.YMin) / 5;
            labelSpace = offset;
            float yc = ax.YTick;
            if (va.Elevation >= 0)
            {
                if (va.Azimuth >= -180 && va.Azimuth < 0)
                    labelSpace = -offset;
                if (va.Azimuth >= -90 && va.Azimuth <= 90)
                    yc = -offset1;
            }
            else if (va.Elevation < 0)
            {
                yc = -offset1;
                if (va.Azimuth >= 0 && va.Azimuth < 180)
                    labelSpace = -offset;
                if (va.Azimuth >= -90 && va.Azimuth <= 90)
                    yc = offset1;
            }
            pta[0] = new Point3(pts[1].X + labelSpace, ax.YMin, pts[1].Z, pts[1].W);
            pta[1] = new Point3(pts[1].X + labelSpace, (ax.YMin + 
                ax.YMax) / 2 + yc, pts[1].Z, pts[1].W);
            pta[0].Transform(m, chart3d, ax, this, cl);
            pta[1].Transform(m, chart3d, ax, this, cl);
            theta = (float)Math.Atan((pta[1].Y - pta[0].Y) / (pta[1].X - pta[0].X));
            theta = theta * 180 / (float)Math.PI;
            gs = g.Save();
            g.TranslateTransform(pta[1].X, pta[1].Y);
            g.RotateTransform(theta);
            try
            {
                g.DrawString(cl.YLabel, cl.LabelFont, aBrush,
                    new PointF(0, 0), sf);
            }
            catch (Exception ee)
            {

            }
            g.Restore(gs);

            // Add z axis labels:
            float zticklength = 10;
            labelSpace = -1.3f * offset;
            offset1 = (ax.ZMax - ax.ZMin) / 8;
            float zc = -offset1;
            for (float z = ax.ZMin; z < ax.ZMax; z = z + ax.ZTick)
            {
                SizeF size = g.MeasureString(z.ToString(), cl.TickFont);
                if (zticklength < size.Width)
                    zticklength = size.Width;
            }
            float zlength = -zticklength;
            if (va.Elevation >= 0)
            {
                if (va.Azimuth >= -180 && va.Azimuth < -90)
                {
                    zlength = -zticklength;
                    labelSpace = -1.3f * offset;
                    zc = -offset1;
                }
                else if (va.Azimuth >= -90 && va.Azimuth < 0)
                {
                    zlength = zticklength;
                    labelSpace = 2 * offset / 3;
                    zc = offset1;
                }
                else if (va.Azimuth >= 0 && va.Azimuth < 90)
                {
                    zlength = zticklength;
                    labelSpace = 2 * offset / 3;
                    zc = -offset1;
                }
                else if (va.Azimuth >= 90 && va.Azimuth <= 180)
                {
                    zlength = -zticklength;
                    labelSpace = -1.3f * offset;
                    zc = offset1;
                }
            }
            else if (va.Elevation < 0)
            {
                if (va.Azimuth >= -180 && va.Azimuth < -90)
                {
                    zlength = -zticklength;
                    labelSpace = -1.3f * offset;
                    zc = offset1;
                }
                else if (va.Azimuth >= -90 && va.Azimuth < 0)
                {
                    zlength = zticklength;
                    labelSpace = 2 * offset / 3;
                    zc = -offset1;
                }
                else if (va.Azimuth >= 0 && va.Azimuth < 90)
                {
                    zlength = zticklength;
                    labelSpace = 2 * offset / 3;
                    zc = offset1;
                }
                else if (va.Azimuth >= 90 && va.Azimuth <= 180)
                {
                    zlength = -zticklength;
                    labelSpace = -1.3f * offset;
                    zc = -offset1;
                }
            }
            pta[0] = new Point3(pts[2].X - labelSpace, pts[2].Y,
                (ax.ZMin + ax.ZMax) / 2 + zc, pts[2].W);
            pta[0].Transform(m, chart3d, ax, this, cl);
            gs = g.Save();
            g.TranslateTransform(pta[0].X - zlength, pta[0].Y);
            g.RotateTransform(270);
            g.DrawString(cl.ZLabel, cl.LabelFont, aBrush,
                new PointF(0, 0), sf);
            g.Restore(gs);
        }
    }

    [TypeConverter(typeof(AxesConverter))]
    public class Axes
    {
        LineStyle axisStyle;
        private float xMax = 5f;
        private float xMin = -5f;
        private float yMax = 3f;
        private float yMin = -3f;
        private float zMax = 6f;
        private float zMin = -6f;
        private float xTick = 1f;
        private float yTick = 1f;
        private float zTick = 3f;
        private Chart3D chart3d;

        public Axes(Chart3D ct3d)
        {
            chart3d = ct3d;
            axisStyle = new LineStyle();
        }


        [Description("Sets line style for the axes."),
        Category("Appearance")]
        public LineStyle AxisStyle
        {
            get { return axisStyle; }
            set
            {
                axisStyle = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the minimum limit for the X axis."),
        Category("Appearance")]
        public float XMin
        {
            get { return xMin; }
            set
            {
                xMin = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the maximum limit for the X axis."),
        Category("Appearance")]
        public float XMax
        {
            get { return xMax; }
            set
            {
                xMax = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the ticks for the X axis."),
        Category("Appearance")]
        public float XTick
        {
            get { return xTick; }
            set
            {
                xTick = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the minimum limit for the Y axis."),
        Category("Appearance")]
        public float YMin
        {
            get { return yMin; }
            set
            {
                yMin = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the maximum limit for the Y axis."),
        Category("Appearance")]
        public float YMax
        {
            get { return yMax; }
            set
            {
                yMax = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the ticks for the Y axis."),
        Category("Appearance")]
        public float YTick
        {
            get { return yTick; }
            set
            {
                yTick = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the minimum limit for the Z axis."),
        Category("Appearance")]
        public float ZMin
        {
            get { return zMin; }
            set
            {
                zMin = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the maximum limit for the Z axis."),
        Category("Appearance")]
        public float ZMax
        {
            get { return zMax; }
            set
            {
                zMax = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the ticks for the Z axis."),
        Category("Appearance")]
        public float ZTick
        {
            get { return zTick; }
            set
            {
                zTick = value;
                chart3d.Invalidate();
            }
        }
    }

    public class AxesConverter : TypeConverter
    {
        // Display the “+” symbol near the property name
        public override bool GetPropertiesSupported(
            ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection
            GetProperties(ITypeDescriptorContext context,
            object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(Axes));
        }
    }

    [TypeConverter(typeof(ChartLabelsConverter))]
    public class ChartLabels
    {
        private string xLabel = "X Axis";
        private string yLabel = "Y Axis";
        private string zLabel = "Z Axis";
        private Font labelFont = new Font("Arial", 10, FontStyle.Regular);
        private Color labelFontColor = Color.Black;
        private Font tickFont;
        private Color tickFontColor = Color.Black;
        private string title = "My 3D Chart";
        private Font titleFont = new Font("Arial Narrow", 14, FontStyle.Regular);
        private Color titleColor = Color.Black;
        private Chart3D chart3d;

        public ChartLabels(Chart3D ct3d)
        {
            chart3d = ct3d;
            tickFont = ct3d.Font;
        }

        [Description("Creates a label for the X axis."),
        Category("Appearance")]
        public string XLabel
        {
            get { return xLabel; }
            set
            {
                xLabel = value;
                chart3d.Invalidate();
            }
        }

        [Description("Creates a label for the Y axis."),
        Category("Appearance")]
        public string YLabel
        {
            get { return yLabel; }
            set
            {
                yLabel = value;
                chart3d.Invalidate();
            }
        }


        [Description("Creates a label for the Z axis."),
        Category("Appearance")]
        public string ZLabel
        {
            get { return zLabel; }
            set
            {
                zLabel = value;
                chart3d.Invalidate();
            }
        }

        [Description("The font used to display the axis labels."),
        Category("Appearance")]
        public Font LabelFont
        {
            get { return labelFont; }
            set
            {
                labelFont = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the color of the axis labels."),
        Category("Appearance")]
        public Color LabelFontColor
        {
            get { return labelFontColor; }
            set
            {
                labelFontColor = value;
                chart3d.Invalidate();
            }
        }

        [Description("The font used to display the tick labels."),
        Category("Appearance")]
        public Font TickFont
        {
            get { return tickFont; }
            set
            {
                tickFont = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the color of the tick labels."),
        Category("Appearance")]
        public Color TickFontColor
        {
            get { return tickFontColor; }
            set
            {
                tickFontColor = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets title for the chart."),
        Category("Appearance")]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                chart3d.Invalidate();
            }
        }

        [Description("The font used to display the title."),
        Category("Appearance")]
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                titleFont = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the color of the title."),
        Category("Appearance")]
        public Color TitleColor
        {
            get { return titleColor; }
            set
            {
                titleColor = value;
                chart3d.Invalidate();
            }
        }
    }

    public class ChartLabelsConverter : TypeConverter
    {
        public override bool GetPropertiesSupported(
            ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection
            GetProperties(ITypeDescriptorContext context,
            object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(ChartLabels));
        }
    }

    [TypeConverter(typeof(GridConverter))]
    public class Grid
    {
        LineStyle gridStyle;
        private bool isXGrid = true;
        private bool isYGrid = true;
        private bool isZGrid = true;
        private Chart3D chart3d;

        public Grid(Chart3D ct3d)
        {
            chart3d = ct3d;
            gridStyle = new LineStyle();
        }

        [Description("Indicates whether the X grid is shown."),
        Category("Appearance")]
        public bool IsXGrid
        {
            get { return isXGrid; }
            set
            {
                isXGrid = value;
                chart3d.Invalidate();
            }
        }

        [Description("Indicates whether the Y grid is shown."),
        Category("Appearance")]
        public bool IsYGrid
        {
            get { return isYGrid; }
            set
            {
                isYGrid = value;
                chart3d.Invalidate();
            }
        }

        [Description("Indicates whether the Z grid is shown."),
               Category("Appearance")]
        public bool IsZGrid
        {
            get { return isZGrid; }
            set
            {
                isZGrid = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the line pattern for the grid line style."),
        Category("Appearance")]
        public LineStyle GridStyle
        {
            get { return gridStyle; }
            set
            {
                gridStyle = value;
                chart3d.Invalidate();
            }
        }
    }

    public class GridConverter : TypeConverter
    {
        public override bool GetPropertiesSupported(
            ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection
            GetProperties(ITypeDescriptorContext context,
            object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(Grid));
        }
    }

    [TypeConverter(typeof(ViewAngleConverter))]
    public class ViewAngle
    {
        private float elevation = 30;
        private float azimuth = -37.5f;
        private Chart3D chart3d;

        public ViewAngle(Chart3D ct3d)
        {
            chart3d = ct3d;
        }

        [Description("Sets the elevation angle."),
        Category("Appearance")]
        public float Elevation
        {
            get { return elevation; }
            set
            {
                elevation = value;
                chart3d.Invalidate();
            }
        }

        [Description("Sets the azimuth angle."),
        Category("Appearance")]
        public float Azimuth
        {
            get { return azimuth; }
            set
            {
                azimuth = value;
                chart3d.Invalidate();
            }
        }
    }

    public class ViewAngleConverter : TypeConverter
    {
        public override bool GetPropertiesSupported(
            ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection
            GetProperties(ITypeDescriptorContext context,
            object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(ViewAngle));
        }
    }


}