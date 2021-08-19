using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface IBuyOrderRepo
    {
        IQueryable<BuyOrderVM> GetAll();
        BuyOrderVM Add(BuyOrderVM ob);
        BuyOrderVM Delete(int id);
        BuyOrderVM Edit(BuyOrderVM ob);
        BuyOrderVM GetById(int id);
    }
}
