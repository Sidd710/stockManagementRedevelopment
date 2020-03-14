using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew
{
    public partial class RHPD : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack){
               if (Session["UserDetails"] != null)
               {
               // LbtnLogout.Visible=true;
               }
               else
               {
                // LbtnLogout.Visible=false;
               }
            }
        }

        protected void LbtnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}