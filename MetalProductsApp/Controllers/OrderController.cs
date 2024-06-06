using MetalProducts.Domain.Filters.Order;
using MetalProducts.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using MetalProducts.Domain.ViewModels.Order;
using MetalProducts.Service.Interfaces;

namespace MetalProductsApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateCompletedOrder()
        {
            var response = await _orderService.CalculateCompletedOrder();
            if (response.StatusCode == MetalProducts.Domain.Enum.StatusCode.OK)
            {
                var csvService = new CsvBaseService<IEnumerable<OrderViewModel>>();
                var uploadFile = csvService.UploadFile(response.Data);
                return File(uploadFile, "text/csv", "Звіт.csv");
            }

            return BadRequest(new { description = response.Description });
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Table()
        {
            return View();
        }

        public async Task<IActionResult> GetCompletedOrder()
        {
            var result = await _orderService.GetCompletedOrder();
            return Json(new { data = result.Data });
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            var response = await _orderService.Create(model);
            if (response.StatusCode == MetalProducts.Domain.Enum.StatusCode.OK)
            {
                return Ok(new { description = response.Description });
            }
            
            return BadRequest(new { description = response.Description }); 
        }
        

        [HttpPost]
        public async Task<IActionResult> EndOrder(long id)
        {
            var response = await _orderService.EndOrder(id);
            if (response.StatusCode == MetalProducts.Domain.Enum.StatusCode.OK)
            {
                return Ok(new { description = response.Description });
            }
            
            return BadRequest(new { description = response.Description }); 
        }
        
        [HttpPost]
        public async Task<IActionResult> OrderHandler(OrderFilter filter)
        {
            var response = await _orderService.GetOrder(filter);
            return Json(new { data = response.Data});
        }
       
    }
}
