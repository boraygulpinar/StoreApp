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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new List<Product>()
                {
                    new(){Id = 1,Name="Samsung S24",Price=5000,Description="Guzel telefon",Category="Telefon"},
                    new(){Id = 2,Name="Samsung S25",Price=6000,Description="Guzel telefon",Category="Telefon"},
                    new(){Id = 3,Name="Samsung S26",Price=7000,Description="Guzel telefon",Category="Telefon"},
                    new(){Id = 4,Name="Samsung S27",Price=8000,Description="Guzel telefon",Category="Telefon"},
                    new(){Id = 5,Name="Samsung S28",Price=9000,Description="Guzel telefon",Category="Telefon"},
                }
                );
        }
    }
}
