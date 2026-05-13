using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;
using ZedGraph;


namespace NNIG_NeuralNetworkInterface
{
    public partial class Scatterplot : Form
    {

        #region Variables

        ArrayList DataLabel;

        ArrayList DataXVariable;
        ArrayList DataYVariable;
        ArrayList DataVariableIndex;

        GraphPane myPane;

        int ColumnInput1;
        int ColumnInput2;
        int DataTargets;

        private double[] VariablesOptions;
        private double[,] InputData;
        private double[,] ExpectedOutput;

        bool IsClassification;

        public ArrayList VariablesNames
        {
            get { return DataLabel; }
            set { DataLabel = value; }
        }

        public double[] isInputorOutput
        {
            get { return VariablesOptions; }
            set { VariablesOptions = value; }
        }


        public double[,] DataToDisplay
        {
            get { return InputData; }
            set { InputData = value; }
        }


        #endregion

        public Scatterplot(double[,] DataMatrix, ArrayList VariabelsCaptions, double[] InputsorOutputs, bool Classification)
        {
            InitializeComponent();
            InputData = DataMatrix;
            DataLabel = VariabelsCaptions;
            VariablesOptions = InputsorOutputs;
            IsClassification = Classification;
        }


        private void buttonShowScatterplot_Click(object sender, EventArgs e)
        {
            if (myPane.CurveList.Count != 0)
            {
                myPane.CurveList.Clear();
          
            }

            LibAlg NeuralMath = new LibAlg();

            double[] Targets = new double[InputData.GetLength(0)];

            //Set the axis labels
            myPane.Title.Text = comboBoxXAxis.SelectedItem.ToString() + " vr" + comboBoxYAxis.SelectedItem.ToString();
            myPane.XAxis.Title.Text = comboBoxXAxis.SelectedItem.ToString();
            myPane.YAxis.Title.Text = comboBoxYAxis.SelectedItem.ToString();
            myPane.YAxis.MajorGrid.IsZeroLine = false;

            PointPairList Coordinates = new PointPairList();
            if (InputData != null)
            {
                if (IsClassification)
                {
                    for (int i = 0; i < InputData.GetLength(0); i++)
                    {
                        Coordinates.Add((double)DataXVariable[i], (double)DataYVariable[i], (double)InputData[i, DataTargets]);
                        Targets[i] = (double)InputData[i, DataTargets];
                    }
                }
                else
                {
                    for (int i = 0; i < InputData.GetLength(0); i++)
                    {
                        Coordinates.Add((double)DataXVariable[i], (double)DataYVariable[i]);
  
                    }
                }

                //Generate a red curve with circle symbols, and "Input Data" in the legend

                LineItem DataPoints = myPane.AddCurve("Input Data", Coordinates, Color.Red, SymbolType.Circle);

                DataPoints.Symbol.Size = 12;

                //Set up a red-blue color gradient to be used for the fill
                DataPoints.Symbol.Fill = new Fill(Color.Red, Color.Blue);

                //Turn off the symbol borders
                DataPoints.Symbol.Border.IsVisible = false;

                //Instruct ZedGraph to fill the symbols by selecting a color out of the red-blue gradient based on the Z value. A minimum value with be red, a maximum value will be blue, and the values in between will be a linearly apportioned color between red and blue.


                if (IsClassification)
                {
                    DataPoints.Symbol.Fill.Type = FillType.GradientByZ;


                    DataPoints.Symbol.Fill.RangeMin = 1;
                    DataPoints.Symbol.Fill.RangeMax = NeuralMath.ComputeMaximumElementVector(Targets);

                }
                else
                {
                    DataPoints.Symbol.Fill.Type = FillType.Solid;
                }

                //Turn off the line, so the curve will be symbols only

                DataPoints.Line.IsVisible = false;

                myPane.Legend.IsVisible = false;


                zedGraphControl1.AxisChange();

                Refresh();
            }

        }

        private void Scatterplot_Load(object sender, EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;

            myPane.Title.IsVisible = false;
        }

        public void PopulateComboBox()
        {
            // DataLabel = new ArrayList();

            if (comboBoxXAxis.Items.Count > 0)
            {
                comboBoxXAxis.Items.Clear();

            }
            if (comboBoxYAxis.Items.Count > 0)
            {
                comboBoxYAxis.Items.Clear();

            }

            DataVariableIndex = new ArrayList();

            for (int i = 0; i < VariablesOptions.GetLength(0); i++)
            {
                if (VariablesOptions[i] == 0)
                {
                    if (DataLabel.Count != 0)
                    {
                        comboBoxXAxis.Items.Add(DataLabel[i].ToString());
                        comboBoxYAxis.Items.Add(DataLabel[i].ToString());
                    }
                    else
                    {
                        comboBoxXAxis.Items.Add("Var " + Convert.ToString(i + 1));
                        comboBoxYAxis.Items.Add("Var " + Convert.ToString(i + 1));
                    }
                    DataVariableIndex.Add(i);
                }
                if (VariablesOptions[i] == 1)
                {
                    DataTargets = i;
                }

                if (!IsClassification)
                {
                    if (VariablesOptions[i] == 1)
                    {
                        if (DataLabel.Count != 0)
                        {
                            comboBoxXAxis.Items.Add(DataLabel[i].ToString());
                            comboBoxYAxis.Items.Add(DataLabel[i].ToString());
                        }
                        else
                        {
                            comboBoxXAxis.Items.Add("Out " + Convert.ToString(i + 1));
                            comboBoxYAxis.Items.Add("Out " + Convert.ToString(i + 1));
                        }
                        DataVariableIndex.Add(i);
                    }

                   
                }

            }
            if (!IsClassification)
            {
                comboBoxXAxis.Items.Add("Rows Numbers");
                comboBoxYAxis.Items.Add("Rows Numbers");
            }
            if (comboBoxXAxis.Items.Count != 0) comboBoxXAxis.SelectedIndex = 0;
            if (comboBoxYAxis.Items.Count != 0) comboBoxYAxis.SelectedIndex = 0;
        }

        private void comboBoxXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataXVariable = new ArrayList();

            int Index;

            if( comboBoxXAxis.SelectedIndex == InputData.GetLength(1)) // if the number of selected item of the combobox is equal to the number of columns in the input data it means that the software is runnig for Regression 
           // if (!IsClassification && comboBoxXAxis.Text == "Rows Numbers")
            {
                for (int i = 0; i < InputData.GetLength(0); i++)
                {
                    DataXVariable.Add((double)(i + 1));

                }
            }
            else
            {
                Index = comboBoxXAxis.SelectedIndex;

                int OriginalDataIndex = (int)DataVariableIndex[Index];

                ColumnInput1 = OriginalDataIndex;

                for (int i = 0; i < InputData.GetLength(0); i++)
                {
                    DataXVariable.Add(InputData[i, OriginalDataIndex]);

                }
            }
        }

        private void comboBoxYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataYVariable = new ArrayList();

            int Index;

            if (!IsClassification && comboBoxYAxis.Text == "Rows Numbers")
            {
                for (int i = 0; i < InputData.GetLength(0); i++)
                {
                    DataYVariable.Add((double)(i + 1));

                }

            }
            else
            {
                Index = comboBoxYAxis.Items.IndexOf(comboBoxYAxis.SelectedItem);

                int OriginalDataIndex = (int)DataVariableIndex[Index];

                ColumnInput2 = OriginalDataIndex;

                for (int i = 0; i < InputData.GetLength(0); i++)
                {
                    DataYVariable.Add(InputData[i, OriginalDataIndex]);

                }
            }
        }



    }
}