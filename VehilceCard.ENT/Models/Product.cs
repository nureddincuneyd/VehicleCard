using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehilceCard.ENT.Models
{
    public class Product:BaseEntity
    {
        public string ProName { get; set; }         // Ürün Adı
        public int ProKG { get; set; }              // Ürün Ağırlığı
        public int ProM3 { get; set; }              // Ürün Hacmi
        public string ProImgUrl { get; set; }       // Ürün Resmi

        // Relational Property
        public virtual List<ProductsWithVehicles> ProductsWithVehicles { get; set; }
    }
}
