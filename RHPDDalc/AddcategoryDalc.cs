using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using RHPDEntity;
using System.Data.SqlClient;
using StarMethods;
using System.Data;
using System.Configuration;


namespace RHPDDalc
{
  public  class AddcategoryDalc
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
    
      public int insertdalc(AddCategoryEntity objentity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Type", objentity.Category_name);
                param[1] = new SqlParameter("@Description", objentity.Category_desc);
                param[2] = new SqlParameter("@IsActive", objentity.Isactive);
                param[3] = new SqlParameter("@Output", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                param[4] = new SqlParameter("@Action", "Insert");
                param[5] = new SqlParameter("@AddedBy", objentity.Addedby);
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spcategorytype", param);
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
              param[0] = new SqlParameter("@Action", "Griddisplay");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spcategorytype", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public Int32  UpdateProductCAteDALC(AddCategoryEntity objAdminEntity)
      {
          int r = 0;
          try
          {
              SqlParameter[] parm = new SqlParameter[7];
              parm[0] = new SqlParameter("@Action", "Update");
              parm[1] = new SqlParameter("@Type", objAdminEntity.Category_name);
              parm[2] = new SqlParameter("@Description", objAdminEntity.Category_desc);
              parm[3] = new SqlParameter("@ID", objAdminEntity.Id);
              parm[4] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
              parm[5] = new SqlParameter("@Output", SqlDbType.Int);
              parm[5].Direction = ParameterDirection.Output;
              parm[6] = new SqlParameter("@ModifiedBy", objAdminEntity.Modificationby);
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spcategorytype", parm);
              r = Convert.ToInt32(parm[5].Value);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public void UpdateCAteDALCactiveinactive(AddCategoryEntity objAdminEntity)
      {
          try
          {
              SqlParameter[] parm = new SqlParameter[3];
              parm[0] = new SqlParameter("@Action", "updateactive");
              parm[1] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
              parm[2] = new SqlParameter("@ID", objAdminEntity.Id);

              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spcategorytype", parm);

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
              param[0] = new SqlParameter("@Action", "DropDisplay");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spcategorymaster", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public int insertDalc(CategoryMasterEntity objentity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[9];
              param[0] = new SqlParameter("@Category_name", objentity.Category_name);
              param[1] = new SqlParameter("@Category_Desc", objentity.Categorydesc);
              param[2] = new SqlParameter("@IsActive", objentity.Isactive);
              param[5] = new SqlParameter("@Category_TypeId", objentity.Category_typeid);
              param[3] = new SqlParameter("@Output", SqlDbType.Int);
              param[3].Direction = ParameterDirection.Output;
              param[4] = new SqlParameter("@Action", "Insert");
              param[6] = new SqlParameter("@Category_Code", objentity.Category_code);
              param[7] = new SqlParameter("@ParentCategory_Id", objentity.Parentcategory_id);
              param[8] = new SqlParameter("@AddedBy", objentity.Addedby);
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spcategorymaster", param);
              r = Convert.ToInt32(param[3].Value);
              return r;

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
          string str = "select ID from CategoryMaster where ID=(select max(id) from  categorymaster)";
          dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
          if (dt.Rows.Count > 0)
          {
              int BID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
              BID++;

              bCOde = "CM-" + BID.ToString();

          }
          else
          {
              bCOde = "CM-1";
          }
          return bCOde;



      }

      public DataTable DropdowndisplayparentcategoryDALC()
      {
          try
          {
              DataTable dt = new DataTable();

              string str = "  select * from categorymaster where IsActive=1";
              dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
              //SqlParameter[] param = new SqlParameter[1];
              //param[0] = new SqlParameter("@Action", "DropDisplay");
              //dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spManageStock", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public DataTable GriddisplayCategoryMasterDALC()
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Action", "Griddisplay");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spcategorymaster", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public int UpdateCategorymasterDALC(CategoryMasterEntity objAdminEntity)
      {
          int r = 0;
          try
          {
              SqlParameter[] parm = new SqlParameter[9];
              parm[0] = new SqlParameter("@Action", "Update");
              parm[1] = new SqlParameter("@Category_Name", objAdminEntity.Category_name);
              parm[2] = new SqlParameter("@Category_Desc", objAdminEntity.Categorydesc);
              parm[3] = new SqlParameter("@ID", objAdminEntity.Id);
              parm[4] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
              parm[5] = new SqlParameter("@Category_TypeId", objAdminEntity.Category_typeid);
              parm[6] = new SqlParameter("@ParentCategory_Id", objAdminEntity.Parentcategory_id);
              parm[7] = new SqlParameter("@ModifiedBy", objAdminEntity.Modificationby);
              parm[8] = new SqlParameter("@Output", SqlDbType.Int);
              parm[8].Direction = ParameterDirection.Output;
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spcategorymaster", parm);
              r = Convert.ToInt32(parm[8].Value);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public void UpdateMasterCAtDALCactiveinactive(CategoryMasterEntity objAdminEntity)
      {
          try
          {
              SqlParameter[] parm = new SqlParameter[3];
              parm[0] = new SqlParameter("@Action", "updateactive");
              parm[1] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
              parm[2] = new SqlParameter("@ID", objAdminEntity.Id);

              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spcategorymaster", parm);

          }
          catch (Exception)
          {

              throw;
          }
      }
    }
}
