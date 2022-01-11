using FreakyFashionServices.StockService.Data;
using FreakyFashionServices.StockService.Models.Domain;
using FreakyFashionServices.StockService.Models.DTO;
using FreakyFashionServices.StockService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.StockService.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private StockServiceContext _ctx { get; }
        private readonly IProductRepository _productRepository;

        public ProductsController(StockServiceContext context, IProductRepository productRepository)
        {
            _ctx = context;
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpGet]
        [Route("product/{articleNumber}")]
        public ActionResult<ProductDTO> GetProduct(string articleNumber)
        {
            var product = _productRepository.GetProduct(articleNumber);
            if (product == null)
                return StatusCode(StatusCodes.Status404NotFound, new { message = $"Product With Article Number {articleNumber} Not Found" });
            else
                return product;

        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDTO p)
        {
            var product = _productRepository.CreateProduct(p);
            return Ok(product);
        }
    } 
}
