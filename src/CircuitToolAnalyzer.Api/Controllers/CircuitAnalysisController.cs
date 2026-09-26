using CircuitToolAnalyzer.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using CircuitToolAnalyzer.Application.Builders;
using CircuitToolAnalyzer.Application.Solvers;
using CircuitToolAnalyzer.Application.Persistance;

[ApiController]
[Route("api/[controller]")]
public class CircuitAnalysisController : ControllerBase
{
    private readonly CircuitBuilder _builder;
    private readonly AnalysisSolver _solver;

    private readonly ICircuitSaved _savedRepository;

    public CircuitAnalysisController(CircuitBuilder builder, AnalysisSolver solver, ICircuitSaved savedRepository)
    {
        _builder = builder;
        _solver = solver;
        _savedRepository = savedRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var summaries = _savedRepository.GetAll();
        return Ok(summaries);
    }


    [HttpPost]
    public IActionResult Analyze([FromBody] CircuitRequestDto dto)
    {
        var circuit = _builder.Build(dto);
        var result = _solver.Solve(circuit);
        var savedId = _savedRepository.Save(dto, result);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] Guid id)
    {
        var savedCircuit = _savedRepository.GetById(id);

        if (savedCircuit == null)
        {
            return NotFound();
        }

        return Ok(savedCircuit);
    }
}