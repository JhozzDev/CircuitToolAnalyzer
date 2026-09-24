using Microsoft.EntityFrameworkCore;
using CircuitToolAnalyzer.Infrastructure.Entities;

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