using System.Collections.Generic;

namespace VehilceCard.ENT.Models
{
    public class Model:BaseEntity
    {
        public string BrandName { get; set; }       // Marka Adı
        public string ModelName { get; set; }       // Model Adı
        public int CapacityKG { get; set; }         // KG Kapasitesi
        public int CapacityM3 { get; set; }         // M3 Kapasitesi

        // Relational Property

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
