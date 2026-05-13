namespace NNIG_NeuralNetworkInterface
{
    partial class ActivationFunctionChooser
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
            this.radioButtonGaussiana = new System.Windows.Forms.RadioButton();
            this.radioButtonHeaviside = new System.Windows.Forms.RadioButton();
            this.radioButtonLinear = new System.Windows.Forms.RadioButton();
            this.radioButtonHypTan = new System.Windows.Forms.RadioButton();
            this.radioButtonLogistic = new System.Windows.Forms.RadioButton();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel_sigmoidHyperbolicT = new System.Windows.Forms.Panel();
            this.numEditsigHT = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.labelBeta = new System.Windows.Forms.Label();
            this.panel_param_gaussiana = new System.Windows.Forms.Panel();
            this.numEditStandarddeviation = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.labelStandardeviation = new System.Windows.Forms.Label();
            this.numEditMeanGaussiana = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.labelMeanGaussiana = new System.Windows.Forms.Label();
            this.panel_Linear_parameters = new System.Windows.Forms.Panel();
            this.numEditLinearCoef = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.labelLinearCoef = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_sigmoidHyperbolicT.SuspendLayout();
            this.panel_param_gaussiana.SuspendLayout();
            this.panel_Linear_parameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonGaussiana);
            this.groupBox1.Controls.Add(this.radioButtonHeaviside);
            this.groupBox1.Controls.Add(this.radioButtonLinear);
            this.groupBox1.Controls.Add(this.radioButtonHypTan);
            this.groupBox1.Controls.Add(this.radioButtonLogistic);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(162, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type:";
            // 
            // radioButtonGaussiana
            // 
            this.radioButtonGaussiana.AutoSize = true;
            this.radioButtonGaussiana.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGaussiana.Location = new System.Drawing.Point(7, 144);
            this.radioButtonGaussiana.Name = "radioButtonGaussiana";
            this.radioButtonGaussiana.Size = new System.Drawing.Size(91, 20);
            this.radioButtonGaussiana.TabIndex = 4;
            this.radioButtonGaussiana.TabStop = true;
            this.radioButtonGaussiana.Text = "Gaussiana";
            this.radioButtonGaussiana.UseVisualStyleBackColor = true;
            this.radioButtonGaussiana.CheckedChanged += new System.EventHandler(this.radioButtonGaussiana_CheckedChanged);
            // 
            // radioButtonHeaviside
            // 
            this.radioButtonHeaviside.AutoSize = true;
            this.radioButtonHeaviside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonHeaviside.Location = new System.Drawing.Point(7, 118);
            this.radioButtonHeaviside.Name = "radioButtonHeaviside";
            this.radioButtonHeaviside.Size = new System.Drawing.Size(88, 20);
            this.radioButtonHeaviside.TabIndex = 3;
            this.radioButtonHeaviside.TabStop = true;
            this.radioButtonHeaviside.Text = "Heaviside";
            this.radioButtonHeaviside.UseVisualStyleBackColor = true;
            this.radioButtonHeaviside.CheckedChanged += new System.EventHandler(this.radioButtonHeaviside_CheckedChanged);
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLinear.Location = new System.Drawing.Point(7, 92);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(63, 20);
            this.radioButtonLinear.TabIndex = 2;
            this.radioButtonLinear.TabStop = true;
            this.radioButtonLinear.Text = "Linear";
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            this.radioButtonLinear.CheckedChanged += new System.EventHandler(this.radioButtonLinear_CheckedChanged);
            // 
            // radioButtonHypTan
            // 
            this.radioButtonHypTan.AutoSize = true;
            this.radioButtonHypTan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonHypTan.Location = new System.Drawing.Point(7, 66);
            this.radioButtonHypTan.Name = "radioButtonHypTan";
            this.radioButtonHypTan.Size = new System.Drawing.Size(145, 20);
            this.radioButtonHypTan.TabIndex = 1;
            this.radioButtonHypTan.TabStop = true;
            this.radioButtonHypTan.Text = "Hyperbolic Tangent";
            this.radioButtonHypTan.UseVisualStyleBackColor = true;
            this.radioButtonHypTan.CheckedChanged += new System.EventHandler(this.radioButtonHyperbolicTangent_CheckedChanged);
            // 
            // radioButtonLogistic
            // 
            this.radioButtonLogistic.AutoSize = true;
            this.radioButtonLogistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLogistic.Location = new System.Drawing.Point(7, 40);
            this.radioButtonLogistic.Name = "radioButtonLogistic";
            this.radioButtonLogistic.Size = new System.Drawing.Size(72, 20);
            this.radioButtonLogistic.TabIndex = 0;
            this.radioButtonLogistic.TabStop = true;
            this.radioButtonLogistic.Text = "Logistic";
            this.radioButtonLogistic.UseVisualStyleBackColor = true;
            this.radioButtonLogistic.CheckedChanged += new System.EventHandler(this.radioButtonsigmoid_CheckedChanged);
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.zedGraphControl1);
            this.groupBoxPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPreview.Location = new System.Drawing.Point(181, 22);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxPreview.Size = new System.Drawing.Size(243, 188);
            this.groupBoxPreview.TabIndex = 1;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Preview";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsEnableHPan = false;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 22);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(230, 159);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel_sigmoidHyperbolicT);
            this.groupBox2.Controls.Add(this.panel_param_gaussiana);
            this.groupBox2.Controls.Add(this.panel_Linear_parameters);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(411, 88);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // panel_sigmoidHyperbolicT
            // 
            this.panel_sigmoidHyperbolicT.Controls.Add(this.numEditsigHT);
            this.panel_sigmoidHyperbolicT.Controls.Add(this.labelBeta);
            this.panel_sigmoidHyperbolicT.Location = new System.Drawing.Point(94, 20);
            this.panel_sigmoidHyperbolicT.Name = "panel_sigmoidHyperbolicT";
            this.panel_sigmoidHyperbolicT.Size = new System.Drawing.Size(200, 54);
            this.panel_sigmoidHyperbolicT.TabIndex = 4;
            this.panel_sigmoidHyperbolicT.Visible = false;
            // 
            // numEditsigHT
            // 
            this.numEditsigHT.AllowSpace = false;
            this.numEditsigHT.Location = new System.Drawing.Point(80, 11);
            this.numEditsigHT.Name = "numEditsigHT";
            this.numEditsigHT.Size = new System.Drawing.Size(77, 22);
            this.numEditsigHT.TabIndex = 1;
            this.numEditsigHT.Text = "1";
            this.numEditsigHT.Leave += new System.EventHandler(this.numEditsigHT_Leave);
            this.numEditsigHT.TextChanged += new System.EventHandler(this.numEditsigHT_TextChanged);
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(25, 14);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(39, 16);
            this.labelBeta.TabIndex = 0;
            this.labelBeta.Text = "Beta:";
            // 
            // panel_param_gaussiana
            // 
            this.panel_param_gaussiana.Controls.Add(this.numEditStandarddeviation);
            this.panel_param_gaussiana.Controls.Add(this.labelStandardeviation);
            this.panel_param_gaussiana.Controls.Add(this.numEditMeanGaussiana);
            this.panel_param_gaussiana.Controls.Add(this.labelMeanGaussiana);
            this.panel_param_gaussiana.Location = new System.Drawing.Point(11, 23);
            this.panel_param_gaussiana.Name = "panel_param_gaussiana";
            this.panel_param_gaussiana.Size = new System.Drawing.Size(351, 49);
            this.panel_param_gaussiana.TabIndex = 1;
            this.panel_param_gaussiana.Visible = false;
            // 
            // numEditStandarddeviation
            // 
            this.numEditStandarddeviation.AllowSpace = false;
            this.numEditStandarddeviation.Location = new System.Drawing.Point(283, 12);
            this.numEditStandarddeviation.Name = "numEditStandarddeviation";
            this.numEditStandarddeviation.Size = new System.Drawing.Size(58, 22);
            this.numEditStandarddeviation.TabIndex = 3;
            this.numEditStandarddeviation.Text = "1";
            this.numEditStandarddeviation.Leave += new System.EventHandler(this.numEditStandarddeviation_Leave);
            this.numEditStandarddeviation.TextChanged += new System.EventHandler(this.numEditStandarddeviation_TextChanged);
            // 
            // labelStandardeviation
            // 
            this.labelStandardeviation.AutoSize = true;
            this.labelStandardeviation.Location = new System.Drawing.Point(136, 15);
            this.labelStandardeviation.Name = "labelStandardeviation";
            this.labelStandardeviation.Size = new System.Drawing.Size(126, 16);
            this.labelStandardeviation.TabIndex = 2;
            this.labelStandardeviation.Text = "Standard Deviation:";
            // 
            // numEditMeanGaussiana
            // 
            this.numEditMeanGaussiana.AllowSpace = false;
            this.numEditMeanGaussiana.Location = new System.Drawing.Point(72, 11);
            this.numEditMeanGaussiana.Name = "numEditMeanGaussiana";
            this.numEditMeanGaussiana.Size = new System.Drawing.Size(58, 22);
            this.numEditMeanGaussiana.TabIndex = 1;
            this.numEditMeanGaussiana.Text = "0";
            this.numEditMeanGaussiana.Leave += new System.EventHandler(this.numEditMeanGaussiana_Leave);
            this.numEditMeanGaussiana.TextChanged += new System.EventHandler(this.numEditMeanGaussiana_TextChanged);
            // 
            // labelMeanGaussiana
            // 
            this.labelMeanGaussiana.AutoSize = true;
            this.labelMeanGaussiana.Location = new System.Drawing.Point(10, 15);
            this.labelMeanGaussiana.Name = "labelMeanGaussiana";
            this.labelMeanGaussiana.Size = new System.Drawing.Size(45, 16);
            this.labelMeanGaussiana.TabIndex = 0;
            this.labelMeanGaussiana.Text = "Mean:";
            // 
            // panel_Linear_parameters
            // 
            this.panel_Linear_parameters.Controls.Add(this.numEditLinearCoef);
            this.panel_Linear_parameters.Controls.Add(this.labelLinearCoef);
            this.panel_Linear_parameters.Location = new System.Drawing.Point(97, 20);
            this.panel_Linear_parameters.Name = "panel_Linear_parameters";
            this.panel_Linear_parameters.Size = new System.Drawing.Size(200, 49);
            this.panel_Linear_parameters.TabIndex = 0;
            this.panel_Linear_parameters.Visible = false;
            // 
            // numEditLinearCoef
            // 
            this.numEditLinearCoef.AllowSpace = false;
            this.numEditLinearCoef.Location = new System.Drawing.Point(80, 13);
            this.numEditLinearCoef.Name = "numEditLinearCoef";
            this.numEditLinearCoef.Size = new System.Drawing.Size(65, 22);
            this.numEditLinearCoef.TabIndex = 1;
            this.numEditLinearCoef.Text = "1.0";
            this.numEditLinearCoef.Leave += new System.EventHandler(this.numEditLinearCoef_Leave);
            this.numEditLinearCoef.TextChanged += new System.EventHandler(this.numEditLinearCoef_TextChanged);
            // 
            // labelLinearCoef
            // 
            this.labelLinearCoef.AutoSize = true;
            this.labelLinearCoef.Location = new System.Drawing.Point(22, 16);
            this.labelLinearCoef.Name = "labelLinearCoef";
            this.labelLinearCoef.Size = new System.Drawing.Size(39, 16);
            this.labelLinearCoef.TabIndex = 0;
            this.labelLinearCoef.Text = "Coef:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(349, 311);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.buttonOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.Location = new System.Drawing.Point(268, 311);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // ActivationFunctionChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(436, 342);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActivationFunctionChooser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Activation Function";
            this.Load += new System.EventHandler(this.ActivationFucntionChooser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel_sigmoidHyperbolicT.ResumeLayout(false);
            this.panel_sigmoidHyperbolicT.PerformLayout();
            this.panel_param_gaussiana.ResumeLayout(false);
            this.panel_param_gaussiana.PerformLayout();
            this.panel_Linear_parameters.ResumeLayout(false);
            this.panel_Linear_parameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonGaussiana;
        private System.Windows.Forms.RadioButton radioButtonHeaviside;
        private System.Windows.Forms.RadioButton radioButtonLinear;
        private System.Windows.Forms.RadioButton radioButtonHypTan;
        private System.Windows.Forms.RadioButton radioButtonLogistic;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel_Linear_parameters;

        private NNIG_NeuralNetworkInterface.numericTextBox numEditLinearCoef;
        //private CtrlLib.NumEdit numEditLinearCoef;
        
        private System.Windows.Forms.Label labelLinearCoef;
        private System.Windows.Forms.Panel panel_param_gaussiana;

        private NNIG_NeuralNetworkInterface.numericTextBox numEditMeanGaussiana;
        //private CtrlLib.NumEdit numEditMeanGaussiana;
        
        private System.Windows.Forms.Label labelMeanGaussiana;
        private System.Windows.Forms.Panel panel_sigmoidHyperbolicT;

        private NNIG_NeuralNetworkInterface.numericTextBox numEditStandarddeviation;
        //private CtrlLib.NumEdit numEditStandarddeviation;
        
        private System.Windows.Forms.Label labelStandardeviation;

        private NNIG_NeuralNetworkInterface.numericTextBox numEditsigHT;
        //private CtrlLib.NumEdit numEditsigHT;
        
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}