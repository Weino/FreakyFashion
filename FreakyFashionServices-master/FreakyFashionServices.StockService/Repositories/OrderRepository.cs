using FreakyFashionServices.StockService.Data;
using FreakyFashionServices.StockService.Models;
using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using FreakyFashionServices.StockService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FreakyFashionServices.StockService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StockServiceContext _ctx;

        public OrderRepository(StockServiceContext ctx)
        {
            _ctx = ctx;
        }

        public List<Order> GetAllOrders()
        {
            return  _ctx.Orders
           .ToList();
        }

        public Order? GetOrder(int id)
        {
            return  _ctx.Orders
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public Order? CreateOrder(CreateOrderDTO o)
        {
            var order = new Order();
            var basket = _ctx.Baskets.Where(x => x.Id == o.BasketId).FirstOrDefault();
            if (basket == null)
                return null;

            order.Customer = o.Customer;
            order.BasketId = basket.Id;
            order.JsonItems = basket.JsonItems;

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();

            return order;
        }
    }
}
