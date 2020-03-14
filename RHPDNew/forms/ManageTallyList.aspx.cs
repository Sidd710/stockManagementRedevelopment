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
    public partial class ManageTallyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void bindgrid(DateTime froms, DateTime to)
        {
            try
            {
                TallySheetEntity objentity = new TallySheetEntity();
                TallySheetComponent objcom = new TallySheetComponent();
                objentity.Action = "Selectfromto";
                objentity.Addedon = froms;
                objentity.ModifiedOn = to;
                DataTable dt = objcom.SelectTallyfromto(objentity);
                if (dt.Rows.Count > 0)
                {
                    radTallyList.DataSource = dt;
                    radTallyList.DataBind();
                }
                else
                {
                    radTallyList.DataSource = null;
                    radTallyList.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void radTallyList_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            try
            {
                radTallyList.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void radTallyList_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                TallySheetEntity objentity = new TallySheetEntity();
                TallySheetComponent objcom = new TallySheetComponent();
                objentity.Action = "Selectfromto";
                objentity.Addedon = Convert.ToDateTime(txtDatefrom.Text);
                objentity.ModifiedOn = Convert.ToDateTime(txtDateto.Text);
                DataTable dt = objcom.SelectTallyfromto(objentity);
                if (dt.Rows.Count > 0)
                {
                    radTallyList.DataSource = dt;
                }
                else
                {
                    radTallyList.DataSource = null;
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
                radTallyList.ExportSettings.ExportOnlyData = true;
                radTallyList.ExportSettings.IgnorePaging = true;
                radTallyList.ExportSettings.OpenInNewWindow = true;
                radTallyList.ExportSettings.FileName = "Esl_List" + DateTime.Now.Date.ToString();

                radTallyList.MasterTableView.ExportToExcel();
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
                        radTallyList.DataSource = null;
                        radTallyList.DataBind();

                        lblMessage.Visible = true;
                        lblMessage.Text = "date to is less than and equal to date from";
                    }
                    else
                    {
                        DateTime dtfrom = Convert.ToDateTime(txtDatefrom.Text);
                        DateTime dtto = Convert.ToDateTime(txtDateto.Text);
                        radTallyList.DataSourceID = "";
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