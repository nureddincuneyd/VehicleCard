using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCard.MAP.MapModel
{
    public class ViewProduct : IViewBase
    {
        public int Id { get; set; }
        public string ProName { get; set; }
        public int ProKG { get; set; }
        public int ProM3 { get; set; }
        public string ProImgUrl { get; set; }
        public bool Status { get; set; }
    }
}
