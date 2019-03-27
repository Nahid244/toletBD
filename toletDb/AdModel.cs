using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toletDb
{
    public class AdModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdModel()
        {
            this.Interested = new HashSet<Interested>();
        }

        public String ad_id { get; set; }
        public string users_id { get; set; }
        public string phone { get; set; }
        public string rent { get; set; }
        public byte[] img1 { get; set; }
        public byte[] img2 { get; set; }
        public byte[] img3 { get; set; }
        public byte[] img4 { get; set; }
        public Nullable<System.DateTime> datee { get; set; }
        public int addresss_id { get; set; }
        
        public string city { get; set; }
        public string area { get; set; }
        public string street_name { get; set; }
        public string street_no { get; set; }
        public string additional_addresss { get; set; }

        public string availability { get; set; }

        public int detail_id { get; set; }
        public String number_of_room { get; set; }
        public String number_of_kitchen { get; set; }
        public String number_of_bathroom { get; set; }
        public string size_of_flat { get; set; }
        public string additional_info { get; set; }

        public virtual Address Addresss { get; set; }
        public virtual Detail Detailsofad { get; set; }
        public virtual usersModel Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interested> Interested { get; set; }
    }
}

