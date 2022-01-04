using FreakyFashionServices.StockService.Data;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.StockService.Controllers
{
    public class OrderController : ControllerBase
    {
        public OrderController(StockServiceContext context)
        {
            context = context;
        }


    }
}
