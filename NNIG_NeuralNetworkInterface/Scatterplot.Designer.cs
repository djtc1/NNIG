namespace NNIG_NeuralNetworkInterface
{
    partial class Scatterplot
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonShowScatterplot = new System.Windows.Forms.Button();
            this.comboBoxYAxis = new System.Windows.Forms.ComboBox();
            this.comboBoxXAxis = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(275, 205);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonShowScatterplot);
            this.groupBox1.Controls.Add(this.comboBoxYAxis);
            this.groupBox1.Controls.Add(this.comboBoxXAxis);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(287, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(166, 146);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Variables:";
            // 
            // buttonShowScatterplot
            // 
            this.buttonShowScatterplot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonShowScatterplot.Location = new System.Drawing.Point(44, 89);
            this.buttonShowScatterplot.Name = "buttonShowScatterplot";
            this.buttonShowScatterplot.Size = new System.Drawing.Size(80, 43);
            this.buttonShowScatterplot.TabIndex = 4;
            this.buttonShowScatterplot.Text = "Show Scatterplot";
            this.buttonShowScatterplot.UseVisualStyleBackColor = true;
            this.buttonShowScatterplot.Click += new System.EventHandler(this.buttonShowScatterplot_Click);
            // 
            // comboBoxYAxis
            // 
            this.comboBoxYAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYAxis.FormattingEnabled = true;
            this.comboBoxYAxis.Location = new System.Drawing.Point(30, 51);
            this.comboBoxYAxis.Name = "comboBoxYAxis";
            this.comboBoxYAxis.Size = new System.Drawing.Size(121, 21);
            this.comboBoxYAxis.TabIndex = 3;
            this.comboBoxYAxis.SelectedIndexChanged += new System.EventHandler(this.comboBoxYAxis_SelectedIndexChanged);
            // 
            // comboBoxXAxis
            // 
            this.comboBoxXAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxXAxis.FormattingEnabled = true;
            this.comboBoxXAxis.Location = new System.Drawing.Point(30, 19);
            this.comboBoxXAxis.Name = "comboBoxXAxis";
            this.comboBoxXAxis.Size = new System.Drawing.Size(121, 21);
            this.comboBoxXAxis.TabIndex = 2;
            this.comboBoxXAxis.SelectedIndexChanged += new System.EventHandler(this.comboBoxXAxis_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // Scatterplot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(461, 224);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Scatterplot";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Scatter Plot";
            this.Load += new System.EventHandler(this.Scatterplot_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxXAxis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonShowScatterplot;
        private System.Windows.Forms.ComboBox comboBoxYAxis;
    }
}