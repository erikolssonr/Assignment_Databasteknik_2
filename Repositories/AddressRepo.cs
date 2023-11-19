using Assignment_Databasteknik.Contexts;
using Assignment_Databasteknik.Entities;

namespace Assignment_Databasteknik.Repositories;

internal class AddressRepo : Repository<AddressEntity>
{
    public AddressRepo(DataContext context) : base(context)
    {
    }
}
