using System.Collections.Generic;

namespace CircuitToolAnalyzer.Api.DTOs
{
    public class CircuitRequestDto
    {
        public string Name { get; set; }
        public List<ConnectionDto> Connections { get; set; }
        public List<NodeDto> Nodes { get; set; }

    }
}
