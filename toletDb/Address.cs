using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toletDb
{
  public  class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            this.Ad = new HashSet<AdModel>();
        }

        public string addresss_id { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string street_name { get; set; }
        public string street_no { get; set; }
        public string additional_addresss { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdModel> Ad { get; set; }
    }
}
