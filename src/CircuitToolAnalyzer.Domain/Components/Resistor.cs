using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitToolAnalyzer.Domain.Components
{
    public class Resistor : Component
    {
        public double ResistanceOhms { get; }
        public Resistor(String name, double resistanceOhms) : base(name)
        {
            if (resistanceOhms < 0)
            {
                throw new ArgumentException("Resistance must be greater than zero.");
            }
            ResistanceOhms = resistanceOhms;
        }
    }
}
