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
    
    public partial class tblExpensePMContainer
    {
        public int Id { get; set; }
        public string ExpenseVoucherNo { get; set; }
        public int PMContainerId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<bool> IsSentfromCP { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string Remarks { get; set; }
    
        public virtual AddPMContainer AddPMContainer { get; set; }
    }
}
