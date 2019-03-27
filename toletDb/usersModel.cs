using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace toletDb
{
    using System;
    using System.Collections.Generic;

    public  class usersModel 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usersModel()
        {
            this.Ad = new HashSet<AdModel>();
            this.Governs = new HashSet<Governs>();
            this.Interested = new HashSet<Interested>();
        }
       // [Required(ErrorMessage ="Required propert")]
        public string users_id { get; set; }

        public string users_pass { get; set; }
        public string phone_no { get; set; }
        public string addresss { get; set; }

        
       // [Remote("IsEmpNameandMailExist", "Validation", ErrorMessage = "EmialId is already exist", AdditionalFields = "EmpName")]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdModel> Ad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Governs> Governs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interested> Interested { get; set; }
    }
}
