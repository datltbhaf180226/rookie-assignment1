using Project1.Data;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repositoties
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MyDbContext context) : base(context)
        {

        }
    }
}
