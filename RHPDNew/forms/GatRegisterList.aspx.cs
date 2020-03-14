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
    public partial class GatRegisterList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {

                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
        private void bindgrid(DateTime froms,DateTime to)
        {
            try
            {
                GatEntity objentity = new GatEntity();
                GatComponent objcom = new GatComponent();
                objentity.Action = "Selectfromto";
                objentity.AddedOn = froms;
                objentity.ModifiedOn1 = to;
                DataTable dt = objcom.Selectedgateformto(objentity);
                if (dt.Rows.Count > 0)
                {
                    radGateout.DataSource = dt;
                    radGateout.DataBind();
                }
                else
                {
                    radGateout.DataSource = null;
                    radGateout.DataBind();
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
                radGateout.ExportSettings.ExportOnlyData = true;
                radGateout.ExportSettings.IgnorePaging = true;
                radGateout.ExportSettings.OpenInNewWindow = true;
                radGateout.ExportSettings.FileName = "Esl_List" + DateTime.Now.Date.ToString();

                radGateout.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void radGateout_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                GatEntity objentity = new GatEntity();
                GatComponent objcom = new GatComponent();
                objentity.Action = "Selectfromto";
                objentity.AddedOn = Convert.ToDateTime(txtDatefrom.Text);
                objentity.ModifiedOn1 =Convert.ToDateTime(txtDateto.Text);
                DataTable dt = objcom.Selectedgateformto(objentity);
                if (dt.Rows.Count > 0)
                {
                    radGateout.DataSource = dt;
                }
                else
                {
                    radGateout.DataSource = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void radGateout_PageIndexChanged1(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            try
            {
                radGateout.DataBind();
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
                        radGateout.DataSource = null;
                        radGateout.DataBind();

                        lblMessage.Visible = true;
                        lblMessage.Text = "date to is less than and equal to date from";
                    }
                    else
                    {
                        DateTime dtfrom = Convert.ToDateTime(txtDatefrom.Text);
                        DateTime dtto = Convert.ToDateTime(txtDateto.Text);
                        radGateout.DataSourceID = "";
                        bindgrid(dtfrom, dtto);
                        //radGateout.DataBind();
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