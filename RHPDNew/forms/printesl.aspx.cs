using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class printesl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ManagestockComp obj = new ManagestockComp();
                DataTable dt = obj.Selectwithid("Selectwithid", Convert.ToInt32(Request.QueryString["id"]));
                if (dt.Rows.Count > 0)
                {
                    RadGrid.DataSource = dt;
                    RadGrid.DataBind();
                }
                else
                {
                    RadGrid.DataSource = null;
                    RadGrid.DataBind();
                }
            }
        }
    }
}