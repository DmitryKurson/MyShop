using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System.Reflection.Emit;
namespace MyShop.Data
{
    public class MyShopDBContext : DbContext
    {
        public DbSet<Client> client { get; set; }
        public DbSet<Producer> producer { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Order> order { get; set; }

        public MyShopDBContext(DbContextOptions<MyShopDBContext> options)
          : base(options)
        {
        }

        public MyShopDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Producer-Goods
            modelBuilder.Entity<Product>()
                .HasOne(g => g.Producer)
                .WithMany(p => p.products)
                .HasForeignKey(g => g.ProducerId);

            // Client-Orders
            modelBuilder.Entity<Order>()
                .HasOne(o => o.client)
                .WithMany(c => c.orders)
                .HasForeignKey(o => o.ClientId);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(go => new { go.OrderId, go.ProductId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(go => go.Product)
                .WithMany(g => g.ProductOrders)
                .HasForeignKey(go => go.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(go => go.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(go => go.OrderId);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
