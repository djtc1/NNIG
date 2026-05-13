namespace NNIG_NeuralNetworkInterface
{
    partial class BackPropagation
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
            this.comboBoxBackAlgo = new System.Windows.Forms.ComboBox();
            this.groupboxparameters = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_iter = new System.Windows.Forms.TextBox();
            this.tb_err = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxSaveAllResults = new System.Windows.Forms.CheckBox();
            this.tb_max_err = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.tb_maxiter = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.tb_beta = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.tb_alpha = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupboxparameters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxBackAlgo
            // 
            this.comboBoxBackAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBackAlgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBackAlgo.FormattingEnabled = true;
            this.comboBoxBackAlgo.Items.AddRange(new object[] {
            "Batch Backpropagation",
            "Sequential Backpropagation"});
            this.comboBoxBackAlgo.Location = new System.Drawing.Point(18, 13);
            this.comboBoxBackAlgo.Name = "comboBoxBackAlgo";
            this.comboBoxBackAlgo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxBackAlgo.Size = new System.Drawing.Size(250, 28);
            this.comboBoxBackAlgo.TabIndex = 0;
            // 
            // groupboxparameters
            // 
            this.groupboxparameters.Controls.Add(this.groupBox1);
            this.groupboxparameters.Controls.Add(this.button1);
            this.groupboxparameters.Controls.Add(this.checkBoxSaveAllResults);
            this.groupboxparameters.Controls.Add(this.tb_max_err);
            this.groupboxparameters.Controls.Add(this.tb_maxiter);
            this.groupboxparameters.Controls.Add(this.tb_beta);
            this.groupboxparameters.Controls.Add(this.tb_alpha);
            this.groupboxparameters.Controls.Add(this.label6);
            this.groupboxparameters.Controls.Add(this.label4);
            this.groupboxparameters.Controls.Add(this.label2);
            this.groupboxparameters.Controls.Add(this.label1);
            this.groupboxparameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupboxparameters.Location = new System.Drawing.Point(18, 48);
            this.groupboxparameters.Name = "groupboxparameters";
            this.groupboxparameters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupboxparameters.Size = new System.Drawing.Size(250, 248);
            this.groupboxparameters.TabIndex = 1;
            this.groupboxparameters.TabStop = false;
            this.groupboxparameters.Text = "Parameters :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_iter);
            this.groupBox1.Controls.Add(this.tb_err);
            this.groupBox1.Location = new System.Drawing.Point(0, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 73);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Square error:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total of iterations done: ";
            // 
            // tb_iter
            // 
            this.tb_iter.Location = new System.Drawing.Point(171, 14);
            this.tb_iter.Name = "tb_iter";
            this.tb_iter.ReadOnly = true;
            this.tb_iter.Size = new System.Drawing.Size(62, 22);
            this.tb_iter.TabIndex = 1;
            this.tb_iter.Text = "0";
            // 
            // tb_err
            // 
            this.tb_err.Location = new System.Drawing.Point(171, 38);
            this.tb_err.Name = "tb_err";
            this.tb_err.ReadOnly = true;
            this.tb_err.Size = new System.Drawing.Size(62, 22);
            this.tb_err.TabIndex = 2;
            this.tb_err.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 14;
            this.button1.Text = "Reset to default";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxSaveAllResults
            // 
            this.checkBoxSaveAllResults.AutoSize = true;
            this.checkBoxSaveAllResults.Location = new System.Drawing.Point(8, 222);
            this.checkBoxSaveAllResults.Name = "checkBoxSaveAllResults";
            this.checkBoxSaveAllResults.Size = new System.Drawing.Size(119, 20);
            this.checkBoxSaveAllResults.TabIndex = 13;
            this.checkBoxSaveAllResults.Text = "Save all values";
            this.checkBoxSaveAllResults.UseVisualStyleBackColor = true;
            // 
            // tb_max_err
            // 
            this.tb_max_err.AllowSpace = false;
            this.tb_max_err.Location = new System.Drawing.Point(172, 104);
            this.tb_max_err.Name = "tb_max_err";
            this.tb_max_err.Size = new System.Drawing.Size(61, 22);
            this.tb_max_err.TabIndex = 11;
            this.tb_max_err.Text = "0";
            this.tb_max_err.Leave += new System.EventHandler(this.tb_max_err_Leave);
            // 
            // tb_maxiter
            // 
            this.tb_maxiter.AllowSpace = false;
            this.tb_maxiter.Location = new System.Drawing.Point(172, 77);
            this.tb_maxiter.Name = "tb_maxiter";
            this.tb_maxiter.Size = new System.Drawing.Size(62, 22);
            this.tb_maxiter.TabIndex = 9;
            this.tb_maxiter.Text = "0";
            this.tb_maxiter.Leave += new System.EventHandler(this.tb_maxiter_Leave);
            // 
            // tb_beta
            // 
            this.tb_beta.AllowSpace = false;
            this.tb_beta.Location = new System.Drawing.Point(172, 50);
            this.tb_beta.Name = "tb_beta";
            this.tb_beta.Size = new System.Drawing.Size(62, 22);
            this.tb_beta.TabIndex = 7;
            this.tb_beta.Text = "0";
            this.tb_beta.Leave += new System.EventHandler(this.tb_beta_Leave);
            // 
            // tb_alpha
            // 
            this.tb_alpha.AllowSpace = false;
            this.tb_alpha.Location = new System.Drawing.Point(172, 23);
            this.tb_alpha.Name = "tb_alpha";
            this.tb_alpha.Size = new System.Drawing.Size(62, 22);
            this.tb_alpha.TabIndex = 6;
            this.tb_alpha.Text = "0";
            this.tb_alpha.Leave += new System.EventHandler(this.tb_alpha_Leave);
            this.tb_alpha.TextChanged += new System.EventHandler(this.tb_alpha_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Min sum square error:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Epochs in one run: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Momentum:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Learning Rate:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(191, 302);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 15;
            this.buttonOk.Text = "Submit";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // BackPropagation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(286, 330);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupboxparameters);
            this.Controls.Add(this.comboBoxBackAlgo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BackPropagation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Backpropagation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackPropagation_FormClosing);
            this.Load += new System.EventHandler(this.BackPropagation_Load);
            this.groupboxparameters.ResumeLayout(false);
            this.groupboxparameters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBackAlgo;
        private System.Windows.Forms.GroupBox groupboxparameters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private NNIG_NeuralNetworkInterface.numericTextBox tb_alpha;
        private NNIG_NeuralNetworkInterface.numericTextBox tb_beta;
        private NNIG_NeuralNetworkInterface.numericTextBox tb_max_err;
        private System.Windows.Forms.TextBox tb_err;
        private NNIG_NeuralNetworkInterface.numericTextBox tb_maxiter;
        private System.Windows.Forms.TextBox tb_iter;
        private System.Windows.Forms.CheckBox checkBoxSaveAllResults;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}