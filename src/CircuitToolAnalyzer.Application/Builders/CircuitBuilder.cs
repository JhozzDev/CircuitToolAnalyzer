using CircuitToolAnalyzer.Application.DTOs;
using CircuitToolAnalyzer.Domain.Topology;
using CircuitToolAnalyzer.Domain.Components;

namespace CircuitToolAnalyzer.Application.Builders
{
    public class CircuitBuilder
    {
      
        public Circuit Build(CircuitRequestDto dto)
        {
            var nodesByName = new Dictionary<string, Node>();
            var circuit = new Circuit(dto.Name);

            foreach (var nodeDto in dto.Nodes)
            {
                var node = new Node(nodeDto.Name, nodeDto.IsGround);
                circuit.AddNode(node);            
                nodesByName[nodeDto.Name] = node;
            }

            foreach (var connectionDto in dto.Connections)
            {
                if(connectionDto.ComponentType is ComponentType.Resistor)
                {
                    var nodeA = nodesByName[connectionDto.NodeAName];
                    var nodeB = nodesByName[connectionDto.NodeBName];
                    var resistor = new Resistor(connectionDto.ComponentName, connectionDto.Value);
                    var connection = new Connection(resistor, nodeA, nodeB);
                    circuit.AddConnection(connection);
                }
                else if (connectionDto.ComponentType is ComponentType.VoltageSource)
                {
                    var nodeA = nodesByName[connectionDto.NodeAName];
                    var nodeB = nodesByName[connectionDto.NodeBName];
                    var voltageSource = new VoltageSource(connectionDto.ComponentName, connectionDto.Value);
                    var connection = new Connection(voltageSource, nodeA, nodeB);
                    circuit.AddConnection(connection);
                }
                else
                {
                    throw new ArgumentException($"Unsupported component type: {connectionDto.ComponentType}");
                }
            }

            return circuit;
        }

    }

  
}
