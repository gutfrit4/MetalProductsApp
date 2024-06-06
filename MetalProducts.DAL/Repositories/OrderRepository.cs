using MetalProducts.DAL.Interfaces;
using MetalProducts.Domain.Entity;

namespace MetalProducts.DAL.Repositories;

public class OrderRepository : IBaseRepository<OrderEntity>
{
    private readonly AppDbContext _appDbContext;

    public OrderRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Create(OrderEntity entity)
    {
        await _appDbContext.Order.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public IQueryable<OrderEntity> GetAll()
    {
        return _appDbContext.Order;
    }

    public async Task Delete(OrderEntity entity)
    {
        _appDbContext.Order.Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }
    
    public async Task<OrderEntity> Update(OrderEntity entity)
    {
        _appDbContext.Order.Update(entity);
        await _appDbContext.SaveChangesAsync();
        
        return entity;
    }
}