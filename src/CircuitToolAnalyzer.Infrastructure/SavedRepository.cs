using CircuitToolAnalyzer.Domain.Analysis;
using CircuitToolAnalyzer.Domain.Topology;
using CircuitToolAnalyzer.Infrastructure.Entities;
using System.Text.Json; 
using System.Linq;
using CircuitToolAnalyzer.Application.Persistance;

namespace CircuitToolAnalyzer.Infrastructure
{
    public class SavedRepository : ICircuitSaved
    {
        private readonly Context _context;
        public SavedRepository(Context context)
        {
            _context = context;
        }

        public Guid Save(Circuit circuit, AnalysisResult result)
        {

            var circuit2 = new SavedCircuit{
                Id = Guid.NewGuid(),
                Name = circuit.Name,
                CreatedAt = DateTime.Now,
                CircuitJson = JsonSerializer.Serialize(circuit),
                ResultJson = JsonSerializer.Serialize(result)
            };

            _context.SavedCircuits.Add(circuit2);
            _context.SaveChanges();
            return circuit2.Id;
        }

        public List<SavedCircuitSummary> GetAll()
        {
            return _context.SavedCircuits
                .Select(sc => new SavedCircuitSummary
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CreatedAt = sc.CreatedAt
                })
                .ToList();
        }

        public SavedCircuitData? GetById(Guid id)
        {
            var savedCircuit = _context.SavedCircuits.FirstOrDefault(sc => sc.Id == id);

            if (savedCircuit == null)
            {
                return null;
            }

            return new SavedCircuitData
            {
                Circuit = JsonSerializer.Deserialize<Circuit>(savedCircuit.CircuitJson),
                Result = JsonSerializer.Deserialize<AnalysisResult>(savedCircuit.ResultJson)
            };
        }
    }
}
