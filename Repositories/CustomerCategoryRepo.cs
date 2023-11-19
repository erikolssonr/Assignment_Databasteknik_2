using Assignment_Databasteknik.Contexts;
using Assignment_Databasteknik.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Databasteknik.Repositories;

internal class CustomerCategoryRepo : Repository<CustomerCategoryEntity>
{
    public CustomerCategoryRepo(DataContext context) : base(context)
    {
    }

}
