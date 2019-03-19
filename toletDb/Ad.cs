using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toletDb
{
   public class Ad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ad()
        {
            this.Interested = new HashSet<Interested>();
        }

        public string ad_id { get; set; }
        public string users_id { get; set; }
        public string phone { get; set; }
        public string rent { get; set; }
        public byte[] img1 { get; set; }
        public byte[] img2 { get; set; }
        public byte[] img3 { get; set; }
        public byte[] img4 { get; set; }
        public Nullable<System.DateTime> datee { get; set; }
        public string addresss_id { get; set; }
        public string availability { get; set; }
        public string detail_id { get; set; }

        public virtual Address Addresss { get; set; }
        public virtual Detail Detailsofad { get; set; }
        public virtual usersModel Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interested> Interested { get; set; }
    }
}
