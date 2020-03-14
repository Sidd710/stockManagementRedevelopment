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

namespace RHPDNew.StockOutPanel
{
    public partial class IssueVoucherView : System.Web.UI.Page
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
        static public string LTNo = "";
        static public string VehicleType = "";
        static public string UnitNio = "";
        static public string Authority = "";
        static public string VechileNumber = "";
        static public string Through = "";
        static public string DriverName = "";
        static public string ArmyNo = "";
        static public string Rank = "";

        static public double StockQty = 0;
        static public int ProductCount = 0;
        private void _BindData()
        {
            try
            {
                if (Request.QueryString["ivNo"].ToString() != "")
                {
                    int id = Convert.ToInt32(Request.QueryString["ivNo"].ToString());

                    SqlCommand cmd = new SqlCommand("usp_GetIssueVoucherToPrint", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Authority = dt.Rows[0]["Authority"].ToString();
                        UnitNio = dt.Rows[0]["UnitNo"].ToString();
                        Through = dt.Rows[0]["through"].ToString();
                        LTNo = dt.Rows[0]["IssueVoucherId"].ToString();
                        _GetSummary(dt);
                        rgdProduct.DataSource = dt;
                        rgdProduct.DataBind();

                        _GetVehicle(id);

                    }
                }

              


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void _GetVehicle(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetIssueVoucherVehicle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                if(con.State.ToString()=="Closed")
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rgdVehicle.DataSource = dt;
                rgdVehicle.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //private void _GetSummary(DataTable dt)
        //{
        //    try
        //    {

        //        DataTable dtFull = new DataTable();
        //        DataTable dtPM = new DataTable();
        //        DataTable dtSUBPM = new DataTable();
        //        dtFull = dt.Clone();
        //        dtPM = dt.Clone();
        //        dtSUBPM = dt.Clone();
        //        string PM = "";
        //        string SUBPM = "";
        //        string ATSO = "";
        //        string IDTICT = "";
        //        var Dom = "";
        //        var Esl = "";
        //        string IV = "";
        //        double pmQty = 0;
        //        double subPMQty = 0;
        //        string sidMin = "";
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            int sid = int.Parse(dr["SID"].ToString());
        //            sidMin = "-" + (sid + (10 * 10)).ToString();
        //            rhpdEntities db = new rhpdEntities();
        //            var lstSID = db.StockMasters.Where(s => s.SID == sid).FirstOrDefault();
        //            if (lstSID != null)
        //            {
        //                if (lstSID.IsEmptyPM == true || lstSID.IsWithoutPacking == true || lstSID.IsDW == true)
        //                {

        //                    dtFull.ImportRow(dr);
        //                }
        //                else
        //                {

        //                    dtFull.ImportRow(dr);

        //                    if (PM != lstSID.PackingMaterial)
        //                    {

        //                        if (pmQty > 0)
        //                            dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", Dom, Esl, 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");

        //                        PM = lstSID.PackingMaterial;

        //                        pmQty = 0;

        //                        string[] full = dr["FormatFull"].ToString().Split('X');
        //                        string[] loose = dr["FormatLoose"].ToString().Split('|');
        //                        if (full.Count() > 0 && full[0].ToString() != "")
        //                            pmQty = pmQty + double.Parse(full[0]);
        //                        if (loose.Count() > 0 && loose[0].ToString() != "")
        //                            pmQty = pmQty + double.Parse(loose[0]);
        //                        ATSO = dr["ATSONo"].ToString();
        //                        IDTICT = dr["IDTICTAWS"].ToString();
        //                        IV = dr["IssueVoucherId"].ToString();

        //                    }
        //                    else
        //                    {

        //                        string[] full = dr["FormatFull"].ToString().Split('X');
        //                        string[] loose = dr["FormatLoose"].ToString().Split('|');
        //                        if (full.Count() > 0 && full[0].ToString() != "")
        //                            pmQty = pmQty + double.Parse(full[0]);
        //                        if (loose.Count() > 0 && loose[0].ToString() != "")
        //                            pmQty = pmQty + double.Parse(loose[0]);
        //                        ATSO = dr["ATSONo"].ToString();
        //                        IDTICT = dr["IDTICTAWS"].ToString();
        //                        IV = dr["IssueVoucherId"].ToString();
        //                    }


        //                    if (lstSID.IsSubPacking == true)
        //                    {
        //                        if (SUBPM != lstSID.SubPMName)
        //                        {

        //                            if (subPMQty > 0)
        //                                dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, "", Dom, Esl, 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

        //                            SUBPM = lstSID.SubPMName;
        //                            subPMQty = 0;

        //                            string[] full = dr["FormatFull"].ToString().Split('X');
        //                            string[] loose = dr["FormatLoose"].ToString().Split('|');
        //                            if (full.Count() > 1 && full[1].ToString() != "")
        //                                subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
        //                            if (loose.Count() > 1 && loose[1].ToString() != "")
        //                                subPMQty = subPMQty + double.Parse(loose[1]);
        //                        }
        //                        else
        //                        {
        //                            string[] full = dr["FormatFull"].ToString().Split('X');
        //                            string[] loose = dr["FormatLoose"].ToString().Split('|');
        //                            if (full.Count() > 1 && full[1].ToString() != "")
        //                                subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
        //                            if (loose.Count() > 1 && loose[1].ToString() != "")
        //                                subPMQty = subPMQty + double.Parse(loose[1]) + double.Parse(loose[0]);

        //                        }
        //                    }
        //                }

        //            }

        //        }
        //        if (pmQty > 0)
        //        {

        //            if (pmQty > 0)
        //                dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", Dom, Esl, 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");

        //            PM = "";

        //            pmQty = 0;
        //        }
        //        if (subPMQty > 0)
        //        {
        //            sidMin = (1 + (int.Parse(sidMin))).ToString();
        //            if (subPMQty > 0)
        //                dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, "", Dom, Esl, 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

        //            SUBPM = "";
        //            subPMQty = 0;
        //        }
        //        dtFull.Merge(dtPM);
        //        dtFull.Merge(dtSUBPM);
               
        //        rgdSummary.DataSource = dtFull;
        //        rgdSummary.DataBind();

        //        foreach (GridDataItem rgd in rgdSummary.MasterTableView.Items)
        //        {
        //            int key = int.Parse(rgd.GetDataKeyValue("ProductId").ToString());
        //            if (key < 0)
        //            {
        //                Table tblBatch = (Table)rgd.FindControl("tblBatch");
        //                tblBatch.Visible = false;
        //            }
        //        }
        //        GridFooterItem footeritemFull = (GridFooterItem)rgdSummary.MasterTableView.GetItems(GridItemType.Footer)[0];
        //        double cost = 0;
        //        double weight = 0;
        //        double qty = 0;
        //        foreach (DataRow dr in dtFull.Rows)
        //        {
        //            cost = cost + double.Parse(dr["VCost"].ToString());
        //            weight = weight + double.Parse(dr["vWeight"].ToString());
        //            qty = qty + double.Parse(dr["stockquantity"].ToString());
        //        }
        //        Label lblWeight = (Label)footeritemFull.FindControl("lblWeight");
        //        Label lblCost = (Label)footeritemFull.FindControl("lblCost");

        //        Label lblTotalQty = (Label)footeritemFull.FindControl("lblTotalQty");
        //        lblTotalQty.Text = qty.ToString("0.000");
        //        lblWeight.Text = "Weight: " + weight.ToString("0.000");
        //        lblCost.Text = "Cost: " + cost.ToString("0.00");
             
              
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

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
                string ATSO = "";
                string IDTICT = "";
                string IV = "";
                string Dom = "";
                string Esl = "";
                double pmQty = 0;
                double subPMQty = 0;
                string sidMin = "";
                foreach (DataRow dr in dt.Rows)
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

                            if (PM != lstSID.PackingMaterial)
                            {

                                if (pmQty > 0)
                                    dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, Dom, Esl, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");

                                PM = lstSID.PackingMaterial;

                                pmQty = 0;

                                string[] full = dr["FormatFull"].ToString().Split('X');
                                string[] loose = dr["FormatLoose"].ToString().Split('|');
                                if (full.Count() > 0 && full[0].ToString() != "")
                                    pmQty = pmQty + double.Parse(full[0]);
                                if (loose.Count() > 0 && loose[0].ToString() != "")
                                    pmQty = pmQty + double.Parse(loose[0]);
                                ATSO = dr["ATSONo"].ToString();
                                IDTICT = dr["IDTICTAWS"].ToString();
                                IV = dr["IssueVoucherId"].ToString();
                                Dom = dr["DOM"].ToString();
                                Esl = dr["ESL"].ToString();


                            }
                            else
                            {

                                string[] full = dr["FormatFull"].ToString().Split('X');
                                string[] loose = dr["FormatLoose"].ToString().Split('|');
                                if (full.Count() > 0 && full[0].ToString() != "")
                                    pmQty = pmQty + double.Parse(full[0]);
                                if (loose.Count() > 0 && loose[0].ToString() != "")
                                    pmQty = pmQty + double.Parse(loose[0]);
                                ATSO = dr["ATSONo"].ToString();
                                IDTICT = dr["IDTICTAWS"].ToString();
                                IV = dr["IssueVoucherId"].ToString();
                                Dom = dr["DOM"].ToString();
                                Esl = dr["ESL"].ToString();

                            }


                            if (lstSID.IsSubPacking == true)
                            {
                                if (SUBPM != lstSID.SubPMName)
                                {

                                    if (subPMQty > 0)
                                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, Dom, Esl, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

                                    SUBPM = lstSID.SubPMName;
                                    subPMQty = 0;

                                    string[] full = dr["FormatFull"].ToString().Split('X');
                                    string[] loose = dr["FormatLoose"].ToString().Split('|');
                                    if (full.Count() > 1 && full[1].ToString() != "")
                                        subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
                                    if (loose.Count() > 1 && loose[1].ToString() != "")
                                        subPMQty = subPMQty + double.Parse(loose[1]);
                                }
                                else
                                {
                                    string[] full = dr["FormatFull"].ToString().Split('X');
                                    string[] loose = dr["FormatLoose"].ToString().Split('|');
                                    if (full.Count() > 1 && full[1].ToString() != "")
                                        subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
                                    if (loose.Count() > 1 && loose[1].ToString() != "")
                                        subPMQty = subPMQty + double.Parse(loose[1]) + double.Parse(loose[0]);

                                }
                            }
                        }

                    }

                }
                if (pmQty > 0)
                {

                    if (pmQty > 0)
                        dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", Dom, Esl, 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");

                    PM = "";

                    pmQty = 0;
                }
                if (subPMQty > 0)
                {
                    sidMin = (1 + (int.Parse(sidMin))).ToString();
                    if (subPMQty > 0)
                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, "", Dom, Esl, 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

                    SUBPM = "";
                    subPMQty = 0;
                }
                dtFull.Merge(dtPM);
                dtFull.Merge(dtSUBPM);

                rgdSummary.DataSource = dtFull;
                rgdSummary.DataBind();
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
            int ltID = Convert.ToInt32(Request.QueryString["ivNo"].ToString());
            Response.Redirect("../StockOutPanel/IssueVoucherPrintScreen.aspx?ivNo=" + ltID);
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