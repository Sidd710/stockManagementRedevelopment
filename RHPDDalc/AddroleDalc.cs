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
    public class DeptDalc
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();      

        public int Insert(DeptMasterEntity objentity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@Action", "Insert");
                param[1] = new SqlParameter("@DeptCode", objentity.DeptCode);
                param[2] = new SqlParameter("@DeptName", objentity.DeptName);
                param[3] = new SqlParameter("@Description", objentity.Description);
                param[5] = new SqlParameter("@IsActive", objentity.IsActive);
                param[6] = new SqlParameter("@AddedBy", objentity.AddedBy);          
                param[4] = new SqlParameter("@Output", SqlDbType.Int);
                param[4].Direction = ParameterDirection.Output;
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spDepartment", param);
                r = Convert.ToInt32(param[4].Value);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(DeptMasterEntity objentity)
        {
            
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@Action", "Update");
                param[1] = new SqlParameter("@DeptCode", objentity.DeptCode);
                param[2] = new SqlParameter("@DeptName", objentity.DeptName);
                param[3] = new SqlParameter("@Description", objentity.Description);
                param[5] = new SqlParameter("@IsActive", objentity.IsActive);
                param[4] = new SqlParameter("@Modifiedby", objentity.Modifiedby);
                param[6] = new SqlParameter("@Id", objentity.Id);                                
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spDepartment", param);               
               
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
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spDepartment", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable SelectActive()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectActive");
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spDepartment", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string getDeptCode()
        {
            string dCOde;
            DataTable dt = new DataTable();
            string str = "select Id from DeptMaster where Id=(select max(Id) from  DeptMaster)";
            dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
            if (dt.Rows.Count > 0)
            {
                int BID = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                BID++;

                dCOde = "DP-" + BID.ToString();

            }
            else
            {
                dCOde = "DP-1";
            }
            return dCOde;



        }
        public int getDeptByRoleID(int roleID)
        {
            int deptID=0;
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Action", "SelectByRoleID");
            param[1] = new SqlParameter("@RoleID", roleID);
        dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spDepartment", param);
        
        if (dt.Rows.Count > 0)
        {
            deptID= Convert.ToInt32(dt.Rows[0]["Id"].ToString());
           

        }          
            
        return deptID;
          



        }


        public DataTable CheckDept(string st)
        {
            try
            {
                DataTable dt = new DataTable();
                // SqlParameter[] param = new SqlParameter[2];
                //param[0] = new SqlParameter("@Action", "UnitCheckExist");
                //param[1] = new SqlParameter("@Unit_name", st);
                // dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUnitById",);
                string str = "select * from DeptMaster WHERE DeptName= '" + st.Trim() + "'";
                dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable updCheckDept(string st,int id)
        {
            try
            {
                DataTable dt = new DataTable();
                // SqlParameter[] param = new SqlParameter[2];
                //param[0] = new SqlParameter("@Action", "UnitCheckExist");
                //param[1] = new SqlParameter("@Unit_name", st);
                // dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUnitById",);
                string str = "select * from DeptMaster WHERE DeptName= '" + st.Trim() + "' and id!="+id+"  ";
                dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
   public class AddroleDalc
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        AddRoleEntity objrole = new AddRoleEntity();
     

       public int insertdalc(AddRoleEntity objentity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param=new SqlParameter[9];
                param[0]=new SqlParameter("@Action","Insert");
                param[1] = new SqlParameter("@Role_code", objentity.Role_code);
                param[2]=new SqlParameter("@Role_desc",objentity.Role_desc);
                param[3] = new SqlParameter("@IsActive", objentity.Isactive);
                param[5] = new SqlParameter("@AddedBy", objentity.AddedBy);
                param[6] = new SqlParameter("@DeptId", objentity.DeptId);
                param[7] = new SqlParameter("@Rank", objentity.Rank);
                param[8] = new SqlParameter("@Role", objentity.Role);
                param[4] = new SqlParameter("@Output", SqlDbType.Int);
                param[4].Direction = ParameterDirection.Output;
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spRole", param);
                r = Convert.ToInt32(param[4].Value);
                return r;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       public DataTable GetRoleByDeptID(int dID)
       {
           try
           {
               DataTable dt = new DataTable();
               string str = "select RoleCode=Role+'('+Role_Code+')', * from RoleMaster where IsActive=1 and DeptId="+dID;
               dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
               return dt;
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
               dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spRole", param);
               return dt;
           }
           catch (Exception)
           {
               
               throw;
           }

       }
       public void UpdateRoleDALC(AddRoleEntity objentity)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@Action", "Update");
                param[1] = new SqlParameter("@Role_code", objentity.Role_code);
                param[2] = new SqlParameter("@Role_desc", objentity.Role_desc);
                param[3] = new SqlParameter("@IsActive", objentity.Isactive);
                param[4] = new SqlParameter("@Role_id", objentity.Role_id);
                param[5] = new SqlParameter("@Role", objentity.Role);
                param[6] = new SqlParameter("@Rank", objentity.Rank);
                param[7] = new SqlParameter("@DeptId", objentity.DeptId);
                param[8] = new SqlParameter("@ModifiedBy", objentity.ModifiedBy);
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spRole", param);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateRoleDALCactive(AddRoleEntity objAdminEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "updateactive");
                parm[1] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
                parm[2] = new SqlParameter("@Role_id", objAdminEntity.Role_id);

              
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spRole", parm);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string getRoleCode()
        {
            string rCOde;
            DataTable dt = new DataTable();
            string str = "select Role_Id from RoleMaster where Role_Id=(select max(Role_Id) from  RoleMaster)";
            dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
            if (dt.Rows.Count > 0)
            {
                int BID = Convert.ToInt32(dt.Rows[0]["Role_Id"].ToString());
                BID++;

                rCOde = "RC-" + BID.ToString();

            }
            else
            {
                rCOde = "RC-1";
            }
            return rCOde;



        }


       public DataTable checkRolename( string st)
        {
            try
            {
                DataTable dt = new DataTable();
                string str = "select * from rolemaster where role='" + st +"'";
                dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
          
        }
       public DataTable updcheckRolename(string st,int id)
       {
           try
           {
               DataTable dt = new DataTable();
               string str = "select * from rolemaster where role='" + st + "' and Role_ID!= "+id+" ";
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
