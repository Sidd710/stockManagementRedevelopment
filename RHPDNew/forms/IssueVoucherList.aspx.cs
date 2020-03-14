using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RHPDNew.StockOutPanel
{
    public partial class IssueVoucherList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                bindgrid();
            }
        }


        public void bindgrid()
        {

            SqlCommand cmd = new SqlCommand("usp_getIssueVoucherList", con);
            cmd.CommandType = CommandType.StoredProcedure;
         if(con.State.ToString()=="Closed")
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
          
                rgdVoucherList.DataSource = dt;
                rgdVoucherList.DataBind();
                
           
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            bindgrid();
        }
        //public void bindprintgrid(String issuevoucherno)
        //{

        //    SqlCommand cmd = new SqlCommand("usp_GetIssueVoucherToPrint", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //   cmd.Parameters.AddWithValue("@issuevoucherNumber", issuevoucherno);
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        printgrid.DataSource = dt;
        //        printgrid.DataBind();
        //        printgrid.Visible = true;
        //    }
        //    else
        //    {
        //        printgrid.EmptyDataText = "No Record Found";
        //        printgrid.DataSource = null;
        //        printgrid.Visible = false;

        //    }
        //}


        //public static void PrintWebControl(Control ctrl)
        //{
        //    PrintWebControl(ctrl, string.Empty);
        //}

        //public static void PrintWebControl(Control ctrl, string Script)
        //{
        //    StringWriter stringWrite = new StringWriter();
        //    System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        //    if (ctrl is WebControl)
        //    {
        //        Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
        //    }
        //    Page pg = new Page();
        //    pg.EnableEventValidation = false;
        //    if (Script != string.Empty)
        //    {
        //        pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
        //    }
        //    HtmlForm frm = new HtmlForm();
        //    pg.Controls.Add(frm);
        //    frm.Attributes.Add("runat", "server");
        //    frm.Controls.Add(ctrl);
        //    pg.DesignerInitialize();
        //    pg.RenderControl(htmlWrite);
        //    string strHTML = stringWrite.ToString();
        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.Write(strHTML);
        //    HttpContext.Current.Response.Write("<script>window.print();</script>");
        //    HttpContext.Current.Response.End();
        //}

        protected void ff_Click(object sender, EventArgs e)
        {
           
            //bindprintgrid("Cat1/IV/1001 DT29-11-2015");
            //Session["ctrl"] = pnlContents;
            //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('issuevoucherlist.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
        }


        [WebMethod(EnableSession = true)]
        public static Vechile[] getissuevoucher(String issuevouchernumber)
        {
            DataTable dt = new DataTable();
            List<Vechile> details = new List<Vechile>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetIssueVoucherToPrint", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@issuevoucherNumber", issuevouchernumber);
                   
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        Vechile vechiledetail_ = new Vechile();
                        vechiledetail_.product_name = dtrow["product_name"].ToString();
                        vechiledetail_.productUnit = dtrow["productUnit"].ToString();
                        vechiledetail_.StockQuantity = dtrow["StockQuantity"].ToString();
                        vechiledetail_.Authority = dtrow["Authority"].ToString();
                        vechiledetail_.through = dtrow["through"].ToString();
                        details.Add(vechiledetail_);
                    }
                }
            }
            return details.ToArray();
        }
        public class Vechile
        {
            public string product_name { get; set; }
            public string productUnit { get; set; }
            public string StockQuantity { get; set; }
            public string Authority { get; set; }
            public string through { get; set; }



        }

        protected void rgdVoucherList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("usp_getIssueVoucherList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State.ToString() == "Closed")
                con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            rgdVoucherList.DataSource = dt;
        }
    }
}