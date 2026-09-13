using CircuitToolAnalyzer.Domain.Topology;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitToolAnalyzer.Domain.Analysis
{
    public class AnalysisResult
    {
        public Guid Id { get; }

        private readonly Dictionary<Guid, double> _nodeVoltages;

        public  IReadOnlyDictionary<Guid, double> NodeVoltages => _nodeVoltages.AsReadOnly();


        public AnalysisType Type { get; }


        public AnalysisResult(AnalysisType type, Dictionary<Guid, double> nodeVoltages)
        {
            Id = Guid.NewGuid();
            Type = type;
            if (nodeVoltages == null)
            {
                throw new ArgumentNullException(nameof(nodeVoltages), "Node voltages dictionary cannot be null.");
            }
            _nodeVoltages = nodeVoltages;
        }
    }
}
