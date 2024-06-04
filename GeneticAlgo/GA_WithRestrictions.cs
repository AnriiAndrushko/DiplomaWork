using GeneticAlgo.DTO;
using MathNet.Numerics.LinearAlgebra;
using GeneticAlgo.Abstract;
using System.Collections.Concurrent;
using GeneticAlgo.Utils;

namespace GeneticAlgo
{
    public class GA_WithRestrictions : GeneticAlgoBase
    {
        private readonly int PopulationSize;
        private readonly int MaxGenerations;
        private readonly double SelectionAmount;
        private readonly double MutationRate;
        private readonly double MutationAmount;//TODO make it adjustable in run
        private readonly int LargeNumber; // M
        private readonly int StagnationLimit;
        private readonly int EliteCount;
        private readonly double ChangeRangePercent;
        private readonly AgentPool _agentPool;

        private Matrix<double> A;
        private Vector<double> B;
        private Vector<double> C;
        private double _bestFitness;
        private readonly VariableRange[] _xRanges;
        private int _stagnationCount;

        private CountdownEvent countdownEvent;

        public GA_WithRestrictions(Matrix<double> a, Vector<double> b, Vector<double> c, VariableRange[] xRanges, double variationPercent, GA_Params parameters)
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
            _agentPool = new AgentPool(PopulationSize, A, B, C, _xRanges, ChangeRangePercent, LargeNumber);
        }

        public override GAResult Run()
        {
            List<Agent> population = InitializePopulation();
            int generations = 0;
            for (int generation = 0; generation < MaxGenerations && _stagnationCount < StagnationLimit; generation++)
            {
                var nextPopulation = SelectPopulation(population);
                var elite = nextPopulation.Take(EliteCount);
                nextPopulation = new List<Agent>(nextPopulation.Skip(EliteCount));

                nextPopulation = Crossover(nextPopulation);
                Mutate(nextPopulation, _xRanges);

                nextPopulation.AddRange(elite);
                population = nextPopulation;

                var currentBest = population.Min(x => x.Fitness);
                var currentWorst = population.Max(x => x.Fitness);
                var currentAvg = population.Average(x => x.Fitness);
                currentGenerationData?.Invoke(currentAvg, currentWorst);
                if (currentBest < _bestFitness)
                {
                    _bestFitness = currentBest;
                    _stagnationCount = 0;
                }
                else
                {
                    _stagnationCount++;
                }
                generations++;
            }

            var bestAgent = population.OrderBy(x => x.Fitness).First();
            var fitness = bestAgent.Fitness;
            return new GAResult(bestAgent, fitness, generations);
        }

        private List<Agent> InitializePopulation()
        {
            var agents = new List<Agent>();
            for (int i =0; i<PopulationSize; i++)
            {
                agents.Add(_agentPool.GetAgent());
            }
            return agents;
        }

        private List<Agent> SelectPopulation(List<Agent> population)
        {
            int numberOfAgentsToSelect = (int)(PopulationSize * SelectionAmount);
            int lastIndex = numberOfAgentsToSelect - 1;
            var sorted = new SortedListWithDuplicates<Agent>();

            for (int i = population.Count-1; i >= 0; i--)
            {
                if (sorted.Count < numberOfAgentsToSelect)
                {
                    var toAdd = population.ElementAt(i);
                    sorted.Add(toAdd);
                }
                else if (population.ElementAt(i).Fitness < sorted.ElementAt(lastIndex).Fitness)
                {
                    _agentPool.ReturnAgent(sorted.ElementAt(lastIndex));
                    sorted.RemoveAt(lastIndex);
                    var toAdd = population.ElementAt(i);
                    sorted.Add(toAdd);
                }
                else
                {
                    _agentPool.ReturnAgent(population.ElementAt(i));
                }

            }
            return new List<Agent>(sorted.Values);
        }

        private List<Agent> Crossover(List<Agent> population)
        {
            var nextPopulation = new ConcurrentBag<Agent>(population);
            int requiredAdds = PopulationSize - EliteCount - population.Count;
            countdownEvent = new CountdownEvent(requiredAdds / 2); // Each task adds two agents

            for (int i = 0; i < requiredAdds / 2; i++)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    var parent1 = population.ElementAt(MultithreadRandom.Instance.Next(population.Count));
                    var parent2 = population.ElementAt(MultithreadRandom.Instance.Next(population.Count));
                    var result = Agent.Crossover(parent1, parent2, _agentPool);
                    nextPopulation.Add(result.Item1);
                    nextPopulation.Add(result.Item2);
                    countdownEvent.Signal();
                });
            }
            countdownEvent.Wait();

            return nextPopulation.ToList();
        }

        private void Mutate(List<Agent> population, VariableRange[] xRanges)
        {   
            int toProcess = population.Count;
            countdownEvent = new CountdownEvent(toProcess);

            Action<Agent> mutateAction = agent =>
            {
                agent.Mutate(MutationAmount, MutationRate, xRanges);
                countdownEvent.Signal();
            };

            foreach (var agent in population)
            {
                ThreadPool.QueueUserWorkItem(_ => mutateAction(agent));
            }
            countdownEvent.Wait();
        }
    }
}
