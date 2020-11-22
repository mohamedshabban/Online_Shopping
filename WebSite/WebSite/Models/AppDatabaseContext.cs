using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebSite.Models
{
    public class AppDatabaseContext:IdentityDbContext<IdentityUser>
        //DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext>options):base(options)
        {
            
        }
        public DbSet<Product>Products { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Clothes", Description = "Clothes" });
            modelBuilder.Entity<Category>().HasData(new Category
                {CategoryId = 2, CategoryName = "Food", Description = "Food"});
            modelBuilder.Entity<Category>().HasData(new Category
                {CategoryId = 3, CategoryName = "Electronics", Description = "Electronics"});
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Jacket",
                ShortDescription = "Jacket",
                LongDescription = "Jacket is the base of Winter",
                AllergyInformation = "",
                Price = 400M,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/61fTX5TjAEL._UL1001_.jpg",
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = true,
                InStock = true,
                CategoryId = 1,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Mango",
                ShortDescription = "Mango",
                LongDescription = "Mango is the base of Fruits",
                AllergyInformation = "",
                Price = 10M,
                ImageUrl = "https://www.supermarketperimeter.com/ext/resources/0722-mangoes.jpg?1595428736",
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = true,
                InStock = true,
                CategoryId = 2,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Freezer",
                ShortDescription = "Freezer",
                LongDescription = "Freezer is the base of Electronics",
                AllergyInformation = "",
                Price = 1500M,
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/619cPmKZsKL._AC_SL1500_.jpg",
                ImageThumbnailUrl = "",
                IsProductOfTheWeek = true,
                InStock = true,
                CategoryId = 3,
            });
        }
    }
}
