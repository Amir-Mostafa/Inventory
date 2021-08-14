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
    public class SupplierRepo : ISupplierRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public SupplierRepo(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public IQueryable<SuppliersVM> GetAll()
        {
           // List<Suppliers> all = db.Suppliers.ToList();
            var data = db.Suppliers.Select(n => new SuppliersVM { Name = n.Name, BankName = n.BankName, BankNumber = n.BankNumber, Id = n.Id, Address = n.Address,Phone=n.Phone });
            return data;
        }

        public SuppliersVM Add(SuppliersVM ob)
        {
            Suppliers data = mapper.Map<Suppliers>(ob);

            db.Suppliers.Add(data);
            db.SaveChanges();
            return ob;
        }

        public SuppliersVM Delete(int id)
        {
            try
            {
                Suppliers d = db.Suppliers.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();
                SuppliersVM data = mapper.Map<SuppliersVM>(d);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public SuppliersVM Edit(SuppliersVM ob)
        {
            try
            {
                var data = mapper.Map<Suppliers>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public SuppliersVM GetById(int id)
        {
            SuppliersVM data = db.Suppliers.Where(n => n.Id == id).Select(n => new SuppliersVM { Id = n.Id, Name = n.Name, BankName = n.BankName, BankNumber = n.BankNumber,  Address = n.Address,Phone=n.Phone }).FirstOrDefault();
            return data;
        }

        public IQueryable<SuppliersVM> Search(string name)
        {
            var data = db.Suppliers.Where(n => n.Name.Contains(name)).Select(n => new SuppliersVM { Id = n.Id, Name = n.Name, BankName = n.BankName, BankNumber = n.BankNumber,  Address = n.Address, Phone = n.Phone });
            return data;
        }

    }
}
