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
    
    public partial class usp_DeleteIssuedVehicle_Result
    {
        public int Id { get; set; }
        public string IssueVoucherId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string VehicleNo { get; set; }
        public Nullable<decimal> PMQuantity { get; set; }
        public Nullable<decimal> StockQuantity { get; set; }
        public string VoucherRemarks { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> dateofgenration { get; set; }
        public string Through { get; set; }
        public Nullable<int> issueVoucher_status { get; set; }
        public Nullable<int> Cat_ID { get; set; }
        public Nullable<int> issueorderID { get; set; }
        public string batchno { get; set; }
        public string FormatFull { get; set; }
        public string FormatLoose { get; set; }
        public Nullable<int> BID { get; set; }
        public Nullable<bool> FullOccupied { get; set; }
    }
}