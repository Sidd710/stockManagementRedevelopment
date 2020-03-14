using RHPDComponent;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class frmTallyDetails : System.Web.UI.Page
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
                    //getDetails();
                    griddisplay();

                }
            }
        }

        public void griddisplay()
        {
            try
            {
                DataTable dt3 = new DataTable();
                TallySheetComponent cmp = new TallySheetComponent();
                dt3 = cmp.GridDisplayfortally();
                RadGrid.DataSource = dt3;
                RadGrid.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

       

        
    }
}