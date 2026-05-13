using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;

namespace NNIG_NeuralNetworkInterface
{
    public partial class MLPEditor : Form
    {

        #region Variables

        protected NeuralNetwork nn;

        protected bool IOlocked = false;

        protected int l_ins, l_outs;

       #endregion


        public NeuralNetwork Neural_Network
        {
            get { return nn; }
            set { nn = value; refreshAll(); }
        }


        public void lockNetworkIO(int inputs, int outputs) //guadar o número de input's e output's
        {
            l_ins = inputs;
            l_outs = outputs;
            IOlocked = true;
        }


        public MLPEditor()
        {
            InitializeComponent();
        }


        public void refreshAll()
        {
            if (nn != null)
            {
                string[] s = new String[3];

                list_layers.Items.Clear();

                s[0] = "Input Layer";
                s[1] = nn.N_Inputs.ToString();
                s[2] = "";
                list_layers.Items.Add(new ListViewItem(s));

                for (int i = 0; i < nn.N_Layers; i++) //refresh list view -- arquitectura da rede
                {
                    if (nn.N_Layers == 1) s[0] = "Output layer";
                    else if (i == nn.N_Layers - 1) s[0] = "Output layer";
                    else s[0] = "Hidden layer " + (i + 1);
                    s[1] = nn[i].N_Neurons + " neuron(s)";
                    s[2] = nn[i].F.Name;

                    list_layers.Items.Add(new ListViewItem(s));
                }
            }
        }



        private void list_layers_ItemActivate(object sender, EventArgs e)
        {
            string LayerName = "";

            if (nn != null && list_layers.SelectedIndices.Count != 0)
            {
                if (list_layers.SelectedIndices[0] == 0)//The first layer don't have processing units
                {
                    return;
                }
                if (list_layers.SelectedIndices[0] > 0 && list_layers.SelectedIndices[0] < list_layers.Items.Count - 1)
                {
                    LayerName = "Hidden Layer" + list_layers.SelectedIndices[0].ToString();
                }
                else if (list_layers.SelectedIndices[0] == list_layers.Items.Count - 1)
                {
                    LayerName = "Output Layer";
                }

                LayerProperties LayerProp = new LayerProperties(nn[list_layers.SelectedIndices[0] - 1], LayerName);
                

                LayerProp.setLayer(nn[list_layers.SelectedIndices[0] - 1]);
                LayerProp.ShowDialog();

            }

            refreshAll();

        }


        private void buttonInsertLayer_Click(object sender, EventArgs e)
        {
            NewLayerForm f = new NewLayerForm();
            f.Text = "New Layer";
            
            f.ShowDialog();
            f.Location = new Point(600, 320);
            if (f.IsValid)
            {
                if (nn == null)//Não existir dados carregados
                {
                    MessageBox.Show("You must choose first the data file.");

                }
                else
                {
                    nn.insertFirstHiddenLayer(f.Nb_Neurons);
                }
            }
            buttonEditLayer.Enabled = false;
            buttonDeleteLayer.Enabled = false;
            this.refreshAll();

        }

        private void buttonEditLayer_Click(object sender, EventArgs e)
        {
            if (list_layers.SelectedIndices.Count != 0 && list_layers.SelectedIndices[0] != nn.N_Layers && list_layers.SelectedIndices[0] != 0)
            {
                NewLayerForm f = new NewLayerForm();
                f.Text = "Edit Layer";
                f.Nb_Neurons = nn[list_layers.SelectedIndices[0]].N_Neurons;
                f.ShowDialog();
                if (f.IsValid)
                    nn.editlayer(list_layers.SelectedIndices[0] - 1, f.Nb_Neurons);
            }

            buttonEditLayer.Enabled = false;
            buttonDeleteLayer.Enabled = false;
            this.refreshAll();

        }

        private void buttonDeleteLayer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list_layers.SelectedIndices.Count; i++)
            {
                if (list_layers.SelectedIndices[i] != nn.N_Layers && list_layers.SelectedIndices[i] != 0)
                    nn.removeLayer(list_layers.SelectedIndices[i] - 1);
            }
            buttonEditLayer.Enabled = false;
            buttonDeleteLayer.Enabled = false;
            this.refreshAll();

        }

        private void button3_Click(object sender, EventArgs e)//choose activation function
        {
            if (nn != null)
            {

                ActivationFunctionChooser f = new ActivationFunctionChooser();

                f.ShowDialog();

                if (f.ChooseOK)
                {
                    nn.setActivationFunction(f.Afunction);


                }
            }

            refreshAll();
        }

        private void button2_Click(object sender, EventArgs e)//randomize
        {
            if (nn != null)
            {
                nn.setRandomizationInterval((double)this.num_min.Value, (double)this.num_max.Value);
                nn.randomizeAll();

            }

        }


        private void buttonWeightFromFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialogWeights.ShowDialog();

            if (dr != DialogResult.OK)
                return;


            FileStream FileName = new FileStream(openFileDialogWeights.FileName, FileMode.Open, FileAccess.Read);

            StreamReader Sr = new StreamReader(FileName);

            string stext = Sr.ReadToEnd();

            Sr.Close();
            FileName.Close();


            #region Extract double Matrix from text

            //compute matrix size
            //get number of lines

            char[] myDelimiters = { '\n' };
            char[] myDelimiters1 = { ';' };



            string[] MatrixStrings = stext.Split(myDelimiters);

            //get number of columns


            int NumberOfLines = MatrixStrings.Length;
            int NumerberOfColumns = MatrixStrings[0].Split(myDelimiters1).Length;


            int TotalNumberofNeurons = 0;

            for (int i = 0; i < nn.N_Layers; i++)
            {
                TotalNumberofNeurons += nn[i].N_Neurons;
            }


            if (NumberOfLines != TotalNumberofNeurons)
            {
                MessageBox.Show("Please check the weights file. The file you choosed does not match the nn arquitecture!", "ERROR", MessageBoxButtons.OK);
                return;

            }
            else
            {
                int nlayers = 0, nneurons = 0, nsinapses = 0;

                //extract each line of strings
                foreach (string st in MatrixStrings)
                {
                    if (nneurons >= nn[nlayers].N_Neurons)
                    {
                        nlayers++;
                        nneurons = 0;
                    }
                    //extract each value of each  line
                    string[] tmpSt = st.Split(myDelimiters1);

                    if (tmpSt.GetLength(0) != nn[nlayers].N_Inputs + 1)
                    {
                        MessageBox.Show("Please check the weights file. The file you choosed does not match the nn arquitecture!", "ERROR", MessageBoxButtons.OK);
                        return;
                    }
                 
                    foreach (string st2 in tmpSt)
                    {
                        if (nsinapses < nn[nlayers][nneurons].N_Inputs)
                        {
                            nn[nlayers][nneurons][nsinapses] = double.Parse(st2);

                        }
                        else
                        {
                            nn[nlayers][nneurons].Threshold = double.Parse(st2);
                        }
                        nsinapses++;
                    }
                    nneurons++;
                    nsinapses = 0;
                }



            #endregion
            }

        }
        private void MLPEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                
                DialogResult buttonclose = MessageBox.Show("Do you want to leave?", "MultiLayer Perceptron Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (buttonclose.Equals(DialogResult.No))
                {
                    e.Cancel = true;
                }
                else
                { 
                    ((NNIG_Software)MdiParent).toolStripButtonNN.Enabled = true;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ArrayList InitialWeights = new ArrayList();

            ArrayList NeuronWeights;

            if (nn == null)
            {
                MessageBox.Show("Please check your options for the neural nertwork arquitecture", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                for (int j = 0; j < nn.N_Layers; j++)
                {
                    for (int k = 0; k < nn[j].N_Neurons; k++)
                    {
                        NeuronWeights = new ArrayList();

                        for (int i = 0; i < nn[j][k].N_Inputs + 1; i++)
                        {
                            if (i != nn[j][k].N_Inputs)
                            {
                                NeuronWeights.Add(nn[j][k][i]);
                            }
                            else
                            {
                                NeuronWeights.Add(nn[j][k].Threshold);
                            }
                        }


                        InitialWeights.Add(NeuronWeights);
                    }
                }//end for

                ((NNIG_Software)MdiParent).NNInitialWeights = InitialWeights;

                ((NNIG_Software)MdiParent).NeuralNet = this.nn;

                ((NNIG_Software)MdiParent).RunButtonCliked = false;
                ((NNIG_Software)MdiParent).toolStripButtonContinue.Enabled = false;
            }
        }

        private void list_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_layers.SelectedIndices.Count == 0)
            {
                buttonEditLayer.Enabled = false;
                buttonDeleteLayer.Enabled = false;
            }
            else
            {
                buttonEditLayer.Enabled = true;
                buttonDeleteLayer.Enabled = true;
            }

        }
    }
}
    