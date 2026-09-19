using System;
using Xunit;
using CircuitToolAnalyzer.Application.Solvers;
using CircuitToolAnalyzer.Domain.Topology;
using CircuitToolAnalyzer.Domain.Components;


namespace CircuitToolAnalyzer.UnitTests.Solvers
{
    public class AnalysisSolverTest
    {




        [Fact]
        public void Solve_Circuit()
        {
            // Arrange
            var circuit = new Circuit("Test Circuit");
            var node1 = new Node("Node 1", false);
            var node2 = new Node("Node GND", true); // Ground node
            
            circuit.AddNode(node1);
            circuit.AddNode(node2);
            
            var voltageSource = new VoltageSource("V1", 10.0);
            var resistor1 = new Resistor("R1", 5.0);

         
            // Act
            var connection1 = new Connection(voltageSource, node1, node2);
            var connection2 = new Connection(resistor1, node1, node2);

            circuit.AddConnection(connection1);
            circuit.AddConnection(connection2);

            var solver = new AnalysisSolver();
        

            // Act
            var result = solver.Solve(circuit);
            // Assert 
            Assert.Equal(10.0, result.NodeVoltages[node1.Id]);

        }

        [Fact]
        public void Solve_ShouldReturnCorrectVoltage()
        {
            // Arrange
            var solver = new AnalysisSolver();
            double voltage = 10.0;
            double r1ohms = 5.0;
            double r2ohms = 5.0;
            // Act
            double result = solver.Solve(voltage, r1ohms, r2ohms);
            // Assert
            Assert.Equal(5.0, result);
        }

        [Fact]
        public void Solve_ShouldThrowArgumentException_WhenSumOfResistancesIsZero()
        {
            // Arrange
            var solver = new AnalysisSolver();
            double voltage = 10.0;
            double r1ohms = 0.0;
            double r2ohms = 0.0;
            // Act & Assert
            Assert.Throws<ArgumentException>(() => solver.Solve(voltage, r1ohms, r2ohms));
        }
    }
}
