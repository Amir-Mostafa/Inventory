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
    public class BuyOrderRepo:IBuyOrderRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public BuyOrderRepo(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public BuyOrderVM Add(BuyOrderVM ob)
        {
            BuyOrder data = mapper.Map<BuyOrder>(ob);

            db.BuyOrders.Add(data);
            db.SaveChanges();
            return mapper.Map<BuyOrderVM>(data);
        }

        public BuyOrderVM Delete(int id)
        {

            try
            {
                BuyOrder d = db.BuyOrders.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();

                BuyOrderVM data = mapper.Map<BuyOrderVM>(d);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public BuyOrderVM Edit(BuyOrderVM ob)
        {

            try
            {
                var data = mapper.Map<BuyOrder>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<BuyOrderVM> GetAll()
        {
            var data = db.BuyOrders.Select(n => new BuyOrderVM { Id = n.Id, Total = n.Total, UserName = n.UserName, Date = n.Date, SupplierId = n.SupplierId });
            return data;
        }

        public BuyOrderVM GetById(int id)
        {
            BuyOrderVM data = db.BuyOrders.Where(n => n.Id == id).Select(n => new BuyOrderVM { Id = n.Id, Total = n.Total, UserName = n.UserName, Date = n.Date, SupplierId = n.SupplierId }).FirstOrDefault();
            return data;
        }

        public BuyOrderVM NextOrder(int id)
        {
            int idd = 0;
            BuyOrder o = db.BuyOrders.OrderByDescending(o => o.Id).FirstOrDefault();
            if (o != null)
                idd = o.Id;

            if (id < idd)
            {
                id++;

                BuyOrderVM data = db.BuyOrders.Where(n => n.Id == id).Select(n => new BuyOrderVM { Id = n.Id, Date = n.Date, Total = n.Total, UserName = n.UserName,SupplierId=n.SupplierId,SupplierName=n.Suppliers.Name }).FirstOrDefault();
                while (data == null && id <= idd)
                {
                    data = db.BuyOrders.Where(n => n.Id == id).Select(n => new BuyOrderVM { Id = n.Id, Date = n.Date, Total = n.Total, UserName = n.UserName, SupplierId = n.SupplierId, SupplierName = n.Suppliers.Name }).FirstOrDefault();
                    id++;
                }
                return data;
            }
            else
                return null;
        }
        public BuyOrderVM PrevOrder(int id)
        {
            int idd = 0;
            BuyOrder o = db.BuyOrders.OrderBy(o => o.Id).FirstOrDefault();
            if (o != null)
                idd = o.Id;

            if (id > idd)
            {
                id--;

                BuyOrderVM data = db.BuyOrders.Where(n => n.Id == id).Select(n => new BuyOrderVM { Id = n.Id, Date = n.Date, Total = n.Total, UserName = n.UserName, SupplierId = n.SupplierId, SupplierName = n.Suppliers.Name }).FirstOrDefault();
                while (data == null && id >= idd)
                {
                    data = db.BuyOrders.Where(n => n.Id == id).Select(n => new BuyOrderVM { Id = n.Id, Date = n.Date, Total = n.Total, UserName = n.UserName, SupplierId = n.SupplierId, SupplierName = n.Suppliers.Name }).FirstOrDefault();
                    id--;
                }
                return data;
            }
            else
                return null;
        }
        public BuyOrderVM LastOrder()
        {
            BuyOrder o = db.BuyOrders.OrderByDescending(o => o.Id).FirstOrDefault();

            if (o == null)
                return null;
            else
                return mapper.Map<BuyOrderVM>(o);
        }

    }
}
