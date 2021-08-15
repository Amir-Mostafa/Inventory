using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.interfces
{
    public interface IClientRepo
    {
        IQueryable<ClientVM> GetAll();
        ClientVM Add(ClientVM ob);
        ClientVM Delete(int id);
        ClientVM Edit(ClientVM ob);
        ClientVM GetById(int id);
        IQueryable<ClientVM> Search(string name);
    }
}
