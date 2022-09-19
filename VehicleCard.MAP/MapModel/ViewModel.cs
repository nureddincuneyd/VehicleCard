using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCard.MAP.MapModel
{
    public class ViewModel : IViewBase
    {
        public int Id { get; set; }
        public string BrandName { get; set; }       // Marka Adı
        public string ModelName { get; set; }       // Model Adı
        public int CapacityKG { get; set; }         // KG Kapasitesi
        public int CapacityM3 { get; set; }         // M3 Kapasitesi
        public bool Status { get; set; }
    }
}
