using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;

namespace RHPDComponent
{
   public class TallySheetComponent
    {

       public DataTable getrecord()
       {
           try
           {
               DataTable dt;
               TallySheetDalc objcategorytype = new TallySheetDalc();
               dt = objcategorytype.DropdowndisplayDALC();
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }


       public DataTable getrecordbyUnit()
       {
           try
           {
               DataTable dt;
               TallySheetDalc objcategorytype = new TallySheetDalc();
               dt = objcategorytype.DropdowndisplayByUnitDALC();
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }


       public int InsertIntoTallySheet(TallySheetEntity objTallyEntity)
       {
           try
           {
               int r;
               TallySheetDalc objTallyDalc = new TallySheetDalc();

               r = objTallyDalc.InsertIntoTallySheet(objTallyEntity);
               return r;
           }
           catch (Exception)
           {

               throw;
           }
       }


     

       public DataTable GridDisplayfortally()
       {
           DataTable dt3;

           try
           {
               TallySheetDalc objTallyDalc = new TallySheetDalc();
               dt3 = new DataTable();
               dt3 = objTallyDalc.GridDisplayfortally();
               return dt3;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public DataTable GridDisplayOftally(TallySheetEntity objTallyEntity)
       {
           DataTable dt3;

           try
           {
               TallySheetDalc objTallyDalc = new TallySheetDalc();
               dt3 = new DataTable();
               dt3 = objTallyDalc.GridDisplayOftally(objTallyEntity);
               return dt3;
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
               TallySheetDalc getdepot = new TallySheetDalc();
               dt = getdepot.GetUnitByDID(DID);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
        //GetIdtDate
       /// <summary>
       /// Get the list of IDT Record
       /// </summary>
       /// <param name="DID"></param>
       /// <returns></returns>
       public DataTable GetIdtRecord(int DID)
       {
           try
           {
               DataTable dt;
               TallySheetDalc getdepot = new TallySheetDalc();
               dt = getdepot.GetIdtRecord(DID);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
       public DataTable SelectTallyfromto(TallySheetEntity objentity)
       {
           try
           {
               DataTable dt;
               TallySheetDalc getdepot = new TallySheetDalc();
               dt = getdepot.SelectTallyfromto(objentity);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
       public DataSet selecttallydetailview(TallySheetEntity objentity)
       {
           try
           {
               DataSet dt;
               TallySheetDalc getdepot = new TallySheetDalc();
               dt = getdepot.selecttallydetailview(objentity);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
    }
}
