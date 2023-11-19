using Assignment_Databasteknik.Contexts;
using Assignment_Databasteknik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Databasteknik.Repositories
{
    internal class ProductTypeRepo : Repository<ProductTypeEntity>
    {
        public ProductTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
