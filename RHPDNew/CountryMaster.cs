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
    
    public partial class CountryMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CountryMaster()
        {
            this.StatesMasters = new HashSet<StatesMaster>();
        }
    
        public int ID { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public Nullable<bool> AllowBilling { get; set; }
        public Nullable<bool> AllowShiping { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatesMaster> StatesMasters { get; set; }
    }
}