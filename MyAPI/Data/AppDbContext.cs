using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using System.Numerics;

namespace MyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }//Database.EnsureCreated(); } // НЕ ЗАБЫТЬ ЗАКОММЕНТИТЬ

        public AppDbContext()
        {
        }

        protected override void OnConfiguring
(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "db_API");
            //optionsBuilder.EnableSensitiveDataLogging;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Service>().OwnsOne(x => x.Timer);
            //modelBuilder.Entity<Service>().OwnsOne(x => x.StatusHistory);

            //modelBuilder
            //    .Entity<Service>(
            //        eb =>
            //        {
            //            //eb.HasNoKey();
            //            //eb.ToView("View_BlogPostCounts");
            //            //eb.Property(v => v.Timer).HasColumnName("Name");
            //            //eb.Property(v => v.Timer).HasColumnName("Timer");

            //        });
        }

        public DbSet<Service> Services { get; set; }
        //public DbSet<History> StatusHistory { get; set; }
    }
}
