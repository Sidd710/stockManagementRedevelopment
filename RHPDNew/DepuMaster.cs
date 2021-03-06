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
    
    public partial class DepuMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepuMaster()
        {
            this.BatchDepots = new HashSet<BatchDepot>();
            this.BatchMasters = new HashSet<BatchMaster>();
            this.StockTransfers = new HashSet<StockTransfer>();
            this.UnitMasters = new HashSet<UnitMaster>();
        }
    
        public int Depu_Id { get; set; }
        public string Depu_Name { get; set; }
        public string Depu_Location { get; set; }
        public string Depot_Code { get; set; }
        public Nullable<bool> IsParent { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CommandId { get; set; }
        public Nullable<int> FormationId { get; set; }
        public string Corp { get; set; }
        public string DepotNo { get; set; }
        public string IDT { get; set; }
        public string ICT { get; set; }
        public string AWS { get; set; }
        public string UnitName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatchDepot> BatchDepots { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatchMaster> BatchMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockTransfer> StockTransfers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnitMaster> UnitMasters { get; set; }
    }
}
