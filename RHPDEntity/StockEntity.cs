using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
    public class StockEntity
    {
        public DateTime Session { get; set; }
        public bool IsSubPacking	{ get; set; }
 public bool IsDW	{ get; set; }
public string SubPMName	{ get; set; }
public int? SubPMGradeId	{ get; set; }
public int? SubPMCapacityId	{ get; set; }
public int? SubPMConditionId	{ get; set; }
public string SubPMShape	{ get; set; }
public string SubPMSize	{ get; set; }
 public double? SubWeight	{ get; set; }
public string SubWeightUnit	{ get; set; }
public string SubShapeUnit { get; set; }
        public bool IsEmptyPM { get; set; }
        public bool IsWithoutPacking { get; set; }
        public int? PMGradeId { get; set; }
        public int? PMConditionId { get; set; }
        public int? PMCapacityId { get; set; }
        public string ShapeUnit { get; set; }
        public string WeigthUnit { get; set; }
        public string CRVNo { get; set; }
        public int IsIrNo { get; set; }
        public int SID { get; set; }
        public int? IsChallanNo { get; set; }
        public string Action { get; set; }
        public string SupplierNo { get; set; }
        public double Weight { get; set; }
     public int Id { get; set; }
        public string ATNo { get; set;} 
              public string RecievedFrom { get; set; }
          public string OtherSupplier { get; set; }
          public string TransferedBy { get; set; }
          public bool? SampleSent { get; set; }
          public string ContactNo { get; set; }
         public string ChallanOrIR { get; set; }
 public string ChallanOrIRNo { get; set; }
 public int ProductId { get; set; }
 public string OriginalMfg { get; set; }
 public string GenericName { get; set; }  
public double CostOfParticular { get; set; }  
 public DateTime RecievedDate { get; set; }  

 public string PackagingMaterialName { get; set; } 
        public string PackagingMaterialShape { get; set; }
        public string PackagingMaterialSize { get; set; } 
public double PackagingMaterialFormatLevel { get; set; }
public string PackagingMaterialFormat { get; set; } 
        public string Remarks { get; set; }
        public int AddedBy { get; set; } 

         public DateTime AddedOn { get; set; }  
         public int ModifiedBy { get; set; }

         public DateTime ModifiedOn { get; set; }

    }

    public class StockBatchEntity
    {
        public string Remarks { get; set; }
        public int Id { get; set; }
        public int StockId { get; set; }
         public string BatchNo { get; set; }
         public string ContactNo { get; set; }
           public DateTime  MfgDate { get; set; }
         public DateTime?  ESLDate { get; set; }
 public DateTime?  ExpiryDate { get; set; }
 public bool SampleSent { get; set; }
        public int WarehouseID { get; set; }
        public int? SectionID { get; set; }
        public int? SectionRows { get; set; }
        public int? SectionCol { get; set; }

        public double? SampleSentQty { get; set; }
        public double?   Cost { get; set; }
       public double CostOfParticular { get; set; }
       public double? Weight { get; set; }
       public double? WeightofParticular { get; set; }
          public string WeightUnit { get; set; }
          public string WarehouseNo { get; set; }

    }

    public class StockVehicleEntity
    {
        public string  IsDDOrCHT { get; set; }
        public string Action { get; set; }
        public int Id { get; set; }
          public int StockId { get; set; }
         public string DriverName { get; set; }
         public string VehicleNo
         {
             get;
             set;
         }
         public string ChallanNo { get; set; }
         public int StockBatchId { get; set; }

          public decimal SentQty { get; set; }
          public decimal RecievedQty { get; set; }






    }
    public class StockSpillageEntity
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public int StockId { get; set; }
         public int StockBatchId { get; set; }
         public double SpilledQty { get; set; }
         public double DamagedBoxes { get; set; }
        public double SpillageAffected { get; set; }
        public double SampleAffected { get; set; }


        public double BothAffected { get; set; }






    }
    public class StockPakagingEntity
    {
        public string Action { get; set; }
        public int Id { get; set; }
        public string PackagingType { get; set; }
         public string Format { get; set; }
         public double RemainingQty { get; set; }
         public int StockBatchId { get; set; }





    }
}
