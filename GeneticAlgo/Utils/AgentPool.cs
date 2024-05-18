using System.Collections.Concurrent;
using MathNet.Numerics.LinearAlgebra;
using GeneticAlgo.DTO;

namespace GeneticAlgo.Utils
{
    public class AgentPool
    {
        public readonly ConcurrentBag<Agent> _agents;
        private readonly Matrix<double> _initialA;
        private readonly Vector<double> _initialB;
        private readonly Vector<double> _initialC;
        private readonly int LargeNumber;
        private readonly VariableRange[] _xRanges;
        private readonly double _changeRangePercent;

        public int taken = 0;
        public int created = 0;
        public int returned = 0;

        public AgentPool(int initialSize, Matrix<double> a, Vector<double> b, Vector<double> c, VariableRange[] xRanges, double changeRangePercent, int largeNumber)
        {
            _agents = new ConcurrentBag<Agent>();
            _initialA = a;
            _initialB = b;
            _initialC = c;
            _xRanges = xRanges;
            _changeRangePercent = changeRangePercent;
            LargeNumber = largeNumber;

            for (int i = 0; i < initialSize; i++)
            {
                _agents.Add(CreateNewAgent());
            }
        }

        public Agent GetAgent()
        {
            if (_agents.TryTake(out var agent))
            {
                taken++;
                return agent;
            }

            return CreateNewAgent();
        }

        public void ReturnAgent(Agent agent)
        {
            returned++;
            _agents.Add(agent);
        }

        private Agent CreateNewAgent()
        {
            created++;
            var x = Vector<double>.Build.Dense(_initialB.Count, i =>
                MultithreadRandom.Instance.NextDouble() * (_xRanges[i].Max - _xRanges[i].Min) + _xRanges[i].Min);
            return new Agent(_initialA, _initialB, _initialC, x, _changeRangePercent, LargeNumber);
        }
    }
}
