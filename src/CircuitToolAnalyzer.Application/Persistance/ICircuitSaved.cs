using CircuitToolAnalyzer.Domain.Analysis;
using CircuitToolAnalyzer.Domain.Topology;
using System.Collections.Generic;

namespace CircuitToolAnalyzer.Application.Persistance
{
    public interface ICircuitSaved
    {

        Guid Save(Circuit circuit, AnalysisResult result);
        List<SavedCircuitSummary> GetAll();  
        SavedCircuitData? GetById(Guid id); 
    } }