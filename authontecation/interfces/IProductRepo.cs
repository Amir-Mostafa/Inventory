using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface IProductRepo
    {
        IQueryable<ProductsVM> GetAll();
        ProductsVM Add(ProductsVM ob);
        ProductsVM Delete(int id);
        ProductsVM Edit(ProductsVM ob);
        ProductsVM GetById(int id);
    }
}
