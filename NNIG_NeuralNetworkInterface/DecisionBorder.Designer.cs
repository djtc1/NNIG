namespace NNIG_NeuralNetworkInterface
{
    partial class DecisionBorder
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxVariY = new System.Windows.Forms.ComboBox();
            this.comboBoxVariableX = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonClearDecisionBorder = new System.Windows.Forms.Button();
            this.buttonShowDecisionBorder = new System.Windows.Forms.Button();
            this.numEditResolutionPoints = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.zedGraphControl1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(427, 340);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plot:";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsEnableHPan = false;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(7, 22);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(408, 309);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBoxVariY);
            this.groupBox2.Controls.Add(this.comboBoxVariableX);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(449, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(162, 155);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Variables:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show scatter\r\n plot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxVariY
            // 
            this.comboBoxVariY.FormattingEnabled = true;
            this.comboBoxVariY.Location = new System.Drawing.Point(35, 55);
            this.comboBoxVariY.Name = "comboBoxVariY";
            this.comboBoxVariY.Size = new System.Drawing.Size(116, 24);
            this.comboBoxVariY.TabIndex = 3;
            this.comboBoxVariY.SelectedIndexChanged += new System.EventHandler(this.comboBoxVariY_SelectedIndexChanged);
            // 
            // comboBoxVariableX
            // 
            this.comboBoxVariableX.FormattingEnabled = true;
            this.comboBoxVariableX.Location = new System.Drawing.Point(35, 25);
            this.comboBoxVariableX.Name = "comboBoxVariableX";
            this.comboBoxVariableX.Size = new System.Drawing.Size(116, 24);
            this.comboBoxVariableX.TabIndex = 2;
            this.comboBoxVariableX.SelectedIndexChanged += new System.EventHandler(this.comboBoxVariableX_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonClearDecisionBorder);
            this.groupBox3.Controls.Add(this.buttonShowDecisionBorder);
            this.groupBox3.Controls.Add(this.numEditResolutionPoints);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(449, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(162, 177);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Decision Border:";
            // 
            // buttonClearDecisionBorder
            // 
            this.buttonClearDecisionBorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonClearDecisionBorder.Location = new System.Drawing.Point(12, 126);
            this.buttonClearDecisionBorder.Name = "buttonClearDecisionBorder";
            this.buttonClearDecisionBorder.Size = new System.Drawing.Size(134, 41);
            this.buttonClearDecisionBorder.TabIndex = 3;
            this.buttonClearDecisionBorder.Text = "Clear decision\r\n border";
            this.buttonClearDecisionBorder.UseVisualStyleBackColor = true;
            this.buttonClearDecisionBorder.Click += new System.EventHandler(this.buttonClearDecisionBorder_Click);
            // 
            // buttonShowDecisionBorder
            // 
            this.buttonShowDecisionBorder.Location = new System.Drawing.Point(12, 80);
            this.buttonShowDecisionBorder.Name = "buttonShowDecisionBorder";
            this.buttonShowDecisionBorder.Size = new System.Drawing.Size(134, 42);
            this.buttonShowDecisionBorder.TabIndex = 2;
            this.buttonShowDecisionBorder.Text = "Show decision\r\n border";
            this.buttonShowDecisionBorder.UseVisualStyleBackColor = true;
            this.buttonShowDecisionBorder.Click += new System.EventHandler(this.buttonShowDecisionBorder_Click);
            // 
            // numEditResolutionPoints
            // 
            this.numEditResolutionPoints.AllowSpace = false;
            this.numEditResolutionPoints.Location = new System.Drawing.Point(61, 45);
            this.numEditResolutionPoints.Name = "numEditResolutionPoints";
            this.numEditResolutionPoints.Size = new System.Drawing.Size(32, 22);
            this.numEditResolutionPoints.TabIndex = 1;
            this.numEditResolutionPoints.TextChanged += new System.EventHandler(this.numEditResolutionPoints_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Number of Resolution\r\n Points:";
            // 
            // DecisionBorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(622, 362);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "DecisionBorder";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Data Plot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DecisionBorder_FormClosing);
            this.Load += new System.EventHandler(this.DecisionBorder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxVariY;
        private System.Windows.Forms.ComboBox comboBoxVariableX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private numericTextBox numEditResolutionPoints;
        private System.Windows.Forms.Button buttonShowDecisionBorder;
        private System.Windows.Forms.Button buttonClearDecisionBorder;
    }
}