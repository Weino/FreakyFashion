using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.StockService.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrders(); 
        public Order? GetOrder(int id);
        public Order? CreateOrder(CreateOrderDTO o);
    }
}
