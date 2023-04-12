global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Hosting.Server;
using System.Diagnostics.Metrics;

namespace webapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=transitiondb;Trusted_Connection=true;TrustServerCertificate=true;");
            //"Data Source" can also instead of Server
            //Database or "Initial Catalog" shows name of database
            //Trusted_Connection toggles secure connection
            //TrustServerCertificate enables SSL for encryption
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Transition>()
                .Property(e => e.start_date)
                .HasColumnType("date");

            modelBuilder.Entity<Transition>()
                .Property(e => e.end_date)
                .HasColumnType("date");

            /*
            modelBuilder.Entity<Transition>()
                .HasMany(e => e.applications)
                .WithMany()
                .HasForeignKey();

            modelBuilder.Entity<Transition>();
            */ 
       }

        public DbSet<Transition> Transitions { get; set; }
    }
}
