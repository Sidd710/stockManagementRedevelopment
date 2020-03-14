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
using AjaxControlToolkit;
using Telerik.Web.UI;
using RHPDComponent;
using System.Globalization;

namespace RHPDNew.Forms
{
    public partial class frmLPCPList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetails"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        _BindData();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void _BindData()
        {
            try
            {
                txtTo.SelectedDate = null;
                txtFrom.SelectedDate = null;
              
                rgdList.DataSource =_GetData();
                rgdList.DataBind();
            
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void _GetStatusList(DataRow dr)
        {
            try
            {
                rbtnStatus.Items.Clear();
                ListItem li =new ListItem();
                li.Text = "All" +" [" +dr["All1"].ToString()+"]";
                li.Value = "All";
                li.Selected = true;
                rbtnStatus.Items.Add(li);
                 li = new ListItem();
                 li.Text = "Processing" + " [" + dr["Processing"].ToString() + "]";
                 li.Value = "Processing";
                rbtnStatus.Items.Add(li);
                li = new ListItem();
                li.Text = "Late" + " [" + dr["Late"].ToString() + "]";
                li.Value = "Late";
                rbtnStatus.Items.Add(li);
                li = new ListItem();
                li.Text = "Completed" + " [" + dr["Completed"].ToString() + "]";
                li.Value = "Completed";
                rbtnStatus.Items.Add(li);
                li = new ListItem();
                li.Text = "Dispute" + " [" + dr["Dispute"].ToString() + "]";
                li.Value = "Dispute";
                rbtnStatus.Items.Add(li);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private DataTable _GetData()
        {
            DataTable dt = new DataTable();
            if (Request.QueryString["iD"] != null)
            {
                int ID = Convert.ToInt32(Request.QueryString["iD"].ToString());
                SqlCommand cmd = new SqlCommand("spLPCPList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "LPCPListByID");
                cmd.Parameters.AddWithValue("@ID", ID);

                if (con.State.ToString() == "Closed")
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

            }
            else
            {
                
                SqlCommand cmd = new SqlCommand("spLPCPList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "LPCPList");               
                if (con.State.ToString() == "Closed")
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
                _GetStatusList(dt.Rows[0]);
            else
                rbtnStatus.Items.Clear();
            return dt;
        }

        protected void rgdCRV_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            _BindData();
           
            if (rbtnCPLP.SelectedItem.Value == "Both")
            {
                rgdList.DataSource = _GetData();
               
            }
            else if (rbtnCPLP.SelectedItem.Value == "CP")
            {
                rgdList.DataSource = _GetCPLP("CP"); 

            }
            else if (rbtnCPLP.SelectedItem.Value == "LP") { rgdList.DataSource = _GetCPLP("LP");  }
        }

        protected void btnSubmitP_Click(object sender, EventArgs e)
        {
            try
            {
                rhpdEntities db = new rhpdEntities();
                Button btn = (Button)sender;
                if (btn.CommandArgument != null)
                {
                    int ID = int.Parse(btn.CommandArgument.ToString());
                    foreach (GridDataItem dataItem in rgdList.MasterTableView.Items)
                    {
                        if (dataItem.GetDataKeyValue("ID").ToString() == btn.CommandArgument.ToString())
                        {
                            if (btn.CommandName.ToString() == "Late")
                            {
                                DropDownList ddl = (DropDownList)dataItem.FindControl("ddlStatusL");
                                TextBox txt = (TextBox)dataItem.FindControl("txtRemarksL");

                                var query = from emp in db.tblLPCPs
                                            where emp.ID == ID
                                            select emp;
                                tblLPCP obj = query.SingleOrDefault();
                                obj.Remarks = txt.Text;
                                if (ddl.SelectedItem.Value == "Spillage")
                                {
                                    obj.Status = true;
                                    obj.Dispute = false;
                                    obj.Late = true;
                                    obj.Other = false;
                                }
                                else if (ddl.SelectedItem.Value == "Dispute")
                                {
                                    obj.Status = true;
                                    obj.Dispute = true;
                                    obj.Late = false;
                                    obj.Other = true;
                                }
                                else if (ddl.SelectedItem.Value == "Other")
                                {
                                    obj.Status = true;
                                    obj.Dispute = false;
                                    obj.Late = false;
                                    obj.Other = true;
                                }

                                obj.ModifiedOn = DateTime.Now;
                                obj.ModifiedBy = 1;
                                db.SaveChanges();
                            }
                            else if (btn.CommandName.ToString() == "Processing")
                            {
                                DropDownList ddl = (DropDownList)dataItem.FindControl("ddlStatusP");
                                TextBox txt = (TextBox)dataItem.FindControl("txtRemarksP");

                                var query = from emp in db.tblLPCPs
                                            where emp.ID == ID
                                            select emp;
                                tblLPCP obj = query.SingleOrDefault();
                                obj.Remarks = txt.Text;
                                if (ddl.SelectedItem.Value == "Spillage")
                                {
                                    obj.Status = false;
                                    obj.Dispute = false;
                                    obj.Late = true;
                                    obj.Other = false;
                                }
                                else if (ddl.SelectedItem.Value == "Dispute")
                                {
                                    obj.Status = true;
                                    obj.Dispute = true;
                                    obj.Late = false;
                                    obj.Other = true;
                                }
                                else if (ddl.SelectedItem.Value == "Other")
                                {
                                    obj.Status = true;
                                    obj.Dispute = false;
                                    obj.Late = false;
                                    obj.Other = true;
                                }

                                obj.ModifiedOn = DateTime.Now;
                                obj.ModifiedBy = 1;
                                db.SaveChanges();
                            }

                        }
                    }
                }
                _BindData();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void rbtnCPLP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _BindData();
                if (rbtnCPLP.SelectedItem.Value == "Both")
                {
                    rgdList.DataSource = _GetData();
                    rgdList.DataBind();
                }
                else if (rbtnCPLP.SelectedItem.Value == "CP")
                {
                    rgdList.DataSource = _GetCPLP("CP"); rgdList.DataBind();

                }
                else if (rbtnCPLP.SelectedItem.Value == "LP") { rgdList.DataSource = _GetCPLP("LP"); rgdList.DataBind(); }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private DataTable _GetCPLP(string p)
        {
            try
            {
                int IsAT = 0;
                if (p == "CP")
                { IsAT = 0; }
                else
                    IsAT = 1;
                DataTable dt = new DataTable();
                if (Request.QueryString["iD"] != null)
                {
                    int ID = Convert.ToInt32(Request.QueryString["iD"].ToString());
                    SqlCommand cmd = new SqlCommand("spLPCPList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "GetByATSOByID");
                    cmd.Parameters.AddWithValue("@IsATNo", IsAT);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    if (con.State.ToString() == "Closed")
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                else
                {
                   
                    SqlCommand cmd = new SqlCommand("spLPCPList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "GetByATSO");
                    cmd.Parameters.AddWithValue("@IsATNo", IsAT);
                   
                    if (con.State.ToString() == "Closed")
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                if (dt.Rows.Count > 0)
                _GetStatusList(dt.Rows[0]);
                else
                    rbtnStatus.Items.Clear();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void rbtnStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _BindData();
                if (rbtnStatus.SelectedItem.Value == "All")
                { rgdList.DataSource = _GetByStatus("All"); rgdList.DataBind(); }
                else if (rbtnStatus.SelectedItem.Value == "Processing")
                { rgdList.DataSource = _GetByStatus("Processing"); rgdList.DataBind(); }
                else if (rbtnStatus.SelectedItem.Value == "Late")
                { rgdList.DataSource = _GetByStatus("Late"); rgdList.DataBind(); }
                else if (rbtnStatus.SelectedItem.Value == "Completed")
                { rgdList.DataSource = _GetByStatus("Completed"); rgdList.DataBind(); }
                else if (rbtnStatus.SelectedItem.Value == "Dispute")
                { rgdList.DataSource = _GetByStatus("Dispute"); rgdList.DataBind(); }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private DataTable _GetByStatus(string p)
        {
            try
            {
                int Status=0;
                int Late=0;
                int Dispute=0;
                if (p == "All")
                {
                    return _GetData();
                }
                else if (p == "Processing")
                {
                     Status = 0;
                     Late = 0;
                     Dispute = 0;
                }
                else if (p == "Late")
                {
                    Status = 0;
                    Late = 1;
                    Dispute = 0;
                }
                else if (p == "Dispute")
                {
                    Status = 1;
                    Late = 0;
                    Dispute = 1;
                }
                else if (p == "Completed")
                {
                    Status = 1;
                    Late = 0;
                    Dispute = 0;
                }
                DataTable dt = new DataTable();
                if (Request.QueryString["iD"] != null)
                {
                    int ID = Convert.ToInt32(Request.QueryString["iD"].ToString());
                    SqlCommand cmd = new SqlCommand("spLPCPList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "GetByStatusByID");
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Late", Late);
                    cmd.Parameters.AddWithValue("@Dispute", Dispute);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    if (con.State.ToString() == "Closed")
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("spLPCPList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "GetByStatus");
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Late", Late);
                    cmd.Parameters.AddWithValue("@Dispute", Dispute);

                    if (con.State.ToString() == "Closed")
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
               
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void ddlStatusP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;

                if (ddl.ToolTip != null)
                {
                    int ID = 0;
                    string status = "";
                    string[] tt = ddl.ToolTip.ToString().Split('/');
                    if (tt.Count() > 1)
                    {
                        if (tt[0] != "")
                        { ID = int.Parse(tt[0].ToString()); }
                        if (tt[1] != "")
                        { status = tt[1].ToString(); }
                    }
                    if (ddl.SelectedItem.Value == "Dispute")
                    {
                        foreach (GridDataItem dataItem in rgdList.MasterTableView.Items)
                        {
                            if (dataItem.GetDataKeyValue("ID").ToString() == ID.ToString())
                            {
                                if (status == "Late")
                                {
                                    TextBox txtRemarksL = (TextBox)dataItem.FindControl("txtRemarksL");
                                    RequiredFieldValidator rqRemarksL = (RequiredFieldValidator)dataItem.FindControl("rqRemarksL");
                                    txtRemarksL.Visible = true;
                                    rqRemarksL.Enabled = true;
                                }
                                else if (status == "Processing")
                                {
                                    TextBox txtRemarksP = (TextBox)dataItem.FindControl("txtRemarksP");
                                    RequiredFieldValidator rqRemarksP = (RequiredFieldValidator)dataItem.FindControl("rqRemarksP");
                                    txtRemarksP.Visible = true;
                                    rqRemarksP.Enabled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (GridDataItem dataItem in rgdList.MasterTableView.Items)
                        {
                            if (dataItem.GetDataKeyValue("ID").ToString() == ID.ToString())
                            {
                                if (status == "Late")
                                {
                                    TextBox txtRemarksL = (TextBox)dataItem.FindControl("txtRemarksL");
                                    RequiredFieldValidator rqRemarksL = (RequiredFieldValidator)dataItem.FindControl("rqRemarksL");
                                    txtRemarksL.Visible = false;
                                    rqRemarksL.Enabled = false;
                                }
                                else if (status == "Processing")
                                {
                                    TextBox txtRemarksP = (TextBox)dataItem.FindControl("txtRemarksP");
                                    RequiredFieldValidator rqRemarksP = (RequiredFieldValidator)dataItem.FindControl("rqRemarksP");
                                    txtRemarksP.Visible = false;
                                    rqRemarksP.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
               
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("spLPCPList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Request.QueryString["iD"] != null)
                {
                    int ID = Convert.ToInt32(Request.QueryString["iD"].ToString());
                    cmd.Parameters.AddWithValue("@Action", "LPCPByDateByID");
                    cmd.Parameters.AddWithValue("@ID", ID);            
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Action", "LPCPByDate");                   
                }
                if (rbtnTenderRec.SelectedItem.Value == "Tender")
                {
                    cmd.Parameters.AddWithValue("@Tender", 1);
                }
                else if (rbtnTenderRec.SelectedItem.Value == "Receiving")
                {
                    cmd.Parameters.AddWithValue("@Tender", 0);
                }
                cmd.Parameters.AddWithValue("@FromDate",txtFrom.SelectedDate);
                cmd.Parameters.AddWithValue("@ToDate",txtTo.SelectedDate);    
                if (con.State.ToString() == "Closed")
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                rgdList.DataSource = dt;
                rgdList.DataBind();
                if(dt.Rows.Count>0)
                _GetStatusList(dt.Rows[0]);
                else
                    rbtnStatus.Items.Clear();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _Clear();
        }

        private void _Clear()
        {
            _BindData();

        }
    }
}