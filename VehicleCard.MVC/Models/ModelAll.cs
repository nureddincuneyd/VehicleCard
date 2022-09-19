using System.Collections.Generic;
using VehilceCard.ENT.Models;

namespace VehicleCard.MVC.Models
{
    public class ModelAll
    {
        public Model rModel { get; set; }
        public Product rProduct { get; set; }
        public ProductsWithVehicles rProductsWithVehicles { get; set; }
        public Vehicle rVehicle { get; set; }


        public List<Model> lModel { get; set; }
        public List<Product> lProduct { get; set; }
        public List<ProductsWithVehicles> lProductsWithVehicles { get; set; }
        public List<Vehicle> lVehicle { get; set; }


    }
}
