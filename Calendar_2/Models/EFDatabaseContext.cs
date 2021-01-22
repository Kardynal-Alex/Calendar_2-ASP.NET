using Microsoft.EntityFrameworkCore;

namespace Calendar_2.Models
{
    public class EFDatabaseContext:DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> opt):base(opt)
        { }
        public DbSet<Event> Events { get; set; }
    }
}
