namespace FreakyFashionServices.StockService.Models.Domain
{
    public class Basket
    {
        public Guid Id {  get; set; }
        public List<LineItem> Items { get; set; } = new();
    }
}
