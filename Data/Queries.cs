using Microsoft.EntityFrameworkCore;
using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Data
{
    public static class Queries
    {
        // Get products with their category and supplier information
        public static async Task<List<Product>> GetProductsWithDetails(ApplicationDbContext context)
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        // Get category hierarchy
        public static async Task<List<Category>> GetCategoryHierarchy(ApplicationDbContext context)
        {
            return await context.Categories
                .Include(c => c.SubCategories)
                .Where(c => c.ParentCategoryId == null)
                .ToListAsync();
        }

        // Get products by category
        public static async Task<List<Product>> GetProductsByCategory(ApplicationDbContext context, int categoryId)
        {
            return await context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        // Get recently created products
        public static async Task<List<Product>> GetRecentlyCreatedProducts(ApplicationDbContext context, int count = 10)
        {
            return await context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedDate)
                .Take(count)
                .ToListAsync();
        }

        // Get product history
        public static async Task<List<ProductHistory>> GetProductHistory(ApplicationDbContext context, int productId)
        {
            return await context.ProductHistory
                .Where(h => h.ProductId == productId)
                .OrderByDescending(h => h.ActionDate)
                .ToListAsync();
        }

        // Get products with low stock
        public static async Task<List<Product>> GetLowStockProducts(ApplicationDbContext context, int threshold = 10)
        {
            return await context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.StockQuantity <= threshold)
                .OrderBy(p => p.StockQuantity)
                .ToListAsync();
        }

        // Get products by price range
        public static async Task<List<Product>> GetProductsByPriceRange(ApplicationDbContext context, decimal minPrice, decimal maxPrice)
        {
            return await context.Products
                .Include(p => p.Category)
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .OrderBy(p => p.Price)
                .ToListAsync();
        }

        // Get supplier performance (number of products supplied)
        public static async Task<List<Supplier>> GetSupplierPerformance(ApplicationDbContext context)
        {
            return await context.Suppliers
                .Include(s => s.Products)
                .OrderByDescending(s => s.Products.Count)
                .ToListAsync();
        }

        // Get category statistics (number of products per category)
        public static async Task<List<Category>> GetCategoryStatistics(ApplicationDbContext context)
        {
            return await context.Categories
                .Include(c => c.Products)
                .OrderByDescending(c => c.Products.Count)
                .ToListAsync();
        }
    }
} 