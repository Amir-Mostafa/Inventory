using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface IOperationRepo
    {
        IQueryable<OperationsVM> GetAll();
        OperationsVM Add(OperationsVM ob);
        OperationsVM Delete(int id);
        OperationsVM Edit(OperationsVM ob);
        OperationsVM GetById(int id);
    }
}
