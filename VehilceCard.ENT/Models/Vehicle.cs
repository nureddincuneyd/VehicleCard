using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehilceCard.ENT.Models
{
    public class Vehicle:BaseEntity
    {
        public string Plate { get; set; }           // Plaka
        public string VehicleImgUrl { get; set; }   // Resim URL'i
        public string Location { get; set; }        // Aracın Bulunduğu Yer
        public int vModelId { get; set; }           // Model Id'si

        // Relational Property

        public virtual Model vModel { get; set; }
        public virtual List<ProductsWithVehicles> ProductsWithVehicles { get; set; }
    }
}
