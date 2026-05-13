namespace NNIG_NeuralNetworkInterface
{
    partial class NNIG_Software
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NNIG_Software));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonInput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNN = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSupLearning = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonclassificationMatrix = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecisionBorder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonErrorGraph = new System.Windows.Forms.ToolStripButton();
            this.viewNNOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonErrorSurface = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonContinue = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.toolStripButtonHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAbout,
            this.toolStripButtonHelp,
            this.toolStripSeparator4,
            this.toolStripSeparator3,
            this.toolStripButtonInput,
            this.toolStripButtonNN,
            this.toolStripButtonSupLearning,
            this.toolStripButtonclassificationMatrix,
            this.toolStripButtonDecisionBorder,
            this.toolStripButtonErrorGraph,
            this.viewNNOutput,
            this.toolStripButtonErrorSurface,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButtonRun,
            this.toolStripButtonContinue});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(108, 640);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStripComponents";
            // 
            // toolStripButtonInput
            // 
            this.toolStripButtonInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripButtonInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonInput.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInput.Image")));
            this.toolStripButtonInput.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInput.Name = "toolStripButtonInput";
            this.toolStripButtonInput.Size = new System.Drawing.Size(106, 19);
            this.toolStripButtonInput.Text = "INPUT";
            this.toolStripButtonInput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonInput.Click += new System.EventHandler(this.toolStripButtonInput_Click);
            // 
            // toolStripButtonNN
            // 
            this.toolStripButtonNN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonNN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonNN.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNN.Image")));
            this.toolStripButtonNN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonNN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNN.Name = "toolStripButtonNN";
            this.toolStripButtonNN.Size = new System.Drawing.Size(106, 30);
            this.toolStripButtonNN.Text = "NN\r\n ARCHITECTURE";
            this.toolStripButtonNN.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButtonNN.Click += new System.EventHandler(this.toolStripButtonNN_Click);
            // 
            // toolStripButtonSupLearning
            // 
            this.toolStripButtonSupLearning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSupLearning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonSupLearning.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSupLearning.Image")));
            this.toolStripButtonSupLearning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSupLearning.Name = "toolStripButtonSupLearning";
            this.toolStripButtonSupLearning.Size = new System.Drawing.Size(106, 30);
            this.toolStripButtonSupLearning.Text = "SUPERVISED \r\n LEARNING";
            this.toolStripButtonSupLearning.Click += new System.EventHandler(this.toolStripButtonSupLearning_Click);
            // 
            // toolStripButtonclassificationMatrix
            // 
            this.toolStripButtonclassificationMatrix.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonclassificationMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonclassificationMatrix.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonclassificationMatrix.Image")));
            this.toolStripButtonclassificationMatrix.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonclassificationMatrix.Name = "toolStripButtonclassificationMatrix";
            this.toolStripButtonclassificationMatrix.Size = new System.Drawing.Size(106, 30);
            this.toolStripButtonclassificationMatrix.Text = "CLASSIFICATION\n\rMATRIX";
            this.toolStripButtonclassificationMatrix.Click += new System.EventHandler(this.toolStripButtonclassificationMatrix_Click);
            // 
            // toolStripButtonDecisionBorder
            // 
            this.toolStripButtonDecisionBorder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDecisionBorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonDecisionBorder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecisionBorder.Image")));
            this.toolStripButtonDecisionBorder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecisionBorder.Name = "toolStripButtonDecisionBorder";
            this.toolStripButtonDecisionBorder.Size = new System.Drawing.Size(106, 30);
            this.toolStripButtonDecisionBorder.Text = "DECISION\r\n BORDER";
            this.toolStripButtonDecisionBorder.Click += new System.EventHandler(this.toolStripButtonDecisionBorder_Click);
            // 
            // toolStripButtonErrorGraph
            // 
            this.toolStripButtonErrorGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonErrorGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonErrorGraph.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonErrorGraph.Image")));
            this.toolStripButtonErrorGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonErrorGraph.Name = "toolStripButtonErrorGraph";
            this.toolStripButtonErrorGraph.Size = new System.Drawing.Size(106, 17);
            this.toolStripButtonErrorGraph.Text = "ERROR GRAPH";
            this.toolStripButtonErrorGraph.Click += new System.EventHandler(this.toolStripButtonErrorGraph_Click);
            // 
            // viewNNOutput
            // 
            this.viewNNOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewNNOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.viewNNOutput.Image = ((System.Drawing.Image)(resources.GetObject("viewNNOutput.Image")));
            this.viewNNOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewNNOutput.Name = "viewNNOutput";
            this.viewNNOutput.Size = new System.Drawing.Size(106, 17);
            this.viewNNOutput.Text = "NN OUTPUT";
            this.viewNNOutput.Click += new System.EventHandler(this.viewNNOutput_Click);
            // 
            // toolStripButtonErrorSurface
            // 
            this.toolStripButtonErrorSurface.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonErrorSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonErrorSurface.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonErrorSurface.Image")));
            this.toolStripButtonErrorSurface.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonErrorSurface.Name = "toolStripButtonErrorSurface";
            this.toolStripButtonErrorSurface.Size = new System.Drawing.Size(106, 17);
            this.toolStripButtonErrorSurface.Text = "ERROR SURFACE";
            this.toolStripButtonErrorSurface.Click += new System.EventHandler(this.toolStripButtonErrorSurface_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(106, 6);
            // 
            // toolStripButtonRun
            // 
            this.toolStripButtonRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonRun.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRun.Image")));
            this.toolStripButtonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRun.Name = "toolStripButtonRun";
            this.toolStripButtonRun.Size = new System.Drawing.Size(106, 17);
            this.toolStripButtonRun.Text = "START";
            this.toolStripButtonRun.Click += new System.EventHandler(this.toolStripButtonRun_Click);
            // 
            // toolStripButtonContinue
            // 
            this.toolStripButtonContinue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonContinue.Enabled = false;
            this.toolStripButtonContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonContinue.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonContinue.Image")));
            this.toolStripButtonContinue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonContinue.Name = "toolStripButtonContinue";
            this.toolStripButtonContinue.Size = new System.Drawing.Size(106, 17);
            this.toolStripButtonContinue.Text = "CONTINUE";
            this.toolStripButtonContinue.Click += new System.EventHandler(this.toolStripButtonContinue_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // toolStripButtonHelp
            // 
            this.toolStripButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHelp.Image")));
            this.toolStripButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHelp.Name = "toolStripButtonHelp";
            this.toolStripButtonHelp.Size = new System.Drawing.Size(106, 19);
            this.toolStripButtonHelp.Text = "HELP";
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(106, 19);
            this.toolStripButtonAbout.Text = "ABOUT";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(106, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(106, 6);
            // 
            // NNIG_Software
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(979, 640);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "NNIG_Software";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NNIG Software Beta1";
            this.Resize += new System.EventHandler(this.NNIG_Software_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NNIG_Software_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStripButton toolStripButtonInput;
        public System.Windows.Forms.ToolStripButton toolStripButtonNN;
        public System.Windows.Forms.ToolStripButton toolStripButtonSupLearning;
        public System.Windows.Forms.ToolStripButton toolStripButtonclassificationMatrix;
        public System.Windows.Forms.ToolStripButton toolStripButtonErrorGraph;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripButton toolStripButtonRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton toolStripButtonContinue;
        public System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripButton toolStripButtonHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton toolStripButtonDecisionBorder;
        public System.Windows.Forms.ToolStripButton viewNNOutput;
        public System.Windows.Forms.ToolStripButton toolStripButtonErrorSurface;


    }
}

