using DatabaseRepPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseRepPattern.Repository
{
    public class DataBase : DbContext
    {
        private static bool _created = false;
        public DataBase(DbContextOptions<DataBase> options) : base(options) {
            //if (!_created)
            //{
            //    _created = true;
            //    Database.EnsureDeleted();
            //    Database.EnsureCreated();
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(sc => new { sc.itemId, sc.orderId });

            //modelBuilder.Entity<OrderItem>()
            //    .HasOne<Item>(sc => sc.Item)
            //    .WithMany(s => s.orderItems)
            //    .HasForeignKey(sc => sc.itemId);

            //modelBuilder.Entity<OrderItem>()
            //    .HasOne<Order>(sc => sc.Order)
            //    .WithMany(s => s.orderItems)
            //    .HasForeignKey(sc => sc.orderId);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
