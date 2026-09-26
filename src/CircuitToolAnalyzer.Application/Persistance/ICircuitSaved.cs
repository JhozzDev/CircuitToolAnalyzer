using CircuitToolAnalyzer.Application.DTOs;
using CircuitToolAnalyzer.Domain.Analysis;
using CircuitToolAnalyzer.Domain.Topology;
using System.Collections.Generic;

namespace CircuitToolAnalyzer.Application.Persistance
{
    public interface ICircuitSaved
    {

        Guid Save(CircuitRequestDto dto, AnalysisResult result);
        List<SavedCircuitSummary> GetAll();  
        SavedCircuitData? GetById(Guid id); 
    } }