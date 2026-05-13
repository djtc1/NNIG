using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;

namespace NNIG_NeuralNetworkInterface
{
    public partial class BackPropagation : Form
    {

        #region Variables

        private bool saveResults = false;

        private BackPropagationLearningAlgorithm alg;
        
        

        #endregion

        public BackPropagation()
        {
            InitializeComponent();

            comboBoxBackAlgo.SelectedIndex = 0;
                 
        }


        #region Public Access to the class
       
        public bool SaveAllResults
        {
            get
            {
                return saveResults;
            }
        }
        #endregion 

      
        private void button1_Click(object sender, EventArgs e)//reset to default values
        {
                tb_alpha.Text = "0.1";
                tb_beta.Text = "0.2";
                tb_iter.Text = "0";// dados pelo algoritmo matemático 
                tb_maxiter.Text = "1000";
                tb_err.Text = "";//dados pelo algoritmo matemático
                tb_max_err.Text = "0.01";// dado pelo algoritmo matemático (**)

                //(**) 
                // Se este não tiver sido corrido então são os valores por defeito. se já tiver sido corrido então dá os valores finais obtidos pelo backpropagation
          
        }

        public void refreshAll(NeuralNetwork  nn)
        {
            tb_iter.Text = "" + nn.LearningAlg.Iteration.ToString();
            tb_err.Text = "" + nn.LearningAlg.Error.ToString();
            
        }

              #region Textboxes Leave method


        private void tb_alpha_Leave(object sender, EventArgs e)
        {
            if (tb_alpha.Text == "")
            {
                
                tb_alpha.Text = "0";
               
            }
        }

        private void tb_beta_Leave(object sender, EventArgs e)
        {
            if (tb_beta.Text == "")
            {
               tb_beta.Text = "0"; 
            }
        }

        private void tb_maxiter_Leave(object sender, EventArgs e)
        {
            if (tb_maxiter.Text == "")
            {
                
              tb_maxiter.Text = "0";

            }
        }

        private void tb_max_err_Leave(object sender, EventArgs e)
        {
            if (tb_max_err.Text == "")
            {
               tb_max_err.Text = "0";
            }
        }

        #endregion



        private void buttonOk_Click(object sender, EventArgs e)//button submit
        {
            if (checkBoxSaveAllResults.Checked)
            {
                saveResults = true;
            }
            else
            {
                saveResults = false;
            }

           
            if (tb_alpha.Text != "")
           {
             try
             {
              ((NNIG_Software)MdiParent).LearningRate = double.Parse(this.tb_alpha.Text);
             }
             catch
             {
                 MessageBox.Show("Please check you option for the Learning Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
                }
                if (tb_beta.Text != "")
                {
                    try
                    {
                        ((NNIG_Software)MdiParent).Momentum = double.Parse(this.tb_beta.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please check you option for the Momentum", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (tb_maxiter.Text != "")
                {
                    try
                    {
                        int iterations = int.Parse(this.tb_maxiter.Text);

                        if (iterations == 0)
                        {
                            MessageBox.Show("You must indicate the number of iterations!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            ((NNIG_Software)MdiParent).IterationsInOnRun = iterations;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please check you option for the Epochs in one run", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (tb_max_err.Text != "")
                {
                    try
                    {
                        ((NNIG_Software)MdiParent).MinimumError = double.Parse(this.tb_max_err.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please check you option for the Min sum square error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }          
            
            if (comboBoxBackAlgo.SelectedItem.ToString() == "Batch Backpropagation")
            {
                ((NNIG_Software)MdiParent).BackPropagationType = "Batch Backpropagation";
            }
            else if (comboBoxBackAlgo.SelectedItem.ToString() == "Sequential Backpropagation")
            {
                ((NNIG_Software)MdiParent).BackPropagationType = "Sequential Backpropagation";
            }

            ((NNIG_Software)MdiParent).RunButtonCliked = false;
            ((NNIG_Software)MdiParent).toolStripButtonContinue.Enabled = false;

          //  this.Close();

        }


        private void BackPropagation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                DialogResult buttonclose = MessageBox.Show("Do you want to leave?", "BackPropagation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (buttonclose.Equals(DialogResult.No))
                {
                    e.Cancel = true;
                }
                else
                {
                    ((NNIG_Software)MdiParent).toolStripButtonSupLearning.Enabled = true;
                }
            }
        }

        private void tb_alpha_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackPropagation_Load(object sender, EventArgs e)
        {

        }






    }
}