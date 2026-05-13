using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NNIG_NeuralNetworkInterface
{
    public partial class NewLayerForm : Form
    {
       
        #region Variables
       
        protected bool valid = false;
       
         #endregion

        #region Public Access to the Class
        
        public int Nb_Neurons
        {
            set { num_neur.Value = value; }
            get { return (int)num_neur.Value; }
        }

        public bool IsValid
        {
            get { return valid; }
        }

        #endregion

        public NewLayerForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            
            valid = true;
            
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            valid = false;
            this.Close();
        }


    }
}