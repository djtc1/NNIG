namespace Chart3DLib
{
    partial class Chart3D
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whileRotatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyDrawAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawChartAndAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImage = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem,
            this.qualityToolStripMenuItem,
            this.whileRotatingToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(156, 70);
            this.menu.Opening += new System.ComponentModel.CancelEventHandler(this.menu_Opening);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // qualityToolStripMenuItem
            // 
            this.qualityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highToolStripMenuItem,
            this.lowToolStripMenuItem});
            this.qualityToolStripMenuItem.Name = "qualityToolStripMenuItem";
            this.qualityToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.qualityToolStripMenuItem.Text = "Quality";
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.highToolStripMenuItem.Text = "High";
            this.highToolStripMenuItem.Click += new System.EventHandler(this.highToolStripMenuItem_Click);
            // 
            // lowToolStripMenuItem
            // 
            this.lowToolStripMenuItem.Name = "lowToolStripMenuItem";
            this.lowToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.lowToolStripMenuItem.Text = "Low";
            this.lowToolStripMenuItem.Click += new System.EventHandler(this.lowToolStripMenuItem_Click);
            // 
            // whileRotatingToolStripMenuItem
            // 
            this.whileRotatingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlyDrawAxisToolStripMenuItem,
            this.drawChartAndAxisToolStripMenuItem});
            this.whileRotatingToolStripMenuItem.Name = "whileRotatingToolStripMenuItem";
            this.whileRotatingToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.whileRotatingToolStripMenuItem.Text = "While Rotating";
            // 
            // onlyDrawAxisToolStripMenuItem
            // 
            this.onlyDrawAxisToolStripMenuItem.Name = "onlyDrawAxisToolStripMenuItem";
            this.onlyDrawAxisToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.onlyDrawAxisToolStripMenuItem.Text = "Only Draw Axis";
            this.onlyDrawAxisToolStripMenuItem.Click += new System.EventHandler(this.onlyDrawAxisToolStripMenuItem_Click);
            // 
            // drawChartAndAxisToolStripMenuItem
            // 
            this.drawChartAndAxisToolStripMenuItem.Name = "drawChartAndAxisToolStripMenuItem";
            this.drawChartAndAxisToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.drawChartAndAxisToolStripMenuItem.Text = "Draw Chart and Axis";
            this.drawChartAndAxisToolStripMenuItem.Click += new System.EventHandler(this.drawChartAndAxisToolStripMenuItem_Click);
            // 
            // saveImage
            // 
            this.saveImage.FileName = "chart";
            this.saveImage.Filter = "Png|*.png|Jpeg|*.jpg";
            // 
            // Chart3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.menu;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Chart3D";
            this.Size = new System.Drawing.Size(361, 324);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chart3D_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chart3D_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Chart3D_MouseUp);
            this.SizeChanged += new System.EventHandler(this.Chart3D_SizeChanged);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveImage;
        private System.Windows.Forms.ToolStripMenuItem whileRotatingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyDrawAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawChartAndAxisToolStripMenuItem;

    }
}
