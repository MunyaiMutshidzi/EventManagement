using Microsoft.EntityFrameworkCore;
using MunyaiM_Assign1.Models;

namespace MunyaiM_Assign1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Attendee>().ToTable("Attendee");
           
        }
    }
}
