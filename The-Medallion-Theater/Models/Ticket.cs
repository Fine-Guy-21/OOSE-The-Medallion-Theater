using System.ComponentModel.DataAnnotations;

namespace The_Medallion_Theater.Models
{
    public class Ticket
    {
        [Key]
        public string? TicketID { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? PerformanceName {  get; set; }
        [Required]
        public string? TotalPrice { get; set; }

    }
}
