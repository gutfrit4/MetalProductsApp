using MetalProducts.Domain.Entity;
using Microsoft.EntityFrameworkCore;




namespace MetalProducts.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            //Database.EnsureDeleted(); //delete
            Database.EnsureCreated();
        }

        public DbSet<OrderEntity> Order { get; set; }
    }

}

