using FreakyFashionServices.StockService.Data;
using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using FreakyFashionServices.StockService.Repositories;
using FreakyFashionServices.StockService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FreakyFashionServices.StockService.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private StockServiceContext _ctx { get; }
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        public BasketController(StockServiceContext context, IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _ctx = context;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }

        [HttpPost]
        public ActionResult <int> CreateBasket()
        {
            var basket = _basketRepository.CreateBasket();

            return Ok(basket.Id);
        }

        [HttpPut("{basketId}")]
        public  ActionResult<BasketDTO> AddProductToBasket(int basketId, [FromBody]LineItemDTO lineItem)
        {
            var basket = _basketRepository.AddProductToBasket(basketId, lineItem);
            if (basket != null)
            {
                List<LineItemDTO> returnItems = ExtractLineItems(basket);
                return new BasketDTO { BasketId = basket.Id, Products = returnItems };
            }
            else
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Basket Or Product Not Found" });
        }

        [HttpGet("{basketId}")] 
        public  ActionResult<BasketDTO> GetBasket(int basketId)
        {
            var basket = _basketRepository.GetBasket (basketId);

            if (basket != null)
            {
                List<LineItemDTO> returnItems = ExtractLineItems(basket);
                return new BasketDTO { BasketId = basket.Id, Products = returnItems };
            }
            else
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Basket Not Found" });
        }

        private List<LineItemDTO> ExtractLineItems(Basket basket)
        {
            var basketItems = JsonSerializer.Deserialize<List<LineItem>>(basket.JsonItems);
            if (basketItems == null)
                basketItems = new List<LineItem>();
            var returnItems = new List<LineItemDTO>();
            foreach (var item in basketItems)
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
