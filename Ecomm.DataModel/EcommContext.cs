using Ecomm.DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecomm.DataModel
{
    public class EcommContext : DbContext
    {
        public EcommContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<ClientInfo> ClientInfos { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductAttributeLookup> ProductAttributeLookups { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasData(
                new ProductCategory { ProductCategoryId = 1, CategoryName = "Car" },
                new ProductCategory { ProductCategoryId = 2, CategoryName = "Mobile" }
                );

            modelBuilder.Entity<ProductAttributeLookup>()
                .HasData(
                new ProductAttributeLookup { AttributeId = 1, ProductCategoryId = 1, AttributeName = "Color" },
                new ProductAttributeLookup { AttributeId = 2, ProductCategoryId = 1, AttributeName = "Make" },
                new ProductAttributeLookup { AttributeId = 3, ProductCategoryId = 1, AttributeName = "Model" },
                new ProductAttributeLookup { AttributeId = 4, ProductCategoryId = 2, AttributeName = "RAM" },
                new ProductAttributeLookup { AttributeId = 5, ProductCategoryId = 2, AttributeName = "Front Camera" },
                new ProductAttributeLookup { AttributeId = 6, ProductCategoryId = 2, AttributeName = "Rear Camera" }
                );
        }
    }
}
