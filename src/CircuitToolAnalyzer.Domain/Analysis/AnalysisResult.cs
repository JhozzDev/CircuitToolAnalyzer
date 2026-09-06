using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitToolAnalyzer.Domain.Analysis
{
    public class AnalysisResult
    {
        public Guid Id { get; }
        public  AnalysisType Type { get;  }


        public AnalysisResult(AnalysisType type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }
    }
}
