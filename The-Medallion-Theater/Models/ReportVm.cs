namespace The_Medallion_Theater.Models
{
    public class ReportVm
    {
        public string? PerformanceName { get; set; }
        public string? ProductionName { get; set; }
        public DateTime PerformanceDate { get; set; }
        public string? PerformanceTime { get; set; }
        public int SeatsSold { get; set; }
        public string ReservedSeat { get; set; }
        public double TotalRevenue { get; set; }

    }
}
