
using Microsoft.EntityFrameworkCore;
using Lab3_WorkshopRSVP.Models;

namespace Lab3_WorkshopRSVP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rsvp> Rsvps { get; set; }
    }
}
