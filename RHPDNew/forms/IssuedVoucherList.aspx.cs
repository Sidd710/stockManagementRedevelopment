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
    public partial class IssuedVoucherList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void bindgrid(DateTime froms, DateTime to)
        {
            try
            {
                IssueVocuherEntity objentity = new IssueVocuherEntity();
                IssueVoucherComponent objcom = new IssueVoucherComponent();
                objentity.Action = "Selectfromto";
                objentity.Addedon = froms;
                objentity.Modifiedon = to;
                DataTable dt = objcom.SelectIssuedVoucherfromto(objentity);
                if (dt.Rows.Count > 0)
                {
                    radIssuedVoucher.DataSource = dt;
                    radIssuedVoucher.DataBind();
                }
                else
                {
                    radIssuedVoucher.DataSource = null;
                    radIssuedVoucher.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void radIssuedVoucher_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            try
            {
                radIssuedVoucher.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void radIssuedVoucher_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                IssueVocuherEntity objentity = new IssueVocuherEntity();
                IssueVoucherComponent objcom = new IssueVoucherComponent();
                objentity.Action = "Selectfromto";
                objentity.Addedon = Convert.ToDateTime(txtDatefrom.Text);
                objentity.Modifiedon = Convert.ToDateTime(txtDateto.Text);
                DataTable dt = objcom.SelectIssuedVoucherfromto(objentity);
                if (dt.Rows.Count > 0)
                {
                    radIssuedVoucher.DataSource = dt;
                }
                else
                {
                    radIssuedVoucher.DataSource = null;
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
                radIssuedVoucher.ExportSettings.ExportOnlyData = true;
                radIssuedVoucher.ExportSettings.IgnorePaging = true;
                radIssuedVoucher.ExportSettings.OpenInNewWindow = true;
                radIssuedVoucher.ExportSettings.FileName = "Esl_List" + DateTime.Now.Date.ToString();

                radIssuedVoucher.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
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
                        radIssuedVoucher.DataSource = null;
                        radIssuedVoucher.DataBind();

                        lblMessage.Visible = true;
                        lblMessage.Text = "date to is less than and equal to date from";
                    }
                    else
                    {
                        DateTime dtfrom = Convert.ToDateTime(txtDatefrom.Text);
                        DateTime dtto = Convert.ToDateTime(txtDateto.Text);
                        radIssuedVoucher.DataSourceID = "";
                        bindgrid(dtfrom, dtto);
                    }
                }
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