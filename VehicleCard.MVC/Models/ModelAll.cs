using System.Collections.Generic;
using VehicleCard.MAP.MapModel;
using VehilceCard.ENT.Models;

namespace VehicleCard.MVC.Models
{
    public class ModelAll
    {
        public ViewModel rModel { get; set; }
        public ViewProduct rProduct { get; set; }
        public ViewProductWithVehicle rProductsWithVehicles { get; set; }
        public ViewVehicle rVehicle { get; set; }


        public List<ViewModel> lModel { get; set; }
        public List<ViewProduct> lProduct { get; set; }
        public List<ViewProductWithVehicle> lProductsWithVehicles { get; set; }
        public List<ViewVehicle> lVehicle { get; set; }


    }
}
