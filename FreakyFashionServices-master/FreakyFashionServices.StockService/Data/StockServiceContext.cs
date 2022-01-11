using FreakyFashionServices.StockService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.StockService.Data
{
    public class StockServiceContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<StockLevel> StockLevel { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        public StockServiceContext(DbContextOptions<StockServiceContext> options)
            : base(options)
        {

        }
    }
}
