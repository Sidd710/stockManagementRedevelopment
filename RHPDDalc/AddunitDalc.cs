using StarMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using RHPDEntity;

namespace RHPDDalc
{
   public class AddunitDalc
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        AddunitEntity Objunit = new AddunitEntity();
        public DataTable DropdowndisplayDALC()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "DropDisplay");
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUnit", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int insertdalc(AddunitEntity objentity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[4] = new SqlParameter("@Action", "Insert");
                param[0] = new SqlParameter("@Depu_Id", objentity.Depu_id);
                param[1] = new SqlParameter("@Unit_Name", objentity.Unit_name);        
                param[2] = new SqlParameter("@Unit_Desc", objentity.Unit_desc);
                param[3] = new SqlParameter("@Unit_Code", objentity.Unit_code);  
                param[5] = new SqlParameter("@IsActive", objentity.Isactive);
                param[6] = new SqlParameter("@Output", SqlDbType.Int);
                param[6].Direction = ParameterDirection.Output;
                param[7] = new SqlParameter("@Command", objentity.Command);
                param[8] = new SqlParameter("@Formation", objentity.Formation);
                param[9] = new SqlParameter("@UnitType", objentity.UnitType);


                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUnit", param);
                r = Convert.ToInt32(param[6].Value);
                return r;
            }



            catch (Exception)
            {

                throw;
            }
        }


        public DataTable GriddisplayDALC()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "griddisplay");
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUnit", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateUnitCAteDALC(AddunitEntity objAdminEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[8];
                parm[0] = new SqlParameter("@Action", "Update");
                parm[1] = new SqlParameter("@Unit_name", objAdminEntity.Unit_name);
            
                parm[2] = new SqlParameter("@Unit_desc", objAdminEntity.Unit_desc);
                parm[3] = new SqlParameter("@Unit_Id", objAdminEntity.Unit_id);
                parm[4] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
                parm[5] = new SqlParameter("@Command", objAdminEntity.Command);
                parm[6] = new SqlParameter("@Formation", objAdminEntity.Formation);
                parm[7] = new SqlParameter("@UnitType", objAdminEntity.UnitType);
                // parm[4] = new SqlParameter("@ImageUrl", objAdminEntity.ImageUrl);
                //  parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUnit", parm);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateUnitDALCactive(AddunitEntity objAdminEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "updateactive");
                parm[1] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
                parm[2] = new SqlParameter("@Unit_id", objAdminEntity.Unit_id);

                // parm[4] = new SqlParameter("@ImageUrl", objAdminEntity.ImageUrl);
                //  parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUnit", parm);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string generateProductcode()
        {
            string bCOde;
            DataTable dt = new DataTable();
            string str = "select Unit_Id from unitmaster where Unit_Id=(select max(Unit_Id) from  unitmaster)";
            dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
            if (dt.Rows.Count > 0)
            {
                int BID = Convert.ToInt32(dt.Rows[0]["Unit_Id"].ToString());
                BID++;

                bCOde = "UM-" + BID.ToString();

            }
            else
            {
                bCOde = "UM-1";
            }
            return bCOde;



        }

        public DataTable UnitCheckExist(string st, int depuid)
        {
            try
            {
                DataTable dt = new DataTable();
               // SqlParameter[] param = new SqlParameter[2];
                //param[0] = new SqlParameter("@Action", "UnitCheckExist");
                //param[1] = new SqlParameter("@Unit_name", st);
                 // dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUnitById",);
                string str = "select * from UnitMaster WHERE Unit_Name= '" + st.Trim() + "' and Depu_Id=" + depuid + "";
                dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable updUnitCheckExist(string st, int depuid,int unitid)
        {
            try
            {
                DataTable dt = new DataTable();
               // SqlParameter[] param = new SqlParameter[2];
                //param[0] = new SqlParameter("@Action", "UnitCheckExist");
                //param[1] = new SqlParameter("@Unit_name", st);
                 // dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUnitById",);
                string str = "select * from UnitMaster WHERE Unit_Name= '" + st.Trim() + "' and Depu_Id=" + depuid + " and Unit_Id!= " + unitid + " ";
                dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
