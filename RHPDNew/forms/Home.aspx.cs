using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class Home : System.Web.UI.Page
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

                    UpdateHome();
                }
            }
        }

        private void UpdateHome()
        {
            try
            {
                if(Session["UserDetails"]!=null)
                {
                    DataTable dt = new DataTable();
                    dt = Session["UserDetails"] as DataTable;
                    if (dt.Rows.Count > 0)
                    { 

                    
                    }
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}