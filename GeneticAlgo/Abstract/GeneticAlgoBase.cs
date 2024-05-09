using GeneticAlgo.DTO;

namespace GeneticAlgo.Abstract
{
    public abstract class GeneticAlgoBase
    {
        public Action<double> currentGenerationBest;
        public abstract GAResult Run();
    }
}
