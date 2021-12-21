using FreakyFashionServices.StockService.Models.DTO;

namespace FreakyFashionServices.StockService.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetOrder(); 
        Task<OrderDTO> GetOrder(int id);
    }
}
