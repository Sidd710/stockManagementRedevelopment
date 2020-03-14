using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class frmIndentDetails : System.Web.UI.Page
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

                    getDetails();

                }
            }
        }
        private void getDetails()
        {
            try
            {
                if (Request.QueryString["iId"]!= null)
                {
                    IndentComponent cmp = new IndentComponent();
                    RadGrid.DataSource = cmp.GetResultIndentdetails(int.Parse(Request.QueryString["iID"].ToString()));
                    RadGrid.DataBind();

                    DataTable dt = new DataTable();
                    dt = cmp.checkIsapproved(int.Parse(Request.QueryString["iID"].ToString()));
                    if ((dt.Rows[0]["IsApproved"]).ToString() == null || (dt.Rows[0]["IsApproved"]).ToString() == "")
                  {
                      btnApprove.Visible = true;
                      btnReject.Visible = true;

                  }
                    else
                  {
                      btnApprove.Visible = false;
                      btnReject.Visible = false;
                  }

                }
                else if (Request.QueryString["iId"] == null)
                {
                    Response.Redirect("FrmViewindent.aspx");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                IndentComponent cmp = new IndentComponent();
                IndentEntity indentity = new IndentEntity();
                indentity.Id = int.Parse(Request.QueryString["iID"].ToString());
                indentity.IsApproved = true;
                cmp.UpdateIndent(indentity);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Indent Approve successfully!');", true);
                getDetails();
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {

            
            IndentComponent cmp = new IndentComponent();
            IndentEntity indentity = new IndentEntity();          
            indentity.Id = int.Parse(Request.QueryString["iID"].ToString());
            indentity.IsApproved = false;
            cmp.UpdateIndent(indentity);
            DataTable dt = new DataTable();
            dt = cmp.GetResultIndentdetails(int.Parse(Request.QueryString["iID"].ToString()));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AddProductComp pCmp = new AddProductComp();
                pCmp.UpdateQuantity(int.Parse(dt.Rows[i]["ProductMasterId"].ToString()), int.Parse(dt.Rows[i]["QtyIssued"].ToString()));
               
              
            }
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Indent Reject successfully!');", true);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}