using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;

namespace NNIG_NeuralNetworkInterface
{
    public partial class ClassificationMatrixEditor : Form
    {
        #region Variables

        String ActivationFunctionName;

        double[] TrueClassifications;

        double[,] NNClassifications;

        ClassificationMatrix NNClassificationMatrix = new ClassificationMatrix();

        LibAlg NeuralMath = new LibAlg();

        bool ForClassification;

        #endregion


        #region Public Access to the Class

        public double[] TheTrueClassifications
        {
            set
            {
                TrueClassifications = value;
            }
        }

        public double[,] NNOutput
        {
            set
            {
                NNClassifications = value;
            }
        }

        public string OutputLayerActivationFunction
        {
            set
            {
                ActivationFunctionName = value.ToString();
            }
        }

        public Boolean IsClassfification
        {
            set { ForClassification = value; }
        }

        #endregion

        public ClassificationMatrixEditor()
        {
            InitializeComponent();

            if (TrueClassifications != null && NNClassifications != null)
            {
                RefreshDataGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TrueClassifications != null && NNClassifications != null)
            {
                RefreshDataGrid();
            }
        }

        public void RefreshDataGrid()
        {
            if (ForClassification)
            {
                float ClassificationError = 0;
                int MissClassifications = 0;
                //  double Performance = 0;

                int NumberofClasses = Convert.ToInt32(NeuralMath.ComputeMaximumElementVector(TrueClassifications));

                int[] Classification = new int[NumberofClasses * NumberofClasses];


                try
                {
                    viewClassificationMatrix.Rows.Clear();
                    viewClassificationMatrix.Columns.Clear();
                }
                catch
                {

                }

                Classification = NNClassificationMatrix.ClassificationVector(TrueClassifications, NNClassifications, ActivationFunctionName);

                SetupDataGridView(NumberofClasses);

                PopulateDataGridView(Classification, NumberofClasses);

                // Fazer os cabeçalhos das colunas
                for (int i = 0; i < NumberofClasses; i++)
                {
                    viewClassificationMatrix.Columns[i].Name = "Class " + Convert.ToString(i + 1);

                    string legenda = "Class " + Convert.ToString(i + 1);

                    viewClassificationMatrix.Rows[i].HeaderCell.Value = legenda;
                }
                viewClassificationMatrix.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

                int countColumn;
                for (countColumn = 0; countColumn < viewClassificationMatrix.Columns.Count; countColumn++)
                {
                    viewClassificationMatrix.Columns[countColumn].SortMode = DataGridViewColumnSortMode.NotSortable;

                }
                int cont = 0;
                for (int i = 1; i < Classification.Length; i++)
                {
                    if (cont != NumberofClasses)
                    {
                        MissClassifications += Classification[i];
                        cont += 1;
                    }
                    else
                    {
                        cont = 0;
                    }
                }

                int NumberPatterns = TrueClassifications.Length;

                ClassificationError = (float)MissClassifications / NumberPatterns;

                numEditClassificationError.Text = ClassificationError.ToString();
            }
            else
            {
                toolStripStatusLabelClassification.Text = " Unable to display classification matrix! Your programme is run for regression"; 
            }
        } //end refresh data 

        private void SetupDataGridView(int NumberofClasses)
        {
            viewClassificationMatrix.ColumnCount = NumberofClasses;
            viewClassificationMatrix.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            viewClassificationMatrix.GridColor = Color.Black;
            viewClassificationMatrix.RowHeadersVisible = true;
        }

        public void PopulateDataGridView(int[] ClassVector, int NumberofClasses)
        {

            string[] Dados = new string[NumberofClasses * NumberofClasses];
            string[] ColumnData = new string[NumberofClasses];

            viewClassificationMatrix.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            for (int i = 0; i < NumberofClasses * NumberofClasses; i++)
            {
                Dados[i] = ClassVector[i].ToString();
            }


            for (int column = 0; column < NumberofClasses; column++)
            {
                int aux = 0;
                for (int j = 0; j < NumberofClasses; j++)
                {
                    ColumnData[j] = Dados[column + aux];
                    aux += NumberofClasses;
                }


                viewClassificationMatrix.Rows.Add(ColumnData);


            }
            viewClassificationMatrix.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        private void ClassificationMatrixEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((NNIG_Software)MdiParent).toolStripButtonclassificationMatrix.Enabled = true;
            ((NNIG_Software)MdiParent).ClassificationResults = null;
        }

    }
}