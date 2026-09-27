using System.Collections.Generic;
namespace CircuitToolAnalyzer.Application.DTOs
{

        public class CircuitRequestDto
        {
            public string Name { get; set; } = "Circuit Test";

            public List<NodeDto> Nodes { get; set; } = new List<NodeDto>
    {
        new NodeDto { Name = "V0", IsGround = false },
        new NodeDto { Name = "V1", IsGround = false },
        new NodeDto { Name = "GND", IsGround = true }
    };

            public List<ConnectionDto> Connections { get; set; } = new List<ConnectionDto>
    {
        new ConnectionDto { ComponentName = "Fuente1", ComponentType = ComponentType.VoltageSource, Value = 20, NodeAName = "V0", NodeBName = "GND" },
        new ConnectionDto { ComponentName = "R0", ComponentType = ComponentType.Resistor, Value = 50, NodeAName = "V0", NodeBName = "V1" },
        new ConnectionDto { ComponentName = "R1", ComponentType = ComponentType.Resistor, Value = 100, NodeAName = "V1", NodeBName = "GND" }
    };
        }

    
}
