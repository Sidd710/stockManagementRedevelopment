using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using RHPDEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using StarMethods;

namespace RHPDDalc
{
  public  class AddProductDalc
    {
      AddProductEntity objaddpro = new AddProductEntity();
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
       SqlCommand cmd = new SqlCommand();
      public int insertDalc(AddProductEntity objentity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param=new SqlParameter[15];
              param[0] = new SqlParameter("@Action", "Insert");
              param[1] = new SqlParameter("@Product_name", objentity.Product_name);
              param[2] = new SqlParameter("@Product_desc", objentity.Product_desc);
              param[3] = new SqlParameter("@Admin_remarks", objentity.Admin_remarks);
              param[4] = new SqlParameter("@Product_code", objentity.Product_code);
              param[5] = new SqlParameter("@Product_cost", objentity.Product_cost);             
              param[6] = new SqlParameter("@IsActive", objentity.Isactive);
              param[7] = new SqlParameter("@Output", SqlDbType.Int);
              param[7].Direction = ParameterDirection.Output;
              param[8] = new SqlParameter("@Short_product_desc", objentity.Short_product_desc);
              param[9] = new SqlParameter("@Category_Id", objentity.Categoryid);
              param[10] = new SqlParameter("@AddedBy", objentity.Addedby);
              param[11] = new SqlParameter("@Cat", objentity.Cat);
              param[12] = new SqlParameter("@ProductUnit", objentity.Productunit);
              param[13] = new SqlParameter("@StockQty", objentity.StockQty);
              param[14] = new SqlParameter("@GSServe", objentity.GSServe);

              
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spProduct", param);
              r = Convert.ToInt32(param[7].Value);
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
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spProduct", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }

      }
      
      public DataTable GriddisplayDALCbyProduct(string productname)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@QuarterId", productname);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "usp_StockOutMain_GetDatabyQuarter", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }

      }

       



      public int UpdateProDALC(AddProductEntity objentity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[16];
              param[0] = new SqlParameter("@Action", "Update");
              param[1] = new SqlParameter("@Product_name", objentity.Product_name);
              param[2] = new SqlParameter("@Product_desc", objentity.Product_desc);
              param[3] = new SqlParameter("@Short_product_desc", objentity.Short_product_desc);
              param[4] = new SqlParameter("@Product_cost", objentity.Product_cost);
              param[5] = new SqlParameter("@Product_ID", objentity.Product_id);
              param[6] = new SqlParameter("@Admin_remarks", objentity.Admin_remarks);
              param[7] = new SqlParameter("@Isactive", objentity.Isactive);
              param[8] = new SqlParameter("@Output", SqlDbType.Int);
              param[8].Direction = ParameterDirection.Output;
              param[9] = new SqlParameter("@ModifiedBy", objentity.Modificationby);
              param[10] = new SqlParameter("@Category_Id", objentity.Categoryid);
              param[11] = new SqlParameter("@Product_code", objentity.Product_code);
              param[12] = new SqlParameter("@Cat", objentity.Cat);
              param[15] = new SqlParameter("@ProductUnit", objentity.Productunit);
              param[13] = new SqlParameter("@StockQty", objentity.StockQty);
              param[14] = new SqlParameter("@GSServe", objentity.GSServe);

              //  parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spProduct", param);
              r = Convert.ToInt32(param[8].Value);
              return r;

          }
          catch (Exception)
          {

              throw;
          }
      }


      public void UpdateproductDALCactive(AddProductEntity objAdminEntity)
      {
          try
          {
              SqlParameter[] parm = new SqlParameter[3];
              parm[0] = new SqlParameter("@Action", "updateactive");
              parm[1] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
              parm[2] = new SqlParameter("@Product_id", objAdminEntity.Product_id);

              // parm[4] = new SqlParameter("@ImageUrl", objAdminEntity.ImageUrl);
              //  parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spProduct", parm);

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
          string str = "select Product_id from ProductMaster where Product_id=(select max(Product_id) from  ProductMaster)";
          dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
          if (dt.Rows.Count > 0)
          {
              int BID = Convert.ToInt32(dt.Rows[0]["Product_id"].ToString());
              BID++;

              bCOde = "PC-" + BID.ToString();

          }
          else
          {
              bCOde = "PC-1";
          }
          return bCOde;



      }

      public void UpdateQuantity(int ProductID, int Quantity)
      {
          try
          {
               SqlParameter[] param = new SqlParameter[3];          
             
              param[0] = new SqlParameter("@Action", "UpdateQty");
              param[1] = new SqlParameter("@Product_ID", ProductID);
              param[2] = new SqlParameter("@StockQty", Quantity);
              StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spProduct", param);
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public DataTable DropdowndisplayCategoryNameDALC()
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[1];
              string str = "select * from CategoryMaster";
              dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
              //param[0] = new SqlParameter("@Action", "DropDisplay");
              //dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spProduct", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }


      #region Stockout Monitoring Screen

      public DataTable getQuarters(int yearvalue)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@yearvalue", yearvalue);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "usp_StockOutMain_Quarters_Get", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public DataTable getProducts(int QuarterId, int typeid, int yearvalue)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@QuarterId", QuarterId);
              param[1] = new SqlParameter("@TypeId", typeid);
              param[2] = new SqlParameter("@Yearvalue", yearvalue);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "usp_StockOutMain_Products_Get", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public int StockOutMain_Product_Add(int QuarterId, int ProductId, int UserId, int typeid, int yearvalue)
      {
          try
          {
              int retrunVal = 0;
              SqlParameter[] param = new SqlParameter[5];
              param[0] = new SqlParameter("@QuarterId", QuarterId);
              param[1] = new SqlParameter("@ProductId", ProductId);
              param[2] = new SqlParameter("@UserId", UserId);
              param[3] = new SqlParameter("@TypeId", typeid);
              param[4] = new SqlParameter("@Yearvalue", yearvalue);
              retrunVal = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "usp_StockOutMain_Product_Add", param);
              return retrunVal;
          }
          catch (Exception)
          {
              throw;
          }
      }

      public int StockOutMain_QuarterData_AutoAdd(int QuarterId, int UserId)
      {
          try
          {
              int retrunVal = 0;
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@QuarterId", QuarterId);
              param[1] = new SqlParameter("@UserId", UserId);
              retrunVal = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "usp_StockOutMain_QuarterData_AutoAdd", param);
              return retrunVal;
          }
          catch (Exception)
          {
              throw;
          }
      }

      public DataTable getStockOutMainData(int quarterId, int typeid, int yearvalue)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[3];
              param[0] = new SqlParameter("@QuarterId", quarterId);
              param[1] = new SqlParameter("@TypeId", typeid);
              param[2] = new SqlParameter("@Yearvalue", yearvalue);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "usp_StockOutMain_GetDatabyQuarter", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public DataTable getStockOutDepotsData(int quarterId, int depotId, bool IsParent, bool NewDepot, int typeid, int yearvalue,string type)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[7];
              param[0] = new SqlParameter("@QuarterId", quarterId);
              param[1] = new SqlParameter("@DepotId", depotId);
              param[2] = new SqlParameter("@IsParent", IsParent);
              param[3] = new SqlParameter("@NewDepot", NewDepot);
              param[4] = new SqlParameter("@Typeid", typeid);
              param[5] = new SqlParameter("@Yearvalue", yearvalue);
              param[6] = new SqlParameter("@type", type);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "usp_StockOutMain_GetDepots", param);
              return dt;
          }
          catch (Exception)
          {
              throw;
          }
      }

      public int addUpdateStockOutMainData(int quarterId, int productId, int depotId, int userId, decimal totalIDT, bool IDTUpdate, int typeid, int yearvalue)
      {
          try
          {
              int retrunVal = 0;
              SqlParameter[] param = new SqlParameter[8];
              param[0] = new SqlParameter("@QuarterId", quarterId);
              param[1] = new SqlParameter("@ProductId", productId);
              param[2] = new SqlParameter("@DepotId", depotId);
              param[3] = new SqlParameter("@UserId", userId);
              param[4] = new SqlParameter("@IDT", totalIDT);
              param[5] = new SqlParameter("@IDTUpdate", IDTUpdate);
              param[6] = new SqlParameter("@TypeId", typeid);
              param[7] = new SqlParameter("@Yearvalue", yearvalue);
              retrunVal = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "usp_StockOutMain_AddUpdate", param);
              return retrunVal;
          }
          catch (Exception)
          {
              throw;
          }
      }

      #endregion
    }
}
