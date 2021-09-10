using authontecation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repo.Entity;
namespace authontecation.Authontecation
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //public DbSet<Employee> Employees { get; set; }
        //public DbContainer(DbContextOptions<DbContainer> opts) : base(opts) { }
        public DbSet<City> City { get; set; }
        public DbSet<Client> Client { get; set; }
        //public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ShokakOperation> ShokakOperations { get; set; }

        public DbSet<Operations> Operations { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }

        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<BuyOperations> BuyOperations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
       .Entity<City>()
       .HasMany(e => e.Clients)
       .WithOne(e => e.City)
       .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
