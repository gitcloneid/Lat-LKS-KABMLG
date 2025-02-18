//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kabmlg
{
    using System;
    using System.Collections.Generic;
    
    public partial class borrowing_record
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public borrowing_record()
        {
            this.borrowing_record_status = new HashSet<borrowing_record_status>();
        }
    
        public int id { get; set; }
        public int borrower_id { get; set; }
        public int device_id { get; set; }
        public string description { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public string status { get; set; }
        public byte[] created_at { get; set; }
    
        public virtual devices devices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<borrowing_record_status> borrowing_record_status { get; set; }
        public virtual users users { get; set; }
    }
}
