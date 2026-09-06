using System;
using System.Collections.Generic;
using CircuitToolAnalyzer.Domain.Components;
using System.Text;

namespace CircuitToolAnalyzer.Domain.Topology
{
    public class Connection
    {
        public Guid Id { get; }

        public Component Component { get; }
        public Node NodeA { get; }
        public Node NodeB { get;  }


        public Connection(Component component, Node nodeA, Node nodeB)
        {
            Id = Guid.NewGuid();
            if (component == null) { throw new ArgumentNullException(nameof(component)); }
            else if (nodeA == null) { throw new ArgumentNullException(nameof(nodeA)); }
            else if (nodeB == null) { throw new ArgumentNullException(nameof(nodeB)); }
            else if (nodeA == nodeB) { throw new ArgumentException("Los nodos no pueden ser iguales", nameof(nodeA)); }

            Component = component;
            NodeA = nodeA;
            NodeB = nodeB;

        }
    }
} 
