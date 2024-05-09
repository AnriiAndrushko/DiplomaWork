namespace GeneticAlgo.DTO
{
    public struct GA_Params
    {
        public readonly int PopulationSize;
        public readonly int MaxGenerations;
        public readonly double SelectionAmount;
        public readonly double MutationRate;
        public readonly double MutationAmount;
        public readonly double LargeNumber; // M
        public readonly int StagnationLimit;
        public readonly int EliteCount;
        public GA_Params(int populationSize, int maxGenerations, double selectionAmount, double mutationRate, double mutationAmount, double largeNumber, int stagnationLimit, int eliteCount)
        {
            if (!CheckKoefBoundaries(selectionAmount))
                throw new ArgumentException("Selection Amount must be between 0 and 1");
            if (!CheckKoefBoundaries(mutationRate))
                throw new ArgumentException("Mutation Rate must be between 0 and 1");
            if ((populationSize * selectionAmount) - eliteCount <= 0)
                throw new ArgumentException("Too small population size for this parameters");

            PopulationSize = populationSize;
            MaxGenerations = maxGenerations;
            SelectionAmount = selectionAmount;
            MutationRate = mutationRate;
            MutationAmount = mutationAmount;
            LargeNumber = largeNumber;
            StagnationLimit = stagnationLimit;
            EliteCount = eliteCount;
        }
        private bool CheckKoefBoundaries(double value)
        {
            return value <= 1 && value >= 0;
        }
    }
}
