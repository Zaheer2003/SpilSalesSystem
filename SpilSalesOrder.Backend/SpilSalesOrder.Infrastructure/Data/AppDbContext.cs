using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpilSalesOrder.Domain.Entities;

namespace SpilSalesOrder.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<SalesOrder> SalesOrder { get; set; }

        public DbSet<SalesOrderItem> SalesOrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SalesOrder>()
                .HasMany(o => o.OrderItemsList)
                .WithOne(i => i.SalesOrder)
                .HasForeignKey(i => i.SalesOrderId)
                .OnDelete(DeleteBehavior.Cascade);

                        modelBuilder.Entity<Item>()

                            .Property(i => i.Price)

                            .HasColumnType("decimal(18,2)");

                        modelBuilder.Entity<Item>()

                            .Property(i => i.TaxRate)

                            .HasColumnType("decimal(18,2)");

            

                        modelBuilder.Entity<SalesOrderItem>()

                            .Property(i => i.UnitPrice)

                            .HasColumnType("decimal(18,2)");

                        modelBuilder.Entity<SalesOrderItem>()

                            .Property(i => i.TaxRate)

                            .HasColumnType("decimal(18,2)");

                        modelBuilder.Entity<SalesOrderItem>()

                            .Property(i => i.ExclAmount)

                            .HasColumnType("decimal(18,2)");

                        modelBuilder.Entity<SalesOrderItem>()

                            .Property(i => i.TaxAmount)

                            .HasColumnType("decimal(18,2)");

                        modelBuilder.Entity<SalesOrderItem>()

                            .Property(i => i.InclAmount)

                            .HasColumnType("decimal(18,2)");

            

                        modelBuilder.Entity<SalesOrder>()

                            .Property(o => o.TotalExel)

                            .HasColumnType("decimal(18,2)");

                        modelBuilder.Entity<SalesOrder>()

                            .Property(o => o.TotalTax)

                            .HasColumnType("decimal(18,2)");

                        modelBuilder.Entity<SalesOrder>()

                            .Property(o => o.TotalIncl)

                            .HasColumnType("decimal(18,2)");

            

            

                                                modelBuilder.Entity<Customer>().HasData(

            

            

                                                    new Customer { id = 1, CustomerName = "Ariya Perera", AddressLine1 = "10 Galle Road", AddressLine2 = "Colombo 03", City = "Colombo", PostalCode = "00300" },

            

            

                                                    new Customer { id = 2, CustomerName = "Saman Kumara", AddressLine1 = "25 Kandy Road", AddressLine2 = "Peradeniya", City = "Kandy", PostalCode = "20400" },

            

            

                                                    new Customer { id = 3, CustomerName = "Nimali Fernando", AddressLine1 = "5 Main Street", AddressLine2 = "Mount Lavinia", City = "Mount Lavinia", PostalCode = "10370" },

            

            

                                                    new Customer { id = 4, CustomerName = "Chamara Silva", AddressLine1 = "Borella Cross Road", AddressLine2 = "Borella", City = "Colombo", PostalCode = "00800" },

            

            

                                                    new Customer { id = 5, CustomerName = "Priya Rajapakse", AddressLine1 = "15 Station Road", AddressLine2 = "Dehiwala", City = "Dehiwala", PostalCode = "10350" }

            

            

                                                );

            

            

                                    

            

            

                                                modelBuilder.Entity<Item>().HasData(

            

            

                                                    new Item { Id = 1, ItemCode = 1001, Description = "Laptop", Price = 1200.00m, TaxRate = 0.15m },

            

            

                                                    new Item { Id = 2, ItemCode = 1002, Description = "Mouse", Price = 25.00m, TaxRate = 0.15m },

            

            

                                                    new Item { Id = 3, ItemCode = 1003, Description = "Keyboard", Price = 75.00m, TaxRate = 0.15m },

            

            

                                                    new Item { Id = 4, ItemCode = 1004, Description = "Monitor", Price = 300.00m, TaxRate = 0.15m },

            

            

                                                    new Item { Id = 5, ItemCode = 1005, Description = "Webcam", Price = 50.00m, TaxRate = 0.15m }

            

            

                                                );
        }


    }
}
