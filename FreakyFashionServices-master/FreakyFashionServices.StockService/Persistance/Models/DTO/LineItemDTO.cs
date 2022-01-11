namespace FreakyFashionServices.StockService.Models.DTO
{
    public class LineItemDTO
    {
        public string ProductArticleNumber { get; set; } = string.Empty;    
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; } = new ProductDTO();
    }
}
