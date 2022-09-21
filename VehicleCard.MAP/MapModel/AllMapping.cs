using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehilceCard.ENT.Models;

namespace VehicleCard.MAP.MapModel
{
    public class AllMapping:Profile
    {
        public AllMapping()
        {
            CreateMap<ViewModel, Model>();
            CreateMap<Model, ViewModel>();

            CreateMap<ViewProduct, Product>();
            CreateMap<Product, ViewProduct>();

            CreateMap<ProductsWithVehicles, ViewProductWithVehicle>();
            CreateMap<ViewProductWithVehicle, ProductsWithVehicles>();

            CreateMap<Vehicle, ViewVehicle>();
            CreateMap<ViewVehicle, Vehicle>();
        }

    }
}
