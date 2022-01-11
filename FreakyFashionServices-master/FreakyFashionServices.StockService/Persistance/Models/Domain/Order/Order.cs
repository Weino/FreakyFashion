namespace FreakyFashionServices.StockService.Models.Domain
{
    public class Order
    {
        public int Id {  get; set; }   
        public string Customer {  get; set; } = string.Empty;
        public string JsonItems { get; set; } = string.Empty;
        public int BasketId { get; internal set; }
    }
}
