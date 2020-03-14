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
    
    public partial class ExpenseVoucherMaster
    {
        public int ID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> BatchID { get; set; }
        public Nullable<decimal> UsedQty { get; set; }
        public Nullable<decimal> UsedFromFullPackets { get; set; }
        public string FormatFull { get; set; }
        public string FormatLoose { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<decimal> RemainingQty { get; set; }
        public string ExpenseVoucherNo { get; set; }
    
        public virtual BatchMaster BatchMaster { get; set; }
        public virtual CategoryMaster CategoryMaster { get; set; }
        public virtual ProductMaster ProductMaster { get; set; }
    }
}