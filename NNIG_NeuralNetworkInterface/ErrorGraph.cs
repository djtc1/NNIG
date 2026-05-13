using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;


namespace NNIG_NeuralNetworkInterface
{
    public partial class ErrorGraph : Form
    {
        GraphPane myPane;

        public ErrorGraph()
        {
            InitializeComponent();
        }

        private void ErrorGraph_Load(object sender, EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;


            myPane.Title.IsVisible = false;
            myPane.XAxis.Title.Text = "Iterations Number";
            myPane.YAxis.Title.Text = "MSE";

            //Saves 100 000 points
            //The RollingPointPairList is an efficient storage class that always 
            // keeps a rolling set of point data without needing to shift any data values

            RollingPointPairList list = new RollingPointPairList(100000);

            // Initially, a curve is added with no data points (list is empty)
            // Color is blue, and there will be no symbols
            LineItem curve = myPane.AddCurve("MSE", list, Color.Blue, SymbolType.None);


            if (((NNIG_Software)MdiParent).LearningAlgorithmError!= null)
            {
                for (int i = 0; i < ((NNIG_Software)MdiParent).LearningAlgorithmError.Count; i++)
                {
                    curve.AddPoint(i++, (double)((NNIG_Software)MdiParent).LearningAlgorithmError[i]); 

                }
            }

            // Just manually control the X axis range so it scrolls continuously
            // instead of discrete step-sized jumps
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
           

            // Scale the axes
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            centrar();
        }

        public void CreateGraph(double x, double y)
        {


            // Make sure that the curvelist has at least one curve
            if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                return;

            // Get the first CurveItem in the graph
            LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (curve == null)
                return;

          

            // Get the PointPairList
            IPointListEdit list = curve.Points as IPointListEdit;
            // If this is null, it means the reference at curve.Points does not
            // support IPointListEdit, so we won't be able to modify it
            if (list == null)
                return;

            // double time = (Environment.TickCount - tickStart) / 1000.0;

            list.Add(x, y);

            // Keep the X scale at a rolling 30 second interval, with one
            // major step between the max X value and the end of the axis

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            Scale yScale = zedGraphControl1.GraphPane.YAxis.Scale;


            // Make sure the Y axis is rescaled to accommodate actual data
            zedGraphControl1.AxisChange();
            // Force a redraw
            zedGraphControl1.Invalidate();

        }

        private void SetSize()
        {
            // Control is always 10 pixels inset from the client rectangle of the form
            Rectangle formRect = this.ClientRectangle;
            formRect.Inflate(-10, -10);

            if (zedGraphControl1.Size != formRect.Size)
            {
                zedGraphControl1.Location = formRect.Location;
                zedGraphControl1.Size = formRect.Size;
            }

        }

        private void ErrorGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((NNIG_Software)MdiParent).toolStripButtonErrorGraph.Enabled = true;
            ((NNIG_Software)MdiParent).ErrorGraphic = null;

        }

        public void ClearGraph()
        {
            zedGraphControl1.GraphPane.CurveList.Clear();

            zedGraphControl1.Refresh();

            myPane = zedGraphControl1.GraphPane;

            RollingPointPairList list = new RollingPointPairList(100000);

            // Initially, a curve is added with no data points (list is empty)
            // Color is blue, and there will be no symbols
            LineItem curve = myPane.AddCurve("MSE", list, Color.Blue, SymbolType.None);

            // Just manually control the X axis range so it scrolls continuously
            // instead of discrete step-sized jumps
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;


            // Scale the axes
            zedGraphControl1.AxisChange();
            //Forces a Redraw
            zedGraphControl1.Invalidate();
        
        }


        private void button_clear_Click(object sender, EventArgs e)
        {
            ClearGraph();
        }

        private void ErrorGraph_Resize(object sender, EventArgs e)
        {
            if (this.Width < 120) this.Width = 120;
            if (this.Height < 150) this.Height = 150;
            centrar();
        }

        private void centrar()
        {
            int windowHeight = this.DisplayRectangle.Height;
            int windowWidth = this.DisplayRectangle.Width;
            zedGraphControl1.Left = 10;
            zedGraphControl1.Top = 10;
            zedGraphControl1.Width = windowWidth - 20;
            zedGraphControl1.Height = windowHeight - 30 - button_clear.Height;
            button_clear.Top = zedGraphControl1.Height + 20;
            button_clear.Left = (windowWidth - button_clear.Width) / 2;
        }
    }
}