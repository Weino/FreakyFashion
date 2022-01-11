using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.StockService.Repositories.Interfaces
{
    public interface IBasketRepository
    {

        public Basket? AddProductToBasket(int basketId, [FromBody] LineItemDTO lineItem);
        public Basket? GetBasket(int basketId);
        public Basket CreateBasket();

    }
}
