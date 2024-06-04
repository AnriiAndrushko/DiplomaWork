using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;
using System.Text;
using GeneticAlgo.DTO;
using GeneticAlgo.Utils;

namespace GeneticAlgo
{
    public class Agent : IComparable
    {
        public Matrix<double> A { get; private set; }
        public Vector<double> B { get; private set; }
        public Vector<double> C { get; private set; }
        public Vector<double> X { get; private set; }
        public readonly int LargeNumber;

        public Matrix<double> InitialA;
        public Vector<double> InitialB;
        public Vector<double> InitialC;

        private double _fitness;

        public double Fitness {
            get {
                return _fitness;
            }
        }

        private double changeRangePercent;//this constant and mutationAmount not because mutationAmount can possibly change in algorythm runtime to find more precise answer (TODO)

        public Agent(Matrix<double> a, Vector<double> b, Vector<double> c, Vector<double> x, double changeRangePercent, int largeNumber)
        {
            A = a.Clone();
            B = b.Clone();
            C = c.Clone();
            X = x.Clone();

            InitialA = a.Clone();
            InitialB = b.Clone();
            InitialC = c.Clone();

            LargeNumber = largeNumber;
            this.changeRangePercent = changeRangePercent;
            _fitness = ComputeFitness();
        }

        public void Init(Matrix<double> a, Vector<double> b, Vector<double> c, Vector<double> x, double changeRangePercent, Matrix<double> initialA, Vector<double> initialB, Vector<double> initialC)
        {
            
            A = a;
            B = b;
            C = c;
            X = x;

            InitialA = initialA;
            InitialB = initialB;
            InitialC = initialC;
            this.changeRangePercent = changeRangePercent;
            _fitness = ComputeFitness();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            Agent otherAgent = obj as Agent;
            if (otherAgent != null)
                return this.Fitness.CompareTo(otherAgent.Fitness);
            else
                throw new ArgumentException("Object is not a Agent");
        }

        public void Mutate(double mutationAmount, double mutationRate, VariableRange[] xRanges)
        {
            MutateMatrix(A, InitialA, mutationRate);
            MutateVector(B, InitialB, mutationRate);
            MutateVector(C, InitialC, mutationRate);

            for (int i = 0; i < X.Count; i++)
            {
                if (MultithreadRandom.Instance.NextDouble() < mutationRate)
                {
                    X[i] = MutateWithinBounds(X[i], mutationAmount, xRanges[i]);
                }
            }
            _fitness = ComputeFitness();
        }


        public static (Agent, Agent) Crossover(Agent parent1, Agent parent2, AgentPool pool)
        {
            int crossoverPoint = MultithreadRandom.Instance.Next(1, parent1.X.Count - 1);

            var agent1 = pool.GetAgent();
            var agent2 = pool.GetAgent();

            var child1X = agent1.X;
            var child2X = agent2.X;
            var child1A = agent1.A;
            var child1B = agent1.B;
            var child1C = agent1.C;
            var child2A = agent2.A;
            var child2B = agent2.B;
            var child2C = agent2.C;

            CopyVectorElements(child1X, parent1.X, 0, crossoverPoint);
            CopyVectorElements(child1X, parent2.X, crossoverPoint, parent1.X.Count - crossoverPoint);
            CopyVectorElements(child2X, parent2.X, 0, crossoverPoint);
            CopyVectorElements(child2X, parent1.X, crossoverPoint, parent2.X.Count - crossoverPoint);

            CopyMatrixElements(child1A, parent1.A);
            CopyMatrixElements(child2A, parent2.A);
            CopyVectorElements(child1B, parent1.B, 0, parent1.B.Count);
            CopyVectorElements(child2B, parent2.B, 0, parent2.B.Count);
            CopyVectorElements(child1C, parent1.C, 0, parent1.C.Count);
            CopyVectorElements(child2C, parent2.C, 0, parent2.C.Count);

            int matrixCrossoverPoint = MultithreadRandom.Instance.Next(1, parent1.A.RowCount);
            CrossoverMatrixRows(child1A, child2A, matrixCrossoverPoint);

            int vectorCrossoverPointB = MultithreadRandom.Instance.Next(1, parent1.B.Count);
            CrossoverVectorElements(child1B, child2B, vectorCrossoverPointB);

            int vectorCrossoverPointC = MultithreadRandom.Instance.Next(1, parent1.C.Count);
            CrossoverVectorElements(child1C, child2C, vectorCrossoverPointC);

            agent1.Init(child1A, child1B, child1C, child1X, parent1.changeRangePercent, parent1.InitialA, parent1.InitialB, parent1.InitialC);
            agent2.Init(child2A, child2B, child2C, child2X, parent2.changeRangePercent, parent2.InitialA, parent2.InitialB, parent2.InitialC);

            return (agent1, agent2);
        }

        private static void CopyVectorElements(Vector<double> destination, Vector<double> source, int startIndex, int length)
        {
            for (int i = 0; i < length; i++)
            {
                destination[startIndex + i] = source[startIndex + i];
            }
        }

        private static void CopyMatrixElements(Matrix<double> destination, Matrix<double> source)
        {
            for (int i = 0; i < source.RowCount; i++)
            {
                for (int j = 0; j < source.ColumnCount; j++)
                {
                    destination[i, j] = source[i, j];
                }
            }
        }

        private static void CrossoverMatrixRows(Matrix<double> matrix1, Matrix<double> matrix2, int crossoverPoint)
        {
            for (int i = crossoverPoint; i < matrix1.RowCount; i++)
            {
                for (int j = 0; j< matrix1.RowCount; j++)
                {
                    var tmp = matrix1[i, j];
                    matrix1[i, j] = matrix2[i, j];
                    matrix2[i, j] = tmp;
                }
            }
        }

        private static void CrossoverVectorElements(Vector<double> vector1, Vector<double> vector2, int crossoverPoint)
        {
            for (int i = crossoverPoint; i < vector1.Count; i++)
            {
                double temp = vector1[i];
                vector1[i] = vector2[i];
                vector2[i] = temp;
            }
        }

        private void MutateMatrix(Matrix<double> matrix, Matrix<double> initialMatrix, double mutationRate)
        {
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    if (MultithreadRandom.Instance.NextDouble() < mutationRate)
                    {
                        matrix[i, j] = MutateWithinBounds(initialMatrix[i, j]);
                    }
                }
            }
        }

        private void MutateVector(Vector<double> vector, Vector<double> initialVector, double mutationRate)
        {
            for (int i = 0; i < vector.Count; i++)
            {
                if (MultithreadRandom.Instance.NextDouble() < mutationRate)
                {
                    vector[i] = MutateWithinBounds(initialVector[i]);
                }
            }
        }

        private double MutateWithinBounds(double initialValue)
        {
            double mutation = Normal.Sample(MultithreadRandom.Instance, 0, Math.Abs(initialValue * changeRangePercent));
            double mutatedValue = initialValue + mutation;
            return Math.Max(initialValue * (1 - changeRangePercent), Math.Min(initialValue * (1 + changeRangePercent), mutatedValue));
        }

        private double MutateWithinBounds(double value, double mutationAmmount, VariableRange xRange)
        {
            double mutation = Normal.Sample(MultithreadRandom.Instance, 0, mutationAmmount);//todo
            double mutatedValue = value + mutation;
            return Math.Max(xRange.Min, Math.Min(xRange.Max, mutatedValue));
        }

        private double ComputeFitness()
        {
            double penalty = 0;
            for (int i = 0; i < A.RowCount; i++)
            {
                double constraint = 0;
                for (int j = 0; j < A.ColumnCount; j++)
                {
                    constraint += A[i, j] * X[j];
                }
                penalty += LargeNumber * Math.Abs(constraint - B[i]);
            }
            return -C.DotProduct(X) + penalty;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Initial Matrix A: " + InitialA.ToString(1000,1000));
            sb.AppendLine("Matrix A: " + A.ToString(1000, 1000));
            sb.AppendLine("Initial Matrix B: " + InitialB);
            sb.AppendLine("Vector B: " + B);
            sb.AppendLine("Initial Matrix C: " + InitialC);
            sb.AppendLine("Vector C: " + C);
            sb.AppendLine("Vector X: " + X);
            return sb.ToString();
        }

    }
}