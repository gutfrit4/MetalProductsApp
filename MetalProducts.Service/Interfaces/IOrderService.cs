using MetalProducts.Domain.Entity;
using MetalProducts.Domain.Response;
using MetalProducts.Domain.ViewModels.Order;

namespace MetalProducts.Serviсe.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<OrderEntity>> Create(CreateOrderViewModel model);
}