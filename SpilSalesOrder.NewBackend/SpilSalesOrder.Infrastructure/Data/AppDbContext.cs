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

        public DbSet<OrderItem> SalesOrderItem { get; set; }

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
            
            modelBuilder.Entity<OrderItem>()
                .Property(i => i.ExclAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(i => i.TaxAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(i => i.InclAmount)
                .HasColumnType("decimal(18,2)");


        }


    }
}
