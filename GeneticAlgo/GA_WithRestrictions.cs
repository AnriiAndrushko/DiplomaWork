using GeneticAlgo.DTO;
using GeneticAlgo.Interfaces;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;

namespace GeneticAlgo
{
    public class GA_WithRestrictions : IGeneticAlgo
    {
        private readonly int PopulationSize;
        private readonly int MaxGenerations;
        private readonly double SelectionAmount;
        private readonly double MutationRate;
        private readonly double MutationAmount;
        private readonly double LargeNumber; // M
        private readonly int StagnationLimit;
        private static Random _random = new Random();
        private Matrix<double> A;
        private Vector<double> B;
        private Vector<double> C;
        private double _bestFitness;
        private readonly VariableRange[] _ranges;
        private int _stagnantGenerations;

        public GA_WithRestrictions(Matrix<double> a, Vector<double> b, Vector<double> c, VariableRange[] ranges, GA_Params parameters)
        {
            PopulationSize = parameters.PopulationSize;
            MaxGenerations = parameters.MaxGenerations;
            SelectionAmount = parameters.SelectionAmount;
            MutationRate = parameters.MutationRate;
            MutationAmount = parameters.MutationAmount;
            LargeNumber = parameters.LargeNumber;
            StagnationLimit = parameters.StagnationLimit;

            A = a;
            B = b;
            C = c;
            _ranges = ranges;

            _bestFitness = double.PositiveInfinity;
            _stagnantGenerations = 0;
        }

        public GAResult Run()
        {
            var population = InitializePopulation();
            for (int generation = 0; generation < MaxGenerations && _stagnantGenerations < StagnationLimit; generation++)
            {
                var nextPopulation = SelectPopullation(population);
                nextPopulation = Crossover(nextPopulation);
                nextPopulation = Mutate(nextPopulation);
                population = nextPopulation;


                var currentBest = population.Min(x => ComputeFitness(x));
                if (currentBest < _bestFitness)
                {
                    _bestFitness = currentBest;
                    _stagnantGenerations = 0;
                }
                else
                {
                    _stagnantGenerations++;
                }
            }

            var bestIndividual = population.OrderBy(x => ComputeFitness(x)).First();
            var fitness = ComputeFitness(bestIndividual);
            return new GAResult(bestIndividual, fitness);
        }

        private Vector<double>[] InitializePopulation()
        {
            return Enumerable.Range(0, PopulationSize).Select(_ =>
                Vector<double>.Build.Dense(B.Count, i =>
                _random.NextDouble() * (_ranges[i].Max - _ranges[i].Min) + _ranges[i].Min
                )).ToArray();
        }

        private double ComputeFitness(Vector<double> x)
        {
            double penalty = 0;
            for (int i = 0; i < A.RowCount; i++)
            {
                double constraint = 0;
                for (int j = 0; j < A.ColumnCount; j++)
                {
                    constraint += A[i, j] * x[j];
                }
                penalty += LargeNumber * Math.Abs(constraint - B[i]);
            }
            return -C.DotProduct(x) + penalty;
        }

        private Vector<double>[] SelectPopullation(Vector<double>[] population)
        {
            return population.OrderBy(x => ComputeFitness(x)).Take((int)(PopulationSize * SelectionAmount)).ToArray();
        }

        private Vector<double>[] Crossover(Vector<double>[] population)
        {
            var nextPopulation = new List<Vector<double>>();
            while (nextPopulation.Count < PopulationSize)
            {
                var parent1 = population[_random.Next(population.Length)];
                var parent2 = population[_random.Next(population.Length)];

                int crossoverPoint = _random.Next(1, parent1.Count - 1);
                var child1 = Vector<double>.Build.DenseOfEnumerable(parent1.Take(crossoverPoint).Concat(parent2.Skip(crossoverPoint)));
                var child2 = Vector<double>.Build.DenseOfEnumerable(parent2.Take(crossoverPoint).Concat(parent1.Skip(crossoverPoint)));
                nextPopulation.Add(child1);
                nextPopulation.Add(child2);
            }
            return nextPopulation.ToArray();
        }

        private Vector<double>[] Mutate(Vector<double>[] population)
        {
            foreach (var individual in population)
            {
                if (_random.NextDouble() < MutationRate)
                {
                    int index = _random.Next(individual.Count);
                    double mutation = Normal.Sample(_random, 0, MutationAmount);
                    double newValue = individual[index] + mutation;
                    individual[index] = Math.Max(_ranges[index].Min, Math.Min(_ranges[index].Max, newValue));
                }
            }
            return population;
        }
    }
}
