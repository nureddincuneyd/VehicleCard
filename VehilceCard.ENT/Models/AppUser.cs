using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehilceCard.ENT.Models
{
    public class AppUser : BaseEntity
    {
        public string UserMail { get; set; }
        public string UserFullName { get; set; }
        public string UserPass { get; set; }
    }
}
