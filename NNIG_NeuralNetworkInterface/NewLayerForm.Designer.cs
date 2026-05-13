namespace NNIG_NeuralNetworkInterface
{
    partial class NewLayerForm
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
            this.labelNumbN = new System.Windows.Forms.Label();
            this.num_neur = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_neur)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumbN
            // 
            this.labelNumbN.AutoSize = true;
            this.labelNumbN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumbN.Location = new System.Drawing.Point(28, 30);
            this.labelNumbN.Name = "labelNumbN";
            this.labelNumbN.Size = new System.Drawing.Size(127, 16);
            this.labelNumbN.TabIndex = 0;
            this.labelNumbN.Text = "Number of Neurons:";
            // 
            // num_neur
            // 
            this.num_neur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_neur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_neur.Location = new System.Drawing.Point(169, 27);
            this.num_neur.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.num_neur.Name = "num_neur";
            this.num_neur.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.num_neur.Size = new System.Drawing.Size(48, 22);
            this.num_neur.TabIndex = 1;
            this.num_neur.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonOk.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.buttonOk.FlatAppearance.BorderSize = 2;
            this.buttonOk.Location = new System.Drawing.Point(142, 85);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCancel.Location = new System.Drawing.Point(28, 85);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // NewLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(240, 122);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.num_neur);
            this.Controls.Add(this.labelNumbN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewLayerForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "New Layer Form";
            ((System.ComponentModel.ISupportInitialize)(this.num_neur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumbN;
        private System.Windows.Forms.NumericUpDown num_neur;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}