using Assignment_Databasteknik.Contexts;
using Assignment_Databasteknik.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment_Databasteknik.Repositories;

internal class CustomerRepo : Repository<CustomerEntity>
{
    private readonly DataContext _context;

    public CustomerRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers
            .Include(x => x.Address)
            .Include(x => x.CustomerCategory)
            .ToListAsync();

    }
}
