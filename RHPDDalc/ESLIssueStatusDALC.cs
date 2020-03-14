using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using StarMethods;

namespace RHPDDalc
{
   public class ESLIssueStatusDALC
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
       
        


       public DataTable SelectESLfilterDALC(DateTime from, DateTime to)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[3];
               param[0] = new SqlParameter("@Action", "FilterbyDate");
               param[1]= new SqlParameter ("@fromdate", from);
               param[2] = new SqlParameter("@todate", to);
               dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spESLIssue", param);
               return dt;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       /// <summary>
       /// select data to diplay in Textbox in ESLIssue page
       /// </summary>
       /// <param name="from"></param>
       /// <param name="to"></param>
       /// <returns></returns>
       public DataTable SelectESLStausDALC(ESLIssueEntity  ObjEntity)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[2];
               param[0] = new SqlParameter("@Action", "SelectESLStatusbyID");
               param[1] = new SqlParameter("@Bid ", ObjEntity.Bid);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spESLIssue", param);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }









       

    }
}
