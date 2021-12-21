using FreakyFashionServices.StockService.Models;
using FreakyFashionServices.StockService.Repositories.Interfaces;

namespace FreakyFashionServices.StockService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FreakyFashionDbContext _ctx;

        public OrderRespository(FreakyFashionDbContext ctx)
    }
}
