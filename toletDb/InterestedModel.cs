using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toletDb
{
    public class InterestedModel
    {
        public string users_id { get; set; }
        public string name { get; set; }
        public int I_id { get; set; }
        public string ad_id { get; set; }
        public string phone { get; set; }
        public string occupation { get; set; }
        public string familymembers { get; set; }
        public string presentAddress { get; set; }

      
        public virtual Interested Interested1 { get; set; }
        public virtual Interested Interested2 { get; set; }
    }
}

