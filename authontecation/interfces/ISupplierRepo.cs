using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface ISupplierRepo
    {
        IQueryable<SuppliersVM> GetAll();
        SuppliersVM Add(SuppliersVM ob);
        SuppliersVM Delete(int id);
        SuppliersVM Edit(SuppliersVM ob);
        SuppliersVM GetById(int id);
        IQueryable<SuppliersVM> Search(string name);
    }
}
