using authontecation.Authontecation;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using repo.Entity;
using repo.interfces;
using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Repo
{
    
    public class CityRepo:ICityRepo
    {
        private ApplicationDbContext db;
        private readonly IMapper mapper;
        public CityRepo(ApplicationDbContext db, IMapper _Mapper)
        {
            this.db = db;
            this.mapper = _Mapper;
        }
        public CityVM Add(CityVM ob)
        {
            City data = mapper.Map<City>(ob);

            db.City.Add(data);
            db.SaveChanges();
            return ob;
        }

        public CityVM Delete(int id)
        {
            try
            {

               // City d = db.City.Where(n => n.Id == id).FirstOrDefault();
               // db.Remove(d);
               // db.SaveChanges();
               //CityVM data = mapper.Map<CityVM>(d);
               // return data;

                City d = db.City.Where(n => n.Id ==id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();

                return mapper.Map<CityVM>(d);

            }
            catch
            {
                return null;
            }
        }
        public CityVM Edit(CityVM ob)
        {
            try
            {
                var data = mapper.Map<City>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        
        public IQueryable<CityVM> GetAll()
        {
            List<City> all = db.City.ToList();
            var data = db.City.Select(n => new CityVM {Id=n.Id,Name=n.Name});
            return data;
        }

        public CityVM GetById(int id)
        {
            CityVM data = db.City.Where(n => n.Id == id).Select(n => new CityVM { Id=n.Id,Name=n.Name}).FirstOrDefault();
            return data;
        }

        public IQueryable<CityVM> Search(string name)
        {
            var data = db.City.Where(n => n.Name.Contains(name)).Select(n => new CityVM { Id = n.Id,Name= n.Name});
            return data;
        }

        public CityVM update(CityVM ob)
        {
            throw new NotImplementedException();
        }
    }
}

