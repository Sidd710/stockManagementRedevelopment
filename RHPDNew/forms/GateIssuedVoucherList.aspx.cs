using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class GateIssuedVoucherList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            { }
        }
        protected void radIssueVoucher_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            try
            {
                radIssueVoucher.DataBind();
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
                radIssueVoucher.ExportSettings.ExportOnlyData = true;
                radIssueVoucher.ExportSettings.IgnorePaging = true;
                radIssueVoucher.ExportSettings.OpenInNewWindow = true;
                radIssueVoucher.ExportSettings.FileName = "Esl_List" + DateTime.Now.Date.ToString();

                radIssueVoucher.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}