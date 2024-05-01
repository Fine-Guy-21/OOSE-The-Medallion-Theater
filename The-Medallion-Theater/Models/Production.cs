namespace The_Medallion_Theater.Models
{
    public class Production
    {
        public string? ProductionId { get; set; }
        public string? ProductionName { get; set; }
        public string? ProductionType { get; set; }
    }

    public enum ProductionType
    {
       play,
       concert
    }

}
