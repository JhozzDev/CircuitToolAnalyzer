# Circuit Tool Analyzer

A web application for building electrical circuits, connecting components through nodes, and automatically solving nodal analysis — calculating node voltages using Kirchhoff's Current Law (KCL).

A portfolio project, under active development, built to demonstrate skills in C#, ASP.NET Core, and clean architecture. It grew out of a Python circuit-analysis script, being progressively rewritten as an independent C#/.NET application.

## Current Status

🚧 Work in progress. The end-to-end flow already works: send a circuit over HTTP → build it in the domain → solve it → return the calculated voltages.

**Already implemented:**
- Full domain model: electrical components (`Resistor`, `VoltageSource`, `CurrentSource`), topology (`Node`, `Connection`, `Circuit`)
- Nodal analysis for circuits with **one unknown node** (nodes fixed by a voltage source are resolved separately)
- REST API with one endpoint (`POST /api/CircuitAnalysis`) that receives a circuit as JSON and returns each node's voltage
- Unit tests with xUnit for the solver

**Pending:**
- Nodal analysis generalized to N unknown nodes (linear system solved with matrices)
- Mesh analysis (KVL)
- Persistence with Entity Framework Core + SQL Server
- Frontend / visual Circuit Builder
- Integration tests

## Tech Stack

**In use:**
- C# / .NET
- ASP.NET Core Web API
- xUnit
- Git / GitHub

**Planned:**
- Entity Framework Core
- SQL Server
- Frontend (TBD)

## Architecture

Layered architecture, keeping the domain isolated from external frameworks:

```
src/
  CircuitToolAnalyzer.Domain          → electrical domain entities, no external dependencies
  CircuitToolAnalyzer.Application     → use cases, solver, DTOs, building circuits from DTOs
  CircuitToolAnalyzer.Infrastructure  → persistence (not yet implemented)
  CircuitToolAnalyzer.Api             → controllers, ASP.NET Core configuration

tests/
  CircuitToolAnalyzer.UnitTests
  CircuitToolAnalyzer.IntegrationTests
```

`Domain` does not depend on `Application`, `Infrastructure`, or `Api` — it can be tested in complete isolation.

## Usage Example

Request to `POST /api/CircuitAnalysis`, for a circuit with a 20V source and two 10Ω resistors in series:

```json
{
  "name": "Sample circuit",
  "nodes": [
    { "name": "V0", "isGround": false },
    { "name": "V1", "isGround": false },
    { "name": "GND", "isGround": true }
  ],
  "connections": [
    { "componentName": "Source1", "componentType": "VoltageSource", "value": 20, "nodeAName": "V0", "nodeBName": "GND" },
    { "componentName": "R1", "componentType": "Resistor", "value": 10, "nodeAName": "V0", "nodeBName": "V1" },
    { "componentName": "R2", "componentType": "Resistor", "value": 10, "nodeAName": "V1", "nodeBName": "GND" }
  ]
}
```

Response:
```json
{
  "type": "Nodal",
  "nodeVoltages": {
    "<GND-id>": 0,
    "<V0-id>": 20,
    "<V1-id>": 10
  }
}
```

## Running Locally

```bash
cd src/CircuitToolAnalyzer.Api
dotnet run
```

The API becomes available at `http://localhost:5031` (port may vary). Interactive documentation via Swagger at `http://localhost:5031/swagger`.

## Tests

```bash
dotnet test
```

## Author

Cristian Jhossander Hiciano — [github.com/JhozzDev](https://github.com/JhozzDev)
