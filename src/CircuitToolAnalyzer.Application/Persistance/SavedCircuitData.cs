using CircuitToolAnalyzer.Domain.Analysis;
using CircuitToolAnalyzer.Domain.Topology;

namespace CircuitToolAnalyzer.Application.Persistance
{
    public class SavedCircuitData
    {
        public Circuit Circuit { get; set; }
        public AnalysisResult Result { get; set; }
    }
}