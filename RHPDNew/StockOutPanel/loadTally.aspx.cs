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

namespace Demo1
{
    public partial class loadTally : System.Web.UI.Page
    {
        string vechileNo = "";
        int issueorderId;
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtdate.Text = "";
                txtldTno.Text = "";
                txtRank.Text = "";
                txtunitNo.Text = "";
                txtvechileno.Text = "";
                lbldriverName.Text = "";
                vechileNo = Request.QueryString["VehicleNo"];
                issueorderId = Convert.ToInt32(Request.QueryString["IssueOrderId"]);
                ViewState["VechileNo"] = vechileNo;
                ViewState["IssueorderID"] = issueorderId;
                genrateAutoLoadTallyNumber();
                getLoadTallyNumber();
                getvechileDetailforLoadtally();
                getAllloadTally(txtldTno.Text.Trim());
                txtvechileno.Text = vechileNo;
                bindgrid();
            }
          
        }

        public void bindgrid()
        {

            SqlCommand cmd = new SqlCommand("usp_getLoadtallydetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vechileNo", vechileNo);
            cmd.Parameters.AddWithValue("@issueorderId", issueorderId);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                loadTallyGrid_.DataSource = dt;
                loadTallyGrid_.DataBind();
                loadTallyGrid_.Visible = true;
                double weight = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    weight = weight + Convert.ToDouble(dr["Weight"].ToString());
                }
                lblTotalWeight.Text = lblTotalWeight.Text + weight.ToString("0.000");
            }
            else
            {
                loadTallyGrid_.EmptyDataText = "No Record Found";
                loadTallyGrid_.DataSource = null;
                loadTallyGrid_.Visible = false;

            }
            con.Close();

        }

        public void getAllloadTally(String loadtallyNo)
        {

            using (SqlCommand cmd = new SqlCommand("usp_getAllloadtallyDetail", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@loadtallyNumberValue", loadtallyNo);

               con.Open();
                using (SqlDataReader dr2 = cmd.ExecuteReader())
                {
                   
                    if (dr2.Read())
                    {
                        lbldriverName.Text = dr2["DriverName"].ToString();
                        txtRank.Text = dr2["Rank"].ToString();
                        txtunitNo.Text = dr2["UnitNo"].ToString();
                        txtdate.Text =Convert.ToDateTime(dr2["DateofGenration"].ToString()).ToString("dd MM yyyy");
                        txtthrough.Text = dr2["Through"].ToString();
                        txtauthority.Text = dr2["Authority"].ToString();
                        //dr2.Close();
                        lbldriverName.Enabled = false;
                        txtauthority.Enabled = false;
                        txtdate.Enabled = false;
                        txtldTno.Enabled = false;
                        txtunitNo.Enabled = false;
                        txtthrough.Enabled = false;
                        txtRank.Enabled = false;
                        Boolean status = Convert.ToBoolean(dr2["Status"].ToString());
                        if (status == false) btnGenrateLoadTally.Visible = true;
                        else
                            btnGenrateLoadTally.Visible = false;

                    }
                    else
                    {
                        dr2.Close();
                    }
                    dr2.Close();
                }
                con.Close();
            }
        }

        public void genrateAutoLoadTallyNumber()
        {
            SqlCommand cmd = new SqlCommand("usp_Autogenrate_LoadTallyNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vechileNo", vechileNo);
            cmd.Parameters.AddWithValue("@IssueorderId", issueorderId);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void getvechileDetailforLoadtally()
        {
            using (SqlCommand cmd = new SqlCommand("usp_getvechileDetailforLoadtally", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@VechileNo", vechileNo);
                
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtvechileno.Text = dr["VechileNumber"].ToString();
                        lbldriverName.Text = dr["DriverName"].ToString();
                        txtRank.Text = dr["Rank"].ToString();
                        txtthrough.Text = dr["Through"].ToString();
                        txtvechileno.Enabled = false;
                        lbldriverName.Enabled = false;
                        txtRank.Enabled = true;
                        txtthrough.Enabled = false;
                       


                    }
                    else
                    {

                    }


                }

                con.Close();
            }

        }

        public void getLoadTallyNumber()
        {
            using (SqlCommand cmd = new SqlCommand("usp_getLoadTallyNumber", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@VechileNo", vechileNo);
                cmd.Parameters.AddWithValue("@issueorderid", issueorderId);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtldTno.Text = dr["loadtallyNumber"].ToString();
                      
                       

                    }
                    else
                    {
                        
                    }
                   
                    
                }
                
                con.Close();
            }
        }

        protected void btnGenrateLoadTally_Click(object sender, EventArgs e)
        {
            DateTime dog = Convert.ToDateTime(txtdate.Text.Trim());
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_GenrateLoadTally", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@issueorderID", ViewState["IssueorderID"]);
                    cmd.Parameters.AddWithValue("@vechileNo", ViewState["VechileNo"]);
                    cmd.Parameters.AddWithValue("@Authority", txtauthority.Text.Trim());
                    cmd.Parameters.AddWithValue("@through", txtthrough.Text.Trim());
                    cmd.Parameters.AddWithValue("@loadtallyNo", txtldTno.Text.Trim());
                    cmd.Parameters.AddWithValue("@driverName", lbldriverName.Text.Trim());
                    cmd.Parameters.AddWithValue("@rank", txtRank.Text.Trim());
                    cmd.Parameters.AddWithValue("@UnitNo", txtunitNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateofgenration", dog);
                    cmd.Parameters.AddWithValue("@Userid", Session["UserId"]);
                    cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);


                    cmd.ExecuteNonQuery();

                }
                Response.Redirect("loadtallylist.aspx");
            }
            con.Close();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
          
        }

        protected void txtRank_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtRank_TextChanged1(object sender, EventArgs e)
        {

        }
    }
}