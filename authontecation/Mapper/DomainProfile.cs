using AutoMapper;
using repo.Entity;
using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<BuyOrder, BuyOrderVM>();
            CreateMap<BuyOrderVM,BuyOrder>();

            CreateMap<BuyOperations,BuyOperationsVM>();
            CreateMap<BuyOperationsVM,BuyOperations>();

            CreateMap<City,CityVM>();
            CreateMap<CityVM,City>();

            CreateMap<Client, ClientVM>();
            CreateMap<ClientVM,Client>();

            CreateMap<Operations,OperationsVM>();
            CreateMap<OperationsVM, Operations>();


            CreateMap<Orders,OrdersVM>();
            CreateMap<OrdersVM,Orders>();


            CreateMap<Products, ProductsVM>();
            CreateMap<ProductsVM, Products>();

            CreateMap<ShokakOperation, ShokakOperationVM>();
            CreateMap<ShokakOperationVM, ShokakOperation>();

            CreateMap<Suppliers, SuppliersVM>();
            CreateMap<SuppliersVM, Suppliers>();
        }
    }
}
