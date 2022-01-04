using FreakyFashionServices.StockService.Models.DTO;

namespace FreakyFashionServices.StockService.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetAllOrders(); 
        Task<OrderDTO> GetOrder(Guid id);
    }
}
