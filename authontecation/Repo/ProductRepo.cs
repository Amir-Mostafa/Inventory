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
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ProductRepo(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public ProductsVM Add(ProductsVM ob)
        {
            Products data = mapper.Map<Products>(ob);

            db.Products.Add(data);
            db.SaveChanges();
            return ob;

        }

        public ProductsVM Delete(int id)
        {
            try
            {
                Products d = db.Products.Where(n => n.Id == id).FirstOrDefault();
                db.Remove(d);
                db.SaveChanges();
                ProductsVM data = mapper.Map<ProductsVM>(d);
                return data;
            }
            catch
            {
                return null;
            }
        }

        public ProductsVM Edit(ProductsVM ob)
        {
            try
            {
                var data = mapper.Map<Products>(ob);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return ob;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ProductsVM> GetAll()
        {
            var data = db.Products.Select(n => new ProductsVM { Id = n.Id, Name = n.Name, BuyPrice = n.BuyPrice, SellPrice = n.SellPrice,Notes = n.Notes, Profit = n.Profit,Weight=n.Weight });
            return data;
        }

        public ProductsVM GetById(int id)
        {
            ProductsVM data = db.Products.Where(n => n.Id == id).Select(n => new ProductsVM { Id = n.Id, Name = n.Name, BuyPrice = n.BuyPrice, SellPrice = n.SellPrice, Notes = n.Notes, Profit = n.Profit, Weight = n.Weight }).FirstOrDefault();
            return data;
        }
    }
}
