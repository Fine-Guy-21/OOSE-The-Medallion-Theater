using System.ComponentModel.DataAnnotations;

namespace The_Medallion_Theater.Models
{
    public class LoginVM
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Returnurl { get; set; }
    }
}
