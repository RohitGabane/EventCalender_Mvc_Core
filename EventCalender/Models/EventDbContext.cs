using Microsoft.EntityFrameworkCore;

namespace EventCalender.Models
{
    public class EventDbContext :DbContext
    {
        public EventDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Api");
            }
        }
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        { 
        }
        public DbSet<Event> Event { get; set; }
    }
}
