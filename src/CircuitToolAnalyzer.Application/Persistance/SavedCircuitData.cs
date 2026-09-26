using CircuitToolAnalyzer.Application.DTOs;
using CircuitToolAnalyzer.Domain.Analysis;
using CircuitToolAnalyzer.Domain.Topology;

namespace CircuitToolAnalyzer.Application.Persistance
{
    public class SavedCircuitData
    {
        public CircuitRequestDto Circuit { get; set; }
        public AnalysisResult Result { get; set; }
    }
}