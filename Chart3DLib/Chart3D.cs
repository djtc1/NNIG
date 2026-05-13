using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Chart3DLib
{
    public partial class Chart3D : UserControl
    {
        private ChartStyle cs;
        private ChartStyle2D cs2d;
        private DrawChart dc;
        private DataSeries ds;
        private Axes ax;
        private ViewAngle va;
        private Grid gd;
        private ChartLabels cl;
        private ColorMap cm;
        private Point mouseBase;
        private bool mouseDown;
        private bool antialias;
        private bool fastRotate;
        private bool upToDate;
        private float baseAzimuth;
        private float baseElevation;
        private Image chartImage;
        private int lastSize;
      
        public Chart3D()
        {
            InitializeComponent();
            //this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            cs = new ChartStyle(this);
            cs2d = new ChartStyle2D(this);
            dc = new DrawChart(this);
            ds = new DataSeries();
            ax = new Axes(this);
            va = new ViewAngle(this);
            gd = new Grid(this);
            cl = new ChartLabels(this);
            gd.GridStyle.LineColor = Color.LightGray;
            this.BackColor = Color.White;
            cm = new ColorMap();
            dc.CMap = cm.Jet();
            mouseDown = false;
            antialias = false;
            fastRotate = true;
            upToDate = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g2;
            //g2 = this.CreateGraphics();
            g2 = e.Graphics;
            if (!upToDate)
            {
                Image buffer = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(buffer);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);

                if (antialias) g.SmoothingMode = SmoothingMode.AntiAlias;
                else g.SmoothingMode = SmoothingMode.None;
                cs2d.ChartArea = this.ClientRectangle;

                if (dc.ChartType == DrawChart.ChartTypeEnum.XYColor ||
                                dc.ChartType == DrawChart.ChartTypeEnum.Contour ||
                                dc.ChartType == DrawChart.ChartTypeEnum.FillContour)
                {
                    cs2d.AddChartStyle2D(g, cs, ax, gd, cl);
                    dc.AddColorBar(g, ds, cs, cs2d, ax, va, cl);
                    dc.AddChart(g, ds, cs, cs2d, ax, va, cl);
                }
                else
                {
                    cs.AddChartStyle(g, ax, va, gd, cl);
                    if (!mouseDown || !fastRotate) dc.AddChart(g, ds, cs, cs2d, ax, va, cl);
                }
                chartImage = buffer;
                upToDate = true;
                g2.DrawImage(buffer, new Point(0, 0));
                g.Dispose();
            }
            else
            {
                g2.DrawImage(chartImage, new Point(0, 0));
            }
            g2.Dispose();
        }

        [BrowsableAttribute(false)]
        public DrawChart C3DrawChart
        {
            get { return this.dc; }
            set { this.dc = value; }
        }

        [BrowsableAttribute(false)]
        public ChartStyle C3ChartStyle
        {
            get { return this.cs; }
            set {
                if (value != null)
                {
                    this.cs = value;
                }
            }
        }

        [BrowsableAttribute(false)]
        public ChartStyle2D C3ChartStyle2D
        {
            get { return this.cs2d; }
            set { this.cs2d = value; }
        }

        [BrowsableAttribute(false)]
        public DataSeries C3DataSeries
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Content)]
        public Axes C3Axes
        {
            get { return this.ax; }
            set
            {
                if (value != null)
                {
                    this.ax = value;
                }
            }
        }

        [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Content)]
        public ViewAngle C3ViewAngle
        {
            get { return this.va; }
            set
            {
                if (value != null)
                {
                    this.va = value;
                }
            }
        }

        [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Content)]
        public bool HighQuality
        {
            get { return antialias; }
            set
            {
                antialias = value;
            }
        }

        [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Content)]
        public bool FastRotate
        {
            get { return fastRotate; }
            set
            {
                fastRotate = value;
            }
        }

        [DesignerSerializationVisibility(
		DesignerSerializationVisibility.Content)]
        public ChartLabels C3Labels
        {
            get { return this.cl; }
            set
            {
                if (value != null)
                {
                    this.cl = value;
                }
            }
        }

        [DesignerSerializationVisibility(
		DesignerSerializationVisibility.Content)]
        public Grid C3Grid
        {
            get { return this.gd; }
            set
            {
                if (value != null)
                {
                    this.gd = value;
                }
            }
        }

        private void Chart3D_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.NoMove2D;
                upToDate = false;
                mouseBase.X = e.X;
                mouseBase.Y = e.Y;
                baseAzimuth = va.Azimuth;
                baseElevation = va.Elevation;
                mouseDown = true;
            }
        }

        private void Chart3D_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.Default;
                mouseDown = false;
                upToDate = false;
                Invalidate();
            }
        }

        private void Chart3D_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                upToDate = false;
                float at = (float)Math.Round(baseAzimuth - (e.X - mouseBase.X), 0);
                float et = (float)Math.Round(baseElevation + (e.Y - mouseBase.Y), 0);
                while (at <= -180) at += 360;
                while (at >= 180) at -= 360;
                while (et <= -90) et += 180;
                while (et >= 90) et -= 180;
                va.Azimuth = at;
                va.Elevation = et;
            }
        }

        public void Redraw()
        {
            upToDate = false;
            this.Invalidate();
        }

        private void Chart3D_SizeChanged(object sender, EventArgs e)
        {
            if(lastSize!=0 && this.Height!=0) Redraw();
            lastSize = this.Height;
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage.FileName = "chart";
            if(saveImage.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    if (saveImage.FileName.ToUpper().EndsWith("jpg".ToUpper()))
                    {
                        chartImage.Save(saveImage.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else if (saveImage.FileName.ToUpper().EndsWith("png".ToUpper()))
                    {
                        chartImage.Save(saveImage.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
                catch (Exception imgE)
                {
                    MessageBox.Show(imgE.Message);
                }
            }
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighQuality = true;
            Redraw();
        }

        private void lowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighQuality = false;
            Redraw();
        }

        private void onlyDrawAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastRotate = true;
        }

        private void drawChartAndAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastRotate = false;
        }

        private void menu_Opening(object sender, CancelEventArgs e)
        {
            drawChartAndAxisToolStripMenuItem.Checked = !FastRotate;
            onlyDrawAxisToolStripMenuItem.Checked = FastRotate;
            highToolStripMenuItem.Checked = HighQuality;
            lowToolStripMenuItem.Checked = !HighQuality;
        }
    }
}