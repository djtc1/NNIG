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
    public partial class NNSupervisedLearningAlg : Form
    {
        public NNIG_Software parentWindow;

        bool buttonokclicked;

        public NNSupervisedLearningAlg()
        {
            InitializeComponent();
        }


        private void listViewSupLearning_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxItemName.Text = listViewSupLearning.FocusedItem.Text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        { 
            if (textBoxItemName.Text == "")
            { 
                MessageBox.Show ("Must Choose Learning Algorithm");
            }
            else
            {
                if (listViewSupLearning.FocusedItem.Text == "Backpropagation")
                {
                    ((NNIG_Software)parentWindow).AccessToBackPropagationEditor = new BackPropagation();
                    ((NNIG_Software)parentWindow).AccessToBackPropagationEditor.MdiParent = parentWindow;
                    ((NNIG_Software)parentWindow).AccessToBackPropagationEditor.Show();
      
                    ((NNIG_Software)parentWindow).AccessToBackPropagationEditor.Location = new Point(0, 560);

                    ((NNIG_Software)parentWindow).toolStripButtonSupLearning.Enabled = false;


                }//end if 

                buttonokclicked = true;
            this.Close();
            }//end else

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxItemName.Text = "";

            this.Close();

            ((NNIG_Software)parentWindow).toolStripButtonSupLearning.Enabled = true;
        }

        private void listViewSupLearning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewSupLearning.SelectedItems != null)
            {

                if (listViewSupLearning.FocusedItem.Text == "Backpropagation")
                {
                    ((NNIG_Software)parentWindow).AccessToBackPropagationEditor = new BackPropagation();
                    ((NNIG_Software)parentWindow).AccessToBackPropagationEditor.MdiParent = parentWindow;
                    ((NNIG_Software)parentWindow).AccessToBackPropagationEditor.Show();
                    ((NNIG_Software)parentWindow).AccessToBackPropagationEditor.Location = new Point(0, 560);
                }

                ((NNIG_Software)parentWindow).toolStripButtonSupLearning.Enabled = false;
              
                buttonokclicked = true;
                
                this.Close();
              
            }
        }

        private void NNSupervisedLearningAlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing && buttonokclicked == false)
            {
                ((NNIG_Software)parentWindow).toolStripButtonSupLearning.Enabled = true;
            }
        }


    }
}