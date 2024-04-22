using MathNet.Numerics.LinearAlgebra;
using System.Text;

namespace GeneticAlgo.DTO
{
    public struct GAResult
    {
        public readonly Vector<double> BestResult;
        public readonly double Fitness;

        public GAResult(Vector<double> bestResult, double fitness)
        {
            BestResult = bestResult;
            Fitness = fitness;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Best Solution: " + BestResult);
            sb.AppendLine("Fitness: " + Fitness);
            return sb.ToString();
        }
    }
}
