//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp9
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public good()
        {
            this.bookings = new HashSet<booking>();
        }
    
        public int id { get; set; }
        public string article { get; set; }
        public string name { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<System.DateTime> cdate { get; set; }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       
        public virtual ICollection<booking> bookings { get; set; }
    }
}
