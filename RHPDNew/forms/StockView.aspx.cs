using RHPDDalc;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using Telerik.Web.UI;
using System.Web.Services;
using System.Configuration;
using System.Text;
using System.Globalization;
using System.Threading;

namespace RHPDNew.Forms
{
    public partial class StockView : System.Web.UI.Page
    {
        CultureInfo InCulture = new CultureInfo("hi-IN");

        public static string AU = "";
        public static int Case = 0;
        public static string stcokCase = "";
        public static string CRVNo = "";
        public static int pID = 0;
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
        protected void rgdStockList_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridDataItem item = (GridDataItem)rgdStockList.SelectedItems[0];//get selected row
            if (item != null)
            {
                string SID = item.GetDataKeyValue("SID").ToString();



                _ReBindData(int.Parse(SID));



            }
        }

        private void _ReBindData(int SID)
        {
            try
            {
                //if (Request.QueryString["sId"] != null)
                {
                    sBID = 0;
                    show = 0;
                    qty = 0;
                    qtyPack = 0;
                    showV = 0;

                    int stockID = SID;
                    DataTable dt = new DataTable();
                    StockComp stockComp = new StockComp();
                    dt = stockComp.Select(stockID);
                    if (dt.Rows.Count > 0)
                    {

                        DataTable stockList = new DataTable();
                        stockList = stockComp.SelectByCRVNo(dt.Rows[0]["CRVNo"].ToString(), int.Parse(dt.Rows[0]["ProductId"].ToString()));
                        if (stockList.Rows.Count <= 1)
                        { rgdStockList.Visible = false; }
                        else
                        {
                            rgdStockList.Visible = true;
                            rgdStockList.DataSource = stockList;
                            rgdStockList.DataBind();
                        }
                        int sid = Convert.ToInt32(dt.Rows[0]["SID"].ToString());
                        _GetBatch();

                        //Vehicle
                        _GetVehicle();

                        //Spillage
                        DataTable sDt = new DataTable();
                        StockSpillageComp sComp = new StockSpillageComp();

                        sDt = sComp.SelectSpillageByStockId(stockID);
                        rgdIfSpillage.DataSource = sDt;
                        rgdIfSpillage.DataBind();
                        foreach (GridColumn myColumn in rgdIfSpillage.MasterTableView.RenderColumns)
                        {
                            if (myColumn.UniqueName == "DamagedBoxesEdit")

                                myColumn.Visible = false;

                            if (myColumn.UniqueName == "DamagedBoxesShow")

                                myColumn.Visible = true;

                        }




                        //Packaging
                        _GetPackaging();
                        //CRV
                        {
                            int level = int.Parse(dt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                            string[] fr = dt.Rows[0]["PackingMaterialFormat"].ToString().Split('X');

                          

                         
                        divStockGrid.Visible = true;
                        rgdStockGrid.DataSource = dt;
                        rgdStockGrid.DataBind();

                       
                        }
                    }
                }//if ends

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void _BindData()
        {
            try
            {
                sBID = 0;
 show = 0;
                 qty = 0;
          qtyPack = 0;
         showV = 0;
                if (Request.QueryString["sId"] != null)
                {

                    int stockID = Convert.ToInt32(Request.QueryString["sId"].ToString());
                    DataTable dt = new DataTable();
                    StockComp stockComp = new StockComp();
                    dt = stockComp.Select(stockID);
                    if (dt.Rows.Count > 0)
                    {
                        AU = dt.Rows[0]["AU"].ToString();
                        CRVNo = dt.Rows[0]["CRVNo"].ToString();
                        pID =int.Parse(dt.Rows[0]["ProductId"].ToString());

                        if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                        {
                            stcokCase = "Product with packging";
                            Case = 1;
                        }
                        else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == true)
                        {
                            stcokCase = "Product with Packaging with DW";
                            Case = 2;

                        }
                        else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                        {
                            stcokCase = "Product with packaging with Sub packaging"; Case = 3;
                        }
                        else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                        {
                            stcokCase = "Packaging without product"; Case = 4;
                        }
                        else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                        {
                            stcokCase = "Product without PACKAGING"; Case = 5;
                        }

                        txtCRVNo.Text = dt.Rows[0]["CRVNo"].ToString();
                        DataTable stockList = new DataTable();
                        stockList = stockComp.SelectByCRVNo(dt.Rows[0]["CRVNo"].ToString(), int.Parse(dt.Rows[0]["ProductId"].ToString()));
                        if (stockList.Rows.Count <= 1)
                        { rgdStockList.Visible = false; }
                        else
                        {
                            rgdStockList.Visible = true;
                            rgdStockList.DataSource = stockList;
                            rgdStockList.DataBind();
                        }
                        int sid = Convert.ToInt32(dt.Rows[0]["SID"].ToString());
                        _GetBatch();
                        _GetCRV();

                        //Vehicle
                        _GetVehicle();

                        //Spillage
                        DataTable sDt = new DataTable();
                        StockSpillageComp sComp = new StockSpillageComp();

                        sDt = sComp.SelectSpillageByStockId(stockID);
                        rgdIfSpillage.DataSource = sDt;
                        rgdIfSpillage.DataBind();
                        foreach (GridColumn myColumn in rgdIfSpillage.MasterTableView.RenderColumns)
                        {
                            if (myColumn.UniqueName == "DamagedBoxesEdit")

                                myColumn.Visible = false;


                            if (myColumn.UniqueName == "DamagedBoxesShow")
                                if (Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                                {
                                    myColumn.Visible = true;
                                }
                                else
                                    myColumn.Visible = false;

                        }




                        //Packaging
                       
                        //CRV

                        int level = int.Parse(dt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                        string[] fr = dt.Rows[0]["PackingMaterialFormat"].ToString().Split('X');

                        if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                        {
                            apPackaging.Visible = false;
                            apPackaging.Enabled = false;

                        }                       
                        if (Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == true)
                        {
                            apPackaging.Visible = false;
                            apPackaging.Enabled = false;
                            acDW.Visible = true;
                            acDW.Enabled = true;
                            _GetDW();
                        }
                        else
                        {
                            _GetPackaging();
                            if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                            {
                                apPackaging.Visible = false;
                                apPackaging.Enabled = false;

                            }
                            else
                            {
                                apPackaging.Visible = true;
                                apPackaging.Enabled = true;
                            }
                            acDW.Visible = false;
                            acDW.Enabled = false;
                        }
                        divStockGrid.Visible = true;
                        rgdStockGrid.DataSource = dt;
                        rgdStockGrid.DataBind();

                    }
                    
                }//if ends
              
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void _GetDW()
        {
            try
            {
                int stockId= Convert.ToInt32(Request.QueryString["sId"].ToString());


                StockPakagingComp cmp = new StockPakagingComp();
                DataTable dt = new DataTable();
                dt = cmp.SelectDWByStockId(stockId);
                if (dt.Rows.Count > 0)
                {
                   
                    dvDWShow.Visible = true;
                    rgdDWShow.DataSource = dt;
                    rgdDWShow.DataBind();

                    GridFooterItem footeritemFull = (GridFooterItem)rgdDWShow.MasterTableView.GetItems(GridItemType.Footer)[0];
                    Label lblTotalQuatity = (Label)footeritemFull.FindControl("lblTotalQuatity");
                    Label lblTotalPackFormat = (Label)footeritemFull.FindControl("lblTotalPackFormat");

                    double totalQty = 0;
                    double tottalPack = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalQty = totalQty + Convert.ToDouble(dt.Rows[i]["RemainingQty"].ToString());
                        string[] full = dt.Rows[i]["Format"].ToString().Split('X');
                        if (full.Count() > 0)
                        {
                           
                            tottalPack = tottalPack + Convert.ToDouble(full[0]);
                        }

                    }
                    lblTotalPackFormat.Text = tottalPack.ToString("0")+"X DW";
                    lblTotalQuatity.Text = totalQty.ToString("0");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
   
        private void _GetVehicle()
        {
            try
            {
                 
                  int stockID = Convert.ToInt32(Request.QueryString["sId"].ToString());

                DataTable dtVehicle = new DataTable();
                StockVehicleComp vComp = new StockVehicleComp();
                dtVehicle = vComp.SelectByStockId(stockID);
                  rdsVehicleList.DataSource = dtVehicle;
                rdsVehicleList.DataBind();

                GridFooterItem footeritem1 = (GridFooterItem)rdsVehicleList.MasterTableView.GetItems(GridItemType.Footer)[0];
                Label lblQtyRec1 = (Label)footeritem1.FindControl("lblQtyRec");
                Label lblQtySent1 = (Label)footeritem1.FindControl("lblQtySent");
                double totalSent = 0;
                double totalRec = 0;
                if (dtVehicle.Rows.Count > 1)
                {
                    foreach (DataRow dr in dtVehicle.Rows)
                    {
                        totalSent = totalSent + double.Parse(dr["SentQty"].ToString());
                        totalRec = totalRec + double.Parse(dr["RecievedQty"].ToString());
                    }
                       lblQtySent1.Text = "Total Sent Qty: " + TruncateDecimalToString(totalSent, 3);
                    lblQtyRec1.Text = "Total Recieved Qty: " + TruncateDecimalToString(totalRec, 3);

                }
                     
                }
            catch (Exception)
            {

                throw;
            }
        }

        private void _GetBatch()
        {
            try
            {
                   int stockID = Convert.ToInt32(Request.QueryString["sId"].ToString());
                DataTable dtBatch = new DataTable();
                StockBatchComp batchComp = new StockBatchComp();
                dtBatch = batchComp.SelectByStockId(stockID);
                rgdBatchList.DataSource = dtBatch;
                rgdBatchList.DataBind();
                  
                


            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int show = 0;
       
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
  
         private void _GetPackaging()
        {
            try
            {

                int stockId =  Convert.ToInt32(Request.QueryString["sId"].ToString());
                StockComp sCmp = new StockComp();
                DataTable stockDt = new DataTable();
                stockDt = sCmp.Select(stockId);
                if (stockDt.Rows.Count > 0)
                {
                    string formatFull = "";

                    int level = Convert.ToInt32(stockDt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                    string[] fr = stockDt.Rows[0]["PackingMaterialFormat"].ToString().Split(new char[] { 'X' });
                    for (int l = 1; l < level; l++)
                    {
                        formatFull = formatFull + "X" + fr[l].ToString();
                    }
                   
                        DataTable dtPackFull = new DataTable();
                        dtPackFull.Columns.AddRange(new DataColumn[5] { 
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("BatchNo", typeof(string)),
                    new DataColumn("Quantity",typeof(string)) ,
                    new DataColumn("PackType",typeof(string)),
                    new DataColumn("Packaging",typeof(string))});
                        DataTable dtPackLoose = new DataTable();
                        dtPackLoose.Columns.AddRange(new DataColumn[5] { 
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("BatchNo", typeof(string)),
                    new DataColumn("Quantity",typeof(string)) ,
                    new DataColumn("PackType",typeof(string)),
                    new DataColumn("Packaging",typeof(string))});
                        StringBuilder sb = new StringBuilder();
                               StockPakagingComp pComp = new StockPakagingComp();
                        DataTable dtFull = new DataTable();
                        dtFull = pComp.SelectByStockIdFull(stockId);
                        rgdPackagingListFull.DataSource = dtFull;
                        rgdPackagingListFull.DataBind();
                        DataTable dtLoose = new DataTable();
                        dtLoose = pComp.SelectByStockIdLoose(stockId);
                        rgdPackingListLoose.DataSource = dtLoose;
                        rgdPackingListLoose.DataBind();

                        GridFooterItem footeritemFull = (GridFooterItem)rgdPackagingListFull.MasterTableView.GetItems(GridItemType.Footer)[0];
                        Label lblTotalFull = (Label)footeritemFull.FindControl("lblTotalQuatity");
                        Label lblTotalPackFormat = (Label)footeritemFull.FindControl("lblTotalPackFormat");
                        double totalQty = 0;
                        double formatQty = 0;
                        for (int i = 0; i < dtFull.Rows.Count; i++)
                        {
                            totalQty = totalQty + Convert.ToDouble(dtFull.Rows[i]["RemainingQty"].ToString());
                            string[] arrFull = dtFull.Rows[i]["Format"].ToString().Split(new char[] { 'X' });
                            formatQty = formatQty + Convert.ToDouble(arrFull[0].ToString());

                        }
                    if(AU=="NOS")
                        lblTotalFull.Text = TruncateDecimal(totalQty, 3).ToString("0.00");
                        else
                        lblTotalFull.Text = TruncateDecimal(totalQty, 3).ToString("0.000");
                        lblTotalPackFormat.Text = (formatQty.ToString() + formatFull).ToString();
                        double totalQtyLoose = 0;   
                    if (dtLoose.Rows.Count > 0)
                        {
                            GridFooterItem footeritemLoose = (GridFooterItem)rgdPackingListLoose.MasterTableView.GetItems(GridItemType.Footer)[0];
                            Label lblTotalLoose = (Label)footeritemLoose.FindControl("lblTotalQuatity");
                            Label lblTotalPackFormatLoose = (Label)footeritemLoose.FindControl("lblTotalPackFormat");
                           
                            string[] totalLooseFormat = new string[level];
                            for (int i = 0; i < dtLoose.Rows.Count; i++)
                            {
                                totalQtyLoose = totalQtyLoose + Convert.ToDouble(dtLoose.Rows[i]["RemainingQty"].ToString());
                                string[] arrLoose = dtLoose.Rows[i]["Format"].ToString().Split(new char[] { '|' });
                                for (int l = 0; l < level; l++)
                                {
                                    totalLooseFormat[l] = (Convert.ToDouble(totalLooseFormat[l]) + Convert.ToDouble(arrLoose[l])).ToString();
                                }
                            }
                            string looseFormat = TruncateDecimal(Convert.ToDouble(totalLooseFormat[0].ToString()), 3).ToString("0"); ;
                            for (int l = 1; l < level; l++)
                            {
                                looseFormat = looseFormat + "|" + totalLooseFormat[l].ToString();
                            }
                            if (AU == "NOS")
                                lblTotalLoose.Text = TruncateDecimal(totalQtyLoose, 3).ToString("0.00");
                                else
                            lblTotalLoose.Text = TruncateDecimal(totalQtyLoose, 3).ToString("0.000"); //totalQtyLoose.ToString("0,0", new CultureInfo("hi-IN"));
                            lblTotalPackFormatLoose.Text = looseFormat;



                                      }
                    double totalQtyPAck = totalQty + totalQtyLoose;
                    lblTotalQtyPackaging.Text = "Total Quantity: " + TruncateDecimalToString((totalQty + totalQtyLoose), 3);

                    }
               

            }
            catch (Exception)
            {

                throw;
            }
        }
         public static int sBID = 0;
         static double qty = 0;
         static double qtyPack = 0;
         static int showV = 0;
       

        
         private void _GetCRV()
         {
             try
             {
                 int stockID = Convert.ToInt32(Request.QueryString["sId"].ToString());
                 DataTable dt = new DataTable();
                 StockComp stockComp = new StockComp();
                 dt = stockComp.Select(stockID);
                 DataTable stockList = new DataTable();
                 if (dt.Rows.Count > 0)
                 {
                     stockList = stockComp.SelectByCRVNo(dt.Rows[0]["CRVNo"].ToString(), int.Parse(dt.Rows[0]["ProductId"].ToString()));

                 }
                 string stockIDs = "";
                 foreach (DataRow dr in stockList.Rows)
                 {
                     stockIDs = stockIDs + dr["SID"].ToString() + ",";
                 }   
     
      
                dt = stockComp.SelectMultiple(stockIDs);
                DataTable dtCRV = new DataTable();
                DataTable dtPM = new DataTable();
                DataTable dtSubPM = new DataTable();
                dtCRV = dt.Clone();
                dtPM = dt.Clone();
                dtSubPM = dt.Clone();
                string PM = "";
                string SUBPM = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.Count < 2)
                        dr["Remarks"] = dr["Remarks1"];
                    else
                        dr["Remarks"] = "[" + (dr["RecievedFrom"].ToString() == "Local purchase" ? "LP" : "CP") + "] " + dr["Remarks1"];
                   
                    if (Convert.ToBoolean(dr["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(dr["IsWithoutPacking"].ToString()) == true)
                   {
                       dr["CatID"] = dr["SID"];
                        dtCRV.ImportRow(dr); }
                    else
                    {
                        dr["CatID"] = dr["SID"];
                        dtCRV.ImportRow(dr);
                        if (PM != dr["PMName"].ToString())
                        {
                            PM = dr["PMName"].ToString();
                            dtPM.Rows.Add(dr["SID"], 1, "", "", "", 0, "", "", 0, 0, "", "", "", "", "", 0, "", "Nos", dr["PMName"].ToString(), "", 0, 1, "", "", 4, "", 4, "", "", "", "", null, "	", null, null, DateTime.Now.TimeOfDay.Milliseconds, 0, "", "2016-01-19 14:33:00.837", "2016-01-19 14:33:00.837", 0, 0, "");
                        }

                        if (Convert.ToBoolean(dr["IsSubPacking"]) == true)
                        {
                            if (SUBPM != dr["SUBPMName"].ToString())
                            {
                                SUBPM = dr["SUBPMName"].ToString();
                                dtSubPM.Rows.Add(dr["SID"], 2, "", "", "", 0, "", "", 0, 0, "", "", "Sub", "", "", 0, "", "Nos", dr["SUBPMName"].ToString(), "", 0, 1, "", "", 4, "", 4, "", "", "", "", null, "	", null, null, DateTime.Now.TimeOfDay.Milliseconds, 0, "", "2016-01-19 14:33:00.837", "2016-01-19 14:33:00.837", 0, 0, "");
                            }
                        }

                    }
                }
                dtCRV.Merge(dtPM);
                dtCRV.Merge(dtSubPM);
                rgdCRV.DataSource = dtCRV;
                rgdCRV.DataBind();
                sBID = 0;
                int count = 0;
                int SID = 0;
                double tottalProductQty = 0;
                double totalAmount = 0;
                double totalWeight = 0;
                foreach (GridDataItem rgdCRVItem in rgdCRV.MasterTableView.Items)
                {
                    int stockId = int.Parse(rgdCRVItem.GetDataKeyValue("SID").ToString());
                    HiddenField hSID = (HiddenField)rgdCRVItem.FindControl("hdnSID");
                    HiddenField hdnLevel = (HiddenField)rgdCRVItem.FindControl("hdnLevel");
                    if (int.Parse(hSID.Value) == stockId)
                    { sBID = 0; }
                    Label lblProductQty = (Label)rgdCRVItem.FindControl("lblProductQty");
                    Label lblCost = (Label)rgdCRVItem.FindControl("lblCost");
                    if (lblCost.Text != "")
                        totalAmount = totalAmount + double.Parse(lblCost.Text);
                    RadGrid rgdCRVBatch = (RadGrid)rgdCRVItem.FindControl("rgdCRVBatch");
                    RadGrid rgdBatchWithoutPacking = (RadGrid)rgdCRVItem.FindControl("rgdBatchWithoutPacking");
                 DataTable sdt=new DataTable();   
               StockComp cmp = new StockComp();
               
                if (count > 0 && SID == int.Parse(hSID.Value))
                {
                    sdt = cmp.Select(int.Parse(hSID.Value));
                    rgdBatchWithoutPacking.Visible = false;
                    rgdCRVBatch.Visible = false;
                    double pmQty = 0;
                    double subpmQty = 0;
                    double productQty = 0;
                    StockPakagingComp pkcmp = new StockPakagingComp();
                    DataTable dtPK = new DataTable();
                  //  dtPK = pkcmp.SelectByStockId(SID);
                   
                    dtPK = pkcmp.SelectByMultipleSID(stockIDs);
                     PM = "";
                     SUBPM = "";
                    foreach (DataRow cdr in dtPK.Rows)
                    {
                        if (int.Parse(cdr["StockId"].ToString()) == int.Parse(hSID.Value))
                        {
                            PM = cdr["PM"].ToString();
                            SUBPM = cdr["SUBPM"].ToString();

                        }
                    }
                    pmQty = 0;
                    foreach (DataRow cdr in dtPK.Rows)
                    {
                        if (PM == cdr["PM"].ToString() && SUBPM == cdr["SUBPM"].ToString())
                        {
                            if (cdr["PackagingType"].ToString() == "DW")
                            {
                                productQty = productQty + double.Parse(cdr["RemainingQty"].ToString());//B

                                string[] full = cdr["Format"].ToString().Split('X');
                                if (full.Count() > 0)
                                {
                                    pmQty = pmQty + double.Parse(full[0]);//A
                                }


                            }
                            else if (cdr["PackagingType"].ToString() == "Full")
                            {
                                productQty = productQty + double.Parse(cdr["RemainingQty"].ToString());//B
                                string[] full = cdr["Format"].ToString().Split('X');
                                if (full.Count() > 1)
                                {
                                    pmQty = pmQty + double.Parse(full[0]) * double.Parse(full[1]);//A-D
                                    subpmQty = subpmQty + double.Parse(full[0]);//C
                                }

                            }
                            else
                            {
                                productQty = productQty + double.Parse(cdr["RemainingQty"].ToString());//B
                                string[] loose = cdr["Format"].ToString().Split('|');
                                if (loose.Count() > 1)
                                {
                                    pmQty = pmQty + double.Parse(loose[1]);//A-D                                  
                                    subpmQty = subpmQty + double.Parse(loose[0]);//C

                                }
                            }
                        }
                       
                    }
                   
                    if (count >= 1)
                    {
                        if (Convert.ToBoolean(sdt.Rows[0]["IsSubPacking"]) == true)
                        {
                            if (int.Parse(hdnLevel.Value) == 2)
                                lblProductQty.Text = "Quantity: " + (pmQty.ToString("0"));
                            else if (int.Parse(hdnLevel.Value) == 1)

                                lblProductQty.Text = "Quantity: " + (subpmQty.ToString("0"));
                        }
                        else
                        {
                            if (Convert.ToBoolean(sdt.Rows[0]["IsDW"]) == true)
                            {

                                lblProductQty.Text = "Quantity: " + (pmQty.ToString("0"));
                            }
                            else
                            {
                                lblProductQty.Text = "Quantity: " + (subpmQty.ToString("0"));
                            }
                        }
                        tottalProductQty = tottalProductQty + productQty;
                        //totalAmount = totalAmount + double.Parse(sdt.Rows[0]["CostOfParticular"].ToString()) * productQty;
                    }
                    else if (count == 2)
                    {
                        lblProductQty.Text = "Quantity: " + TruncateDecimalToString(productQty, 3);
                    }


                }
                sdt = cmp.Select(stockId);
                if (sdt.Rows.Count > 0)
                {
                    bool ESL = true;
                    bool EXP = true;

                    if (Convert.ToBoolean(sdt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(sdt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                    {
                        foreach (GridDataItem rgdCRVBatchItem in rgdBatchWithoutPacking.MasterTableView.Items)
                        {
                            //Convert.ToInt32(Request.QueryString["sID"].ToString());
                            RadGrid rgdChild = (RadGrid)rgdCRVBatchItem.FindControl("rdsVehicleList");
                            int BactchID = int.Parse(rgdCRVBatchItem.GetDataKeyValue("BID").ToString());
                            if (sBID != BactchID)
                            {
                                sBID = BactchID;
                                Label lblEsl = (Label)rgdCRVBatchItem.FindControl("lblEsl");
                                if (lblEsl.Text == "N/A")
                                    ESL = false;
                                else
                                    ESL = true;
                                Label lblEXPDate = (Label)rgdCRVBatchItem.FindControl("lblEXPDate");
                                if (lblEXPDate.Text == "N/A")
                                    EXP = false;
                                else
                                    EXP = true;
                                Label lblWeight1 = (Label)rgdCRVBatchItem.FindControl("lblWeight");
                                string[] wt = lblWeight1.Text.Split(' ');
                                if (wt[0] != "")
                                {
                                    totalWeight = totalWeight + double.Parse(wt[0]);

                                }
                                StockVehicleComp vComp = new StockVehicleComp();
                                DataTable dtVehicle = new DataTable();
                                dtVehicle = vComp.SelectByBactchID(stockId, BactchID);
                                if (dtVehicle.Rows.Count > 0)
                                {
                                    rgdChild.DataSource = dtVehicle;
                                    rgdChild.DataBind();
                                    double qtyE = 0;
                                    foreach (DataRow dr in dtVehicle.Rows)
                                    {
                                        qtyE = qtyE + double.Parse(dr["RecievedQty"].ToString());
                                    }
                                   // totalAmount = totalAmount + double.Parse(sdt.Rows[0]["CostOfParticular"].ToString()) * qtyE;
                                    tottalProductQty = tottalProductQty + qtyE;
                                }
                            }
                            else
                            {

                                rgdChild.Visible = false;
                            }
                        }

                    }
                    else
                    {

                        foreach (GridDataItem rgdCRVBatchItem in rgdCRVBatch.MasterTableView.Items)
                        {
                            //int stockId = int.Parse(rgdCRVItem.GetDataKeyValue("SID").ToString()); //Convert.ToInt32(Request.QueryString["sID"].ToString());
                            RadGrid rgdChild = (RadGrid)rgdCRVBatchItem.FindControl("rdsVehicleList");
                            int BactchID = int.Parse(rgdCRVBatchItem.GetDataKeyValue("BID").ToString());
                            if (sBID != BactchID)
                            {
                                sBID = BactchID;
                                Label lblEsl = (Label)rgdCRVBatchItem.FindControl("lblEsl");
                                if (lblEsl.Text == "N/A")
                                    ESL = false;
                                else
                                    ESL = true;
                                Label lblEXPDate = (Label)rgdCRVBatchItem.FindControl("lblEXPDate");
                                if (lblEXPDate.Text == "N/A")
                                    EXP = false;
                                else
                                    EXP = true;
                                StockVehicleComp vComp = new StockVehicleComp();
                                DataTable dtVehicle = new DataTable();
                                dtVehicle = vComp.SelectByBactchID(stockId, BactchID);
                                if (dtVehicle.Rows.Count > 0)
                                {
                                    rgdChild.DataSource = dtVehicle;
                                    rgdChild.DataBind();
                                }
                                Label lblWeight1 = (Label)rgdCRVBatchItem.FindControl("lblWeight");

                               if(lblWeight1.Text!="")
                               {
                                   string[] wt = lblWeight1.Text.Split(' ');
                                   totalWeight = totalWeight + double.Parse(wt[0]);

                               }

                            }
                            else
                            {
                                rgdChild.Visible = false;
                                //Label lblBatchNo = (Label)rgdCRVBatchItem.FindControl("lblBatchNo");
                                //lblBatchNo.Visible = false;
                                Label lblMFGDate = (Label)rgdCRVBatchItem.FindControl("lblMFGDate");
                                lblMFGDate.Visible = false;
                                Label lblEsl = (Label)rgdCRVBatchItem.FindControl("lblEsl");
                                lblEsl.Visible = false;
                                Label lblEXPDate = (Label)rgdCRVBatchItem.FindControl("lblEXPDate");
                                lblEXPDate.Visible = false;
                                Label lblCost1 = (Label)rgdCRVBatchItem.FindControl("lblCostAU");
                                lblCost1.Visible = false;
                                Label lblWeight = (Label)rgdCRVBatchItem.FindControl("lblWeight");
                                lblWeight.Visible = false;

                                DataTable dtQty = new DataTable();
                                StockPakagingComp cmpP = new StockPakagingComp();
                                dtQty = cmpP.SelectByBatchId(BactchID);
                                if (dtQty.Rows.Count > 0)
                                {
                                    if (dtQty.Rows[0]["PackagingType"].ToString() == "Full")
                                    {
                                        string[] arr = dtQty.Rows[0]["Format"].ToString().Split('X');
                                        qtyPack = qtyPack + double.Parse(arr[0]);
                                    }
                                    qty = qty + double.Parse(dtQty.Rows[0]["RemainingQty"].ToString());
                                    if (dtQty.Rows[0]["PackagingType"].ToString() == "Loose")
                                    {
                                        string[] arr = dtQty.Rows[0]["Format"].ToString().Split('|');
                                        qtyPack = qtyPack + double.Parse(arr[0]);
                                    }
                                    //qty = qty + double.Parse(dtQty.Rows[0]["RemainingQty"].ToString());
                                }
                                if (dtQty.Rows.Count > 1)
                                {
                                    if (dtQty.Rows[1]["PackagingType"].ToString() == "Full")
                                    {
                                        string[] arr = dtQty.Rows[1]["Format"].ToString().Split('X');
                                        qtyPack = double.Parse(arr[0]);
                                    }
                                    qty = qty + double.Parse(dtQty.Rows[1]["RemainingQty"].ToString());
                                    if (dtQty.Rows[1]["PackagingType"].ToString() == "Loose")
                                    {
                                        string[] arr = dtQty.Rows[1]["Format"].ToString().Split('|');
                                        qtyPack = qtyPack + double.Parse((arr[0]));
                                    }
                                }
                                Label lblthisFormatQty = (Label)rgdCRVBatchItem.FindControl("lblthisFormatQty");
                                lblthisFormatQty.Visible = true;
                                lblthisFormatQty.Text = "Total Packets: " + qtyPack.ToString("0");
                                Label lblthisFullQty = (Label)rgdCRVBatchItem.FindControl("lblthisFullQty");
                                lblthisFullQty.Visible = true;
                                if (AU == "NOS")
                                    lblthisFullQty.Text = " Total Qty in Batch: " + qty.ToString("0.00");

                                    else

                                lblthisFullQty.Text = " Total Qty in Batch: " + qty.ToString("0.000");




                                qtyPack = 0;
                                qty = 0;


                            }
                        }
                    }
                        foreach (GridColumn myColumn in rgdCRVBatch.MasterTableView.RenderColumns)
                                {

                                    if (myColumn.UniqueName == "EXPDate")

                                        myColumn.Visible = EXP;

                                    if (myColumn.UniqueName == "Esl")

                                        myColumn.Visible = ESL;



                                }

                        foreach (GridColumn myColumn in rgdBatchWithoutPacking.MasterTableView.RenderColumns)
                        {

                            if (myColumn.UniqueName == "EXPDate")

                                myColumn.Visible = EXP;

                            if (myColumn.UniqueName == "Esl")

                                myColumn.Visible = ESL;



                        }

                    

                    
                }//
                count++;
                SID = int.Parse(hSID.Value);
                }
                GridFooterItem footer = (GridFooterItem)rgdCRV.MasterTableView.GetItems(GridItemType.Footer)[0];
                Label lblTotalQty = (Label)footer.FindControl("lblTotalQty");
                if(Case==5)
                    lblTotalQty.Text = " Total  Quantity: " + TruncateDecimalToString(tottalProductQty, 3);
                    else
                lblTotalQty.Text = " Total Product Quantity: "+ TruncateDecimalToString(tottalProductQty, 3);
                Label lblTotalWeight = (Label)footer.FindControl("lblTotalWeight");
                if (Case == 5)
                    lblTotalWeight.Text = " Total  Weight: " + TruncateDecimalToString(totalWeight, 3);
                    else
                lblTotalWeight.Text = " Total Product Weight: " + TruncateDecimalToString(totalWeight, 3);
                Label lblAmount = (Label)footer.FindControl("lblAmount");
                lblAmount.Text ="Total Amount: "+totalAmount.ToString("0.00");
             
                
            
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void rgdCRV_ItemCreated(object sender, GridItemEventArgs e)
        {
            // if (!IsPostBack)
            {
                if (e.Item is GridDataItem)
                {

                    GridDataItem item = (e.Item as GridDataItem);
                    int stockId = int.Parse(item.GetDataKeyValue("SID").ToString());
                    // int stockId = Convert.ToInt32(hdnStockID.Value);
                   
                            RadGrid rgdChild = (RadGrid)item.FindControl("rgdCRVBatch");
                            RadGrid rgdBatchWithoutPacking = (RadGrid)item.FindControl("rgdBatchWithoutPacking");
                            Label lblCost = (Label)item.FindControl("lblCost");
                            StockComp cmp = new StockComp();
                            DataTable sdt = new DataTable();
                            double amount = 0;
                            sdt = cmp.Select(stockId);
                            if (sdt.Rows.Count > 0)
                            {
                                if (Convert.ToBoolean(sdt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(sdt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                                {
                                    rgdBatchWithoutPacking.Visible = true;
                                    rgdChild.Visible = false;
                                    StockBatchComp bcmp = new StockBatchComp();
                                    DataTable bdt = new DataTable();
                                    bdt = bcmp.SelectByStockId(stockId);
                                    rgdBatchWithoutPacking.DataSource = bdt;
                                    rgdBatchWithoutPacking.DataBind();
                                    bool ESL = true;
                                    bool EXP = true;
                                    foreach (DataRow dr in bdt.Rows)
                                    {
                                        if (dr["Cost"].ToString()!="")
                                        amount = amount + double.Parse(dr["Cost"].ToString());
                                        if (dr["Esl"].ToString() == "")
                                            ESL = false;
                                        if (dr["EXPDate"].ToString() == "")
                                            EXP = false;
                                    }
                                    foreach (GridColumn myColumn in rgdBatchWithoutPacking.MasterTableView.RenderColumns)
                                    {

                                        if (myColumn.UniqueName == "EXPDate")

                                            myColumn.Visible = EXP;

                                        if (myColumn.UniqueName == "Esl")

                                            myColumn.Visible = ESL;



                                    }

                                }
                                else
                                {
                                    rgdBatchWithoutPacking.Visible = false;
                                    rgdChild.Visible = true;
                                   
                                    StockPakagingComp pComp = new StockPakagingComp();
                                    DataTable dtChild = new DataTable();
                                    dtChild = pComp.SelectByStockId(stockId);
                                    if (dtChild.Rows.Count > 0)
                                    {
                                        rgdChild.DataSource = dtChild;
                                        rgdChild.DataBind();
                                        bool ESL = true;
                                        bool EXP = true;
                                        foreach (DataRow dr in dtChild.Rows)
                                        {
                                            if (dr["CostOfParticular"].ToString() != "")
                                                amount = amount + double.Parse(dr["CostOfParticular"].ToString()) * double.Parse(dr["RemainingQty"].ToString());
                                            if (dr["Esl"].ToString() == "")
                                                ESL = false;
                                            if (dr["EXPDate"].ToString() == "")
                                                EXP = false;
                                        }
                                        foreach (GridColumn myColumn in rgdChild.MasterTableView.RenderColumns)
                                        {

                                            if (myColumn.UniqueName == "EXPDate")

                                                myColumn.Visible = EXP;

                                            if (myColumn.UniqueName == "Esl")

                                                myColumn.Visible = ESL;   
                                          
                                            

                                        }

                                        DataTable dt = new DataTable();
                                        // StockComp cmp = new StockComp();
                                        dt = cmp.Select(stockId);
                                        if (dt.Rows.Count > 0)
                                        {
                                            int level = int.Parse(dt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                                            string[] fr = dt.Rows[0]["PackingMaterialFormat"].ToString().Split('X');
                                            GridFooterItem footeritemFull = (GridFooterItem)rgdChild.MasterTableView.GetItems(GridItemType.Footer)[0];
                                            Label lblTotalQuatity = (Label)footeritemFull.FindControl("lblTotalQuatity");
                                            lblTotalQuatity.Text = dt.Rows[0]["Quantity"].ToString();
                                            //Label lblAmount = (Label)footeritemFull.FindControl("lblAmount");
                                            ////  lblAmount.Text = (Convert.ToDouble(dt.Rows[0]["Quantity"].ToString()) * Convert.ToDouble(dt.Rows[0]["CostOfParticular"].ToString())).ToString();
                                            //lblAmount.Text = "(" + (dt.Rows[0]["CostOfParticular"].ToString()) + "X" + (dt.Rows[0]["Quantity"].ToString()) + ")=" + (Convert.ToDouble(dt.Rows[0]["Quantity"].ToString()) * Convert.ToDouble(dt.Rows[0]["CostOfParticular"].ToString())).ToString("0,0", new CultureInfo("hi-IN"));

                                            pComp = new StockPakagingComp();
                                            DataTable dtFull = new DataTable();
                                            dtFull = pComp.SelectByStockIdFull(stockId);
                                            DataTable dtLoose = new DataTable();
                                            dtLoose = pComp.SelectByStockIdLoose(stockId);
                                            Label lblTotalLooseFormat = (Label)footeritemFull.FindControl("lblTotalLooseFormat");
                                            Label lblTotalFullFormat = (Label)footeritemFull.FindControl("lblTotalFullFormat");
                                            double totalQty = 0;
                                            double formatQty = 0;
                                            string formatFull = "";
                                            for (int l = 1; l < level; l++)
                                            {
                                                formatFull = formatFull + "X" + fr[l].ToString();
                                            }
                                            for (int i = 0; i < dtFull.Rows.Count; i++)
                                            {
                                                totalQty = totalQty + Convert.ToDouble(dtFull.Rows[i]["RemainingQty"].ToString());
                                                string[] arrFull = dtFull.Rows[i]["Format"].ToString().Split(new char[] { 'X' });
                                                formatQty = formatQty + Convert.ToDouble(arrFull[0].ToString());

                                            }
                                            lblTotalFullFormat.Text = (formatQty.ToString("0") + "X" + formatFull).ToString();
                                            double totalQtyLoose = 0;
                                            string[] totalLooseFormat = new string[level];
                                            if (dtLoose.Rows.Count > 0)
                                            {
                                                for (int i = 0; i < dtLoose.Rows.Count; i++)
                                                {
                                                    totalQtyLoose = totalQtyLoose + Convert.ToDouble(dtLoose.Rows[i]["RemainingQty"].ToString());
                                                    string[] arrLoose = dtLoose.Rows[i]["Format"].ToString().Split(new char[] { '|' });
                                                    for (int l = 0; l < level; l++)
                                                    {
                                                        totalLooseFormat[l] = (Convert.ToDouble(totalLooseFormat[l]) + Convert.ToDouble(arrLoose[l])).ToString();
                                                    }
                                                }
                                                string looseFormat = Convert.ToDouble(totalLooseFormat[0].ToString()).ToString("0");
                                                for (int l = 1; l < level; l++)
                                                {
                                                    looseFormat = looseFormat + "|" + totalLooseFormat[l].ToString();
                                                }


                                                lblTotalLooseFormat.Text = looseFormat;

                                            }
                                            else
                                            {
                                                lblTotalLooseFormat.Text = "N/A";
                                            }
                                        }
                                    }

                                
                            
                        }
                    }
                    if(amount>0)
                        lblCost.Text = TruncateDecimalToString(amount, 2).ToString();
                }
            }
        }

        protected void lbtnPRint_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("PrintCRV.aspx?cno=" + CRVNo + "&pid=" + pID);
        }

    }
}