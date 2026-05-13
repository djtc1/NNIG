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
    public partial class NNArquitectureChooser : Form
    {

        public NNIG_Software parentWindow;

        bool buttonokclicked = false;

        public NNArquitectureChooser()
        {
            InitializeComponent();

        }

        private void listViewNN_SelectedIndexChanged(object sender, EventArgs e)
        {
             textBoxItemName.Text = listViewNN.FocusedItem.Text;


        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(textBoxItemName.Text == "")
            {
                    MessageBox.Show ("Must Choose a Neural Network Arquitecture");
            }
            else
            {
                if (listViewNN.FocusedItem.Text == "MLP")
                {
                    ((NNIG_Software)parentWindow).AccessToMLPArquitecture = new MLPEditor();
                    ((NNIG_Software)parentWindow).AccessToMLPArquitecture.MdiParent = parentWindow;
                    if (((NNIG_Software)parentWindow).InputDataArray != null && ((NNIG_Software)parentWindow).Targets != null)
                    {

                        int[] outputs = { ((NNIG_Software)parentWindow).Targets[0].Length };
                        ((NNIG_Software)parentWindow).AccessToMLPArquitecture.Neural_Network = new NeuralNetwork(((NNIG_Software)parentWindow).InputDataArray[0].Length, outputs);

                    }

                    ((NNIG_Software)parentWindow).AccessToMLPArquitecture.Show();
                
                    ((NNIG_Software)parentWindow).AccessToMLPArquitecture.Location = new Point(643, 25);
                    ((NNIG_Software)parentWindow).toolStripButtonNN.Enabled = false;
                    buttonokclicked = true;
                    this.Close();

                }

            }
           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxItemName.Text = "";
           
            this.Close();
        }

        private void textBoxItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewNN_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewNN.SelectedItems != null)
            {
                if (listViewNN.FocusedItem.Text == "MLP")
                {
                    ((NNIG_Software)parentWindow).AccessToMLPArquitecture = new MLPEditor();
                    ((NNIG_Software)parentWindow).AccessToMLPArquitecture.MdiParent = parentWindow;
                    if (((NNIG_Software)parentWindow).InputDataArray != null && ((NNIG_Software)parentWindow).Targets != null)
                    {

                        int[] outputs = { ((NNIG_Software)parentWindow).Targets[0].Length };
                        ((NNIG_Software)parentWindow).AccessToMLPArquitecture.Neural_Network = new NeuralNetwork(((NNIG_Software)parentWindow).InputDataArray[0].Length, outputs);

                    }

                    ((NNIG_Software)parentWindow).AccessToMLPArquitecture.Show();

                    ((NNIG_Software)parentWindow).AccessToMLPArquitecture.Location = new Point(643, 25);
                    ((NNIG_Software)parentWindow).toolStripButtonNN.Enabled = false;

                 

                } 
                
                this.Close();
                
                ((NNIG_Software)parentWindow).toolStripButtonNN.Enabled = false;
                
                buttonokclicked = true;

            }
        }

        private void NNArquitectureChooser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && buttonokclicked == false)
            {
                ((NNIG_Software)parentWindow).toolStripButtonNN.Enabled = true;
            }
        }

      
    }
}