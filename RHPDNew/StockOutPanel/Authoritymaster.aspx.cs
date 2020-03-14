using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI.HtmlControls;


namespace RHPDNew.StockOutPanel
{
    public partial class Authoritymaster : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        int auid;
        public int attributetype;
        int yearvalue;
        string typeName = "";
        int qtid;
        protected void Page_Load(object sender, EventArgs e)
        {
           
           if(!IsPostBack)
            {
                bindFinancialyear();
                bindAuthority();
                athoritypanel.Visible = false;
                btnclick.Visible = true;
                Table1.Visible = false;
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
                ddlyear.Items.Insert(0, new ListItem("--Select Financial Year--", "0"));
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
                ddlordertype.Items.Insert(0, new ListItem("--Select Order Type--", "0"));
            }
            else
            {

            }
            con.Close();
        }

        public void GetQuarterList()
        {
            rdoBtnLstQuarters.DataSource = GetQuarterListData();
            rdoBtnLstQuarters.DataTextField = "QuarterName";
            rdoBtnLstQuarters.DataValueField = "QuarterId";
            rdoBtnLstQuarters.DataBind();

             typeName = GetAttributeName(Convert.ToInt32(ddlordertype.SelectedValue));
             ViewState["TypeName"] = typeName;
            if (typeName == "IDT")
            {
                rdoBtnLstQuarters.Visible = true;
                Table1.Visible = true;
            }
            else if (typeName == "Full Year")
            {
                rdoBtnLstQuarters.Visible = false;
            }
            else
            {
                rdoBtnLstQuarters.Visible = false;
            }

        }

        public DataTable GetQuarterListData()
        {
            DataTable dtQuarterList = new DataTable();
            AddProductComp objaddpro = new AddProductComp();
            dtQuarterList = objaddpro.getQuarters(Convert.ToInt32(ddlyear.SelectedValue));
            return dtQuarterList;
        }


        public string GetAttributeName(int TypeId)
        {
            string attributename_ = "";
            if (TypeId != 0)
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

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlyear.SelectedIndex > 0)
            {


                bindOrderType();


            }

        }

        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlordertype.SelectedIndex > 0)
            {
                Table1.Visible = true;
                GetQuarterList();
            }
        }


        protected void btnaddAuthority_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_add_update_Authority", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(chkactive.Checked==true)
                    {
                        cmd.Parameters.AddWithValue("@active", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@active", 0);
                    }

                    if (btnaddAuthority.Text == "Update Authority")
                    {
                        cmd.Parameters.AddWithValue("@Auid", ViewState["Auid"]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Auid", 0);
                    }
                   
                    cmd.Parameters.AddWithValue("@Auname", txtAuthority.Text.Trim());
                    cmd.Parameters.AddWithValue("@Fyear", Convert.ToInt32(ddlyear.SelectedValue));
                    cmd.Parameters.AddWithValue("@OrderType", Convert.ToInt32(ddlordertype.SelectedValue));

                    if (Convert.ToString(ViewState["TypeName"]) == "IDT")
                    {
                        cmd.Parameters.AddWithValue("@Qid", Convert.ToInt32(rdoBtnLstQuarters.SelectedValue));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Qid", 0);
                    }
                    cmd.Parameters.AddWithValue("@userId", Session["UserId"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                GridAuth_.Visible = true;
                bindAuthority();
                athoritypanel.Visible = false;
                btnclick.Visible = true;

                if (ViewState["Auid"]==null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Authority hasbeen added sucessfully!!!!!", true);
                   
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Authority hasbeen updated sucessfully!!!!!", true);
                   
                }
                Response.Redirect("Authoritymaster.aspx");
              
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void bindAuthority()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_Authority", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    grdAuth.DataSource = dt;
                    grdAuth.DataBind();

                }
                else
                {
                    grdAuth.EmptyDataText = "No Record Found !!!!";
                    grdAuth.DataSource = null;
                    grdAuth.DataBind();
                }
            }
            catch(Exception)
            {
                throw;
            }
            con.Close();
        }

        protected void btnclick_Click(object sender, EventArgs e)
        {
            athoritypanel.Visible = true;
            GridAuth_.Visible = false;
            btnclick.Visible = false;
        }

        protected void grdAuth_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SqlConnection connew = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            athoritypanel.Visible = true;
            GridAuth_.Visible = false;
            btnclick.Visible = false;
            btnaddAuthority.Text = "Update Authority";


            if (e.CommandName == "editAuthority")
            {
                auid = Convert.ToInt32(e.CommandArgument);
                ViewState["Auid"] = auid;
                using (SqlCommand cmd = new SqlCommand("usp_getAuthorityDetail", connew))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connew.Open();
                    cmd.Parameters.AddWithValue("@AuthorityId", auid);
                   
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        
                        if (dr.Read())
                        {
                            txtAuthority.Text = dr["AuthorityName"].ToString();
                            int act =Convert.ToInt32(dr["Active"]);

                            if (act == 1)
                            {
                                chkactive.Checked = true;

                            }
                            else
                            {
                                chkactive.Checked = false;
                            }
                          
                            int fyncid = Convert.ToInt32(dr["Fyear"]);

                            if(fyncid!=0)
                            {
                                bindFinancialyear();
                                ddlyear.SelectedValue =Convert.ToString(fyncid);
                            }

                            int typeid_ = Convert.ToInt32(dr["OrderType"]);
                            if (typeid_ != 0)
                            {
                                bindOrderType();
                                ddlordertype.SelectedValue = Convert.ToString(typeid_);
                            }

                            qtid = Convert.ToInt32(dr["Qid"]);

                            if(qtid!=0)
                            {
                                Table1.Visible = true;
                                GetQuarterList();
                                rdoBtnLstQuarters.SelectedValue = Convert.ToString(qtid);

                            }

                           

                           
                        }
                        else
                        {

                        }


                    }

                    connew.Close();
                }

            }
        }

        protected void btncamnce_Click(object sender, EventArgs e)
        {
            Response.Redirect("Authoritymaster.aspx");
        }
    }
}