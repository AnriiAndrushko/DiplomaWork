using GeneticAlgo.Abstract;
using GeneticAlgo;
using GeneticAlgo.DTO;
using MathNet.Numerics.LinearAlgebra;

namespace Win_Forms_GUI
{
    public partial class Form1 : Form
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        private event Action<double> currentGenerationBestHandler;
        GeneticAlgoBase ga;
        public Form1()
        {
            InitializeComponent();
            currentGenerationBestHandler = (currentBest) =>
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    LogTextBox.AppendText("Current generation best: " + currentBest + Environment.NewLine);
                });
            };
        }

        private void startSimBtn_Click(object sender, EventArgs e)
        {
            int population, maxGenerations, stagnationLimit, eliteCount,
                matrixSize = 10, xMin, xMax, dMin = -100, dMax = 100;
            double selectionAmount, mutationRate, mutationAmount, variationPercent;
            VariableRange[] xRanges;

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
                if (checkBox1.Checked)
                {
                    matrixSize = Int32.Parse(MatrixSizeBox.Text);

                    xMin = Int32.Parse(DataXDiapasonMinBox.Text);
                    xMax = Int32.Parse(DataXDiapasonMaxBox.Text);
                    xRanges = new VariableRange[matrixSize];
                    for (int i = 0; i < matrixSize; i++)
                    {
                        xRanges[i] = new VariableRange(xMin, xMax);
                    }
                    dMax = Int32.Parse(DataDiapasonMaxBox.Text);
                    dMin = Int32.Parse(DataDiapasonMinBox.Text);

                }
                else
                {
                    throw new ArgumentException();
                    //todo path to file
                }
            }
            catch
            {
                LogTextBox.AppendText("Wrong parameters" + Environment.NewLine);
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
            Task.Run(() => RunAlgorytm(parameters, variationPercent, xRanges, matrixSize, dMax, dMin));
        }

        void RunAlgorytm(GA_Params parameters, double variationPercent, VariableRange[] xRanges, int matrixSize, double dMax, double dMin)
        {
            // Крок 1: Генерація матриці A
            var A = GenerateNonSingularMatrix(matrixSize, matrixSize, dMax, dMin);

            // Крок 2: Генерація розв'язку x0
            var x0 = Vector<double>.Build.Dense(matrixSize, i => random.NextDouble() * (dMax - dMin) + dMin);

            // Крок 3: Формування матриці B
            var B = A * x0;

            // Крок 4: Вектор C
            var C = Vector<double>.Build.Dense(matrixSize, i => SumColumn(A, i));

            ga = new GA_WithRestrictions(A, B, C, xRanges, variationPercent, parameters);

            ga.currentGenerationBest += currentGenerationBestHandler;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = ga.Run();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            this.Invoke((MethodInvoker)delegate
            {
                LogTextBox.AppendText(elapsedMs.ToString() + Environment.NewLine);
                LogTextBox.AppendText(CalculateAverageDistance(res.BestResult.X, x0).ToString() + Environment.NewLine);
            });
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
        Matrix<double> GenerateNonSingularMatrix(int rows, int cols, double dMax, double dMin)
        {
            Matrix<double> matrix;
            do
            {
                matrix = Matrix<double>.Build.Dense(rows, cols, (i, j) => random.NextDouble() * (dMax - dMin) + dMin);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel1.Visible = false;
                return;
            }
            panel1.Visible = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ga != null && ga.currentGenerationBest != null)
            {
                ga.currentGenerationBest -= currentGenerationBestHandler;
            }
        }
    }
}
