using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitToolAnalyzer.Application.Solvers
{
    public class AnalysisSolver
    {


        public double Solve(double voltage, double r1ohms, double r2ohms)
        {

        if(r1ohms + r2ohms == 0)
        {
            throw new ArgumentException("The sum of resistances cannot be zero.");
        }

            double voltage1 = voltage * (r2ohms/(r1ohms + r2ohms));
        return voltage1;

        }
    }
}
