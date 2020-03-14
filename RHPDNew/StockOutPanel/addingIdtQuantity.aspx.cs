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

namespace Demo1
{
    public partial class addingIdtQuantity : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        int Dipuid;  //ViewState["dipuID"] need to get data from querystring
        int prdId;  //ViewState["productId"] need to get data from querystring
        int QtrID;  //ViewState["QtrID"] need to get data from querystring



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {

                    getActualIdtQty(Dipuid, prdId);
                }
            }
        }
       // SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public decimal getdremainingIDT(int prdid, int DepuID, int quarterId)
        {

            using (SqlCommand cmd = new SqlCommand("usp_getRemainingIDT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (con.State.ToString() != "Open")
                    con.Open();
                cmd.Parameters.AddWithValue("@productId", prdid);
                cmd.Parameters.AddWithValue("@depuID", DepuID);
                cmd.Parameters.AddWithValue("@quaterID", quarterId);
                cmd.Parameters.AddWithValue("@TypeId", Convert.ToInt32(Request.QueryString["TypeId"].ToString()));
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return decimal.Parse(dr["RemaingIDT"].ToString());

                        con.Close();
                    }
                    else
                        return 0; con.Close();
                }

            }


        }


        public void getActualIdtQty(int DepuId, int ProductId)
        {
            decimal qty = getdremainingIDT(Convert.ToInt32(Request.QueryString["prdId"].ToString()), Convert.ToInt32(Request.QueryString["Did"].ToString()), Convert.ToInt32(Request.QueryString["qid"].ToString()));
           if(qty<0)
               qty = 0;
            using (SqlCommand cmd = new SqlCommand("usp_GetIdtqty", con))
           {
               cmd.CommandType = CommandType.StoredProcedure;
               if (con.State.ToString() != "Open") con.Open();

               cmd.Parameters.AddWithValue("@depuId", Convert.ToInt32(Request.QueryString["Did"].ToString()));
               cmd.Parameters.AddWithValue("@productId", Convert.ToInt32(Request.QueryString["prdId"].ToString()));
               cmd.Parameters.AddWithValue("@QuaterID", Convert.ToInt32(Request.QueryString["qid"].ToString()));
              // cmd.Parameters.AddWithValue("@TypeId", Convert.ToInt32(Request.QueryString["TypeId"].ToString()));
               using (SqlDataReader dr = cmd.ExecuteReader())
               {
                   if (dr.Read())
                   {
                       decimal total = decimal.Parse(dr["TotalIDT"].ToString());
                       if (qty > total)
                           lblactualquantity.Text = qty.ToString() + "[Issued: " +(qty-total).ToString() + "]";
                       else
                           lblactualquantity.Text = qty.ToString() + "[Issued: " + (total-qty).ToString() + "]";
                       prdname.Text = dr["Product_Name"].ToString();

                   }
               }
           }
            
        
        }



        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int depoid = Convert.ToInt32(ViewState["dipuID"]);
            int prdid = Convert.ToInt32(ViewState["productId"]);
            DateTime refDT=Convert.ToDateTime(txtrefrencedate.SelectedDate);
            using (SqlCommand cmd = new SqlCommand())
            {
                string crntQnty = "";
                cmd.Connection = con;
                if (Request.Form[hfName.UniqueID].IndexOf('+') > -1)
                {
                    crntQnty = Request.Form[hfName.UniqueID].Split('+')[1];
                    cmd.CommandText = "usp_UpdateIdtQty_Add";
                }
                else if (Request.Form[hfName.UniqueID].IndexOf('-') > -1)
                {
                    crntQnty = Request.Form[hfName.UniqueID].Split('-')[1];
                    cmd.CommandText = "usp_UpdateIdtQty_Sub";
                }
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@dipuid", Convert.ToInt32(Request.QueryString["Did"].ToString()));
                cmd.Parameters.AddWithValue("@prdid", Convert.ToInt32(Request.QueryString["prdId"].ToString()));
                cmd.Parameters.AddWithValue("@currentQTY", crntQnty);
                //SqlParameter currentqty = cmd.Parameters.AddWithValue("@currentQTY", lblcurrentquantity.Text);
                cmd.Parameters.AddWithValue("@Refrenceletter", txtRefrenceletter.Text.Trim());
                cmd.Parameters.AddWithValue("@RefrenceletterDate", refDT);
                cmd.Parameters.AddWithValue("@remarks", txtremarks.Text.Trim());
                cmd.Parameters.AddWithValue("@QuaterID", Convert.ToInt32(Request.QueryString["qid"].ToString()));
                cmd.Parameters.AddWithValue("@TypeId", Convert.ToInt32(Request.QueryString["TypeId"].ToString()));
                cmd.ExecuteNonQuery();
                con.Close();
               
                    Response.Redirect("../StockOutPanel/frmMonitoringStock.aspx");
                
            }
        }


    }
}