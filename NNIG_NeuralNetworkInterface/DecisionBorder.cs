using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;
using ZedGraph;

namespace NNIG_NeuralNetworkInterface
{
    public partial class DecisionBorder : Form
    {
        #region Variables

        ArrayList DataLabel;
        
        ArrayList DataXVariable;
        ArrayList DataYVariable;
        ArrayList DataVariableIndex;

        GraphPane myPane;

        double XStep;
        double YStep;

        int ResolutionPoints;
        int ColumnInput1;
        int ColumnInput2;
        int DataTargets;

        private NeuralNetwork nn;

        private double[] VariablesOptions;
        private double[,] InputData;
        private double[,] ExpectedOutput;


        LineItem curve;

        ClassificationMatrix DetermineClass = new ClassificationMatrix();

        #endregion


        #region Public Access to the Class
        public NeuralNetwork AccesstoNN
        {
            set { nn = value; }
        }

        public ArrayList VariablesNames
        {
            get { return DataLabel; }
            set { DataLabel = value; }
        }

        public double[] isInputorOutput
        {
            get { return VariablesOptions; }
            set { VariablesOptions = value; }
        }


        public double[,] DataToDisplay
        {
            get { return InputData; }
            set { InputData = value;}
        }

        #endregion

        #region Constructors

        public DecisionBorder()
        {
            InitializeComponent();
        }

        public DecisionBorder(double[,] Data, NeuralNetwork NN, ArrayList VariabelsCaptions, double[] InputsorOutputs)
        {
            InitializeComponent();

            InputData = Data;
            nn = NN;
            DataLabel = VariabelsCaptions;
            VariablesOptions = InputsorOutputs;
        
        }


        #endregion

        #region Zerox
        //public ArrayList Zerox(double[,] nnOutputNormalized, double[] NNClassifications)
        //{
        //    double tol = 0.001;
            
        //    int n = nnOutputNormalized.GetLength(0);
           
        //    int[] ChangingClasse;
            
        //    LibAlg NeuralMath = new LibAlg();

        //    ArrayList Roots = new ArrayList();//saves the zero crossings of nnOutput

        //    for (int i = 0; i < n - 2; i++)
        //    {
        //        for (int j = 0; j < nnOutputNormalized.GetLength(1); j++)
        //        {
        //            if ((Math.Sign(nnOutputNormalized[i, j]) != Math.Sign(nnOutputNormalized[i + 1, j])) || Math.Abs(nnOutputNormalized[i, j]) < tol)
        //            {
        //                ChangingClasse = new int[3];

        //                ChangingClasse[0] = i;
        //                ChangingClasse[1] = (int)NNClassifications[i];
        //                ChangingClasse[2] = (int)NNClassifications[i + 1];

        //                Roots.Add(ChangingClasse);
                       
        //                break; //terminates the for loop. We only need one diference between the coordinates of the target.
        //            }
        //        }
        //    }
        //    for (int j = 0; j < nnOutputNormalized.GetLength(1); j++)
        //    {
        //        if (Math.Abs(nnOutputNormalized[n - 1, j]) < tol)
        //        {
        //            ChangingClasse = new int[3];
        //            ChangingClasse[0] = n - 1;
        //            ChangingClasse[1] =(int) NNClassifications[n - 1]; 
        //            ChangingClasse[2] = -1;


        //            Roots.Add(ChangingClasse);
        //            break;

        //        }
        //    }

        //    return Roots;
        //}
        #endregion

        public ArrayList Zerox(ActivationFunction AFunction, double[,] nnOutput)
        {
            double tol = 0.001;

            int n = nnOutput.GetLength(0);

            double MiddlePoint = (AFunction.FunctionUpperLimit + AFunction.FunctionLowerLimit) / 2;

            int ChangingClasse;

            LibAlg NeuralMath = new LibAlg();

            ArrayList Roots = new ArrayList();//saves the zero crossings of nnOutput

            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < nnOutput.GetLength(1); j++)
                {
                    if (Math.Sign(nnOutput[i, j] - MiddlePoint) != Math.Sign(nnOutput[i + 1, j] - MiddlePoint) || Math.Abs(nnOutput[i, j] - MiddlePoint) < tol)
                    {
                        ChangingClasse = new int() ;
                        ChangingClasse = i;

                        Roots.Add(ChangingClasse);

                        break; //terminates the for loop. We only need one diference between the coordinates of the target.
                    }
                }
            }
            for (int j = 0; j < nnOutput.GetLength(1); j++)
            {
                if (Math.Abs(nnOutput[n - 1, j]) < tol)
                {
                    ChangingClasse = new int();
                    ChangingClasse = n-1;

                    Roots.Add(ChangingClasse);
                    break;

                }
            }

            return Roots;
        }


         /// <summary>
        /// Determines the coordinates  of the decision border of an MLP
        /// </summary>
        /// <param name="ColunmInput1">Column of the inputs to display in the X-axis</param>
        /// <param name="ColumnInput2">Column of the inputs to display in the Y-axis</param>
        /// <param name="Inputs">Matriz of inputs</param>
        /// <param name="nn">Neural Network</param>
        /// <param name="Resolution">The number of resolution points</param>
        /// <returns></returns>
        public ArrayList DecisionBorderCoordinatesLabels(int Resolution)
        {
            LibAlg NeuralMath = new LibAlg();

           // ClassificationMatrix Classification = new ClassificationMatrix ();

          //  LinearScaling RangeInterval; //projectar para o intervalo [-1,1];
          
            if (DataXVariable != null && DataYVariable != null)
            {
                double[] xvariabel = new double[DataXVariable.Count]; // guardar a abcissa dos pontos onde vamos avaliar a função            
                double[] yvariabel = new double[DataYVariable.Count]; // guardar a ordenada dos pontos onde vamos avaliar a função
                for (int i = 0; i < DataXVariable.Count; i++) 
                {
                    xvariabel[i] = (double)DataXVariable[i]; //eixo dos xx
                    yvariabel[i] = (double)DataYVariable[i]; //  eixo dos yy
                }


              //  double[,] OutputOfNetNormalized = new double[Resolution + 11, nn.N_Outputs];// Saves the results of the neural network when the inputs are coordinates of the space where the inputs are represented 
                double[,] OutputOfNet = new double[Resolution + 11, nn.N_Outputs];//importante para a classfificação

                double xmin = NeuralMath.ComputeMinimumElementVector(xvariabel); //ponto inicial do eixo do xx
                double xmax = NeuralMath.ComputeMaximumElementVector(xvariabel); // ponto final do eixo dos yy

                double Stepx = (xmax - xmin) / Resolution; //step x

                XStep = Stepx; 

                double ymin = NeuralMath.ComputeMinimumElementVector(yvariabel); // ponto inicial do eixo do yy
                double ymax = NeuralMath.ComputeMaximumElementVector(yvariabel); // ponto final do eixo do yy

                double Stepy = (ymax - ymin) / Resolution; //step yy
                YStep = Stepy;

                double xaux = xmin - 5 * XStep;
                double yaux;
                
                double[] CoordinatesPlusLabel = new double[4];

                BorderPoints DecisionBorderPoints;

                ArrayList ZeroCrossingCoordinates = new ArrayList();

                double[] x = new double[nn.N_Inputs];//todos os elementos vão ser zero excepto os escolhidos para a representação.

               // double[] RightNeighbour = new double[nn.N_Inputs];//vizinho à direita - necessário para desenhar as curvas
              //  double[] RightNeighbourOutput = new double[nn.N_Outputs];//necessário para o desenho das curvas de decisão

                x = NeuralMath.FillVectorWithA(x, 0); //inicializar com zeros
                
                ArrayList xy = new ArrayList();

                double[] outputvector = new double[nn.N_Outputs];

                for (int i = 0; i <= Resolution + 10; i++)//fixar a horizontal
                {
                    x[ColumnInput1] = xaux;

                    yaux = ymin - 5 * YStep;
                   
                    for (int j = 0; j <= Resolution + 10; j++)//fixar a vertical acrecentar1 ponto 
                    {
                        x[ColumnInput2] = yaux;
                        
                        outputvector = nn.Output(x); // Calcular a resposta da rede neuronal para aquele padrão
                        
                  //      RangeInterval = new LinearScaling(outputvector, -1, 1); //projectá-lo no intervalo [-1,1]
                        
               //         double[] OutputVectorNormalized = RangeInterval.ComputeNormalizedVector(nn[nn.N_Layers-1].F.FunctionLowerLimit,nn[nn.N_Layers-1].F.FunctionUpperLimit); // vector de saída no intervalo de [-1,1]

                        for (int k = 0; k < outputvector.Length; k++)
                        {
                            OutputOfNet[j, k] = outputvector[k];  //formar a matriz de saída para esta direcçãoo vertical
                           // OutputOfNetNormalized[j, k] = OutputVectorNormalized[k];
                        }

                        yaux += Stepy; //passar para o próximo ponto

                    }//end for go to next vertical point

                    #region
                    //   double[] NNClassifications = Classification.ConstructClassVector(OutputOfNet,nn[nn.N_Layers-1].F.Name);

                    //ZeroCrossingCoordinates = Zerox(OutputOfNetNormalized, NNClassifications);
                    #endregion

                    ZeroCrossingCoordinates = Zerox(nn[nn.N_Layers-1].F, OutputOfNet);

                   for (int l = 0; l < ZeroCrossingCoordinates.Count;l++)
                   {
                        DecisionBorderPoints = new BorderPoints();//criar novo objecto
                        DecisionBorderPoints.XCoordinate = xaux;
                        DecisionBorderPoints.YCoordinate = ymin - 5 * YStep  + Stepy * (int)ZeroCrossingCoordinates[l];
                        
#region To be deleted
                        // DecisionBorderPoints.ItsClass = ((int[])ZeroCrossingCoordinates[l])[1];
                      //  DecisionBorderPoints.ItsUpperNeighbourClass = ((int[])ZeroCrossingCoordinates[l])[2];

                       // RightNeighbour[ColumnInput1] = DecisionBorderPoints.XCoordinate + XStep; //errado
                      //  RightNeighbour[ColumnInput2] = DecisionBorderPoints.YCoordinate;//errado

                       // RightNeighbourOutput = nn.Output(RightNeighbour);

                        //double[,] AuxRightNeighbourOutput = new double[1, RightNeighbourOutput.Length];
                        //// convert RightNeighbour into a matrix....
                        //for (int m = 0; m < RightNeighbourOutput.Length; m++)
                        //{
                        //    AuxRightNeighbourOutput[0, m] = RightNeighbourOutput[m];
                        //}

                        //  DecisionBorderPoints.ItsRightNeighbourClass = (int)Classification.ConstructClassVector(AuxRightNeighbourOutput, nn[nn.N_Layers - 1].F.Name)[0];
#endregion 

                        xy.Add(DecisionBorderPoints);
                    }

                    xaux += Stepx; // passar para a próxima barra horizontal


                }//end for 
                return xy;
            }

            else
            {
                ArrayList PrevenirErros = new ArrayList();
                return PrevenirErros;
            }

        } //end method DecisionBorderCoordinatesLabels

        #region DecisionBorderCurves
        /// <summary>
        /// Determine the curve the link the point that belong to the decision curve
        /// </summary>
        /// <param name="ColumnInput1">Column to be drawn in x-axis</param>
        /// <param name="ColumnInput2">Column to be drawn in the y-axis</param>
        /// <param name="Inputs">~Matrix with all the inputs</param>
        /// <param name="Resolution">Number of resolution points</param>
        /// <returns></returns>
        //public ArrayList DecisionBorderCurves(int Resolution)
        //{
        //    ArrayList DecisionBorderPoints = DecisionBorderCoordinatesLabels(Resolution);
        //    ArrayList DecisionBorderPointsCurves = new ArrayList();
        //    ArrayList DecisionBorderCurveObject;

        //    ArrayList IndexesOfItemstobeDeleted;


        //    BorderPoints CurvePoints = new BorderPoints();
        //    BorderPoints CurvePointsAux = new BorderPoints();

        //    ArrayList Curve;
        //    ArrayList CurveAux;

        //    bool FoundPointstoBeLinked = false;

        //    int k = 0;

        //    while (DecisionBorderPoints.Count > 0)//formar as curvas iniciais baseadas nas etiquetas obtidas no barrimento vertical
        //    {
        //        DecisionBorderCurveObject = new ArrayList();
        //        IndexesOfItemstobeDeleted = new ArrayList();

        //        CurvePoints = (BorderPoints)DecisionBorderPoints[0]; //guardar o primeiro ponto da lista

        //        DecisionBorderCurveObject.Add(CurvePoints);// guardar na curva;

        //        DecisionBorderPoints.RemoveAt(0); // retirar da lista

        //        for (int i = 0; i < DecisionBorderPoints.Count; i++) //percorrer a lista que sobra
        //        {
        //            CurvePointsAux = (BorderPoints)DecisionBorderPoints[i];

        //            if (CurvePoints.ItsClass == CurvePointsAux.ItsClass && CurvePoints.ItsUpperNeighbourClass == CurvePointsAux.ItsUpperNeighbourClass)//pontos com a mesma etiqueta 
        //            {

        //                DecisionBorderCurveObject.Add(CurvePointsAux);

        //                IndexesOfItemstobeDeleted.Add(CurvePointsAux);

        //                DecisionBorderPoints.Remove(CurvePointsAux);

        //            }//end if
        //        }//end for

        //        DecisionBorderPointsCurves.Add(DecisionBorderCurveObject);

        //        for (int l = 0; l < IndexesOfItemstobeDeleted.Count; l++)//reformular
        //        {
        //           // DecisionBorderPoints.Remove((BorderPoints)IndexesOfItemstobeDeleted[l]);
        //        }


        //    }// end while

        //    //neste momento temos as primeiras listas construídas (espero) guardas numa array list em forma de array list de objectos....



        //    DecisionBorderCurveObject = new ArrayList();//guardar a nova lista

        //     CurvePoints = new BorderPoints();
        //     CurvePointsAux = new BorderPoints();


        //    while (k < DecisionBorderPointsCurves.Count)
        //    {
        //        Curve = new ArrayList();
        //        Curve = (ArrayList)DecisionBorderPointsCurves[k];
        //        //fixar a lista i

        //        for (int j = k + 1; j < DecisionBorderPointsCurves.Count; j++)//procurar nas seguinte um ponto que corresponda à condição abaixo estabelecida
        //        {
        //            CurveAux = new ArrayList();
        //            CurveAux = (ArrayList)DecisionBorderPointsCurves[j];

        //            foreach (object PointandLabel in Curve)
        //            {
        //                FoundPointstoBeLinked = false;

        //                CurvePoints = (BorderPoints)PointandLabel;


        //                foreach (object PointandLabelAux in CurveAux)
        //                {
        //                    CurvePointsAux = (BorderPoints)PointandLabelAux;

        //                    if (CurvePoints.ItsUpperNeighbourClass == CurvePointsAux.ItsUpperNeighbourClass && CurvePoints.ItsRightNeighbourClass == CurvePointsAux.ItsRightNeighbourClass && ((CurvePoints.XCoordinate - CurvePointsAux.XCoordinate) < XStep || (CurvePoints.YCoordinate - CurvePointsAux.YCoordinate) < YStep))
        //                    {
        //                        DecisionBorderCurveObject = new ArrayList();//guardar a nova lista

        //                        DecisionBorderCurveObject.Add(CurvePoints);
        //                        DecisionBorderCurveObject.Add(CurvePointsAux);

        //                        FoundPointstoBeLinked = true;

        //                        break;

        //                    }//end if 

        //                }//end foreach


        //            }//end forach
        //            if (FoundPointstoBeLinked)
        //            {
        //                DecisionBorderPointsCurves.Add(DecisionBorderCurveObject);
        //            }//end if

        //        }//end for

        //        k++;
        //    }//end while


        //    //3º passo procurar relações na horizontal
        //    while (k < DecisionBorderPointsCurves.Count)
        //    {
        //        Curve = new ArrayList();
        //        Curve = (ArrayList)DecisionBorderPointsCurves[k];
        //        //fixar a lista i

        //        for (int j = k + 1; j < DecisionBorderPointsCurves.Count; j++)//procurar nas seguinte um ponto que corresponda à condição abaixo estabelecida
        //        {
        //            CurveAux = new ArrayList();
        //            CurveAux = (ArrayList)DecisionBorderPointsCurves[j];

        //            foreach (object PointandLabel in Curve)
        //            {
        //                FoundPointstoBeLinked = false;

        //                CurvePoints = (BorderPoints)PointandLabel;


        //                foreach (object PointandLabelAux in CurveAux)
        //                {
        //                    CurvePointsAux = (BorderPoints)PointandLabelAux;

        //                    if (CurvePoints.ItsClass == CurvePointsAux.ItsClass && CurvePoints.ItsRightNeighbourClass == CurvePointsAux.ItsRightNeighbourClass && ((CurvePoints.XCoordinate - CurvePointsAux.XCoordinate) < XStep || (CurvePoints.YCoordinate - CurvePointsAux.YCoordinate) < YStep))
        //                    {
        //                        DecisionBorderCurveObject = new ArrayList();//guardar a nova lista

        //                        DecisionBorderCurveObject.Add(CurvePoints);
        //                        DecisionBorderCurveObject.Add(CurvePointsAux);

        //                        FoundPointstoBeLinked = true;


        //                        break;

        //                    }//end if 

        //                }//end foreach


        //            }//end forach
        //            if (FoundPointstoBeLinked)
        //            {
        //                DecisionBorderPointsCurves.Add(DecisionBorderCurveObject);
        //            }//end if

        //        }//end for

        //        k++;
        //    }//end while


        //    return DecisionBorderPointsCurves;

        //}

        #endregion

        private void DecisionBorder_Load(object sender, EventArgs e)
        {
            myPane = zedGraphControl1.GraphPane;

            myPane.Title.IsVisible = false; //fica sem título pois este ja se encontra no control

        }

        public void PopulateComboBox()
        {
           // DataLabel = new ArrayList();

            if (comboBoxVariableX.Items.Count > 0)
            {
                comboBoxVariableX.Items.Clear();
            
            }
            if ( comboBoxVariY.Items.Count > 0)
            {
                comboBoxVariY.Items.Clear();

            }
            
            DataVariableIndex = new ArrayList();
            
            for (int i = 0; i < VariablesOptions.GetLength(0); i++)
            {
                if (VariablesOptions[i] == 0)
                {
                    if (DataLabel.Count != 0)
                    {
                        comboBoxVariableX.Items.Add(DataLabel[i].ToString());
                        comboBoxVariY.Items.Add(DataLabel[i].ToString());
                    }
                    else
                    {
                        comboBoxVariableX.Items.Add("var " + Convert.ToString(i + 1));
                        comboBoxVariY.Items.Add("var " + Convert.ToString(i + 1));
                    }
                    DataVariableIndex.Add(i);
                }
                if(VariablesOptions[i]==1)
                {
                    DataTargets = i;
                }
               
            }
        }

        private void comboBoxVariableX_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataXVariable = new ArrayList();
            
            int Index;

            Index = comboBoxVariableX.Items.IndexOf(comboBoxVariableX.SelectedItem);

            int OriginalDataIndex = (int)DataVariableIndex[Index];

            ColumnInput1 = OriginalDataIndex;

            for (int i = 0; i < InputData.GetLength(0); i++) 
            {
                DataXVariable.Add(InputData[i, OriginalDataIndex]);

            }
        }

        private void comboBoxVariY_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataYVariable = new ArrayList();
            
            int Index;

            Index = comboBoxVariY.Items.IndexOf(comboBoxVariY.SelectedItem);

            int OriginalDataIndex = (int)DataVariableIndex[Index];

            ColumnInput2 = OriginalDataIndex;

            for (int i = 0; i < InputData.GetLength(0); i++)
            {
                DataYVariable.Add(InputData[i, OriginalDataIndex]);

            }
        }

        private void button1_Click(object sender, EventArgs e)//button Show Scatterplot
        {
            LibAlg NeuralMath = new LibAlg ();

            double[] Targets = new double[InputData.GetLength(0)];
          
            //Set the axis labels
            myPane.Title.Text = comboBoxVariableX.SelectedItem.ToString()+" vr"+comboBoxVariY.SelectedItem.ToString();
            myPane.XAxis.Title.Text = comboBoxVariableX.SelectedItem.ToString();
            myPane.YAxis.Title.Text = comboBoxVariY.SelectedItem.ToString();
            myPane.YAxis.MajorGrid.IsZeroLine = false;

            PointPairList Coordinates = new PointPairList();
            if (InputData != null)
            {
                for (int i = 0; i < InputData.GetLength(0); i++)
                {
                    Coordinates.Add((double)DataXVariable[i], (double)DataYVariable[i], (double)InputData[i, DataTargets]
       );
                    Targets[i] = (double)InputData[i, DataTargets];
                }

                //Generate a red curve with circle symbols, and "Input Data" in the legend

                LineItem DataPoints = myPane.AddCurve("Input Data", Coordinates, Color.Red, SymbolType.Circle);

                DataPoints.Symbol.Size = 12;

                //Set up a red-blue color gradient to be used for the fill
                DataPoints.Symbol.Fill = new Fill(Color.Red, Color.Blue);

                //Turn off the symbol borders
                DataPoints.Symbol.Border.IsVisible = false;

                //Instruct ZedGraph to fill the symbols by selecting a color out of the red-blue gradient based on the Z value. A minimum value with be red, a maximum value will be blue, and the values in between will be a linearly apportioned color between red and blue.

                DataPoints.Symbol.Fill.Type = FillType.GradientByZ;

                DataPoints.Symbol.Fill.RangeMin = 1;
                DataPoints.Symbol.Fill.RangeMax = NeuralMath.ComputeMaximumElementVector(Targets);

                //Turn off the line, so the curve will be symbols only
                DataPoints.Line.IsVisible = false;


                myPane.Legend.IsVisible = false;



                zedGraphControl1.AxisChange();

                Refresh();
            }

        }

        private void numEditResolutionPoints_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ResolutionPoints = Convert.ToInt32(numEditResolutionPoints.Text);
            }
            catch
            { 
                MessageBox.Show("Please check your options for 'Number of Resolution Points'","Error",MessageBoxButtons.OK);
            }
        }

        private void buttonShowDecisionBorder_Click(object sender, EventArgs e)
        {

            ConstructDecisionBorder();
            
            
     }

        public void ClearLastCurve()
        {
            if (curve != null)
            {
                curve.Clear();

                zedGraphControl1.GraphPane.CurveList.RemoveRange(1,zedGraphControl1.GraphPane.CurveList.Count-1);
                zedGraphControl1.Refresh();
            }
        }

        public void ConstructDecisionBorder()
        { 
            ArrayList Curves = new ArrayList();

            if (ResolutionPoints != 0)
            {
               // Curves = DecisionBorderCurves(ResolutionPoints);
                Curves = DecisionBorderCoordinatesLabels(ResolutionPoints);
            }

            for (int i = 0; i < Curves.Count; i++)//fixar as curvas
            {
              //  ArrayList OneCurve = new ArrayList();
//
              //OneCurve = (ArrayList)Curves[i];
//
                PointPairList CurveCoordinates = new PointPairList();
                BorderPoints Points = new BorderPoints();
             
                Points = (BorderPoints)Curves[i];
                
                CurveCoordinates.Add(Points.XCoordinate, Points.YCoordinate);
                
#region
                //for (int j = 0; j < OneCurve.Count; j++)//fixar os pontos da curva
                //{
                //    BorderPoints Points = (BorderPoints)OneCurve[j];

                //    CurveCoordinates.Add(Points.XCoordinate, Points.YCoordinate);
                //}//end for
#endregion
                curve = myPane.AddCurve("", CurveCoordinates, Color.Black, SymbolType.XCross);
                curve.Line.Width = 2.5F;
                curve.Line.IsVisible= false;
                curve.Symbol.Fill = new Fill(Color.Black);
            }//end for 



            myPane.Legend.IsVisible = false;

            zedGraphControl1.AxisChange();

            zedGraphControl1.Refresh();
        }

        private void buttonClearDecisionBorder_Click(object sender, EventArgs e)
        {
            ClearLastCurve();
        }

        private void DecisionBorder_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((NNIG_Software)MdiParent).toolStripButtonDecisionBorder.Enabled = true;
        }

    
 } //end class 

 /// <summary>
 /// Saves the information about the coordinates of the points and the information about the label of the points.
 /// </summary>
 public class BorderPoints
 {
     public double XCoordinate;
     public double YCoordinate;
    // public double ItsClass;
    // public double ItsUpperNeighbourClass;
    // public double ItsRightNeighbourClass;

     public BorderPoints()
     {
         //
         //TODO: Add constructor logic here
         //
     }
  }



}