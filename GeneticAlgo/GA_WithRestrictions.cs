using GeneticAlgo.DTO;
using MathNet.Numerics.LinearAlgebra;
using GeneticAlgo.Abstract;

namespace GeneticAlgo
{
    public class GA_WithRestrictions : GeneticAlgoBase
    {
        private readonly int PopulationSize;
        private readonly int MaxGenerations;
        private readonly double SelectionAmount;
        private readonly double MutationRate;
        private readonly double MutationAmount;
        private readonly double LargeNumber; // M
        private readonly int StagnationLimit;
        private readonly int EliteCount;
        private readonly double ChangeRangePercent;
        private static Random _random = new Random();

        private Matrix<double> A;
        private Vector<double> B;
        private Vector<double> C;
        private double _bestFitness;
        private readonly VariableRange[] _xRanges;
        private int _stagnationCount;

        public GA_WithRestrictions(Matrix<double> a, Vector<double> b, Vector<double> c, VariableRange[] xRanges, float variationPercent, GA_Params parameters)
        {
            PopulationSize = parameters.PopulationSize;
            MaxGenerations = parameters.MaxGenerations;
            SelectionAmount = parameters.SelectionAmount;
            MutationRate = parameters.MutationRate;
            MutationAmount = parameters.MutationAmount;
            LargeNumber = parameters.LargeNumber;
            StagnationLimit = parameters.StagnationLimit;
            EliteCount = parameters.EliteCount;
            ChangeRangePercent = variationPercent;


            A = a;
            B = b;
            C = c;
            _xRanges = xRanges;

            _bestFitness = double.PositiveInfinity;
            _stagnationCount = 0;
        }

        public override GAResult Run()
        {
            var population = InitializePopulation();
            for (int generation = 0; generation < MaxGenerations && _stagnationCount < StagnationLimit; generation++)
            {
                var nextPopulation = SelectPopulation(population);
                var elite = nextPopulation.Take(EliteCount);
                nextPopulation = nextPopulation.Skip(10).ToList();

                nextPopulation = Crossover(nextPopulation);
                Mutate(nextPopulation, _xRanges);

                nextPopulation.AddRange(elite);

                population = nextPopulation;

                var currentBest = population.Min(x => ComputeFitness(x));
                currentGenerationBest?.Invoke(currentBest);
                if (currentBest < _bestFitness)
                {
                    _bestFitness = currentBest;
                    _stagnationCount = 0;
                }
                else
                {
                    _stagnationCount++;
                }
            }

            var bestAgent = population.OrderBy(x => ComputeFitness(x)).First();
            var fitness = ComputeFitness(bestAgent);
            return new GAResult(bestAgent, fitness);
        }

        private List<Agent> InitializePopulation()
        {
            return Enumerable.Range(0, PopulationSize).Select(_ =>
            {
                var x = Vector<double>.Build.Dense(B.Count, i =>
                    _random.NextDouble() * (_xRanges[i].Max - _xRanges[i].Min) + _xRanges[i].Min);
                return new Agent(A, B, C, x, ChangeRangePercent);
            }).ToList();
        }


        private double ComputeFitness(Agent agent)
        {
            double penalty = 0;
            for (int i = 0; i < agent.A.RowCount; i++)
            {
                double constraint = 0;
                for (int j = 0; j < agent.A.ColumnCount; j++)
                {
                    constraint += agent.A[i, j] * agent.X[j];
                }
                penalty += LargeNumber * Math.Abs(constraint - agent.B[i]);
            }
            return -agent.C.DotProduct(agent.X) + penalty;
        }

        private List<Agent> SelectPopulation(List<Agent> population)
        {
            return population.OrderBy(x => ComputeFitness(x)).Take((int)(PopulationSize * SelectionAmount)).ToList();
        }

        private List<Agent> Crossover(List<Agent> population)
        {
            var nextPopulation = new List<Agent>(population);

            while (nextPopulation.Count < PopulationSize - EliteCount)
            {
                var parent1 = population[_random.Next(population.Count)];
                var parent2 = population[_random.Next(population.Count)];

                var result = Agent.Crossover(parent1, parent2);

                nextPopulation.Add(result.Item1);
                nextPopulation.Add(result.Item2);
            }
            return nextPopulation;
        }

        private void Mutate(List<Agent> population, VariableRange[] xRanges)
        {
            foreach (var agent in population)
            {
                agent.Mutate(MutationAmount, MutationRate, xRanges);
            }
        }
    }
}
