using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;

namespace NNIG_NeuralNetworkInterface
{
    public partial class NNIGINPUTDATA : Form
    {
        public NNIGINPUTDATA InputData;

        #region Variáveis

        int seedSwap;

        int InputorOutput = -1; //Classificar como intput ou output

        int ContColumnstobeInput = 0;

        int lastindex = -1;

        int NumberofExperiments = 0;

        int NumberofGroups;

        int NumberLinesGroup;

        int TargetColumn;

        int NumberGroupsTrain;

        int NumberGroupsTest;

        double NumberofClasses = 0;

        int numberoutputs = 0;

        double LimiteIntervalo;

        double LimiteDireitoIntervalo;

        double[] InputorOutputIndex;//guardar se a coluna vai ser input ou output ou ignorada
        // se estiver um 0 será input
        // se estiver um 1 será output
        // se estiver um -1  será ignorada
        double[] TrueClasses;

        // double[] TargetVector;

        double[,] DataMatrix;

        double[,] mtemp;

        double[,] MTempAux;

        double[][] InputMatrix;

        double[][] ExpectedOutputMatrix;


        bool crossValidation = false;

        bool clikOK = false;

        bool IsClassification;

        String ScalingData = "";

        LibAlg NeuralMath = new LibAlg();

        ArrayList ColumnHeadersText = new ArrayList();

        allDataPreview DataPreview;

        Scatterplot ViewDataPlot;

        ArrayList Groups;




        #endregion

        #region Public acess to the class

        public bool exp
        {
            get { return clikOK; }
        }
        public ToolStripButton toolStripButton;

        public DataGridView DataView
        {
            get
            {
                return dataGridViewInputOutput;
            }
        }

        public int N_Inputs
        {
            get
            {
                return ContColumnstobeInput;
            }
        }

        public int N_Output
        {
            get
            {
                return Convert.ToInt32(NumberofClasses);
            }
        }

        public double[,] Data
        {
            get
            {
                if (mtemp != null)
                {
                    return mtemp;
                }
                else
                {
                    return DataMatrix;

                }


            }
            set { DataMatrix = value; }
        }

        public int GetNumberExperiments
        {
            get
            {
                return NumberofExperiments;
            }
        }

        public bool CrossValidationChoosen
        {
            get
            {
                return crossValidation;
            }
        }

        public double[] ColumnOptions
        {
            get { return InputorOutputIndex; }
            set { InputorOutputIndex = value; }
        }

        public ArrayList ColumnCaption
        {
            get { return ColumnHeadersText; }
        }

        #endregion

        //constructor 
        public NNIGINPUTDATA()
        {
            InitializeComponent();

        }




        /// <summary>
        /// Setup da tabela de visualização dos dados
        /// Conversão de variáveis para strings
        /// </summary>
        public void SetupDataGridView(double[,] MatrizDados, ArrayList ColumnHeaders)
        {
            dataGridViewInputOutput.ColumnCount = MatrizDados.GetLength(1);
            dataGridViewInputOutput.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewInputOutput.GridColor = Color.Black;
            dataGridViewInputOutput.RowHeadersVisible = true;
            dataGridViewInputOutput.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                       
            // Fazer os cabeçalhos das colunas e das linhas
            for (int i = 0; i < MatrizDados.GetLength(1); i++)
            {
                if (ColumnHeadersText.Count != 0)
                {
                    for (int j = 0; j < ColumnHeadersText.Count; j++)
                    {
                        dataGridViewInputOutput.Columns[j].Name = ColumnHeaders[j].ToString();
                    }
                }
                else
                {
                    dataGridViewInputOutput.Columns[i].Name = "var " + Convert.ToString(i + 1);
                }
            }




        }

        /// <summary>
        /// Coloca os dados num tabela
        /// </summary>
        /// <param name="MatrizDados">Matriz que queremos dispor</param>
        private void PopulateDataGridView(double[,] MatrizDados)
        {
            int legenda;

            string[] LinhaDados = new string[MatrizDados.GetLength(1)];

            dataGridViewInputOutput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            for (int linha = 0; linha < MatrizDados.GetLength(0); linha++)
            {
                if (linha < 7)
                {
                    for (int Coluna = 0; Coluna < MatrizDados.GetLength(1); Coluna++)
                    {
                        LinhaDados[Coluna] = Convert.ToString(MatrizDados[linha, Coluna]);
                    }

                    dataGridViewInputOutput.Rows.Add(LinhaDados);
                    legenda = linha + 1;
                    dataGridViewInputOutput.Rows[linha].HeaderCell.Value = legenda.ToString();

                }
            }
            dataGridViewInputOutput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            if (comboBoxsubsets.SelectedItem != null && numEditTrain.Text != "" && numEditTest.Text != "")
            {
                int Numberlines = (int)Math.Floor((double)(MatrizDados.GetLength(0) / NumberofGroups));

                int i = -1;
                while (i++ < 6)
                {
                    if (i < (int)(Numberlines * NumberGroupsTrain))
                    {
                        dataGridViewInputOutput.Rows[i].HeaderCell.Value = "Train";
                        dataGridViewInputOutput.Rows[i].HeaderCell.Style.BackColor = Color.Red;
       
                    }
                    else
                    {
                        dataGridViewInputOutput.Rows[i].HeaderCell.Value = "Test";
                        dataGridViewInputOutput.Rows[i].HeaderCell.Style.BackColor = Color.Green;
                    }

                }

            }

        }

        private void dataGridViewInputOutput_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (lastindex == e.ColumnIndex)
            {

                dataGridViewInputOutput.Columns[e.ColumnIndex].Selected = false;
                lastindex = -1;
            }

            else
            {
                lastindex = e.ColumnIndex;
            }

            InputorOutput = e.ColumnIndex;


        }
        private void dataGridViewInputOutput_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                int nc = dataGridViewInputOutput.SelectedColumns.Count;
                for (int i = 0; i < dataGridViewInputOutput.Columns.Count; i++)
                {
                    if (nc != 0)
                    {
                        dataGridViewInputOutput.Columns[i].Selected = false;
                    }
                }
            }
        }

        private void dataGridViewInputOutput_DoubleClick(object sender, EventArgs e)
        {
            String[] LinesNames;
            
            int caption;

            if (DataMatrix != null)
            {
                if (MTempAux != null)
                {
                    LinesNames = new string[MTempAux.GetLength(0)];
                    int i = -1;
                    while (i++ < NumberGroupsTrain * NumberLinesGroup - 1)
                    {
                        LinesNames[i] = "Train";
                    }
                    for (int j = (int)NumberGroupsTrain * NumberLinesGroup; j < MTempAux.GetLength(0); j++)
                    {
                        LinesNames[j] = "Test";
                    }

                    DataPreview = new allDataPreview(MTempAux, InputorOutputIndex, LinesNames, ColumnHeadersText, IsClassification); //reescrever

                }


                else if (mtemp != null)
                {


                    LinesNames = new string[mtemp.GetLength(0)];

                    for (int i = 0; i < mtemp.GetLength(0); i++)
                    {
                        caption = i + 1;

                        LinesNames[i] = caption.ToString();
                    }
                    DataPreview = new allDataPreview(mtemp, InputorOutputIndex, LinesNames, ColumnHeadersText, IsClassification); //reescrever

                }
                else
                {
                    LinesNames = new string[DataMatrix.GetLength(0)];

                    for (int i = 0; i < DataMatrix.GetLength(0); i++)
                    {
                        caption = i + 1;

                        LinesNames[i] = caption.ToString();
                    }
                    DataPreview = new allDataPreview(DataMatrix, InputorOutputIndex, LinesNames, ColumnHeadersText, IsClassification); //reescrever

                }

                DataPreview.Show();
                DataPreview.MdiParent = this.MdiParent;



            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridViewInputOutput.SelectedColumns.Count != 1)
            {
                MessageBox.Show("Please choose one and only one column for Input or Output");
                e.Cancel = true;
            }
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridViewInputOutput.Columns[InputorOutput].HeaderCell.Style.ForeColor = Color.Green;
            dataGridViewInputOutput.Columns[InputorOutput].DefaultCellStyle.ForeColor = Color.Green;

            for (int i = 0; i < dataGridViewInputOutput.Columns.Count; i++)
            {

                dataGridViewInputOutput.Columns[i].Selected = false;

            }
            InputorOutputIndex[InputorOutput] = 0;
            RefreshDataGrid();

        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList OutputPositions;
            
            OutputPositions = NeuralMath.FindPositionsVector(InputorOutputIndex, 1);

            if (OutputPositions.Count > 1 || (int)OutputPositions[0] != InputorOutput)
            {

                MessageBox.Show("The targets must be in just one column!", "NNIG WARNING!!", MessageBoxButtons.OK);

                return;

            }
            else
            {
                dataGridViewInputOutput.Columns[InputorOutput].HeaderCell.Style.ForeColor = Color.Red;
                dataGridViewInputOutput.Columns[InputorOutput].DefaultCellStyle.ForeColor = Color.Red;

                for (int i = 0; i < dataGridViewInputOutput.Columns.Count; i++)
                {

                    dataGridViewInputOutput.Columns[i].Selected = false;

                }

                InputorOutputIndex[InputorOutput] = 1;
                
                TargetColumn = InputorOutput;

                IsClassification = true;

            }


            RefreshDataGrid();
        }

        private void metricOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList OutputPositions;

            OutputPositions = NeuralMath.FindPositionsVector(InputorOutputIndex, 1);
          

            //if (MarkedOutput && )
            if (OutputPositions.Count > 1 || (int)OutputPositions[0] != InputorOutput)
            {

                MessageBox.Show("The targets must be in just one column!", "NNIG WARNING!!", MessageBoxButtons.OK);

                return;

            }

            else
            {
                
                dataGridViewInputOutput.Columns[InputorOutput].HeaderCell.Style.ForeColor = Color.DodgerBlue;
                dataGridViewInputOutput.Columns[InputorOutput].DefaultCellStyle.ForeColor = Color.DodgerBlue;

                for (int i = 0; i < dataGridViewInputOutput.Columns.Count; i++)
                {

                    dataGridViewInputOutput.Columns[i].Selected = false;

                }

                InputorOutputIndex[InputorOutput] = 1;

                TargetColumn = InputorOutput;
                IsClassification = false;
            }

            RefreshDataGrid();
        }

        private void ignoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewInputOutput.Columns[InputorOutput].HeaderCell.Style.ForeColor = Color.Black;
            dataGridViewInputOutput.Columns[InputorOutput].DefaultCellStyle.ForeColor = Color.Black;
            for (int i = 0; i < dataGridViewInputOutput.Columns.Count; i++)
            {

                dataGridViewInputOutput.Columns[i].Selected = false;

            }
            InputorOutputIndex[InputorOutput] = -1;
            RefreshDataGrid();
        }

        public void RefreshDataGrid()
        {
            if (DataMatrix != null)
            {
                mtemp = NeuralMath.CopyMatrix(DataMatrix);

                if (checkBoxRandomizeInitialData.Checked)
                {
                    mtemp = NeuralMath.SwapMatrix(mtemp, seedSwap);
                }

                if (checkBoxNormalizeData.Checked)
                {

                    int[] outputColumns = new int[1];

                    for (int i = 0; i < InputorOutputIndex.Length; i++)
                    {
                        if (InputorOutputIndex[i] == 1) ////output
                        {
                            outputColumns[0] = i;
                        }
                    }

                    #region switch
                    switch (ScalingData)
                    {
                        case "RangeScaling":
                            try
                            {
                                LimiteIntervalo = double.Parse(numtextBoxNormalizationLimitInterval.Text);
                                LimiteDireitoIntervalo = double.Parse(numtextBoxNormalizationRightLimitInterval.Text);
                                LinearScaling RangeScaling = new LinearScaling(mtemp, LimiteIntervalo, LimiteDireitoIntervalo, outputColumns);

                                mtemp = RangeScaling.ComputeNormalizedMatrix();

                            }
                            catch
                            {

                            }
                            break;
                        case "MeanCentering":

                            MeanCenteringScaling MeanCentering = new MeanCenteringScaling(mtemp, outputColumns);
                            mtemp = MeanCentering.ComputeNormalizedMatrix();
                            break;

                        case "Standardization":

                            StandarizationScaling Normalization = new StandarizationScaling(mtemp, outputColumns);
                            mtemp = Normalization.ComputeNormalizedMatrix();

                            break;

                    }
                    #endregion

                }

                if (checkBoxMaintainRepresentativity.Checked)
                {
                    ArrayList Aux;
                    NumberLinesGroup = ((ArrayList)Groups[0]).Count;
                    MTempAux = new double[Groups.Count * NumberLinesGroup, mtemp.GetLength(1)];

                    int line = 0;

                    for (int i = 0; i < Groups.Count; i++)
                    {
                        Aux = new ArrayList();
                        Aux = (ArrayList)Groups[i];
                        for (int j = 0; j < Aux.Count; j++) //fixar as linhas
                        {
                            for (int k = 0; k < mtemp.GetLength(1); k++)//fixas as colunas
                            {
                                MTempAux[line, k] = mtemp[((int)Aux[j]), k];
                            }

                            line++;
                        }

                    }

                    dataGridViewInputOutput.Rows.Clear();

                    PopulateDataGridView(MTempAux);  //reescrito

                } //end suffle matrix mainting class representativity
                else
                {

                    dataGridViewInputOutput.Rows.Clear();

                    PopulateDataGridView(mtemp);  //reescrito
                }

                for (int i = 0; i < dataGridViewInputOutput.Columns.Count; i++)
                {

                    dataGridViewInputOutput.Columns[i].Selected = false;

                }
            }
            else
            { 
                MessageBox.Show("Please check your data","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
        }//end refreshdatagrid

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string DisplayFileName = "";

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr != DialogResult.OK)
                return;

            FileStream FileName = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

            StreamReader Sr = new StreamReader(FileName);

            string stext = Sr.ReadToEnd();

            

            Sr.Close();

            FileName.Close();

            ColumnHeadersText.Clear();

            #region Extract double Matrix from text
             
            char[] myDelimiters ={ '\n' }; //Alexandra
            char[] myDelimiters1 = { ';' };
            char[] myDelimitersFileName = { '\\' }; //Alexandra Oliveira

            
            string[] MatrixStrings = stext.Split(myDelimiters, StringSplitOptions.RemoveEmptyEntries);

          

            string[] DisplayFileNametemp = openFileDialog1.FileName.Split(myDelimitersFileName);

            DisplayFileName = DisplayFileNametemp[DisplayFileNametemp.Length - 1];

            labelfile.Text = "File Name: " + DisplayFileName;


            string[] FileHeaders = MatrixStrings[0].Split(myDelimiters1);
            string FirstFileHeaders = FileHeaders[0];

            int NumberOfLines;

            try //determinar a dimensão da matriz no caso em que o ficheiro contem cabeçalhos
            {
                double.Parse(FirstFileHeaders);

                NumberOfLines = MatrixStrings.Length;
            }
            catch
            {
                NumberOfLines = MatrixStrings.Length - 1;
            }



            int NumerberOfColumns = MatrixStrings[0].Split(myDelimiters1).Length;


            DataMatrix = new double[NumberOfLines, NumerberOfColumns];

            int CountLines = 0, CountColumns = 0;
            int Flag = 0;




            for (int j = 0; j < MatrixStrings.GetLength(0); j++)
            {
                string st = MatrixStrings[j];//Alexandra

                string[] tmpSt = st.Split(myDelimiters1);

                for (int i = 0; i < tmpSt.Length; i++)
                {
                    string st2 = tmpSt[i];


                    try
                    {

                        DataMatrix[CountLines, CountColumns] = double.Parse(st2);

                        Flag++;

                    }

                    catch
                    {
                        if (j == 0)
                        {
                            ColumnHeadersText.Add(st2);
                        }
                    }



                    CountColumns++;
                }
                if (Flag != 0)
                {
                    CountLines++;
                }
                CountColumns = 0;

            }

            #endregion


            InputorOutputIndex = new double[NumerberOfColumns];

            LibAlg la = new LibAlg();



            InputorOutputIndex = la.FillVectorWithA(InputorOutputIndex, 0);

            InputorOutputIndex[InputorOutputIndex.Length - 1] = 1;

            TargetColumn = InputorOutputIndex.Length - 1;

            dataGridViewInputOutput.Rows.Clear();
            dataGridViewInputOutput.Columns.Clear();

            RefreshDataGridOptions(DataMatrix, InputorOutputIndex, ColumnHeadersText);

            labelnumvariables.Text = DataMatrix.GetLength(1).ToString();
            labelnumvariables.Visible = true;

            labelnumberofpatterns.Text = DataMatrix.GetLength(0).ToString();
            labelnumberofpatterns.Visible = true;

            for (int i = 2; i < DataMatrix.GetLength(0); i++)
            {
                comboBoxsubsets.Items.Add(i);
            }

        }//end openfile method

        public void RefreshDataGridOptions(double[,] Matrix, double[] ColumnOptions, ArrayList Headers)
        {

            dataGridViewInputOutput.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            SetupDataGridView(Matrix, Headers);

            PopulateDataGridView(Matrix);


            #region Seleccionar as colunas

            int countColumn;
            for (countColumn = 0; countColumn < dataGridViewInputOutput.Columns.Count; countColumn++)
            {
                dataGridViewInputOutput.Columns[countColumn].SortMode = DataGridViewColumnSortMode.NotSortable;
                //daniel
                //iniciar os headers com o menu strip
                dataGridViewInputOutput.Columns[countColumn].HeaderCell.ContextMenuStrip = contextMenuStrip1;

            }

            #endregion

            dataGridViewInputOutput.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            for (int i = 0; i < ColumnOptions.Length; i++)
            {
                if (ColumnOptions[i] == 0)
                {
                    dataGridViewInputOutput.Columns[i].HeaderCell.Style.ForeColor = Color.Green;
                    dataGridViewInputOutput.Columns[i].DefaultCellStyle.ForeColor = Color.Green;

                }
                else if (ColumnOptions[i] == 1)
                {
                    if (IsClassification)
                    {
                        dataGridViewInputOutput.Columns[i].HeaderCell.Style.ForeColor = Color.Red;
                        dataGridViewInputOutput.Columns[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridViewInputOutput.Columns[i].HeaderCell.Style.ForeColor = Color.DodgerBlue;
                        dataGridViewInputOutput.Columns[i].DefaultCellStyle.ForeColor = Color.DodgerBlue;
                    }
                }
                else if (ColumnOptions[i] == -1)
                {
                    dataGridViewInputOutput.Columns[i].HeaderCell.Style.ForeColor = Color.Black;
                    dataGridViewInputOutput.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }


        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDataGrid();

        }//cleartoolStripMenuItem

        public void ClearDataGrid()
        {
            dataGridViewInputOutput.Rows.Clear();
            dataGridViewInputOutput.Columns.Clear();

            dataGridViewInputOutput.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;//fazer o reset do SelectionMode;

            ColumnHeadersText.RemoveRange(0, ColumnHeadersText.Count);

            labelfile.Text = "File: ";

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            clearToolStripMenuItem_Click(sender, e);
        }

        #region checkBoxes

        private void checkBoxRandomizeInitialData_CheckedChanged(object sender, EventArgs e)
        {
            Random r = new Random();

            seedSwap = r.Next();

            RefreshDataGrid();
        }

        private void checkBoxNormalizeData_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNormalizeData.Checked)
            {
                this.comboBoxScalingData.Visible = true;
                this.comboBoxScalingData.SelectedIndex = 0;
                this.panelInputNormalizationLimite.Visible = true;
            }
            else
            {
                this.comboBoxScalingData.Visible = false;
                this.panelInputNormalizationLimite.Visible = false;
            }

            RefreshDataGrid();
        }

        private void checkBoxCrossValidation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCrossValidation.Checked)
            {
                crossValidation = true;

                if (comboBoxsubsets.SelectedItem != null)
                {

                }
                else
                {
                    if (checkBoxMaintainRepresentativity.Checked == true)
                    {
                        MessageBox.Show("You must choose the number of subsets first!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checkBoxMaintainRepresentativity.Checked = false;
                    }

                }
            }
            else
            {
                crossValidation = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxsubsets.SelectedItem != null)
            {
                Groups = new ArrayList();

                NumberofGroups = Convert.ToInt32(comboBoxsubsets.SelectedItem);

                Groups = NeuralMath.ShuffleMaintainingClassProportion(NumberofGroups, NeuralMath.RetirarVectoresColunaMatriz(DataMatrix, TargetColumn));

                RefreshDataGrid();
            }
            else
            {
                if (checkBoxMaintainRepresentativity.Checked == true)
                {
                    MessageBox.Show("You must choose the number of subsets first!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkBoxMaintainRepresentativity.Checked = false;
                }

            }

        }

        #endregion

        private void numtextBoxNormalizationLimitInterval_TextChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();

        }//end method     

        private void numtextBoxNormalizationRightLimitInterval_TextChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void numEditTrain_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxsubsets.SelectedItem == null)
            {
                if (numEditTrain.Text != "")
                {
                    MessageBox.Show("First you must select the number of subset you want to use");
                }
                numEditTrain.Text = "";

            }
            else
            {
                if (numEditTrain.Text != "")
                {
                    if (Convert.ToInt32(numEditTrain.Text) <= 0)
                    {
                        MessageBox.Show("The number of groups to train must be gretter than zero!");
                        numEditTrain.Text = "";
                    }
                    else if (Convert.ToInt32(numEditTrain.Text) > Convert.ToInt32(comboBoxsubsets.SelectedItem))
                    {
                        MessageBox.Show("The number of groups to train must be less or equal to the number of subsets!");
                        numEditTest.Text = "0";
                        numEditTrain.Text = comboBoxsubsets.SelectedItem.ToString();

                    }
                    else
                    {
                        NumberGroupsTrain = Convert.ToInt32(numEditTrain.Text);

                        NumberGroupsTest = Convert.ToInt32(comboBoxsubsets.SelectedItem) - NumberGroupsTrain;

                        numEditTest.Text = NumberGroupsTest.ToString();

                        if (NumberGroupsTrain < NumberGroupsTest)
                        {
                            MessageBox.Show("The number of train groups should be greatter than the number of test groups");
                        }
                    }
                }
            }
        }//end numEditTrain_TestChanged

        private void numEditTrain_Leave(object sender, EventArgs e)
        {
            if (numEditTrain.Text == "" && comboBoxsubsets.SelectedItem != null)
            {
                numEditTrain.Text = NumberGroupsTrain.ToString();
            }
        }//end numEditTrain_Leave

        private void numEditTest_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxsubsets.SelectedItem == null)
            {
                if (numEditTest.Text != "")
                {
                    MessageBox.Show("First you must select the number of subset you want to use");
                }
                numEditTest.Text = "";

            }
            else
            {
                if (numEditTest.Text != "")
                {
                    if (Convert.ToInt32(numEditTest.Text) < 0)
                    {
                        MessageBox.Show("The number of groups to test must be gretter ou equal to zero!");
                        numEditTest.Text = "";

                    }
                    if (Convert.ToInt32(numEditTest.Text) > Convert.ToInt32(comboBoxsubsets.SelectedItem))
                    {
                        MessageBox.Show("The number of groups to test must be less or equal to the number of subsets!");
                        numEditTest.Text = "0";
                        numEditTrain.Text = comboBoxsubsets.SelectedItem.ToString();

                    }
                    else
                    {
                        NumberGroupsTest = Convert.ToInt32(numEditTest.Text);

                        NumberGroupsTrain = Convert.ToInt32(comboBoxsubsets.SelectedItem) - NumberGroupsTest;

                        numEditTrain.Text = NumberGroupsTrain.ToString();

                        if (NumberGroupsTrain < NumberGroupsTest)
                        {
                            MessageBox.Show("The number of train groups should be gretter than the number of test groups");

                        }
                    }
                }
            }

        }

        private void numEditTest_Leave(object sender, EventArgs e)
        {
            if (numEditTest.Text == "" && comboBoxsubsets.SelectedItem != null && numEditTest.Text == "")
            {
                numEditTrain.Text = NumberGroupsTrain.ToString();
                numEditTest.Text = "0";
            }

        }

        private void NNIGInputDataStructureGUI_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewInputOutput.ColumnCount; i++)
            {
                dataGridViewInputOutput.Columns[i].Selected = false;
            }
        }

        private void comboBoxScalingData_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxScalingData.SelectedIndex)
            {
                case 0:
                    this.panelInputNormalizationLimite.Visible = true;
                    ScalingData = "RangeScaling";
                    break;
                case 1:
                    this.panelInputNormalizationLimite.Visible = false;
                    ScalingData = "MeanCentering";
                    break;
                case 2:
                    this.panelInputNormalizationLimite.Visible = false;
                    ScalingData = "Standardization";
                    break;


            }

            RefreshDataGrid();
        }

        private void comboBoxsubsets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxsubsets.SelectedItem != null)
            {
                numEditTrain.Text = Convert.ToString(Convert.ToDouble(comboBoxsubsets.SelectedItem));
                numEditTest.Text = Convert.ToString(0);

                NumberGroupsTrain = Convert.ToInt32(numEditTrain.Text);
                NumberGroupsTest = 1;
            }

        }

        private void CreateInputandOutputMatrix(double[,] DataMatrix, double[] InputOutputOptions)
        {
            int auxiliarinput = -1;

            int dim = DataMatrix.GetLength(0);//determinar o número de exemplares, ou seja o número de vectores que ira compor a jagged array

            ContColumnstobeInput = 0;

            InputMatrix = new double[dim][];//jagged array

            ExpectedOutputMatrix = new double[dim][];//jagged array

            double[,] TargetMatrix = new double[dim, Convert.ToInt32(NumberofClasses)];

            double[] TargetVector = new double[DataMatrix.GetLength(0)]; ;

            TrueClasses = new double[DataMatrix.GetLength(0)];

            for (int i = 0; i < InputOutputOptions.Length; i++)//determinar o numero de elementos que ira compor cada elemento da jagged array
            {
                if (InputOutputOptions[i] == 0)
                {
                    ContColumnstobeInput++;

                }

            }

            TrueClasses = NeuralMath.RetirarVectoresColunaMatriz(DataMatrix, TargetColumn);

            if (IsClassification)
            {
                NumberofClasses = NeuralMath.ComputeMaximumElementVector(NeuralMath.RetirarVectoresColunaMatriz(DataMatrix, TargetColumn));

                TargetMatrix = NeuralMath.ConstructTargetsMatrix(TrueClasses);

                if (NumberofClasses == 2)//se for um problema de duas classes usar apenas um vector, usar por exemplo a primeira coluna
                {
                    TargetVector = NeuralMath.RetirarVectoresColunaMatriz(TargetMatrix, 0);
                }
            }
            else
            {
                TargetVector = TrueClasses;
            }


            for (int k = 0; k < dim; k++) // povoar a jagged Array
            {
                InputMatrix[k] = new double[ContColumnstobeInput];
                
                 if (NumberofClasses == 2|| IsClassification == false)
                 {
                    ExpectedOutputMatrix[k] = new double[1];
                 }
                    else
                    {
                        ExpectedOutputMatrix[k] = new double[Convert.ToInt64(NumberofClasses)];
                    }
                


                for (int i = 0; i < InputOutputOptions.Length; i++)
                {
                    if (InputOutputOptions[i] == 0)//construction of the input matrix
                    {
                        auxiliarinput++;

                        InputMatrix[k][auxiliarinput] = DataMatrix[k, i];


                    }//end if
                    else if (InputOutputOptions[i] == 1)//constrution of the output matrix
                    {
                        if (NumberofClasses == 2||IsClassification == false)
                        {
                            ExpectedOutputMatrix[k][0] = TargetVector[k];

                        }
                        else
                        {
                            for (int j = 0; j < NumberofClasses; j++)
                            {
                                try
                                {
                                    ExpectedOutputMatrix[k][j] = TargetMatrix[k, j];
                                }
                                catch
                                {
                                    MessageBox.Show("Please review your options! The output must be a natural number.", "ERROR", MessageBoxButtons.OK);
                                    return;
                                }
                            }
                        }

                    }//end else if
                }//end for

                auxiliarinput = -1;

            }//end for
        }

        //ok button
        private void button1_Apply_Click(object sender, EventArgs e)
        {

            if (MTempAux != null)
            {

                CreateInputandOutputMatrix(MTempAux, InputorOutputIndex);

                ((NNIG_Software)MdiParent).EnteredData = MTempAux;
            }
            else if (mtemp != null)
            {
                CreateInputandOutputMatrix(mtemp, InputorOutputIndex);

                ((NNIG_Software)MdiParent).EnteredData = mtemp;
            }
            else
            {
                CreateInputandOutputMatrix(DataMatrix, InputorOutputIndex);

                ((NNIG_Software)MdiParent).EnteredData = DataMatrix;
            }


            ((NNIG_Software)MdiParent).IsForClassification = IsClassification;
            ((NNIG_Software)MdiParent).InputedClassesLabels = TrueClasses;
            ((NNIG_Software)MdiParent).InputDataArray = InputMatrix;
            ((NNIG_Software)MdiParent).Targets = ExpectedOutputMatrix;
            ((NNIG_Software)MdiParent).IsDoingCrossValidation = crossValidation;
            ((NNIG_Software)MdiParent).NumberGroupsToTrain = NumberGroupsTrain;
            ((NNIG_Software)MdiParent).SetVariablesOptions = InputorOutputIndex;
            ((NNIG_Software)MdiParent).SetVariablesCaption = ColumnHeadersText;

            ((NNIG_Software)MdiParent).RunButtonCliked = false;
            ((NNIG_Software)MdiParent).toolStripButtonContinue.Enabled = false;



            int inputs = InputMatrix[0].Length;
            int[] outputs = { ExpectedOutputMatrix[0].Length };
            if (((NNIG_Software)MdiParent).AccessToMLPArquitecture != null)
            {
                ((NNIG_Software)MdiParent).AccessToMLPArquitecture.Neural_Network = new NeuralNetwork(inputs, outputs);
                ((NNIG_Software)MdiParent).AccessToMLPArquitecture.refreshAll();
            }


        }

        private void NNIGINPUTDATA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                ((NNIG_Software)MdiParent).toolStripButtonInput.Enabled = true;


                DialogResult buttonclose = MessageBox.Show("Do you want to save?", "Input Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);


                if (buttonclose.Equals(DialogResult.Yes))
                    ((NNIG_Software)(this.MdiParent)).reloadInputData = true;

                else if (buttonclose.Equals(DialogResult.No))
                {
                    ClearDataGrid();

                    DataMatrix = null;
                    InputData = null;

                    ((NNIG_Software)(this.MdiParent)).reloadInputData = false;
                }
                else if (buttonclose.Equals(DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }
        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {
            if (dataGridViewInputOutput.SelectedColumns.Count == 0)
            {
                MessageBox.Show("You must select a column first");
                e.Cancel = true;

            }
            else if (dataGridViewInputOutput.SelectedColumns.Count != 1)
            {
                MessageBox.Show("You must select just one column at a time");
                e.Cancel = true;
            }
        }

        private void NNIGINPUTDATA_Load(object sender, EventArgs e)
        {

        }

        private void buttonshowscatter_Click(object sender, EventArgs e)
        {
            if(DataMatrix!=null)
            {
              ViewDataPlot = new Scatterplot(DataMatrix,ColumnHeadersText,InputorOutputIndex,IsClassification);
              ViewDataPlot.PopulateComboBox();
              ViewDataPlot.Show();
              ViewDataPlot.MdiParent = this.MdiParent;

            }
            else 
            {
                MessageBox.Show( "Please enter Data","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
        
        }
    }
}