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
    public partial class allDataPreview : Form
    {
        #region Variables

        ArrayList ColumnHeadersText = new ArrayList();

        double[,] DataMatrix;
       
        String[] LinesName;

        bool Classification;

        #endregion

        #region Public Access to the class

        public double[,] SetData
        {
            set
            {
                DataMatrix = value;
            }
        }

        #endregion

        public allDataPreview(double[,] DataMatrix, double[] InputOutputOptions, String[] LinesHeaders, ArrayList ColumnHeadersNames, bool IsForClassification)
        {
            InitializeComponent();

            ColumnHeadersText = ColumnHeadersNames;

            SetupDataGridView(DataMatrix);
            PopulateDataGridView(DataMatrix, LinesHeaders);

            int countColumn;
            for (countColumn = 0; countColumn < dataGridViewInputOutput.Columns.Count; countColumn++)
            {
                dataGridViewInputOutput.Columns[countColumn].SortMode = DataGridViewColumnSortMode.NotSortable;

                if (InputOutputOptions[countColumn] == 0)
                {
                    dataGridViewInputOutput.Columns[countColumn].HeaderCell.Style.ForeColor = Color.Green;
                    dataGridViewInputOutput.Columns[countColumn].DefaultCellStyle.ForeColor = Color.Green;
                }
                if (InputOutputOptions[countColumn] == 1)
                {
                    if (IsForClassification)
                    {
                        dataGridViewInputOutput.Columns[countColumn].HeaderCell.Style.ForeColor = Color.Red;
                        dataGridViewInputOutput.Columns[countColumn].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        dataGridViewInputOutput.Columns[countColumn].HeaderCell.Style.ForeColor = Color.DodgerBlue;
                        dataGridViewInputOutput.Columns[countColumn].DefaultCellStyle.ForeColor = Color.DodgerBlue;
                    }
                }

            }

            LinesName = LinesHeaders;
        }


        private void SetupDataGridView(double[,] MatrizDados)
        {

            dataGridViewInputOutput.ColumnCount = MatrizDados.GetLength(1);
            dataGridViewInputOutput.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewInputOutput.GridColor = Color.Black;
            dataGridViewInputOutput.RowHeadersVisible = true;

            // Fazer os cabeçalhos das colunas e das linhas
            for (int i = 0; i < MatrizDados.GetLength(1); i++)
            {
                if (ColumnHeadersText.Count != 0)
                {
                    for (int j = 0; j < ColumnHeadersText.Count; j++)
                    {
                        dataGridViewInputOutput.Columns[j].Name = ColumnHeadersText[j].ToString();
                    }
                }
                else
                {
                    dataGridViewInputOutput.Columns[i].Name = "var " + Convert.ToString(i + 1);
                }
            }
        }

        public void PopulateDataGridView(double[,] MatrizDados, String[] LinesName)
        {

            string[] LinhaDados = new string[MatrizDados.GetLength(1)];

            dataGridViewInputOutput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            for (int linha = 0; linha < MatrizDados.GetLength(0); linha++)
            {
                for (int Coluna = 0; Coluna < MatrizDados.GetLength(1); Coluna++)
                {
                    LinhaDados[Coluna] = Convert.ToString(MatrizDados[linha, Coluna]);
                }

                dataGridViewInputOutput.Rows.Add(LinhaDados);

                dataGridViewInputOutput.Rows[linha].HeaderCell.Value = LinesName[linha];
            }
            dataGridViewInputOutput.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

        }

        private void allDataPreview_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewInputOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}