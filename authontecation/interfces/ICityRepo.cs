using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface ICityRepo
    {
        IQueryable<CityVM> GetAll();
        CityVM Add(CityVM ob);
        CityVM Delete(CityVM ob);
        CityVM Edit(CityVM ob);
        CityVM GetById(int id);
        IQueryable<CityVM> Search(string name);
    }
}
