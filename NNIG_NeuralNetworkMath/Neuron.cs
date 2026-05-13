/*
 * Based on 
 * NEURAL NETWORK Library
 * Version 0.1 (april 2002)
 * By Fleurey Franck (franck.fleurey@ifrance.com)
 * Distributed under GPL licence (see www.fsf.org)
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace NNIG_NeuralNetworkMath
{
    /// <summary>
    /// Class representing an artificial neuron
    /// </summary>
    /// <remarks>
    /// <code>
    ///  
    ///  --------------> * W[0] \                              -----  
    ///  --------------> * W[1] - + -------> -threshold -------| f | ---------> O
    ///  --------------> * W[i] /                              -----
    ///     SYNAPSES      WEIGHT             THRESHOLD       ACTIVATION       OUTPUT
    ///
    /// </code>
    ///</remarks>
    [Serializable]
    public class Neuron
    {


        #region PROTECTED FIELDS (State variables)

        /// <summary>
        /// Pseudo random number generator to initialize neuron weight
        /// </summary>
        protected static Random rand = new Random();
        /// <summary>
        /// Minimum value for randomisation of weights and threshold
        /// </summary>
        protected double R_MIN = -0.3f;//Alexandra Oliveira (sugestão Luís Silva) antes estava -1
        /// <summary>
        /// Maximum value for randomization of weights and threshold
        /// </summary>
        protected double R_MAX = 0.3f; // Alexandra Oliveira (sugestão Luís Silva)antes estava 1
        /// <summary>
        /// Weight of every synapse
        /// </summary>
        protected double[] w;
        /// <summary>
        /// Last weight of every synapse
        /// </summary>
        protected double[] last_w;
        /// <summary>
        /// Threshold of the neuron
        /// </summary>
        protected double threshold = 0f;
        /// <summary>
        /// Last threshold of the neuron
        /// </summary>
        protected double last_threshold = 0f;
        /// <summary>
        /// Activation function of the neuron
        /// </summary>
        protected ActivationFunction f = null;
        /// <summary>
        /// Value of the last neuron ouput
        /// </summary>
        protected double o = 0f;
        /// <summary>
        /// Last value of synapse sum minus threshold
        /// </summary>
        protected double ws = 0f;
        /// <summary>
        /// Usefull for backpropagation algorithm
        /// </summary>
        protected double a;
        protected double b;

        protected double[] aS;





        #endregion

        #region PUBLIC ACCES TO STATE OF THE NEURON

        /// <summary>
        ///  Number of neuron inputs (synapses)
        /// </summary>
        public int N_Inputs
        {
            get { return w.Length; }
        }
        /// <summary>
        /// Indexer of the neuron to get or set weight of synapses
        /// </summary>
        public double this[int synapse]
        {
            get { return w[synapse]; }
            set { last_w[synapse] = w[synapse]; w[synapse] = value; }
        }
        /// <summary>
        /// To get or set the threshold value of the neuron
        /// </summary>
        public double Threshold
        {
            get { return threshold; }
            set { last_threshold = threshold; threshold = value; }
        }
        /// <summary>
        /// Get the last output of the neuron
        /// </summary>
        public double Output
        {
            get { return o; }
        }
        /// <summary>
        /// Get the last output prime of the neuron (f'(ws))
        /// </summary>
        public double OutputPrime
        {
            get { return f.OutputPrime(ws); }
        }
        /// <summary>
        /// Get the last sum of inputs
        /// </summary>
        public double WS
        {
            get { return ws; }
        }
        /// <summary>
        /// Get or set the neuron activation function
        /// </summary>
        public ActivationFunction F
        {
            get { return f; }
            set { f = value; }
        }
        /// <summary>
        /// Get or set a value of the neuron
        /// (usefull for backpropagation learning algorithm)
        /// </summary>
        public double A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }

        /// <summary>
        /// Get or set a value of the neuron
        /// (usefull for backpropagation learning algorithm)
        /// </summary>
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
            }
        }

        /// <summary>
        ///  Get or set a value of the neuron
        /// (usefull for backpropagation learning algorithm batch mode)
        /// Alexandra
        /// </summary>
        public double[] ASinapse
        {

            get { return aS; }
            set { aS = value; }
        }

        /// <summary>
        /// Get the last threshold value of the neuron
        /// </summary>
        public double Last_Threshold
        {
            get { return last_threshold; }
        }
        /// <summary>
        /// Get the last weights of the neuron
        /// </summary>
        public double[] Last_W
        {
            get { return last_w; }
        }
        /// <summary>
        /// Get or set the minimum value for randomisation of weights and threshold
        /// </summary>
        public double Randomization_Min
        {
            get { return R_MIN; }
            set { R_MIN = value; }
        }
        /// <summary>
        /// Get or set the maximum value for randomization of weights and threshold
        /// </summary>
        public double Randomization_Max
        {
            get { return R_MAX; }
            set { R_MAX = value; }
        }

        #endregion

        #region NEURON CONSTRUCTOR

        /// <summary>
        /// Build a neurone with Ni inputs
        /// </summary>
        /// <param name="Ni">number of inputs</param>
        /// <param name="af">The activation function of the neuron</param>
        public Neuron(int Ni, ActivationFunction af)
        {
            LibAlg lib = new LibAlg();

            w = new double[Ni];
            last_w = new double[Ni];
            f = af;


        }
        /// <summary>
        /// Build a neurone with Ni inputs whith a default 
        /// activation function (SIGMOID)
        /// </summary>
        /// <param name="Ni">number of inputs</param>
        public Neuron(int Ni)
        {
            w = new double[Ni];
            last_w = new double[Ni];
            f = new SigmoidActivationFunction();
        }

        #endregion

        #region PUBLIC METHODS (INITIALIZATION FUNCTIONS)

        /// <summary>
        /// Randomize Weight for each input between R_MIN and R_MAX
        /// </summary>
        public void randomizeWeight()
        {
            for (int i = 0; i < N_Inputs; i++)
            {
                w[i] = R_MIN + (((double)(rand.Next(1000))) / 1000f) * (R_MAX - R_MIN);
                last_w[i] = 0f;
            }
        }
        /// <summary>
        /// Randomize the threshold (between R_MIN and R_MAX)
        /// </summary>
        public void randomizeThreshold()
        {
            threshold = R_MIN + (((double)(rand.Next(1000))) / 1000f) * (R_MAX - R_MIN);
        }
        /// <summary>
        /// Randomize the threshold and the weights
        /// </summary>
        public void randomizeAll()
        {
            randomizeWeight();
            randomizeThreshold();
        }

        #endregion

        #region PUBLIC METHODS (COMPUTE THE OUTPUT VALUE)

        /// <summary>
        /// Compute the output of the neurone
        /// </summary>
        /// <param name="input">The input vector</param>
        /// <returns>The output value of the neuron ( =f(ws) )</returns>
        public double ComputeOutput(double[] input)
        {
            if (input.Length != N_Inputs)
                throw new Exception("NEURONE : Wrong input vector size, unable to compute output value");
            ws = 0;
            for (int i = 0; i < N_Inputs; i++)
                ws += w[i] * input[i];
            ws += threshold;
            if (f != null)
                o = f.Output(ws);
            else
                o = ws;
            return o;
        }
        #endregion
    }
}
