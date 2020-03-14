using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using RHPDEntity;
using System.Data;
using StarMethods;

namespace RHPDDalc
{
    public class AddDepuDalc
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        AddDepuEntity objadddepu = new AddDepuEntity();


        public int insertdalc(AddDepuEntity objentity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[15] = new SqlParameter("@AWS", objentity.AWS);
                param[14] = new SqlParameter("@ICT", objentity.ICT);
                param[13] = new SqlParameter("@IDT", objentity.IDT);
                param[12] = new SqlParameter("@UnitName", objentity.UnitName);
                param[0] = new SqlParameter("@Depu_name", objentity.Depu_name);
                param[1] = new SqlParameter("@Depu_location", objentity.Depu_location);
                param[2] = new SqlParameter("@IsActive", objentity.Isactive);
                param[3] = new SqlParameter("@Output", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                param[4] = new SqlParameter("@Action", "Insert");
                param[5] = new SqlParameter("@Depot_Code", objentity.Depot_code);
                param[6] = new SqlParameter("@IsParent", objentity.Isparent);
                param[7] = new SqlParameter("@AddedBy", objentity.Addedby);
                param[8] = new SqlParameter("@status", objentity.Status);

               // param[9] = new SqlParameter("@CommandId", objentity.CommandId);
                param[10] = new SqlParameter("@FormationId", objentity.FormationId);
                param[11] = new SqlParameter("@Corp", objentity.Corp);
                param[9] = new SqlParameter("@DepotNo", objentity.DepotNo);
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spDepu", param);
                r = Convert.ToInt32(param[3].Value);
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
                param[0] = new SqlParameter("@Action", "select");
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spDepu", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet selectDATA(string action, int id)
        {
            try
            {
                DataSet dt = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action",action);
                param[1] = new SqlParameter("@Depu_Id", id);
                dt = StarHelper.ExecuteDataSet(con, CommandType.StoredProcedure, "spDepu", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Int32 UpdateProductCAteDALC(AddDepuEntity objAdminEntity)
        {
            Int32 r=0;
            try
            {
                SqlParameter[] parm = new SqlParameter[16];
                parm[15] = new SqlParameter("@AWS", objAdminEntity.AWS);
                parm[14] = new SqlParameter("@ICT", objAdminEntity.ICT);
                parm[13] = new SqlParameter("@IDT", objAdminEntity.IDT);
                parm[12] = new SqlParameter("@UnitName", objAdminEntity.UnitName);
                parm[0] = new SqlParameter("@Action", "Update");
                parm[1] = new SqlParameter("@Depu_name", objAdminEntity.Depu_name);
                parm[2] = new SqlParameter("@Depu_location", objAdminEntity.Depu_location);
                parm[3] = new SqlParameter("@Depu_Id", objAdminEntity.Depu_id);
                parm[4] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
                parm[5] = new SqlParameter("@IsParent", objAdminEntity.Isparent);
                parm[6] = new SqlParameter("@ModifiedBy", objAdminEntity.Modificationby);
                parm[7] = new SqlParameter("@Output", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                parm[8] = new SqlParameter("@status", objAdminEntity.Status);
             //   parm[9] = new SqlParameter("@CommandId", objAdminEntity.CommandId);
                parm[10] = new SqlParameter("@FormationId", objAdminEntity.FormationId);
                parm[11] = new SqlParameter("@Corp", objAdminEntity.Corp);
                parm[9] = new SqlParameter("@DepotNo", objAdminEntity.DepotNo);
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spDepu", parm);
                r = Convert.ToInt32(parm[7].Value);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateProductCAteDALCactive(AddDepuEntity objAdminEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "updateactive");
                parm[1] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
                parm[2] = new SqlParameter("@Depu_Id", objAdminEntity.Depu_id);

                // parm[4] = new SqlParameter("@ImageUrl", objAdminEntity.ImageUrl);
                //  parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spDepu", parm);

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
            string str = "select Depu_ID from depumaster where Depu_ID=(select max(Depu_ID) from  depumaster)";
            dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
            if (dt.Rows.Count > 0)
            {
                int BID = Convert.ToInt32(dt.Rows[0]["Depu_ID"].ToString());
                BID++;

                bCOde = "DM-" + BID.ToString();

            }
            else
            {
                bCOde = "DM-1";
            }
            return bCOde;



        }


        public void removeParent()
        {
            try
            {
               
               // string str = "update depumaster set isparent=0";
               // StarHelper.ExecuteNonQuery(con, CommandType.Text, str);

                SqlParameter[] parm = new SqlParameter[1];
                parm[0] = new SqlParameter("@Action", "removeParent");               

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spDepu", parm);
            }
            catch (Exception)
            {

                throw;
            }




        }

        public bool checkparentid()
        {
            try
            {


                DataTable dt = new DataTable();
                string str = "select isparent from DepuMaster where isparent='true' and IsActive='true' ";
                dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
                if (dt.Rows.Count > 0)
                {
                    string BID = dt.Rows[0]["IsParent"].ToString();

                    if (BID.ToLower() == "true")
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {

                throw;
            }




        }


    }
}
