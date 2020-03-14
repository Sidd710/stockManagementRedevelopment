using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RHPDEntity;
using RHPDComponent;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class ESLIssueStatus : System.Web.UI.Page
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
                    //Dropdownlist();
                }
            }
        }

        //public void Dropdownlist()
        //{
        //    DataTable dt = new DataTable();
        //    ESLIssueComponent Obj = new ESLIssueComponent();
        //    dt = Obj.SelectDropdownComponent();
        //    if (dt.Rows.Count > 0)
        //    {
        //        ddlstatus.DataSource = dt;
        //        ddlstatus.DataTextField = "Status";
        //        ddlstatus.DataValueField = "Id";
        //        ddlstatus.DataBind();
        //    }
        //}


        /// <summary>
        /// GridDisplay 
        /// </summary>
        public void GridDisplay()
        {
            try
            {
                ESLIssueComponent ObjESLComp = new ESLIssueComponent();
                EslForwardingNoteEntity ObjEslEntity = new EslForwardingNoteEntity();
                DataTable dt = new DataTable();
                string str = "EslManageGridDisplay";
                dt = ObjESLComp.SelectESLIssueGridComponent(str,null);

                //DataTable sortedDt = null;
                //dt.DefaultView.Sort = "dispatchDate" + " " + "ASC";
                //sortedDt = dt.DefaultView.ToTable();
                //dt = null;
                //sortedDt.DefaultView.Sort = "EslDate" + " " + "ASC";
                //dt = sortedDt.DefaultView.ToTable();
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

        protected void ESLRadgrid_PageIndexChanged(object source, GridPageChangedEventArgs e)
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtDatefrom.Text = string.Empty;
                txtDateto.Text = string.Empty;
                lblMessage.Visible = false;
                lblMessage.Text = "";
                GridDisplay();

            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Visible = false;
                lblMessage.Text = "";
                if (txtDatefrom.Text.ToString() != "" && txtDateto.Text.ToString() != "")
                {
                    if ((Convert.ToDateTime(txtDatefrom.Text)) > (Convert.ToDateTime(txtDateto.Text)))
                    {
                        ESLRadgrid.DataSource = null;
                        ESLRadgrid.DataBind();

                        lblMessage.Visible = true;
                        lblMessage.Text = "date to is less than and equal to date from";
                    }
                    else
                    {
                        DateTime dtfrom = Convert.ToDateTime(txtDatefrom.Text);
                        DateTime dtto = Convert.ToDateTime(txtDateto.Text);

                        bindgrid(dtfrom, dtto);
                    }
                }
                else if (txtDatefrom.Text.ToString() == "" && txtDateto.Text.ToString() == "")
                {
                    GridDisplay();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bindgrid(DateTime dtfrom, DateTime dtto)
        {
            try
            {
                lblMessage.Visible = false;
                lblMessage.Text = "";
                ESLIssueStatusComponent ObjStatus = new ESLIssueStatusComponent ();
                DataTable dt;
                dt = ObjStatus.SelectIssueStatusComp(dtfrom, dtto);
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
                    lblMessage.Text = "No Any Record ";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnValidateSample_Click(object sender, EventArgs e)
        {
            radWindowValidateBatch.Controls.Clear();
            radWindowValidateBatch.NavigateUrl = "EslValidateSample.aspx?Id=" + ((LinkButton)(sender)).CommandArgument;            
            radWindowValidateBatch.Visible = true;
            radWindowValidateBatch.VisibleStatusbar = false;
            radWindowValidateBatch.Behaviors = WindowBehaviors.Close;
            string script = "function f(){$find(\"" + radWindowValidateBatch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);         
        }




        //protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        ESLIssueComponent ObjESLComp = new ESLIssueComponent();
        //        ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
        //        DataTable dt = new DataTable();
        //         int Statusid = Convert.ToInt32(ddlstatus.SelectedValue);
        //         dt = ObjESLComp.SelectGridbyStatusComp(Statusid);
        //        if (dt.Rows.Count > 0)
        //        {
        //            lblMessage.Visible = false;
        //            ESLRadgrid.DataSource = dt;
        //            ESLRadgrid.DataBind();

        //        }
        //        else
        //        {
        //            ESLRadgrid.DataSource = null;
        //            ESLRadgrid.DataBind();   
        //            lblMessage.Visible = true;
        //            lblMessage.Text = "No Any Record";
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}






    }
}