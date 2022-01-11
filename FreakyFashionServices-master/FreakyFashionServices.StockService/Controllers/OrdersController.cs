using FreakyFashionServices.StockService.Data;
using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using FreakyFashionServices.StockService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FreakyFashionServices.StockService.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private StockServiceContext _ctx { get; }
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrdersController(StockServiceContext context, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _ctx = context;
            _orderRepository = orderRepository;
            _productRepository = productRepository; 
        }

        [HttpPost]
        public ActionResult<OrderDTO> CreateOrder([FromBody] CreateOrderDTO o)
        {
            var order = _orderRepository.CreateOrder(o);
            if (order == null)
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Basket Not Found" });

            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                Customer = order.Customer,
                Products = ExtractLineItems(order)
            };

            return Ok(orderDTO);
        }

        [HttpGet]
        [Route("order/{orderId}")]
        public ActionResult<OrderDTO> GetOrder(int orderId)
        {
            var order = _orderRepository.GetOrder(orderId);
            if (order == null)
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Order Not Found" });

            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                Customer = order.Customer,
                Products = ExtractLineItems(order)
            };

            return Ok(orderDTO);
        }

        [HttpGet]
        public ActionResult<List<OrderDTO>> GetAllOrders()
        {
            var orders= _orderRepository.GetAllOrders(); 
            var orderDTOs = new List<OrderDTO>();
            foreach (var order in orders)
            {
                orderDTOs.Add(new OrderDTO
                {
                    Id = order.Id,
                    Customer = order.Customer,
                    Products = ExtractLineItems(order)
                });
            }

            return Ok(orderDTOs);
        }

        private List<LineItemDTO> ExtractLineItems(Order order)
        {
            if (order.JsonItems == null || order.JsonItems == string.Empty)
                return new List<LineItemDTO>(); 

            var orderItems = JsonSerializer.Deserialize<List<LineItem>>(order.JsonItems);
            if (orderItems == null)
                orderItems = new List<LineItem>();

            var returnItems = new List<LineItemDTO>();
            foreach (var item in orderItems)
            {
                var returnItem = new LineItemDTO();
                var product = _productRepository.GetProduct(item.ProductId);
                if (product != null)
                {
                    returnItem.ProductArticleNumber = product.ArticleNumber;
                    returnItem.Product = product;
                }
                returnItem.Quantity = item.Quantity;
                returnItems.Add(returnItem);
            }

            return returnItems;
        }
    }
}
