using System.ComponentModel.DataAnnotations;

namespace The_Medallion_Theater.Models
{
    public class Ticket
    {
        [Key]
        public string? TicketID { get; set; }
        public string? PatronID { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? PerformanceName {  get; set; }
        [Required]
        public string? Seats {  get; set; }
        [Required]
        public double TotalPrice { get; set; }

    }
}
