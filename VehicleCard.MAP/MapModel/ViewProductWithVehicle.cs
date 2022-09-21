using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCard.MAP.MapModel
{
    public class ViewProductWithVehicle : IViewBase
    {
        public int Id { get; set; }
        public int AvailableCapKG { get; set; }
        public int AvailableCapM3 { get; set; }
        public int VehiclesId { get; set; }
        public int ProductsId { get; set; }
        public string OperationName { get; set; }
        public bool Status { get; set; }
    }
}
