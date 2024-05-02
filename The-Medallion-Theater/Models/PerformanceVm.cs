namespace The_Medallion_Theater.Models
{
    public class PerformanceVm
    {
        public string? PerformanceID { get; set; }
        public string? PerformanceName { get; set; }
        public string? ProductionName { get; set; }
        public DateTime PerformanceDate { get; set; }
        public PerformanceTime PTime { get; set; }
        public List<Production> prods { get; set; }
        
    }
}
