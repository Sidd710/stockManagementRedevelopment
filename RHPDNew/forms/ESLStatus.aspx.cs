using RHPDComponent;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RHPDNew.Forms
{
    public partial class ESLStatus : System.Web.UI.Page
    {
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
                    GridDisplay();
                    List<string> listStatus = new List<string>();
                    listStatus.Add(string.Empty);
                    listStatus.Add("Fit");
                    listStatus.Add("UnFit");
                    listStatus.Add("Pending");
                    ddlstatus.DataSource = listStatus;
                    ddlstatus.DataBind();
                }  
            }

        }

        public void GridDisplay()
        {
            try
            {
                ESLIssueComponent ObjESLComp = new ESLIssueComponent();
                ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
                DataTable dt = new DataTable();
                dt = ObjESLComp.SelectESLIssueStatusGridComponent(ObjEslEntity);
                if (dt.Rows.Count > 0)
                {
                    ESLRadgrid.DataSource = dt;
                    ESLRadgrid.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ESLRadgrid_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            try
            {
                ESLRadgrid.CurrentPageIndex = e.NewPageIndex;
                GridDisplay();
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        protected void btnViewDetails_Click(object sender, EventArgs e)
        {
            radWindowViewDetails.Controls.Clear();
            radWindowViewDetails.NavigateUrl = "EslViewDetails.aspx?Id=" + ((LinkButton)(sender)).CommandArgument;
            radWindowViewDetails.Visible = true;
            radWindowViewDetails.VisibleStatusbar = false;
            radWindowViewDetails.Behaviors = WindowBehaviors.Close;
            string script = "function f(){$find(\"" + radWindowViewDetails.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
              
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Visible = false;
                DateTime dateFrom = (DateTime)dpDateFrom.SelectedDate;
                DateTime dateTo = (DateTime)dpDateTo.SelectedDate;
                string status = ddlstatus.SelectedValue.ToString();
                lblMessage.Text = "";

                if (dateTo <= dateFrom)
                {
                    lblMessage.Text = "Date To can't be less than or equal to Date From!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                }
                else if(status!= "Fit" && status!= "UnFit" && status!= "Pending"){
                    lblMessage.Text = "Status can't be other than 'Fit', 'UnFit' or 'Pending'!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                }
               else 
                   bindgrid(dateFrom, dateTo, status);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bindgrid(DateTime from, DateTime to,string status)
        {
            try
            {
                lblMessage.Visible = false;
                lblMessage.Text = "";
                //ESLIssueStatusComponent ObjStatus = new ESLIssueStatusComponent();
                ESLIssueComponent ObjStatus = new ESLIssueComponent();
                // ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
                DataTable dt;
                dt = ObjStatus.SelectStatusCompByDate(from, to, status);
                if (dt.Rows.Count > 0)
                {
                    ESLRadgrid.DataSource = dt;
                    ESLRadgrid.DataBind();
                }
                else
                {
                    ESLRadgrid.DataSource = null;
                    ESLRadgrid.DataBind();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Didn't found any Record!";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        //protected void ddlstatus_SelectedIndexChanged1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ESLIssueComponent ObjESLComp = new ESLIssueComponent();
        //        ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
        //        DataTable dt = new DataTable();
        //        if (Convert.ToString(ddlstatus.SelectedValue) != "-- Select --")
        //        {
        //            int Statusid = Convert.ToInt32(ddlstatus.SelectedValue);
        //            dt = ObjESLComp.SelectGridbyStatusComp(Statusid);
        //            if (dt.Rows.Count > 0)
        //            {
        //                lblMessage.Visible = false;
        //                ESLRadgrid.DataSource = dt;
        //                ESLRadgrid.DataBind();

        //            }
        //            else
        //            {
        //                ESLRadgrid.DataSource = null;
        //                ESLRadgrid.DataBind();
        //                lblMessage.Visible = true;
        //                lblMessage.Text = "No Any Record";
        //            }
        //        }
        //        else
        //        {
        //            GridDisplay();
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

       

        //private void bindgrid(DateTime from, DateTime to)
        //{
        //    try
        //    {
        //        lblMessage.Visible = false;
        //        lblMessage.Text = "";
        //        //ESLIssueStatusComponent ObjStatus = new ESLIssueStatusComponent();
        //        ESLIssueComponent ObjStatus = new ESLIssueComponent();
        //       // ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
        //        DataTable dt;
        //        dt = ObjStatus.SelectStatusCompByDate(from, to);
        //        if (dt.Rows.Count > 0)
        //        {
        //            ESLRadgrid.DataSource = dt;
        //            ESLRadgrid.DataBind();
        //        }
        //        else
        //        {
        //            ESLRadgrid.DataSource = null;
        //            ESLRadgrid.DataBind();
        //            lblMessage.Visible = true;
        //            lblMessage.Text = "Didn't found any Record!";
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //protected void ddlstatus_DataBound(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DropDownList list = sender as DropDownList;
        //        if (list != null)
        //            list.Items.Insert(0, "-- Select --");

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}