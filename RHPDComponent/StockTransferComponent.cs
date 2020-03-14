using RHPDDalc;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RHPDComponent
{
  public  class StockTransferComponent
    {
      StockTransferDalc objStockDalc = new StockTransferDalc();
      public void InsertStockCompo(StockTransferEntity objStcktransfrEntity)
      {
          try
          {
             //int r;
             StockTransferDalc objStockDalc = new StockTransferDalc();
              objStockDalc.InsertDalc(objStcktransfrEntity);

              //return r;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public void updatedalc(StockTransferEntity objStcktransfrEntity)
      {
          try
          {
              //int r;
              StockTransferDalc objStockDalc = new StockTransferDalc();
              objStockDalc.updatedalc(objStcktransfrEntity);
              //return r;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public void InsertStockCompoByDepo(StockTransferEntity objStcktransfrEntity)
      {
          try
          {
              // int r;
              StockTransferDalc objStockDalc = new StockTransferDalc();
              objStockDalc.InsertStockByDepoDalc(objStcktransfrEntity);

              //return r;
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
              StockTransferDalc objcategorytype = new StockTransferDalc();
              dt = objcategorytype.DropdowndisplayDALC();
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
              DataTable dt;
              StockTransferDalc objcategorytype = new StockTransferDalc();
              dt = objcategorytype.Getstockquantity(objentity);
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
              DataTable dt;
              StockTransferDalc getdepot = new StockTransferDalc();
              dt = getdepot.GetUnitByDID(DID);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public DataTable getrecordCategory(int did)
      {
          try
          {
              DataTable dt;
              StockTransferDalc objcategorytype = new StockTransferDalc();
              dt = objcategorytype.DropdowndisplayCategoryDalc(did);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public DataTable GetProductByDID(int DID)
      {
          try
          {
              DataTable dt;
              StockTransferDalc getdepot = new StockTransferDalc();
              dt = getdepot.DropdowndisplayProductCategoryDalc(DID);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public DataTable getrecordCategorytype()
      {
          try
          {
              DataTable dt;
              StockTransferDalc objcategorytype = new StockTransferDalc();
              dt = objcategorytype.DropdowndisplayCategory();
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

    }
}
