using Microsoft.EntityFrameworkCore;

namespace Mission6_0108_ReedStewart.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base (options) //Constructor
        {
        }

        public DbSet<Application> Applications { get; set; }
    }
}
