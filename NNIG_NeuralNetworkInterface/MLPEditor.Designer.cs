namespace NNIG_NeuralNetworkInterface
{
    partial class MLPEditor
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
            this.list_layers = new System.Windows.Forms.ListView();
            this.c_layer = new System.Windows.Forms.ColumnHeader();
            this.c_n_neuron = new System.Windows.Forms.ColumnHeader();
            this.c_n_activationFunction = new System.Windows.Forms.ColumnHeader();
            this.groupBoxlayerproperties = new System.Windows.Forms.GroupBox();
            this.buttonDeleteLayer = new System.Windows.Forms.Button();
            this.buttonEditLayer = new System.Windows.Forms.Button();
            this.buttonInsertLayer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonWeightFromFile = new System.Windows.Forms.Button();
            this.num_max = new System.Windows.Forms.NumericUpDown();
            this.num_min = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialogWeights = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxlayerproperties.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_min)).BeginInit();
            this.SuspendLayout();
            // 
            // list_layers
            // 
            this.list_layers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.list_layers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list_layers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c_layer,
            this.c_n_neuron,
            this.c_n_activationFunction});
            this.list_layers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_layers.ForeColor = System.Drawing.Color.SteelBlue;
            this.list_layers.FullRowSelect = true;
            this.list_layers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_layers.Location = new System.Drawing.Point(12, 12);
            this.list_layers.MultiSelect = false;
            this.list_layers.Name = "list_layers";
            this.list_layers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.list_layers.Size = new System.Drawing.Size(360, 128);
            this.list_layers.TabIndex = 0;
            this.list_layers.UseCompatibleStateImageBehavior = false;
            this.list_layers.View = System.Windows.Forms.View.Details;
            this.list_layers.ItemActivate += new System.EventHandler(this.list_layers_ItemActivate);
            this.list_layers.SelectedIndexChanged += new System.EventHandler(this.list_layers_SelectedIndexChanged);
            // 
            // c_layer
            // 
            this.c_layer.Text = "Layer";
            this.c_layer.Width = 70;
            // 
            // c_n_neuron
            // 
            this.c_n_neuron.Text = "Number of Neurons";
            this.c_n_neuron.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_n_neuron.Width = 145;
            // 
            // c_n_activationFunction
            // 
            this.c_n_activationFunction.Text = "Activation Function";
            this.c_n_activationFunction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_n_activationFunction.Width = 145;
            // 
            // groupBoxlayerproperties
            // 
            this.groupBoxlayerproperties.Controls.Add(this.buttonDeleteLayer);
            this.groupBoxlayerproperties.Controls.Add(this.buttonEditLayer);
            this.groupBoxlayerproperties.Controls.Add(this.buttonInsertLayer);
            this.groupBoxlayerproperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxlayerproperties.Location = new System.Drawing.Point(380, 6);
            this.groupBoxlayerproperties.Name = "groupBoxlayerproperties";
            this.groupBoxlayerproperties.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxlayerproperties.Size = new System.Drawing.Size(123, 134);
            this.groupBoxlayerproperties.TabIndex = 1;
            this.groupBoxlayerproperties.TabStop = false;
            this.groupBoxlayerproperties.Text = "NN Architecture :";
            // 
            // buttonDeleteLayer
            // 
            this.buttonDeleteLayer.Enabled = false;
            this.buttonDeleteLayer.Location = new System.Drawing.Point(12, 95);
            this.buttonDeleteLayer.Name = "buttonDeleteLayer";
            this.buttonDeleteLayer.Size = new System.Drawing.Size(98, 35);
            this.buttonDeleteLayer.TabIndex = 2;
            this.buttonDeleteLayer.Text = "Delete Layer";
            this.buttonDeleteLayer.UseVisualStyleBackColor = true;
            this.buttonDeleteLayer.Click += new System.EventHandler(this.buttonDeleteLayer_Click);
            // 
            // buttonEditLayer
            // 
            this.buttonEditLayer.Enabled = false;
            this.buttonEditLayer.Location = new System.Drawing.Point(12, 56);
            this.buttonEditLayer.Name = "buttonEditLayer";
            this.buttonEditLayer.Size = new System.Drawing.Size(98, 35);
            this.buttonEditLayer.TabIndex = 1;
            this.buttonEditLayer.Text = "Edit Layer";
            this.buttonEditLayer.UseVisualStyleBackColor = true;
            this.buttonEditLayer.Click += new System.EventHandler(this.buttonEditLayer_Click);
            // 
            // buttonInsertLayer
            // 
            this.buttonInsertLayer.Location = new System.Drawing.Point(12, 18);
            this.buttonInsertLayer.Name = "buttonInsertLayer";
            this.buttonInsertLayer.Size = new System.Drawing.Size(98, 35);
            this.buttonInsertLayer.TabIndex = 0;
            this.buttonInsertLayer.Text = "Insert Layer";
            this.buttonInsertLayer.UseVisualStyleBackColor = true;
            this.buttonInsertLayer.Click += new System.EventHandler(this.buttonInsertLayer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonOK);
            this.groupBox1.Controls.Add(this.buttonWeightFromFile);
            this.groupBox1.Controls.Add(this.num_max);
            this.groupBox1.Controls.Add(this.num_min);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(490, 112);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neurons Parameters:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(379, 74);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "Submit";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonWeightFromFile
            // 
            this.buttonWeightFromFile.Location = new System.Drawing.Point(304, 21);
            this.buttonWeightFromFile.Name = "buttonWeightFromFile";
            this.buttonWeightFromFile.Size = new System.Drawing.Size(179, 27);
            this.buttonWeightFromFile.TabIndex = 6;
            this.buttonWeightFromFile.Text = "Initialize Weights From File";
            this.buttonWeightFromFile.UseVisualStyleBackColor = true;
            this.buttonWeightFromFile.Click += new System.EventHandler(this.buttonWeightFromFile_Click);
            // 
            // num_max
            // 
            this.num_max.DecimalPlaces = 2;
            this.num_max.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_max.Location = new System.Drawing.Point(215, 78);
            this.num_max.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_max.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.num_max.Name = "num_max";
            this.num_max.Size = new System.Drawing.Size(55, 22);
            this.num_max.TabIndex = 5;
            this.num_max.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            // 
            // num_min
            // 
            this.num_min.DecimalPlaces = 2;
            this.num_min.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_min.Location = new System.Drawing.Point(215, 50);
            this.num_min.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_min.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.num_min.Name = "num_min";
            this.num_min.Size = new System.Drawing.Size(56, 22);
            this.num_min.TabIndex = 4;
            this.num_min.Value = new decimal(new int[] {
            3,
            0,
            0,
            -2147418112});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Maximum :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minimum : ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Initialize Random Weights";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 81);
            this.button3.TabIndex = 0;
            this.button3.Text = "Choose NN Activation Function ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialogWeights
            // 
            this.openFileDialogWeights.FileName = "openFileDialog1";
            // 
            // MLPEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(514, 271);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxlayerproperties);
            this.Controls.Add(this.list_layers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MLPEditor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "MultiLayer Perceptron Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MLPEditor_FormClosing);
            this.groupBoxlayerproperties.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_min)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView list_layers;
        private System.Windows.Forms.ColumnHeader c_layer;
        private System.Windows.Forms.ColumnHeader c_n_neuron;
        private System.Windows.Forms.ColumnHeader c_n_activationFunction;
        private System.Windows.Forms.GroupBox groupBoxlayerproperties;
        private System.Windows.Forms.Button buttonInsertLayer;
        private System.Windows.Forms.Button buttonEditLayer;
        private System.Windows.Forms.Button buttonDeleteLayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_max;
        private System.Windows.Forms.NumericUpDown num_min;
        private System.Windows.Forms.Button buttonWeightFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogWeights;
        private System.Windows.Forms.Button buttonOK;
    }
}