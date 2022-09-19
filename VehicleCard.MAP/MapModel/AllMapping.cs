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
            CreateMap<Product, ViewProduct>();
            CreateMap<Model, ViewModel>();
            CreateMap<ProductsWithVehicles, ViewProductWithVehicle>();
            CreateMap<Vehicle, ViewVehicle>();


            CreateMap<ViewProduct,Product>();
            CreateMap<ViewModel,Model>();
            CreateMap<ViewProductWithVehicle,ProductsWithVehicles>();
            CreateMap<ViewVehicle,Vehicle>();
        }

    }
}
