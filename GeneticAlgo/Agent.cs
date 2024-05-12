using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;
using System.Text;
using GeneticAlgo.DTO;
using GeneticAlgo.Utils;

namespace GeneticAlgo
{
    public class Agent
    {
        public Matrix<double> A { get; private set; }
        public Vector<double> B { get; private set; }
        public Vector<double> C { get; private set; }
        public Vector<double> X { get; private set; }

        public readonly Matrix<double> InitialA;
        public readonly Vector<double> InitialB;
        public readonly Vector<double> InitialC;

        private readonly double changeRangePercent;//this constant and mutationAmount not because mutationAmount can possibly change in algorythm runtime to find more precise answer

        public Agent(Matrix<double> a, Vector<double> b, Vector<double> c, Vector<double> x, double changeRangePercent)
        {
            A = a.Clone();
            B = b.Clone();
            C = c.Clone();
            X = x.Clone();

            InitialA = a.Clone();
            InitialB = b.Clone();
            InitialC = c.Clone();
            this.changeRangePercent = changeRangePercent;
        }

        public Agent(Matrix<double> a, Vector<double> b, Vector<double> c, Vector<double> x, double changeRangePercent, Matrix<double> initialA, Vector<double> initialB, Vector<double> initialC)
        {
            A = a;
            B = b;
            C = c;
            X = x;

            InitialA = initialA;
            InitialB = initialB;
            InitialC = initialC;
            this.changeRangePercent = changeRangePercent;
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
        }


        public static (Agent, Agent) Crossover(Agent parent1, Agent parent2)
        {
            int crossoverPoint = MultithreadRandom.Instance.Next(1, parent1.X.Count - 1);

            // Crossover X
            var child1X = Vector<double>.Build.DenseOfEnumerable(parent1.X.Take(crossoverPoint).Concat(parent2.X.Skip(crossoverPoint)));
            var child2X = Vector<double>.Build.DenseOfEnumerable(parent2.X.Take(crossoverPoint).Concat(parent1.X.Skip(crossoverPoint)));

            // Crossover matrices A, B, and C
            var child1A = parent1.A.Clone();
            var child1B = parent1.B.Clone();
            var child1C = parent1.C.Clone();
            var child2A = parent2.A.Clone();
            var child2B = parent2.B.Clone();
            var child2C = parent2.C.Clone();

            // Choose a random row to crossover for matrix A and vector B
            int matrixCrossoverPoint = MultithreadRandom.Instance.Next(1, parent1.A.RowCount);
            CrossoverMatrixRows(child1A, child2A, matrixCrossoverPoint);
            CrossoverVectorElements(child1B, child2B, matrixCrossoverPoint);

            // Choose a random index to crossover for vector C
            int vectorCrossoverPoint = MultithreadRandom.Instance.Next(1, parent1.C.Count);
            CrossoverVectorElements(child1C, child2C, vectorCrossoverPoint);

            return (new Agent(child1A, child1B, child1C, child1X, parent1.changeRangePercent, parent1.InitialA, parent1.InitialB, parent1.InitialC),
                    new Agent(child2A, child2B, child2C, child2X, parent2.changeRangePercent, parent2.InitialA, parent2.InitialB, parent2.InitialC));
        }

        private static void CrossoverMatrixRows(Matrix<double> matrix1, Matrix<double> matrix2, int crossoverPoint)
        {
            for (int i = crossoverPoint; i < matrix1.RowCount; i++)
            {
                var tempRow = matrix1.Row(i);
                matrix1.SetRow(i, matrix2.Row(i));
                matrix2.SetRow(i, tempRow);
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
            double mutation = Normal.Sample(MultithreadRandom.Instance, 0, initialValue * changeRangePercent);
            double mutatedValue = initialValue + mutation;
            return Math.Max(initialValue * (1 - changeRangePercent), Math.Min(initialValue * (1 + changeRangePercent), mutatedValue));
        }

        private double MutateWithinBounds(double value, double mutationAmount, VariableRange xRange)
        {
            double mutation = Normal.Sample(MultithreadRandom.Instance, 0, mutationAmount);//todo
            double mutatedValue = value + mutation;
            return Math.Max(xRange.Min, Math.Min(xRange.Max, mutatedValue));
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Initial Matrix A: " + InitialA);
            sb.AppendLine("Matrix A: " + A);
            sb.AppendLine("Initial Matrix B: " + InitialB);
            sb.AppendLine("Vector B: " + B);
            sb.AppendLine("Initial Matrix C: " + InitialC);
            sb.AppendLine("Vector C: " + C);
            sb.AppendLine("Vector X: " + X);
            return sb.ToString();
        }
    }
}