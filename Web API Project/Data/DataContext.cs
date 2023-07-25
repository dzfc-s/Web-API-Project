global using Microsoft.EntityFrameworkCore;
using Web_API_Project.Models;

namespace Web_API_Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER16; Initial Catalog=WEBApiDB; Integrated Security=true; TrustServerCertificate=true");
        }

        public DbSet<User> Users { get; set; }
    }
}
