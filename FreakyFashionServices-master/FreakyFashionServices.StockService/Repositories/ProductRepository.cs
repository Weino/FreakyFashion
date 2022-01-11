using FreakyFashionServices.StockService.Data;
using FreakyFashionServices.StockService.Models;
using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using FreakyFashionServices.StockService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.StockService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StockServiceContext _ctx;

        public ProductRepository(StockServiceContext ctx)
        {
            _ctx = ctx;     
        }

        public ProductDTO CreateProduct(ProductDTO p)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                ArticleNumber = p.ArticleNumber,
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                UrlSlug = p.UrlSlug,
            };
            //Adderar en produkt i databasen
            _ctx.Products.Add(product);
             _ctx.SaveChangesAsync();

            return p;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products = _ctx.Products;

            var productDTOs = _ctx.Products.Select(x => new ProductDTO
            {
                Id = x.Id,
                ArticleNumber = x.ArticleNumber,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                UrlSlug = x.UrlSlug,
            });
            return productDTOs.ToList();
        }

        public ProductDTO? GetProduct(string articleNumber)
        {
                   return  _ctx.Products
            .Select(x => new ProductDTO
            {
                Id = x.Id,
                ArticleNumber = x.ArticleNumber,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                UrlSlug = x.UrlSlug,
            })
            .FirstOrDefault(x => x.ArticleNumber == articleNumber);
        }

        public ProductDTO? GetProduct(Guid productId)
        {
            return _ctx.Products
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    ArticleNumber = x.ArticleNumber,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    UrlSlug = x.UrlSlug,
                })
                .FirstOrDefault(x => x.Id == productId);
        }
    }
}
