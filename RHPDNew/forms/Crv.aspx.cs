using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDEntity;
using RHPDComponent;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class Crvpx : System.Web.UI.Page
    {
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
                        txtDatefrom.Text = txtDateto.Text = DateTime.Now.ToString("dd MMM yyyy");
                        DateTime dtfrom = Convert.ToDateTime(txtDatefrom.Text);
                        DateTime dtto = Convert.ToDateTime(txtDateto.Text);
                        bindgrid(dtfrom, dtto);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void bindgrid(DateTime dtfrom,DateTime dtto)
        {
            try
            {
                lblMessage.Visible = false;
                lblMessage.Text = "";

                DataTable dt;
                ManagestockComp obj = new ManagestockComp();
                dt= obj.selectcrv(dtfrom, dtto);
                if (dt.Rows.Count > 0)
                {
                    radCrvp.DataSource = dt;
                    radCrvp.DataBind();
                }
                else
                {
                    radCrvp.DataSource = null;
                    radCrvp.DataBind();
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Any Record ";
                }
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
                        radCrvp.DataSource = null;
                        radCrvp.DataBind();

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
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                radCrvp.ExportSettings.ExportOnlyData = true;
                radCrvp.ExportSettings.IgnorePaging = true;
                radCrvp.ExportSettings.OpenInNewWindow = true;
                radCrvp.ExportSettings.FileName = "Crvp" + DateTime.Now.Date.ToString();

                radCrvp.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtDatefrom.Text = string.Empty;
            txtDateto.Text = string.Empty;
            lblMessage.Visible = false;
            lblMessage.Text = "";
        }
    }
}