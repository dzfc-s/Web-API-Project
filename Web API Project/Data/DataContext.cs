global using Microsoft.EntityFrameworkCore;
using System;
using Web_API_Project.Models;

namespace Web_API_Project.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER16; Initial Catalog=WEBApiDB2; Integrated Security=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Assistant>().ToTable("Assistants");
            modelBuilder.Entity<Professor>().HasBaseType<Assistant>().ToTable("Professors");

        }
    }
}
