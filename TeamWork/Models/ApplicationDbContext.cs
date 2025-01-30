using Microsoft.EntityFrameworkCore;

namespace TeamWork.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        //это то, как я буду обращаться к тбалице задач
        public DbSet<Task> Tasks { get; set; }
    }
}
