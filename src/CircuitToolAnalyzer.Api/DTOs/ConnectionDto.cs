namespace CircuitToolAnalyzer.Api.DTOs
{
    public class ConnectionDto
    {

        public string ComponentName { get; set; }
        public ComponentType ComponentType { get; set; }
        public double Value { get; set; }
        public string NodeAName { get; set; }
        public string NodeBName { get; set; }

    }
}
