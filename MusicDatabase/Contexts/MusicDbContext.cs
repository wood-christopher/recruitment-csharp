using Microsoft.EntityFrameworkCore;
using MusicDatabase.Models;

namespace MusicDatabase.Contexts
{
    public class ArtistContext : DbContext
    {
        public ArtistContext(DbContextOptions<ArtistContext> options) : base(options)
        {

        }
        public DbSet<Artist> Artists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artist>().HasKey("Id");

            string sqlFile = Path.Combine(Directory.GetCurrentDirectory(), "data.sql");
            string sql = File.ReadAllText(sqlFile);

            modelBuilder.HasSequence<long>("ArtistSequence").StartsAt(1);

            modelBuilder.Entity<Artist>().Property(a => a.Id).HasDefaultValueSql("NEXT VALUE FOR ArtistSequence");

            modelBuilder.Entity<Artist>().ToTable("Artist");

            modelBuilder.Entity<Artist>().Property(a => a.Id).HasColumnName("Id");

            modelBuilder.Entity<Artist>().HasIndex(a => a.name).IsUnique();
        }
    }
}
