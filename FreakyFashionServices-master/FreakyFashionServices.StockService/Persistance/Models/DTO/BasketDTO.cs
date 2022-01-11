using FreakyFashionServices.StockService.Models.Domain;

namespace FreakyFashionServices.StockService.Models.DTO
{
    public class BasketDTO
    {
        public int BasketId { get; set; }
        public List<LineItemDTO> Products { get; set; } = new();
        
    }
}
