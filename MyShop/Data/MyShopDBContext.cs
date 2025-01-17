using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System.Reflection.Emit;
namespace MyShop.Data
{
    public class MyShopDBContext : DbContext
    {
        public DbSet<Client> client { get; set; }
        public DbSet<Producer> producer { get; set; }
        public DbSet<Goods> goods { get; set; }
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
            modelBuilder.Entity<Goods>()
                .HasOne(g => g.Producer)
                .WithMany(p => p.goods)
                .HasForeignKey(g => g.ProdusersId);

            // Client-Orders
            modelBuilder.Entity<Order>()
                .HasOne(o => o.client)
                .WithMany(c => c.orders)
                .HasForeignKey(o => o.ClientId);

            // Goods-Orders
            modelBuilder.Entity<Goods>()
                .HasMany(g => g.Orders)
                .WithMany(o => o.goods);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
