using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;

namespace NNIG_NeuralNetworkInterface
{
    public partial class GraphicalNeuron : UserControl
    {
        #region Variaveis

        protected Neuron neu = null;
        protected int totalHeight = 200;
        
        #endregion
 

        public GraphicalNeuron()
        {
            InitializeComponent();
        }

        #region Public access to the class

        public int TotalHeight
        {
            get { return totalHeight; }
        }

        public void setNeuron(Neuron n)
        {
            neu = n;
        }

        #endregion

        private void GraphicalNeuron_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
           
            Brush b = new SolidBrush(Color.Black);
            Pen p = new Pen(b, 1);
            Font ft = new Font("Verdana", 10);

            if (neu != null)
            {

                int dy = -vScrollBar1.Value;

                int tot = neu.N_Inputs + 2;
                int mil = (30 * tot + 60) / 2;

                for (int i = 2; i < tot; i++)
                {
                    g.DrawString("" + Math.Round(neu[i - 2], 5), ft, b, 120, i * 30 - 15 + dy);
                    g.DrawLine(p, 60, 30 * i + dy, 180, 30 * i + dy);
                    g.DrawString("W", ft, b, 60, i * 30 - 15 + dy);
                    g.DrawLine(p, 180, 30 * i + dy, 300, mil + dy);

                }
                g.DrawString("" + Math.Round(neu.Threshold, 5), ft, b, 120, tot * 30 - 15 + 10 + dy);
                g.DrawLine(p, 60, 30 * tot + 10 + dy, 180, 30 * tot + 10 + dy);
                g.DrawString("1", ft, b, 30, tot * 30 + dy);
                g.DrawString("W(0)", ft, b, 60, tot * 30 + dy - 5);
                g.DrawLine(p, 180, 30 * tot + dy + 10, 300, mil + dy);


                if (30 * tot + 10 - 200 > 0) {vScrollBar1.Maximum = 30 * tot + 10 - 200; vScrollBar1.Visible = true; }
                else { vScrollBar1.Value = 0; vScrollBar1.Visible = false; }



               pictureBox1.Left = 280;
               pictureBox1.Top = mil - 50 + dy;

                totalHeight = 30 * tot + 50;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.Refresh();
        }




    }
}
