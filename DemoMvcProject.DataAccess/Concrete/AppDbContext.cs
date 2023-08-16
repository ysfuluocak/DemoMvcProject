using DemoMvcProject.DataAccess.Configuration;
using DemoMvcProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DemoMvcProject.DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
        }
    }
}
