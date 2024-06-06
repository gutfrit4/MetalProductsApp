using MetalProducts.DAL.Interfaces;
using MetalProducts.Domain.Entity;
using MetalProducts.Domain.Response;
using MetalProducts.Domain.ViewModels.Order;
using MetalProducts.Serviсe.Interfaces;

namespace MetalProducts.Service.Implementations;

public class OrderService : IOrderService
{
    private readonly IBaseRepository<OrderEntity> _orderRepository;
    
    public Task<IBaseResponse<OrderEntity>> Create(CreateOrderViewModel model)
    {
        throw new NotImplementedException();
    }
}