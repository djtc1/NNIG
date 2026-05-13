using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;
using Chart3DLib;

namespace NNIG_NeuralNetworkInterface
{
    public partial class ErrorSurface : Form
    {
        private class weightPosition
        {
            public int previousNeuron, neuron , layer;
            public string letra;

            public weightPosition(string letra, int previousNeuron, int neuron, int layer)
            {
                this.letra=letra;
                this.previousNeuron = previousNeuron;
                this.neuron = neuron;
                this.layer = layer;
            }

            public override string ToString()
            {
                switch(letra)
                {
                    case "W":
                        return letra + "(" + (previousNeuron + 1).ToString() + ", " + (neuron + 1).ToString() + ", " + (layer + 1).ToString() + ")";
                        break;
                    case "B": default:
                        return letra + "(" + (neuron + 1).ToString() + ", " + (layer + 1).ToString() + ")";
                        break;
                }
            }
        }

        ErrorSurfaceWeightsHelp WeightsHelp;

        ColorMap cm;
        

        private NeuralNetwork nn;
        private double[][] InputMatrix;
        private double[][] TargetMatrix;

        float x, y, z;


        public NeuralNetwork AccesstoNN
        {
            set { nn = value; }
        }

        public double[][] InputData
        {
            set { InputMatrix = value; }
        }

        public double[][] ExpectedOutput
        {
            set { TargetMatrix = value; }        
        }

        public ErrorSurface()
        {
            InitializeComponent();
            
        }

        public ErrorSurface(NeuralNetwork NN, double[][] InputedData, double[][] ExpectedOutput)
        {
            InitializeComponent();
            nn = NN;
            InputMatrix = InputedData;
            TargetMatrix = ExpectedOutput;
            
            PopulateComboBox();

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            double Min;
            double Max;
            float MinZ=0;
            float MaxZ=0;
            bool alreadyTested=false;

            double Resolution=0;
            double Step=0;
            weightPosition selectedX = (weightPosition)comboBoxWeightX.SelectedItem;
            weightPosition selectedY = (weightPosition)comboBoxWeightY.SelectedItem;

            ArrayList WeightsIntervals = new ArrayList ();

            Boolean ParseMinResult;
            Boolean ParseMaxResult;
            Boolean ParseStep;

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            cm = new ColorMap();
            chart3DError.C3DrawChart.CMap = cm.Cool();
            chart3DError.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.Surface;
            chart3DError.C3ChartStyle.IsColorBar = true;
            chart3DError.C3DataSeries.LineStyle.IsVisible = true;
            chart3DError.HighQuality = true;
          
      


            ParseMinResult = double.TryParse(numericTextBoxLeftBound.Text, out Min);
            ParseMaxResult = double.TryParse(numericTextBoxRight.Text, out Max);
            
            if (ParseMinResult == true && ParseMaxResult == true)
            {
                if (Min >= Max)
                {
                    MessageBox.Show(" Please check your options for the left and right bounds", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    chart3DError.C3Axes.XMin = (float) Min;
                    chart3DError.C3Axes.XMax = (float) Max;
                    chart3DError.C3Axes.YMin = (float) Min;
                    chart3DError.C3Axes.YMax = (float) Max;

                    ParseStep = double.TryParse(numericTextBoxStep.Text, out Resolution);

                    if (ParseStep)
                    {

                        Step = (Max - Min) / Resolution;

                        for (double l = 0; l <= Resolution ; l += Step)
                        {
                            WeightsIntervals.Add(Min + l * Step);

                        }

                    }
                }
            }

            chart3DError.C3Axes.XTick = (float)(Max - Min) / 5;
            chart3DError.C3Axes.YTick = (float)(Max - Min) / 5;
            chart3DError.C3DataSeries.XDataMin = chart3DError.C3Axes.XMin;
            chart3DError.C3DataSeries.YDataMin = chart3DError.C3Axes.YMin;
            chart3DError.C3DataSeries.XSpacing = (float) Resolution;
            chart3DError.C3DataSeries.YSpacing = (float)Resolution;

            chart3DError.C3Labels.XLabel = comboBoxWeightX.Text;
            chart3DError.C3Labels.YLabel = comboBoxWeightY.Text;
            chart3DError.C3Labels.ZLabel = "MSE";
            

            chart3DError.C3DataSeries.XNumber = Convert.ToInt16(Step) + 1;
            chart3DError.C3DataSeries.YNumber = Convert.ToInt16(Step) + 1;

            Point3[,] pts = new Point3[chart3DError.C3DataSeries.XNumber,
                chart3DError.C3DataSeries.YNumber];
            

            for (int i = 0; i < chart3DError.C3DataSeries.XNumber; i++)
            {
                for (int j = 0; j < chart3DError.C3DataSeries.YNumber; j++)
                {
                     x = chart3DError.C3DataSeries.XDataMin +
                        i * chart3DError.C3DataSeries.XSpacing;

                    //Update Weights in nn arquitecture
                    if (nn != null)
                    {
                        if (selectedX.letra=="W")
                        {
                            nn[selectedX.layer][selectedX.neuron][selectedX.previousNeuron] = x;
                        }
                        else
                        {
                            nn[selectedX.layer][selectedX.neuron].Threshold = x;
                        }

                         y = chart3DError.C3DataSeries.YDataMin +
                            j * chart3DError.C3DataSeries.YSpacing;

                        //Update Weights in nn arquitecture

                         if (selectedY.letra == "W")
                        {
                            nn[selectedY.layer][selectedY.neuron][selectedY.previousNeuron] = y;
                        }
                        else
                        {
                            nn[selectedY.layer][selectedY.neuron].Threshold = y;
                        }

                        //compute z value

                        double zz = ComputeMSE(InputMatrix, TargetMatrix);

                        z = (float)zz;

                        if (!alreadyTested)
                        {
                            alreadyTested = true;
                            MinZ = z;
                            MaxZ = z;
                        }
                        else
                        {
                            if (z < MinZ) MinZ = z;
                            if (z > MaxZ) MaxZ = z;
                        }

                        
                        pts[i, j] = new Point3(x, y, z, 1);
                    }
                }
                
            }

            chart3DError.C3Axes.ZMin = MinZ;
            chart3DError.C3Axes.ZMax = MaxZ;
            chart3DError.C3Axes.ZTick = (MaxZ-MinZ)/5;
            chart3DError.C3DataSeries.PointArray = pts;
            chart3DError.Redraw();
        }

        public void PopulateComboBox()
        {
            if (comboBoxWeightX.Items.Count > 0)
            {
                comboBoxWeightX.Items.Clear();

            }
            if (comboBoxWeightY.Items.Count > 0)
            {
                comboBoxWeightY.Items.Clear();

            }

            for (int i = 0; i < nn.N_Layers; i++)//fixar camada
            {
                for (int j = 0; j < nn[i].N_Neurons; j++)//fixar neurónios
                {
                    for (int k = 0; k < nn[i][j].N_Inputs+1; k++)//sinapses
                    {

                        if (k == nn[i][j].N_Inputs)
                        {
                            comboBoxWeightX.Items.Add(new weightPosition("B", k, j, i));
                            comboBoxWeightY.Items.Add(new weightPosition("B", k, j, i));
                        }
                        else
                        {
                            comboBoxWeightX.Items.Add(new weightPosition("W", k, j, i));
                            comboBoxWeightY.Items.Add(new weightPosition("W", k, j, i));
                        }
                    }
                }
            }

        }//end PopulateComboBox method


        public void RefreshGrafic()
        {

            double zz = ComputeMSE(InputMatrix, TargetMatrix);

            z = (float)zz;//????

            chart3DError.Redraw();

        
        }


        private double ComputeMSE(double[][] InpData, double[][] ExpectedOut)
        {
            double Error = 0;
            double[] ErrorVector;

            for (int i = 0; i < InpData.Length; i++)
            {
                ErrorVector = nn.Output(InputMatrix[i]);

                for (int j = 0; j < ErrorVector.Length; j++)
                {
                    Error += Math.Pow((ErrorVector[j] - ExpectedOut[i][j]), 2);
                }
            }
            
            Error /= 2;
            return Error;
        }


        private void labelHelpXAxis_Click(object sender, EventArgs e)
        {
            WeightsHelp = new ErrorSurfaceWeightsHelp();
            WeightsHelp.MdiParent = this.MdiParent;
            WeightsHelp.Show();
            WeightsHelp.BringToFront();
        }

        private void ErrorSurface_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((NNIG_Software)MdiParent).toolStripButtonErrorSurface.Enabled = true;
        }

    }
}