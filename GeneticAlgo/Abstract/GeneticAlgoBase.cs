using GeneticAlgo.DTO;

namespace GeneticAlgo.Abstract
{
    public abstract class GeneticAlgoBase
    {
        public Action<double, double> currentGenerationData;
        public abstract GAResult Run();
    }
}
