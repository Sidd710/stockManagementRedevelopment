using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using RHPDEntity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using StarMethods;


namespace RHPDDalc
{
  public class StockDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        public void DeleteOnUpdate(int SID)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@Action", "DeleteOnUpdate");
                param[1] = new SqlParameter("@SID", SID);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);



            }
            catch (Exception)
            {

                throw;
            }
        }
        public int InsertStockIn(StockEntity objentity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[43];
                param[42] = new SqlParameter("@Session", objentity.Session);
                param[41] = new SqlParameter("@IsDW", objentity.IsDW);
                param[40] = new SqlParameter("@IsSubPacking", objentity.IsSubPacking);
                param[39] = new SqlParameter("@SubPMCapacityId", objentity.SubPMCapacityId);
                param[38] = new SqlParameter("@SubPMConditionId", objentity.SubPMConditionId);
                param[37] = new SqlParameter("@SubPMGradeId", objentity.SubPMGradeId);
                param[36] = new SqlParameter("@SubPMName", objentity.SubPMName);
                param[35] = new SqlParameter("@SubPMShape", objentity.SubPMShape);
                param[34] = new SqlParameter("@SubPMSize", objentity.SubPMSize);
                param[33] = new SqlParameter("@SubShapeUnit", objentity.SubShapeUnit);
                param[32] = new SqlParameter("@SubWeight", objentity.SubWeight);
                param[31] = new SqlParameter("@SubWeightUnit", objentity.SubWeightUnit);
              
                param[30] = new SqlParameter("@IsWithoutPacking", objentity.IsWithoutPacking);
                param[29] = new SqlParameter("@IsEmptyPM", objentity.IsEmptyPM);
           
                param[28] = new SqlParameter("@PMCapacityId", objentity.PMCapacityId);
                param[27] = new SqlParameter("@PMConditionId", objentity.PMConditionId);
                param[26] = new SqlParameter("@PMGradeId", objentity.PMGradeId);
              
                param[24] = new SqlParameter("@ShapeUnit", objentity.ShapeUnit);
                param[25] = new SqlParameter("@WeigthUnit", objentity.WeigthUnit);

                param[23] = new SqlParameter("@Weight", SqlDbType.Decimal);
               
                param[23].Value = objentity.Weight;

           
                param[22] = new SqlParameter("@SupplierNo", objentity.SupplierNo);
                param[0] = new SqlParameter("@Action", "InsertStockIn");
                param[1] = new SqlParameter("@AddedBy", objentity.AddedBy);
                param[2] = new SqlParameter("@ATNo", objentity.ATNo);
                param[3] = new SqlParameter("@IsChallanNo", objentity.IsChallanNo);
                param[5] = new SqlParameter("@ChallanOrIRNo", objentity.ChallanOrIRNo);
                param[6] = new SqlParameter("@PackingMaterialFormat", objentity.PackagingMaterialFormat);
                param[7] = new SqlParameter("@CostOfParticular", SqlDbType.Decimal);              
                param[7].Value = objentity.CostOfParticular;
                param[8] = new SqlParameter("@GenericName", objentity.GenericName);
                param[9] = new SqlParameter("@OriginalMfg", objentity.OriginalMfg);
                param[10] = new SqlParameter("@OtherSupplier", objentity.OtherSupplier);
                param[11] = new SqlParameter("@PackagingMaterialFormatLevel", objentity.PackagingMaterialFormatLevel);
                param[12] = new SqlParameter("@PackagingMaterialName", objentity.PackagingMaterialName);
                param[13] = new SqlParameter("@PackagingMaterialShape", objentity.PackagingMaterialShape);
                param[14] = new SqlParameter("@PackagingMaterialSize", objentity.PackagingMaterialSize);
                param[15] = new SqlParameter("@ProductId", objentity.ProductId);
                param[16] = new SqlParameter("@RecievedDate", objentity.RecievedDate);
                param[17] = new SqlParameter("@RecievedFrom", objentity.RecievedFrom);
                param[18] = new SqlParameter("@Remarks", objentity.Remarks);
                param[19] = new SqlParameter("@SampleSent", objentity.SampleSent);
                param[20] = new SqlParameter("@TransferedBy", objentity.TransferedBy);
                param[4] = new SqlParameter("@IsIrNo", objentity.IsIrNo);
                param[21] = new SqlParameter("@Output", SqlDbType.Int);
                param[21].Direction = ParameterDirection.Output;
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
                r = Convert.ToInt32(param[21].Value);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateStockIn(StockEntity objentity)
        {
           
            try
            {
                SqlParameter[] param = new SqlParameter[44];
                param[43] = new SqlParameter("@Session", objentity.Session);
                param[41] = new SqlParameter("@IsDW", objentity.IsDW);
                param[40] = new SqlParameter("@IsSubPacking", objentity.IsSubPacking);
                param[39] = new SqlParameter("@SubPMCapacityId", objentity.SubPMCapacityId);
                param[38] = new SqlParameter("@SubPMConditionId", objentity.SubPMConditionId);
                param[37] = new SqlParameter("@SubPMGradeId", objentity.SubPMGradeId);
                param[36] = new SqlParameter("@SubPMName", objentity.SubPMName);
                param[35] = new SqlParameter("@SubPMShape", objentity.SubPMShape);
                param[34] = new SqlParameter("@SubPMSize", objentity.SubPMSize);
                param[33] = new SqlParameter("@SubShapeUnit", objentity.SubShapeUnit);
                param[32] = new SqlParameter("@SubWeight", objentity.SubWeight);
                param[42] = new SqlParameter("@SubWeightUnit", objentity.SubWeightUnit);
          
                param[30] = new SqlParameter("@IsWithoutPacking", objentity.IsWithoutPacking);
                param[31] = new SqlParameter("@IsEmptyPM", objentity.IsEmptyPM);
           
                param[28] = new SqlParameter("@PMCapacityId", objentity.PMCapacityId);
                param[27] = new SqlParameter("@PMConditionId", objentity.PMConditionId);
                param[29] = new SqlParameter("@PMGradeId", objentity.PMGradeId);         
               
                param[26] = new SqlParameter("@ShapeUnit", objentity.ShapeUnit);
                param[25] = new SqlParameter("@WeigthUnit", objentity.WeigthUnit);
              
                param[24] = new SqlParameter("@Weight", SqlDbType.Decimal);

                param[24].Value = objentity.Weight;
                param[23] = new SqlParameter("@SupplierNo", objentity.SupplierNo);
                param[22] = new SqlParameter("@SID", objentity.SID);
                param[0] = new SqlParameter("@Action", "UpdateStockIn");
                param[1] = new SqlParameter("@AddedBy", objentity.AddedBy);
                param[2] = new SqlParameter("@ATNo", objentity.ATNo);
                param[3] = new SqlParameter("@IsChallanNo", objentity.IsChallanNo);
                param[5] = new SqlParameter("@ChallanOrIRNo", objentity.ChallanOrIRNo);
                param[6] = new SqlParameter("@PackingMaterialFormat", objentity.PackagingMaterialFormat);
               
                param[7] = new SqlParameter("@CostOfParticular", SqlDbType.Decimal);
                param[7].Value = objentity.CostOfParticular;
            
                param[8] = new SqlParameter("@GenericName", objentity.GenericName);
                param[9] = new SqlParameter("@OriginalMfg", objentity.OriginalMfg);
                param[10] = new SqlParameter("@OtherSupplier", objentity.OtherSupplier);
                param[11] = new SqlParameter("@PackagingMaterialFormatLevel", objentity.PackagingMaterialFormatLevel);
                param[12] = new SqlParameter("@PackagingMaterialName", objentity.PackagingMaterialName);
                param[13] = new SqlParameter("@PackagingMaterialShape", objentity.PackagingMaterialShape);
                param[14] = new SqlParameter("@PackagingMaterialSize", objentity.PackagingMaterialSize);
                param[15] = new SqlParameter("@ProductId", objentity.ProductId);
                param[16] = new SqlParameter("@RecievedDate", objentity.RecievedDate);
                param[17] = new SqlParameter("@RecievedFrom", objentity.RecievedFrom);
                param[18] = new SqlParameter("@Remarks", objentity.Remarks);
                param[19] = new SqlParameter("@SampleSent", objentity.SampleSent);
                param[20] = new SqlParameter("@TransferedBy", objentity.TransferedBy);
                param[4] = new SqlParameter("@IsIrNo", objentity.IsIrNo);
                param[21] = new SqlParameter("@Output", SqlDbType.Int);
                param[21].Direction = ParameterDirection.Output;
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int SID)
        {
            try
            {
               
          SqlParameter[] param = new SqlParameter[2];
          
          param[0] = new SqlParameter("@Action", "DeleteStockIn");
          param[1] = new SqlParameter("@SID", SID);
         
          StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
                
       

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable SelectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectAll");               
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Select(int Id)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "Select");
                param[1] = new SqlParameter("@SID", Id);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectByCRVNo(string CRVNo,int ProductID)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Action", "SelectByCRVNo");
                param[1] = new SqlParameter("@CRVNo", CRVNo);
                param[2] = new SqlParameter("@ProductId", ProductID);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
  

        public DataTable SelectMultiple(string Ids)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "SelectMultiple");
                param[1] = new SqlParameter("@IDs", Ids);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
      public int AddCRVNo(int StockID,string CRVNo)
        {
           
            try
            {
                int r = 0;
                SqlParameter[] param = new SqlParameter[4];
                param[2] = new SqlParameter("@SID", StockID);
                param[0] = new SqlParameter("@Action", "UpdateCRV");
                param[1] = new SqlParameter("@CRVNo", CRVNo);
                param[3] = new SqlParameter("@Output", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
                r = Convert.ToInt32(param[3].Value);
                return r;
             
               
                
            }
            catch (Exception)
            {

                throw;
            }
        }

  
  }
  public class StockBatchDAL
  {
      SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
      SqlCommand cmd = new SqlCommand();
      public int InsertBatch(StockBatchEntity objentity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[21];
                param[20] = new SqlParameter("@WarehouseID", objentity.WarehouseID);
                param[19] = new SqlParameter("@SectionID", objentity.SectionID);
                param[18] = new SqlParameter("@SectionRows", objentity.SectionRows);

                param[17] = new SqlParameter("@SectionCol", objentity.SectionCol);

                param[16] = new SqlParameter("@SampleSentQty", objentity.SampleSentQty);
                param[15] = new SqlParameter("@WarehouseNo", objentity.WarehouseNo);
              param[14] = new SqlParameter("@Cost",  objentity.Cost);
       
              param[13] = new SqlParameter("@CostOfParticular", SqlDbType.Decimal);
              param[13].Value = objentity.CostOfParticular;
             param[12] = new SqlParameter("@BWeight", objentity.Weight);

             param[11] = new SqlParameter("@WeightofParticular", objentity.WeightofParticular);
              //param[11] = new SqlParameter("@WeightofParticular", SqlDbType.Decimal);
              //param[11].Value = objentity.WeightofParticular;
              //param[12] = new SqlParameter("@BWeight", SqlDbType.Decimal);
              //param[12].Value = objentity.Weight;

              param[10] = new SqlParameter("@WeightUnit", objentity.WeightUnit);
         

              param[9] = new SqlParameter("@Remarks", objentity.Remarks);
              param[8] = new SqlParameter("@ContactNo", objentity.ContactNo);
              param[4] = new SqlParameter("@Action", "InsertStockBatchMaster");
              param[1] = new SqlParameter("@BatchNo", objentity.BatchNo);
              param[2] = new SqlParameter("@ESLDate", objentity.ESLDate);
              param[3] = new SqlParameter("@ExpiryDate", objentity.ExpiryDate);
              param[5] = new SqlParameter("@MfgDate", objentity.MfgDate);
              param[6] = new SqlParameter("@SampleSent", objentity.SampleSent);
              param[7] = new SqlParameter("@StockId", objentity.StockId);
              param[0] = new SqlParameter("@Output", SqlDbType.Int);
              param[0].Direction = ParameterDirection.Output;
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
              r = Convert.ToInt32(param[0].Value);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public int UpdateBatch(StockBatchEntity objentity)
      {
         
          try
          {
              int r = 0;
              SqlParameter[] param = new SqlParameter[22];
                param[20] = new SqlParameter("@WarehouseID", objentity.WarehouseID);
                param[19] = new SqlParameter("@SectionID", objentity.SectionID);
                param[18] = new SqlParameter("@SectionRows", objentity.SectionRows);

                param[21] = new SqlParameter("@SectionCol", objentity.SectionCol);

                param[17] = new SqlParameter("@SampleSentQty", objentity.SampleSentQty);
                param[16] = new SqlParameter("@WarehouseNo", objentity.WarehouseNo);
              param[14] = new SqlParameter("@Cost", SqlDbType.Decimal);
              param[14].Value = objentity.Cost;
              //param[14] = new SqlParameter("@Cost", objentity.Cost);
            // param[13] = new SqlParameter("@CostOfParticular", objentity.CostOfParticular);
              param[13] = new SqlParameter("@CostOfParticular", SqlDbType.Decimal);
             param[13].Value = objentity.CostOfParticular;
             //param[11] = new SqlParameter("@BWeight", objentity.Weight);
             //param[12] = new SqlParameter("@WeightofParticular", objentity.WeightofParticular);
             param[12] = new SqlParameter("@BWeight", SqlDbType.Decimal);
             param[12].Value = objentity.Weight;
             param[11] = new SqlParameter("@WeightofParticular", SqlDbType.Decimal);
             param[11].Value = objentity.WeightofParticular;
             param[15] = new SqlParameter("@WeightUnit", objentity.WeightUnit);
              param[10] = new SqlParameter("@Remarks", objentity.Remarks);
              param[9] = new SqlParameter("@ContactNo", objentity.ContactNo);
              param[4] = new SqlParameter("@Action", "UpdateStockBatchMaster");
              param[8] = new SqlParameter("@BID", objentity.Id);
              param[1] = new SqlParameter("@BatchNo", objentity.BatchNo);
              param[2] = new SqlParameter("@ESLDate", objentity.ESLDate);
              param[3] = new SqlParameter("@ExpiryDate", objentity.ExpiryDate);
              param[5] = new SqlParameter("@MfgDate", objentity.MfgDate);
              param[6] = new SqlParameter("@SampleSent", objentity.SampleSent);
              param[7] = new SqlParameter("@StockId", objentity.StockId);
              param[0] = new SqlParameter("@Output", SqlDbType.Int);
              param[0].Direction = ParameterDirection.Output;
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
              r = Convert.ToInt32(param[0].Value);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public void Delete(int BID)
      {

          try
          {
              SqlParameter[] param = new SqlParameter[2];
              param[1] = new SqlParameter("@BID", BID);
              param[0] = new SqlParameter("@Action", "DeleteBatch");             
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);

          }
          catch (Exception)
          {

              throw;
          }
      }
        public DataTable GetWarehouseNoList()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "WarehouseNo");
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spGetWareHouseSections", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectByBatchNo(int BID)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[1];
           
              param[0] = new SqlParameter("@BatchCode", BID);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "usp_grdbachwithproductqty", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
   
      public DataTable Select(int Id)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectBatch");
              param[1] = new SqlParameter("@BID", Id);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectByStockId(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectBatchByStock");
              param[1] = new SqlParameter("@StockId", @StockId);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public DataTable SelectByVehicle(int StockId,string DriverName,string VehicleNo)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[4];
              param[0] = new SqlParameter("@Action", "SelectBatchByVehicle");
              param[1] = new SqlParameter("@StockId", StockId);
              param[2] = new SqlParameter("@DriverName", DriverName);
              param[3] = new SqlParameter("@VehicleNo", VehicleNo);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
  }
  public class StockVehicleDAL
  {
      SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
      SqlCommand cmd = new SqlCommand();

      public int Insert(StockVehicleEntity objentity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[10];

              param[9] = new SqlParameter("@IsDDOrCHT", objentity.IsDDOrCHT);
              param[8] = new SqlParameter("@ChallanNo", objentity.ChallanNo);
             param[4] = new SqlParameter("@Action", "InsertStockVehicle"); 
              param[1] = new SqlParameter("@VehicleNo", objentity.VehicleNo);
              param[2] = new SqlParameter("@StockId", objentity.StockId);
              param[3] = new SqlParameter("@StockBatchId", objentity.StockBatchId);
              param[5] = new SqlParameter("@SentQty", SqlDbType.Decimal);
              param[5].Value = objentity.SentQty;
              param[6] = new SqlParameter("@RecievedQty", SqlDbType.Decimal);
              param[6].Value = objentity.RecievedQty;
              
              param[7] = new SqlParameter("@DriverName", objentity.DriverName);
              param[0] = new SqlParameter("@Output", SqlDbType.Int);
              param[0].Direction = ParameterDirection.Output;
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
              r = Convert.ToInt32(param[0].Value);
              return r;
          }
          catch (Exception)
          {

              throw;
          }

      }
      public int Update(StockVehicleEntity objentity)
      {
          
          try
          {
              int v = 0;
              SqlParameter[] param = new SqlParameter[11];
              param[10] = new SqlParameter("@IsDDOrCHT", objentity.IsDDOrCHT);
              param[9] = new SqlParameter("@ChallanNo", objentity.ChallanNo);
              param[4] = new SqlParameter("@Action", "UpdateStockVehicle");
              param[1] = new SqlParameter("@VehicleNo", objentity.VehicleNo);
              param[2] = new SqlParameter("@StockId", objentity.StockId);
              param[3] = new SqlParameter("@StockBatchId", objentity.StockBatchId);
              param[5] = new SqlParameter("@SentQty", SqlDbType.Decimal);
              param[5].Value = objentity.SentQty;
              param[6] = new SqlParameter("@RecievedQty", SqlDbType.Decimal);
              param[6].Value = objentity.RecievedQty;
              
                   param[7] = new SqlParameter("@DriverName", objentity.DriverName);
              param[8] = new SqlParameter("@Id", objentity.Id);
              param[0] = new SqlParameter("@Output", SqlDbType.Int);
              param[0].Direction = ParameterDirection.Output;
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
              v = Convert.ToInt32(param[0].Value);
              return v;
              
          }
          catch (Exception)
          {

              throw;
          }
      }

      public void Delete(int Id)
      {

          try
          {
              SqlParameter[] param = new SqlParameter[2];
              param[1] = new SqlParameter("@Id", Id);
              param[0] = new SqlParameter("@Action", "DeleteVehicle");
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);

          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable Select(int Id)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectVehicle");
              param[1] = new SqlParameter("@Id", Id);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectByStockId(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectVehicleByStock");
              param[1] = new SqlParameter("@StockId", StockId);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectVehicleNoStockId(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectVehicleNoByStock");
              param[1] = new SqlParameter("@StockId", StockId);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectByBactchID(int StockId, int BatchID)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@Action", "SelectVehicleByBatch");
              param[1] = new SqlParameter("@StockBatchId", BatchID);
              param[2] = new SqlParameter("@StockId", StockId);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

  }


  public class StockSpillageDAL
  {
      SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
      SqlCommand cmd = new SqlCommand();

      public int Insert(StockSpillageEntity objentity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[9];
              param[5] = new SqlParameter("@Action", "InsertStockSpillage");
              //  param[7] = new SqlParameter("@SampleAffected", SqlDbType.Decimal);

              //  param[7].Value = objentity.SampleAffected;
              //  param[8] = new SqlParameter("@SpillageAffected", SqlDbType.Decimal);

              //  param[8].Value = objentity.SpillageAffected;
              //  param[9] = new SqlParameter("@BothAffected", SqlDbType.Decimal);

              //  param[9].Value = objentity.BothAffected;
              //  param[1] = new SqlParameter("@DamagedBoxes", SqlDbType.Decimal);

              //param[1].Value = objentity.DamagedBoxes;
              
              //param[2] = new SqlParameter("@SpilledQty", SqlDbType.Decimal);

              //param[2].Value = objentity.SpilledQty;

                param[7] = new SqlParameter("@SampleAffected",  objentity.SampleAffected);
                param[8] = new SqlParameter("@SpillageAffected",objentity.SpillageAffected);
                param[6] = new SqlParameter("@BothAffected",objentity.BothAffected);
                param[1] = new SqlParameter("@DamagedBoxes",  objentity.DamagedBoxes);

                param[2] = new SqlParameter("@SpilledQty", objentity.SpilledQty);
                param[3] = new SqlParameter("@StockBatchId", objentity.StockBatchId);
              param[4] = new SqlParameter("@StockId", objentity.StockId);             
              param[0] = new SqlParameter("@Output", SqlDbType.Int);
              param[0].Direction = ParameterDirection.Output;
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
              r = Convert.ToInt32(param[0].Value);
              return r;
          }
          catch (Exception ex)
          {

              throw;
          }
      }

      public DataTable SelectSpillageByStockId(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectIfSpillageByStock");
              param[1] = new SqlParameter("@StockId", StockId);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

       public DataTable SelectByStockId(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectSpillageByStock");
              param[1] = new SqlParameter("@StockId", StockId);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
       public DataTable SelectByBatchId(int StockId, int BatchId)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[3];
               param[0] = new SqlParameter("@Action", "SelectSpillageByStockBatch");
               param[1] = new SqlParameter("@StockId", StockId);
               param[2] = new SqlParameter("@StockBatchId", BatchId);
               dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
    

  }

  public class StockPakagingDAL
  {
      SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
      SqlCommand cmd = new SqlCommand();

      public int Insert(StockPakagingEntity objentity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[6];
              param[5] = new SqlParameter("@Action", "InsertStockPakaging");
              param[1] = new SqlParameter("@Format", objentity.Format);
              param[2] = new SqlParameter("@PackagingType", objentity.PackagingType);
              param[3] = new SqlParameter("@RemainingQty", SqlDbType.Decimal);
             
              param[3].Value = objentity.RemainingQty;

             
              
        
              param[4] = new SqlParameter("@StockBatchId", objentity.StockBatchId);
              param[0] = new SqlParameter("@Output", SqlDbType.Int);
              param[0].Direction = ParameterDirection.Output;
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spStock", param);
              r = Convert.ToInt32(param[0].Value);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public DataTable SelectDWByStockId(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectDWPacking");
              param[1] = new SqlParameter("@StockId", StockId);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectByCRVNo(string CRVNo, int ProductID)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@Action", "SelectPackingByCRVNo");
              param[1] = new SqlParameter("@CRVNo", CRVNo);
              param[2] = new SqlParameter("@ProductId", ProductID);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

     
  
      public DataTable SelectByMultipleSID(string SIDs)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectPackingBySIDs");
              param[1] = new SqlParameter("@IDs", SIDs);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectByStockId(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectPacking");
              param[1] = new SqlParameter("@StockId", StockId);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectByBatchId(int BatchID)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectPackingByBatchID");
              param[1] = new SqlParameter("@BID", BatchID);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

    
      public DataTable SelectByStockIdLoose(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@Action", "SelectPackingLoose");
              param[1] = new SqlParameter("@StockId", StockId);
              param[2] = new SqlParameter("@PackagingType", "Loose");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectByStockIdFull(int StockId)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@Action", "SelectPackingFull");
              param[1] = new SqlParameter("@StockId", StockId);
              param[2] = new SqlParameter("@PackagingType", "Full");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable Select(int Id)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectPackingById");
              param[1] = new SqlParameter("@Id", Id);
            
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
  }
}
