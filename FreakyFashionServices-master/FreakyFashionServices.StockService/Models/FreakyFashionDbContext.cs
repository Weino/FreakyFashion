using FreakyFashionServices.StockService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.StockService.Models
{
    public class FreakyFashionDbContext : DbContext
    {
        public FreakyFashionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders {  get; set; }   
    }
}
