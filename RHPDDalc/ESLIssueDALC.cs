using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RHPDEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using StarMethods;

namespace RHPDDalc
{
   public class ESLIssueDALC
    {
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
         
       /// <summary>
       ///Select ddl Status 
       /// </summary>
       /// <returns></returns>
     public DataTable SelectDropdowndListStatusDALC()
       {
           try
           {
               DataTable dt = new DataTable();
               string str = "Select Id, Status from StatusMaster where Id=4 and IsActive= 1";
               dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
               return dt;

           }
           catch (Exception)
           {
               
               throw;
           }
         
       }



      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
     //Select dropdown fro ESLStatusIssue

     public DataTable SelectDropdowndListissueDALC()
     {
         try
         {
             DataTable dt = new DataTable();
             string str = "Select * from StatusMaster where Status!='Pending' AND Status!='Sent' AND IsActive=1 ";
             dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
             return dt;

         }
         catch (Exception)
         {

             throw;
         }

     }

    /// <summary>
     ///Display Stockquantity
    /// </summary>
     /// <param name="PID"></param>
    /// <returns></returns>s
     public DataTable SelectStockQtyDALC(int BatchId)
     {
         try
         {
             DataTable dt = new DataTable();
             SqlParameter[] param = new SqlParameter[2];
             param[0] = new SqlParameter("@Action", "SelectProductAndStockDetails");
             param[1] = new SqlParameter("@Bid", BatchId);
             dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spESLIssue", param);
             return dt;
         }
         catch (Exception)
         {
             throw;
         }

     }

     public DataTable SelectForwardNoteViewDALC(int FnId)
     {
         try
         {
             DataTable dt = new DataTable();
             SqlParameter[] param = new SqlParameter[2];
             param[0] = new SqlParameter("@actionName", "SelectForwardNoteDetails");
             param[1] = new SqlParameter("@FnId", FnId);
             dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "sp_EslForwardingNoteProc", param);
             return dt;
         }
         catch (Exception)
         {
             throw;
         }

     }
     /// <summary>
     /// Insert forwarding note
     /// </summary> 
     /// <param name="objentity"></param>
     /// <returns></returns>
     public int InserEslForwardingNoteDALC(EslForwardingNoteEntity objentity)
     {
         int r = 0;
         try
         {
 
             SqlParameter[] param = new SqlParameter[31];
             param[0] = new SqlParameter("@actionName", "InsertData");
             param[1] = new SqlParameter("@batchId", objentity.BatchId);
             param[2] = new SqlParameter("@forwardingNoteNumber", objentity.ForwardingNoteNumber);
             param[3] = new SqlParameter("@forwardNoteDate", objentity.ForwardNoteDate);
             param[4] = new SqlParameter("@officerDesignation", objentity.OfficerDesignation);
             param[5] = new SqlParameter("@addressee", objentity.Adderessee);
             param[6] = new SqlParameter("@nomenStore", objentity.NomenStore);
             param[7] = new SqlParameter("@containerType", objentity.ContainerType);
             param[8] = new SqlParameter("@sampleRefNumber", objentity.SampleRefNumber);
             param[9] = new SqlParameter("@sampleIdentificationMarks", objentity.SampleIndetityMarks);
             param[10] = new SqlParameter("@sampleQualtity", objentity.SampleQuantity);
             param[11] = new SqlParameter("@numberOfSamples", objentity.SampleNumbers);
             param[12] = new SqlParameter("@sampleType",objentity.SampleType);
             param[13] = new SqlParameter("@dispatchDate",objentity.DispatchDate);
             param[14] = new SqlParameter("@dispatchMethod",objentity.DispatchMethod);
             param[15] = new SqlParameter("@sampleDrawnDate",objentity.SampleDrawnDate);
             param[16] = new SqlParameter("@drawerNameAndRank",objentity.DrawerNameAndRank);
             param[17] = new SqlParameter("@quantityRepressntedBySample",objentity.QuantityRepressntedBySample);
             param[18] = new SqlParameter("@intendedDestination",objentity.IntendedDestination);
             param[19] = new SqlParameter("@fillingDate",objentity.FillingDate);
             param[20] = new SqlParameter("@iNoteNumber",objentity.INoteNumber);
             param[21] = new SqlParameter("@iNoteDate",objentity.INoteDate);
             param[22] = new SqlParameter("@previousTestReferences",objentity.PreviousTestReferences);
             param[23] = new SqlParameter("@tankNumber",objentity.TankNumber);
             param[24] = new SqlParameter("@containerMarkingDetails",objentity.ContainerMarkingDetails);
             param[25] = new SqlParameter("@tradeOwned",objentity.TradeOwned);
             param[26] = new SqlParameter("@govtStock",objentity.GovtStock);
             param[27] = new SqlParameter("@tradeGovtAccepted",objentity.TradeGovtAccepted);
             param[28] = new SqlParameter("@reasonForTest",objentity.ReasonForTest);
             param[29] = new SqlParameter("@governingSupply",objentity.GoverningSupply);
             param[30] = new SqlParameter("@isForwardingNoteActive", objentity.IsForwardNumberActive);

             r = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_EslForwardingNoteProc", param);
             return r;
           }
         catch (Exception)
         {
             throw;
         }
     }

       /// <summary>
       //Insert ESL Issue
       /// </summary>
       /// <param name="objentity"></param>
       /// <returns></returns>

     public int  InserESLIssueDALC(ESLIssueEntity objentity)
     {
         int r = 0;
         try
         {
 
             SqlParameter[] param = new SqlParameter[11];
             param[0] = new SqlParameter("@Action", "Insert");
             param[1] = new SqlParameter("@Bid", objentity.Bid);
             param[2] = new SqlParameter("@Quantitytype", objentity.Quantitytype);
             param[3] = new SqlParameter("@Quantity", objentity.Quantity);
             param[4] = new SqlParameter("@StatusID", objentity.Statusid);
             param[5] = new SqlParameter("@RemarksBynurGP", objentity.Remarksbynurgp);
             param[6] = new SqlParameter("@RemarksByjcoiGP", objentity.RemarksByjcoigp);
             param[7] = new SqlParameter("@RemarksByjDSO", objentity.Remarksbydso);
             param[8] = new SqlParameter("@OverallRemarks", objentity.Overallremarks);
             param[9] = new SqlParameter("@IssueTo", objentity.Issueto);
           //  param[10] = new SqlParameter("@RecievedDate", objentity.Recieveddate);
             param[10] = new SqlParameter("@IsActive", objentity.IsActive);
             r= StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spESLIssue", param);
             return r;
           }
         catch (Exception)
         {
             throw;
         }
     }


      /// <summary>
      /// ESLGridDisplay 
      /// </summary>
      /// <param name="objESLIssue"></param>
      /// <returns></returns>
       // Modified by Rohit Pundeer
    public DataTable SelectESLIssueGridDALC(string actionName,int? bId) 
    {
         try
         {
             DataTable dt = new DataTable();
             SqlParameter[] param = new SqlParameter[2];
             //param[0] = new SqlParameter("@Action", "ESLIssueGridDisplay");
             //dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spESLIssue", param);
             param[0] = new SqlParameter("@actionName", actionName);
             param[1] = new SqlParameter("@batchId", bId);
             dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "sp_EslForwardingNoteProc", param);
             return dt;
         }
         catch (Exception)
         {
             throw;
         }
     }

    /// <summary>
    /// Update batches with new Esl Date 
    /// </summary> 
    /// <param name="actionName"></param>
    /// <param name="bId"></param>
    /// <returns></returns>
    /// // Added by Rohit Pundeer
    public int UpdateBatchEslDateAndStatusDALC(int? bId, DateTime? newDate,DateTime? preDate)
    {
        try
        {
            int dt = 0;
            DateTime mDate = DateTime.Now;

            if (newDate != null)
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@actionName", "FitBatchEslDateAndStatus");
                param[1] = new SqlParameter("@batchId", bId);
                param[2] = new SqlParameter("@NewEslDate", newDate);
                param[3] = new SqlParameter("@ModifyDate", mDate);
                param[4] = new SqlParameter("@PreviousEslDate", preDate);
                dt = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_EslForwardingNoteProc", param);
            }
            else if (newDate == null)
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@actionName", "UnfitBatchDateAndStatus");
                param[1] = new SqlParameter("@batchId", bId);
                param[2] = new SqlParameter("@ModifyDate", mDate);
                dt = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_EslForwardingNoteProc", param);
            }            
            return dt;
        }
        catch (Exception)
        {
            throw;
        }
    }


       
     /// <summary>
     ///   Update ESL Issue Status
     /// </summary>
     /// <param name="ObjESLIssue"></param>
     /// <returns></returns>
 
       public DataTable UpdateESLstatus(ESLIssueEntity ObjESLIssue)
    {
        try
        {
             DataTable dt = new DataTable();
             SqlParameter[] param = new SqlParameter[6];
             param[0] = new SqlParameter("@Action", "UpdateESLIssue");
             param[1] = new SqlParameter("@RecievedDate", ObjESLIssue.Recieveddate);
             param[2] = new SqlParameter("@StatusID", ObjESLIssue.Statusid);
             param[3] = new SqlParameter("@Bid", ObjESLIssue.Bid);
             param[4] = new SqlParameter("@Quantity", ObjESLIssue.Quantity);
             param[5] = new SqlParameter("@ModifiedBy", ObjESLIssue.ModifiedBy);
             dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spESLIssue", param);
             return dt;
        }
        catch (Exception)
        {
            
            throw;
        }
    }








   //Bindgrid accordingf to StatusID

       public DataTable SelectGridbyStatusDALC(int StatusId)
       {
           try 
	    {	 
           DataTable dt = new DataTable ();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@Action", "ChangeGridStatus");
           param[1] = new SqlParameter("@StatusID" ,StatusId);
           dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spESLIssue", param);
           return dt;       
		
	    }
	    catch (Exception)
	    {
		
		    throw;
	    }
         
        }

       public DataTable SelectESLIssueStatusGridDALC(ESLIssueEntity objESLIssue)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[1];
               param[0] = new SqlParameter("@Action", "EslViewDetailsGrid");
               dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spESLIssue", param);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }

       }
       public DataTable SelectStatusDalcByDate(DateTime from, DateTime to)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[3];
               param[0] = new SqlParameter("@Action", "FilterbyDate");
               param[1] = new SqlParameter("@StartDate", from);
               param[2] = new SqlParameter("@EndDate", to);
               dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spESLIssue", param);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
       public DataTable SelectStatusDalcByDate(DateTime from, DateTime to, string status)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[4];
               param[0] = new SqlParameter("@actionName", "FilterbyDateAndStatus");
               param[1] = new SqlParameter("@StartDate", from);
               param[2] = new SqlParameter("@EndDate", to);
               param[3] = new SqlParameter("@Status", status);
               dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "sp_EslForwardingNoteProc", param);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }


    }
}
