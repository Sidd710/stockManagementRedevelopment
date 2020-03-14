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
    public partial class rhpd : System.Web.UI.UserControl
    {
        int Fyid = 0;
        string Fynancialyearrange = "";
        public int attributetype;
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFinancialyear();
                

            }
        }
        public void bindFinancialyear()
        {

            SqlCommand cmd = new SqlCommand("usp_GetFinancialyear", con);
            cmd.CommandType = CommandType.StoredProcedure;


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlyear.DataTextField = "YearRange";
                ddlyear.DataValueField = "QuarterYear";
                ddlyear.DataSource = dt;
                ddlyear.DataBind();
                ddlyear.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {

            }
            con.Close();
        }

        public void bindOrderType()
        {

            SqlCommand cmd = new SqlCommand("usp_getattributeby_financialyear", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlordertype.DataTextField = "AttributeName";
                ddlordertype.DataValueField = "TypeId";
                ddlordertype.DataSource = dt;
                ddlordertype.DataBind();
                ddlordertype.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {

            }
            con.Close();
        }
       
        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlyear.SelectedIndex>0)
            {
              
               
                bindOrderType();
               
                
            }
                
        }

        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {


            if(ddlordertype.SelectedIndex>0)
            {
                Session["attribute"] = null;
                Session["yearvaluue"] = null;
                attributetype =Convert.ToInt32(ddlordertype.SelectedValue);
                int yearvalue = Convert.ToInt32(ddlyear.SelectedValue);
                this.Page.GetType().InvokeMember("LoadInitialData_", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { attributetype, yearvalue });
            }
        }
        public void setdropdown( int selectedvalue,int yearselectedvalue)
        {
            bindOrderType();
            ddlordertype.SelectedValue = Convert.ToString(selectedvalue);
            ddlyear.SelectedValue = Convert.ToString(yearselectedvalue);
            string attributeName_ = GetAttributeName(selectedvalue);

            if (attributeName_ == "IDT")
            {

                lbltext.Text = "IDT Panel";
            }

            else if (attributeName_ == "ICT")
            {
                lbltext.Text = "ICT Panel";
            }
            else if (attributeName_ == "AWS")
            {
                lbltext.Text = "AWS Panel";
            }
            else if (attributeName_ == "Full Year")
            {
                lbltext.Text = "Full Year Panel";
            }

        }
        public string GetAttributeName(int TypeId)
        {
            string attributename_ = "";
            if(TypeId!=0)
            {
                
                SqlCommand cmd = new SqlCommand("usp_GetAttributeName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Typeid", TypeId);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                attributename_ = dt.Rows[0]["AttributeName"].ToString();
                con.Close();
            }
          
            return attributename_;
            
            
        }

      


    }
}