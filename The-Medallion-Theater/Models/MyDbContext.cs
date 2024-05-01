using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace The_Medallion_Theater.Models
{
    public class MyDbContext : IdentityDbContext<Patron>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Patron> Patrons{ get; set; }
        public DbSet<Production> Productions{ get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
    

}
