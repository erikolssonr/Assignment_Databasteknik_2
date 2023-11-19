using Assignment_Databasteknik.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Databasteknik.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductTypeEntity> ProductTypes { get; set; }
    public DbSet<CustomerCategoryEntity> CustomerCategories { get; set; }
    
}
