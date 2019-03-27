using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toletDb
{
   public class Interested
    {
        public int I_id { get; set; }
        public string ad_id { get; set; }
        public string users_id { get; set; }
        public string msg { get; set; }

        public virtual AdModel Ad { get; set; }
        public virtual usersModel Users { get; set; }
    }
}
