using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toletDb
{
   public class Detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Detail()
        {
            this.Ad = new HashSet<AdModel>();
        }

        public string detail_id { get; set; }
        public Nullable<int> number_of_room { get; set; }
        public Nullable<int> number_of_kitchen { get; set; }
        public Nullable<int> number_of_bathroom { get; set; }
        public string size_of_flat { get; set; }
        public string additional_info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdModel> Ad { get; set; }
    }
}
