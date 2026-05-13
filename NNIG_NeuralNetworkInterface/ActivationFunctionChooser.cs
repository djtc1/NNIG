using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using NNIG_NeuralNetworkMath;

namespace NNIG_NeuralNetworkInterface
{
    public partial class ActivationFunctionChooser : Form
    {
        protected ActivationFunction currentAF;

        LineItem myCurve;
        PointPairList list;
        GraphPane myPane;

        protected bool choose = false;
        
        public bool ChooseOK
        {
            get { return choose; }
        }

        public ActivationFunction Afunction
        {
            get
            {
                return currentAF;
            }
            set
            {
                if (value.GetType().FullName.IndexOf("Linear") > 0)
                {
                    LinearActivationFunction c = (LinearActivationFunction)value;

                    currentAF = new LinearActivationFunction();

                    ((LinearActivationFunction)currentAF).A = c.A;

                    this.numEditLinearCoef.Text = "" + c.A;

                    this.radioButtonLinear.Select();
                }
                else if (value.GetType().FullName.IndexOf("Gaussian") > 0)
                {
                    GaussianActivationFunction c = (GaussianActivationFunction)value;

                    currentAF = new GaussianActivationFunction();

                    ((GaussianActivationFunction)currentAF).Mu = c.Mu;
                    ((GaussianActivationFunction)currentAF).Sigma = c.Sigma;

                    this.numEditMeanGaussiana.Text = "" + c.Mu;
                    this.numEditStandarddeviation.Text = "" + c.Sigma;
                    this.radioButtonGaussiana.Select();

                }
                else if (value.GetType().FullName.IndexOf("Heaviside") > 0)
                {
                    currentAF = new HeavisideActivationFunction();

                    this.radioButtonHeaviside.Select();
                }
                else if (value.GetType().FullName.IndexOf("Sigmoid") > 0)
                {
                    SigmoidActivationFunction c = (SigmoidActivationFunction)value;

                    currentAF = new SigmoidActivationFunction();

                    ((SigmoidActivationFunction)currentAF).Beta = c.Beta;

                    this.numEditsigHT.Text = "" + c.Beta;

                    this.radioButtonLogistic.Select();

                }

                else if (value.GetType().FullName.IndexOf("Hyperbolic Tangent") > 0)
                {
                    HyperbolicTangentActivationFunction c = (HyperbolicTangentActivationFunction)value;

                    currentAF = new HyperbolicTangentActivationFunction();

                    ((HyperbolicTangentActivationFunction)currentAF).Beta = c.Beta;

                    this.numEditsigHT.Text = "" + c.Beta;

                    this.radioButtonHypTan.Select();

                }
            }
        }//end propertie





        public ActivationFunctionChooser()
        {
            InitializeComponent();

            currentAF = new SigmoidActivationFunction();
            refreshPreview();
        }

        protected void refreshPreview()
        {
             myPane = zedGraphControl1.GraphPane;

             zedGraphControl1.GraphPane.CurveList.Clear();

            // Set the titles and axis labels
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "X";
            myPane.YAxis.Title.Text = "Y";

            // Make up some data arrays based on the Sine function
            double x, y;

           
            list = new PointPairList();
            for ( x = -4; x < 4; x+= 0.1)
            {
                y = currentAF.Output(x);
                list.Add(x, y);
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
             myCurve = myPane.AddCurve(currentAF.Name,list, Color.Red, SymbolType.None);

            // Set the Y axis intersect the X axis at an X value of 0.0
            myPane.YAxis.Cross = 0.0;
            myPane.XAxis.Cross = 0.0; 
            // Turn off the axis frame and all the opposite side tics
            myPane.Chart.Border.IsVisible = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;

            // Calculate the Axis Scale Ranges
           zedGraphControl1.AxisChange();
           zedGraphControl1.Refresh();

            //functionPreview1.setFunction(currentAF);
           

            //if (radioButtonHypTan.Checked)
            //{
            //    functionPreview1.Y_MIN = -1.25;
                
            //}

            //else
            //{
            //    functionPreview1.Y_MIN = -0.25;
            //}

            //functionPreview1.Refresh();

        }

        private void ActivationFucntionChooser_Load(object sender, EventArgs e)
        {
          

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            choose = true;

            this.Close();
            
            }//end buttonOk_click

            private void radioButtonsigmoid_CheckedChanged(object sender, EventArgs e)
            {
                if (radioButtonLogistic.Checked)
                {
                    SigmoidActivationFunction c = new SigmoidActivationFunction();

                    currentAF = c;


                    c.Beta = double.Parse(this.numEditsigHT.Text);

                    this.panel_sigmoidHyperbolicT.Visible = true;


                    refreshPreview();

                }
                else //if( radioButtonsigmoid.Checked = false && radioButtonHyperbolicTangent.Checked = false)
                {
                    this.panel_sigmoidHyperbolicT.Visible = false;
                }
            }

            private void radioButtonLinear_CheckedChanged(object sender, EventArgs e)
            {
                if (radioButtonLinear.Checked)
                {
                    LinearActivationFunction c = new LinearActivationFunction();

                    currentAF = c;

                    this.panel_Linear_parameters.Visible = true;

                    c.A = double.Parse(numEditLinearCoef.Text);

                    refreshPreview();
                }
                else
                {
                    this.panel_Linear_parameters.Visible = false;
                }
            }

            private void radioButtonHeaviside_CheckedChanged(object sender, EventArgs e)
            {
                if (radioButtonHeaviside.Checked)
                {
                    HeavisideActivationFunction c = new HeavisideActivationFunction();

                    currentAF = c;

                    refreshPreview();

                }
            }

            private void radioButtonGaussiana_CheckedChanged(object sender, EventArgs e)
            {
                if (radioButtonGaussiana.Checked)
                {
                    GaussianActivationFunction c = new GaussianActivationFunction();

                    currentAF = c;

                    this.panel_param_gaussiana.Visible = true;

                    c.Mu = double.Parse(this.numEditMeanGaussiana.Text);
                    c.Sigma = double.Parse(this.numEditStandarddeviation.Text);

                    refreshPreview();
                }
                else
                {
                    this.panel_param_gaussiana.Visible = false;
                }
            }



            private void radioButtonHyperbolicTangent_CheckedChanged(object sender, EventArgs e)
            {
                if (radioButtonHypTan.Checked)
                {
                    HyperbolicTangentActivationFunction c = new HyperbolicTangentActivationFunction();

                    currentAF = c;

                    this.panel_sigmoidHyperbolicT.Visible = true;

                    c.Beta = double.Parse(this.numEditsigHT.Text);

                    refreshPreview();

                }
                else
                {
                    this.panel_sigmoidHyperbolicT.Visible = false;
                }
            }


            private void numEditMeanGaussiana_TextChanged(object sender, EventArgs e)
            {
                if (numEditMeanGaussiana.Text != "")
                {
                    GaussianActivationFunction c = (GaussianActivationFunction)currentAF;

                    c.Mu = double.Parse(numEditMeanGaussiana.Text);
                }

                refreshPreview();
            }

            private void numEditStandarddeviation_TextChanged(object sender, EventArgs e)
            {
                if (numEditStandarddeviation.Text != "")
                {
                    GaussianActivationFunction c = (GaussianActivationFunction)currentAF;

                    c.Sigma = double.Parse(numEditStandarddeviation.Text);
                }
                refreshPreview();
            }


            private void numEditsigHT_TextChanged(object sender, EventArgs e)
            {
                if (numEditsigHT.Text != "")
                {
                    if (radioButtonLogistic.Checked)
                    {
                        SigmoidActivationFunction c = (SigmoidActivationFunction)currentAF;

                        c.Beta = double.Parse(numEditsigHT.Text);

                    }
                    else if (radioButtonHypTan.Checked)
                    {
                        HyperbolicTangentActivationFunction c = (HyperbolicTangentActivationFunction)currentAF;

                        c.Beta = double.Parse(numEditsigHT.Text);

                    }
                }
                refreshPreview();

            }

            private void numEditLinearCoef_TextChanged(object sender, EventArgs e)
            {
                if (numEditLinearCoef.Text != "")
                {
                    LinearActivationFunction c = (LinearActivationFunction)currentAF;

                    c.A = double.Parse(numEditLinearCoef.Text);
                }
                refreshPreview();

            }

            private void numEditMeanGaussiana_Leave(object sender, EventArgs e)
            {
                if (numEditMeanGaussiana.Text == "")
                {
                    GaussianActivationFunction c = (GaussianActivationFunction)currentAF;
                    numEditMeanGaussiana.Text = c.Mu.ToString();
                }
            }

            private void numEditStandarddeviation_Leave(object sender, EventArgs e)
            {
                if (numEditStandarddeviation.Text == "")
                {
                    GaussianActivationFunction c = (GaussianActivationFunction)currentAF;
                    numEditMeanGaussiana.Text = c.Sigma.ToString();
                }
            }

            private void numEditLinearCoef_Leave(object sender, EventArgs e)
            {
                if (numEditLinearCoef.Text == "")
                {
                    LinearActivationFunction c = (LinearActivationFunction)currentAF;
                    numEditLinearCoef.Text = c.A.ToString();
                }
            }

            private void numEditsigHT_Leave(object sender, EventArgs e)
            {
                if (numEditsigHT.Text == "")
                {
                    if (radioButtonLogistic.Checked)
                    {
                        SigmoidActivationFunction c = (SigmoidActivationFunction)currentAF;

                        numEditsigHT.Text = c.Beta.ToString();
                    }
                    else if (radioButtonHypTan.Checked)
                    {
                        HyperbolicTangentActivationFunction c = (HyperbolicTangentActivationFunction)currentAF;

                        numEditsigHT.Text = c.Beta.ToString();

                    }
                }

            }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            choose = false;

            this.Close();
        }


        }

    }
