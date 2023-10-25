using Microsoft.EntityFrameworkCore;
namespace webAPIMiniReddit.Model

{
    public class DataContext : DbContext
    {
        public DbSet<Traad> Traade { get; set; }
        public DbSet<Kommentar> Kommentare { get; set; }

        public string DbPath { get; set; }
        public DataContext()
        {
            DbPath = "bin/miniReddit.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"DataSource={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Traad>().ToTable("Traade");
            modelBuilder.Entity<Kommentar>().ToTable("Kommentare");
        }
    }
}
