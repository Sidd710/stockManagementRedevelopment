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

namespace Demo1
{
    public partial class loadTallyList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
            }

            
        }

        public DataTable _bindgrid2()
        {

            SqlCommand cmd = new SqlCommand("usp_getLoadTallyList", con);
            cmd.CommandType = CommandType.StoredProcedure;
           // con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            

        }
        public void bindgrid()
        {

            SqlCommand cmd = new SqlCommand("usp_getVechile_prdquantity", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataTable dtLoad = new DataTable();
            dtLoad = _bindgrid2();
            bool exists = false;
            DataTable dtFinal = new DataTable();
            dtFinal = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            { 
                foreach (DataRow drL in dtLoad.Rows)
            {
                if (dr["VehicleNo"].ToString() == drL["VechileNo"].ToString() && drL["Status"].ToString() == "Active")
                {                  
                  exists = true;
                }
                


            }
                if (exists == false)
                {
                    dtFinal.ImportRow(dr);
                }
                exists = false;
            }

            if (dt.Rows.Count > 0)
            {
                VechileListGrid_.DataSource = dtFinal;
                VechileListGrid_.DataBind();
                VechileListGrid_.Visible = true;
            }
            else
            {
                VechileListGrid_.EmptyDataText = "No Record Found";
                VechileListGrid_.DataSource = null;
                VechileListGrid_.Visible = false;

            }


        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            bindgrid();
        }

        protected void VechileListGrid__RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                        Label lbl = e.Row.Cells[1].FindControl("lblFO") as Label;                      
                       
                    if (lbl.Text == "Yes")
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                        e.Row.Font.Bold = true;
                    }
                    RHPDNew.rhpdEntities db = new RHPDNew.rhpdEntities();
                   // var tl=db.tbl_loadtaly.Where()
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}