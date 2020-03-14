using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Web.SessionState;
using System;

namespace RHPDNew.StockOutPanel
{
    public partial class issueidtList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
            }
        }

        public void bindgrid()
        {

            SqlCommand cmd = new SqlCommand("usp_getIssueIdtdetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                IssueIDTgrid_.DataSource = dt;
                IssueIDTgrid_.DataBind();
                IssueIDTgrid_.Visible = true;
            }
            else
            {
                IssueIDTgrid_.EmptyDataText = "No Record Found";
                IssueIDTgrid_.DataSource = null;
                IssueIDTgrid_.Visible = false;

            }
        }

    }
}