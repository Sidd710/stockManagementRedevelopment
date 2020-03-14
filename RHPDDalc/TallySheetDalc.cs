using RHPDEntity;
using StarMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RHPDDalc
{
   public class TallySheetDalc
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        public DataTable DropdowndisplayDALC()
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[1];
               param[0] = new SqlParameter("@Action", "SelectDepot");
               dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }


        public DataTable DropdowndisplayByUnitDALC()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectUnit");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertIntoTallySheet(TallySheetEntity objTallyEntity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@DepuIdFrom", objTallyEntity.DepuIdFrom);
                param[1] = new SqlParameter("@ToDepuId", objTallyEntity.ToDepuId);
                param[2] = new SqlParameter("@Authority", objTallyEntity.Authority);
                param[3] = new SqlParameter("@Output", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                param[4] = new SqlParameter("@Action", "InsertIntoTallySheet");
                param[5] = new SqlParameter("@Through", objTallyEntity.Through);
                param[6] = new SqlParameter("@VehBaNo", objTallyEntity.VehBaNo);
                param[7] = new SqlParameter("@ToUnitId", objTallyEntity.ToUnitId);
                param[8] = new SqlParameter("@AddedBy", objTallyEntity.AddedBy);
                param[9] = new SqlParameter("@ModifiedBy", objTallyEntity.ModifiedBy);
                param[10] = new SqlParameter("@IsActive", objTallyEntity.IsActive);
                param[11] = new SqlParameter("@IdtId", objTallyEntity.IdtId);

                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_ManageTallySheet", param);
                r = Convert.ToInt32(param[3].Value);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }

      
        public DataTable GridDisplayfortally()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "GridDisplayfortally");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GridDisplayOftally(TallySheetEntity objTallyEntity)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "Getlist");
                param[1] = new SqlParameter("@idt", objTallyEntity.Id);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable GetUnitByDID(int DID)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "GetUnitByDID");
                param[1] = new SqlParameter("@Depu_Id", DID);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetIdtRecord(int IDT)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "Getlist");
                param[1] = new SqlParameter("@idt", IDT);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectTallyfromto(TallySheetEntity objentity)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Action", objentity.Action);
                param[1] = new SqlParameter("@from", objentity.Addedon);
                param[2] = new SqlParameter("@to", objentity.ModifiedOn);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_ManageTallySheet", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet selecttallydetailview(TallySheetEntity objentity)
        {
            try
            {
                DataSet dt = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", objentity.Action);
                param[1] = new SqlParameter("@Id", objentity.Id);
                dt = StarHelper.ExecuteDataSet(conn, CommandType.StoredProcedure, "sp_ManageTallySheet", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
