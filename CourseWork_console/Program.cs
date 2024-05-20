using GeneticAlgo;
using GeneticAlgo.DTO;
using MathNet.Numerics.LinearAlgebra;
using GeneticAlgo.Abstract;


Random random = new Random(Guid.NewGuid().GetHashCode());

int matrixSize = 10;
// Крок 1: Генерація матриці A
var A = GenerateNonSingularMatrix(matrixSize, matrixSize);

// Крок 2: Генерація розв'язку x0
var x0 = Vector<double>.Build.Dense(matrixSize, i => random.NextDouble() * 2000 - 1000);

// Крок 3: Формування матриці B
var B = A * x0;

// Крок 4: Вектор C
var C = Vector<double>.Build.Dense(matrixSize, i => SumColumn(A, i));

//Matrix<double> A = Matrix<double>.Build.DenseOfArray(new double[,] { { 0.5, 0.3 },
//                                                                     { 0.2, 0.6 } });
//var x0 = Vector<double>.Build.DenseOfArray(new double[] { 10, 10 });
//var B = A * x0;
//var C = Vector<double>.Build.Dense(x0.Count, i => SumColumn(A, i));

VariableRange[] xRanges = new VariableRange[matrixSize];
for (int i = 0; i < matrixSize; i++)
{
    xRanges[i] = new VariableRange(-10000, 10000);
}




for (int j = 0; j < 19; j++)
{


    GA_Params gaParams = new GA_Params(
        5000,
        20000,
        0.35,
        0.35,
        50,
        10000,
        350,
        5
        );

    //Console.WriteLine("Matrix A:");
    //Console.WriteLine(A);
    //Console.WriteLine("Vector x0:");
    //Console.WriteLine(x0);
    //Console.WriteLine("Matrix B:");
    //Console.WriteLine(B);
    //Console.WriteLine("Vector C:");
    //Console.WriteLine(C);

    GeneticAlgoBase ga = new GA_WithRestrictions(A, B, C, xRanges, 0.0f, gaParams);


    //Console.WriteLine("Press any key to begin");
    //Console.ReadKey();



    //ga.currentGenerationBest += (currentBest) => {
    //    Console.Clear();
    //    Console.WriteLine("Current generation best: " + currentBest);
    //};


    var watch = System.Diagnostics.Stopwatch.StartNew();
    var res = ga.Run();

    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;
    Console.WriteLine(elapsedMs);
    Console.WriteLine(CalculateAverageDistance(res.BestResult.X, x0));
}
//Console.Clear();
//Console.WriteLine(res);

//Console.WriteLine("Correct answer x0:");
//Console.WriteLine(x0);

Matrix<double> GenerateNonSingularMatrix(int rows, int cols)
{
    Matrix<double> matrix;
    do
    {
        matrix = Matrix<double>.Build.Dense(rows, cols, (i, j) => random.NextDouble() * 2000-1000);
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

//static double CalculateAverageDistance(Matrix<double> matrix1, Matrix<double> matrix2)
//{
//    if (matrix1.RowCount != matrix2.RowCount || matrix1.ColumnCount != matrix2.ColumnCount)
//    {
//        throw new ArgumentException("Matrices must have the same dimensions.");
//    }

//    double totalDistance = 0;
//    int elementCount = matrix1.RowCount * matrix1.ColumnCount;

//    for (int i = 0; i < matrix1.RowCount; i++)
//    {
//        for (int j = 0; j < matrix1.ColumnCount; j++)
//        {
//            totalDistance += Math.Abs(matrix1[i, j] - matrix2[i, j]);
//        }
//    }

//    return totalDistance / elementCount;
//}

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