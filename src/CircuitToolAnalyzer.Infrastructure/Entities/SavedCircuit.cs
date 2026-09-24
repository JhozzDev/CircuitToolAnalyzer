using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitToolAnalyzer.Infrastructure.Entities
{
    public class SavedCircuit
    {

        public Guid Id { get; set; }
        public String Name { get; set; }
        public String CircuitJson { get; set; }

        public String ResultJson { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
