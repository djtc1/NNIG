using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NNIG_NeuralNetworkInterface
{
    public partial class OutputPreview : Form
    {
        #region Variables

        public ArrayList ColumnHeadersText = new ArrayList();

        double[] Deviations;
        double[,] DataMatrix;
 
        #endregion

        #region Public Access to the class

        public double[,] SetData
        {
            set
            {
                DataMatrix = value;
            }
        }

        public double[] SetDeviations
        {
            set { Deviations = value; }
        }

        #endregion


        public OutputPreview(double[,] DataMatrix, double[] OutputErrors)
        {
            InitializeComponent();
            RefreshDataPreview(DataMatrix, OutputErrors);
            
        }

        public OutputPreview()
        {
            InitializeComponent();
        }


        public void RefreshDataPreview(double[,] DataMatrix, double[] OutputErrors)
        {
            if ( dataGridViewInputOutput.Rows.Count != 0)
            {
                dataGridViewInputOutput.Columns.Clear();
                dataGridViewInputOutput.Rows.Clear();
            }

            if (DataMatrix.GetLength(0) == DataMatrix.GetLength(0))
            {
                SetupDataGridView(DataMatrix, OutputErrors);
                PopulateDataGridView(DataMatrix, OutputErrors);

                int countColumn;
                for (countColumn = 0; countColumn < dataGridViewInputOutput.Columns.Count; countColumn++)
                {
                    dataGridViewInputOutput.Columns[countColumn].SortMode = DataGridViewColumnSortMode.NotSortable;

                }
            }
            else
            {
                MessageBox.Show("Output Matrix 0 leghth is diferent of the 0 dimention of the Deviations ");
            }
        }



        private void SetupDataGridView(double[,] MatrizDados, double[] OutputErrors)
        {

            dataGridViewInputOutput.ColumnCount = MatrizDados.GetLength(1)+1;
            dataGridViewInputOutput.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewInputOutput.GridColor = Color.Black;
            dataGridViewInputOutput.RowHeadersVisible = true;

            // Fazer os cabeçalhos das colunas e das linhas
            for (int i = 0; i < MatrizDados.GetLength(1) + 1; i++)
            {
                if (ColumnHeadersText.Count != 0)
                {
                    for (int j = 0; j < ColumnHeadersText.Count; j++)
                    {
                        dataGridViewInputOutput.Columns[j].Name = ColumnHeadersText[j].ToString();
                    }
                }
                
            }
        }


        public void PopulateDataGridView(double[,] MatrizDados, double[] OutputErrors)
        {

            string[] LinhaDados = new string[MatrizDados.GetLength(1) + 1];

            dataGridViewInputOutput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
           
            for (int linha = 0; linha < MatrizDados.GetLength(0); linha++)
            {
                for (int Coluna = 0; Coluna < MatrizDados.GetLength(1)+1; Coluna++)
                {
                    if (Coluna < MatrizDados.GetLength(1))
                    {
                        LinhaDados[Coluna] = Convert.ToString(MatrizDados[linha, Coluna]);
                    }
                    else
                    {
                        LinhaDados[MatrizDados.GetLength(1)] = Convert.ToString(OutputErrors[linha]);
                    }
                }

                dataGridViewInputOutput.Rows.Add(LinhaDados);

            }
            dataGridViewInputOutput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

        }


        private void OutputPreview_Load(object sender, EventArgs e)
        {

        }

        private void OutputPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((NNIG_Software)MdiParent).Controls.Remove(this);
            ((NNIG_Software)MdiParent).viewNNOutput.Enabled = true;
        }
    }
}