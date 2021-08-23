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
    public class OrderRepo :IOrderRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public OrderRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public OrdersVM Add(OrdersVM ob)
        {
            Orders data = mapper.Map<Orders>(ob);

            db.Orders.Add(data);
            db.SaveChanges();
            db.Entry(data).Reload();
            return mapper.Map<OrdersVM>(data);
        }

        public OrdersVM Delete(int id)
        {
            try
            {
                Orders d = db.Orders.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();
                OrdersVM data = mapper.Map<OrdersVM>(d);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public OrdersVM Edit(OrdersVM ob)
        {
            try
            {
                var data = mapper.Map<Orders>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<OrdersVM> GetAll()
        {
            var data = db.Orders.Select(n => new OrdersVM {  Id= n.Id, Date = n.Date, Total = n.Total, UserName = n.UserName, Paid = n.Paid,Remaind=n.Remaind,Weight=n.Weight,ClientId=n.ClientId });
            return data;
        }

        public OrdersVM GetById(int id)
        {
            OrdersVM data = db.Orders.Where(n => n.Id == id).Select(n => new OrdersVM { Id = n.Id, Date = n.Date, Total = n.Total, UserName = n.UserName, Paid = n.Paid, Remaind = n.Remaind, Weight = n.Weight, ClientId = n.ClientId }).FirstOrDefault();
            return data;
        }

     
    }
}
