using CircuitToolAnalyzer.Domain.Topology;
using CircuitToolAnalyzer.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CircuitToolAnalyzer.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        public DbSet<SavedCircuit> SavedCircuits { get; set; }
    }
}