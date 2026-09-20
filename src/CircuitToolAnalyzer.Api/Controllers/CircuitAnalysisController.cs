using CircuitToolAnalyzer.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CircuitAnalysisController : ControllerBase
{
    [HttpPost]
    public IActionResult Analyze([FromBody] CircuitRequestDto dto)
    {
        // por ahora, solo para probar que el JSON llega bien
        return Ok(dto);
    }
}