/*Based on 
 * NEURAL NETWORK Library
 * Version 0.1 (april 2002)
 * By Fleurey Franck (franck.fleurey@ifrance.com)
 * Distributed under GPL licence (see www.fsf.org)
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
using System.IO;

namespace NNIG_NeuralNetworkMath
{

    /// <summary>
    /// The abstract class describing a learning
    /// algorithm for a neural network
    /// </summary>
    [Serializable]
    public abstract class LearningAlgorithm
    {

        #region PROTECTED FIELDS

        /// <summary>
        /// The neural network
        /// </summary>
        protected NeuralNetwork nn;
        /// <summary>
        /// Under this threshold value, learning will be
        /// considered as complete
        /// </summary>
        protected double ERROR_THRESHOLD = 0.001;
        /// <summary>
        /// Max number of iteration to learn data
        /// </summary>
        protected int MAX_ITER = 1000;
        /// <summary>
        /// Input matrix of data to learn
        /// </summary>
        protected double[][] ins;
        /// <summary>
        /// output matrix of data to learn
        /// </summary>
        protected double[][] outs;
        /// <summary>
        /// Number of learning iterations done
        /// </summary>
        protected int iter = 0;
        /// <summary>
        /// Last sum of square errors computed
        /// </summary>
        protected double error = -1;

        protected Boolean Semaphore = true;

        protected ArrayList allErrors;

        protected double ErrorsStandardDeviation;
        
        #endregion

        #region PUBLIC ACCES TO LEARNING ALGORITHM STATE
        /// <summary>
        /// Get the neural network of the learning algorithm
        /// </summary>
        public NeuralNetwork N_Network
        {
            get
            {
                return nn;
            }
        }
        /// <summary>
        /// Get the last square error
        /// </summary>
        public double Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }
        /// <summary>
        /// Get or set the maximum sum of square errors value ( >0)
        /// </summary>
        public double ErrorTreshold
        {
            get
            {
                return ERROR_THRESHOLD;
            }
            set
            {
                ERROR_THRESHOLD = (value > 0) ? value : ERROR_THRESHOLD;
            }
        }
        /// <summary>
        /// Get the current number of learning iterations done
        /// </summary>
        public int Iteration
        {
            get
            {
                return iter;
            }

            set
            {
                iter = value;
            }
        }
        /// <summary>
        /// Get or set the maximum number of learning iterations.
        /// </summary>
        public int MaxIteration
        {
            get
            {
                return MAX_ITER;
            }
            set
            {
                MAX_ITER = (value > 0) ? value : MAX_ITER;
            }
        }

        public Boolean RedLight
        {
            get { return Semaphore; }
            set { Semaphore = value; }
        }

        public ArrayList AllLearningErrors
        {
            get{return allErrors; }
                
        }


        public double GetErrorsStandardDeviations
        {
            get { return ErrorsStandardDeviation; }


        }

        #endregion

        #region CONSTRUCTOR AND METHODS

        /// <summary>
        /// Learning algorithm constructor
        /// </summary>
        /// <param name="n">The neural network to train</param>
        public LearningAlgorithm(NeuralNetwork n)
        {
            nn = n;
        }
        /// <summary>
        /// To train the neuronal network on data.
        /// inputs[n] represents an input vector of 
        /// the neural network and expected_outputs[n]
        /// the expected ouput for this vector. 
        /// </summary>
        /// <param name="inputs">the input matrix</param>
        /// <param name="expected_outputs">the expected output matrix</param>
        public virtual void Learn(double[][] inputs, double[][] expected_outputs)
        {
            if (inputs.Length < 1)
                throw new Exception("LearningAlgorithme : no input data : cannot learn from nothing");
            if (expected_outputs.Length < 1)
                throw new Exception("LearningAlgorithme : no output data : cannot learn from nothing");
            if (inputs.Length != expected_outputs.Length)
                throw new Exception("LearningAlgorithme : inputs and outputs size does not match : learning aborded ");
            ins = inputs;
            outs = expected_outputs;
        }
        #endregion

    }

    #region BackPropagationLearningAlgorithm

    /// <summary>
    /// Implementation of stockastic gradient backpropagation
    /// learning algorithm
    /// </summary>
    /// <remarks>
    /// <code>
    /// 
    ///                      PROPAGATION WAY IN NN
    ///                    ------------------------->
    /// 
    ///        o ----- Sj = f(WSj) ----> o ----- Si = f(WSi) ----> o
    ///      Neuron j                Neuron i                   Neuron k
    ///    (layer L-1)               (layer L)                 (layer L+1)
    /// 
    /// For the neuron i :
    /// -------------------
    /// W[i,j](n+1) = W[i,j](n) + alpha * Ai * Sj + gamma * ( W[i,j](n) - W[i,j](n-1) )
    /// T[i](n+1) = T[i](n) - alpha * Ai + gamma * ( T[i](n) - T[i](n-1) )
    /// 
    ///		with :
    ///				Ai = f'(WSi) * (expected_output_i - si) for output layer
    ///				Ai = f'(WSi) * SUM( Ak * W[k,i] )       for others
    /// 
    /// </code>
    /// 
    /// </remarks>
    [Serializable]
    public abstract class BackPropagationLearningAlgorithm : LearningAlgorithm
    {

        #region PRETECTED FIELDS
        /// <summary>
        /// the alpha parameter of the algorithm
        /// </summary>
        protected double alpha = 0.5;
        /// <summary>
        /// the gamma parameter of the algorithm
        /// </summary>
        protected double gamma = 0.2;
        /// <summary>
        /// The error vector
        /// </summary>
        protected double[] e;




        #endregion

        #region PUBLIC ACCES TO PARAMETERS OF ALGORITHM

        /// <summary>
        /// get or set the alpha parameter of the algorithm
        /// between 0 and 1, must be >0
        /// </summary>
        public double Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = (value > 0) ? value : alpha;
            }
        }
        /// <summary>
        /// get or set the gamma parameter of the algorithm
        /// (Rumelhart coef)
        /// between 0 and 1.
        /// </summary>
        public double Gamma
        {
            get
            {
                return gamma;
            }
            set
            {
                gamma = (value >= 0) ? value : gamma;
            }
        }



        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Build a new BackPropagation learning algorithm instance
        /// with alpha = 0,5 and gamma = 0,3
        /// </summary>
        /// <param name="nn">The neural network to train</param>
        public BackPropagationLearningAlgorithm(NeuralNetwork nn)
            : base(nn)
        {
        }

        #endregion

    }

    [Serializable]
    public class OnlineBackPropagationLearningAlgorithm : BackPropagationLearningAlgorithm
    {
       

        public double Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = (value > 0) ? value : alpha;
            }
        }


        public double Gamma
        {
            get
            {
                return gamma;
            }
            set
            {
                gamma = (value >= 0) ? value : gamma;
            }
        }


        //protected double[] e;
        #region Constructor
        public OnlineBackPropagationLearningAlgorithm(NeuralNetwork nn)
            : base(nn)
        {
        }
        #endregion
        /// <summary>
        /// To train the neuronal network on data.
        /// inputs[n] represents an input vector of 
        /// the neural network and expected_outputs[n]
        /// the expected ouput for this vector. 
        /// </summary>
        /// <param name="inputs">the input matrix</param>
        /// <param name="expected_outputs">the expected output matrix</param>
        public override void Learn(double[][] inputs, double[][] expected_outputs)
        {
            base.Learn(inputs, expected_outputs);
            double[] nout;
            double err;
            iter = 0;
            do
            {
                error = 0f;
                e = new double[nn.N_Outputs];
                for (int i = 0; i < ins.Length; i++)
                {
                    err = 0f;
                    nout = nn.Output(inputs[i]);
                    for (int j = 0; j < nout.Length; j++)
                    {
                        e[j] = outs[i][j] - nout[j];
                        err += e[j] * e[j];
                    }
                    err /= 2f;
                    error += err;

                    //alterarar erro

                    ComputeA(i);
                    setWeight(i);
                }
                iter++;//actualiza o número de iterações antes de testar a condição
            }
            while (iter < MAX_ITER && this.error > ERROR_THRESHOLD);
        }

        /// <summary>
        /// Compute the "A" parameter for each neuron
        /// of the network
        /// </summary>
        /// <param name="i">the index of the curent training data</param>
        protected void ComputeA(int i)
        {
            double sk;
            int l = nn.N_Layers - 1;
            // For the last layer
            for (int j = 0; j < nn[l].N_Neurons; j++)
                nn[l][j].A = nn[l][j].OutputPrime * e[j];
            // For other layer
            for (l--; l >= 0; l--)
            {
                for (int j = 0; j < nn[l].N_Neurons; j++)
                {
                    sk = 0f;
                    for (int k = 0; k < nn[l + 1].N_Neurons; k++)
                        sk += nn[l + 1][k].A * nn[l + 1][k][j];
                    nn[l][j].A = nn[l][j].OutputPrime * sk;
                }
            }
        }

        /// <summary>
        /// Set new neron's weights
        /// </summary>
        /// <param name="i">the index of the curent training data</param>
        protected void setWeight(int i)
        {
            double[] lin;
            for (int j = 0; j < nn.N_Layers; j++)
            {
                if (j == 0)
                    lin = ins[i];
                else
                    lin = nn[j - 1].Last_Output;
                for (int n = 0; n < nn[j].N_Neurons; n++)
                {
                    for (int k = 0; k < nn[j][n].N_Inputs; k++)
                        nn[j][n][k] += alpha * lin[k] * nn[j][n].A + gamma * (nn[j][n][k] - nn[j][n].Last_W[k]);
                    nn[j][n].Threshold += alpha * nn[j][n].A + gamma * (nn[j][n].Threshold - nn[j][n].Last_Threshold);
                }
            }
        }//end setWeight
    }//End online backpropagation



    #endregion


    #region BacthMode


    [Serializable]
    public class BatchBackPropagationLearningAlgorithm : BackPropagationLearningAlgorithm
    {
       

        public double Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = (value > 0) ? value : alpha;
            }
        }


        public double Gamma
        {
            get
            {
                return gamma;
            }
            set
            {
                gamma = (value >= 0) ? value : gamma;
            }
        }
       

        LibAlg NeuralMath = new LibAlg();
        NN_statistics Statistics;
        
        #region Constructor
        public BatchBackPropagationLearningAlgorithm(NeuralNetwork nn)
            : base(nn)
        {
        }
        #endregion

        /// <summary>
        /// To train the neuronal network on data.
        /// inputs[n] represents an input vector of 
        /// the neural network and expected_outputs[n]
        /// the expected ouput for this vector. 
        /// </summary>
        /// <param name="inputs">the input matrix</param>
        /// <param name="expected_outputs">the expected output matrix</param>
        public override void Learn(double[][] inputs, double[][] expected_outputs)
        {

            base.Learn(inputs, expected_outputs);
            double[] nout;
            double[] helper;
            double[] AllPatternsErrors = new double[ins.Length];
            double err;
            iter = 0;
            allErrors = new ArrayList();

            double[] outputtest = new double[ins.Length];//para fazer validação
            double[,] outputtest1layer = new double[ins.Length, nn[0].N_Neurons];//para fazer validação


            #region test
            /*
            string FILE_Output_NAME = "C:/Documents and Settings/aoliveira/Desktop/Programa/testes_software_NNIG/CSharp/Iteration_output_C_sharp.txt";
            string File_1layerOutput_NAME = "C:/Documents and Settings/aoliveira/Desktop/Programa/testes_software_NNIG/CSharp/Iteration_1Layer_Output_c_sharp.txt";
            string File_Name_Error = "C:/Documents and Settings/aoliveira/Desktop/Programa/testes_software_NNIG/CSharp/MSE_itera_C_sharp.txt";
            string File_Name_Weights = "C:/Documents and Settings/aoliveira/Desktop/Programa/testes_software_NNIG/CSharp/Weights_itera_C_sharp.txt";


            FileStream File_output = new FileStream(FILE_Output_NAME, FileMode.OpenOrCreate, FileAccess.Write);
            FileStream File_1stLayer_output = new FileStream(File_1layerOutput_NAME, FileMode.OpenOrCreate, FileAccess.Write);
            FileStream File_error_mse = new FileStream(File_Name_Error, FileMode.OpenOrCreate, FileAccess.Write);
            FileStream File_Weights = new FileStream(File_Name_Weights, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter SWOutput = new StreamWriter(File_output);
            StreamWriter SW1stLayerOutput = new StreamWriter(File_1stLayer_output);
            StreamWriter SWErrorMSE = new StreamWriter(File_error_mse);
            StreamWriter SWWeights = new StreamWriter(File_Weights);
            */
            #endregion


            for (int i = 0; i < nn.N_Layers; i++)
            {
                for (int j = 0; j < nn[i].N_Neurons; j++)
                {

                    helper = new double[nn[i][j].N_Inputs];
                    helper = NeuralMath.FillVectorWithA(helper, 0);

                    nn[i][j].ASinapse = helper;//erro


                }
            }


            double tmperr = 0;

            do
            {
                //if (Semaphore)
               // {
                iter++;//actualiza o número de iterações antes de testar a condição

                #region Escrita dos resultados
                /*
                SWOutput.WriteLine("iteracao" + iter);

                SW1stLayerOutput.WriteLine("iteracao" + iter);

                SWErrorMSE.WriteLine("iteracao" + iter);

                SWWeights.WriteLine("iteracao" + iter);
                */
                #endregion


                tmperr = 0f; //quando alter

                e = new double[nn.N_Outputs];

                for (int i = 0; i < ins.Length; i++)//number of patterns - percorrer colunas
                {
                    err = 0f;

                    nout = nn.Output(inputs[i]); // compute the output for pattern i 

                    #region Escrita dos resultados
                    outputtest[i] = nn.Output(inputs[i])[0]; //testar as saidas da rede, só serva para fazer validação dos resultados....

                    //SWOutput.WriteLine(nn.Output(inputs[i])[0].ToString());


                    for (int k = 0; k < nn[0].N_Neurons; k++)
                    {
                        outputtest1layer[i, k] = nn[0].Output(inputs[i])[k];
                    }//for test 
                    #endregion

                    #region Escrita dos resultados
                    //SW1stLayerOutput.WriteLine(outputtest1layer[i, 0].ToString(), ';', outputtest1layer[i,1]);

                    //SW1stLayerOutput.WriteLine(outputtest1layer[i, 0].ToString());
                    #endregion

                    for (int j = 0; j < nout.Length; j++)// number of output neurons
                    {
                        e[j] = outs[i][j] - nout[j];//target-output da rede

                        err += e[j] * e[j]; //sum squared for that pattern


                    }//end for

                    tmperr += err;

                    //err /= 2f; //cálculo do mse para aquele padrão ?????


                    ComputeA(i);

                    ComputeDeltaE(i);

                    AllPatternsErrors[i] = tmperr;

                }//end for 


                error = tmperr;
                error /= ins.Length;

                #region Escrita dos resultados
                //SWErrorMSE.WriteLine(error.ToString());//test
                #endregion

                SetWeight();

                for (int i = 0; i < nn.N_Layers; i++)//test
                {

                    for (int j = 0; j < nn[i].N_Neurons; j++)
                    {
                        /*
                        for (int k = 0; k < nn[i][j].N_Inputs; k++)
                        {

                            SWWeights.Write(nn[i][j][k].ToString() + ";");
                        }

                        SWWeights.WriteLine(nn[i][j].Threshold.ToString());
                        */
                        nn[i][j].B = 0;
                        nn[i][j].ASinapse = NeuralMath.FillVectorWithA(nn[i][j].ASinapse, 0);
                    }
                }
                //Semaphore = false;
           // }
            //else
            //{
            //    Thread.Sleep(1);
            //}
            allErrors.Add(error);
            }
            while (iter < MAX_ITER);
            // while (iter < MAX_ITER && this.error > ERROR_THRESHOLD);

            Statistics = new NN_statistics(AllPatternsErrors);
            ErrorsStandardDeviation = Statistics.s();

            #region Escrita dos resultados
            /*
            SWOutput.Close();
            SWWeights.Close();
            SW1stLayerOutput.Close();
            SWErrorMSE.Close();
            */
            #endregion


 

        }//end learn

        /// <summary>
        /// Compute the "A" parameter for each neuron
        /// of the network
        /// </summary>
        /// <param name="i">the index of the curent training data</param>
        protected void ComputeA(int i)
        {
            double sk;

            int l = nn.N_Layers - 1;

            // For the last layer
            for (int j = 0; j < nn[l].N_Neurons; j++)//percorre os neurónios
                nn[l][j].A = nn[l][j].OutputPrime * e[j];

            // For other layer
            for (l--; l >= 0; l--)
            {
                for (int j = 0; j < nn[l].N_Neurons; j++)//cada neurónio
                {
                    sk = 0f;

                    for (int k = 0; k < nn[l + 1].N_Neurons; k++)//cada neurónio da camada seguinte
                        sk += nn[l + 1][k].A * nn[l + 1][k][j];
                    nn[l][j].A = nn[l][j].OutputPrime * sk;
                }
            }
        }

        /// <summary>
        /// Compute de dE/dweight
        /// </summary>
        protected void ComputeDeltaE(int i)
        {
            double[] lin;
            double lixo;

            for (int j = 0; j < nn.N_Layers; j++)//camadas da rede neuronal
            {
                if (j == 0)
                    lin = ins[i];
                else
                    lin = nn[j - 1].Last_Output;

                for (int n = 0; n < nn[j].N_Neurons; n++)//para cada neurónio
                {
                    double[] helper = new double[nn[j][n].N_Inputs];
                    double[] helper2 = new double[nn[j][n].N_Inputs];

                    for (int k = 0; k < nn[j][n].N_Inputs; k++)//percorrer as sinapses
                    {
                        helper[k] = nn[j][n].A * lin[k];

                    }

                    lixo = NeuralMath.ComputeSomaVectores(nn[j][n].ASinapse, helper, ref helper2);//não esta bem                    
                    nn[j][n].B += nn[j][n].A;

                    nn[j][n].ASinapse = helper2;
                }
            }

        }// end ComputeDeltaE

        /// <summary>
        /// 
        /// </summary>
        protected void SetWeight()
        {
            for (int i = 0; i < nn.N_Layers; i++)
            {
                for (int j = 0; j < nn[i].N_Neurons; j++)
                {
                    double[] DeltaE = nn[i][j].ASinapse;

                    for (int k = 0; k < nn[i][j].N_Inputs; k++)
                    {
                        nn[i][j][k] += alpha * DeltaE[k] + gamma * (nn[i][j][k] - nn[i][j].Last_W[k]);
                    }
                    nn[i][j].Threshold += alpha * nn[i][j].B + gamma * (nn[i][j].Threshold - nn[i][j].Last_Threshold);
                }
            }


        }//end SetWeight

    }

    #endregion



    #region GeneticLearningAlgorithm

    /// <summary>
    /// A genetic learning algorithm
    /// </summary>
    /// <remarks>
    /// This is an aplication of genetic algorithm to train neural networks.
    /// The population is made of GeneticNeuralNetwork instance which is a
    /// compact representation of neural network. A genetic neural network
    /// represent a set of weights and threshold for a particular neural network.
    /// 
    /// Here is the main loop of the algorithm :
    /// <code>
    ///	  Create initial random population of POPULATION_SIZE neural networks
    ///	   -> Evaluate fitness function (square error on learning values)
    ///	  |   Select best neural networks
    ///	  |   Cross selected networks to make new generation
    ///    -- apply mutation operator on new generation
    ///	  Until error > error_threshold  	   
    /// </code>
    ///</remarks>
    [Serializable]
    public class GeneticLearningAlgorithm : LearningAlgorithm
    {

        #region PROTECTED FIELDS AND PROPERTIES
        /// <summary>
        /// The random number generator
        /// </summary>
        protected static Random rand = new Random();
        /// <summary>
        /// The population size
        /// </summary>
        protected int POPULATION_SIZE = 50;
        /// <summary>
        /// The mutation ratio during crossover
        /// </summary>
        protected int MUTATION_RATIO = 4;
        /// <summary>
        /// Maximum mutation amplitude
        /// </summary>
        protected double MAX_MUTATION_AMP = 1f;
        /// <summary>
        /// The ratio of population selected for crossover
        /// </summary>
        protected int SELECTION_RATIO = 10;
        /// <summary>
        /// The population of GeneticNeuralNetwork
        /// </summary>
        protected ArrayList population;

        #endregion

        #region PUBLIC ACCES TO ALGORITHM STATE

        /// <summary>
        /// Get or set the population size
        /// </summary>
        public int PopulationSize
        {
            get
            {
                return POPULATION_SIZE;
            }
            set
            {

                ArrayList newPop = new ArrayList();
                int index = 0;
                population.Sort();
                while (index < value && index < population.Count)
                {
                    newPop.Add(population[index]);
                    index++;
                }
                while (index < value)
                {
                    newPop.Add(Muted_NeuralNetwork);
                    index++;
                }
                POPULATION_SIZE = value;
            }
        }
        /// <summary>
        /// Get or set the mutation ratio (between 0 and 100)
        /// </summary>
        public int MutationRatio
        {
            get
            {
                return MUTATION_RATIO;
            }
            set
            {
                MUTATION_RATIO = value;
            }
        }
        /// <summary>
        /// Get or set the maximum mutation amplitude
        /// </summary>
        public double MaxMutationAmplitude
        {
            get
            {
                return MAX_MUTATION_AMP;
            }
            set
            {
                MAX_MUTATION_AMP = value;
            }
        }
        /// <summary>
        /// get or set the selection ratio
        /// </summary>
        public int SelectionRatio
        {
            get
            {
                return SELECTION_RATIO;
            }
            set
            {
                SELECTION_RATIO = value;
            }
        }
        #endregion

        #region GENETIC ALGORITHM IMPLEMENTATION
        /// <summary>
        /// Get the random amplitude of a mutation
        /// </summary>
        protected double MutationValue
        {
            get
            {
                return (((double)rand.Next(20000) - 10000f) / 10000) * MAX_MUTATION_AMP;
            }
        }
        /// <summary>
        /// Get a bool with MUTATION_RATIO/100 probability to be true
        /// </summary>
        protected bool Mute
        {
            get
            {
                return (rand.Next(100) < MUTATION_RATIO);
            }
        }
        /// <summary>
        /// Get a random selected neural network in the population
        /// </summary>
        protected int RandSelectionIndex
        {
            get
            {
                return rand.Next(POPULATION_SIZE * SELECTION_RATIO / 100);
            }
        }
        /// <summary>
        /// get a muted GeneticNeuralNetwork from the neural network
        /// </summary>
        protected GeneticNeuralNetwork Muted_NeuralNetwork
        {
            get
            {
                GeneticNeuralNetwork result = new GeneticNeuralNetwork(nn);
                result.Init();
                for (int i = 0; i < result.N_Genes; i++)
                    if (Mute)
                        result[i] += MutationValue;
                return result;
            }
        }
        /// <summary>
        /// Define the crossover operator for 2 GeneticNeuralNetwork
        /// </summary>
        /// <param name="i1">index of mother in population</param>
        /// <param name="i2">index of father in population</param>
        /// <returns>the child</returns>
        protected GeneticNeuralNetwork CrossOver(int i1, int i2)
        {
            GeneticNeuralNetwork result = new GeneticNeuralNetwork(nn);
            GeneticNeuralNetwork ind1 = (GeneticNeuralNetwork)population[i1];
            GeneticNeuralNetwork ind2 = (GeneticNeuralNetwork)population[i2];
            int t = rand.Next(ind1.N_Genes);
            int index = 0;
            while (index < t)
            {
                result[index] = ind1[index];
                if (Mute)
                    result[index] += MutationValue;
                index++;
            }
            while (index < ind1.N_Genes)
            {
                result[index] = ind2[index];
                if (Mute)
                    result[index] += MutationValue;
                index++;
            }
            return result;
        }
        /// <summary>
        /// Compute the new generation
        /// </summary>
        protected void makeNewGeneration()
        {
            ArrayList result = new ArrayList();
            population.Sort();
            result.Add(population[0]);
            int index = 1;
            while (index < POPULATION_SIZE)
            {
                result.Add(CrossOver(RandSelectionIndex, RandSelectionIndex));
                index++;
            }
            population = result;
        }
        /// <summary>
        /// Computes square error for each GeneticNeuralNetwork in population
        /// </summary>
        protected void ComputeErrors()
        {
            double[] nout;
            double err;
            double[] e = new double[nn.N_Outputs];

            foreach (GeneticNeuralNetwork ind in population)
            {
                ind.setWeights();
                ind.Error = 0f;
                for (int i = 0; i < ins.Length; i++)
                {
                    err = 0f;
                    nout = nn.Output(ins[i]);
                    for (int j = 0; j < nout.Length; j++)
                    {
                        e[j] = outs[i][j] - nout[j];
                        err += e[j] * e[j];
                    }
                    err /= 2f;
                    ind.Error += err;
                }
            }
        }

        #endregion

        #region PUBLIC METHODS AND CONSTRUCTOR

        /// <summary>
        /// GeneticLearningAlgorithm constructor
        /// </summary>
        /// <param name="nn">The neural network to train</param>
        public GeneticLearningAlgorithm(NeuralNetwork nn)
            : base(nn)
        {
            population = new ArrayList();
            for (int i = 0; i < POPULATION_SIZE; i++)
                population.Add(Muted_NeuralNetwork);
        }
        /// <summary>
        /// Make a new random population
        /// </summary>
        public void RandomizePopulation()
        {
            for (int i = 0; i < population.Count; i++)
            {
                nn.randomizeAll();
                population[i] = Muted_NeuralNetwork;
            }
        }
        /// <summary>
        /// To train the neuronal network on data.
        /// inputs[n] represents an input vector of 
        /// the neural network and expected_outputs[n]
        /// the expected ouput for this vector. 
        /// </summary>
        /// <param name="inputs">the input matrix</param>
        /// <param name="expected_outputs">the expected output matrix</param>
        public override void Learn(double[][] inputs, double[][] expected_outputs)
        {
            base.Learn(inputs, expected_outputs);

            iter = 0;
            do
            {
                if (iter != 0)
                    makeNewGeneration();
                ComputeErrors();
                population.Sort();
                error = ((GeneticNeuralNetwork)population[0]).Error;
                iter++;
            }
            while (iter < MAX_ITER && this.error > ERROR_THRESHOLD);
            ((GeneticNeuralNetwork)population[0]).setWeights();
        }

        #endregion

        #region GeneticNeuralNetwork
        /// <summary>
        /// Representation of a neural network for the genetic algorithm
        /// </summary>
        [Serializable]
        protected class GeneticNeuralNetwork : IComparable
        {
            /// <summary>
            /// The genes : all neurons weight and threshold
            /// </summary>
            protected double[] genes;
            /// <summary>
            /// The global square error of the neuron
            /// </summary>
            protected double sq_err = -1f;
            /// <summary>
            /// The neural network of the Genetic Neural Network
            /// </summary>
            protected NeuralNetwork nn;
            /// <summary>
            /// Get or set the genes value
            /// </summary>
            public double this[int index]
            {
                get
                {
                    return genes[index];
                }
                set
                {
                    genes[index] = value;
                }
            }
            /// <summary>
            /// Get or set the square error of the Network
            /// </summary>
            public double Error
            {
                get
                {
                    return sq_err;
                }
                set
                {
                    sq_err = value;
                }
            }
            /// <summary>
            /// Get the number of genes of the Genetic Neural Network
            /// </summary>
            public int N_Genes
            {
                get
                {
                    return genes.Length;
                }
            }
            /// <summary>
            /// Build a new Genetic NeuralNetwork from the Neural Network given as parameter
            /// </summary>
            /// <param name="n">The neural network model</param>
            public GeneticNeuralNetwork(NeuralNetwork n)
            {
                nn = n;
                int size = 0;
                for (int i = 0; i < nn.N_Layers; i++)
                    size += (nn[i].N_Inputs + 1) * nn[i].N_Neurons;
                genes = new double[size];
            }
            /// <summary>
            /// Initialize Genetic network from Neural Network
            /// </summary>
            public void Init()
            {
                int index = 0;
                int i, j, k;
                for (i = 0; i < nn.N_Layers; i++)
                    for (j = 0; j < nn[i].N_Neurons; j++)
                    {
                        for (k = 0; k < nn[i][j].N_Inputs; k++)
                            genes[index++] = nn[i][j][k];
                        genes[index++] = nn[i][j].Threshold;
                    }
            }
            /// <summary>
            /// Set Genetic neural network weights to the real neural network
            /// </summary>
            public void setWeights()
            {
                int index = 0;
                int i, j, k;
                for (i = 0; i < nn.N_Layers; i++)
                    for (j = 0; j < nn[i].N_Neurons; j++)
                    {
                        for (k = 0; k < nn[i][j].N_Inputs; k++)
                            nn[i][j][k] = genes[index++];
                        nn[i][j].Threshold = genes[index++];
                    }
            }
            /// <summary>
            /// Compare 2 genetic neural network on their square error
            /// </summary>
            /// <param name="other">another neural network</param>
            /// <returns>the comparative value</returns>
            public int CompareTo(Object other)
            {
                return sq_err.CompareTo(((GeneticNeuralNetwork)other).Error);
            }
        }
        #endregion
    }

    #endregion
    
}
