using System.Reflection.Metadata;

namespace The_Medallion_Theater.Models
{
    public class Performance
    {
        public string? PerformanceID { get; set; }
        public string? PerformanceName { get; set; }
        public string? ProductionName {  get; set; }
        public DateTime PerformanceDate {  get; set; }
        public PerformanceTime PTime { get; set; }
        List<string>? ReservedSeats { get; set; }
    }



    public enum PerformanceTime
    {
        matinee,
        afternoon
    }
}
