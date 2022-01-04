namespace FreakyFashionServices.StockService.Models.Domain
{
    public class LineItem
    {
        public Guid Id { get; set; }
        public int ProductId {  get; set; }
        public int Quantity {  get; set; }
    }
}
