namespace NNIG_NeuralNetworkInterface
{
    partial class OutputPreview
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
            this.dataGridViewInputOutput = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxST = new System.Windows.Forms.TextBox();
            this.labelSD = new System.Windows.Forms.Label();
            this.textBoxMSE = new System.Windows.Forms.TextBox();
            this.labelMSE = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputOutput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewInputOutput
            // 
            this.dataGridViewInputOutput.AllowUserToAddRows = false;
            this.dataGridViewInputOutput.AllowUserToDeleteRows = false;
            this.dataGridViewInputOutput.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewInputOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInputOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInputOutput.EnableHeadersVisualStyles = false;
            this.dataGridViewInputOutput.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewInputOutput.Name = "dataGridViewInputOutput";
            this.dataGridViewInputOutput.ReadOnly = true;
            this.dataGridViewInputOutput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewInputOutput.Size = new System.Drawing.Size(378, 265);
            this.dataGridViewInputOutput.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewInputOutput);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(395, 292);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NN Outputs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxST);
            this.groupBox2.Controls.Add(this.labelSD);
            this.groupBox2.Controls.Add(this.textBoxMSE);
            this.groupBox2.Controls.Add(this.labelMSE);
            this.groupBox2.Location = new System.Drawing.Point(413, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(142, 101);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics:";
            // 
            // textBoxST
            // 
            this.textBoxST.Location = new System.Drawing.Point(84, 59);
            this.textBoxST.Name = "textBoxST";
            this.textBoxST.ReadOnly = true;
            this.textBoxST.Size = new System.Drawing.Size(52, 20);
            this.textBoxST.TabIndex = 3;
            // 
            // labelSD
            // 
            this.labelSD.AutoSize = true;
            this.labelSD.Location = new System.Drawing.Point(6, 59);
            this.labelSD.Name = "labelSD";
            this.labelSD.Size = new System.Drawing.Size(55, 26);
            this.labelSD.TabIndex = 2;
            this.labelSD.Text = "Errors St.\r\nDeviation:";
            // 
            // textBoxMSE
            // 
            this.textBoxMSE.Location = new System.Drawing.Point(84, 27);
            this.textBoxMSE.Name = "textBoxMSE";
            this.textBoxMSE.ReadOnly = true;
            this.textBoxMSE.Size = new System.Drawing.Size(52, 20);
            this.textBoxMSE.TabIndex = 1;
            // 
            // labelMSE
            // 
            this.labelMSE.AutoSize = true;
            this.labelMSE.Location = new System.Drawing.Point(6, 30);
            this.labelMSE.Name = "labelMSE";
            this.labelMSE.Size = new System.Drawing.Size(36, 13);
            this.labelMSE.TabIndex = 0;
            this.labelMSE.Text = "MSE :";
            // 
            // OutputPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(564, 322);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "OutputPreview";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Output Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OutputPreview_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputOutput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInputOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelMSE;
        private System.Windows.Forms.Label labelSD;
        public System.Windows.Forms.TextBox textBoxMSE;
        public System.Windows.Forms.TextBox textBoxST;
    }
}