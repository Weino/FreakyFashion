namespace FreakyFashionServices.StockService.Models.Domain
{
    public class Order
    {
        public Guid Id {  get; set; }   
        public string Customer {  get; set; } = string.Empty;
        public List<LineItem> Items {  get; set; } = new();
        public string CustomerName { get; set; } = string.Empty;
        public Guid BasketId { get; internal set; }
    }
}
