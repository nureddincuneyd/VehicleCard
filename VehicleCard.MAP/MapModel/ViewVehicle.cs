using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCard.MAP.MapModel
{
    public class ViewVehicle : IViewBase
    {
        public int Id { get; set; }
        public string Plate { get; set; }           // Plaka
        public string VehicleImgUrl { get; set; }   // Resim URL'i
        public string Location { get; set; }        // Aracın Bulunduğu Yer
        public int vModelId { get; set; }           // Model Id'si
        public bool Status { get; set; }
    }
}
