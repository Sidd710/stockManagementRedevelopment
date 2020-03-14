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
    public partial class LoadTallyView : System.Web.UI.Page
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
                if (Request.QueryString["ltNo"] != null)
                {
                    int ltID = Convert.ToInt32(Request.QueryString["ltNo"].ToString());
                    rhpdEntities db = new rhpdEntities();
                    var lt = db.tbl_loadtallydetail.Where(l => l.Id == ltID).FirstOrDefault();
                    if (lt != null)
                    {
                        LTNo = lt.loadtallyNumber;
                        UnitNio = lt.UnitNo;
                        Authority = lt.Authority;
                        var sumQty = db.tblIssueVoucherVehicleDetails.Where(v => v.issueorderID == lt.IssueorderId && v.VehicleNo == lt.vechileNo).Sum(v => v.StockQuantity);
                        if (sumQty != null)
                            StockQty =Convert.ToDouble(sumQty);
                        var ltList = db.tbl_loadtaly.Where(l => l.loadtallyNumber == lt.loadtallyNumber && l.IssueorderId == lt.IssueorderId && l.vechileNo == lt.vechileNo).ToList();
                        var vehList = db.tbl_vechileMaster.Where(v => v.VechileNumber == lt.vechileNo).FirstOrDefault();
                        if(vehList!=null)
                        {
                            var vType = db.tbl_vechileMaster_Type.Where(vt => vt.VtypeId == vehList.vechileType).FirstOrDefault();
                            if (vType != null)
                                VehicleType = vType.Vtypename;
                            VechileNumber = vehList.VechileNumber;
                           // Rank = vehList.Rank;
                            DriverName = vehList.DriverName;
                            Through = vehList.Through;
                            ArmyNo = vehList.ArmyNo;
                            DataTable dt = new DataTable();
                            dt = _GetLoadTallyData(ltID);
                            ProductCount = dt.Rows.Count;
                            rgdProduct.DataSource = dt;
                            rgdProduct.DataBind();
                            _GetSummary(dt);
                        }
                    }
        
                }

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
                string ATSO = "";
                string IDTICT = "";
                string IV = "";

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
                                    dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO);

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
                            }


                            if (lstSID.IsSubPacking == true)
                            {
                                if (SUBPM != lstSID.SubPMName)
                                {

                                    if (subPMQty > 0)
                                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO);

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
                        dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO);

                    PM = "";

                    pmQty = 0;
                }
                if (subPMQty > 0)
                {
                    sidMin = (1 + (int.Parse(sidMin))).ToString();
                    if (subPMQty > 0)
                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO);

                    SUBPM = "";
                    subPMQty = 0;
                }
                dtFull.Merge(dtPM);
                dtFull.Merge(dtSUBPM);
              
                rgdSummary.DataSource = dtFull;
                rgdSummary.DataBind();
                foreach (GridDataItem rgd in rgdSummary.MasterTableView.Items)
                {
                    int key = int.Parse(rgd.GetDataKeyValue("ProductId").ToString());
                    if (key < 0)
                    {
                        Table tblBatch = (Table)rgd.FindControl("tblBatch");
                        tblBatch.Visible = false;
                    }
                }
                GridFooterItem footeritemFull = (GridFooterItem)rgdSummary.MasterTableView.GetItems(GridItemType.Footer)[0];
                double cost = 0;
                double weight = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    cost = cost + double.Parse(dr["VCost"].ToString());
                    weight = weight + double.Parse(dr["vWeight"].ToString());
                }
                Label lblWeight = (Label)footeritemFull.FindControl("lblWeight");
                Label lblCost = (Label)footeritemFull.FindControl("lblCost");
                
                Label lblTotalQty = (Label)footeritemFull.FindControl("lblTotalQty");
                lblTotalQty.Text =double.Parse(dt.Rows[0]["sumQty"].ToString()).ToString("0.000");
                lblWeight.Text=weight.ToString("0.000");
                lblCost.Text = cost.ToString("0.00");
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private DataTable _GetLoadTallyData(int ltNo)
        {
            try
            {
                 DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetLoadTallyData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@LTId", ltNo);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
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
            int ltID = Convert.ToInt32(Request.QueryString["ltNo"].ToString());
            Response.Redirect("../StockOutPanel/PrintLoadTally.aspx?ltNo=" + ltID);
        }
  
    }
}