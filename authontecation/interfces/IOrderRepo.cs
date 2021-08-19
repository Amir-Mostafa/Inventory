using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
   public interface IOrderRepo
    {
        IQueryable<OrdersVM> GetAll();
        OrdersVM Add(OrdersVM ob);
        OrdersVM Delete(int id);
        OrdersVM Edit(OrdersVM ob);
        OrdersVM GetById(int id);
    }
}
