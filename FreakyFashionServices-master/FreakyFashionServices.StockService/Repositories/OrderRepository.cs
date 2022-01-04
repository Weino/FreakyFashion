using FreakyFashionServices.StockService.Data;
using FreakyFashionServices.StockService.Models;
using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using FreakyFashionServices.StockService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.StockService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StockServiceContext _ctx;

        public OrderRepository(StockServiceContext ctx)
        {
            _ctx = ctx;     
        }

        public async Task<List<OrderDTO>> GetAllOrders()
        {
                 return await _ctx.Orders
                .Select(x => new OrderDTO
                {
                    CustomerName = x.CustomerName,
                    Id = x.Id,
                    BasketId = x.BasketId,
                })
                .ToListAsync();
        }

        public async Task<OrderDTO> GetOrder(Guid id)
        {
                var order = await _ctx.Orders
                .Where(x => x.Id == id) 
                .Select(x => new OrderDTO
                {
                   CustomerName = x.CustomerName,
                   Id = x.Id,
                   BasketId = x.BasketId,
                })
                .FirstOrDefaultAsync();
            return order;
        }
    }
}
