using Microsoft.AspNetCore.Mvc;
using MetalProducts.Domain.ViewModels.Order;

namespace MetalProductsApp.Controllers
{
    public class OrderController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            return Ok(); 
        }
       
    }
}
