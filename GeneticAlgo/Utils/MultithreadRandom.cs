namespace GeneticAlgo.Utils
{
    internal class MultithreadRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random Instance
        {
            get
            {
                return Local ?? (Local = new Random(Guid.NewGuid().GetHashCode()));
            }
        }
    }
}
