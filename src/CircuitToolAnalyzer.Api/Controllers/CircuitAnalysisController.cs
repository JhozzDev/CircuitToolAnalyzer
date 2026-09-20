using CircuitToolAnalyzer.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using CircuitToolAnalyzer.Application.Builders;
using CircuitToolAnalyzer.Application.Solvers;

[ApiController]
[Route("api/[controller]")]
public class CircuitAnalysisController : ControllerBase
{
    private readonly CircuitBuilder _builder;
    private readonly AnalysisSolver _solver;

    public CircuitAnalysisController(CircuitBuilder builder, AnalysisSolver solver)
    {
        _builder = builder;
        _solver = solver;
    }

    [HttpPost]
    public IActionResult Analyze([FromBody] CircuitRequestDto dto)
    {
        var circuit = _builder.Build(dto);
        var result = _solver.Solve(circuit);

        return Ok(result);
    }
}