using CircuitToolAnalyzer.Domain.Components;    

namespace CircuitToolAnalyzer.Domain.Topology
{
   

    public class Node
    {
       public Guid Id { get; }
       public string Name { get; }

       public bool IsGround { get; }
        private readonly List<Component> _components;
        public IReadOnlyCollection<Component> Components => _components.AsReadOnly();

        public Node(string name, bool isGround)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacío", nameof(name));
            }

            Id = Guid.NewGuid();
            Name = name;
            IsGround = isGround;
            _components = new List<Component>();
        }
        
       public void AddComponent(Component component)
        {
            if(component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }
            _components.Add(component);
        }
    }
}
