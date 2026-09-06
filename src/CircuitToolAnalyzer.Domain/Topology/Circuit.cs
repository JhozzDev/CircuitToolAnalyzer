using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace CircuitToolAnalyzer.Domain.Topology
{
    public class Circuit
    {
        public Guid Id { get; }
        public string Name { get; }

        private readonly List<Node> _nodes;

        public IReadOnlyCollection<Node> Nodes => _nodes.AsReadOnly();

        public Circuit(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacío", nameof(name));
            }
            Id = Guid.NewGuid();
            Name = name;
            _nodes = new List<Node>();
        }
        public Node GetGroundNode()
        {

            var groundNode = _nodes.Find(n => n.IsGround == true);
            if (groundNode == null)
            {
                throw new InvalidOperationException("No se encontró un nodo con IsGround = true en el circuito.");

            }
            return groundNode;

        }
        public void AddNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            else if (_nodes.Exists(n => n.Id == node.Id))
            {
                throw new InvalidOperationException($"El nodo con Id {node.Id} ya existe en el circuito.");
            }
            else if (_nodes.Exists(n => node.IsGround == true && n.IsGround == true))
            {
                throw new InvalidOperationException($"Ya existe un nodo con IsGround {node.IsGround} en el circuito.");
            }

            _nodes.Add(node);
        }
       
    }
}
