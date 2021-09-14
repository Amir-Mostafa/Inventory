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
<<<<<<< HEAD
        List<ShokakOperationVM> CityReportByCityId(int id);
=======

        List<ShokakOperationVM> clientOperations(int id);

>>>>>>> 992ac6d359ae71ec4a5b0eeffeebfb22340a1803
    }
}
