namespace CircuitToolAnalyzer.Web.Models
{
    public class AnalysisResultResponse
    {
        public Guid Id { get; set; }
        public Dictionary<Guid, double> NodeVoltages { get; set; }
        public string Type { get; set; }
    }
}
