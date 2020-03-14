using RHPDEntity;
using StarMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using System.Text;
using Microsoft;

namespace RHPDDalc
{
   public class IndnetDalc
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        public int InsertDalc(RHPDEntity.IndentEntity objIndentEntity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Action", "insert");
                param[1] = new SqlParameter("@IndentName", objIndentEntity.IndentName);
                param[2] = new SqlParameter("@AddedBy", objIndentEntity.AddedBy);
                r = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "SPINDENT", param));
                return r;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateIndentDALC(RHPDEntity.IndentEntity objIndentEntity)
        {
            int r = 0;
            try
            {
                //int r = 0;
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Action", objIndentEntity.Action);
                //param[0] = new SqlParameter("@ImageName", objentity.Imagename);
                param[1] = new SqlParameter("@IndentName", objIndentEntity.IndentName);
                param[2] = new SqlParameter("@ModifiedBy", objIndentEntity.ModifiedBy);
                param[3] = new SqlParameter("@ModifiedOn", objIndentEntity.ModifiedOn);
                param[4] = new SqlParameter("@IsActive", objIndentEntity.IsActive);
                //  param[6] = new SqlParameter("@CategoryMasterId", objStcktransfrEntity.CategoryMasterID1);
                r = Convert.ToInt32(SqlHelper.ExecuteScalar(conn, CommandType.StoredProcedure, "SPINDENT", param));
                return r;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateIndentDALCinactive(IndentEntity objIndentEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", objIndentEntity.Action);
                parm[1] = new SqlParameter("@IsActive", objIndentEntity.IsActive);
                parm[2] = new SqlParameter("@ID", objIndentEntity.Id);

                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "SPINDENT", parm);

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

                //string str = "  select * from IDT where IsActive=1";
                //dt = StarHelper.ExecuteDataTable(conn, CommandType.Text, str);
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectAll");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectIssueVoucherId()
        {
            try
            {
                DataTable dt = new DataTable();

                //string str = "  select * from IDT where IsActive=1";
                //dt = StarHelper.ExecuteDataTable(conn, CommandType.Text, str);
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectIssueVoucherId");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectGateInoutList()
        {
            try
            {
                DataTable dt = new DataTable();

                //string str = "  select * from IDT where IsActive=1";
                //dt = StarHelper.ExecuteDataTable(conn, CommandType.Text, str);
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectGateInoutList");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetResultIndent()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "Select");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable checkIsapproved(int indetntid)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "selectid");
                param[1] = new SqlParameter("@Id", indetntid);

                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }   
     


        public DataTable GetResultIndentdetails(int indetntid)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "Viewdetails");
                param[1] = new SqlParameter("@indentid", indetntid);

                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "SPINDENT", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateIndent(IndentEntity objEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "UpdateindentApprove");
                parm[1] = new SqlParameter("@IsApproved", objEntity.IsApproved);
                parm[2] = new SqlParameter("@id", objEntity.Id);    
        

                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "SPINDENT", parm);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
