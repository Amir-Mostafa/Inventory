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
    public class BuyOperationRepo:IBuyOperationRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public BuyOperationRepo(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public BuyOperationsVM Add(BuyOperationsVM ob)
        {
            BuyOperations data = mapper.Map<BuyOperations>(ob);

            db.BuyOperations.Add(data);
            db.SaveChanges();
            return ob;
        }

        public BuyOperationsVM Delete(int id)
        {
            try
            {
                BuyOperations d = db.BuyOperations.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();
                BuyOperationsVM data = mapper.Map<BuyOperationsVM>(d);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public BuyOperationsVM Edit(BuyOperationsVM ob)
        {

            try
            {
                var data = mapper.Map<BuyOperations>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<BuyOperationsVM> GetAll()
        {
            var data = db.BuyOperations.Select(n => new BuyOperationsVM { Id = n.Id, Total = n.Total, ProductAmout = n.ProductAmout, Date = n.Date, ProductPrice = n.ProductPrice,Notes=n.Notes });
            return data;
        }

        public BuyOperationsVM GetById(int id)
        {
            BuyOperationsVM data = db.BuyOperations.Where(n => n.Id == id).Select(n => new BuyOperationsVM { Id = n.Id, Total = n.Total, ProductAmout = n.ProductAmout, Date = n.Date, ProductPrice = n.ProductPrice, Notes = n.Notes }).FirstOrDefault();
            return data;
        }
    }
}
