using System;
using System.Collections.Generic;
using System.Linq;
using CircuitToolAnalyzer.Domain.Analysis;
using CircuitToolAnalyzer.Domain.Components;
using CircuitToolAnalyzer.Domain.Topology;

namespace CircuitToolAnalyzer.Application.Solvers
{
    public class AnalysisSolver
    {

        public Node nodeGND { get; set; }

        public Node nodoNoGND { get; set; }

        public Circuit circuit { get; set; }

        public double Solve(double voltage, double r1ohms, double r2ohms)
        {

        if(r1ohms + r2ohms == 0)
        {
            throw new ArgumentException("The sum of resistances cannot be zero.");
        }

            double voltage1 = voltage * (r2ohms/(r1ohms + r2ohms));
        return voltage1;

        }

        public AnalysisResult Solve(Circuit circuit)
        {
            var nodeGND = circuit.GetGroundNode();

         
            var voltages = new Dictionary<Guid, double>();
            voltages[nodeGND.Id] = 0.0;        
            
            foreach (var conexion in circuit.Connections)
            {
                if (conexion.Component is VoltageSource voltageSource)
                {
                    var nodoFuente = conexion.NodeA == nodeGND ? conexion.NodeB : conexion.NodeA;
                    voltages[nodoFuente.Id] = voltageSource.VoltageVolts;
                }
            }
            var nodoNoGND = circuit.Nodes.First(n => n != nodeGND && !voltages.ContainsKey(n.Id));

            var conexionesDelNodo = circuit.Connections.Where(c => c.NodeA == nodoNoGND || c.NodeB == nodoNoGND);


       
          

            double sumaConductancias = 0.0;
            double sumaCorrientesConocidas = 0.0;
            foreach (var conexion in conexionesDelNodo)
            {

                if (conexion.Component is Resistor resistor)
                {
                    var otroNodo = conexion.NodeA == nodoNoGND ? conexion.NodeB : conexion.NodeA;
                    double votro = voltages[otroNodo.Id];

                    sumaConductancias += 1.0 / resistor.ResistanceOhms;
                    sumaCorrientesConocidas += votro / resistor.ResistanceOhms;
                }
            }

            double v1 = sumaCorrientesConocidas / sumaConductancias;

            if (!voltages.ContainsKey(nodoNoGND.Id))
            {
                voltages[nodoNoGND.Id] = v1;
            }
           
            return new AnalysisResult(
                AnalysisType.Nodal,
                voltages
            );
        }
    }
}
