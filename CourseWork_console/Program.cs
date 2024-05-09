﻿using GeneticAlgo;
using GeneticAlgo.DTO;
using MathNet.Numerics.LinearAlgebra;
using GeneticAlgo.Abstract;

Random random = new Random();

// Крок 1: Генерація матриці A
var A = GenerateNonSingularMatrix(7, 7);

// Крок 2: Генерація розв'язку x0
var x0 = Vector<double>.Build.Dense(7, i => random.NextDouble() * 1000);

// Крок 3: Формування матриці B
var B = A * x0;

// Крок 4: Вектор C
var C = Vector<double>.Build.Dense(7, i => SumColumn(A, i));

//Matrix<double> A = Matrix<double>.Build.DenseOfArray(new double[,] { { 0.5, 0.3 }, 
//                                                                     { 0.2, 0.6 } });
//var x0 = Vector<double>.Build.DenseOfArray(new double[] { 10, 10 });
//var B = A * x0;
//var C = Vector<double>.Build.Dense(x0.Count, i => SumColumn(A, i));

VariableRange[] xRanges = new VariableRange[] {
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
    new VariableRange(-10000000, 10000000),
};

GA_Params gaParams = new GA_Params(
    20000,
    10000,
    0.35,
    0.2,
    1000,
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

GeneticAlgoBase ga = new GA_WithRestrictions(A, B, C, xRanges, 0.1f, gaParams);


Console.WriteLine("Press any key to begin");
Console.ReadKey();



ga.currentGenerationBest += (currentBest) => {
    Console.Clear();
    Console.WriteLine("Current generation best: " + currentBest);

};

var res = ga.Run();
Console.WriteLine(res);


Matrix<double> GenerateNonSingularMatrix(int rows, int cols)
{
    Matrix<double> matrix;
    do
    {
        matrix = Matrix<double>.Build.Dense(rows, cols, (i, j) => random.NextDouble() * 1000);
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