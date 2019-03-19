using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toletDb
{
   public class Governs
    {
        public int G_id { get; set; }
        public string users_id { get; set; }
        public string request { get; set; }

        public virtual usersModel Users { get; set; }
    }
}
