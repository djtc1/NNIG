using System;
using System.Collections.Generic;
using System.Text;

namespace Chart3DLib
{
    public class ChartFunctions
    {
        public ChartFunctions()
        {
        }

        public void Line3D(DataSeries ds, Axes ax)
        {
            ax.XMin = -1f;
            ax.XMax = 1f;
            ax.YMin = -1f;
            ax.YMax = 1f;
            ax.ZMin = 0;
            ax.ZMax = 30;
            ax.XTick = 0.5f;
            ax.YTick = 0.5f;
            ax.ZTick = 5;

            ds.XDataMin = ax.XMin;
            ds.YDataMin = ax.YMin;
            ds.XSpacing = 0.3f;
            ds.YSpacing = 0.3f;
            ds.XNumber = Convert.ToInt16((ax.XMax - ax.XMin) / ds.XSpacing) + 1;
            ds.YNumber = Convert.ToInt16((ax.YMax - ax.YMin) / ds.YSpacing) + 1;
            ds.PointList.Clear();

            for (int i = 0; i < 300; i++)
            {
                float t = 0.1f * i;
                float x = (float)Math.Exp(-t / 30) *
                    (float)Math.Cos(t);
                float y = (float)Math.Exp(-t / 30) *
                    (float)Math.Sin(t);
                float z = t;
                ds.AddPoint(new Point3(x, y, z, 1));
            }
        }

        public void Peak3D(DataSeries ds, Axes ax)
        {
            ax.XMin = -3;
            ax.XMax = 3;
            ax.YMin = -3;
            ax.YMax = 3;
            ax.ZMin = -8;
            ax.ZMax = 8;
            ax.XTick = 1;
            ax.YTick = 1;
            ax.ZTick = 4;

            ds.XDataMin = ax.XMin;
            ds.YDataMin = ax.YMin;
            ds.XSpacing = 0.3f;
            ds.YSpacing = 0.3f;
            ds.XNumber = Convert.ToInt16((ax.XMax - ax.XMin) / ds.XSpacing) + 1;
            ds.YNumber = Convert.ToInt16((ax.YMax - ax.YMin) / ds.YSpacing) + 1;

            Point3[,] pts = new Point3[ds.XNumber, ds.YNumber];
            for (int i = 0; i < ds.XNumber; i++)
            {
                for (int j = 0; j < ds.YNumber; j++)
                {
                    float x = ds.XDataMin + i * ds.XSpacing;
                    float y = ds.YDataMin + j * ds.YSpacing;
                    double zz = 3 * Math.Pow((1 - x), 2) * Math.Exp(-x * x -
                        (y + 1) * (y + 1)) - 10 * (0.2 * x - Math.Pow(x, 3) -
                        Math.Pow(y, 5)) * Math.Exp(-x * x - y * y) -
                        1 / 3 * Math.Exp(-(x + 1) * (x + 1) - y * y);
                    float z = (float)zz;
                    pts[i, j] = new Point3(x, y, z, 1);
                }
            }
            ds.PointArray = pts;
        }

        public void SinROverR3D(DataSeries ds, Axes ax)
        {
            ax.XMin = -8;
            ax.XMax = 8;
            ax.YMin = -8;
            ax.YMax = 8;
            ax.ZMin = -0.5f;
            ax.ZMax = 1;
            ax.XTick = 4;
            ax.YTick = 4;
            ax.ZTick = 0.5f;

            ds.XDataMin = ax.XMin;
            ds.YDataMin = ax.YMin;
            ds.XSpacing = 0.5f;
            ds.YSpacing = 0.5f;
            ds.XNumber = Convert.ToInt16((ax.XMax - ax.XMin) / ds.XSpacing) + 1;
            ds.YNumber = Convert.ToInt16((ax.YMax - ax.YMin) / ds.YSpacing) + 1;

            Point3[,] pts = new Point3[ds.XNumber, ds.YNumber];
            for (int i = 0; i < ds.XNumber; i++)
            {
                for (int j = 0; j < ds.YNumber; j++)
                {
                    float x = ds.XDataMin + i * ds.XSpacing;
                    float y = ds.YDataMin + j * ds.YSpacing;
                    float r = (float)Math.Sqrt(x * x + y * y) + 0.000001f;
                    float z = (float)Math.Sin(r) / r;
                    pts[i, j] = new Point3(x, y, z, 1);
                }
            }
            ds.PointArray = pts;
        }

        public void Exp4D(DataSeries ds, Axes ax)
        {
            ax.XMin = -2;
            ax.XMax = 2;
            ax.YMin = -2;
            ax.YMax = 2;
            ax.ZMin = -2;
            ax.ZMax = 2;
            ax.XTick = 1;
            ax.YTick = 1;
            ax.ZTick = 1;

            ds.XDataMin = ax.XMin;
            ds.YDataMin = ax.YMin;
            ds.ZZDataMin = ax.ZMin;
            ds.XSpacing = 0.1f;
            ds.YSpacing = 0.1f;
            ds.ZSpacing = 0.1f;
            ds.XNumber = Convert.ToInt16((ax.XMax - ax.XMin) / ds.XSpacing) + 1;
            ds.YNumber = Convert.ToInt16((ax.YMax - ax.YMin) / ds.YSpacing) + 1;
            ds.ZNumber = Convert.ToInt16((ax.ZMax - ax.ZMin) / ds.ZSpacing) + 1;

            Point4[, ,] pts = new Point4[ds.XNumber, ds.YNumber, ds.ZNumber];
            for (int i = 0; i < ds.XNumber; i++)
            {
                for (int j = 0; j < ds.YNumber; j++)
                {
                    for (int k = 0; k < ds.ZNumber; k++)
                    {
                        float x = ds.XDataMin + i * ds.XSpacing;
                        float y = ds.YDataMin + j * ds.YSpacing;
                        float z = ax.ZMin + k * ds.ZSpacing;
                        float v = z * (float)Math.Exp(-x * x - y * y - z * z);
                        pts[i, j, k] = new Point4(new Point3(x, y, z, 1), v);
                    }
                }
            }
            ds.Point4Array = pts;
        }

    }
}
