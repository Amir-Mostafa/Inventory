using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface IShokakOperationRepo
    {
        IQueryable<ShokakOperationVM> GetAll();
        ShokakOperationVM Add(ShokakOperationVM ob);
        ShokakOperationVM Delete(int id);
        ShokakOperationVM Edit(ShokakOperationVM ob);
        ShokakOperationVM GetById(int id);
    }
}
