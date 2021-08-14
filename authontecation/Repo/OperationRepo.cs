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
    public class OperationRepo : IOperationRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public OperationRepo(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public OperationsVM Add(OperationsVM ob)
        {
            Operations data = mapper.Map<Operations>(ob);

            db.Operations.Add(data);
            db.SaveChanges();
            return ob;
        }

        public OperationsVM Delete(int id)
        {

            try
            {
                Operations d = db.Operations.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();
                OperationsVM data = mapper.Map<OperationsVM>(d);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public OperationsVM Edit(OperationsVM ob)
        {
            try
            {
                var data = mapper.Map<Operations>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<OperationsVM> GetAll()
        {
            var data = db.Operations.Select(n => new OperationsVM { Id = n.Id, productAmount = n.productAmount, productPrice = n.productPrice, date = n.date, Notes = n.Notes, Profit = n.Profit, Weight = n.Weight,Total=n.Total,OrderId=n.OrderId,ProductId=n.ProductId ,ClientId=n.ClientId});
            return data;
        }

        public OperationsVM GetById(int id)
        {
            OperationsVM data = db.Operations.Where(n => n.Id == id).Select(n => new OperationsVM { Id = n.Id, productAmount = n.productAmount, productPrice = n.productPrice, date = n.date, Notes = n.Notes, Profit = n.Profit, Weight = n.Weight, Total = n.Total, OrderId = n.OrderId, ProductId = n.ProductId, ClientId = n.ClientId }).FirstOrDefault();
            return data;
        }
    }
}
