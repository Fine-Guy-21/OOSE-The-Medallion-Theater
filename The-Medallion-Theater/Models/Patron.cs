using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace The_Medallion_Theater.Models
{
    public class Patron : IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        [Required]
        public string? City { get; set; }
        
        public string? State { get; set; }
        public string? ZipCode { get; set; }

    }

}
