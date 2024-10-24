using GameClubAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameClubAPI.DatabseContext
{
    public class GameClubDbContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Event> Events { get; set; }

        public GameClubDbContext(DbContextOptions<GameClubDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(c => c.Name).IsUnique();
            });
            
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }

}
