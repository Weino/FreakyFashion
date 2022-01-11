namespace FreakyFashionServices.StockService.Models.DTO
{
    public class OrderDTO
    {
        public int Id {  get; set; }  
        public string Customer{ get; set; } = string.Empty;
        public List<LineItemDTO> Products { get; set; }   = new List<LineItemDTO>();
    }
}
