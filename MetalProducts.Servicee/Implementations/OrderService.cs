using System.Globalization;
using MetalProducts.DAL.Interfaces;
using MetalProducts.Domain.Entity;
using MetalProducts.Domain.Enum;
using MetalProducts.Domain.Extentions;
using MetalProducts.Domain.Filters.Order;
using MetalProducts.Domain.Response;
using MetalProducts.Domain.ViewModels.Order;
using MetalProducts.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MetalProducts.Service.Implementations;

public class OrderService : IOrderService
{
    private readonly IBaseRepository<OrderEntity> _orderRepository;
    private ILogger<OrderService> _logger;

    public OrderService(IBaseRepository<OrderEntity> orderRepository, ILogger<OrderService> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }


    public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> CalculateCompletedOrder()
    {
        try
        {
            var order = await _orderRepository.GetAll()
                .Select(x => new OrderViewModel()
                {
                    Id = x.Id,
                    orderName = x.orderName,
                    companyName = x.companyName,
                    Email = x.Email,
                    phoneNumber = x.phoneNumber,
                    Priority = x.Priority.ToString(),
                    Price = x.Price,
                    Description = x.Description,
                    Created = x.Created.ToString(CultureInfo.InvariantCulture),
                    isDone = x.isDone == true ? "Done" : "Not Done"
                })
                .ToListAsync();
            return new BaseResponse<IEnumerable<OrderViewModel>>()
            {
                Data = order,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[OrderService.CalculateCompletedOrder]: {ex.Message}");
            return new BaseResponse<IEnumerable<OrderViewModel>>()
            {
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<OrderCompletedViewModel>>> GetCompletedOrder()
    {
        try
        {
            var order = await _orderRepository.GetAll()
                .Where(x => x.isDone)
                // .Where(x => x.Created.Date == DateTime.Today)
                .Select(x => new OrderCompletedViewModel()
                {
                    Id = x.Id,
                    orderName = x.orderName,
                    Description = x.Description
                })
                .ToListAsync();
            return new BaseResponse<IEnumerable<OrderCompletedViewModel>>()
            {
                Data = order,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[OrderService.GetCompletedOrder]: {ex.Message}");
            return new BaseResponse<IEnumerable<OrderCompletedViewModel>>()
            {
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<OrderEntity>> Create(CreateOrderViewModel model)
    {
        try
        {
            model.Validate(); 
            
            _logger.LogInformation($"Запит на створеня замовлення - {model.orderName}");

            var order = await _orderRepository.GetAll()
                .Where(x => x.Created.Date == DateTime.Today)
                .FirstOrDefaultAsync(x => x.orderName == model.orderName);
            if (order != null)
            {
                return new BaseResponse<OrderEntity>()
                {
                    Description = "Замовлення з такою назвою вже є",
                    StatusCode = StatusCode.TaskIsHasAlready
                };
            }

            order = new OrderEntity()
            {
                orderName = model.orderName,
                companyName = model.companyName,
                Email = model.Email,
                phoneNumber = model.phoneNumber,
                Price = model.Price,
                Description = model.Description,
                isDone = false,
                Priority = model.Priority,
                Created = DateTime.Now
            };

            await _orderRepository.Create(order);

            _logger.LogInformation($"Замовлення створилось: {order.orderName} {order.Created}");
            return new BaseResponse<OrderEntity>()
            {
                Description = "Замовлення створилось",
                StatusCode = StatusCode.OK
            };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[OrderService.Create]: {ex.Message}");
            return new BaseResponse<OrderEntity>()
            {
                Description = $"{ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> EndOrder(long id)
    {
        try
        {
            var order = await _orderRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                return new BaseResponse<bool>()
                {
                    Description = "Замовлення не знайдено",
                    StatusCode = StatusCode.OrderNotFound
                };
            }

            order.isDone = true;
            await _orderRepository.Update(order);
            
            return new BaseResponse<bool>()
            {
                Description = "Замовлення виконано",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[OrderService.EndOrder]: {ex.Message}");
            return new BaseResponse<bool>()
            {
                Description = $"{ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetOrder(OrderFilter filter)
    {
        try
        {
            var order = await _orderRepository.GetAll()
                .Where(x=> x.isDone == false)
                .WhereIf(!string.IsNullOrWhiteSpace(filter.companyName), x=> x.companyName == filter.companyName)
                .WhereIf(filter.Priority.HasValue, x=> x.Priority == filter.Priority)
                .Select(x=>new OrderViewModel()
                {
                    Id = x.Id,
                    orderName = x.orderName,
                    companyName = x.companyName,
                    Email = x.Email,
                    phoneNumber = x.phoneNumber,
                    Priority = x.Priority.GetDisplayName(),
                    Price = x.Price,
                    Description = x.Description,
                    Created = x.Created.ToLongDateString(),
                    isDone = x.isDone == true ? "Виконано" : "Не виконано"
                })
                .ToListAsync();
            
            
            return new BaseResponse<IEnumerable<OrderViewModel>>()
            {
                Data = order,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[OrderService.Create]: {ex.Message}");
            return new BaseResponse<IEnumerable<OrderViewModel>>()
            {
                Description = $"{ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}