using StarMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using RHPDEntity;

namespace RHPDDalc
{
   public class StockTransferDalc
    {
       SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        public void InsertDalc(RHPDEntity.StockTransferEntity objStcktransfrEntity)
        {
            try
            {
                //int r = 0;
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@Action", objStcktransfrEntity.Action);
                //param[0] = new SqlParameter("@ImageName", objentity.Imagename);
                param[1] = new SqlParameter("@DepuMasterId", objStcktransfrEntity.DepuMasterID1);
                param[2] = new SqlParameter("@IsUnit", objStcktransfrEntity.IsUnit1);
                param[3] = new SqlParameter("@UnitMasterId", objStcktransfrEntity.UnitMasterID1);
                param[4] = new SqlParameter("@TypeOfOrderId", objStcktransfrEntity.TypeOfOrderId);
                param[5] = new SqlParameter("@IndentId", objStcktransfrEntity.IndentId);
                param[6] = new SqlParameter("@XMLData", SqlDbType.Xml);
                param[6].Value = objStcktransfrEntity.Xmldata;
                param[7] = new SqlParameter("@IsActive", objStcktransfrEntity.IsActive1);
                param[8] = new SqlParameter("@AddedBy", objStcktransfrEntity.AddedBy1);
              //  param[6] = new SqlParameter("@CategoryMasterId", objStcktransfrEntity.CategoryMasterID1);
                //param[7] = new SqlParameter("@Output", SqlDbType.Int);
               // param[7].Direction = ParameterDirection.Output;
                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
                //Convert.ToInt32(param[7].Value);
                //return r;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void updatedalc(RHPDEntity.StockTransferEntity objStcktransfrEntity)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Action", objStcktransfrEntity.Action);
                param[1] = new SqlParameter("@ProductMasterId", objStcktransfrEntity.ProductMasterID1);
                param[2] = new SqlParameter("@BID", objStcktransfrEntity.BatchMasterId);
                param[3] = new SqlParameter("@IssueQty", objStcktransfrEntity.IssueQty);
                param[4] = new SqlParameter("@StockQty", objStcktransfrEntity.StockQty);
                param[5] = new SqlParameter("@ModifiedBy", objStcktransfrEntity.ModifiedBy);
                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertStockByDepoDalc(RHPDEntity.StockTransferEntity objStcktransfrEntity)
        {
            try
            {
                //int r = 0;
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@Action", "InsertStockTransferToDepo");
                //param[0] = new SqlParameter("@ImageName", objentity.Imagename);
                param[1] = new SqlParameter("@DepuMasterId", objStcktransfrEntity.DepuMasterID1);

                param[2] = new SqlParameter("@CategoryMasterId", objStcktransfrEntity.CategoryMasterID1);
                param[3] = new SqlParameter("@ProductMasterId", objStcktransfrEntity.ProductMasterID1);
                param[4] = new SqlParameter("@QtyIssued", objStcktransfrEntity.QtyIssued1);
                param[5] = new SqlParameter("@AddedBy", objStcktransfrEntity.AddedBy1);
                param[6] = new SqlParameter("@CategoryTypeID", objStcktransfrEntity.CategoryTypeId1);
                //param[7] = new SqlParameter("@Output", SqlDbType.Int);
                //param[7].Direction = ParameterDirection.Output;
                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
                //Convert.ToInt32(param[7].Value);
                //return r;

            }
            catch (Exception)
            {

                throw;
            }
        }
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


        public DataTable Getstockquantity(StockTransferEntity objentity)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "checkquantity");
                param[1] = new SqlParameter("@Product_ID", objentity.Productid);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
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

        public DataTable DropdowndisplayCategoryDalc(int did)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "SelectCategory");
                param[1] = new SqlParameter("@Category_TypeId", did);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable DropdowndisplayProductCategoryDalc(int DID)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "GetProductByID");
                param[1] = new SqlParameter("@Category_Id", DID);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable DropdowndisplayCategory()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "GetCategoryByType");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_StockTransfer", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}
