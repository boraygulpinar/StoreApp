using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Concrete
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Products)
                .UsingEntity<ProductCategory>();

            modelBuilder.Entity<Category>()
                .HasIndex(u => u.Url)
                .IsUnique();

            modelBuilder.Entity<Product>().HasData(
                new List<Product>()
                {
                    new(){Id = 1,Name="Samsung S24",Price=5000,Description="Guzel telefon"},
                    new(){Id = 2,Name="Samsung S25",Price=6000,Description="Guzel telefon"},
                    new(){Id = 3,Name="Samsung S26",Price=7000,Description="Guzel telefon"},
                    new(){Id = 4,Name="Samsung S27",Price=8000,Description="Guzel telefon"},
                    new(){Id = 5,Name="Samsung S28",Price=9000,Description="Guzel telefon"},
                }
                );

            modelBuilder.Entity<Category>().HasData(
                new List<Category>()
                {
                    new(){Id=1,Name="Telefon",Url="telefon"},
                    new(){Id=2,Name="Elektronik",Url="elektronik"},
                    new(){Id=3,Name="Beyaz Eşya",Url="beyaz-esya"},
                }
                );

            modelBuilder.Entity<ProductCategory>().HasData(
                new List<ProductCategory>()
                {
                    new ProductCategory(){ProductId=1,CategoryId=1},
                    new ProductCategory(){ProductId=2,CategoryId=1},
                    new ProductCategory(){ProductId=3,CategoryId=1},
                    new ProductCategory(){ProductId=4,CategoryId=2},
                    new ProductCategory(){ProductId=5,CategoryId=2},
                }
                );
        }
    }
}
