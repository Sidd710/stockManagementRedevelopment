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
    public partial class IssueOrderList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        int status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                binddropdown();
                bindgridissueorder();
            }
        }
        private void binddropdown()
        {

            SqlCommand cmd = new SqlCommand("usp_Dropdowngetcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
          

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlcategory.DataTextField = "Category_Name";
                ddlcategory.DataValueField = "ID";
                ddlcategory.DataSource = dt;
                ddlcategory.DataBind();
                ddlcategory.Items.Insert(0, new ListItem("--All--", "0"));
            }
            else
            {

            }
            con.Close();
        }
        public void bindgridissueorder()
        {


            SqlCommand cmd = new SqlCommand("usp_get_issueorder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@catId", Convert.ToInt32(ddlcategory.SelectedValue));
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                issueorderlistgrid.DataSource = dt;
                issueorderlistgrid.DataBind();
                

            }
            else
            {
                issueorderlistgrid.DataSource = null;
                issueorderlistgrid.DataBind();
                issueorderlistgrid.EmptyDataText = "No Record Found !!!!";
               
            }
            con.Close();
        }

        protected void issueorderlistgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int prdid;
            string issuorder = "";
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label issueorderNumber = (Label)e.Row.FindControl("lblissueorderNo");
                HyperLink lnkissuevoucherkey = (HyperLink)e.Row.FindControl("lnkgenratevoucher");
               // HiddenField hd1 = (HiddenField)e.Row.FindControl("HiddenField1");
               // prdid = Convert.ToInt32(hd1.Value);
                issuorder = issueorderNumber.Text;
                SqlCommand cmd = new SqlCommand("usp_getcount_satus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productid", 0);
                cmd.Parameters.AddWithValue("@issueorderNumber", issuorder);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
               

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                         status = Convert.ToInt32(dr["issuevoucher_status"].ToString());
                       

                    }
                }
                //if (status == 1)
                //{
                //    lnkissuevoucherkey.Text = "Issue Voucher Genrated";
                //    //lnkissuevoucherkey.Enabled = false;
                //}
               // status = 0;
                
            }

        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catid = Convert.ToInt32(ddlcategory.SelectedValue);
            bindgridissueorder();
        }

    }
}