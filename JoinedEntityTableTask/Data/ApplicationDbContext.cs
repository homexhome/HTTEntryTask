using JoinedEntityTableTask.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace JoinedEntityTableTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>()
                .HasIndex(p => new { p.CategoryName })
                .IsUnique(true);
            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.ProductName })
                .IsUnique(true);
        }
    }
}
