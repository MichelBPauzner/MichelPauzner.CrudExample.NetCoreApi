using Microsoft.EntityFrameworkCore;
using WebApi.Domain;

namespace WebApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) :
           base(options)
        { }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
        }
    }
}
