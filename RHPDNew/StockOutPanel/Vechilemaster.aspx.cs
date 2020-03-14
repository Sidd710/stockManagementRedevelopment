using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Script.Services;

namespace RHPDNew.StockOutPanel
{
    public partial class Vechilemaster : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("usp_GetVechile_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
        }

        protected void rgdVehicleMaster_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                rgdVehicleMaster.DataSource = dt;
            }
        }


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            var getdate = "";
            if (txtsearchbydate.Text == "")
            {
                getdate = "";
            }
            else
            {
                getdate = txtsearchbydate.Text.Trim();
            }
            SqlCommand cmd = new SqlCommand("usp_GetVechile_DetailBySearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Todaysdate", getdate);
            cmd.Parameters.AddWithValue("@VehicleNos", "");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rgdVehicleMaster.DataSource = dt;
                rgdVehicleMaster.DataBind();
            }
            con.Close();
        }


        //private void bindVechiledetail()
        //{
        //     var getdate = "";
        //    if(txtsearchbydate.Text=="")
        //    {
        //        getdate = "";
        //    }
        //    else
        //    {
        //        getdate = txtsearchbydate.Text.Trim();
        //    }
        //    SqlCommand cmd = new SqlCommand("usp_GetVechile_Detail", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Todaysdate", getdate);
        //    cmd.Parameters.AddWithValue("@VehicleNos", "");
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {

        //        grdVechile.DataSource = dt;
        //        grdVechile.DataBind();

        //    }
        //    else
        //    {
        //        grdVechile.EmptyDataText = "No Record Found !!!!";
        //        grdVechile.DataSource = null;
        //        grdVechile.DataBind();
        //    }
        //    con.Close();
        //}

        
    }
}