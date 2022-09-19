using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCard.MAP.MapModel
{
    public interface IViewBase
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
