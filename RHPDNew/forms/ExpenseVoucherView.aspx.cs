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
using Telerik.Web.UI;


namespace RHPDNew.Forms
{
    public partial class ExpenseVoucherView : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);


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
                    _BindData();
                }
            }
        }
        static public string ATSO = "";
        static public string LTNo = "";
        static public string Category_Name = "";
        static public string BathcNo = "";
        static public string Product_Name = "";
        static public double UsedQty = 0;
        static public string FormatFull = "";
        static public string FormatLoose = "";
        static public string Remarks = "";      
        static public double UsedFromFullPackets = 0;
        static public double RemainingQty = 0;
        private void _BindData()
        {
            try
            {
                if (Request.QueryString["evID"].ToString() != "")
                {
                    int id = Convert.ToInt32(Request.QueryString["evID"].ToString());

                    SqlCommand cmd = new SqlCommand("spExpenseVoucherSummary", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Action", "Summary");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Category_Name = dt.Rows[0]["Category_Name"].ToString();
                        BathcNo = dt.Rows[0]["BatchNo"].ToString();
                        Product_Name = dt.Rows[0]["Product_Name"].ToString();
                        UsedQty =double.Parse(dt.Rows[0]["UsedQty"].ToString());
                        RemainingQty = double.Parse(dt.Rows[0]["RemainingQty"].ToString());
                        UsedFromFullPackets = double.Parse(dt.Rows[0]["UsedFromFullPackets"].ToString());
                        FormatFull = dt.Rows[0]["FormatFull"].ToString();
                        FormatLoose = dt.Rows[0]["FormatLoose"].ToString();
                        Remarks = dt.Rows[0]["Remarks"].ToString();
                        ATSO = dt.Rows[0]["ATSONo"].ToString();
                        LTNo = dt.Rows[0]["Category_Name"].ToString() + "/" + dt.Rows[0]["ID"].ToString() + " dt" + Convert.ToDateTime(dt.Rows[0]["ExAddedOn"].ToString()).ToString("dd/MM/yyyy");
                        _GetSummary(dt);
                        rgdProduct.DataSource = dt;
                        rgdProduct.DataBind();
                      rgdPMConatainer.DataSource=  _GetPMConatiner(id);
                      rgdPMConatainer.DataBind();
                      
                    }
                }




            }
            catch (Exception)
            {

                throw;
            }
        }

        private DataTable _GetPMConatiner(int id)
        {
            try
            {
                 SqlCommand cmd = new SqlCommand("spExpenseVoucherSummary", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Action", "GetPMContiner");
                if(con.State.ToString()=="Closed")
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

   

        private void _GetSummary(DataTable dt)
        {
            try
            {

                DataTable dtFull = new DataTable();
                DataTable dtPM = new DataTable();
                DataTable dtSUBPM = new DataTable();
                dtFull = dt.Clone();
                dtPM = dt.Clone();
                dtSUBPM = dt.Clone();
                string PM = "";
                string SUBPM = "";
              
                double pmQty = 0;
                double subPMQty = 0;
                string sidMin = "";
                foreach (DataRow dr in dt.Rows)
                {

                    int PMCount = int.Parse(dr["PMCount"].ToString());

                    if (PMCount > 0)
                    {
                        int sid = int.Parse(dr["SID"].ToString());
                        sidMin = "-" + (sid + (10 * 10)).ToString();
                        rhpdEntities db = new rhpdEntities();
                        var lstSID = db.StockMasters.Where(s => s.SID == sid).FirstOrDefault();
                        if (lstSID != null)
                        {


                            if (lstSID.IsEmptyPM == true || lstSID.IsWithoutPacking == true || lstSID.IsDW == true)
                            {

                                dtFull.ImportRow(dr);
                            }
                            else
                            {

                                dtFull.ImportRow(dr);
                                DataTable dtPMC = new DataTable();
                                int id = Convert.ToInt32(Request.QueryString["evID"].ToString());
                                dtPMC = _GetPMConatiner(id);
                                foreach (DataRow drPMC in dtPMC.Rows)
                                {

                                    if (PM != drPMC["MaterialName"].ToString())
                                    {

                                        if (pmQty > 0)
                                            dtPM.Rows.Add(0, 0, 0, int.Parse(sidMin), PM, "Nos", ATSO, 0, 0, 0, pmQty, "", "", "", pmQty, DateTime.Now, BathcNo, Category_Name, 0, DateTime.Now, DateTime.Now, DateTime.Now);

                                        PM = drPMC["MaterialName"].ToString();

                                        pmQty = double.Parse(drPMC["Quantity"].ToString());

                                        //string[] full = dr["FormatFull"].ToString().Split('X');
                                        //string[] loose = dr["FormatLoose"].ToString().Split('|');
                                        //if (full.Count() > 0 && full[0].ToString() != "")
                                        //    pmQty = pmQty + double.Parse(full[0]);
                                        //if (loose.Count() > 0 && loose[0].ToString() != "")
                                        //    pmQty = pmQty + double.Parse(loose[0]);



                                    }
                                    else
                                    {

                                        //string[] full = dr["FormatFull"].ToString().Split('X');
                                        //string[] loose = dr["FormatLoose"].ToString().Split('|');
                                        //if (full.Count() > 0 && full[0].ToString() != "")
                                        //    pmQty = pmQty + double.Parse(full[0]);
                                        //if (loose.Count() > 0 && loose[0].ToString() != "")
                                        //    pmQty = pmQty + double.Parse(loose[0]);
                                        pmQty = pmQty + double.Parse(drPMC["Quantity"].ToString());

                                    }


                                    //if (lstSID.IsSubPacking == true)
                                    //{
                                    //    if (SUBPM != lstSID.SubPMName)
                                    //    {

                                    //        if (subPMQty > 0)
                                    //            dtSUBPM.Rows.Add(0, 0, 0, int.Parse(sidMin), SUBPM, "Nos", ATSO, 0, 0, 0, 0, "", "", "", subPMQty, DateTime.Now, BathcNo, Category_Name, 0);

                                    //        SUBPM = lstSID.SubPMName;
                                    //        subPMQty = 0;

                                    //        string[] full = dr["FormatFull"].ToString().Split('X');
                                    //        string[] loose = dr["FormatLoose"].ToString().Split('|');
                                    //        if (full.Count() > 1 && full[1].ToString() != "")
                                    //            subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
                                    //        if (loose.Count() > 1 && loose[1].ToString() != "")
                                    //            subPMQty = subPMQty + double.Parse(loose[1]);
                                    //    }
                                    //    else
                                    //    {
                                    //        string[] full = dr["FormatFull"].ToString().Split('X');
                                    //        string[] loose = dr["FormatLoose"].ToString().Split('|');
                                    //        if (full.Count() > 1 && full[1].ToString() != "")
                                    //            subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
                                    //        if (loose.Count() > 1 && loose[1].ToString() != "")
                                    //            subPMQty = subPMQty + double.Parse(loose[1]) + double.Parse(loose[0]);

                                    //    }
                                    //}
                                }

                            }
                        }
                    }
                    else
                        dtFull.ImportRow(dr);

                    
                }
                if (pmQty > 0)
                {

                    if (pmQty > 0)
                        dtPM.Rows.Add(0, 0, 0, int.Parse(sidMin), PM, "Nos", ATSO, 0, 0, 0, pmQty, "", "", "", pmQty, DateTime.Now, BathcNo, Category_Name, 0, DateTime.Now, DateTime.Now, DateTime.Now);

                    PM = "";

                    pmQty = 0;
                }
               
                dtFull.Merge(dtPM);
               // dtFull.Merge(dtSUBPM);

                rgdSummary.DataSource = dtFull;
                rgdSummary.DataBind();

                foreach (GridDataItem rgd in rgdSummary.MasterTableView.Items)
                {
                    int key = int.Parse(rgd.GetDataKeyValue("Product_ID").ToString());
                    if (key < 0)
                    {
                        Table tblBatch = (Table)rgd.FindControl("tblBatch");
                        tblBatch.Visible = false;
                    }
                }
                GridFooterItem footeritemFull = (GridFooterItem)rgdSummary.MasterTableView.GetItems(GridItemType.Footer)[0];
                double cost = 0;
                
                double qty = 0;
                foreach (DataRow dr in dtFull.Rows)
                {
                    if (cost == 0)
                    cost = double.Parse(dr["VCost"].ToString());
                    qty = qty + double.Parse(dr["UsedQty"].ToString());
                }
               
                Label lblTotalQty = (Label)footeritemFull.FindControl("lblTotalQty");
                lblTotalQty.Text = qty.ToString("0.000");
              



            }
            catch (Exception)
            {

                throw;
            }
        }




        public string TruncateDecimalToString(double value, int digit)
        {
            try
            {
                double step = (double)Math.Pow(10, digit);
                double tmp = (double)Math.Truncate(step * value);
                if (digit == 2)
                    return (tmp / step).ToString("0.00");
                else
                    return (tmp / step).ToString("0.000");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public double TruncateDecimal(double value, int digit)
        {
            try
            {
                double step = (double)Math.Pow(10, digit);
                double tmp = (double)Math.Truncate(step * value);
                return tmp / step;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rgdCRV_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        protected void rgdProduct_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {

                    GridDataItem item = (e.Item as GridDataItem);
                    int productID = int.Parse(item.GetDataKeyValue("ProductId").ToString());
                    RadGrid rgdBatch = (RadGrid)item.FindControl("rgdBatch");



                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void lbtnPRint_Click(object sender, EventArgs e)
        {
            int ltID = Convert.ToInt32(Request.QueryString["evID"].ToString());
            Response.Redirect("../Forms/ExpenseVoucherPrint.aspx?evID=" + ltID);
        }

        protected void rgdVehicle_ItemCreated(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (e.Item as GridDataItem);
                    int vId = int.Parse(item.GetDataKeyValue("Id").ToString());
                    RadGrid rgdProduct1 = (RadGrid)item.FindControl("rgdProduct");
                    SqlCommand cmd = new SqlCommand("usp_GetIssueVoucherProductByVehicle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", vId);
                    if (con.State.ToString() == "Closed")
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rgdProduct1.DataSource = dt;
                    rgdProduct1.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
  
    }
}