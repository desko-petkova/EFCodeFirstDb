using EFCodeFirstDb.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(
           "Server=(localdb)\\MSSQLLocalDB;Database=CodeFirstDb;Integrated Security=True;");


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Sale> Sales { get; set; }
    }
}
