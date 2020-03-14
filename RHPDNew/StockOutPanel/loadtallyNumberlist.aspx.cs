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

namespace RHPDNew.StockOutPanel
{
    public partial class loadtallyNumberlist : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);

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
                  
                bindgrid();
            }}

        }

        public void bindgrid()
        {

            SqlCommand cmd = new SqlCommand("usp_getLoadTallyList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rgdTelly.DataSource = dt;
                rgdTelly.DataBind();
                rgdTelly.Visible = true;
            }
            
        }

        [WebMethod(EnableSession = true)]
        public static Vechile[] getloadtally(String LoadTallyNumber)
        {
            DataTable dt = new DataTable();
            List<Vechile> details = new List<Vechile>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetLoadTallyToPrint", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@LoadtallyNumber", LoadTallyNumber);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        Vechile vechiledetail_ = new Vechile();
                        vechiledetail_.product_name = dtrow["product_name"].ToString();
                        vechiledetail_.productUnit = dtrow["productUnit"].ToString();
                        vechiledetail_.StockQuantity = dtrow["StockQuantity"].ToString();
                        vechiledetail_.Authority = dtrow["Authority"].ToString();
                        vechiledetail_.through = dtrow["through"].ToString();
                        vechiledetail_.vechileNo = dtrow["vechileNo"].ToString();
                        vechiledetail_.PMQuantity =dtrow["PMQuantity"].ToString();
                        details.Add(vechiledetail_);
                    }
                }
            }
            return details.ToArray();
        }
        public class Vechile
        {
            public string product_name { get; set; }
            public string productUnit { get; set; }
            public string StockQuantity { get; set; }
            public string Authority { get; set; }
            public string through { get; set; } 
            public string vechileNo { get; set; }
            public string PMQuantity { get; set; }
            


        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            bindgrid();
        }

        protected void rgdTelly_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("usp_getLoadTallyList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if(con.State.ToString()=="Closed")
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
                rgdTelly.DataSource = dt;
           
        }
    }
}