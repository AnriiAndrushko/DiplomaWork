using GeneticAlgo.Abstract;
using GeneticAlgo;
using GeneticAlgo.DTO;
using MathNet.Numerics.LinearAlgebra;
using System.Text;
using System.Globalization;

namespace Win_Forms_GUI
{
    public partial class Form1 : Form
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        private event Action<double, double> writeCurrentGenerationData;
        GeneticAlgoBase ga;
        string inputFileContent = string.Empty;
        string filePathToWrite;
        public Form1()
        {
            InitializeComponent();
            writeCurrentGenerationData = (avgFitness, biggestFitness) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //File.AppendAllText("avgFitnes_plot.txt", avgFitness.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +", ");
                    //File.AppendAllText("biggestFitness_plot.txt", biggestFitness.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +", ");
                    LogTextBox.AppendText("Avg fitness: " + avgFitness + Environment.NewLine);
                    LogTextBox.AppendText("Biggest fitness: " + biggestFitness + Environment.NewLine);
                });
            };
        }

        private void startSimBtn_Click(object sender, EventArgs e)
        {
            startSimBtn.Enabled = false;
            SelectFileBtn.Enabled = false;
            int population, maxGenerations, stagnationLimit, eliteCount,
                matrixSize = 10, xMin, xMax, dMin = -100, dMax = 100;
            double selectionAmount, mutationRate, mutationAmount, variationPercent;
            VariableRange[] xRanges;
            Matrix<double> A;
            Vector<double> x0,B,C;

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

                    A = GenerateNonSingularMatrix(matrixSize, matrixSize);
                    x0 = Vector<double>.Build.Dense(matrixSize, i => random.NextDouble() * (dMax - dMin) + dMin);
                    B = A * x0;
                    C = Vector<double>.Build.Dense(matrixSize, i => SumColumn(A, i));

                }
                else
                {
                    string[] lines = inputFileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    List<double[]> matrixRows = new List<double[]>();
                    Vector<double> bVector = null;
                    List<VariableRange> xRangeList = new List<VariableRange>();
                    int numRows = 0;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i].Trim();
                        if (line.StartsWith("A:"))
                        {
                            // Parse matrix A

                            while (i + numRows + 1 < lines.Length && !lines[i + numRows + 1].StartsWith("B:"))
                            {
                                matrixRows.Add(ParseRow(lines[i + numRows + 1]));
                                numRows++;
                            }
                        }
                        else if (line.StartsWith("B:"))
                        {
                            // Parse vector B
                            bVector = Vector<double>.Build.DenseOfArray(ParseRow(lines[i + 1]));
                        }
                        else if (line.StartsWith("X ranges:"))
                        {
                            // Parse X ranges
                            for (int j = 0; j < numRows; j++)
                            {
                                xRangeList.Add(ParseRange(lines[i + 1 + j]));
                            }
                        }
                    }

                    A = Matrix<double>.Build.DenseOfRows(matrixRows);
                    B = bVector;
                    xRanges = xRangeList.ToArray();
                    C = Vector<double>.Build.Dense(numRows, i => SumColumn(A, i));
                }
            }
            catch
            {
                LogTextBox.AppendText("Wrong parameters" + Environment.NewLine);
                startSimBtn.Enabled = true;
                SelectFileBtn.Enabled = true;
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

            Task.Run(() => RunAlgorytm(A, B, C, parameters, variationPercent, xRanges, matrixSize, dMax, dMin));
        }

        void RunAlgorytm(Matrix<double> A, Vector<double> B, Vector<double> C, GA_Params parameters, double variationPercent, VariableRange[] xRanges, int matrixSize, double dMax, double dMin)
        {
            filePathToWrite = "output.txt";
            StringBuilder sb = new StringBuilder();
            sb.Append("A:\n" + A.ToString(1000, 1000) + Environment.NewLine);
            sb.Append("B:\n" + B.ToString() + Environment.NewLine);
            sb.Append("C:\n" + C.ToString() + Environment.NewLine);
            //sb.Append("x0:\n" + x0.ToString() + Environment.NewLine);


            File.WriteAllText(filePathToWrite, sb.ToString());


            ga = new GA_WithRestrictions(A, B, C, xRanges, variationPercent, parameters);

            ga.currentGenerationData += writeCurrentGenerationData;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = ga.Run();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            sb = new StringBuilder();
            sb.Append("---------------------------------" + Environment.NewLine);
            sb.Append("Time: " + elapsedMs.ToString() + "ms" + Environment.NewLine);
            //sb.Append("Distance: " + CalculateAverageDistance(res.BestResult.X, x0).ToString() + Environment.NewLine);
            sb.Append(res.ToString());
            this.Invoke((MethodInvoker)delegate
            {
                LogTextBox.AppendText(sb.ToString());
                startSimBtn.Enabled = true;
                SelectFileBtn.Enabled = true;
            });
            File.AppendAllText(filePathToWrite, sb.ToString());
        }

        static double[] ParseRow(string rowText)
        {
            return rowText.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        static VariableRange ParseRange(string rangeText)
        {
            string[] rangeValues = rangeText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double xMin = double.Parse(rangeValues[0], CultureInfo.InvariantCulture);
            double xMax = double.Parse(rangeValues[1], CultureInfo.InvariantCulture);
            return new VariableRange(xMin, xMax);
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
                matrix = Matrix<double>.Build.Dense(rows, cols, (i, j) => random.NextDouble());
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ga != null && ga.currentGenerationData != null)
            {
                ga.currentGenerationData -= writeCurrentGenerationData;
            }
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            PathToFileBox.Text = filePath;
            inputFileContent = fileContent;
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }
    }
}
