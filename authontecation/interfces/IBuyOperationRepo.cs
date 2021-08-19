using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface IBuyOperationRepo
    {
        IQueryable<BuyOperationsVM> GetAll();
        BuyOperationsVM Add(BuyOperationsVM ob);
        BuyOperationsVM Delete(int id);
        BuyOperationsVM Edit(BuyOperationsVM ob);
        BuyOperationsVM GetById(int id);
    }
}
