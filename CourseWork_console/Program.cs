using GeneticAlgo;
using GeneticAlgo.DTO;
using MathNet.Numerics.LinearAlgebra;
using GeneticAlgo.Abstract;


Random random = new Random(Guid.NewGuid().GetHashCode());

// Крок 1: Генерація матриці A
var A = GenerateNonSingularMatrix(10, 10);

// Крок 2: Генерація розв'язку x0
var x0 = Vector<double>.Build.Dense(10, i => random.NextDouble() * 2000 - 1000);

// Крок 3: Формування матриці B
var B = A * x0;

// Крок 4: Вектор C
var C = Vector<double>.Build.Dense(10, i => SumColumn(A, i));

//Matrix<double> A = Matrix<double>.Build.DenseOfArray(new double[,] { { 0.5, 0.3 },
//                                                                     { 0.2, 0.6 } });
//var x0 = Vector<double>.Build.DenseOfArray(new double[] { 10, 10 });
//var B = A * x0;
//var C = Vector<double>.Build.Dense(x0.Count, i => SumColumn(A, i));

VariableRange[] xRanges = new VariableRange[] {
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
    new VariableRange(-10000, 10000),
};

GA_Params gaParams = new GA_Params(
    40000,
    10000,
    0.5,
    0.1,
    100,
    10000,
    200,
    5
    );

Console.WriteLine("Matrix A:");
Console.WriteLine(A);
Console.WriteLine("Vector x0:");
Console.WriteLine(x0);
Console.WriteLine("Matrix B:");
Console.WriteLine(B);
Console.WriteLine("Vector C:");
Console.WriteLine(C);

GeneticAlgoBase ga = new GA_WithRestrictions(A, B, C, xRanges, 0.0f, gaParams);


Console.WriteLine("Press any key to begin");
Console.ReadKey();



ga.currentGenerationBest += (currentBest) => {
    Console.Clear();
    Console.WriteLine("Current generation best: " + currentBest);
};

var res = ga.Run();

Console.Clear();
Console.WriteLine(res);

Console.WriteLine("Correct answer x0:");
Console.WriteLine(x0);

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