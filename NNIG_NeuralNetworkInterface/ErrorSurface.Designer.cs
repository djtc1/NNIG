namespace NNIG_NeuralNetworkInterface
{
    partial class ErrorSurface
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
            Chart3DLib.LineStyle lineStyle1 = new Chart3DLib.LineStyle();
            Chart3DLib.DataSeries dataSeries1 = new Chart3DLib.DataSeries();
            Chart3DLib.BarStyle barStyle1 = new Chart3DLib.BarStyle();
            Chart3DLib.LineStyle lineStyle2 = new Chart3DLib.LineStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorSurface));
            Chart3DLib.LineStyle lineStyle3 = new Chart3DLib.LineStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chart3DError = new Chart3DLib.Chart3D();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericTextBoxLeftBound = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericTextBoxRight = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericTextBoxStep = new NNIG_NeuralNetworkInterface.numericTextBox();
            this.labelStep = new System.Windows.Forms.Label();
            this.labelweightint = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.comboBoxWeightY = new System.Windows.Forms.ComboBox();
            this.comboBoxWeightX = new System.Windows.Forms.ComboBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelHelpXAxis = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxProperties.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart3DError);
            this.groupBox1.Location = new System.Drawing.Point(2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(323, 321);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Error Surface";
            // 
            // chart3DError
            // 
            this.chart3DError.BackColor = System.Drawing.Color.White;
            lineStyle1.IsVisible = true;
            lineStyle1.LineColor = System.Drawing.Color.Black;
            lineStyle1.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle1.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle1.Thickness = 1F;
            this.chart3DError.C3Axes.AxisStyle = lineStyle1;
            this.chart3DError.C3Axes.XMax = 5F;
            this.chart3DError.C3Axes.XMin = -5F;
            this.chart3DError.C3Axes.XTick = 1F;
            this.chart3DError.C3Axes.YMax = 3F;
            this.chart3DError.C3Axes.YMin = -3F;
            this.chart3DError.C3Axes.YTick = 1F;
            this.chart3DError.C3Axes.ZMax = 6F;
            this.chart3DError.C3Axes.ZMin = -6F;
            this.chart3DError.C3Axes.ZTick = 3F;
            barStyle1.IsBarSingleColor = false;
            barStyle1.XLength = 0.5F;
            barStyle1.YLength = 0.5F;
            barStyle1.ZOrigin = 0F;
            dataSeries1.BarStyle = barStyle1;
            lineStyle2.IsVisible = true;
            lineStyle2.LineColor = System.Drawing.Color.Black;
            lineStyle2.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle2.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle2.Thickness = 1F;
            dataSeries1.LineStyle = lineStyle2;
            dataSeries1.Point4Array = null;
            dataSeries1.PointArray = null;
            dataSeries1.PointList = ((System.Collections.ArrayList)(resources.GetObject("dataSeries1.PointList")));
            dataSeries1.XDataMin = -5F;
            dataSeries1.XNumber = 10;
            dataSeries1.XSpacing = 1F;
            dataSeries1.YDataMin = -5F;
            dataSeries1.YNumber = 10;
            dataSeries1.YSpacing = 1F;
            dataSeries1.ZNumber = 10;
            dataSeries1.ZSpacing = 1F;
            dataSeries1.ZZDataMin = -5F;
            this.chart3DError.C3DataSeries = dataSeries1;
            lineStyle3.IsVisible = true;
            lineStyle3.LineColor = System.Drawing.Color.LightGray;
            lineStyle3.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle3.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle3.Thickness = 1F;
            this.chart3DError.C3Grid.GridStyle = lineStyle3;
            this.chart3DError.C3Grid.IsXGrid = true;
            this.chart3DError.C3Grid.IsYGrid = true;
            this.chart3DError.C3Grid.IsZGrid = true;
            this.chart3DError.C3Labels.LabelFont = new System.Drawing.Font("Arial", 10F);
            this.chart3DError.C3Labels.LabelFontColor = System.Drawing.Color.Black;
            this.chart3DError.C3Labels.TickFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart3DError.C3Labels.TickFontColor = System.Drawing.Color.Black;
            this.chart3DError.C3Labels.Title = "";
            this.chart3DError.C3Labels.TitleColor = System.Drawing.Color.Black;
            this.chart3DError.C3Labels.TitleFont = new System.Drawing.Font("Arial Narrow", 14F);
            this.chart3DError.C3Labels.XLabel = "X Axis";
            this.chart3DError.C3Labels.YLabel = "Y Axis";
            this.chart3DError.C3Labels.ZLabel = "Z Axis";
            this.chart3DError.C3ViewAngle.Azimuth = -37.5F;
            this.chart3DError.C3ViewAngle.Elevation = 30F;
            this.chart3DError.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart3DError.Location = new System.Drawing.Point(6, 19);
            this.chart3DError.Name = "chart3DError";
            this.chart3DError.Size = new System.Drawing.Size(311, 296);
            this.chart3DError.TabIndex = 0;
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxProperties.Controls.Add(this.numericTextBoxStep);
            this.groupBoxProperties.Controls.Add(this.labelStep);
            this.groupBoxProperties.Controls.Add(this.labelweightint);
            this.groupBoxProperties.Controls.Add(this.buttonShow);
            this.groupBoxProperties.Controls.Add(this.comboBoxWeightY);
            this.groupBoxProperties.Controls.Add(this.comboBoxWeightX);
            this.groupBoxProperties.Controls.Add(this.labelY);
            this.groupBoxProperties.Controls.Add(this.labelX);
            this.groupBoxProperties.Location = new System.Drawing.Point(331, 42);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBoxProperties.Size = new System.Drawing.Size(192, 250);
            this.groupBoxProperties.TabIndex = 1;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Properties:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericTextBoxLeftBound, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericTextBoxRight, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(52, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(122, 28);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "[";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericTextBoxLeftBound
            // 
            this.numericTextBoxLeftBound.AllowSpace = false;
            this.numericTextBoxLeftBound.Location = new System.Drawing.Point(23, 3);
            this.numericTextBoxLeftBound.Name = "numericTextBoxLeftBound";
            this.numericTextBoxLeftBound.Size = new System.Drawing.Size(27, 20);
            this.numericTextBoxLeftBound.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = ",";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericTextBoxRight
            // 
            this.numericTextBoxRight.AllowSpace = false;
            this.numericTextBoxRight.Location = new System.Drawing.Point(71, 3);
            this.numericTextBoxRight.Name = "numericTextBoxRight";
            this.numericTextBoxRight.Size = new System.Drawing.Size(27, 20);
            this.numericTextBoxRight.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericTextBoxStep
            // 
            this.numericTextBoxStep.AllowSpace = false;
            this.numericTextBoxStep.Location = new System.Drawing.Point(104, 153);
            this.numericTextBoxStep.Name = "numericTextBoxStep";
            this.numericTextBoxStep.Size = new System.Drawing.Size(56, 20);
            this.numericTextBoxStep.TabIndex = 6;
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(6, 147);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(92, 26);
            this.labelStep.TabIndex = 5;
            this.labelStep.Text = "Number of \r\nResolution Points:";
            // 
            // labelweightint
            // 
            this.labelweightint.AutoSize = true;
            this.labelweightint.Location = new System.Drawing.Point(6, 103);
            this.labelweightint.Name = "labelweightint";
            this.labelweightint.Size = new System.Drawing.Size(45, 26);
            this.labelweightint.TabIndex = 4;
            this.labelweightint.Text = "Weight\r\nInterval:";
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(52, 196);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(94, 39);
            this.buttonShow.TabIndex = 2;
            this.buttonShow.Text = "Show Error\r\n Surface";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // comboBoxWeightY
            // 
            this.comboBoxWeightY.FormattingEnabled = true;
            this.comboBoxWeightY.Location = new System.Drawing.Point(52, 62);
            this.comboBoxWeightY.Name = "comboBoxWeightY";
            this.comboBoxWeightY.Size = new System.Drawing.Size(108, 21);
            this.comboBoxWeightY.TabIndex = 3;
            // 
            // comboBoxWeightX
            // 
            this.comboBoxWeightX.FormattingEnabled = true;
            this.comboBoxWeightX.Location = new System.Drawing.Point(52, 29);
            this.comboBoxWeightX.Name = "comboBoxWeightX";
            this.comboBoxWeightX.Size = new System.Drawing.Size(108, 21);
            this.comboBoxWeightX.TabIndex = 2;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(6, 70);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(42, 13);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "Y Axis: ";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(6, 32);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(39, 13);
            this.labelX.TabIndex = 0;
            this.labelX.Text = "X Axis:";
            // 
            // labelHelpXAxis
            // 
            this.labelHelpXAxis.AutoSize = true;
            this.labelHelpXAxis.BackColor = System.Drawing.Color.DodgerBlue;
            this.labelHelpXAxis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHelpXAxis.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelpXAxis.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelHelpXAxis.Location = new System.Drawing.Point(497, 91);
            this.labelHelpXAxis.Name = "labelHelpXAxis";
            this.labelHelpXAxis.Size = new System.Drawing.Size(19, 21);
            this.labelHelpXAxis.TabIndex = 8;
            this.labelHelpXAxis.Text = "?";
            this.labelHelpXAxis.Click += new System.EventHandler(this.labelHelpXAxis_Click);
            // 
            // ErrorSurface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(535, 337);
            this.Controls.Add(this.labelHelpXAxis);
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.groupBox1);
            this.Name = "ErrorSurface";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "Error Surface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorSurface_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxProperties.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Chart3DLib.Chart3D chart3DError;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.ComboBox comboBoxWeightY;
        private System.Windows.Forms.ComboBox comboBoxWeightX;
        private System.Windows.Forms.Label labelweightint;
        private numericTextBox numericTextBoxStep;
        private System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private numericTextBox numericTextBoxLeftBound;
        private System.Windows.Forms.Label label2;
        private numericTextBox numericTextBoxRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelHelpXAxis;

    }
}