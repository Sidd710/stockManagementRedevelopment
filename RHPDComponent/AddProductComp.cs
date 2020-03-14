using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;

namespace RHPDComponent
{
   public class AddProductComp
    {
       public int InsertUserComp(AddProductEntity objentity)
       {
           try
           {
               int r;
               AddProductDalc objaddpro = new AddProductDalc();
               r = objaddpro.insertDalc(objentity);
               return r;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public DataTable GridDisplayComponent()
       {
           DataTable dt3;

           try
           {
               AddProductDalc objadduser = new AddProductDalc();
               dt3 = new DataTable();
               dt3 = objadduser.GriddisplayDALC();
               return dt3;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public DataTable GriddisplayDALCbyProductComponent(string productName)
       {
           DataTable dt3;

           try
           {
               AddProductDalc objadduser = new AddProductDalc();
               dt3 = new DataTable();
               dt3 = objadduser.GriddisplayDALCbyProduct(productName);
               return dt3;
           }
           catch (Exception)
           {

               throw;
           }
       }

       
     

       public int updatecomponent(AddProductEntity objentity)
       {
           int r;
           try
           {

               AddProductDalc objaddpro= new AddProductDalc();
               r=objaddpro.UpdateProDALC(objentity);
               return r;
           }
           catch (Exception)
           {

               throw;
           }
       }
       public void ActiveInactivate(AddProductEntity objentity)
       {

           try
           {

               AddProductDalc objaddpro = new AddProductDalc();
               objaddpro.UpdateproductDALCactive(objentity);

           }
           catch (Exception)
           {

               throw;
           }
       }

       public string getCode()
       {
           try
           {
               AddProductDalc objaddpro = new AddProductDalc();
               string code = objaddpro.generateProductcode();
               return code;
           }
           catch (Exception)
           {

               throw;
           }
       }
       public void UpdateQuantity(int ProductID, int Quantity)
       {
           try
           {
                AddProductDalc objcategorytype = new AddProductDalc();
                objcategorytype.UpdateQuantity(ProductID, Quantity);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataTable getrecord()
       {
           try
           {
               DataTable dt;
               AddProductDalc objcategorytype = new AddProductDalc();
               dt = objcategorytype.DropdowndisplayCategoryNameDALC();
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }

       #region Stockout Monitoring Screen

       public DataTable getStockOutMain(int quarterId, int typeid, int yearvalue)
       {
           try
           {
               DataTable dt;
               AddProductDalc objcategorytype = new AddProductDalc();
               dt = objcategorytype.getStockOutMainData(quarterId, typeid, yearvalue);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public DataTable getStockOutDepots(int quarterId, int depotId, bool IsParent, bool NewDepot, int typeid, int yearvalue, string typeName)
       {
           try
           {
               DataTable dt;
               AddProductDalc objcategorytype = new AddProductDalc();
               dt = objcategorytype.getStockOutDepotsData(quarterId, depotId, IsParent, NewDepot, typeid, yearvalue, typeName);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public int addUpdateStockOutMain(int quarterId, int productId, int depotId, int userId, decimal totalIDT, bool IDTUpdate, int typeid, int yearvalue)
       {
           try
           {
               int retrunVal = 0;
               AddProductDalc objcategorytype = new AddProductDalc();
               retrunVal = objcategorytype.addUpdateStockOutMainData(quarterId, productId, depotId, userId, totalIDT, IDTUpdate, typeid, yearvalue);
               return retrunVal;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public DataTable getQuarters(int yearvalue)
       {
           try
           {
               DataTable dt;
               AddProductDalc objcategorytype = new AddProductDalc();
               dt = objcategorytype.getQuarters(yearvalue);
               return dt;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataTable getProducts(int QuarterId, int typeid, int yearvalue)
       {
           try
           {
               DataTable dt;
               AddProductDalc obj = new AddProductDalc();
               dt = obj.getProducts(QuarterId, typeid, yearvalue);
               return dt;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int StockOutMain_Product_Add(int QuarterId, int ProductId, int UserId, int typeid, int yearvalue)
       {
           try
           {
               int retrunVal = 0;
               AddProductDalc objcategorytype = new AddProductDalc();
               retrunVal = objcategorytype.StockOutMain_Product_Add(QuarterId, ProductId, UserId, typeid, yearvalue);
               return retrunVal;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public int StockOutMain_QuarterData_AutoAdd(int QuarterId, int UserId)
       {
           try
           {
               int retrunVal = 0;
               AddProductDalc objcategorytype = new AddProductDalc();
               retrunVal = objcategorytype.StockOutMain_QuarterData_AutoAdd(QuarterId, UserId);
               return retrunVal;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion
    }
}
