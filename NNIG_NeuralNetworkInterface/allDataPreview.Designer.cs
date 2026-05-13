namespace NNIG_NeuralNetworkInterface
{
    partial class allDataPreview
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInputOutput
            // 
            this.dataGridViewInputOutput.AllowUserToAddRows = false;
            this.dataGridViewInputOutput.AllowUserToDeleteRows = false;
            this.dataGridViewInputOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInputOutput.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewInputOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInputOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInputOutput.EnableHeadersVisualStyles = false;
            this.dataGridViewInputOutput.Location = new System.Drawing.Point(12, 5);
            this.dataGridViewInputOutput.Name = "dataGridViewInputOutput";
            this.dataGridViewInputOutput.ReadOnly = true;
            this.dataGridViewInputOutput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewInputOutput.Size = new System.Drawing.Size(367, 258);
            this.dataGridViewInputOutput.TabIndex = 0;
            this.dataGridViewInputOutput.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInputOutput_CellContentClick);
            // 
            // allDataPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(388, 275);
            this.Controls.Add(this.dataGridViewInputOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "allDataPreview";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Data Preview";
            this.Load += new System.EventHandler(this.allDataPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInputOutput;

    }
}