using FreakyFashionServices.StockService.Data;
using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using FreakyFashionServices.StockService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FreakyFashionServices.StockService.Repositories
{

    public class BasketRepository : IBasketRepository
    {
        private readonly StockServiceContext _ctx;

        public BasketRepository(StockServiceContext ctx)
        {
            _ctx = ctx;
        }

        public Basket CreateBasket()
        {
            var basket = new Basket();
            var basketItems = new List<LineItem>();
            basket.JsonItems = JsonSerializer.Serialize(basketItems);
            _ctx.Baskets.Add(basket);
            _ctx.SaveChanges();

            return basket;
        }

        public Basket? GetBasket(int basketId)
        {
            return  _ctx.Baskets
                .Where(x => x.Id == basketId)
                .FirstOrDefault();
        }

        public Basket? AddProductToBasket(int basketId, LineItemDTO lineItem)
        {
            var product = _ctx.Products.Where(x => x.ArticleNumber == lineItem.ProductArticleNumber).FirstOrDefault();
            if (product == null)
                return null;

            var basket = _ctx.Baskets.Where(x => x.Id == basketId)
             .FirstOrDefault();
            if (basket != null)
            {
                var basketItems = JsonSerializer.Deserialize<List<LineItem>>(basket.JsonItems);
                if (basketItems == null)
                    basketItems = new List<LineItem>();

                var addLineItem = new LineItem
                {
                    ProductId = product.Id,
                    Quantity = lineItem.Quantity,
                };

                basketItems.Add(addLineItem);
                basket.JsonItems = JsonSerializer.Serialize(basketItems);
                _ctx.SaveChangesAsync();
                return basket;
            }
            else
            {
                return null;
            }
        }
    }
}

