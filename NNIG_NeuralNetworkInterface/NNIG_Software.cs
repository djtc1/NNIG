using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NNIG_NeuralNetworkMath;
using ZedGraph;

namespace NNIG_NeuralNetworkInterface
{
    public partial class NNIG_Software : Form
    {

        #region GlobalVariables

        String BackPropagationChoosen;

        

        int NumberGroupsTrain;
        int TotalIterations;
        int Iterations = 0;
        int MaxIterations;


        double Error = 0;
        double ErrorThreshold = 0;
        double[] VariablesOptions;
        double[] TrueClasses;
        double[] NNClassification;
        double[] NNDeviations;
        double[,] DataMatrix;
        double[,] NNOutput;
        double[][] ExpectedOutput;
        double[][] InputMatrix;
 

        #region Learning Algorithm

        public int IterationsInOnRun;

        public double LearningRate;
        public double Momentum;
        public double MinimumError;

        #endregion

        bool ForClassification;
        bool CrossValidation;
        bool SaveAllAlgorithmValues;
        //bool isRunning = false;
        public bool RunButtonCliked = false;

        public bool IsFormClosing = false;
        public bool reloadInputData = false;

        public LineItem line;

        ArrayList VariablesCaption;
        ArrayList CrossValidationFolds;
        ArrayList CrossValidationExpectedValuesFolds;
        public ArrayList LearningAlgorithmError;
        public ArrayList NNInitialWeights;

        NeuralNetwork NN;

        BackPropagationLearningAlgorithm BackPropLearning;
        ClassificationMatrix DoClassification = new ClassificationMatrix();

        LibAlg NeuralMath;

        #endregion

        #region Public access to the global Variables


        public bool IsDoingCrossValidation
        {
            get { return CrossValidation; }
            set { CrossValidation = value; }
        }

        public bool IsForClassification
        {
            get { return ForClassification; }
            set { ForClassification = value; }
        }

        public int NumberGroupsToTrain
        {
            get { return NumberGroupsTrain; }
            set { NumberGroupsTrain = value; }
        }

        public double[] SetVariablesOptions
        {
            set { VariablesOptions = value; }
        }

        public double[] InputedClassesLabels
        {
            get { return TrueClasses; }
            set { TrueClasses = value; }
        }

        public double[,] EnteredData
        {
            get { return DataMatrix; }
            set { DataMatrix = value; }
        }

        public double[][] InputDataArray
        {
            get { return InputMatrix; }
            set { InputMatrix = value; }
        }


        public double[][] Targets
        {
            get { return ExpectedOutput; }
            set { ExpectedOutput = value; }
        }

        public ArrayList CrossValidationInputFolds
        {
            get { return CrossValidationFolds; }
            set { CrossValidationFolds = value; }
        }

        public ArrayList CrossValidationTargetFolds
        {
            get { return CrossValidationExpectedValuesFolds; }
            set { CrossValidationExpectedValuesFolds = value; }
        }


        public ArrayList SetVariablesCaption
        {
            set { VariablesCaption = value; }
        }


        public MLPEditor AccessToMLPArquitecture
        {
            get { return MLPArchitectureEditor; }
            set { MLPArchitectureEditor = value; }
        }

        public BackPropagation AccessToBackPropagationEditor
        {
            get { return BackPropagationEditor; }
            set { BackPropagationEditor = value; }
        }

        public NeuralNetwork NeuralNet
        {
            get { return NN; }
            set { NN = value; }
        }

        public BackPropagationLearningAlgorithm BackPropagationAlgorithm
        {
            get { return BackPropLearning; }
            set { BackPropLearning = value; }
        }

        public String BackPropagationType
        {
            get { return BackPropagationChoosen; }
            set { BackPropagationChoosen = value; }
        }

        public bool IsSavingAllAlgorithmIterationsValues
        {
            get { return SaveAllAlgorithmValues; }
            set { SaveAllAlgorithmValues = value; }
        }


        #endregion

        #region ChildComponentes

        NNIGINPUTDATA InputData;

        MLPEditor MLPArchitectureEditor;

        BackPropagation BackPropagationEditor;

        public ClassificationMatrixEditor ClassificationResults;

        public ErrorGraph ErrorGraphic;

        OutputPreview ViewOutputs;

        DecisionBorder ViewDecisionBorder;

        ErrorSurface ViewErrorSurface;

        #endregion


        public NNIG_Software()
        {
            InitializeComponent();

        }

        private void toolStripButtonInput_Click(object sender, EventArgs e)
        {

            InputData = new NNIGINPUTDATA();



            if (DataMatrix != null & reloadInputData == true)
            {
                InputData.Data = DataMatrix;
                InputData.ColumnOptions = VariablesOptions;
                InputData.RefreshDataGridOptions(DataMatrix, VariablesOptions, VariablesCaption);
            }

            InputData.MdiParent = this;


            InputData.Show();

            InputData.Location = new Point(0, 0);

            this.toolStripButtonInput.Enabled = false;
        }

        private void toolStripButtonNN_Click(object sender, EventArgs e)
        {
            NNArquitectureChooser ChooseNN = new NNArquitectureChooser();

            ChooseNN.parentWindow = this;

            ChooseNN.Show();

            ChooseNN.Location = new Point(this.Width / 2 - 250, this.Height / 5);

            this.toolStripButtonNN.Enabled = false;
            
        }

        private void toolStripButtonSupLearning_Click(object sender, EventArgs e)
        {

            NNSupervisedLearningAlg ChooseSupervisedLearning = new NNSupervisedLearningAlg();

            ChooseSupervisedLearning.parentWindow = this;

            ChooseSupervisedLearning.Show();

            ChooseSupervisedLearning.Location = new Point(this.Width / 2 - 250, this.Height / 5);

            this.toolStripButtonSupLearning.Enabled = false;
            
        }

        private void toolStripButtonclassificationMatrix_Click(object sender, EventArgs e)
        {
                ClassificationResults = new ClassificationMatrixEditor();

                ClassificationResults.MdiParent = this;

                ClassificationResults.Show();

                ClassificationResults.Location = new Point(170, 560);

                this.toolStripButtonclassificationMatrix.Enabled = false;

                if (RunButtonCliked)
                {
                    DisplayClassificationMatrix();

                }

        }

        private void toolStripButtonErrorGraph_Click(object sender, EventArgs e)
        {
            ErrorGraphic = new ErrorGraph();

            ErrorGraphic.MdiParent = this;

            ErrorGraphic.Show();

            ErrorGraphic.Location = new Point(570, 465);

            this.toolStripButtonErrorGraph.Enabled = false;

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            #region

            //NN.LearningAlg.Iteration = 0;

            //if (ErrorGraphic != null)
            //{
            //    while (isRunning)
            //    {
            //        if (NN.LearningAlg.Error >= 0)
            //        {
            //           ErrorGraphic.CreateGraph(TotalIterations + NN.LearningAlg.Iteration , (float)NN.LearningAlg.Error);
            //         //  ErrorGraphic.CreateGraph( NN.LearningAlg.Iteration, (float)NN.LearningAlg.Error);
            //           NN.LearningAlg.RedLight = true;
            //        }
            //    }
            //}
            //if (ErrorGraphic == null)
            //{
            //    line = new LineItem("MSE");
            //    line.AddPoint(TotalIterations + NN.LearningAlg.Iteration, (float)NN.LearningAlg.Error);

            //    NN.LearningAlg.RedLight = true;

            //}
            #endregion

        }

        private void toolStripButtonRun_Click(object sender, EventArgs e)//buttonStart
        {
            TotalIterations = 0;

            LearningAlgorithmError = new ArrayList();

            if (NN != null && BackPropagationEditor != null && InputData != null)
            {
                #region Star over

                int nlayers = 0, nneurons = 0, nsinapses = 0;

                foreach (ArrayList Neuron in NNInitialWeights)
                {
                    if (nneurons >= NN[nlayers].N_Neurons)
                    {
                        nlayers++;
                        nneurons = 0;
                    }

                    for (int i = 0; i < Neuron.Count; i++)
                    {
                        if (nsinapses < NN[nlayers][nneurons].N_Inputs)
                        {
                            NN[nlayers][nneurons][nsinapses] = (double)Neuron[i];

                        }
                        else
                        {
                            NN[nlayers][nneurons].Threshold = (double)Neuron[i];
                        }
                        nsinapses++;
                    }
                    nneurons++;
                    nsinapses = 0;
                }

                if (ErrorGraphic != null)
                {
                    ErrorGraphic.ClearGraph();

                }

                #endregion

                if (RunButtonCliked == false)
                {
                    switch (BackPropagationChoosen)
                    {
                        case "Batch Backpropagation":

                            BatchBackPropagationLearningAlgorithm Learning = new BatchBackPropagationLearningAlgorithm(NN);

                            Learning.Alpha = LearningRate;
                            Learning.Gamma = Momentum;
                            Learning.MaxIteration = IterationsInOnRun;
                            Learning.ErrorTreshold = MinimumError;

                            NN.LearningAlg = Learning;
                            Error = NN.LearningAlg.Error;

                            break;
                        case "Sequential Backpropagation":

                            break;

                    }
                }
                else
                {
                    toolStripButtonContinue.Enabled = true;

                    TotalIterations = 0;

                    NN.LearningAlg.Error = Error;
                    NN.LearningAlg.ErrorTreshold = ErrorThreshold;
                    NN.LearningAlg.MaxIteration = MaxIterations;
                    BackPropagationEditor.refreshAll(NN);
                }

                // isRunning = true;

                // backgroundWorker.RunWorkerAsync(); //keeps drawing the graph


                if (NN[NN.N_Layers - 1].F.Name == "Hyperbolic Tangent" && ForClassification == true )
                {
                    int lines = 0;
                    int columns = 0;

                    foreach (double[] i in ExpectedOutput)
                    {
                        foreach (int j in i)
                        {

                            if (j == 0)
                            {
                                ExpectedOutput[lines][columns] = -1;

                            }
                            columns++;
                        }
                        lines++;
                        columns = 0;
                    }

                }

                NN.LearningAlg.Learn(InputMatrix, ExpectedOutput);

                // isRunning = false;

                LearningAlgorithmError = NN.LearningAlg.AllLearningErrors;

                if (ErrorGraphic != null)
                {

                    if (NN.LearningAlg.Error >= 0)
                    {
                        for (int i = 0; i < LearningAlgorithmError.Count; i++)
                        {
                            ErrorGraphic.CreateGraph(i++, (double)LearningAlgorithmError[i]);
                        }

                    }

                }
                


                BackPropagationEditor.refreshAll(NN);

                DisplayClassificationMatrix();
               
                DisplayNNOutput();    

                DisplayDecisionBorder();

                RunButtonCliked = true;

                toolStripButtonContinue.Enabled = true;

                Refresh();


            }
        }

        private void toolStripButtonContinue_Click(object sender, EventArgs e)
        {

            if (NN != null && BackPropagationEditor != null && InputData != null)
            {

                TotalIterations = NN.LearningAlg.Iteration;

                //isRunning = true;

                //backgroundWorker.RunWorkerAsync();

                NN.LearningAlg.Learn(InputMatrix, ExpectedOutput);

                //isRunning = false;

                NN.LearningAlg.Iteration += TotalIterations;

                for (int i = 0; i < NN.LearningAlg.AllLearningErrors.Count; i++)
                {
                    LearningAlgorithmError.Add((double)NN.LearningAlg.AllLearningErrors[i]);
                }


                if (ErrorGraphic != null)
                {

                    if (NN.LearningAlg.Error >= 0)
                    {
                        for (int i = TotalIterations; i < LearningAlgorithmError.Count; i++)
                        {
                            ErrorGraphic.CreateGraph(i++, (double)LearningAlgorithmError[i]);
                        }

                    }

                }

                BackPropagationEditor.refreshAll(NN);


                DisplayClassificationMatrix();
               
                DisplayNNOutput();

               

                if (ViewDecisionBorder != null)
                {
                   
                    DisplayDecisionBorder();
                }

                Refresh();


            }

        }

        public void DisplayClassificationMatrix()
        {
            ComputeNNOutput();
           
                if (ClassificationResults != null)
                {
                    ClassificationResults.IsClassfification = ForClassification;

                    ClassificationResults.TheTrueClassifications = TrueClasses;

                    ClassificationResults.NNOutput = NNOutput;

                    ClassificationResults.OutputLayerActivationFunction = NN[NN.N_Layers - 1].F.Name;

                    ClassificationResults.RefreshDataGrid();
                }
            


        }

        private void ComputeNNOutput()
        {

            NeuralMath = new LibAlg();

            NNOutput = new double[InputMatrix.GetLength(0), NN.N_Outputs];

            double[] Outputs = new double[NN.N_Outputs];

            for (int i = 0; i < DataMatrix.GetLength(0); i++)// for each pattern
            {
                double[] Pattern = InputMatrix[i];

                Outputs = NN.Output(Pattern);

                for (int j = 0; j < NN.N_Outputs; j++)
                {
                    NNOutput[i, j] = Outputs[j];
                }

            }

            NNClassification = DoClassification.ConstructClassVector(NNOutput, NN[NN.N_Layers - 1].F.Name);
           
            if (NNClassification.GetLength(0) == TrueClasses.GetLength(0))
            {
                NNDeviations = new double[NNClassification.GetLength(0)];

                for (int i = 0; i < NNClassification.GetLength(0); i++)
                {
                    NNDeviations[i] = NNClassification[i] - TrueClasses[i];
                }
            }
            else
            {
                MessageBox.Show("True Classes and The NeuralNetwork Classification must have the same dimentions");
            }


        }

        private void DisplayNNOutput()
        {
            ComputeNNOutput();
            
            if (ViewOutputs != null)
            {

                ArrayList Neurons = new ArrayList();
                for (int i = 0; i < this.NNOutput.GetLength(1); i++)
                {
                    if (i == 0)
                    {
                        Neurons.Add((i + 1).ToString() + "st Neuron");
                    }
                    else if (i == 1)
                    {
                        Neurons.Add((i + 1).ToString() + "nd Neuron");
                    }
                    else if (i == 2)
                    {
                        Neurons.Add((i + 1).ToString() + "rd Neuron");
                    }
                    else
                    {
                        Neurons.Add((i + 1).ToString() + "th Neuron");
                    }
                }
                Neurons.Add( "Deviations");


                ViewOutputs.ColumnHeadersText = Neurons;
                ViewOutputs.RefreshDataPreview(NNOutput,NNDeviations);
                
                ViewOutputs.textBoxMSE.Text = NN.LearningAlg.Error.ToString();
                ViewOutputs.textBoxST.Text = NN.LearningAlg.GetErrorsStandardDeviations.ToString();

            }

        }

        private void DisplayDecisionBorder()
        {
            if (ViewDecisionBorder != null)
            {
                ViewDecisionBorder.AccesstoNN = this.NN;
                ViewDecisionBorder.VariablesNames = this.VariablesCaption;
                ViewDecisionBorder.isInputorOutput = this.VariablesOptions;
                ViewDecisionBorder.DataToDisplay = this.DataMatrix;
                ViewDecisionBorder.PopulateComboBox();
                ViewDecisionBorder.ClearLastCurve();
                ViewDecisionBorder.ConstructDecisionBorder();
                ViewDecisionBorder.Refresh();
            }
        }

        private void NNIG_Software_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult buttonclose = MessageBox.Show("Do you want to leave?", "NNIG Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (buttonclose.Equals(DialogResult.No))
            {
                e.Cancel = true;
            }

            else
            {
                IsFormClosing = true;
            }


        }

        private void NNIG_Software_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void viewNNOutput_Click(object sender, EventArgs e)
        {
            if (NN != null)
            {
                if (RunButtonCliked)
                {
                    double[] Outputs = new double[NN.N_Outputs];
                   
                    NNOutput = new double[InputMatrix.GetLength(0), NN.N_Outputs];

                    for (int i = 0; i < InputMatrix.GetLength(0); i++)// for each pattern
                    {
                        double[] Pattern = InputMatrix[i];
                        
                        Outputs = NN.Output(Pattern);

                        for (int j = 0; j < NN.N_Outputs; j++)
                        {
                            NNOutput[i, j] = Outputs[j];
                        }

                    }

                    ArrayList Neurons = new ArrayList();
                    
                    for (int i = 0; i < this.NNOutput.GetLength(1); i++)
                    {
                        if (i == 0)
                        {
                            Neurons.Add((i + 1).ToString() + "st Neuron");
                        }
                        else if (i == 1)
                        {
                            Neurons.Add((i + 1).ToString() + "nd Neuron");
                        }
                        else if (i == 2)
                        {
                            Neurons.Add((i + 1).ToString() + "rd Neuron");
                        }
                        else
                        {
                            Neurons.Add((i + 1).ToString() + "th Neuron");
                        }
                    }
                    Neurons.Add("Deviations");

                    ViewOutputs = new OutputPreview(this.NNOutput, NNDeviations);

                    ViewOutputs.MdiParent = this;

                    ViewOutputs.ColumnHeadersText = Neurons;

                    ViewOutputs.textBoxMSE.Text = NN.LearningAlg.Error.ToString();
                    ViewOutputs.textBoxST.Text = NN.LearningAlg.GetErrorsStandardDeviations.ToString();

                    ViewOutputs.Show();

                    ViewOutputs.RefreshDataPreview(this.NNOutput, NNDeviations);

                   
                }
                else
                {
                    ViewOutputs = new OutputPreview();

                    ViewOutputs.MdiParent = this;

                    ViewOutputs.Show();
                }
            }
            else
            {
                ViewOutputs = new OutputPreview();

                ViewOutputs.MdiParent = this;

                ViewOutputs.Show();

            }
            ViewOutputs.Location = new Point(0, 550);
            this.viewNNOutput.Enabled = false;
        }

        private void toolStripButtonDecisionBorder_Click(object sender, EventArgs e)
        {
            if (NN != null)
            {
                if (RunButtonCliked)
                {
                    ViewDecisionBorder = new DecisionBorder(DataMatrix, NN, VariablesCaption, VariablesOptions);

                    ViewDecisionBorder.MdiParent = this;

                    ViewDecisionBorder.Show();

                    ViewDecisionBorder.PopulateComboBox();
         
                }
                else
                {
                    ViewDecisionBorder = new DecisionBorder();

                    ViewDecisionBorder.MdiParent = this;

                    ViewDecisionBorder.Show();

                }
            }
            else
            {
                ViewDecisionBorder = new DecisionBorder();

                ViewDecisionBorder.MdiParent = this;

                ViewDecisionBorder.Show();
            }
            
            ViewDecisionBorder.Location = new Point(250, 195);
            this.toolStripButtonDecisionBorder.Enabled = false;
        }

        private void toolStripButtonErrorSurface_Click(object sender, EventArgs e)
        {
            if (NN != null)
            {
                if (RunButtonCliked)
                {

                    ViewErrorSurface = new ErrorSurface(NN, InputMatrix, ExpectedOutput);
                    
                    ViewErrorSurface.MdiParent = this;

                    ViewErrorSurface.Show();


                }
                else
                {
                    ViewErrorSurface = new ErrorSurface();

                    ViewErrorSurface.MdiParent = this;

                    ViewErrorSurface.Show();

                }
            }
            else
            {
                ViewErrorSurface = new ErrorSurface();

                ViewErrorSurface.MdiParent = this;

                ViewErrorSurface.Show();
                
            }

           this.toolStripButtonErrorSurface.Enabled = false;

        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader ST = new System.IO.StreamReader("About.txt");
            MessageBox.Show(" " + ST.ReadToEnd() + " ");
            ST.Close();
        }

  


    }
}