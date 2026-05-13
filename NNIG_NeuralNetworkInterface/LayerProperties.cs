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
    public partial class LayerProperties : Form
    {
        protected Layer layer = null;

        public LayerProperties(Layer l, string LayerName)
        {
            InitializeComponent();

            layer = l;

            this.Text = LayerName;
        }

        public void setLayer(Layer l)
        {
            layer = l;
            neuron_list.Items.Clear();
            for (int i = 0; i < l.N_Neurons; i++)
                neuron_list.Items.Add("Neuron " + i);
            neuron_list.SelectedIndex = 0;
            
            nnigNeuronGUI1.setNeuron(l[0]);
            
            this.tb_in_size.Text = "" + l.N_Inputs;
            this.tb_out_size.Text = "" + l.N_Neurons;
            this.textBoxActivationFunction.Text = "" + l.F.Name + " Activation Function";
        }

        private void neuron_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layer != null)
            {
                nnigNeuronGUI1.setNeuron(layer[neuron_list.SelectedIndex]);

                nnigNeuronGUI1.Refresh();
            }
        }

        private void but_rand_all_w_Click(object sender, EventArgs e)
        {
            if (layer != null)
            {
                double min, max;
                try
                {
                    min = double.Parse(this.tb_r_min.Text.Replace(",", "."));
                    max = double.Parse(this.tb_r_max.Text.Replace(",", "."));

                }
                catch
                {
                    min = -0.3;
                    max = 0.3;
                    tb_r_min.Text = "" + min;
                    tb_r_max.Text = "" + max;
                }

                layer.setRandomizationInterval(min, max);
                layer.randomizeAll();

            }

           nnigNeuronGUI1.Refresh();

        }

        private void but_choos_af_Click(object sender, EventArgs e)
        {
            ActivationFunctionChooser ac = new ActivationFunctionChooser();

            ac.ShowDialog();

            if (ac.ChooseOK && layer != null)
            {
                layer.setActivationFunction(ac.Afunction);
                this.textBoxActivationFunction.Text = "" + ac.Afunction.Name + " Activation Function";
               
                nnigNeuronGUI1.setNeuron(layer[neuron_list.SelectedIndex]);
            }

            nnigNeuronGUI1.Refresh();

        }
    }
}