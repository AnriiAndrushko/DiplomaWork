namespace GeneticAlgo.DTO
{
    public struct VariableRange
    {
        public readonly double Min;
        public readonly double Max;

        public VariableRange(double min, double max)
        {
            Min = min;
            Max = max;
        }
    }
}
