using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Models.Domain;

namespace MyApi.Data
{
    public class OrdersDbContext:DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> dbContextOptions):base(dbContextOptions){

        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for the products
            var products = new List<Product>
            {
                new Product
                {
                    ProductId =Guid.Parse("80f440ee-4cec-4c2f-adfa-0fe91e680e59"),
                    ProductName = "Wireless Earbuds",
                    Price = 29
                },
                new Product
                {
                    ProductId =Guid.Parse("569bec51-0f89-4467-a2b9-3137e01847cb"),
                    ProductName = "Bluetooth Speaker",
                    Price =49
                },
                new Product
                {
                    ProductId =Guid.Parse("a0978012-8349-43aa-ac8a-79fc5731551d"),
                    ProductName = "Laptop stand",
                    Price = 16
                },
                new Product
                {
                    ProductId =Guid.Parse("a6830687-d41d-486f-8e48-6ff52e757892"),
                    ProductName = "Gaming Stand",
                    Price = 20
                },
                new Product
                {
                    ProductId =Guid.Parse("81d9a2d1-b6e0-4813-8f1b-beff2fada320"),
                    ProductName = "Smart watch",
                    Price = 35
                }
            };

            modelBuilder.Entity<Product>().HasData(products);

            //Seed data for Customer

            var customers = new List<Customer>()
            {
                new Customer
                {
                    CustomerId =Guid.Parse("01d29b50-94bc-4b58-aca6-a644eff83b33"),
                    CustomerName = "John",
                    email = "xyz@gmail.com",
                    PhoneNumber = "111-222-333"
                },
                new Customer
                {
                    CustomerId =Guid.Parse("b12f061f-2c3c-4b73-bf0d-b902df7f2ba4"),
                    CustomerName = "Michael",
                    email = "abc@gmail.com",
                    PhoneNumber ="111-222-444"
                },
                new Customer
                {
                    CustomerId =Guid.Parse("d4503de4-e1b6-43bc-b5f9-aa4c7a24c814"),
                    CustomerName = "Willams",
                    email = "pqr@gmail.com",
                    PhoneNumber ="111-333-444"
                },
                new Customer
                {
                    CustomerId =Guid.Parse("15988176-70ba-4f21-bba8-250c402b54e7"),
                    CustomerName = "Smith",
                    email = "uvw@gmail.com",
                    PhoneNumber ="222-333-444"
                },
            };

            modelBuilder.Entity<Customer>().HasData(customers);


        }
    }
}

