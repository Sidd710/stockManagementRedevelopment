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
    
    public partial class tbl_loadtallydetail
    {
        public int Id { get; set; }
        public string loadtallyNumber { get; set; }
        public Nullable<int> IssueorderId { get; set; }
        public string vechileNo { get; set; }
        public string DriverName { get; set; }
        public string Rank { get; set; }
        public string UnitNo { get; set; }
        public Nullable<System.DateTime> DateofGenration { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> Createddate { get; set; }
        public Nullable<int> Modifiedby { get; set; }
        public Nullable<System.DateTime> Modifieddate { get; set; }
        public string Authority { get; set; }
        public string Through { get; set; }
        public Nullable<int> LoadtallyId { get; set; }
        public string Remarks { get; set; }
    }
}
