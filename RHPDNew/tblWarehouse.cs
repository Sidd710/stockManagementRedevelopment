//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RHPDNew
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblWarehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblWarehouse()
        {
            this.tblSections = new HashSet<tblSection>();
        }
    
        public int ID { get; set; }
        public string WareHouseNo { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSection> tblSections { get; set; }
    }
}
