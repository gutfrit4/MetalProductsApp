﻿using MetalProducts.Domain.Entity;
using Microsoft.EntityFrameworkCore;




namespace MetalProducts.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TaskEntity> Task { get; set; }
    }

}

