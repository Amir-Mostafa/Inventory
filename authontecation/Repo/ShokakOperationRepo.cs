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
    public class ShokakOperationRepo: IShokakOperationRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ShokakOperationRepo(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public ShokakOperationVM Add(ShokakOperationVM ob)
        {
            ShokakOperation data = mapper.Map<ShokakOperation>(ob);

            db.ShokakOperations.Add(data);
            db.SaveChanges();
            return ob;
        }

        public ShokakOperationVM Delete(int id)
        {

            try
            {
                ShokakOperation d = db.ShokakOperations.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();
                ShokakOperationVM data = mapper.Map<ShokakOperationVM>(d);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public ShokakOperationVM Edit(ShokakOperationVM ob)
        {

            try
            {
                var data = mapper.Map<ShokakOperation>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ShokakOperationVM> GetAll()
        {
            var data = db.ShokakOperations.Select(n => new ShokakOperationVM { Id = n.Id, Creditor = n.Creditor, Debtor = n.Debtor, Date= n.Date, Notes = n.Notes, OrderId = n.OrderId, ClientId = n.ClientId });
            return data;
        }

        public ShokakOperationVM GetById(int id)
        {
            ShokakOperationVM data = db.ShokakOperations.Where(n => n.Id == id).Select(n => new ShokakOperationVM { Id = n.Id, Creditor = n.Creditor, Debtor = n.Debtor, Date = n.Date, Notes = n.Notes, OrderId = n.OrderId, ClientId = n.ClientId }).FirstOrDefault();
            return data;
        }

        public List<ShokakOperationVM> clientOperations(int id)
        {
            List<ShokakOperationVM> data =db.ShokakOperations.Where(n => n.ClientId == id).Select(n => new ShokakOperationVM { Id = n.Id, Creditor = n.Creditor, Debtor = n.Debtor, Date = n.Date, Notes = n.Notes, OrderId = n.OrderId, ClientId = n.ClientId }).ToList();

            double totalCreit = 0;
            double totalDebtor = 0;
            for (int i=0;i<data.Count;i++)
            {
                if (i == 0)
                    data[i].total =(double.Parse(data[i].Debtor) - double.Parse(data[i].Creditor)).ToString();

                else
                {
                    data[i].total = (double.Parse(data[i].Debtor) - double.Parse(data[i].Creditor)+ double.Parse(data[i - 1].total)).ToString();
                }
                totalCreit += double.Parse(data[i].Creditor);
                totalDebtor += double.Parse(data[i].Debtor);
            }
            if (data.Count > 0)
            {
                data[data.Count - 1].totalCreditor = totalCreit.ToString();
                data[data.Count - 1].totalDebtor = totalDebtor.ToString();
            }

            return data;
        }
    }
}
