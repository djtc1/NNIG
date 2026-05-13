namespace NNIG_NeuralNetworkInterface
{
    partial class LayerProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.neuron_list = new System.Windows.Forms.ListBox();
            this.neuron_prop = new System.Windows.Forms.GroupBox();
            this.nnigNeuronGUI1 = new NNIG_NeuralNetworkInterface.GraphicalNeuron();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.but_choos_af = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_out_size = new System.Windows.Forms.TextBox();
            this.tb_in_size = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_r_max = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.tb_r_min = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.but_rand_all_w = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.graphicalNeuron1 = new NNIG_NeuralNetworkInterface.GraphicalNeuron();
            this.textBoxActivationFunction = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.neuron_prop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.neuron_list);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(155, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neurons:";
            // 
            // neuron_list
            // 
            this.neuron_list.FormattingEnabled = true;
            this.neuron_list.ItemHeight = 16;
            this.neuron_list.Items.AddRange(new object[] {
            "no layer loaded",
            ""});
            this.neuron_list.Location = new System.Drawing.Point(21, 24);
            this.neuron_list.Name = "neuron_list";
            this.neuron_list.Size = new System.Drawing.Size(112, 164);
            this.neuron_list.TabIndex = 0;
            this.neuron_list.SelectedIndexChanged += new System.EventHandler(this.neuron_list_SelectedIndexChanged);
            // 
            // neuron_prop
            // 
            this.neuron_prop.Controls.Add(this.nnigNeuronGUI1);
            this.neuron_prop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.neuron_prop.Location = new System.Drawing.Point(182, 113);
            this.neuron_prop.Name = "neuron_prop";
            this.neuron_prop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuron_prop.Size = new System.Drawing.Size(455, 313);
            this.neuron_prop.TabIndex = 1;
            this.neuron_prop.TabStop = false;
            this.neuron_prop.Text = "Neuron Properties: ";
            // 
            // nnigNeuronGUI1
            // 
            this.nnigNeuronGUI1.BackColor = System.Drawing.Color.White;
            this.nnigNeuronGUI1.Location = new System.Drawing.Point(18, 28);
            this.nnigNeuronGUI1.Margin = new System.Windows.Forms.Padding(4);
            this.nnigNeuronGUI1.Name = "nnigNeuronGUI1";
            this.nnigNeuronGUI1.Size = new System.Drawing.Size(424, 266);
            this.nnigNeuronGUI1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxActivationFunction);
            this.groupBox2.Controls.Add(this.but_choos_af);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(155, 109);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activation Function:";
            // 
            // but_choos_af
            // 
            this.but_choos_af.Location = new System.Drawing.Point(18, 21);
            this.but_choos_af.Name = "but_choos_af";
            this.but_choos_af.Size = new System.Drawing.Size(112, 58);
            this.but_choos_af.TabIndex = 0;
            this.but_choos_af.Text = "Choose Layer Activation Function";
            this.but_choos_af.UseVisualStyleBackColor = true;
            this.but_choos_af.Click += new System.EventHandler(this.but_choos_af_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_out_size);
            this.groupBox3.Controls.Add(this.tb_in_size);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(18, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(221, 89);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Layer Properties";
            // 
            // tb_out_size
            // 
            this.tb_out_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_out_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_out_size.Location = new System.Drawing.Point(147, 51);
            this.tb_out_size.Name = "tb_out_size";
            this.tb_out_size.ReadOnly = true;
            this.tb_out_size.Size = new System.Drawing.Size(53, 22);
            this.tb_out_size.TabIndex = 3;
            this.tb_out_size.Text = "0";
            // 
            // tb_in_size
            // 
            this.tb_in_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_in_size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_in_size.Location = new System.Drawing.Point(147, 26);
            this.tb_in_size.Name = "tb_in_size";
            this.tb_in_size.ReadOnly = true;
            this.tb_in_size.Size = new System.Drawing.Size(53, 22);
            this.tb_in_size.TabIndex = 2;
            this.tb_in_size.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output vector size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input vector size:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_r_max);
            this.groupBox4.Controls.Add(this.tb_r_min);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.but_rand_all_w);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(255, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox4.Size = new System.Drawing.Size(382, 89);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Randomization of All Layer Weights: ";
            // 
            // tb_r_max
            // 
            this.tb_r_max.Location = new System.Drawing.Point(283, 54);
            this.tb_r_max.Name = "tb_r_max";
            this.tb_r_max.Size = new System.Drawing.Size(64, 22);
            this.tb_r_max.TabIndex = 6;
            this.tb_r_max.Text = "0.3";
            // 
            // tb_r_min
            // 
            this.tb_r_min.Location = new System.Drawing.Point(283, 22);
            this.tb_r_min.Name = "tb_r_min";
            this.tb_r_min.Size = new System.Drawing.Size(64, 22);
            this.tb_r_min.TabIndex = 5;
            this.tb_r_min.Text = "-0.3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Maximum value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Minimum value:";
            // 
            // but_rand_all_w
            // 
            this.but_rand_all_w.Location = new System.Drawing.Point(24, 26);
            this.but_rand_all_w.Name = "but_rand_all_w";
            this.but_rand_all_w.Size = new System.Drawing.Size(135, 50);
            this.but_rand_all_w.TabIndex = 2;
            this.but_rand_all_w.Text = "Initialize Random Weights";
            this.but_rand_all_w.UseVisualStyleBackColor = true;
            this.but_rand_all_w.Click += new System.EventHandler(this.but_rand_all_w_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.graphicalNeuron1);
            this.groupBox5.Font = new System.Drawing.Font("ZWAdobeF", 8.25F);
            this.groupBox5.Location = new System.Drawing.Point(2, 94);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox5.Size = new System.Drawing.Size(548, 285);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Neuron Properties: ";
            // 
            // graphicalNeuron1
            // 
            this.graphicalNeuron1.BackColor = System.Drawing.Color.White;
            this.graphicalNeuron1.Location = new System.Drawing.Point(16, 24);
            this.graphicalNeuron1.Margin = new System.Windows.Forms.Padding(4);
            this.graphicalNeuron1.Name = "graphicalNeuron1";
            this.graphicalNeuron1.Size = new System.Drawing.Size(424, 256);
            this.graphicalNeuron1.TabIndex = 0;
            // 
            // textBoxActivationFunction
            // 
            this.textBoxActivationFunction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxActivationFunction.Location = new System.Drawing.Point(7, 82);
            this.textBoxActivationFunction.Name = "textBoxActivationFunction";
            this.textBoxActivationFunction.ReadOnly = true;
            this.textBoxActivationFunction.Size = new System.Drawing.Size(142, 22);
            this.textBoxActivationFunction.TabIndex = 1;
            // 
            // LayerProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(657, 448);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.neuron_prop);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LayerProperties";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Layer Properties";
            this.groupBox1.ResumeLayout(false);
            this.neuron_prop.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox neuron_list;
        private System.Windows.Forms.GroupBox neuron_prop;
        private NNIG_NeuralNetworkInterface.GraphicalNeuron nnigNeuronGUI1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button but_choos_af;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_in_size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_out_size;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private NNIG_NeuralNetworkInterface.GraphicalNeuron graphicalNeuron1;
        private System.Windows.Forms.Button but_rand_all_w;
        private NNIG_NeuralNetworkInterface.numericTextBox tb_r_min;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private NNIG_NeuralNetworkInterface.numericTextBox tb_r_max;
        private System.Windows.Forms.TextBox textBoxActivationFunction;
    }
}