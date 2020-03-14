using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;

namespace RHPDComponent
{
    public class StockComp
    {
        public void DeleteOnUpdate(int SID)
        {
            try
            {
                StockDAL objDal = new StockDAL();
                objDal.DeleteOnUpdate(SID);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int InsertStockIn(StockEntity objentity)
        {
            try
            {
                int r;
                StockDAL objDal = new StockDAL();
                r = objDal.InsertStockIn(objentity);
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
                 StockDAL objDal = new StockDAL();
                 objDal.UpdateStockIn(objentity);
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
                StockDAL objDal = new StockDAL();
                objDal.Delete(SID);
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
                StockDAL objDal = new StockDAL();

                return dt = objDal.SelectAll(); 
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
                StockDAL objDal = new StockDAL();

                return dt = objDal.SelectByCRVNo(CRVNo,ProductID);
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
                StockDAL objDal = new StockDAL();

                return dt = objDal.SelectMultiple(Ids);
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
                StockDAL objDal = new StockDAL();

                return dt = objDal.Select(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int AddCRVNo(int StockID, string CRVNo)
        {
            try
            {
                int r = 0;
                StockDAL objDal = new StockDAL();

               return r= objDal.AddCRVNo(StockID, CRVNo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    public class StockBatchComp
    {
        public int InsertBatch(StockBatchEntity objentity)
        {
           
            try
            {
                int r;
                StockBatchDAL objDal = new StockBatchDAL();
                r = objDal.InsertBatch(objentity);
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
                 StockBatchDAL objDal = new StockBatchDAL();
                return r=objDal.UpdateBatch(objentity);
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
                StockBatchDAL objDal = new StockBatchDAL();

                return dt = objDal.GetWarehouseNoList();
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
                StockBatchDAL objDal = new StockBatchDAL();

                return dt = objDal.SelectByBatchNo(BID);
      
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectByVehicle(int StockId, string DriverName, string VehicleNo)
        {
            try
            {
                DataTable dt = new DataTable();
                  StockBatchDAL objDal = new StockBatchDAL();

                  return dt = objDal.SelectByVehicle(StockId,DriverName,VehicleNo);
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
                 StockBatchDAL objDal = new StockBatchDAL();
                 objDal.Delete(BID);
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
                StockBatchDAL objDal = new StockBatchDAL();
                     return dt=objDal.Select(Id);
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
                StockBatchDAL objDal = new StockBatchDAL();
                           return dt=objDal.SelectByStockId(StockId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
    public class StockVehicleComp
    {
        public int Insert(StockVehicleEntity objentity)
        {
            try
            {
                int r;
                
                StockVehicleDAL objDal = new StockVehicleDAL();
                r = objDal.Insert(objentity);
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
 StockVehicleDAL objDal = new StockVehicleDAL();
               return  v= objDal.Update(objentity);
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
                StockVehicleDAL objDal = new StockVehicleDAL();
                objDal.Delete(Id);
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
                StockVehicleDAL objDal = new StockVehicleDAL();
                DataTable dt = new DataTable();
                      return dt=objDal.Select(Id);
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
                StockVehicleDAL objDal = new StockVehicleDAL();
                DataTable dt = new DataTable();
                return dt=objDal.SelectByStockId(StockId);
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
                StockVehicleDAL objDal = new StockVehicleDAL();
                DataTable dt = new DataTable();
                return dt = objDal.SelectVehicleNoStockId(StockId);
            }
            catch (Exception)
            {

                throw;
            }
        }
          public DataTable SelectByBactchID(int StockId,int BatchID)
        {
            try
            {
                StockVehicleDAL objDal = new StockVehicleDAL();
                DataTable dt = new DataTable();
                return dt = objDal.SelectByBactchID(StockId,BatchID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    public class StockSpillageComp
    {
        public int Insert(StockSpillageEntity objentity)
        {
            try
            {
                int r;

                StockSpillageDAL objDal = new StockSpillageDAL();
                r = objDal.Insert(objentity);
                return r;
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
                 StockSpillageDAL objDal = new StockSpillageDAL();
                 return dt = objDal.SelectByStockId(StockId);
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
                StockSpillageDAL objDal = new StockSpillageDAL();
                return dt = objDal.SelectByBatchId(StockId,BatchId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectSpillageByStockId(int StockId)
        {
            try
            {
                DataTable dt = new DataTable();
                StockSpillageDAL objDal = new StockSpillageDAL();
                return dt = objDal.SelectSpillageByStockId(StockId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    public class StockPakagingComp
    {
        public DataTable Select(int Id)
        {
            try
            {
                StockPakagingDAL objDal = new StockPakagingDAL();
                DataTable dt = new DataTable();
                return dt = objDal.Select(Id);
          
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int Insert(StockPakagingEntity objentity)
        {
            try
            {
                int r;
                StockPakagingDAL objDal = new StockPakagingDAL();
                r = objDal.Insert(objentity);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectDWByStockId(int StockId)
        {
            StockPakagingDAL objDal = new StockPakagingDAL();
            DataTable dt = new DataTable();
            return dt = objDal.SelectDWByStockId(StockId);
        }

        public DataTable SelectByCRVNo(string CRVNo, int ProductID)
        {
            try
            {
                StockPakagingDAL objDal = new StockPakagingDAL();
                DataTable dt = new DataTable();
                return dt = objDal.SelectByCRVNo(CRVNo, ProductID);


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
                 StockPakagingDAL objDal = new StockPakagingDAL();
                 DataTable dt = new DataTable();
                 return dt = objDal.SelectByMultipleSID(SIDs);


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
                StockPakagingDAL objDal = new StockPakagingDAL();
                DataTable dt = new DataTable();
                return dt = objDal.SelectByBatchId(BatchID);
          
 
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
 StockPakagingDAL objDal = new StockPakagingDAL();
 DataTable dt = new DataTable();
               return dt=objDal.SelectByStockId(StockId);
          
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
                StockPakagingDAL objDal = new StockPakagingDAL();
                DataTable dt = new DataTable();
                return dt = objDal.SelectByStockIdLoose(StockId);

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
                StockPakagingDAL objDal = new StockPakagingDAL();
                DataTable dt = new DataTable();
                return dt = objDal.SelectByStockIdFull(StockId);

            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
