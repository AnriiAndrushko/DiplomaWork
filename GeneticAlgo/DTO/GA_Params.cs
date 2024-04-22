namespace GeneticAlgo.DTO
{
    public struct GA_Params
    {
        public readonly int PopulationSize = 2000;
        public readonly int MaxGenerations = 1000;
        public readonly double SelectionAmount = 0.5;
        public readonly double MutationRate = 0.3;
        public readonly double MutationAmount = 5;
        public readonly double LargeNumber = 1000000; // M
        public readonly int StagnationLimit = 500;
        public GA_Params() { }
        public GA_Params(int populationSize, int maxGenerations, double selectionAmount, double mutationRate, double mutationAmount, double largeNumber, double variationKoef, int stagnationLimit)
        {
            if (CheckKoefBoundaries(selectionAmount))
                throw new ArgumentException("Selection Amount must be between 1 and 0");
            if (CheckKoefBoundaries(mutationRate))
                throw new ArgumentException("Mutation Rate must be between 1 and 0");
            if (CheckKoefBoundaries(variationKoef))
                throw new ArgumentException("Variation Koef must be between 1 and 0");

            PopulationSize = populationSize;
            MaxGenerations = maxGenerations;
            SelectionAmount = selectionAmount;
            MutationRate = mutationRate;
            MutationAmount = mutationAmount;
            LargeNumber = largeNumber;
            StagnationLimit = stagnationLimit;
        }
        private bool CheckKoefBoundaries(double value)
        {
            return value <= 1 && value >= 0;
        }
    }
}
