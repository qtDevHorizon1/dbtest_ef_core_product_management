using Microsoft.EntityFrameworkCore;
using EFCore.Models;

namespace EFCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductHistory> ProductHistory { get; set; }
        public DbSet<ProductStats> ProductStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity table mappings
            modelBuilder.Entity<Product>()
                .ToTable("products", "productmanagement_dbo");

            modelBuilder.Entity<Category>()
                .ToTable("categories", "productmanagement_dbo");

            modelBuilder.Entity<Supplier>()
                .ToTable("suppliers", "productmanagement_dbo");

            modelBuilder.Entity<ProductHistory>()
                .ToTable("producthistory", "productmanagement_dbo");

            modelBuilder.Entity<ProductStats>()
                .ToTable("productstats", "productmanagement_dbo");

            // Configure Category self-referencing relationship
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Product relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure ProductHistory relationship
            modelBuilder.Entity<ProductHistory>()
                .HasOne(h => h.Product)
                .WithMany(p => p.History)
                .HasForeignKey(h => h.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProductStats is now a standalone table, no relationship configuration needed
        }
    }
} 