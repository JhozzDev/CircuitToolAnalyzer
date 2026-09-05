using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitToolAnalyzer.Domain.Components
{
    public class VoltageSource : Component
    {
        public double VoltageVolts { get; }
        public VoltageSource(String name, double voltageVolts) : base(name)
        {
            if (double.IsNaN(voltageVolts) || double.IsInfinity(voltageVolts))
            {
                throw new ArgumentException("Voltage must be a valid number.");
            }
            VoltageVolts = voltageVolts;
        }
    }
}
