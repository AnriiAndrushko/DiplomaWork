using MathNet.Numerics.LinearAlgebra;
using System.Text;

namespace GeneticAlgo.DTO
{
    public struct GAResult
    {
        public readonly Agent BestResult;
        public readonly double Fitness;

        public GAResult(Agent bestResult, double fitness)
        {
            BestResult = bestResult;
            Fitness = fitness;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Best Solution:\n" + BestResult);
            sb.AppendLine("Fitness: " + Fitness);
            return sb.ToString();
        }
    }
}
