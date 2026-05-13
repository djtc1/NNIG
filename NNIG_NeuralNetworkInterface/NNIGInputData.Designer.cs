namespace NNIG_NeuralNetworkInterface
{
    partial class NNIGINPUTDATA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxViewData = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelnumberofpatterns = new System.Windows.Forms.Label();
            this.labelnumvariables = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonshowscatter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewInputOutput = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metricOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelfile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelInputNormalizationLimite = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.numtextBoxNormalizationRightLimitInterval = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numtextBoxNormalizationLimitInterval = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxScalingData = new System.Windows.Forms.ComboBox();
            this.checkBoxNormalizeData = new System.Windows.Forms.CheckBox();
            this.checkBoxRandomizeInitialData = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxCrossValidation = new System.Windows.Forms.CheckBox();
            this.checkBoxMaintainRepresentativity = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numEditTest = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.numEditTrain = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxsubsets = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.groupBoxViewData.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputOutput)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelInputNormalizationLimite.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(-2, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip.Size = new System.Drawing.Size(516, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AutoSize = false;
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // groupBoxViewData
            // 
            this.groupBoxViewData.Controls.Add(this.groupBox3);
            this.groupBoxViewData.Controls.Add(this.buttonshowscatter);
            this.groupBoxViewData.Controls.Add(this.groupBox2);
            this.groupBoxViewData.Controls.Add(this.dataGridViewInputOutput);
            this.groupBoxViewData.Controls.Add(this.labelfile);
            this.groupBoxViewData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxViewData.Location = new System.Drawing.Point(5, 27);
            this.groupBoxViewData.Name = "groupBoxViewData";
            this.groupBoxViewData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxViewData.Size = new System.Drawing.Size(454, 224);
            this.groupBoxViewData.TabIndex = 1;
            this.groupBoxViewData.TabStop = false;
            this.groupBoxViewData.Text = "Data";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelnumberofpatterns);
            this.groupBox3.Controls.Add(this.labelnumvariables);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(256, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 58);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Dimensions";
            // 
            // labelnumberofpatterns
            // 
            this.labelnumberofpatterns.AutoSize = true;
            this.labelnumberofpatterns.Location = new System.Drawing.Point(118, 37);
            this.labelnumberofpatterns.Name = "labelnumberofpatterns";
            this.labelnumberofpatterns.Size = new System.Drawing.Size(0, 15);
            this.labelnumberofpatterns.TabIndex = 3;
            // 
            // labelnumvariables
            // 
            this.labelnumvariables.AutoSize = true;
            this.labelnumvariables.Location = new System.Drawing.Point(129, 21);
            this.labelnumvariables.Name = "labelnumvariables";
            this.labelnumvariables.Size = new System.Drawing.Size(0, 15);
            this.labelnumvariables.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Number of patterns:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Number of variables:";
            // 
            // buttonshowscatter
            // 
            this.buttonshowscatter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.buttonshowscatter.Location = new System.Drawing.Point(298, 165);
            this.buttonshowscatter.Name = "buttonshowscatter";
            this.buttonshowscatter.Size = new System.Drawing.Size(97, 51);
            this.buttonshowscatter.TabIndex = 4;
            this.buttonshowscatter.Text = "Show\n\rScatterplot";
            this.buttonshowscatter.UseVisualStyleBackColor = true;
            this.buttonshowscatter.Click += new System.EventHandler(this.buttonshowscatter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(256, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 58);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caption";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Continuous Output";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Location = new System.Drawing.Point(60, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 14);
            this.panel3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nominal Output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(60, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 14);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 15);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewInputOutput
            // 
            this.dataGridViewInputOutput.AllowUserToAddRows = false;
            this.dataGridViewInputOutput.AllowUserToDeleteRows = false;
            this.dataGridViewInputOutput.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewInputOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInputOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewInputOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInputOutput.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInputOutput.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewInputOutput.EnableHeadersVisualStyles = false;
            this.dataGridViewInputOutput.Location = new System.Drawing.Point(10, 21);
            this.dataGridViewInputOutput.MultiSelect = false;
            this.dataGridViewInputOutput.Name = "dataGridViewInputOutput";
            this.dataGridViewInputOutput.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInputOutput.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewInputOutput.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewInputOutput.Size = new System.Drawing.Size(240, 195);
            this.dataGridViewInputOutput.TabIndex = 1;
            this.dataGridViewInputOutput.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewInputOutput_ColumnHeaderMouseClick);
            this.dataGridViewInputOutput.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewInputOutput_Scroll);
            this.dataGridViewInputOutput.DoubleClick += new System.EventHandler(this.dataGridViewInputOutput_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.metricOutputToolStripMenuItem,
            this.ignoreToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening_1);
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.inputToolStripMenuItem.Text = "Input";
            this.inputToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.outputToolStripMenuItem.Text = " Nominal Output";
            this.outputToolStripMenuItem.Click += new System.EventHandler(this.outputToolStripMenuItem_Click);
            // 
            // metricOutputToolStripMenuItem
            // 
            this.metricOutputToolStripMenuItem.Name = "metricOutputToolStripMenuItem";
            this.metricOutputToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.metricOutputToolStripMenuItem.Text = "Continuous Output";
            this.metricOutputToolStripMenuItem.Click += new System.EventHandler(this.metricOutputToolStripMenuItem_Click);
            // 
            // ignoreToolStripMenuItem
            // 
            this.ignoreToolStripMenuItem.Name = "ignoreToolStripMenuItem";
            this.ignoreToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ignoreToolStripMenuItem.Text = "Ignore";
            this.ignoreToolStripMenuItem.Click += new System.EventHandler(this.ignoreToolStripMenuItem_Click);
            // 
            // labelfile
            // 
            this.labelfile.AutoSize = true;
            this.labelfile.Location = new System.Drawing.Point(260, 19);
            this.labelfile.Name = "labelfile";
            this.labelfile.Size = new System.Drawing.Size(67, 15);
            this.labelfile.TabIndex = 0;
            this.labelfile.Text = "File Name:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelInputNormalizationLimite);
            this.groupBox1.Controls.Add(this.comboBoxScalingData);
            this.groupBox1.Controls.Add(this.checkBoxNormalizeData);
            this.groupBox1.Controls.Add(this.checkBoxRandomizeInitialData);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(227, 141);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preprocessing";
            // 
            // panelInputNormalizationLimite
            // 
            this.panelInputNormalizationLimite.Controls.Add(this.label7);
            this.panelInputNormalizationLimite.Controls.Add(this.numtextBoxNormalizationRightLimitInterval);
            this.panelInputNormalizationLimite.Controls.Add(this.label6);
            this.panelInputNormalizationLimite.Controls.Add(this.numtextBoxNormalizationLimitInterval);
            this.panelInputNormalizationLimite.Controls.Add(this.label5);
            this.panelInputNormalizationLimite.Location = new System.Drawing.Point(27, 88);
            this.panelInputNormalizationLimite.Name = "panelInputNormalizationLimite";
            this.panelInputNormalizationLimite.Size = new System.Drawing.Size(182, 30);
            this.panelInputNormalizationLimite.TabIndex = 3;
            this.panelInputNormalizationLimite.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "]";
            // 
            // numtextBoxNormalizationRightLimitInterval
            // 
            this.numtextBoxNormalizationRightLimitInterval.AllowSpace = false;
            this.numtextBoxNormalizationRightLimitInterval.Location = new System.Drawing.Point(110, 3);
            this.numtextBoxNormalizationRightLimitInterval.Name = "numtextBoxNormalizationRightLimitInterval";
            this.numtextBoxNormalizationRightLimitInterval.Size = new System.Drawing.Size(31, 21);
            this.numtextBoxNormalizationRightLimitInterval.TabIndex = 3;
            this.numtextBoxNormalizationRightLimitInterval.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = ";";
            // 
            // numtextBoxNormalizationLimitInterval
            // 
            this.numtextBoxNormalizationLimitInterval.AllowSpace = false;
            this.numtextBoxNormalizationLimitInterval.Location = new System.Drawing.Point(66, 3);
            this.numtextBoxNormalizationLimitInterval.Name = "numtextBoxNormalizationLimitInterval";
            this.numtextBoxNormalizationLimitInterval.Size = new System.Drawing.Size(32, 21);
            this.numtextBoxNormalizationLimitInterval.TabIndex = 1;
            this.numtextBoxNormalizationLimitInterval.Text = "-1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Interval = [";
            // 
            // comboBoxScalingData
            // 
            this.comboBoxScalingData.FormattingEnabled = true;
            this.comboBoxScalingData.Items.AddRange(new object[] {
            "Range Scaling",
            "Mean Centering",
            "Standardization"});
            this.comboBoxScalingData.Location = new System.Drawing.Point(118, 52);
            this.comboBoxScalingData.Name = "comboBoxScalingData";
            this.comboBoxScalingData.Size = new System.Drawing.Size(103, 23);
            this.comboBoxScalingData.TabIndex = 2;
            this.comboBoxScalingData.SelectedIndexChanged += new System.EventHandler(this.comboBoxScalingData_SelectedIndexChanged);
            // 
            // checkBoxNormalizeData
            // 
            this.checkBoxNormalizeData.AutoSize = true;
            this.checkBoxNormalizeData.Location = new System.Drawing.Point(9, 55);
            this.checkBoxNormalizeData.Name = "checkBoxNormalizeData";
            this.checkBoxNormalizeData.Size = new System.Drawing.Size(112, 19);
            this.checkBoxNormalizeData.TabIndex = 1;
            this.checkBoxNormalizeData.Text = "Normalize Data";
            this.checkBoxNormalizeData.UseVisualStyleBackColor = true;
            this.checkBoxNormalizeData.CheckedChanged += new System.EventHandler(this.checkBoxNormalizeData_CheckedChanged);
            // 
            // checkBoxRandomizeInitialData
            // 
            this.checkBoxRandomizeInitialData.AutoSize = true;
            this.checkBoxRandomizeInitialData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxRandomizeInitialData.Location = new System.Drawing.Point(9, 25);
            this.checkBoxRandomizeInitialData.Name = "checkBoxRandomizeInitialData";
            this.checkBoxRandomizeInitialData.Size = new System.Drawing.Size(151, 19);
            this.checkBoxRandomizeInitialData.TabIndex = 0;
            this.checkBoxRandomizeInitialData.Text = "Randomize Initial Data";
            this.checkBoxRandomizeInitialData.UseVisualStyleBackColor = false;
            this.checkBoxRandomizeInitialData.CheckedChanged += new System.EventHandler(this.checkBoxRandomizeInitialData_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxCrossValidation);
            this.groupBox4.Controls.Add(this.checkBoxMaintainRepresentativity);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.numEditTest);
            this.groupBox4.Controls.Add(this.numEditTrain);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.comboBoxsubsets);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(238, 257);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox4.Size = new System.Drawing.Size(221, 104);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Train/Test";
            // 
            // checkBoxCrossValidation
            // 
            this.checkBoxCrossValidation.AutoSize = true;
            this.checkBoxCrossValidation.Location = new System.Drawing.Point(4, 81);
            this.checkBoxCrossValidation.Name = "checkBoxCrossValidation";
            this.checkBoxCrossValidation.Size = new System.Drawing.Size(115, 19);
            this.checkBoxCrossValidation.TabIndex = 7;
            this.checkBoxCrossValidation.Text = "Cross-Validation";
            this.checkBoxCrossValidation.UseVisualStyleBackColor = true;
            this.checkBoxCrossValidation.CheckedChanged += new System.EventHandler(this.checkBoxCrossValidation_CheckedChanged);
            // 
            // checkBoxMaintainRepresentativity
            // 
            this.checkBoxMaintainRepresentativity.AutoSize = true;
            this.checkBoxMaintainRepresentativity.Location = new System.Drawing.Point(4, 60);
            this.checkBoxMaintainRepresentativity.Name = "checkBoxMaintainRepresentativity";
            this.checkBoxMaintainRepresentativity.Size = new System.Drawing.Size(189, 19);
            this.checkBoxMaintainRepresentativity.TabIndex = 6;
            this.checkBoxMaintainRepresentativity.Text = "Maintain class representativity";
            this.checkBoxMaintainRepresentativity.UseVisualStyleBackColor = true;
            this.checkBoxMaintainRepresentativity.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(129, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Test:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Train:";
            // 
            // numEditTest
            // 
            this.numEditTest.AllowSpace = false;
            this.numEditTest.Location = new System.Drawing.Point(134, 32);
            this.numEditTest.Name = "numEditTest";
            this.numEditTest.Size = new System.Drawing.Size(31, 21);
            this.numEditTest.TabIndex = 3;
            this.numEditTest.Leave += new System.EventHandler(this.numEditTest_Leave);
            this.numEditTest.TextChanged += new System.EventHandler(this.numEditTest_TextChanged);
            // 
            // numEditTrain
            // 
            this.numEditTrain.AllowSpace = false;
            this.numEditTrain.Location = new System.Drawing.Point(93, 32);
            this.numEditTrain.Name = "numEditTrain";
            this.numEditTrain.Size = new System.Drawing.Size(31, 21);
            this.numEditTrain.TabIndex = 2;
            this.numEditTrain.Leave += new System.EventHandler(this.numEditTrain_Leave);
            this.numEditTrain.TextChanged += new System.EventHandler(this.numEditTrain_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Subsets:";
            // 
            // comboBoxsubsets
            // 
            this.comboBoxsubsets.FormattingEnabled = true;
            this.comboBoxsubsets.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxsubsets.Location = new System.Drawing.Point(4, 30);
            this.comboBoxsubsets.Name = "comboBoxsubsets";
            this.comboBoxsubsets.Size = new System.Drawing.Size(78, 23);
            this.comboBoxsubsets.TabIndex = 0;
            this.comboBoxsubsets.SelectedIndexChanged += new System.EventHandler(this.comboBoxsubsets_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Apply_Click);
            // 
            // NNIGINPUTDATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(462, 402);
            this.Controls.Add(this.groupBoxViewData);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NNIGINPUTDATA";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Input Data";
            this.Click += new System.EventHandler(this.NNIGInputDataStructureGUI_Click);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NNIGINPUTDATA_FormClosing);
            this.Load += new System.EventHandler(this.NNIGINPUTDATA_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxViewData.ResumeLayout(false);
            this.groupBoxViewData.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputOutput)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelInputNormalizationLimite.ResumeLayout(false);
            this.panelInputNormalizationLimite.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxViewData;
        private System.Windows.Forms.Label labelfile;
        private System.Windows.Forms.DataGridView dataGridViewInputOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelnumvariables;
        private System.Windows.Forms.Label labelnumberofpatterns;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxRandomizeInitialData;
        private System.Windows.Forms.Panel panelInputNormalizationLimite;
        private System.Windows.Forms.ComboBox comboBoxScalingData;
        private System.Windows.Forms.CheckBox checkBoxNormalizeData;
        private NNIG_NeuralNetworkInterface.numericTextBox numtextBoxNormalizationLimitInterval;
        private System.Windows.Forms.Label label5;
        private NNIG_NeuralNetworkInterface.numericTextBox numtextBoxNormalizationRightLimitInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private NNIG_NeuralNetworkInterface.numericTextBox numEditTest;
        private NNIG_NeuralNetworkInterface.numericTextBox numEditTrain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxsubsets;
        private System.Windows.Forms.CheckBox checkBoxCrossValidation;
        private System.Windows.Forms.CheckBox checkBoxMaintainRepresentativity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metricOutputToolStripMenuItem;
        private System.Windows.Forms.Button buttonshowscatter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
    }
}