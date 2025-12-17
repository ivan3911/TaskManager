using Microsoft.EntityFrameworkCore;

namespace TaskManager
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Task> Tasks { get; set; }

    }
}
