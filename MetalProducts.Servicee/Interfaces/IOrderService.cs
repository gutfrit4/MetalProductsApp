using MetalProducts.Domain.Entity;
using MetalProducts.Domain.Filters.Order;
using MetalProducts.Domain.Response;
using MetalProducts.Domain.ViewModels.Order;

namespace MetalProducts.Service.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<IEnumerable<OrderViewModel>>> CalculateCompletedOrder();
    
    Task<IBaseResponse<IEnumerable<OrderCompletedViewModel>>> GetCompletedOrder();
    
    Task<IBaseResponse<OrderEntity>> Create(CreateOrderViewModel model);

    Task<IBaseResponse<bool>> EndOrder(long id);
    
    Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetOrder(OrderFilter filter);
    
    
}