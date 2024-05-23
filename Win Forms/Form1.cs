using System;
using System.Windows.Forms;
using GeneticAlgo.Abstract;
using GeneticAlgo;
using GeneticAlgo.DTO;
using MathNet.Numerics.LinearAlgebra;

namespace Win_Forms_GUI
{
    public partial class Form1 : Form
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        public Form1()
        {
            InitializeComponent();
        }

        private void startSimBtn_Click(object sender, EventArgs e)
        {
            int population, maxGenerations, stagnationLimit, eliteCount;
            double selectionAmount, mutationRate, mutationAmount, variationPercent;
            try
            {
                population = Int32.Parse(PopulationSizeBox.Text);
                maxGenerations = Int32.Parse(MaxGenerationCBox.Text);
                selectionAmount = SelectionAmountTrack.Value * 0.01;
                mutationRate = MutationRateTrack.Value * 0.01;
                mutationAmount = Int32.Parse(MutationAmountBox.Text);
                stagnationLimit = Int32.Parse(StagnationLimitBox.Text);
                eliteCount = Int32.Parse(EliteCountBox.Text);
                variationPercent = VariationPercentTrack.Value * 0.01;
            }
            catch
            {
                LogTextBox.AppendText("Wrong parameters");
                return;
            }


            var parameters = new GA_Params(
                population,
                maxGenerations,
                selectionAmount,
                mutationRate,
                mutationAmount,
                100000,
                stagnationLimit,
                eliteCount
                );
            RunAlgorytm(parameters, variationPercent);
        }

        void RunAlgorytm(GA_Params parameters, double variationPercent)
        {

            int matrixSize = 10;

            VariableRange[] xRanges = new VariableRange[matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                xRanges[i] = new VariableRange(-10000, 10000);
            }

            // Крок 1: Генерація матриці A
            var A = GenerateNonSingularMatrix(matrixSize, matrixSize);

            // Крок 2: Генерація розв'язку x0
            var x0 = Vector<double>.Build.Dense(matrixSize, i => random.NextDouble() * 2000 - 1000);

            // Крок 3: Формування матриці B
            var B = A * x0;

            // Крок 4: Вектор C
            var C = Vector<double>.Build.Dense(matrixSize, i => SumColumn(A, i));

            GeneticAlgoBase ga = new GA_WithRestrictions(A, B, C, xRanges, 0.0f, parameters);


            ga.currentGenerationBest += (currentBest) =>
            {
                LogTextBox.AppendText("Current generation best: " + currentBest);
            };


            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = ga.Run();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            LogTextBox.AppendText(elapsedMs.ToString());
            LogTextBox.AppendText(CalculateAverageDistance(res.BestResult.X, x0).ToString());
        }

        static double CalculateAverageDistance(Vector<double> vector1, Vector<double> vector2)
        {
            if (vector1.Count != vector2.Count)
            {
                throw new ArgumentException("Vectors must have the same dimensions.");
            }

            double totalDistance = 0;
            int elementCount = vector1.Count;

            for (int i = 0; i < vector1.Count; i++)
            {
                totalDistance += Math.Abs(vector1[i] - vector2[i]);
            }

            return totalDistance / elementCount;
        }
        Matrix<double> GenerateNonSingularMatrix(int rows, int cols)
        {
            Matrix<double> matrix;
            do
            {
                matrix = Matrix<double>.Build.Dense(rows, cols, (i, j) => random.NextDouble() * 2000 - 1000);
            }
            while (matrix.Determinant() == 0);
            return matrix;
        }

        double SumColumn(Matrix<double> matrix, int columnIndex)
        {
            double sum = 0;
            for (int i = 0; i < matrix.RowCount; i++)
            {
                sum += matrix[i, columnIndex];
            }
            return sum;
        }

        private void PopulationSizeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void MaxGenerationCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void MutationAmountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void StagnationLimitBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void EliteCountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SelectionAmountTrack_ValueChanged(object sender, EventArgs e)
        {
            SelectionAmountLabel.Text = SelectionAmountTrack.Value.ToString() + "%";
        }

        private void MutationRateTrack_ValueChanged(object sender, EventArgs e)
        {
            MutationRateLabel.Text = MutationRateTrack.Value.ToString() + "%";
        }

        private void VariationPercentTrack_ValueChanged(object sender, EventArgs e)
        {
            VariationPercentLable.Text = VariationPercentTrack.Value.ToString() + "%";
        }
    }
}
