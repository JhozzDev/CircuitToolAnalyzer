using System;


namespace CircuitToolAnalyzer.Domain.Components
{
    public abstract class Component
    {
        public Guid Id { get;  }
        public String Name { get; }

        protected Component(String name)
        {
            
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            }

            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
