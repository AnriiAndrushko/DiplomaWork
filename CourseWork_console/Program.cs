using GeneticAlgo;
using GeneticAlgo.DTO;
using GeneticAlgo.Interfaces;
using MathNet.Numerics.LinearAlgebra;

Random random = new Random();

//// Крок 1: Генерація матриці A
//var A = GenerateNonSingularMatrix(3, 3);

//// Крок 2: Генерація розв'язку x0
//var x0 = Vector<double>.Build.Dense(3, i => random.NextDouble() * 10 + 1);

//// Крок 3: Формування матриці B
//var B = A * x0;

//// Крок 4: Вектор C
//var C = Vector<double>.Build.Dense(3, i => SumColumn(A, i));

Matrix<double> A = Matrix<double>.Build.DenseOfArray(new double[,] { { 0.5, 0.3 }, 
                                                                     { 0.2, 0.6 } });
var x0 = Vector<double>.Build.DenseOfArray(new double[] { 10, 10 });
var B = A * x0;
var C = Vector<double>.Build.Dense(x0.Count, i => SumColumn(A, i));

VariableRange[] ranges = new VariableRange[] {
    new VariableRange(0, 15), // Для x0
    new VariableRange(0, 15)  // Для x1
};

Console.WriteLine("Matrix A:");
Console.WriteLine(A);
Console.WriteLine("Vector x0:");
Console.WriteLine(x0);
Console.WriteLine("Matrix B:");
Console.WriteLine(B);
Console.WriteLine("Vector C:");
Console.WriteLine(C);

IGeneticAlgo ga = new GA_WithRestrictions(A, B, C, ranges, new GA_Params());

Console.WriteLine(ga.Run());






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