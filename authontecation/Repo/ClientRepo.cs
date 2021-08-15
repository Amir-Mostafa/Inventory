using authontecation.Authontecation;
using AutoMapper;
using repo.Entity;
using repo.interfces;
using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Repo
{
    public class ClientRepo : IClientRepo
    {
        private ApplicationDbContext db;
        private readonly IMapper mapper;
        public ClientRepo(ApplicationDbContext db, IMapper _Mapper)
        {
            this.db = db;
            this.mapper = _Mapper;
        }
        public ClientVM Add(ClientVM ob)
        {
            Client data = mapper.Map<Client>(ob);

            db.Client.Add(data);
            db.SaveChanges();
            return ob;
        }

        public ClientVM Delete(int id)
        {
            try
            {
                Client d = db.Client.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();

                return mapper.Map<ClientVM>(d);
            }
            catch
            {
                return null;
            }

        }

        public ClientVM Edit(ClientVM ob)
        {
            try
            {
                var data = mapper.Map<Client>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ClientVM> GetAll()
        {
            List<Client> all = db.Client.ToList();
            var data = db.Client.Select(n => new ClientVM { CityId = n.CityId, CityName = n.City.Name, Name = n.Name, Id = n.Id, Notes = n.Notes });
            return data;
        }

        public ClientVM GetById(int id)
        {
            ClientVM data = db.Client.Where(n => n.Id == id).Select(n => new ClientVM { Id = n.Id, CityId = n.CityId, CityName = n.City.Name, Name = n.Name, Notes = n.Notes }).FirstOrDefault();
            return data;
        }

        public IQueryable<ClientVM> Search(string name)
        {
            var data = db.Client.Where(n => n.Name.Contains(name)).Select(n => new ClientVM { Id = n.Id, CityId = n.CityId, CityName = n.City.Name, Name = n.Name, Notes = n.Notes });
            return data;
        }
    }
}
