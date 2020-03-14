using Microsoft.ApplicationBlocks.Data;
using RHPDEntity;
using StarMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RHPDDalc
{
    class stockout
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();




        //public void insertIssueOrder()
        //{

        //    conn.Open();

        //    using (SqlCommand cmd = new SqlCommand("usp_Insert_IssueOrder", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@issueorderNo", txtissueordno.Text.Trim());
        //            cmd.Parameters.AddWithValue("@issueorderdate", txtdateofgenration.Text.Trim());
        //            cmd.Parameters.AddWithValue("@authority", txtAuthority.Text.Trim());
        //            cmd.Parameters.AddWithValue("@depoid", DepuID);
        //            cmd.Parameters.AddWithValue("@qid", quarterId);
        //            cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
        //            cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;

        //            cmd.ExecuteNonQuery();
        //            int intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);

        //            conn.Close();

        //            if (intResult == 1)
        //            {
        //                //Response.Redirect("loadtally.aspx");
        //                //return 1;
        //            }
        //            else
        //            {
        //                // return 0;
        //            }
        //        }
         


        //}



    }


}
