using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehilceCard.ENT.Models
{
    public class ProductsWithVehicles:BaseEntity
    {
        public int AvailableCapKG { get; set; }
        public int AvailableCapM3 { get; set; }
        public int VehiclesId { get; set; }
        public int ProductsId { get; set; }

        // Relational Property
        public virtual Vehicle Vehicles { get; set; }
        public virtual Product Products { get; set; }

    }
}
