using System;
using Xunit;
using CircuitToolAnalyzer.Application.Solvers;


namespace CircuitToolAnalyzer.UnitTests.Solvers
{
    public class AnalysisSolverTest
    {
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
