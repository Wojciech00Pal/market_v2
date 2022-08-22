﻿using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;

namespace Plugins.DataStore.SQL
{
    public class MarketContext:DbContext
    {
        public MarketContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            //seeding some data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage-t" },
                new Category { CategoryId = 2, Name = "Frozen", Description = "Cola" },
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat-t" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Iced tea", Quantity = 100, Price = 2.97 },
                new Product { ProductId = 2, CategoryId = 1, Name = "tea", Quantity = 60, Price = 5 },
                new Product { ProductId = 3, CategoryId = 1, Name = "Orange", Quantity = 1000, Price = 2.99 },
                new Product { ProductId = 4, CategoryId = 3, Name = "Chicken", Quantity = 100, Price = 2.9 }
                );
             
        }

    }
}
