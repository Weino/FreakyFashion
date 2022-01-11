using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.StockService.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public List<ProductDTO> GetAllProducts();
        public ProductDTO? GetProduct(string articleNumber);
        public ProductDTO? GetProduct(Guid productId);
        public ProductDTO CreateProduct(ProductDTO p);
    }
}
