using System.Text;

namespace GeneticAlgo.DTO
{
    public struct GAResult
    {
        public readonly Agent BestResult;
        public readonly double Fitness;
        public readonly int TotalGenerations;

        public GAResult(Agent bestResult, double fitness, int totalGenerations)
        {
            BestResult = bestResult;
            Fitness = fitness;
            TotalGenerations = totalGenerations;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Best Solution:\n" + BestResult);
            sb.AppendLine("Fitness: " + Fitness);
            sb.AppendLine("Total generations: " + TotalGenerations);
            return sb.ToString();
        }
    }
}
