using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitToolAnalyzer.Domain.Components
{
    public class CurrentSource : Component
    {
        public double CurrentAmps { get; }

        public CurrentSource(String name, double currentAmps) : base(name)
        {
            if (double.IsNaN(currentAmps) || double.IsInfinity(currentAmps))
            {
                throw new ArgumentException("Current must be a valid number.");
            }

            CurrentAmps = currentAmps;
        }
    }
}
