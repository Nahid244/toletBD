//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace toletBDdb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Addresss
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Addresss()
        {
            this.Ad = new HashSet<Ad>();
        }
    
        public string addresss_id { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string street_name { get; set; }
        public string street_no { get; set; }
        public string additional_addresss { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ad> Ad { get; set; }
    }
}
