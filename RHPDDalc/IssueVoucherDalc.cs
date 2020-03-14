using Microsoft.ApplicationBlocks.Data;
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
  public  class IssueVoucherDalc
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        public int insertdalc(IssueVocuherEntity objIssueVoucherEntity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@Action", objIssueVoucherEntity.Action);
                param[1] = new SqlParameter("@IdtId", objIssueVoucherEntity.IdtId);
                param[2] = new SqlParameter("@ToDepuId", objIssueVoucherEntity.ToDepuId);
                param[3] = new SqlParameter("@ToUnitId", objIssueVoucherEntity.ToUnitId);
                param[4] = new SqlParameter("@VechileNo", objIssueVoucherEntity.VechileNo);
                param[5] = new SqlParameter("@Authority", objIssueVoucherEntity.Authority);
                param[6] = new SqlParameter("@Through", objIssueVoucherEntity.Through);
                param[7] = new SqlParameter("@IsActive", objIssueVoucherEntity.IsActive);
                param[8] = new SqlParameter("@AddedBy", objIssueVoucherEntity.AddedBy);
                param[9] = new SqlParameter("@ModifiedBy", objIssueVoucherEntity.ModifiedBy);
                param[10] = new SqlParameter("@Output",SqlDbType.Int);
                param[10].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IssueVoucher", param);
                r = Convert.ToInt32(param[10].Value);
                return r;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public int UpdateIssuevoucherDALC(IssueVocuherEntity objIssueVoucherEntity)
        {
            int r = 0;
            try
            {
                //int r = 0;
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@Action", objIssueVoucherEntity.Action);
                param[1] = new SqlParameter("@IdtId", objIssueVoucherEntity.IdtId);
                param[2] = new SqlParameter("@ToDepuId", objIssueVoucherEntity.ToDepuId);
                param[3] = new SqlParameter("@ToUnitId", objIssueVoucherEntity.ToUnitId);
                param[4] = new SqlParameter("@VechileNo", objIssueVoucherEntity.VechileNo);
                param[5] = new SqlParameter("@Authority", objIssueVoucherEntity.Authority);
                param[6] = new SqlParameter("@Through", objIssueVoucherEntity.Through);
                param[7] = new SqlParameter("@IsActive", objIssueVoucherEntity.IsActive);
                param[8] = new SqlParameter("@AddedBy", objIssueVoucherEntity.AddedBy);
                //  param[6] = new SqlParameter("@CategoryMasterId", objStcktransfrEntity.CategoryMasterID1);
                r = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IssueVoucher", param));
                return r;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InActiveIssueVoucher(IssueVocuherEntity objIssueVoucherEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", objIssueVoucherEntity.Action);
                parm[1] = new SqlParameter("@IsActive", objIssueVoucherEntity.IsActive);
                parm[2] = new SqlParameter("@Id", objIssueVoucherEntity.Id);

                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_IssueVoucher", parm);

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
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_IssueVoucher", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectByID(int IssueVoucherid)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "SelectById");
                param[1] = new SqlParameter("@Id", IssueVoucherid);

                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_IssueVoucher", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable SelectStcktransfrIndentWise(IssueVocuherEntity objIssueVoucherEntity)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "SelectStockTransferDetailIndentWise");
                param[1] = new SqlParameter("@IdtId", objIssueVoucherEntity.IdtId);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_IssueVoucher", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable SelectIssuedVoucherfromto(IssueVocuherEntity objIssueVoucherEntity)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Action", objIssueVoucherEntity.Action);
                param[1] = new SqlParameter("@from", objIssueVoucherEntity.Addedon);
                param[2] = new SqlParameter("@to", objIssueVoucherEntity.Modifiedon);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_IssueVoucher", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataSet SelectIssuedetailview(IssueVocuherEntity objIssueVoucherEntity)
        {
            try
            {
                DataSet dt = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", objIssueVoucherEntity.Action);
                param[1] = new SqlParameter("@Id", objIssueVoucherEntity.Id);
                dt = StarHelper.ExecuteDataSet(conn, CommandType.StoredProcedure, "sp_IssueVoucher", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
