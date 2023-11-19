using Assignment_Databasteknik.Contexts;
using Assignment_Databasteknik.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Databasteknik.Repositories;

internal class ProductRepo : Repository<ProductEntity>
{
    private readonly DataContext _context;
    public ProductRepo(DataContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.Include(x => x.ProductType).ToListAsync();
    }
}
