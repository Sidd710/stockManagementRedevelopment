using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;


namespace RHPDComponent
{
   public class ESLIssueComponent
    {


       /// <summary>
       /// StatusDorpdown
       /// </summary>
       /// <returns></returns>
       /// 
         public DataTable SelectDropdownStatusComponent()
       {
     

           try
           {
               DataTable  dt = new DataTable();
               ESLIssueDALC objadduser = new ESLIssueDALC();
               dt = objadduser.SelectDropdowndListStatusDALC();
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }





         public DataTable SelectDropdownComponent()
         {


             try
             {
                 DataTable  dt = new DataTable();
                 ESLIssueDALC obj = new ESLIssueDALC();
                 dt = obj.SelectDropdowndListissueDALC();
                 return dt;
             }
             catch (Exception)
             {

                 throw;
             }
         }



       /// <summary>
       /// Slelect Stock Quantity
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
         public DataTable SelectStockQtyComponent(int BatchId)
         {
             try
             {
                 DataTable dt = new DataTable();
                 ESLIssueDALC objESLDALC = new ESLIssueDALC();
                 dt = objESLDALC.SelectStockQtyDALC(BatchId);
                 return dt;
             }
             catch (Exception)
             {

                 throw;
             }
         }

        /// <summary>
        /// Insert forwarding note details
        /// </summary>
        /// <param name="objentity"></param>
        /// <returns></returns>
         public int InsertForwardingNoteDetails(EslForwardingNoteEntity objentity)
         {
             try
             {
                 int r;
                  ESLIssueDALC objESLDALC = new  ESLIssueDALC();
                  r = objESLDALC.InserEslForwardingNoteDALC(objentity);
                  return r;
             }
             catch (Exception)
             {

                 throw;
             }
         }
         public DataTable SelectForwardNoteViewComponent(int Id)
         {
             try
             {
                 DataTable dt = new DataTable();
                 ESLIssueDALC objESLDALC = new ESLIssueDALC();
                 dt = objESLDALC.SelectForwardNoteViewDALC(Id);
                 return dt;
             }
             catch (Exception)
             {

                 throw;
             }
         }


       /// <summary>
       /// Insert ESLIssue_Product 
       /// </summary>
       /// <param name="objentity"></param>
       /// <returns></returns>

         public int InsertproductESLIssue(ESLIssueEntity objentity)
         {
             try
             {
                 int r;
                  ESLIssueDALC objESLDALC = new  ESLIssueDALC();
                  r = objESLDALC.InserESLIssueDALC(objentity);
                  return r;
             }
             catch (Exception)
             {
                 throw;
             }
         }

       public DataTable SelectESLIssueGridComponent(string actionName, int? Id)

         {
             try
             {
                 DataTable dt = new DataTable();
                 ESLIssueDALC objESLDALC = new ESLIssueDALC();
                 dt = objESLDALC.SelectESLIssueGridDALC(actionName,Id);
                 return dt;
             }
             catch (Exception)
             {
                 
                 throw;
             }
         }




       public int UpdateESLstatusComponent(int? id, DateTime? date,DateTime? date1)

       {
           try
           {
            int dt = 0;
            ESLIssueDALC ObjDALC = new ESLIssueDALC ();
            //dt = ObjDALC.UpdateESLstatus(ObjESLIssue);
            dt = ObjDALC.UpdateBatchEslDateAndStatusDALC(id,date,date1); 
            return dt;

           }
           catch (Exception)
           {               
               throw;
           }
          
       }



      /// <summary>
       /// Girdview change by StatusID
      /// </summary>
      /// <param name="StatusId"></param>
      /// <returns></returns>
       public DataTable SelectGridbyStatusComp(int StatusId)
       {
           try
           {
               DataTable dt = new DataTable();
               ESLIssueDALC Obj = new ESLIssueDALC();
               dt = Obj.SelectGridbyStatusDALC(StatusId);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
       public DataTable SelectESLIssueStatusGridComponent(ESLIssueEntity ObjESLentity)
       {
           try
           {
               DataTable dt = new DataTable();
               ESLIssueDALC objESLDALC = new ESLIssueDALC();
               dt = objESLDALC.SelectESLIssueStatusGridDALC(ObjESLentity);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
       

       public DataTable SelectStatusCompByDate(DateTime from, DateTime to)
       {
           try
           {
               DataTable dt;
               //ESLIssueStatusDALC ObjStatusDALC = new ESLIssueStatusDALC();
               ESLIssueDALC ObjStatusDALC = new ESLIssueDALC();
               dt = ObjStatusDALC.SelectStatusDalcByDate(from, to);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
       public DataTable SelectStatusCompByDate(DateTime from, DateTime to, string status)
       {
           try
           {
               DataTable dt;
               //ESLIssueStatusDALC ObjStatusDALC = new ESLIssueStatusDALC();
               ESLIssueDALC ObjStatusDALC = new ESLIssueDALC();
               dt = ObjStatusDALC.SelectStatusDalcByDate(from, to, status);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }





    }
}
