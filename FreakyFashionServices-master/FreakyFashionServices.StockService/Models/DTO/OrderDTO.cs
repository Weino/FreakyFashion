namespace FreakyFashionServices.StockService.Models.DTO
{
    public class OrderDTO
    {
        public Guid Id {  get; set; }  
        public Guid BasketId {  get; set; }
        public string CustomerName { get; set; } = string.Empty;

    }
}
