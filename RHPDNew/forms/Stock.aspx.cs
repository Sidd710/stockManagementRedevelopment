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


namespace RHPDNew.Forms
{
    public partial class Stock : System.Web.UI.Page
    {
        public static string TransferedBY = "";
        public static string AU = "";
        public static int Case = 0;
        public static string stcokCase = "";
        public static int sLooseCount = 0;
        public static string btnCRVText = "Generate CRV";
        public static bool txtCRVEnable = true;
        public static bool btnEditStockVisible = true;
        public static bool btnAddBatchVisible = true;
        public static bool btnAddNEwVehicleVisible = true;
        public static bool btnSpilEditVisible = true;
        public static bool txtCRVNoVisible = false;
        public static bool sGetPacking = false;
        public static int sBID = 0;
        public static int sVID = 0;
        public static int Index = 0;
        public static bool ExpDate = true;
        public static bool EslDate = true;
        public static bool BatchList = true;
        public static bool BatchEdit = false;
        public static bool VehicleList = true;
        public static bool VehicleEdit = false;
        public static bool SpillageAdd = true;
        public static bool SpillageList = false;
        public static bool PackIntro = true;
        public static bool PackList = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        protected void ddlWarehouse_DataBound(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "";
                ddl.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string stockIDs = Request.QueryString["sId"].ToString();
                //Panes
                //        apBatch.Visible = false;
                //             apVehicle.Visible = false;
                //             apSppilage.Visible = false;
                //             apPackaging.Visible = false;
                //             apCRV.Visible = false;
                //         //Variables
                //           sLooseCount = 0;
                //btnCRVText = "Generate CRV";
                // txtCRVEnable = true;
                //btnEditStockVisible = true;
                // btnAddBatchVisible = true;
                //btnAddNEwVehicleVisible = true;
                //  btnSpilEditVisible = true;
                // txtCRVNoVisible = false;
                // sGetPacking = false;
                // sBID = 0;
                // sVID = 0;
                //  Index = 0;
                //  ExpDate = true;
                // EslDate = true;
                // BatchList = true;
                //  BatchEdit = false;
                // VehicleList = true;
                //  VehicleEdit = false;
                // SpillageAdd = true;
                // SpillageList = false;
                // PackIntro = true;
                // PackList = false;

                Response.Redirect("~/Forms/stock.aspx?sId=" + stockIDs + "&pID=n");

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void rgdStockList_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridDataItem item = (GridDataItem)rgdStockList.SelectedItems[0];//get selected row
            if (item != null)
            {
                string SID = item.GetDataKeyValue("SID").ToString();
                string[] stockIDs = Request.QueryString["sId"].ToString().Split(',');
                string qString = "";
                for (int i = 0; i < stockIDs.Count(); i++)
                {
                    if (stockIDs[i] != SID)
                        qString = qString + stockIDs[i] + ",";
                }

                Index = 0;
                Response.Redirect("~/Forms/stock.aspx?sId=" + qString + SID);



            }
        }

        public void _GetProduct()
        {

            if (Request.QueryString["sId"] != null)
            {
                StockComp stockComp = new StockComp();
                string qsSIDs = Request.QueryString["sId"].ToString();
                DataTable stockList = new DataTable();
                stockList = stockComp.SelectMultiple(qsSIDs);
                if (stockList.Rows.Count > 0)
                {
                    hdnCatID.Value = stockList.Rows[0]["CatID"].ToString();
                    adProduct.DataSourceID = "sqlProductCat";
                }
            }
            else
            {
                hdnCatID.Value = "0";
                adProduct.DataSourceID = "sqlProduct";
            }



        }
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            sBID = 0;
            if (Request.QueryString["sId"] != null)
            {
                string stockIDs = Request.QueryString["sId"].ToString();
                Response.Redirect("~/Forms/stock.aspx?sId=" + stockIDs);
            }
            else
            { Response.Redirect("~/Forms/stock.aspx"); }
           // _BindData();
            
        }
        private void _BindData()
        {
            try
            {
                _GetSession();
                txtReceivedDate.SelectedDate = DateTime.Now;
                _GetProduct();
                if (Request.QueryString["sId"] != null)
                {


                    btnEditStock.Visible = btnEditStockVisible = true;
                    StockComp stockComp = new StockComp();
                    string qsSIDs = Request.QueryString["sId"].ToString();
                    DataTable stockList = new DataTable();
                    stockList = stockComp.SelectMultiple(qsSIDs);
                    if (stockList.Rows.Count <= 1)
                    {
                        if (Request.QueryString["pID"] == null)
                            rgdStockList.Visible = false;
                        else
                        {
                            rgdStockList.Visible = true;
                            rgdStockList.DataSource = stockList;
                            rgdStockList.DataBind();
                        }
                    }
                    else
                    {
                        rgdStockList.Visible = true;
                        rgdStockList.DataSource = stockList;
                        rgdStockList.DataBind();
                    }
                    string[] stockIDs = Request.QueryString["sId"].ToString().Split(',');
                    int stockID = Convert.ToInt32(stockIDs[stockIDs.Count() - 1]);
                    hdnStockID.Value = stockID.ToString();
                    //  string newProduct = Request.QueryString["pID"].ToString();
                    DataTable dt = new DataTable();

                    if (Request.QueryString["pID"] == null)
                        dt = stockComp.Select(stockID);
                    else
                    {
                        dt = stockComp.Select(stockID);
                        if (dt.Rows.Count > 0)
                        {

                           
                            lblSupplier.Text = "[ " + dt.Rows[0]["OtherSupplier"].ToString() + " ]";
                            hdnSupplier.Value = dt.Rows[0]["OtherSupplier"].ToString();
                            //ddlRecievedFrom.SelectedValue = dt.Rows[0]["RecievedFrom"].ToString();
                            rbtnListTransferedBy.SelectedValue = dt.Rows[0]["TransferedBy"].ToString();
                            txtReceivedDate.Enabled = false;
                            txtReceivedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["RecievedOn"].ToString());
                            if (dt.Rows[0]["ATNo"].ToString() != "")
                            {
                                rbATNoSupNo.SelectedValue = "1";
                                lblATNo.Text = dt.Rows[0]["ATNo"].ToString();
                                lblATNo.Visible = true;
                            }
                            else
                            {
                                rbATNoSupNo.SelectedValue = "2";
                                lblSupNo.Text = dt.Rows[0]["SupplierNo"].ToString();
                                lblSupNo.Visible = true;
                            }

                            reqATNo.Enabled = false;
                            reqSup.Enabled = false;
                            reqSupplier.Enabled = false;

                        }
                        else
                        {
                            txtReceivedDate.Enabled = true;
                            reqATNo.Enabled = true;
                            reqSupplier.Enabled = true;
                            reqSup.Enabled = true;
                        
                        }
                        dt = new DataTable();
                        _GetddlShape();
                        _GetddlShapeSub();
                        divStock.Visible = true;
                        divStockGrid.Visible = false;
                        btnCRVText = "Generate CRV";
                        txtCRVEnable = true;
                        btnEditStockVisible = true;
                        btnAddBatchVisible = true;
                        btnAddNEwVehicleVisible = true;
                        btnSpilEditVisible = true;
                        txtCRVNoVisible = false;
                        sGetPacking = false;
                        sBID = 0;
                        sVID = 0;
                        Index = 0;
                        Case = 0;
                        stcokCase = "";
                        AU = "";

                        ExpDate = true;
                        EslDate = true;
                        BatchList = true;
                        BatchEdit = false;
                        VehicleList = true;
                        VehicleEdit = false;
                        SpillageAdd = true;
                        SpillageList = false;
                        PackIntro = true;
                        PackList = false;

                        //
                        apBatch.Visible = false;
                        apVehicle.Visible = false;
                        apSppilage.Visible = false;
                        apPackaging.Visible = false;
                        apCRV.Visible = false;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        AU = dt.Rows[0]["AU"].ToString();
                        TransferedBY = dt.Rows[0]["TransferedBy"].ToString();
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

                        hdnLevel.Value = (dt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                        string str = dt.Rows[0]["CRVNo"].ToString();

                        if (str == "")
                        { }
                        else
                        {
                            Response.Redirect("../Forms/CRVList.aspx");

                        }

                        int sid = Convert.ToInt32(dt.Rows[0]["SID"].ToString());
                        accData.SelectedIndex = Index;
                        //Batch
                        btnAddBatch.Visible = btnAddBatchVisible;
                        _GetBatch();

                        //Vehicle
                        btnAddNEwVehicle.Visible = btnAddNEwVehicleVisible;
                        _GetVehicle();

                        //Spillage
                        _GetSpillage();






                        //Packaging
                        _GetPackagingList();
                        //CRV

                       // if (txtCRVNoVisible)
                        {
                            _GetCRV();



                        }


                        divStock.Visible = false;
                        divStockGrid.Visible = true;
                        rgdStockGrid.DataSource = dt;
                        rgdStockGrid.DataBind();
                        apBatch.Visible = true;
                        apVehicle.Visible = true;
                        apSppilage.Visible = true;
                        apPackaging.Visible = true;
                        apCRV.Visible = true;
                        if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                        {
                            apPackaging.Visible = false;
                            apPackaging.Enabled = false;
                            //apSppilage.Visible = false;
                           
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
                            acDW.Visible = false;
                            acDW.Enabled = false;
                        }
                    }
                    if (Case == 2 || Case == 5)
                    { lblWeigth.Text = "Weight of particular:"; }
                    else
                    { lblWeigth.Text = "Weight of single Full PM:"; }
                   
                }//if ends
                else
                {
                    _GetddlShape();
                    _GetddlShapeSub();
                    divStock.Visible = true;
                    divStockGrid.Visible = false;
                    btnCRVText = "Generate CRV";
                    txtCRVEnable = true;
                    btnEditStockVisible = true;
                    btnAddBatchVisible = true;
                    btnAddNEwVehicleVisible = true;
                    btnSpilEditVisible = true;
                    txtCRVNoVisible = false;
                    sGetPacking = false;
                    sBID = 0;
                    sVID = 0;
                    Index = 0;
                    ExpDate = true;
                    EslDate = true;
                    BatchList = true;
                    BatchEdit = false;
                    VehicleList = true;
                    VehicleEdit = false;
                    SpillageAdd = true;
                    SpillageList = false;
                    PackIntro = true;
                    PackList = false;
                    Case = 0;
                    stcokCase = "";
                    AU = "";

                    //
                    apBatch.Visible = false;
                    apVehicle.Visible = false;
                    apSppilage.Visible = false;
                    apPackaging.Visible = false;
                    apCRV.Visible = false;

                }
                lblVehilceError.Text = "";
                lblErrorBatch.Text = "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void _GetSession()
        {
            try
            {
                
                ListItem li = new ListItem();
                int currentYear = DateTime.Now.Year;
                int index = 0;
                for (int i = currentYear - 20; i < currentYear + 20; i++)
                {
                    li = new ListItem();
                    li.Text = i.ToString();
                    li.Value = i.ToString();
                    ddlSession.Items.Insert(index, li);
                    index++;
                }
                ddlSession.SelectedValue = currentYear.ToString() ;
                lblSession.Text = "-" + (currentYear + 1).ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int year = int.Parse(ddlSession.SelectedItem.Value);
                lblSession.Text = "-" +( year + 1).ToString();

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void _GetSpillage()
        {
            try
            {
                DataTable ifsDt = new DataTable();
                StockSpillageComp sComp = new StockSpillageComp();
                int stockID = Convert.ToInt32(hdnStockID.Value);
             
                //From sppil table
                DataTable sDt = new DataTable();
                sDt = sComp.SelectByStockId(stockID);
                DataTable dt = new DataTable();
                dt = sDt.Clone();
                bool exists = false;
                DataTable sdt = new DataTable();
                StockComp cmp = new StockComp();
                sdt = cmp.Select(stockID);
                if (sdt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(sdt.Rows[0]["IsDW"].ToString()) == true|| Convert.ToBoolean(sdt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(sdt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                    {


                        foreach (DataRow sdr in sDt.Rows)
                        {
                            if (sdr["tSpilqty"].ToString() != "0.000")
                            {
                                StockSpillageEntity sent=new StockSpillageEntity();
                                sent.DamagedBoxes = 0;
                                sent.BothAffected = 0;
                                sent.SampleAffected = 0;
                                sent.SpillageAffected = 0;
                                sent.SpilledQty = Convert.ToDouble(sdr["tSpilqty"].ToString());
                                sent.StockBatchId = int.Parse(sdr["tBatchId"].ToString());
                                sent.StockId = stockID;
                                sComp.Insert(sent);
                            }  

                              }
                        txtCRVNoVisible = true;
                        _UpdateBatchWeigth();
                        Index = 4;
                    }

                    
                }
                ifsDt = sComp.SelectSpillageByStockId(stockID);

                foreach (DataRow sdr in sDt.Rows)
                {
                    foreach (DataRow ifdr in ifsDt.Rows)
                    {
                        if (int.Parse(sdr["tBatchId"].ToString()) == int.Parse(ifdr["StockBatchId"].ToString()))
                            exists = true;


                    }
                    if (exists == false)
                    {

                        if (double.Parse(sdr["tSpilqty"].ToString()) > 0 || double.Parse(sdr["SampleSentQty"].ToString())>0)
                            dt.ImportRow(sdr);

                    } exists = false;

                }
                

                rgdIfSpillage.DataSource = ifsDt;
                rgdIfSpillage.DataBind();
                foreach (GridColumn myColumn in rgdIfSpillage.MasterTableView.RenderColumns)
                {
                    if (Convert.ToBoolean(sdt.Rows[0]["IsDW"].ToString()) == true || Convert.ToBoolean(sdt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(sdt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                    {
                        if (myColumn.UniqueName == "DamagedBoxesEdit")

                            myColumn.Visible = false;

                        if (myColumn.UniqueName == "DamagedBoxesShow")

                            myColumn.Visible = false;
                    }
                    else
                    {

                        if (myColumn.UniqueName == "DamagedBoxesEdit")

                            myColumn.Visible = false;

                        if (myColumn.UniqueName == "DamagedBoxesShow")

                            myColumn.Visible = true;

                    }
                    if (TransferedBY != "None")
                    {
                        if (myColumn.UniqueName == "SampleSentQty")

                            myColumn.Visible = false;
                        if (myColumn.UniqueName == "SpilAffectedQty")

                            myColumn.Visible = false;
                        if (myColumn.UniqueName == "SampleAffectedQty")

                            myColumn.Visible = false;
                        if (myColumn.UniqueName == "BothAffectd")

                            myColumn.Visible = false;
                    }
                }
                GridFooterItem footeritem = (GridFooterItem)rgdIfSpillage.MasterTableView.GetItems(GridItemType.Footer)[0];
                Button btnSpilEdit = (Button)footeritem.FindControl("btnSpilEdit");
                if (ifsDt.Rows.Count > 0)

                    btnSpilEdit.Visible = btnSpilEditVisible = true;
                else
                    btnSpilEdit.Visible = btnSpilEditVisible = false;
                if (Convert.ToBoolean(sdt.Rows[0]["IsDW"].ToString()) == true||Convert.ToBoolean(sdt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(sdt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                { btnSpilEdit.Visible = btnSpilEditVisible = false; }

                rgdSppilage.DataSource = dt;
                rgdSppilage.DataBind();

               if(TransferedBY!="None")
               {
                   foreach (GridColumn myColumn in rgdSppilage.MasterTableView.RenderColumns)
                   {

                       if (myColumn.UniqueName == "SampleSentQty")

                           myColumn.Visible = false;
                       if (myColumn.UniqueName == "SpilAffectedQty")

                           myColumn.Visible = false;
                       if (myColumn.UniqueName == "SampleAffectedQty")

                           myColumn.Visible = false;
                       if (myColumn.UniqueName == "BothAffectd")

                           myColumn.Visible = false;
                   }
            
               }
                if (dt.Rows.Count > 0)
                {
                    divIfSppilage.Visible = true;
                    if (ifsDt.Rows.Count == 0)
                    {
                        divSppilageList.Visible = false;
                    }
                    else
                        divSppilageList.Visible = true;
                }
                else
                {
                    divIfSppilage.Visible = false;
                    divSppilageList.Visible = true;
                }





            }
            catch (Exception)
            {

                throw;
            }
        }

        private void _GetCRV()
        {
            try
            {
                string stockIDs = Request.QueryString["sId"].ToString();
                DataTable dt = new DataTable();
                StockComp stockComp = new StockComp();
                dt = stockComp.SelectMultiple(stockIDs);
                DataTable dtCRV = new DataTable();
                dtCRV = dt.Clone();
              
                foreach (DataRow dr in dt.Rows)
                {

                    if (Convert.ToBoolean(dr["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(dr["IsWithoutPacking"].ToString()) == true)
                   {
                       dr["CatID"] = dr["SID"];
                        dtCRV.ImportRow(dr); }
                    else
                    {
                        dr["CatID"] = dr["SID"];
                        dtCRV.ImportRow(dr);
                        dtCRV.Rows.Add(dr["SID"],1,"","","",0,"", "", 0, 0, "", "", "", "", "", 0, "", "Nos", dr["PackingMaterial"].ToString(), "", 0, 1, "", "", 4, "", 4, "", "", "", "", null, "	", null, null, DateTime.Now.TimeOfDay.Milliseconds, 0, "", "2016-01-19 14:33:00.837", "2016-01-19 14:33:00.837", 0, 0);
                        if (Convert.ToBoolean(dr["IsSubPacking"]) == true)
                        {
                            dtCRV.Rows.Add(dr["SID"], 2, "", "", "", 0, "", "", 0, 0, "", "", "Sub", "", "", 0, "", "Nos", dr["SubPackingMaterial"].ToString(), "", 0, 1, "", "", 4, "", 4, "", "", "", "", null, "	", null, null, DateTime.Now.TimeOfDay.Milliseconds, 0, "", "2016-01-19 14:33:00.837", "2016-01-19 14:33:00.837", 0, 0);

                        }

                    }
                }
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
                    dtPK = pkcmp.SelectByStockId(SID);
                    pmQty = 0;
                    foreach (DataRow cdr in dtPK.Rows)
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
                   
                    if (count >= 1)
                    {
                        if (Convert.ToBoolean(sdt.Rows[0]["IsSubPacking"]) == true)
                        {
                            if (int.Parse(hdnLevel.Value) == 2)
                                lblProductQty.Text = "Quantity: " + pmQty.ToString("0");
                            else if (int.Parse(hdnLevel.Value) == 1)

                                lblProductQty.Text = "Quantity: " + (subpmQty).ToString("0");
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
                        lblProductQty.Text = "Quantity: " + (productQty.ToString("0"));
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
                                if(AU=="NOS")
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
                            lblCost.Text =TruncateDecimalToString(amount, 2).ToString();
                }
            }
        }

        private void _GetVehicle()
        {
            try
            {
                lblVehilceError.Text = "";
                int stockID = Convert.ToInt32(hdnStockID.Value);


                DataTable dtVehicle = new DataTable();
                StockVehicleComp vComp = new StockVehicleComp();
                dtVehicle = vComp.SelectByStockId(stockID);
                rgdVehicle.DataSource = dtVehicle;
                rgdVehicle.DataBind();
                if (dtVehicle.Rows.Count == 0)
                {

                    divEditVehicle.Visible = VehicleEdit = true;
                    divVehicleAll.Visible = VehicleList = false;
                }
                rdsVehicleList.DataSource = dtVehicle;
                rdsVehicleList.DataBind();
                double totalSent = 0;
                double totalRec = 0;
                GridFooterItem footeritem1 = (GridFooterItem)rdsVehicleList.MasterTableView.GetItems(GridItemType.Footer)[0];
                Label lblQtyRec1 = (Label)footeritem1.FindControl("lblQtyRec");
                Label lblQtySent1 = (Label)footeritem1.FindControl("lblQtySent");
                GridFooterItem footeritem = (GridFooterItem)rgdVehicle.MasterTableView.GetItems(GridItemType.Footer)[0];
                Label lblQtyRec = (Label)footeritem.FindControl("lblQtyRec");
                Label lblQtySent = (Label)footeritem.FindControl("lblQtySent");
                if (dtVehicle.Rows.Count > 1)
                {
                    foreach (DataRow dr in dtVehicle.Rows)
                    {
                        totalSent = totalSent + double.Parse(dr["SentQty"].ToString());
                        totalRec = totalRec + double.Parse(dr["RecievedQty"].ToString());
                    }
                    lblQtySent.Text = "Total Sent Qty: " + TruncateDecimalToString(totalSent, 3);
                    lblQtyRec.Text = "Total Recieved Qty: " + TruncateDecimalToString(totalRec, 3);
                    lblQtySent1.Text = "Total Sent Qty: " + TruncateDecimalToString(totalSent, 3);
                    lblQtyRec1.Text = "Total Recieved Qty: " + TruncateDecimalToString(totalRec, 3);

                }
                DropDownList ddlBatch = (DropDownList)footeritem.FindControl("ddlBatch");
                DataTable dtBatch = new DataTable();
                StockBatchComp batchComp = new StockBatchComp();
                dtBatch = batchComp.SelectByStockId(stockID);
                ddlBatch.DataSource = dtBatch;
                ddlBatch.DataBind();
                DataTable dtV = new DataTable();
                dtV = vComp.Select(int.Parse(hdnVehicle.Value));
                if (dtV.Rows.Count > 0)
                {
                    TextBox txtDriverName = (TextBox)footeritem.FindControl("txtDriverName");
                    TextBox txtVehicleNo = (TextBox)footeritem.FindControl("txtVehicleNo");
                    txtDriverName.Text = dtV.Rows[0]["DriverName"].ToString();
                    txtVehicleNo.Text = dtV.Rows[0]["VehicleNo"].ToString();
                    TextBox txtChallanNo = (TextBox)footeritem.FindControl("txtChallanNo");
                    txtChallanNo.Text = dtV.Rows[0]["ChallanNo"].ToString();
                }
                divEditVehicle.Visible = VehicleEdit;
                divVehicleAll.Visible = VehicleList;
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
                lblErrorBatch.Text = "";
                int stockID = Convert.ToInt32(hdnStockID.Value);

                DataTable dtBatch = new DataTable();
                StockBatchComp batchComp = new StockBatchComp();
                dtBatch = batchComp.SelectByStockId(stockID);
                rgdBatchList.DataSource = dtBatch;
                rgdBatchList.DataBind();
                if (dtBatch.Rows.Count == 0)
                {
                    BatchEdit = true;
                    BatchList = false;
                    dvEditBatch.Visible = true;
                    dvListBacth.Visible = false;
                    // _BindData();
                }
                rgdBatch.DataSource = dtBatch;
                rgdBatch.DataBind();
                GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
               
                DropDownList ddlWarehouse = (DropDownList)footeritem.FindControl("ddlWarehouse");
                DataTable dtWR = new DataTable();
                dtWR = batchComp.GetWarehouseNoList();
                ddlWarehouse.DataSource = dtWR;
                ddlWarehouse.DataBind();
                string ESL = "";
                string Exp = "";
                if (dtBatch.Rows.Count > 0)
                {
                     ESL = dtBatch.Rows[0]["Esl"].ToString();
                     Exp = dtBatch.Rows[0]["EXPDate"].ToString();
                    if (ESL == "")
                        EslDate = false;
                    else
                        EslDate = true;
                    if (Exp == "")
                        ExpDate = false;
                    else
                        ExpDate = true;
                }

                foreach (GridColumn myColumn in rgdBatch.MasterTableView.RenderColumns)
                {
                    if (myColumn.UniqueName == "EXPDate")
                    {
                        myColumn.Visible = ExpDate;
                    }
                    if (myColumn.UniqueName == "Esl")
                    {
                        myColumn.Visible = EslDate;
                    }
                  
                }
                foreach (GridColumn myColumn in rgdBatchList.MasterTableView.RenderColumns)
                {
                    if (myColumn.UniqueName == "EXPDate")
                    {
                        myColumn.Visible = ExpDate;
                    }
                    if (myColumn.UniqueName == "Esl")
                    {
                        myColumn.Visible = EslDate;
                    }
                   
                }
                GridCommandItem rgdItem = (GridCommandItem)rgdBatch.MasterTableView.GetItems(GridItemType.CommandItem)[0];
                CheckBox cbxExp = (CheckBox)rgdItem.FindControl("cbxExpDate");
                cbxExp.Checked = ExpDate;
                CheckBox cbxEsl = (CheckBox)rgdItem.FindControl("cbxESLDate");
                cbxEsl.Checked = EslDate;
                GridCommandItem rgdItem1 = (GridCommandItem)rgdBatchList.MasterTableView.GetItems(GridItemType.CommandItem)[0];
                CheckBox cbxExp1 = (CheckBox)rgdItem1.FindControl("cbxExpDate");
                cbxExp1.Checked = ExpDate;
                CheckBox cbxEsl1 = (CheckBox)rgdItem1.FindControl("cbxESLDate");
                cbxEsl1.Checked = EslDate;
                dvEditBatch.Visible = BatchEdit;
                dvListBacth.Visible = BatchList;
                if (dtBatch.Rows.Count > 0)
                {
                    cbxExp.Enabled = false;
                    cbxEsl.Enabled = false; 
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void _GetddlShape()
        {
            try
            {
                DataTable objdt = new DataTable();
                objdt = GetDataForChart();

                ddlShape.DataSource = objdt;
                ddlShape.DataTextField = "Shape";
                ddlShape.DataValueField = "Id";
                ddlShape.DataBind();


            
                string imageURL = "";
               
                for (int i = 0; i < ddlShape.Items.Count; i++)
                {
                    switch (ddlShape.Items[i].Value)
                    {
                        case "Sphere": imageURL = "../assets/Images/sphere.png";
                            break;
                        case "Cube": imageURL = "../assets/Images/cube1.png";
                            break;
                        case "Cuboid": imageURL = "../assets/Images/cuboid1.jpg";
                            break;
                        case "Cylinder": imageURL = "../assets/Images/cylinder1.png";
                            break;
                        case "Other": imageURL = "../assets/Images/other.png";
                            break;
                    }
                    ListItem item = ddlShape.Items[i];
                    item.Attributes["style"] = "background: url(" + imageURL + ");background-repeat:no-repeat;width:60px;height: 60px;";

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void _GetddlShapeSub()
        {
            try
            {
                DataTable objdt = new DataTable();
                objdt = GetDataForChart();

            
                ddlSubShape.DataSource = objdt;
                ddlSubShape.DataTextField = "Shape";
                ddlSubShape.DataValueField = "Id";
                ddlSubShape.DataBind();
                string imageURL = "";
                for (int i = 0; i < ddlSubShape.Items.Count; i++)
                {
                    switch (ddlSubShape.Items[i].Value)
                    {
                        case "Sphere": imageURL = "../assets/Images/sphere.png";
                            break;
                        case "Cube": imageURL = "../assets/Images/cube1.png";
                            break;
                        case "Cuboid": imageURL = "../assets/Images/cuboid1.jpg";
                            break;
                        case "Cylinder": imageURL = "../assets/Images/cylinder1.png";
                            break;
                        case "Other": imageURL = "../assets/Images/other.png";
                            break;
                    }
                    ListItem item = ddlSubShape.Items[i];
                    item.Attributes["style"] = "background: url(" + imageURL + ");background-repeat:no-repeat;width:60px;height: 60px;";

                
               
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void _DeleteOnUpdate()
        {

            try
            {
                int stockId = Convert.ToInt32(hdnStockID.Value);
                StockComp cmp = new StockComp();
                cmp.DeleteOnUpdate(stockId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetDataForChart()
        {
            DataTable _objdt = new DataTable();
            _objdt.Columns.Add("Shape", typeof(string));
            _objdt.Columns.Add("Id", typeof(string));
            _objdt.Rows.Add("--Select--", "");
            _objdt.Rows.Add("Sphere", "Sphere");
            _objdt.Rows.Add("Cube", "Cube");
            _objdt.Rows.Add("Cuboid", "Cuboid");
            _objdt.Rows.Add("Cylinder", "Cylinder");
            _objdt.Rows.Add("Other", "Other");
            return _objdt;
        }
     
        private void _GetPackaging()
        {
            try
            {
                //  Index = 4;
                sGetPacking = false;
                int stockId = Convert.ToInt32(hdnStockID.Value);
                StockComp sCmp = new StockComp();
                DataTable stockDt = new DataTable();
                stockDt = sCmp.Select(stockId);
                if (stockDt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(stockDt.Rows[0]["IsDW"].ToString()) == true)
                    {
                        apPackaging.Visible = false;
                        apPackaging.Enabled = false;
                        acDW.Visible = true;
                        acDW.Enabled = true;
                        _GetDW();
                        return;
                    }
                    if (Convert.ToBoolean(stockDt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(stockDt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                    {
                        apPackaging.Visible = false;
                        apPackaging.Enabled = false;
                        return;
                    }
                    string formatFull = "";

                    int level = Convert.ToInt32(stockDt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                    string[] fr = stockDt.Rows[0]["PackingMaterialFormat"].ToString().Split(new char[] { 'X' });
                    for (int l = 1; l < level; l++)
                    {
                        formatFull = formatFull + "X" + fr[l].ToString();
                    }
                  
                    {
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
                        double tottalQtyfull = 0;
                        double tottalQtyLoose = 0;
                        double tottalformat = 0;

                        DataTable sDt = new DataTable();
                        StockSpillageComp sComp = new StockSpillageComp();
                        sDt = sComp.SelectByStockId(stockId);

                        if (sDt.Rows.Count > 0)
                        {
                            string format = "";
                            double divider = 1;
                            double remainder = 0;
                            double qty = 1;

                            int digit = 1;
                            double looseQty = 0;

                            hdnLevel.Value = level.ToString();
                            double damagedBoxes = 0;
                            for (int i = 0; i < sDt.Rows.Count; i++)
                            {
                                DataTable dtDamgeBoxes = new DataTable();
                                StockSpillageComp compSpil = new StockSpillageComp();
                                dtDamgeBoxes = compSpil.SelectByBatchId(stockId, int.Parse(sDt.Rows[i]["tBatchId"].ToString()));
                                if (dtDamgeBoxes.Rows.Count > 0)
                                {
                                    damagedBoxes = double.Parse(dtDamgeBoxes.Rows[0]["DamagedBoxes"].ToString());

                                }
                               
                                {//Full Packaging
                                    double recQty = Convert.ToDouble(sDt.Rows[i]["tSentQty"].ToString());
                                        double Spilqty = Convert.ToDouble(sDt.Rows[i]["tSpilqty"].ToString());

                                    for (int l = 0; l < level; l++)
                                    {
                                        if (fr[l].ToString() != "")
                                        {
                                            qty = qty * Convert.ToDouble(fr[l].ToString());
                                        }
                                    }
                                    remainder = recQty % qty;//Loose
                                    remainder = Math.Round(remainder, 3);
                                    recQty = recQty - remainder;//Full qty
                                    divider = recQty / qty;//Full PAckaging

                                    double sppilPack = 0;
                                    double sppilLoose = 0;

                                    sppilLoose = Spilqty % qty;//Spill loose
                                    sppilLoose = Math.Round(sppilLoose, 3);
                                    sppilPack = Spilqty - sppilLoose;
                                    sppilPack = sppilPack / qty;
                                    if (remainder == 0)
                                    {
                                        if (sppilLoose.ToString("0.000") != "0.000")
                                        {
                                            sppilLoose = qty - sppilLoose;
                                            sppilPack = (Spilqty + sppilLoose) / qty;
                                        }
                                      

                                    }
                                    else if (TruncateDecimal(remainder,3) < Spilqty)
                                    {
                                        sppilLoose = Spilqty - remainder;
                                        sppilPack = sppilLoose % qty;
                                        sppilPack = Math.Round(sppilPack, 3);
                                        sppilPack = (sppilLoose - sppilPack) / qty;
                                        sppilLoose = sppilLoose % qty;
                                        sppilLoose = Math.Round(sppilLoose, 3);
                                        if (sppilLoose > remainder)
                                        {                                            
                                            sppilLoose = qty - sppilLoose;
                                            sppilPack = ((Spilqty - remainder )+ sppilLoose) / qty;
                                        }
                                      
                                    }
                                    if (damagedBoxes < sppilPack)
                                    {
                                        lblSpilErr.Text = "Damaged boxes can not be less than " + sppilPack + " as per found Spillage!";
                                       
                                    }

                                    if (damagedBoxes != 0)
                                    {
                                        remainder = remainder + qty * damagedBoxes;
                                        recQty = recQty - qty * damagedBoxes;
                                        divider = divider - damagedBoxes;
                                        
                                    }
                                    double rm = TruncateDecimal(remainder, 3);
                                    remainder = rm - Spilqty;

                                    if (divider > 0)
                                    {
                                        format = divider.ToString("0") + formatFull;
                                        if (AU == "NOS")
                                            dtPackFull.Rows.Add(int.Parse(sDt.Rows[i]["tBatchId"].ToString()), sDt.Rows[i]["BatchNo"].ToString(), recQty.ToString("0.00"), "Full Packaging", format);
                                     
                                            else
                                        dtPackFull.Rows.Add(int.Parse(sDt.Rows[i]["tBatchId"].ToString()), sDt.Rows[i]["BatchNo"].ToString(), recQty.ToString("0.000"), "Full Packaging", format);
                                        tottalQtyfull = tottalQtyfull + recQty;
                                        tottalformat = tottalformat + divider;
                                    }
                                    if (remainder > 0)
                                    {
                                        if (AU == "NOS")
                                            dtPackLoose.Rows.Add(int.Parse(sDt.Rows[i]["tBatchId"].ToString()), sDt.Rows[i]["BatchNo"].ToString(), (TruncateDecimal(remainder, 3)).ToString("0.00"), "Loose Packaging", "");
                                        else
                                        dtPackLoose.Rows.Add(int.Parse(sDt.Rows[i]["tBatchId"].ToString()), sDt.Rows[i]["BatchNo"].ToString(), (TruncateDecimal(remainder, 3)).ToString("0.000"), "Loose Packaging", "");
                                        tottalQtyLoose = tottalQtyLoose + remainder;
                                        sLooseCount = sLooseCount + 1;
                                    }               
                            
                                    remainder = 0;
                                    qty = 1;
                                    format = "";
                                    damagedBoxes = 0;
                                    sppilLoose = 0;
                                }

                            }


                        }
                        rgdFullPack.DataSource = dtPackFull;
                        rgdFullPack.DataBind();
                        rgdLoosePAck.DataSource = dtPackLoose;
                        rgdLoosePAck.DataBind();
                        double totalQtyPAck = 0;
                        foreach (DataRow dr in dtPackFull.Rows)
                        { totalQtyPAck=totalQtyPAck+double.Parse(dr["Quantity"].ToString());}
                        foreach (DataRow dr in dtPackLoose.Rows)
                        { totalQtyPAck = totalQtyPAck + double.Parse(dr["Quantity"].ToString()); }
                        lblQtyFullPack.Text = "Total Quantity: " + TruncateDecimalToString(totalQtyPAck, 3);            
                        GridFooterItem footeritemFull = (GridFooterItem)rgdFullPack.MasterTableView.GetItems(GridItemType.Footer)[0];
                        Label lblTotalFull = (Label)footeritemFull.FindControl("lblTotalQuatity");
                        if (AU == "NOS")
                            lblTotalFull.Text = TruncateDecimal(tottalQtyfull, 3).ToString("0.00");
                            else
                        lblTotalFull.Text = TruncateDecimal(tottalQtyfull, 3).ToString("0.000");
                        Label lblTotalPackFormat = (Label)footeritemFull.FindControl("lblTotalPackFormat");
                        lblTotalPackFormat.Text = TruncateDecimal(tottalformat, 3).ToString("0") + formatFull;

                        GridFooterItem footeritemLoose = (GridFooterItem)rgdLoosePAck.MasterTableView.GetItems(GridItemType.Footer)[0];
                        Label lblTotalLoose = (Label)footeritemLoose.FindControl("lblTotalQuatity");
                         if (AU == "NOS")
                             lblTotalLoose.Text = TruncateDecimal(tottalQtyLoose, 3).ToString("0.00");         
                             else
                        lblTotalLoose.Text = TruncateDecimal(tottalQtyLoose, 3).ToString("0.000");        

                        divDispPack.Visible = PackList = false;
                        divIntroPack.Visible = PackIntro = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void _UpdateBatchWeigth()
        {
            try
            {
                StockComp cmp = new StockComp();
                DataTable dt = new DataTable();
                dt = cmp.Select(int.Parse(hdnStockID.Value));
                if (dt.Rows.Count > 0)
                {
                    string stcokCase = "";
                    if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                    {
                        stcokCase = "1";
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == true)
                    {
                        stcokCase = "2";
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                    {
                        stcokCase = "3";
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                    {
                        stcokCase = "4";
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                    {
                        stcokCase = "5";
                    }
                    string[] format = dt.Rows[0]["PackingMaterialFormat"].ToString().Split('X');
                    double formatQty = 1;
                    for (int i = 0; i < format.Count(); i++)
                    {
                        if (format[i]!="")
                            formatQty = formatQty * Convert.ToDouble(format[i]);
                    }
                    StockBatchComp bcmp = new StockBatchComp();
                    DataTable bList = new DataTable();
                    bList = bcmp.SelectByStockId(int.Parse(hdnStockID.Value));
                    foreach (DataRow bdr in bList.Rows)
                    {
                        int BID = int.Parse(bdr["BID"].ToString());    
                        StockPakagingComp pcmp = new StockPakagingComp();
                        DataTable pdt = new DataTable();
                         double bRemQty =0;
                        double packets=0;
                        double subPackets = 0;
                        
                            pdt = pcmp.SelectByBatchId(BID);
                                    foreach (DataRow dr in pdt.Rows)
                                    {
                                        bRemQty = bRemQty + Convert.ToDouble(dr["RemainingQty"].ToString());
                                        if (dr["PackagingType"].ToString() == "Full")
                                        {
                                            string[] packing=dr["Format"].ToString().Split('X');
                                            packets = packets + Convert.ToDouble(packing[0]);
                                            if (stcokCase=="3")
                                            {
                                                subPackets = subPackets + Convert.ToDouble(packing[1]);
                                            }
                                        }
                                        else if (dr["PackagingType"].ToString() == "Loose")
                                        {
                                             string[] packing=dr["Format"].ToString().Split('|');
                                             packets = packets + Convert.ToDouble(packing[1]);
                                            if (stcokCase == "3")
                                            {
                                                subPackets = subPackets + Convert.ToDouble(packing[1]);
                                            }
                                        }
                                        else if (dr["PackagingType"].ToString() == "DW")
                                        {
                                            string[] packing=dr["Format"].ToString().Split('X');
                                            packets = packets + Convert.ToDouble(packing[0]);
                                        }
                                    }

                          double cost = 0;
                            double weight = 0;
                            double weightOfPArticular = 0;
                     
                         DataTable bdt=new DataTable();
                                    StockBatchEntity bentity=new StockBatchEntity();
                                    bdt=bcmp.Select(BID);
                                    if(bdt.Rows.Count>0)
                                    {
                                        bentity.Id=BID;
                                        bentity.BatchNo = bdt.Rows[0]["BatchNo"].ToString();
                                        bentity.StockId=int.Parse(hdnStockID.Value);
                                        bentity.MfgDate=Convert.ToDateTime(bdt.Rows[0]["MFGDate"].ToString());
                                        if(bdt.Rows[0]["Esl"].ToString()!="")
                                        bentity.ESLDate=Convert.ToDateTime(bdt.Rows[0]["Esl"].ToString());
                                        if(bdt.Rows[0]["EXPDate"].ToString()!="")
                                        bentity.ExpiryDate=Convert.ToDateTime(bdt.Rows[0]["EXPDate"].ToString());
                                        bentity.CostOfParticular =TruncateDecimal(Convert.ToDouble(bdt.Rows[0]["CostOfParticular"].ToString()),2);
                                        bentity.Remarks=bdt.Rows[0]["Remarks"].ToString();
                                        bentity.SampleSent= Convert.ToBoolean(bdt.Rows[0]["IsSentto"].ToString());
                                        bentity.WarehouseNo=bdt.Rows[0]["WarehouseNo"].ToString();
                                        bentity.ContactNo=bdt.Rows[0]["ContactNo"].ToString();
                                        bentity.WeightUnit = bdt.Rows[0]["WeightUnit"].ToString();
                           bentity.WarehouseID =int.Parse(bdt.Rows[0]["WarehouseID"].ToString());
                            if (bdt.Rows[0]["SectionID"].ToString() != "")
                                bentity.SectionID = int.Parse(bdt.Rows[0]["SectionID"].ToString());
                            if (bdt.Rows[0]["SectionCol"].ToString()!="")
                            bentity.SectionCol =int.Parse(bdt.Rows[0]["SectionCol"].ToString());
                            if (bdt.Rows[0]["SectionRows"].ToString() != "")
                                bentity.SectionRows = int.Parse(bdt.Rows[0]["SectionRows"].ToString());
                            
                            if (bdt.Rows[0]["SampleSentQty"].ToString()!="")
                            bentity.SampleSentQty =double.Parse(bdt.Rows[0]["SampleSentQty"].ToString());
                            switch (stcokCase)
                                        {
                                            case "1": //Product with packging 
                                                cost = (bRemQty * bentity.CostOfParticular);
                                                weightOfPArticular = (Convert.ToDouble(dt.Rows[0]["Weight"].ToString()) / formatQty);
                                                weight = (bRemQty * weightOfPArticular);
                                                break;
                                            case "2": //Product With Packaging with DW
                                                cost = (bRemQty * bentity.CostOfParticular);
                                                weight = (bRemQty * Convert.ToDouble(dt.Rows[0]["Weight"].ToString()));
                                                weightOfPArticular = Convert.ToDouble(dt.Rows[0]["Weight"].ToString());

                                                break;
                                            case "3": //with packaging  with Sub packaging
                                                cost = (bRemQty * bentity.CostOfParticular);
                                                weightOfPArticular = (Convert.ToDouble(dt.Rows[0]["Weight"].ToString()) / formatQty);
                                                weight = (bRemQty * weightOfPArticular);
                                                break;
                                            case "4": // Packaging without product
                                                StockVehicleComp vcmp1 = new StockVehicleComp();
                                                DataTable vdt1 = new DataTable();
                                                vdt1 = vcmp1.SelectByBactchID(int.Parse(hdnStockID.Value), BID);

                                                foreach (DataRow dr in vdt1.Rows)
                                                {
                                                    bRemQty = bRemQty + Convert.ToDouble(dr["RecievedQty"].ToString());
                                                }
                                                cost = (bRemQty * bentity.CostOfParticular);
                                                weightOfPArticular = (Convert.ToDouble(dt.Rows[0]["Weight"].ToString()));
                                                weight = (weightOfPArticular * bRemQty);

                                                break;
                                            case "5": //Product without PACKAGING
                                                StockVehicleComp vcmp = new StockVehicleComp();
                                                DataTable vdt = new DataTable();
                                                DataTable vdtBID = new DataTable();
                                                vdt = vcmp.SelectByStockId(int.Parse(hdnStockID.Value));
                                                vdtBID = vcmp.SelectByBactchID(int.Parse(hdnStockID.Value), BID);
                                                //double maxQty = 0;
                                                //foreach (DataRow dr in vdt.Rows)
                                                //{
                                                //    bRemQty = bRemQty + Convert.ToDouble(dr["RecievedQty"].ToString());
                                                //    if (Convert.ToDouble(dr["RecievedQty"].ToString()) > maxQty)
                                                //        maxQty = Convert.ToDouble(dr["RecievedQty"].ToString());
                                                //}
                                                double bRemQtyBID = 0;
                                                foreach (DataRow dr in vdtBID.Rows)
                                                {
                                                    bRemQtyBID = bRemQtyBID + Convert.ToDouble(dr["RecievedQty"].ToString());

                                                }
                                               
                                                cost = (bRemQtyBID * bentity.CostOfParticular);
                                                //if (bRemQty > Convert.ToDouble(dt.Rows[0]["Weight"].ToString()))
                                                //{
                                                //    weightOfPArticular = ((Convert.ToDouble(dt.Rows[0]["Weight"].ToString()) / maxQty));// TruncateDecimal(maxQty * formatQty, 3);

                                                //    weight = (bRemQtyBID * weightOfPArticular);
                                                //}

                                                weight = (bRemQtyBID * Convert.ToDouble(dt.Rows[0]["Weight"].ToString()));
                                                weightOfPArticular = Convert.ToDouble(dt.Rows[0]["Weight"].ToString());
                                                break;
                                        }

                                        bentity.Cost=TruncateDecimal(cost,2);
                                        bentity.Weight = weight;
                                        if (weightOfPArticular>0)
                                            bentity.WeightofParticular = weightOfPArticular;
                                        bcmp.UpdateBatch(bentity);
                                    
                            }
                        }
                    }
                
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
                 int stockId = Convert.ToInt32(hdnStockID.Value);
                       
                        StockPakagingComp cmp = new StockPakagingComp();
                        DataTable dt = new DataTable();
                        dt = cmp.SelectDWByStockId(stockId);
                        if (dt.Rows.Count > 0)
                        {
                            dvDWSave.Visible = false;
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
                else
                        {
                            dvDWShow.Visible = false;
                            dvDWSave.Visible = true;
                            DataTable sDt = new DataTable();
                        StockSpillageComp sComp = new StockSpillageComp();
                        sDt = sComp.SelectByStockId(stockId);
                          
                            rhdDWDefine.DataSource = sDt;
                            rhdDWDefine.DataBind();
                        
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
                return (tmp / step);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public decimal DTruncateDecimal(decimal value, int digit)
        {
            try
            {
                decimal step = (decimal)Math.Pow(10, digit);
                decimal tmp = (decimal)Math.Truncate(step * value);
                return (tmp / step);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void _GetPackagingList()
        {
            try
            {
               
                int stockId = Convert.ToInt32(hdnStockID.Value);
                StockComp stockComp = new StockComp();
                DataTable stockDt = new DataTable();
                stockDt = stockComp.Select(stockId);
                if (stockDt.Rows.Count > 0)
                {

                    if (Convert.ToBoolean(stockDt.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(stockDt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                    {
                        apPackaging.Visible = false;
                        apPackaging.Enabled = false;
                        return;
                    }
                    string formatFull = "";
                    int level = Convert.ToInt32(stockDt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                    string[] fr = stockDt.Rows[0]["PackingMaterialFormat"].ToString().Split(new char[] { 'X' });
                    for (int l = 1; l < level; l++)
                    {
                        formatFull = formatFull + "X" + fr[l].ToString();
                    }
                    StockPakagingComp pComp = new StockPakagingComp();
                    DataTable dtFull = new DataTable();
                    dtFull = pComp.SelectByStockIdFull(stockId);
                    if (dtFull.Rows.Count < 1)
                    {
                        _GetPackaging();
                        return;

                    }

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
                    if (AU == "NOS")
                    {
                        lblTotalFull.Text = totalQty.ToString("0.00");
                        lblTotalPackFormat.Text = (formatQty.ToString() + formatFull).ToString();
                    }
                    else
                    {
                        lblTotalFull.Text = totalQty.ToString("0.000");
                        lblTotalPackFormat.Text = (formatQty.ToString() + formatFull).ToString();
                    }
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
                        string looseFormat =TruncateDecimal(Convert.ToDouble(totalLooseFormat[0].ToString()),3).ToString("0");
                        for (int l = 1; l < level; l++)
                        {
                            looseFormat = looseFormat + "|" + totalLooseFormat[l].ToString();
                        }
                        if(AU=="NOS")
                            lblTotalLoose.Text = totalQtyLoose.ToString("0.00");
                            else
                        lblTotalLoose.Text = totalQtyLoose.ToString("0.000");
                        lblTotalPackFormatLoose.Text = looseFormat;
                        divDispPack.Visible = PackList = true;
                        divIntroPack.Visible = PackIntro = false;
                      
            
                        
                    }

                    _GetCRV();
                    double totalQtyPAck = totalQty + totalQtyLoose;
                    lblTotalQtyPackaging.Text = "Total Quantity: " + TruncateDecimalToString((totalQty + totalQtyLoose), 3);

                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                StockEntity objEntity = new StockEntity();
                StockComp objCom = new StockComp();
                objEntity.TransferedBy = rbtnListTransferedBy.SelectedItem.Value;
                objEntity.Remarks = txtRemarks.Text;
                objEntity.Session = Convert.ToDateTime("1-4-" + ddlSession.SelectedItem.Value);
              
                int omCount = Convert.ToInt32(txtOriginalManufacture.Entries.Count.ToString());
                 if (omCount == 0)
                 {

                     objEntity.OriginalMfg = hdnOM.Value;

                 }
                 else
                 {                  
                    rhpdEntities db = new rhpdEntities();
                    OriginalManufacture_ cn = new OriginalManufacture_();
                    string text = "";
                    foreach (AutoCompleteBoxEntry entry in txtOriginalManufacture.Entries)
                    {
                        if (entry.Text != "")
                            text = entry.Text.Split(';')[0];
                    }

                    var item = db.OriginalManufacture_.SingleOrDefault(s => s.Name == text);
                    if (item == null)
                    {
                        cn.Name = text;
                        cn.Address = "";
                        cn.IsActivated = true;
                        db.OriginalManufacture_.Add(cn);
                        db.SaveChanges();
                    }
                        objEntity.OriginalMfg = text;
                    
                }
              
                if (rbtnPacking.SelectedValue == "1")
                {
                    objEntity.IsWithoutPacking = false;
                    objEntity.IsEmptyPM = true;
                    objEntity.PackagingMaterialFormat = "";
                    objEntity.PackagingMaterialFormatLevel = 0;

                }
                else if (rbtnPacking.SelectedValue == "2")
                {
                    objEntity.IsWithoutPacking = true;
                    objEntity.IsEmptyPM = false;
                    objEntity.PackagingMaterialFormat = "";
                    objEntity.PackagingMaterialFormatLevel = 0;

                }
                else
                {
                    objEntity.IsWithoutPacking = false;
                    objEntity.IsEmptyPM = false;
                    if (cbxDW.Checked == true)
                    { objEntity.IsDW = true; }
                    else
                    {
                        objEntity.IsDW = false;
                        foreach (Control cnt in phFormat.Controls)
                        {
                            if (cnt is RadNumericTextBox)
                            {
                                RadNumericTextBox rdx = (RadNumericTextBox)cnt;
                                if (rdx.Text != "")
                                {
                                    objEntity.PackagingMaterialFormatLevel = objEntity.PackagingMaterialFormatLevel + 1;
                                    if (objEntity.PackagingMaterialFormat != null)
                                        objEntity.PackagingMaterialFormat = objEntity.PackagingMaterialFormat + "X" + rdx.Text;
                                    else
                                        objEntity.PackagingMaterialFormat = rdx.Text;
                                }
                            }
                        }
                    }
                }
                objEntity.IsSubPacking = false;
                if (cbxSubPack.Checked == true)
                {
                    if (rnSubPMWeight.Text != "")
                    {
                        objEntity.SubWeightUnit = ddlSubWeight.SelectedItem.Value;
                        if (double.Parse(rnSubPMWeight.Text) < 1 && double.Parse(rnSubPMWeight.Text)>=.5)
                        {
                            if (objEntity.SubWeightUnit == "KGS")
                            {
                                objEntity.SubWeight = double.Parse(rnSubPMWeight.Text) * 1000;
                                objEntity.SubWeightUnit = "GRAMS";
                            }
                            else if (objEntity.SubWeightUnit == "TONNES")
                            {
                                objEntity.SubWeight = double.Parse(rnSubPMWeight.Text) * 1000;
                                objEntity.SubWeightUnit = "KGS";
                            }
                            else
                                objEntity.SubWeight = double.Parse(rnSubPMWeight.Text);
                        }
                        else if (double.Parse(rnSubPMWeight.Text) >= 1000 )
                        {
                            if (objEntity.SubWeightUnit == "KGS")
                            {
                                objEntity.SubWeight = double.Parse(rnSubPMWeight.Text) / 1000;
                                objEntity.SubWeightUnit = "TONNES";
                            }
                            else if (objEntity.SubWeightUnit == "GRAMS")
                            {
                                objEntity.SubWeight = double.Parse(rnSubPMWeight.Text) / 1000;
                                objEntity.SubWeightUnit = "KGS";
                            }
                            else
                                objEntity.SubWeight = double.Parse(rnSubPMWeight.Text);
                        }
                        else
                        objEntity.SubWeight = double.Parse(rnSubPMWeight.Text);
                    }
                    if (ddlSubShape.SelectedItem.Value != "")
                    {
                        objEntity.SubShapeUnit = ddlSubShapeUnit.SelectedItem.Value;
                        objEntity.SubPMShape = ddlSubShape.SelectedItem.Value;

                        switch (ddlSubShape.SelectedItem.Value)
                        {
                            case "Sphere":
                                objEntity.SubPMSize = rnSphereR.Text;
                                break;
                            case "Cube":
                                objEntity.SubPMSize = rnSubCubeRadius.Text;
                                break;
                            case "Cuboid":
                                objEntity.SubPMSize = rnSubCubeRadius.Text + "X" + rnSubCuboidBrth.Text + "X" + rnSubCuboidHeight.Text;
                                break;
                            case "Cylinder":
                                objEntity.SubPMSize = rnSubCylinderRadius.Text + "X" + rnSubCylinderHeight.Text;
                                break;
                            case "Other":
                                objEntity.SubPMSize = txtSubOtherInfo.Text;
                                break;
                        }
                    }
                    objEntity.IsSubPacking = true;
                    int cdCount = Convert.ToInt32(rdaSubCondition.Entries.Count.ToString());
                    if (cdCount == 0)
                    {

                        if (hdnSubCondition.Value != "")
                            objEntity.SubPMConditionId = int.Parse(hdnSubCondition.Value);
                        else
                            objEntity.SubPMConditionId = null;
                    }
                    else
                    {
                        rhpdEntities db = new rhpdEntities();
                        PMCondition cn = new PMCondition();
                        string text = "";
                        foreach (AutoCompleteBoxEntry entry in rdaSubCondition.Entries)
                        {
                            if (entry.Text != "")
                                text = entry.Text.Split(';')[0];
                        }

                        var item = db.PMConditions.SingleOrDefault(s => s.Condition == text);
                        if (item == null)
                        {
                            cn.Condition = text;
                            cn.AddedOn = DateTime.Now.Date;
                            cn.IsActive = true;
                            db.PMConditions.Add(cn);
                            db.SaveChanges();
                            objEntity.SubPMConditionId = cn.Id;
                        }
                        else
                            objEntity.SubPMConditionId = item.Id;
                    }

                    int gdCount = Convert.ToInt32(rdaSubGrade.Entries.Count.ToString());
                    if (gdCount == 0)
                    {

                        if (hdnSubGrade.Value != "")
                            objEntity.SubPMGradeId = int.Parse(hdnSubGrade.Value);
                        else
                            objEntity.SubPMGradeId = null;
                    }
                    else
                    {
                        rhpdEntities db = new rhpdEntities();
                        PMGrade gd = new PMGrade();
                        string text = "";
                        foreach (AutoCompleteBoxEntry entry in rdaSubGrade.Entries)
                        {
                            if (entry.Text != "")
                                text = entry.Text.Split(';')[0];
                        }
                        var item = db.PMGrades.SingleOrDefault(s => s.Grade == text);
                        if (item == null)
                        {
                            gd.Grade = text;
                            gd.AddedOn = DateTime.Now.Date;
                            gd.IsActive = true;
                            db.PMGrades.Add(gd);
                            db.SaveChanges();
                            objEntity.SubPMGradeId = gd.Id;
                        }
                        else
                            objEntity.SubPMGradeId = item.Id;
                    }


                    int cpCount = Convert.ToInt32(rdaSubCapacity.Entries.Count.ToString());
                    if (cpCount == 0)
                    {

                        if (hdnSubCapacity.Value != "")
                            objEntity.SubPMCapacityId = int.Parse(hdnSubCapacity.Value);
                        else
                            objEntity.SubPMCapacityId = null;
                    }
                    else
                    {
                        rhpdEntities db = new rhpdEntities();
                        PMCapacity cp = new PMCapacity();
                        string text = "";
                        foreach (AutoCompleteBoxEntry entry in rdaSubCapacity.Entries)
                        {
                            if (entry.Text != "")
                                text = entry.Text.Split(';')[0]; ;
                        }


                        var item = db.PMCapacities.SingleOrDefault(s => s.Unit == text);
                        if (item == null)
                        {
                            cp.Unit = text;
                            cp.Capacity = 0;
                            cp.AddedOn = DateTime.Now.Date;
                            cp.IsActive = true;
                            db.PMCapacities.Add(cp);
                            db.SaveChanges();
                            objEntity.SubPMCapacityId = cp.Id;
                        }
                        else
                            objEntity.SubPMCapacityId = item.Id;
                    }

                    int nmCount = Convert.ToInt32(rdaSubPMName.Entries.Count.ToString());
                    if (nmCount == 0)
                    {

                        if (hdnSubPMName.Value != "")
                            objEntity.SubPMName = hdnSubPMName.Value;
                    }
                    else
                    {
                        // 
                        rhpdEntities db = new rhpdEntities();
                        PMName pmname = new PMName();
                        string text = "";
                        foreach (AutoCompleteBoxEntry entry in rdaSubPMName.Entries)
                        {
                            if (entry.Text != "")
                                text = entry.Text.Split(';')[0];
                        }

                        var item = db.PMNames.SingleOrDefault(s => s.Name == text);
                        if (item == null)
                        {
                            pmname.Name = text;
                            pmname.AddedOn = DateTime.Now.Date;
                            pmname.IsActive = true;
                            db.PMNames.Add(pmname); db.SaveChanges();

                        }

                        objEntity.SubPMName = text;
                    }
                }
                int  cdCount1 = Convert.ToInt32(txtCondition.Entries.Count.ToString());
                if (cdCount1 == 0)
                {

                    if (hdnPMCondition.Value != "")
                        objEntity.PMConditionId = int.Parse(hdnPMCondition.Value);
                    else
                        objEntity.PMConditionId = null;
                }
                else
                {
                    rhpdEntities db = new rhpdEntities();
                    PMCondition cn = new PMCondition();
                    string text = "";
                    foreach (AutoCompleteBoxEntry entry in txtCondition.Entries)
                    {
                        if (entry.Text != "")
                        text = entry.Text.Split(';')[0];
                    }

                    var item = db.PMConditions.SingleOrDefault(s => s.Condition == text);
                    if (item == null)
                    {
                        cn.Condition = text;
                        cn.AddedOn = DateTime.Now.Date;
                        cn.IsActive = true;
                        db.PMConditions.Add(cn);
                        db.SaveChanges();
                        objEntity.PMConditionId = cn.Id;
                    }
                    else
                        objEntity.PMConditionId = item.Id;
                }        
                
               int   gdCount1 = Convert.ToInt32(txtGrade.Entries.Count.ToString());
                if (gdCount1 == 0)
                {

                    if (hdnPMGrade.Value != "")
                        objEntity.PMGradeId = int.Parse(hdnPMGrade.Value);
                    else
                        objEntity.PMGradeId = null;
                }
                else
                {
                    rhpdEntities db = new rhpdEntities();                    
                    PMGrade gd = new PMGrade();
                    string text = "";
                    foreach (AutoCompleteBoxEntry entry in txtGrade.Entries)
                    {
                        if (entry.Text != "")
                            text = entry.Text.Split(';')[0];
                    }
                    var item = db.PMGrades.SingleOrDefault(s => s.Grade == text);
                    if (item == null)
                    {
                        gd.Grade = text;                       
                        gd.AddedOn = DateTime.Now.Date;
                        gd.IsActive = true;
                        db.PMGrades.Add(gd);
                        db.SaveChanges();
                        objEntity.PMGradeId = gd.Id;
                    }
                    else
                        objEntity.PMGradeId = item.Id;
                }        
                
               int  cpCount1 = Convert.ToInt32(txtCapacity.Entries.Count.ToString());
               if(cpCount1==0) { 
                    if(hdnPMCapacity.Value!="")
                         objEntity.PMCapacityId=int.Parse(hdnPMCapacity.Value);
                    else
                objEntity.PMCapacityId=null;
                }
                else
                {
                    rhpdEntities db = new rhpdEntities();
                    PMCapacity cp=new PMCapacity();
                    string text = "";
                    foreach (AutoCompleteBoxEntry entry in txtCapacity.Entries)
                    {
                        if (entry.Text != "")
                            text = entry.Text.Split(';')[0]; ;
                    }
                   
                                   
                    var item = db.PMCapacities.SingleOrDefault(s => s.Unit==text);
                    if (item == null)
                    {
                        cp.Unit =text;
                        cp.Capacity=0;
                        cp.AddedOn = DateTime.Now.Date;
                        cp.IsActive = true;
                        db.PMCapacities.Add(cp); 
                        db.SaveChanges();
                          objEntity.PMCapacityId=cp.Id;
                    }
                    else
                          objEntity.PMCapacityId=item.Id;
                }        
                
              int   nmCount1 = Convert.ToInt32(txtPackingMaterial.Entries.Count.ToString());
                if (nmCount1 == 0)
                {
                    if (hdnPMName.Value != "")
                        objEntity.PackagingMaterialName = hdnPMName.Value;
                }
                else
                {
                   // 
                    rhpdEntities db = new rhpdEntities();
                    PMName pmname = new PMName();
                    string text = "";
                    foreach (AutoCompleteBoxEntry entry in txtPackingMaterial.Entries)
                    {
                        if (entry.Text!="")
                            text = entry.Text.Split(';')[0];
                    }
                   
                    var item = db.PMNames.SingleOrDefault(s => s.Name == text);
                    if (item == null)
                    {
                        pmname.Name = text;
                        pmname.AddedOn = DateTime.Now.Date;
                        pmname.IsActive = true;
                        db.PMNames.Add(pmname); db.SaveChanges();                        
                    }
                    
                    objEntity.PackagingMaterialName = text;
                }
                int sCount = Convert.ToInt32(rdaSupplier.Entries.Count.ToString());
                if (sCount == 0)
                {
                    objEntity.OtherSupplier = hdnSupplier.Value;
                }
                else
                {
                    foreach (AutoCompleteBoxEntry entry in rdaSupplier.Entries)
                    {
                        if (sCount == 1)
                            objEntity.OtherSupplier = objEntity.OtherSupplier + entry.Text;
                        else
                            objEntity.OtherSupplier = objEntity.OtherSupplier + entry.Text + ",";
                        sCount--;
                        rhpdEntities db = new rhpdEntities();
                        supplier objcmd = new supplier();
                        var defIndex = (entry.Text).ToString();
                        var item = db.suppliers.SingleOrDefault(s => s.Name == defIndex);
                        if (item == null)
                        {

                            objcmd.Name = entry.Text;
                            objcmd.Address = "NA";
                            objcmd.IsActivated = true;
                            objcmd.ContactNo = null;
                            db.suppliers.Add(objcmd); db.SaveChanges();

                        }
                    }
                }

                objEntity.WeigthUnit = ddlWeightUnit.Text;
                if (double.Parse(rtxtWeight.Text) < 1 && double.Parse(rtxtWeight.Text) >= .5)
                {
                    if (objEntity.WeigthUnit == "KGS")
                    {
                        objEntity.Weight = double.Parse(rtxtWeight.Text) * 1000;
                        objEntity.WeigthUnit = "GRAMS";
                    }
                    else if (objEntity.WeigthUnit == "TONNES")
                    {
                        objEntity.Weight = double.Parse(rtxtWeight.Text) * 1000;
                        objEntity.WeigthUnit = "KGS";
                    }
                    else
                        objEntity.Weight = double.Parse(rtxtWeight.Text);

                }
                else if (double.Parse(rtxtWeight.Text) >= 1000)
                {
                    if (objEntity.WeigthUnit == "KGS")
                    {
                        objEntity.Weight = double.Parse(rtxtWeight.Text) / 1000;
                        objEntity.WeigthUnit = "TONNES";
                    }
                    else if (objEntity.WeigthUnit == "GRAMS")
                    {
                        objEntity.Weight = double.Parse(rtxtWeight.Text) / 1000;
                        objEntity.WeigthUnit = "KGS";
                    }
                    else
                        objEntity.Weight = double.Parse(rtxtWeight.Text);
                }
                else
                    objEntity.Weight = double.Parse(rtxtWeight.Text);
               
                objEntity.ShapeUnit = ddlUnit.Text;            
              
                objEntity.PackagingMaterialShape = ddlShape.SelectedItem.Value;
                switch (ddlShape.SelectedItem.Value)
                {
                    case "Sphere":
                        objEntity.PackagingMaterialSize = txtSpRadius.Text;
                        break;
                    case "Cube": objEntity.PackagingMaterialSize = txtCubeEdge.Text;
                        break;
                    case "Cuboid": objEntity.PackagingMaterialSize = txtCblength.Text + "X" + txtCbbreadth.Text + "X" + txtCbheight.Text;
                        break;
                    case "Cylinder": objEntity.PackagingMaterialSize = txtCyRadius.Text + "X" + txtCyHeight.Text;
                        break;
                    case "Other": objEntity.PackagingMaterialSize = txtOtherArea.Text;
                        break;
                }
                if (adProduct.Entries.Count == 0)
                {

                    objEntity.ProductId = int.Parse(hdnPID.Value);

                }
                else
                {
                    objEntity.ProductId = int.Parse(adProduct.Entries[0].Value);
                    foreach (AutoCompleteBoxEntry entry in adProduct.Entries)
                    {
                        objEntity.ProductId = int.Parse(entry.Value);
                    }
                }                
                objEntity.RecievedDate = Convert.ToDateTime(txtReceivedDate.SelectedDate);
                if (rbATNoSupNo.SelectedItem.Value == "2")
                    objEntity.RecievedFrom = "Local purchase";
                else
                    objEntity.RecievedFrom = "Central Procurement";
                objEntity.CostOfParticular = 0;             
                objEntity.AddedBy = 1;//need chnge
                objEntity.GenericName = "";
                string[] atno = rdxAtNo.Text.Split(',');
                string[] sono = rdxSupplierNo.Text.Split(',');
                int r = 0;
                if (int.Parse(hdnEditStock.Value) != 0)
                {
                    if (rbATNoSupNo.SelectedItem.Value == "1")
                    {
                        if (rdxAtNo.Text == "")
                            objEntity.ATNo = lblATNo.Text;
                        else
                            objEntity.ATNo = atno[0];
                        objEntity.SupplierNo = null;
                    }
                    else
                    {
                        if (rdxSupplierNo.Text == "")
                            objEntity.SupplierNo = lblSupNo.Text;
                        else
                            objEntity.SupplierNo = sono[0];
                        objEntity.ATNo = null;
                    }
                    objEntity.SID = r = int.Parse(hdnStockID.Value);
                    objCom.UpdateStockIn(objEntity);
                }
                else
                {
                    if (rbATNoSupNo.SelectedItem.Value == "1")
                    {
                        if (rdxAtNo.Text == "")
                            objEntity.ATNo = lblATNo.Text;
                        else
                            objEntity.ATNo = atno[0];

                        objEntity.SupplierNo = null;
                    }
                    else
                    {
                        if (rdxSupplierNo.Text == "")
                            objEntity.SupplierNo = lblSupNo.Text;
                        else
                            objEntity.SupplierNo = sono[0];
                        objEntity.ATNo = null;
                    }
                    if (objEntity.ATNo == null)
                    {
                        if (lblATNo.Text != "")
                            objEntity.ATNo = lblATNo.Text;
                        else
                            objEntity.ATNo = null;
                    }
                    if (objEntity.SupplierNo == null)
                    {
                        if (lblSupNo.Text == "")
                            objEntity.SupplierNo = null;
                        else
                            objEntity.SupplierNo = lblSupNo.Text;
                    }
                    r = objCom.InsertStockIn(objEntity);
                }
                string stockIDs = "";
                string[] stockArr = stockIDs.Split(',');

                if (Request.QueryString["sId"] != null)
                {
                    stockIDs = Request.QueryString["sId"].ToString();
                    stockArr = Request.QueryString["sId"].ToString().Split(',');
                }
                if (int.Parse(hdnEditStock.Value) == 0)
                {
                    // Index = 1;
                    if (stockIDs != "")

                        Response.Redirect("~/Forms/stock.aspx?sId=" + stockIDs + "," + r);
                    else
                        Response.Redirect("~/Forms/stock.aspx?sId=" + r);
                }
                else
                {
                    if (stockIDs != "")

                        Response.Redirect("~/Forms/stock.aspx?sId=" + stockIDs);
                    else
                        Response.Redirect("~/Forms/stock.aspx");
                }

                hdnEditStock.Value = "0";
                hdnPMCapacity.Value = "";                
                hdnPMCondition.Value = "";
                hdnPMGrade.Value = "";
                hdnPMName.Value = "";
                hdnSupplier.Value = "";
                hdnSubPMName.Value = "";
                hdnSubGrade.Value = "";
                hdnSubCondition.Value = "";
                hdnSubCapacity.Value = "";
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnEditStock_Click(object sender, EventArgs e)
        {
            try
            {
                rhpdEntities db = new rhpdEntities();
                DataTable dt = new DataTable();
                StockDAL obj = new StockDAL();
                dt = obj.Select(int.Parse(hdnStockID.Value));
                if (dt.Rows.Count > 0)
                {
                    ddlSession.SelectedValue = Convert.ToDateTime(dt.Rows[0]["Session"].ToString()).Year.ToString();
                    lblSession.Text = "-" +( Convert.ToDateTime(dt.Rows[0]["Session"].ToString()).Year+1).ToString();
                    _GetddlShapeSub();
                    _GetddlShape();
                    hdnEditStock.Value = "1";
                    reqATNo.Enabled = false;
                    reqSup.Enabled = false;
                    prprprr.Enabled = false;
                    divStock.Visible = true;
                    divStockGrid.Visible = false;
                    rtxtWeight.Text = dt.Rows[0]["Weight"].ToString();
                    //ddlRecievedFrom.SelectedValue = dt.Rows[0]["RecievedFrom"].ToString();
                    hdnSupplier.Value = dt.Rows[0]["OtherSupplier"].ToString();
                   
                    if (hdnSupplier.Value != "")
                    {
                        lblSupplier.Text = "[ " + dt.Rows[0]["OtherSupplier"].ToString() + " ]";
                        reqSupplier.Enabled = false;
                    }
                    rbtnListTransferedBy.SelectedValue = dt.Rows[0]["TransferedBy"].ToString();
                    //  txtChallanIRNo.Text = dt.Rows[0]["ChallanOrIrNo"].ToString();
                    if (dt.Rows[0]["ATNo"].ToString() != "")
                    {
                        rbATNoSupNo.SelectedValue = "1";
                        lblATNo.Text = dt.Rows[0]["ATNo"].ToString();
                        lblATNo.Visible = true;
                    }
                    else
                    {
                        rbATNoSupNo.SelectedValue = "2";
                        lblSupNo.Text = dt.Rows[0]["SupplierNo"].ToString();
                        lblSupNo.Visible = true;
                    }
                    hdnPID.Value = dt.Rows[0]["ProductId"].ToString();
                    lblProduct.Text = "[" + dt.Rows[0]["ITEMS"].ToString() + "]";
                    hdnOM.Value = dt.Rows[0]["OriginalManf"].ToString();
                    lblOM.Text = "[" + dt.Rows[0]["OriginalManf"].ToString() + "]";
                    rqOM.Enabled = false;
                    //txtGenericName.Text = dt.Rows[0]["GenericName"].ToString();
                   // txtCostOfParticular.Text = dt.Rows[0]["CostOfParticular"].ToString();
                    txtReceivedDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["RecievedOn"].ToString());
                    //string[] gd = dt.Rows[0]["PackingMaterial"].ToString().Split(' ');
                    // txtPackingMaterial.Text = gd[0];// dt.Rows[0]["PackingMaterial"].ToString();
                    // ddlPMGrade.SelectedValue = dt.Rows[0]["PMGrade"].ToString();

                    if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == true)
                    {
                        rbtnPacking.SelectedValue = "1";
                         rqPMName.Enabled = true;
                divFormat.Visible = false;
              //  B.Visible = false;
                pnlPMName.Visible = true;

                cbxSubPack.Visible = false;
                cbxDW.Visible = false;
           
               
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == true)
                    {
                        rbtnPacking.SelectedValue = "2";
                         rqPMName.Enabled = false;
                divFormat.Visible = false;
               // dvWeight.Visible = false;
                lblWeigth.Text = "Weight of particular:";
                pnlPMName.Visible = false;
                cbxSubPack.Visible = false;
                cbxDW.Visible = false;
                    }
                    else
                    {
                        if (Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == true)
                        {

                            cbxSubPack.Checked = true;
                            pnlSupPack.Visible = true;
                            lblSubPMName.Text = "[ " + dt.Rows[0]["SubPMName"].ToString() + " ]";
                            hdnSubPMName.Value = dt.Rows[0]["SubPMName"].ToString();

                           

                            if (dt.Rows[0]["SubPMConditionId"].ToString() != "")
                            {
                                int cid = int.Parse(dt.Rows[0]["SubPMConditionId"].ToString());
                                PMCondition cn = new PMCondition();
                                var pmCond = db.PMConditions.SingleOrDefault(s => s.Id == cid);
                                if (pmCond != null)
                                {
                                    hdnSubCondition.Value = cid.ToString();
                                    lblSubCondition.Text = " [ " + pmCond.Condition + " ]";
                                }
                            }
                            if (dt.Rows[0]["SubPMCapacityId"].ToString() != "")
                            {
                                int cid = int.Parse(dt.Rows[0]["SubPMCapacityId"].ToString());

                                PMCapacity cn = new PMCapacity();
                                var pmCond = db.PMCapacities.SingleOrDefault(s => s.Id == cid);
                                if (pmCond != null)
                                {
                                    hdnSubCapacity.Value = cid.ToString();
                                  lblSubCapacity.Text = " [ " + pmCond.Unit + " ]";
                                }
                            }
                            if (dt.Rows[0]["SubPMGradeId"].ToString() != "")
                            {
                                int cid = int.Parse(dt.Rows[0]["SubPMGradeId"].ToString());

                                PMGrade cn = new PMGrade();
                                var pmCond = db.PMGrades.SingleOrDefault(s => s.Id == cid);
                                if (pmCond != null)
                                {

                                 hdnSubGrade.Value = cid.ToString();
                                 lblSubGrade.Text = " [ " + pmCond.Grade + " ]";
                                }
                            }
                            _GetddlShapeSub();
                            if (dt.Rows[0]["SubWeight"].ToString() != "")
                            {
                                ddlSubWeight.SelectedValue = dt.Rows[0]["SubWeightUnit"].ToString();
                                rnSubPMWeight.Text = dt.Rows[0]["SubWeight"].ToString();
                            }
                            if (dt.Rows[0]["SubPMShape"].ToString() != "")
                            {
                                ddlSubShape.SelectedValue = dt.Rows[0]["SubPMShape"].ToString();


                                switch (dt.Rows[0]["SubPMShape"].ToString())
                                {

                                    case "Sphere":
                                        dvSubSphere.Visible = true;
                                        string[] sp = dt.Rows[0]["SubPMSize"].ToString().Split(new char[] { 'X' });
                                        rnSphereR.Text = sp[0].ToString();

                                        break;
                                    case "Cube":
                                        dvSubCube.Visible = true;
                                        string[] cb = dt.Rows[0]["SubPMSize"].ToString().Split(new char[] { 'X' });
                                        rnSubCubeRadius.Text = cb[0].ToString();

                                        break;
                                    case "Cuboid":
                                        dvSubCuboid.Visible = true;
                                        string[] c = dt.Rows[0]["SubPMSize"].ToString().Split(new char[] { 'X' });
                                        rnSubCuboidLngth.Text = c[0].ToString();
                                        rnSubCuboidBrth.Text = c[1].ToString();
                                        rnSubCuboidHeight.Text = c[2].ToString();

                                        break;
                                    case "Cylinder":
                                        dvSubCylinder.Visible = true;
                                        string[] cy = dt.Rows[0]["SubPMSize"].ToString().Split(new char[] { 'X' });
                                        rnSubCylinderRadius.Text = cy[0].ToString();
                                        rnSubCylinderHeight.Text = cy[1].ToString();

                                        break;
                                    case "Other":
                                        dvSubOther.Visible = true;
                                        string[] oa = dt.Rows[0]["SubPMSize"].ToString().Split(new char[] { 'X' });
                                        txtSubOtherInfo.Text = oa[0].ToString();

                                        break;
                                }
                            }
                            ddlSubShapeUnit.Visible = true;
                        }
                        rbtnPacking.SelectedValue = "0";
                         rqPMName.Enabled = true;
                divFormat.Visible = true;
                dvWeight.Visible = true;
                pnlPMName.Visible = true;
                cbxDW.Visible = true;
                    }
                    rqPMName.Enabled = false;
                    lblPMName.Text = "[ " + dt.Rows[0]["PMName"].ToString() + " ]";
                    hdnPMName.Value = dt.Rows[0]["PMName"].ToString();

                 

                    if (dt.Rows[0]["PMConditionId"].ToString() != "")
                    {
                        int cid = int.Parse(dt.Rows[0]["PMConditionId"].ToString());
                        PMCondition cn = new PMCondition();
                        var pmCond = db.PMConditions.SingleOrDefault(s => s.Id == cid);
                        if (pmCond != null)
                        {
                            hdnPMCondition.Value = cid.ToString();
                            lblPMCondition.Text = " [ " + pmCond.Condition + " ]";
                        }
                    }
                    if (dt.Rows[0]["PMCapacityId"].ToString() != "")
                    {
                        int cid = int.Parse(dt.Rows[0]["PMCapacityId"].ToString());

                        PMCapacity cn = new PMCapacity();
                        var pmCond = db.PMCapacities.SingleOrDefault(s => s.Id == cid);
                        if (pmCond != null)
                        {

                            hdnPMCapacity.Value = cid.ToString();
                            lblPMCapacity.Text = " [ " +pmCond.Unit + " ]";
                        }
                    }
                    if (dt.Rows[0]["PMGradeId"].ToString()!= "")
                    {
                        int cid = int.Parse(dt.Rows[0]["PMGradeId"].ToString());

                        PMGrade cn = new PMGrade();
                        var pmCond = db.PMGrades.SingleOrDefault(s => s.Id == cid);
                        if (pmCond != null)
                        {

                            hdnPMGrade.Value = cid.ToString();
                            lblPMGrade.Text = " [ " + pmCond.Grade + " ]";
                        }
                    }

                    txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();

                    if (Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == true)
                    {
                        cbxDW.Checked = true;
                        divFormat.Visible = false;
                       // dvWeight.Visible = false;
                        lblWeigth.Text = "Weight of particular:";
                        cbxSubPack.Visible = false;
                    }
                    else
                    {
                        divFormat.Visible = true;
                      //  dvWeight.Visible = true;
                        cbxDW.Checked = false;
                        
                        int level = int.Parse(dt.Rows[0]["PackagingMaterialFormatLevel"].ToString());

                        string[] fr = dt.Rows[0]["PackingMaterialFormat"].ToString().Split(new char[] { 'X' });
                        int k = 0;
                        foreach (Control cnt in phFormat.Controls)
                        {
                            if (cnt is RadNumericTextBox)
                            {
                                if (level > 0)
                                {
                                    RadNumericTextBox rdx = (RadNumericTextBox)cnt;

                                    rdx.Text = fr[k].ToString();
                                    k++;
                                    level = level - 1;
                                }

                            }
                        }
                        if (level > 0)
                        {
                            for (int i = k; i < level; i++)
                            {
                                Label lbl = new Label();
                                RadNumericTextBox rdx = new RadNumericTextBox();
                                lbl.Text = "X";
                                rdx.Height = 25;
                                rdx.Width = 30;
                                rdx.Text = fr[i].ToString();
                                rdx.NumberFormat.DecimalDigits = 0;
                                phFormat.Controls.Add(lbl);
                                phFormat.Controls.Add(rdx);
                                level = level - 1;
                            }
                        }
                    }
                    _GetddlShape();
                   
                    ddlShape.SelectedValue = dt.Rows[0]["PackagingMaterialShape"].ToString();
                    ddlUnit.SelectedValue = dt.Rows[0]["ShapeUnit"].ToString();
                    ddlWeightUnit.SelectedValue = dt.Rows[0]["WeigthUnit"].ToString();
                    switch (dt.Rows[0]["PackagingMaterialShape"].ToString())
                    {

                        case "Sphere":
                            dvShpere.Visible = true;
                            string[] sp = dt.Rows[0]["PackagingMaterialSize"].ToString().Split(new char[] { 'X' });
                            txtSpRadius.Text = sp[0].ToString();

                            break;
                        case "Cube":
                            dvCube.Visible = true;
                            string[] cb = dt.Rows[0]["PackagingMaterialSize"].ToString().Split(new char[] { 'X' });
                            txtCubeEdge.Text = cb[0].ToString();

                            break;
                        case "Cuboid":
                            dvCuboid.Visible = true;
                            string[] c = dt.Rows[0]["PackagingMaterialSize"].ToString().Split(new char[] { 'X' });
                            txtCblength.Text = c[0].ToString();
                            txtCbbreadth.Text = c[1].ToString();
                            txtCbheight.Text = c[2].ToString();

                            break;
                        case "Cylinder":
                            dvCylinder.Visible = true;
                            string[] cy = dt.Rows[0]["PackagingMaterialSize"].ToString().Split(new char[] { 'X' });
                            txtCyRadius.Text = cy[0].ToString();
                            txtCyHeight.Text = cy[1].ToString();

                            break;
                        case "Other":
                            dvOther.Visible = true;
                            string[] oa = dt.Rows[0]["PackagingMaterialSize"].ToString().Split(new char[] { 'X' });
                            txtOtherArea.Text = oa[0].ToString();

                            break;
                    }
                    ddlUnit.Visible = true;
                }
                if (Case == 4)
                    divFormat.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlBatch_DataBound(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ListItem li = new ListItem();
                    li.Value = "0";
                    li.Text = "-- Select --";
                    GridFooterItem footeritem = (GridFooterItem)rgdVehicle.MasterTableView.GetItems(GridItemType.Footer)[0];
                    DropDownList ddlBatch = (DropDownList)footeritem.FindControl("ddlBatch");
                    ddlBatch.Items.Insert(0, li);


                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btnSubmitBatch_Click(object sender, EventArgs e)
        {
            try
            {
                StockComp scmp = new StockComp();
                DataTable dt = new DataTable();
                dt = scmp.Select(int.Parse(hdnStockID.Value));
                if (dt.Rows.Count > 0)
                {
                    GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
                    TextBox txtBatchNo = (TextBox)footeritem.FindControl("txtBatchNo");
                    //  TextBox txtMfgDate = (TextBox)footeritem.FindControl("txtMfgDate");
                    RadDatePicker txtMfgDate = (RadDatePicker)footeritem.FindControl("txtMfgDate");
                    RadDatePicker txtExpiryDate = (RadDatePicker)footeritem.FindControl("txtExpiryDate");
                    RadMonthYearPicker txtESLDate = (RadMonthYearPicker)footeritem.FindControl("txtESLDate");
                    CheckBox cbxSampleSentB = (CheckBox)footeritem.FindControl("cbxSampleSentB");
                    TextBox txtContactNo = (TextBox)footeritem.FindControl("txtContactNo");
                    TextBox txtRemarks = (TextBox)footeritem.FindControl("txtRemarks");
                    RadNumericTextBox txtCost = (RadNumericTextBox)footeritem.FindControl("txtCost");
                    Button btnSubmitBatch = (Button)footeritem.FindControl("btnSubmitBatch");
                   DropDownList ddlWarehouse = (DropDownList)footeritem.FindControl("ddlWarehouse");
                    RadNumericTextBox txtRows = (RadNumericTextBox)footeritem.FindControl("txtRows");
                    RadNumericTextBox txtColumns = (RadNumericTextBox)footeritem.FindControl("txtColumns");
                    StockBatchComp bComp = new StockBatchComp();
                    StockBatchEntity bEntity = new StockBatchEntity();
                    double cost = 0;
                    cost = bEntity.CostOfParticular = Convert.ToDouble(txtCost.Text);
                    bEntity.WarehouseNo = ddlWarehouse.SelectedItem.Text;
                    string[] WS = bEntity.WarehouseNo.Split('/');
                    rhpdEntities db = new rhpdEntities();
                    if (WS.Count() > 0)
                    {
                        string W = WS[0].ToString();
                        var wh = db.tblWarehouses.Where(x => x.WareHouseNo ==W).FirstOrDefault();
                        if (wh != null)
                            bEntity.WarehouseID = wh.ID;
                        if (WS.Count() > 1)
                        {
                            string S= WS[1].ToString();
                            var SCN = db.tblSections.Where(s => s.Section == S).FirstOrDefault();
                            if (SCN != null)
                                bEntity.SectionID = SCN.ID;
                            
                        }
                    }
                    if (txtRows.Text != "")
                        bEntity.SectionRows = int.Parse(txtRows.Text);
                    if (txtColumns.Text != "")
                        bEntity.SectionCol = int.Parse(txtColumns.Text);
                    bEntity.BatchNo = txtBatchNo.Text;
                    bEntity.StockId = Convert.ToInt32(hdnStockID.Value);
                    bEntity.SampleSent = cbxSampleSentB.Checked;
                    RadNumericTextBox txtSampleSentQty = (RadNumericTextBox)footeritem.FindControl("txtSampleSentQty");
                    if (TransferedBY == "None")
                    {
                        if(txtSampleSentQty.Text!="")
                        bEntity.SampleSentQty = Convert.ToDouble(txtSampleSentQty.Text);


                    }
                    else {
                        bEntity.ContactNo = txtContactNo.Text;
                    }
                    bEntity.MfgDate = (txtMfgDate.SelectedDate.Value);
                    if (txtESLDate.SelectedDate == null && txtExpiryDate.SelectedDate == null)
                    {
                        lblErrorBatch.Text = "* ESL/Expiry both can not be null!";
                        return;
                    }
                    if (txtExpiryDate.SelectedDate == null)
                        bEntity.ExpiryDate = null;
                    else
                        bEntity.ExpiryDate = (txtExpiryDate.SelectedDate.Value);
                    if (txtESLDate.SelectedDate == null)
                        bEntity.ESLDate = null;
                    else
                        bEntity.ESLDate = (txtESLDate.SelectedDate.Value);
                    bEntity.Remarks = txtRemarks.Text;
                    if (Convert.ToDateTime(dt.Rows[0]["RecievedOn"].ToString()) < (bEntity.MfgDate))
                    {
                        lblErrorBatch.Text = "* DOM can never be Greater than Recieved date!";
                        return;
                    }
                    if (bEntity.ESLDate != null)
                    {
                        if (bEntity.ESLDate < bEntity.MfgDate)
                        {
                            lblErrorBatch.Text = "* ESL can never be lesser than DOM!";
                            return;
                        }
                    }
                    if (bEntity.ExpiryDate != null)
                    {
                        if (bEntity.ExpiryDate < bEntity.MfgDate)
                        {
                            lblErrorBatch.Text = "* Expiry Date can never be lesser than DOM!";
                            return;
                        }
                    }
                    int bID = 0;
                    Boolean check = false;
                    if (btnSubmitBatch.Text == "Add")
                    {
                        bID = bComp.InsertBatch(bEntity);
                        check = true;
                    }
                    else
                    {
                        bID = Convert.ToInt32(hdnBatchId.Value);
                        bEntity.Id = sBID;
                        bID = bComp.UpdateBatch(bEntity);
                        _DeleteOnUpdate();
                        check = false;
                    }
                    if (bID == 0)
                    {

                        lblErrorBatch.Text = "* Batch No already exists !";
                        return;
                    }
                    else
                    {
                        lblErrorBatch.Text = "";
                        sBID = 0;
                    }
                    SpillageAdd = true;
                    SpillageList = false;
                    PackIntro = true;
                    PackList = false;
                    _BindData();
                    _GetBatch();
                    if (check == true)
                    {
                        footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
                        txtCost = (RadNumericTextBox)footeritem.FindControl("txtCost");
                        txtCost.Text = cost.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rgdBatch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            // if (!IsPostBack)
            {
                try
                {
                    //if (e.CommandName != null || e.CommandName != "")
                    {

                        StockBatchComp cmp = new StockBatchComp();
                        if (e.CommandName == "DeleteBatch")
                        {
                            int bID = Convert.ToInt32(e.CommandArgument.ToString());
                            cmp.Delete(bID);
                            _GetBatch();
                        }
                        else if (e.CommandName == "EditBatch")
                        {
                            int bID = Convert.ToInt32(e.CommandArgument.ToString());
                            sBID = bID;
                            hdnBatchId.Value = bID.ToString();
                            DataTable dtBatch = new DataTable();
                            dtBatch = cmp.Select(bID);
                            if (dtBatch.Rows.Count > 0)
                            {
                                GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
                                TextBox txtBatchNo = (TextBox)footeritem.FindControl("txtBatchNo");
                                // TextBox txtMfgDate = (TextBox)footeritem.FindControl("txtMfgDate");
                                RadDatePicker txtMfgDate = (RadDatePicker)footeritem.FindControl("txtMfgDate");

                                RadDatePicker txtExpiryDate = (RadDatePicker)footeritem.FindControl("txtExpiryDate");
                                RadMonthYearPicker txtESLDate = (RadMonthYearPicker)footeritem.FindControl("txtESLDate");
                                TextBox txtRemarks = (TextBox)footeritem.FindControl("txtRemarks");
                                //  TextBox txtWarehouseNo = (TextBox)footeritem.FindControl("txtWarehouseNo");
                                DropDownList ddlWarehouse = (DropDownList)footeritem.FindControl("ddlWarehouse");
                                RadNumericTextBox txtRows = (RadNumericTextBox)footeritem.FindControl("txtRows");
                                RadNumericTextBox txtColumns = (RadNumericTextBox)footeritem.FindControl("txtColumns");


                                TextBox txtContactNo = (TextBox)footeritem.FindControl("txtContactNo");
                                RadNumericTextBox txtCost = (RadNumericTextBox)footeritem.FindControl("txtCost");
                                CheckBox cbxSampleSentB = (CheckBox)footeritem.FindControl("cbxSampleSentB");
                                RadNumericTextBox txtSampleSentQty = (RadNumericTextBox)footeritem.FindControl("txtSampleSentQty");
                                cbxSampleSentB.Checked = Convert.ToBoolean(dtBatch.Rows[0]["IsSentto"].ToString());
                                if(cbxSampleSentB.Checked)
                                {
                                    if (TransferedBY == "None")
                                    {
                                        if (txtSampleSentQty.Text != "")
                                            txtSampleSentQty.Text = dtBatch.Rows[0]["SampleSentQty"].ToString(); ;


                                    }
                                    else {
                                         txtContactNo.Text= dtBatch.Rows[0]["ContactNo"].ToString();
                                    }
                                }
                                txtCost.Text = dtBatch.Rows[0]["CostOfParticular"].ToString();
                              //  txtWarehouseNo.Text = dtBatch.Rows[0]["WarehouseNo"].ToString();
                              ddlWarehouse.SelectedValue= dtBatch.Rows[0]["WarehouseNo"].ToString();
                               txtColumns.Text= dtBatch.Rows[0]["SectionCol"].ToString();
                                txtRows.Text= dtBatch.Rows[0]["SectionRows"].ToString();
                                txtBatchNo.Text = dtBatch.Rows[0]["BatchNo"].ToString();
                                if (dtBatch.Rows[0]["MFGDate"].ToString() != "")
                                {
                                    txtMfgDate.SelectedDate = Convert.ToDateTime(dtBatch.Rows[0]["MFGDate"]);//.ToString("dd-MM-yyyy");
                                }
                                if (dtBatch.Rows[0]["EXPDate"].ToString()!= "")
                                    txtExpiryDate.SelectedDate = Convert.ToDateTime(dtBatch.Rows[0]["EXPDate"]);//.ToString("dd-MM-yyyy");
                                if (dtBatch.Rows[0]["Esl"].ToString()!="")
                                    txtESLDate.SelectedDate = Convert.ToDateTime(dtBatch.Rows[0]["Esl"]);//.ToString("dd-MM-yyyy");
                              
                                txtRemarks.Text = dtBatch.Rows[0]["Remarks"].ToString();

                                Button btnSubmitBatch = (Button)footeritem.FindControl("btnSubmitBatch");
                                btnSubmitBatch.Text = "Update";
                            }
                        }

                    }
                    rgdBatch.Focus();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected void rgdVehicle_ItemCommand(object sender, GridCommandEventArgs e)
        {
            //if (e.CommandName != null || e.CommandName.ToString() != "")
            {
                try
                {
                    StockVehicleComp vCOmp = new StockVehicleComp();
                    if (e.CommandName == "DeleteVehicle")
                    {
                        int vID = Convert.ToInt32(e.CommandArgument.ToString());
                        vCOmp.Delete(vID);
                        _GetVehicle();
                    }
                    else
                        if (e.CommandName == "EditVehicle")
                        {
                            int vID = Convert.ToInt32(e.CommandArgument.ToString());

                            sVID = vID;
                            hdnVehicle.Value = vID.ToString();
                            DataTable dt = new DataTable();
                            dt = vCOmp.Select(vID);
                            if (dt.Rows.Count > 0)
                            {
                                GridFooterItem footeritem = (GridFooterItem)rgdVehicle.MasterTableView.GetItems(GridItemType.Footer)[0];
                                TextBox txtDriverName = (TextBox)footeritem.FindControl("txtDriverName");
                                TextBox txtVehicleNo = (TextBox)footeritem.FindControl("txtVehicleNo");
                                TextBox txtChallanNo = (TextBox)footeritem.FindControl("txtChallanNo");
                                RadioButtonList rbtnDDCHT = (RadioButtonList)footeritem.FindControl("rbtnDDCHT");
                                RadNumericTextBox txtSentQty = (RadNumericTextBox)footeritem.FindControl("txtSentQty");
                                RadNumericTextBox txtRecievedQty = (RadNumericTextBox)footeritem.FindControl("txtRecievedQty");
                                DropDownList ddlBatch = (DropDownList)footeritem.FindControl("ddlBatch");
                                Button btnSubmitVehicle = (Button)footeritem.FindControl("btnSubmitVehicle");
                                Label lblBatchdll = (Label)footeritem.FindControl("lblBatchdll");
                                lblBatchdll.Visible = true;
                                rbtnDDCHT.SelectedValue = dt.Rows[0]["IsDDOrCHT"].ToString();
                                lblBatchdll.Text = dt.Rows[0]["BatchNo"].ToString();
                                Label lblBID = (Label)footeritem.FindControl("lblBID");
                                lblBID.Text = dt.Rows[0]["StockBatchId"].ToString();
                                ddlBatch.Visible = false;
                                btnSubmitVehicle.Text = "Update";
                                txtDriverName.Text = dt.Rows[0]["DriverName"].ToString();
                                txtVehicleNo.Text = dt.Rows[0]["VehicleNo"].ToString();
                                txtChallanNo.Text = dt.Rows[0]["ChallanNo"].ToString();
                                txtSentQty.Text = dt.Rows[0]["SentQty"].ToString();
                                txtRecievedQty.Text = dt.Rows[0]["RecievedQty"].ToString();
                                sBID = int.Parse(dt.Rows[0]["StockBatchId"].ToString());
                            }
                        }
                    rgdVehicle.Focus();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        protected void btnSubmitVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                GridFooterItem footeritem = (GridFooterItem)rgdVehicle.MasterTableView.GetItems(GridItemType.Footer)[0];
                TextBox txtDriverName = (TextBox)footeritem.FindControl("txtDriverName");
                TextBox txtVehicleNo = (TextBox)footeritem.FindControl("txtVehicleNo");
                TextBox txtChallanNo = (TextBox)footeritem.FindControl("txtChallanNo");
                RadNumericTextBox txtSentQty = (RadNumericTextBox)footeritem.FindControl("txtSentQty");
                RadNumericTextBox txtRecievedQty = (RadNumericTextBox)footeritem.FindControl("txtRecievedQty");
                RadioButtonList rbtnDDCHT = (RadioButtonList)footeritem.FindControl("rbtnDDCHT");
                DropDownList ddlBatch = (DropDownList)footeritem.FindControl("ddlBatch");
                Button btnSubmitVehicle = (Button)footeritem.FindControl("btnSubmitVehicle");
                StockVehicleComp vComp = new StockVehicleComp();
                StockVehicleEntity vEntity = new StockVehicleEntity();
                vEntity.IsDDOrCHT = rbtnDDCHT.SelectedValue;
                vEntity.DriverName = txtDriverName.Text;
                vEntity.VehicleNo = txtVehicleNo.Text;
                vEntity.ChallanNo = txtChallanNo.Text;
                vEntity.SentQty = Convert.ToDecimal(txtSentQty.Text);
                vEntity.RecievedQty = Convert.ToDecimal(txtRecievedQty.Text);
                if (vEntity.SentQty < vEntity.RecievedQty)
                {
                    lblVehilceError.Text = "* Recieved Qty can not be greater than Sent Qty!";
                    return;
                }
                vEntity.StockId = Convert.ToInt32(hdnStockID.Value);
                int v = 0;
                if (btnSubmitVehicle.Text == "Add")
                {
                    vEntity.StockBatchId = Convert.ToInt32(ddlBatch.SelectedItem.Value);
                    v = vComp.Insert(vEntity); hdnVehicle.Value = v.ToString();
                    _DeleteOnUpdate();
                }
                else
                {
                    vEntity.StockBatchId = sBID;
                    vEntity.Id = sVID;
                    v = vComp.Update(vEntity);
                    _DeleteOnUpdate();

                }

                if (v > 0)
                {
                    sBID = 0;
                    sVID = v;
                    SpillageAdd = true;
                    SpillageList = false;
                    PackIntro = true;
                    PackList = false;
                    _BindData();
                    hdnVehicle.Value = v.ToString();
                     footeritem = (GridFooterItem)rgdVehicle.MasterTableView.GetItems(GridItemType.Footer)[0];
                           rbtnDDCHT = (RadioButtonList)footeritem.FindControl("rbtnDDCHT");
                           rbtnDDCHT.SelectedValue = vEntity.IsDDOrCHT;
                           rbtnDDCHT.Enabled = false;
            
                }
                else
                {
                    lblVehilceError.Text = "* Vehicle already exists!";
                    return;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private double _CheckPackagingSppil(int BID, double damagedBoxes)
        {
            try
            {
               
                int stockId = Convert.ToInt32(hdnStockID.Value);
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
                    // if (PackIntro == true)
                    {

                        StringBuilder sb = new StringBuilder();                  

                        DataTable sDt = new DataTable();
                        StockSpillageComp sComp = new StockSpillageComp();
                        sDt = sComp.SelectByStockId(stockId);
                        if (sDt.Rows.Count > 0)
                        {
                            
                            double divider = 1;
                            double remainder = 0;
                            double qty = 1;

                           

                            hdnLevel.Value = level.ToString();

                            for (int i = 0; i < sDt.Rows.Count; i++)
                            {
                                if (int.Parse(sDt.Rows[i]["tBatchId"].ToString()) == BID)
                                {

                                    double recQty = Convert.ToDouble(sDt.Rows[i]["tSentQty"].ToString());
                                    //if (sDt.Rows[i]["SampleSentQty"].ToString() != "")
                                    //{ recQty = recQty + Convert.ToDouble(sDt.Rows[i]["SampleSentQty"].ToString()); }

                                    double Spilqty = Convert.ToDouble(sDt.Rows[i]["tSpilqty"].ToString());

                                    for (int l = 0; l < level; l++)
                                    {
                                        if (fr[l].ToString() != "")
                                        {
                                            qty = qty * Convert.ToDouble(fr[l].ToString());
                                        }
                                    }
                                    remainder = recQty % qty;//Loose
                                    recQty = recQty - remainder;//Full qty
                                    divider = recQty / qty;//Full PAckaging

                                    double sppilPack = 0;
                                    double sppilLoose = 0;

                                    sppilLoose = Spilqty % qty;//Spill loose
                                    sppilPack = Spilqty - sppilLoose;
                                    sppilPack = sppilPack / qty;
                                    if (remainder == 0)
                                    {
                                        if (sppilLoose.ToString("0.000") != "0.000")
                                        {
                                            sppilLoose = qty - sppilLoose;
                                            sppilPack = (Spilqty + sppilLoose) / qty;
                                        }
                                        sppilLoose = 0;

                                    }
                                    else if (remainder < Spilqty)
                                    {
                                        

                                        sppilLoose = Spilqty - remainder;
                                        sppilPack = sppilLoose % qty;
                                        sppilPack = (sppilLoose - sppilPack) / qty;
                                        sppilLoose = sppilLoose % qty;
                                        if (sppilLoose >remainder)
                                        {
                                            sppilLoose = qty - sppilLoose;
                                            sppilPack = ((Spilqty - remainder) + sppilLoose) / qty;
                                        }
                                        else if (sppilLoose < qty && TruncateDecimal(sppilLoose, 3).ToString() != "0,00")
                                        {
                                            sppilPack = sppilPack + 1;
                                        }
                                        sppilLoose = 0;

                                    }
                                    if (damagedBoxes < sppilPack)
                                    {
                                        lblSpilErr.Text = "* Spillage Damaged boxes can not be less than " + sppilPack.ToString("0") + " as per found Spillage in Batch No " + sDt.Rows[i]["BatchNo"].ToString() + "!";
                                        return 0;
                                    }
                                    if (divider == 0)
                                        return -1;
                                    else
                                        return divider;
                                    remainder = 0;
                                    qty = 1;
                                   
                                    sppilPack = 0;
                                    sppilLoose = 0;

                                }

                            }


                        }

                    }
                }
                return -1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private double _CheckPackagingSample(int BID, double damagedBoxes)
        {
            try
            {

                int stockId = Convert.ToInt32(hdnStockID.Value);
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
                    // if (PackIntro == true)
                    {

                        StringBuilder sb = new StringBuilder();

                        DataTable sDt = new DataTable();
                        StockSpillageComp sComp = new StockSpillageComp();
                        sDt = sComp.SelectByStockId(stockId);
                        if (sDt.Rows.Count > 0)
                        {

                            double divider = 1;
                            double remainder = 0;
                            double qty = 1;

                            double sppilPack = 0;
                            double sppilLoose = 0;


                            hdnLevel.Value = level.ToString();

                            for (int i = 0; i < sDt.Rows.Count; i++)
                            {
                                if (int.Parse(sDt.Rows[i]["tBatchId"].ToString()) == BID)
                                {

                                    double recQty = 0;// Convert.ToDouble(sDt.Rows[i]["tSentQty"].ToString());
                                    if (sDt.Rows[i]["SampleSentQty"].ToString() != "")
                                    {
                                        recQty = recQty + Convert.ToDouble(sDt.Rows[i]["SampleSentQty"].ToString());
                                         double Spilqty = Convert.ToDouble(sDt.Rows[i]["SampleSentQty"].ToString()); // Convert.ToDouble(sDt.Rows[i]["tSpilqty"].ToString());



                                         for (int l = 0; l < level; l++)
                                         {
                                             if (fr[l].ToString() != "")
                                             {
                                                 qty = qty * Convert.ToDouble(fr[l].ToString());
                                             }
                                         }
                                         remainder = recQty % qty;//Loose
                                         recQty = recQty - remainder;//Full qty
                                         divider = recQty / qty;//Full PAckaging


                                         sppilLoose = Spilqty % qty;//Spill loose
                                         sppilPack = Spilqty - sppilLoose;
                                         sppilPack = sppilPack / qty;
                                         if (remainder == 0)
                                         {
                                             if (sppilLoose.ToString("0.000") != "0.000")
                                             {
                                                 sppilLoose = qty - sppilLoose;
                                                 sppilPack = (Spilqty + sppilLoose) / qty;
                                             }
                                             sppilLoose = 0;

                                         }
                                         else if (remainder < Spilqty)
                                         {


                                             sppilLoose = Spilqty - remainder;
                                             sppilPack = sppilLoose % qty;
                                             sppilPack = (sppilLoose - sppilPack) / qty;
                                             sppilLoose = sppilLoose % qty;
                                             if (sppilLoose > remainder)
                                             {
                                                 sppilLoose = qty - sppilLoose;
                                                 sppilPack = ((Spilqty - remainder) + sppilLoose) / qty;
                                             }
                                             else if (sppilLoose < qty && TruncateDecimal(sppilLoose, 3).ToString() != "0,00")
                                             {
                                                 sppilPack = sppilPack + 1;
                                             }
                                             sppilLoose = 0;

                                         }
                                    }
                                        if (damagedBoxes < sppilPack)
                                        {
                                            lblSpilErr.Text = "* Sample Sent Damaged boxes can not be less than " + sppilPack.ToString("0") + " as per found Spillage in Batch No " + sDt.Rows[i]["BatchNo"].ToString() + "!";
                                            return 0;
                                        }
                                    
                                    if (divider == 0)
                                        return -1;
                                    else
                                        return divider;
                                    remainder = 0;
                                    qty = 1;
                                    
                                    sppilPack = 0;
                                    sppilLoose = 0;

                                }

                            }


                        }

                    }
                }
                return -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnPackSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int level = Convert.ToInt32(hdnLevel.Value);
                if (level > 0)
                {
                    sGetPacking = false;
                    int stockId = Convert.ToInt32(hdnStockID.Value);
                    foreach (GridDataItem dataItem in rgdFullPack.MasterTableView.Items)
                    {
                        StockPakagingComp pComp = new StockPakagingComp();
                        StockPakagingEntity pEntiy = new StockPakagingEntity();
                        Label lblBatchId = (Label)dataItem.FindControl("lblBatchID");
                        Label lblFormat = (Label)dataItem.FindControl("lblFormat");
                        Label lblQuantity = (Label)dataItem.FindControl("lblQuantity");
                        pEntiy.PackagingType = "Full";
                        pEntiy.StockBatchId = Convert.ToInt32(lblBatchId.Text);
                        pEntiy.Format = lblFormat.Text;
                        pEntiy.RemainingQty = Convert.ToDouble(lblQuantity.Text);
                        int p = pComp.Insert(pEntiy);
                    }
                    foreach (GridDataItem dataItem in rgdLoosePAck.MasterTableView.Items)
                    {
                        StockPakagingComp pComp = new StockPakagingComp();
                        StockPakagingEntity pEntiy = new StockPakagingEntity();
                        Label lblBatchId = (Label)dataItem.FindControl("lblBatchID");
                        Label lblQuantity = (Label)dataItem.FindControl("lblQuantity");
                        pEntiy.PackagingType = "Loose";
                        pEntiy.StockBatchId = Convert.ToInt32(lblBatchId.Text);
                        RadGrid rgdChild = (RadGrid)dataItem.FindControl("rgdChildLoosePAck");
                        pEntiy.Format = "";
                        GridFooterItem footeritem = (GridFooterItem)rgdChild.MasterTableView.GetItems(GridItemType.Footer)[0];

                        pEntiy.RemainingQty = Convert.ToDouble(lblQuantity.Text);
                        foreach (GridDataItem item in rgdChild.MasterTableView.Items)
                        {
                            int levelID = Convert.ToInt32(item.GetDataKeyValue("childID").ToString());
                            RadNumericTextBox txtLevel = (RadNumericTextBox)item.FindControl("txtLevel");
                            pEntiy.Format = pEntiy.Format + txtLevel.Text + "|";

                        }
                        pEntiy.Format = pEntiy.Format + pEntiy.RemainingQty.ToString(); ;
                        int p = pComp.Insert(pEntiy);

                    }

                }
                sGetPacking = true;
                Index = 5;
                PackIntro = false;
                PackList = true;
                _UpdateBatchWeigth();
                _BindData();
                _GetCRV();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void rgdLoosePAck_ItemCreated(object sender, GridItemEventArgs e)
        {
            // if(!IsPostBack)
            if (sLooseCount > 0)
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (e.Item as GridDataItem);
                    RadGrid rgdChild = (RadGrid)item.FindControl("rgdChildLoosePAck");
                    if (rgdChild != null)
                    {
                        sLooseCount = sLooseCount - 1;

                        DataTable dtChild = new DataTable();
                        dtChild.Columns.AddRange(new DataColumn[3] { 
                    new DataColumn("childID", typeof(int)),
                    new DataColumn("Level", typeof(string)),
                    new DataColumn("LevelID",typeof(string)) 
                   });
                        int level = Convert.ToInt32(hdnLevel.Value);
                        for (int l = 1; l < level; l++)
                        {
                            if (l == 1)
                                dtChild.Rows.Add(l, "Main Packet(s)", (l).ToString());
                            else if (l == level)
                                dtChild.Rows.Add(l, "Pieces/Qty ", (l).ToString());
                            else
                                dtChild.Rows.Add(l, "Level " + (l).ToString(), (l).ToString());
                        }
                        rgdChild.DataSource = dtChild;
                        rgdChild.DataBind();
                    }

                }

            }
        }

     

        protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DropDownList ddl = (DropDownList)sender;
                string value = ddl.SelectedItem.Value;
                GridFooterItem footeritem = (GridFooterItem)rgdVehicle.MasterTableView.GetItems(GridItemType.Footer)[0];
                TextBox txtVehicleNo = (TextBox)footeritem.FindControl("txtVehicleNo");
                TextBox txtDriverName = (TextBox)footeritem.FindControl("txtDriverName");
                DropDownList ddlBatch = (DropDownList)footeritem.FindControl("ddlBatch");
                StockBatchComp bComp = new StockBatchComp();
                DataTable dt = new DataTable();
                if (sVID != 0)
                {
                    dt = bComp.SelectByVehicle(int.Parse(hdnStockID.Value), txtDriverName.Text, txtVehicleNo.Text);
                    ddlBatch.DataSource = dt;
                    ddlBatch.DataBind();
                    if (dt.Rows.Count == 0)
                    {
                        ListItem li = new ListItem();
                        li.Value = "0";
                        li.Text = "-- No batch found --";
                        ddlBatch.Items.Insert(0, li);
                        lblVehilceError.Text = "* All batches are already introduced to this vehicle! ";
                        return;
                    }

                    else
                    {
                        ListItem li = new ListItem();
                        li.Value = "0";
                        li.Text = "-- Select --";
                        ddlBatch.Items.Insert(0, li);
                    }
                    
                    for (int i = 0; i < ddlBatch.Items.Count; i++)
                    {
                        if (ddlBatch.Items[i].Value == value)
                        {
                            ddlBatch.SelectedValue = value;
                        }
                    }
                }
                else
                {
                    dt = bComp.SelectByStockId(int.Parse(hdnStockID.Value));
                    ddlBatch.DataSource = dt;
                    ddlBatch.DataBind();


                    if (dt.Rows.Count == 0)
                    {
                        ListItem li = new ListItem();
                        li.Value = "0";
                        li.Text = "-- No batch found --";
                        ddlBatch.Items.Insert(0, li);
                        lblVehilceError.Text = "* All batches are already introduced to this vehicle! ";
                        return;
                    }

                    else
                    {
                        ListItem li = new ListItem();
                        li.Value = "0";
                        li.Text = "-- Select --";
                        ddlBatch.Items.Insert(0, li);
                        for (int i = 0; i < ddlBatch.Items.Count; i++)
                        {
                            if (ddlBatch.Items[i].Value == value)
                            {
                                ddlBatch.SelectedValue = value;
                            }
                        }
                    }
                }
                //if (sBID != 0)
                //{
                //    dt = bComp.Select(int.Parse(hdnVehicle.Value));
                  
                //    ddlBatch.DataSource = dt;
                //    ddlBatch.DataBind();
                //}
                //else if (txtVehicleNo.Text != "" && txtDriverName.Text != "")
                //{

                //    dt = bComp.SelectByVehicle(int.Parse(hdnStockID.Value), txtDriverName.Text, txtVehicleNo.Text);
                //   // DropDownList ddlBatch = (DropDownList)footeritem.FindControl("ddlBatch");
                //    ddlBatch.DataSource = dt;
                //    ddlBatch.DataBind();
                //    if (dt.Rows.Count > 0)
                //    {

                //        ListItem li = new ListItem();
                //        li.Value = "0";
                //        li.Text = "-- Select --";
                //        ddlBatch.Items.Insert(0, li);
                //        for (int i = 0; i < ddlBatch.Items.Count; i++)
                //        {
                //            if (ddlBatch.Items[i].Value == value)
                //            {
                //                ddlBatch.SelectedValue = value;
                //            }
                //        }

                //    }
                //    else
                //    {
                //        ListItem li = new ListItem();
                //        li.Value = "0";
                //        li.Text = "-- No batch found --";
                //        ddlBatch.Items.Insert(0, li);
                //        lblVehilceError.Text = "* All batches are already introduced to this vehicle! ";
                //        return;
                //    }
                //}

            }
            catch (Exception)
            {

                throw;
            }
        }


    
        protected void ddlShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string value = ddlShape.SelectedItem.Value.ToString();
                switch (value)
                {
                    case "Sphere":
                        dvShpere.Visible = true;
                        dvCube.Visible = false;
                        dvCuboid.Visible = false;
                        dvCylinder.Visible = false;
                        dvOther.Visible = false;
                        break;
                    case "Cube":
                        dvCube.Visible = true;
                        dvShpere.Visible = false;
                        dvCuboid.Visible = false;
                        dvCylinder.Visible = false;
                        dvOther.Visible = false;

                        break;
                    case "Cuboid":
                        dvCuboid.Visible = true;
                        dvCube.Visible = false;
                        dvShpere.Visible = false;

                        dvCylinder.Visible = false;
                        dvOther.Visible = false;

                        break;
                    case "Cylinder":
                        dvCylinder.Visible = true;
                        dvCube.Visible = false;
                        dvShpere.Visible = false;
                        dvCuboid.Visible = false;

                        dvOther.Visible = false;


                        break;
                    case "Other":
                        dvOther.Visible = true;
                        dvCube.Visible = false;
                        dvShpere.Visible = false;
                        dvCuboid.Visible = false;
                        dvCylinder.Visible = false;



                        break;
                }
                _GetddlShape();
                ddlShape.SelectedValue = value;
                ddlUnit.Visible = true;
                ddlShape.Focus();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cbxExpDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox cbx = (CheckBox)sender;
                ExpDate = cbx.Checked;
                foreach (GridColumn myColumn in rgdBatch.MasterTableView.RenderColumns)
                {
                    if (myColumn.UniqueName == "EXPDate")
                    {
                        myColumn.Visible = cbx.Checked;
                    }
                }
                _GetBatch();
                cbx.Focus();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cbxESLDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cbx = (CheckBox)sender;
                EslDate = cbx.Checked;
                _GetBatch();
                cbx.Focus();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmitAllBatch_Click(object sender, EventArgs e)
        {

            BatchEdit = false;
            BatchList = true;
            dvEditBatch.Visible = false;
            dvListBacth.Visible = true;
            Index = 2;
            _BindData();
        }

        protected void btnAddBatch_Click(object sender, EventArgs e)
        {

            BatchEdit = true;
            BatchList = false;
            dvEditBatch.Visible = true;
            dvListBacth.Visible = false;
            Index = 1;
            _BindData();
            sBID = 0;
        }

        protected void btnVEhicleSubmitAll_Click(object sender, EventArgs e)
        {
            VehicleEdit = false;
            VehicleList = true;
            divEditVehicle.Visible = VehicleEdit;
            divVehicleAll.Visible = VehicleList;
            Index = 3;
            _BindData();
            _GetPackaging();

            //divSppilageList.Visible = SpillageList=true;

        }

        protected void btnAddNEwVehicle_Click(object sender, EventArgs e)
        {

            VehicleEdit = true;
            VehicleList = false;
            divEditVehicle.Visible = VehicleEdit;
            divVehicleAll.Visible = VehicleList;
            // SpillageAdd = false;
            Index = 2;

            _BindData();
            sBID = 0;
        }


        protected void rgdIfSpillage_ItemCommand(object sender, GridCommandEventArgs e)
        {

            try
            {

                if (e.CommandName == "EditSpill")
                {


                    foreach (GridDataItem item in rgdIfSpillage.MasterTableView.Items)
                    {
                        HiddenField hdn = (HiddenField)item.FindControl("hdnIsSent");
                        Label lbl = (Label)item.FindControl("lblDamagedBoxes");
                        lbl.Visible = false;
                        Label lblBothQty = (Label)item.FindControl("lblBothQty");
                        Label lblSampleQty = (Label)item.FindControl("lblSampleQty");
                        Label lblSpillQty = (Label)item.FindControl("lblSpillQty");                       
                        RadNumericTextBox txtDamagedBox = (RadNumericTextBox)item.FindControl("txtDamagedBox");
                        RadNumericTextBox txtBothDamagedBox = (RadNumericTextBox)item.FindControl("txtBothDamagedBox");
                        RadNumericTextBox txtSampleDamagedBox = (RadNumericTextBox)item.FindControl("txtSampleDamagedBox");
                        RadNumericTextBox txtSppilDamagedBox = (RadNumericTextBox)item.FindControl("txtSppilDamagedBox");
                        txtDamagedBox.Visible = true;
                        txtSppilDamagedBox.Visible = true;
                        lblSpillQty.Visible = false;
                        if (Convert.ToBoolean(hdn.Value) == true)
                        {
                            lblBothQty.Visible = false;
                            lblSampleQty.Visible = false;
                            txtSampleDamagedBox.Visible = true;
                            txtBothDamagedBox.Visible = true;
                        }
                    }
                    GridFooterItem footeritem = (GridFooterItem)rgdIfSpillage.MasterTableView.GetItems(GridItemType.Footer)[0];
                    Button btnSpilEdit = (Button)footeritem.FindControl("btnSpilEdit");
                    btnSpilEdit.Visible = false;
                    Button btn = (Button)footeritem.FindControl("btnSubmitSpillage");
                    btn.Visible = true;
                    // Index = 4;
                    rgdIfSpillage.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static double qty = 0;
        static double qtyPack = 0;
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            _GetVehicle();
            _GetBatch();
            sBID = 0;
            sVID = 0;

        }

       

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (txtCRVNoVisible == false)
            {
                txtCRVNoVisible = true;
                txtCRVNo.Visible = true;
                rq.Enabled = true;
                btnCRVText = btnGenCRV.Text = "Submit";
                
                //Spillage
                if (SpillageList == true)
                {
                    GridFooterItem footeritem = (GridFooterItem)rgdIfSpillage.MasterTableView.GetItems(GridItemType.Footer)[0];
                    Button btnSpilEdit = (Button)footeritem.FindControl("btnSpilEdit");
                    btnSpilEdit.Visible = false;
                    btnSpilEditVisible = false;
                }
                //vehicle
                btnAddNEwVehicle.Visible = btnAddNEwVehicleVisible = false;
                //Batch
                btnAddBatch.Visible = btnAddBatchVisible = false;
                //Stcok
                btnEditStock.Visible = btnEditStockVisible = false;
                btnSubmitCRV.Visible = true;
                btnGenCRV.Visible = false;
            }
            //else
            //    if (btnGenCRV.Text == "Generate CRV" && txtCRVNoVisible == true)
            //    {


            //  //CRV


            //        btnCRVText = btnGenCRV.Text = "Submit";

            //        //Spillage
            //        if (SpillageList == true)
            //        {
            //            GridFooterItem footeritem = (GridFooterItem)rgdIfSpillage.MasterTableView.GetItems(GridItemType.Footer)[0];
            //            Button btnSpilEdit = (Button)footeritem.FindControl("btnSpilEdit");
            //            btnSpilEdit.Visible = false;
            //            btnSpilEditVisible = false;
            //        }
            //        //vehicle
            //        btnAddNEwVehicle.Visible = btnAddNEwVehicleVisible = false;
            //        //Batch
            //        btnAddBatch.Visible = btnAddBatchVisible = false;
            //        //Stcok
            //        btnEditStock.Visible = btnEditStockVisible = false;
            //    }
            //else if (btnGenCRV.Text == "Submit" &&  txtCRVNoVisible == true)
            //{
            //    //Save CRV
            //    string[] stockIDs = Request.QueryString["sID"].ToString().Split(',');
            //    for (int i = 0; i < stockIDs.Count(); i++)
            //    {
            //        StockComp cmp = new StockComp();
            //        cmp.AddCRVNo(int.Parse(stockIDs[i]), txtCRVNo.Text);
            //    }
            //        txtCRVEnable = txtCRVNo.Enabled = false;
            //        btnCRVText = btnGenCRV.Text = "Print CRV";



            //}
            //else
            //{
            //    //Print

            //    Response.Redirect("../Forms/PrintStockInCRV.aspx?sID=" + hdnStockID.Value);
            //}
            Index = 5;
            _BindData();

        }
        protected void btnSubmitCRV_Click(object sender, EventArgs e)
        {
            //if (txtCRVNoVisible == true)
            if (txtCRVNo.Text == "")
            {
                sBID = 0;
                _GetCRV();
                return;
            }

            {
                //Save CRV
                string[] stockIDs = Request.QueryString["sID"].ToString().Split(',');
                for (int i = 0; i < stockIDs.Count(); i++)
                {
                    StockComp cmp = new StockComp();
                    DataTable dt = new DataTable();
                    dt = cmp.Select(int.Parse(stockIDs[i]));
                    if (dt.Rows.Count > 0)
                    {
                        if (double.Parse(dt.Rows[0]["Quantity"].ToString()) == 0)
                        {
                            sBID = 0;
                            _GetCRV();
                            lblError.Text = "Kindly fill all required details,One of the Stock detail among all is pending!";
                            return;
                        }

                    }
                }
                for (int i = 0; i < stockIDs.Count(); i++)
                {
                    StockComp cmp = new StockComp();
                   int SID= cmp.AddCRVNo(int.Parse(stockIDs[i]), txtCRVNo.Text);
                   if (SID == 0)
                   {
                       _GetCRV();
                       lblError.Text = "CRV number already exists!";
                       return;
                   }
                }
                txtCRVEnable = txtCRVNo.Enabled = false;
                btnCRVText = btnGenCRV.Text = "Print CRV";



            }

            Index = 5;
            _BindData();
        }
        public static int c = 0;
        protected void btnAddTextbox_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                c = c + 1;
                Label[] lbl = new Label[c];

                RadNumericTextBox[] rdx = new RadNumericTextBox[c];

                for (int i = 0; i < c; i++)
                {
                    lbl[i] = new Label();
                    rdx[i] = new RadNumericTextBox();
                    lbl[i].Text = "X";
                    rdx[i].Height = 25;
                    rdx[i].Width = 30;
                    rdx[i].NumberFormat.DecimalDigits = 0;
                    phFormat.Controls.Add(lbl[i]);

                    phFormat.Controls.Add(rdx[i]);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rbATNoSupNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbATNoSupNo.SelectedItem.Value == "1")
            {
                rdxAtNo.Visible = true;
                reqATNo.Enabled = true;
                rdxSupplierNo.Visible = false;
                reqSup.Enabled = false;
            }
            else
            {
                rdxAtNo.Visible = false;
                reqATNo.Enabled = false;
                rdxSupplierNo.Visible = true;
                reqSup.Enabled = true;
            }
            rbATNoSupNo.Focus();
        }

        protected void btnSubmitCRV_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.CommandArgument != null)
            {
                int SID = int.Parse(btn.CommandArgument.ToString());
                StockComp cmp = new StockComp();
                cmp.Delete(SID);
                string[] stockIDs = Request.QueryString["sId"].ToString().Split(',');
                string qString = "";
                for (int i = 0; i < stockIDs.Count(); i++)
                {
                    if (stockIDs[i] != SID.ToString())
                    {
                        if (qString == "")
                        { qString = qString + stockIDs[i]; }
                        else
                        {
                            qString = qString+","  + stockIDs[i];
                        }
                    }
                }


                Response.Redirect("~/Forms/stock.aspx?sId=" + qString);


            }
        }

        protected void rgdPackingListLoose_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Edit")
                {
                    int ID = Convert.ToInt32(e.CommandArgument.ToString());
                    StockPakagingComp cmp = new StockPakagingComp();
                    DataTable dt = new DataTable();
                    dt = cmp.Select(ID);
                    if (dt.Rows.Count > 0)
                    {

                        LooseID.Value = ID.ToString();
                        string[] format = dt.Rows[0]["Format"].ToString().Split('|');



                        rgdEditLoosePAck.Visible = true;
                        rgdPackingListLoose.Visible = false;

                        DataTable dtChild = new DataTable();
                        dtChild.Columns.AddRange(new DataColumn[4] { 
                    new DataColumn("childID", typeof(int)),
                    new DataColumn("LooseID", typeof(int)),
                      new DataColumn("Level", typeof(string)),
                    new DataColumn("LevelID",typeof(string)) 
                   });


                        for (int l = 1; l < format.Count(); l++)
                        {
                            if (l == 1)
                                dtChild.Rows.Add(l, ID, "Batch No:" + dt.Rows[0]["BatchNo"].ToString() + "[" + dt.Rows[0]["Format"].ToString() + "]  <br />Main Packet(s)", (l).ToString());
                            else if (l == format.Count() - 1)
                                dtChild.Rows.Add(l, ID, "Pieces/Qty ", (l).ToString());
                            else
                                dtChild.Rows.Add(l, ID, "Level " + (l).ToString(), (l).ToString());
                        }
                        rgdEditLoosePAck.DataSource = dtChild;
                        rgdEditLoosePAck.DataBind();
                    }
                }
                rgdEditLoosePAck.Focus();
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void btnCancelLooseEdit_Click(object sender, EventArgs e)
        {

            _GetPackagingList();
            rgdEditLoosePAck.Visible = false;
            rgdPackingListLoose.Visible = true;

        }

        protected void btnUpdateLoose_Click(object sender, EventArgs e)
        {
            try
            {


                if (LooseID.Value != "0")
                {
                    int ID = int.Parse(LooseID.Value);
                    StockPakagingComp cmp = new StockPakagingComp();
                    DataTable dt = new DataTable();
                    dt = cmp.Select(ID);
                    if (dt.Rows.Count > 0)
                    {
                        StockPakagingComp pComp = new StockPakagingComp();
                        StockPakagingEntity pEntiy = new StockPakagingEntity();
                        pEntiy.PackagingType = "Loose";
                        pEntiy.StockBatchId = int.Parse(dt.Rows[0]["StockBatchId"].ToString());
                        pEntiy.Format = "";
                        pEntiy.RemainingQty = double.Parse(dt.Rows[0]["RemainingQty"].ToString());


                        foreach (GridDataItem item in rgdEditLoosePAck.MasterTableView.Items)
                        {

                            RadNumericTextBox txtLevel = (RadNumericTextBox)item.FindControl("txtLevel");
                            pEntiy.Format = pEntiy.Format + txtLevel.Text + "|";

                        }
                        pEntiy.Format = pEntiy.Format + pEntiy.RemainingQty.ToString(); ;
                        int p = pComp.Insert(pEntiy);

                    }


                    LooseID.Value = "0";
                    _UpdateBatchWeigth();
                    _GetBatch();
                    _GetPackagingList();
                    rgdEditLoosePAck.Visible = false;
                    rgdPackingListLoose.Visible = true;

                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rgdSppilage_ItemCreated(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (e.Item as GridDataItem);
                    int BID = int.Parse(item.GetDataKeyValue("tBatchId").ToString());
                    Label lbl = (Label)item.FindControl("lblSpilErr");
                    Label lblSpillSentBox = (Label)item.FindControl("lblSpillSentBox");
                    double sppilmin = _GetMinDamagedBoxSppil(BID);
                   lblSpillSentBox.Text = lblSpillSentBox.Text + sppilmin.ToString("0");                   

                   Label lblSampleSentBox = (Label)item.FindControl("lblSampleSentBox");
                   double sampleMin = _GetMinDamagedBoxSample(BID);

                   lblSampleSentBox.Text = lblSampleSentBox.Text + sampleMin.ToString("0");

                    //Total
                   lbl.Text = lbl.Text + (sppilmin ).ToString("0");

                   if (sppilmin == 0)
                   {
                       lbl.Text = "No spillage!";
                       lbl.ForeColor = System.Drawing.Color.Green;
                   }
                    else
                       lbl.ForeColor = System.Drawing.Color.Blue;
                   if (sppilmin == 0)
                       lblSpillSentBox.Visible = false;
                   if (sampleMin == 0)
                       lblSampleSentBox.Visible = false;
                    
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private double _GetMinDamagedBoxSample(int BID)
        {
            try
            {               
                double sppilPack = 0;
                double sppilLoose = 0;
                int stockId = Convert.ToInt32(hdnStockID.Value);
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
                                       
                        DataTable sDt = new DataTable();
                        StockSpillageComp sComp = new StockSpillageComp();
                        sDt = sComp.SelectByStockId(stockId);
                        if (sDt.Rows.Count > 0)
                        {
                           
                            double remainder = 0;
                            double qty = 1;                         

                            hdnLevel.Value = level.ToString();

                            for (int i = 0; i < sDt.Rows.Count; i++)
                            {
                                if (int.Parse(sDt.Rows[i]["tBatchId"].ToString()) == BID)
                                {//Full Packaging

                                    double recQty = Convert.ToDouble(sDt.Rows[i]["tSentQty"].ToString());
                                    if (sDt.Rows[i]["SampleSentQty"].ToString() != "")
                                    {
                                       // recQty = recQty + Convert.ToDouble(sDt.Rows[i]["SampleSentQty"].ToString());
                                        double Spilqty = Convert.ToDouble(sDt.Rows[i]["SampleSentQty"].ToString()); // Convert.ToDouble(sDt.Rows[i]["tSpilqty"].ToString());

                                        for (int l = 0; l < level; l++)
                                        {
                                            if (fr[l].ToString() != "")
                                            {
                                                qty = qty * Convert.ToDouble(fr[l].ToString());
                                            }
                                        }
                                        remainder = recQty % qty;//Loose

                                        sppilLoose = Spilqty % qty;//Spill loose
                                        sppilPack = Spilqty - sppilLoose;
                                        sppilPack = sppilPack / qty;
                                        if (remainder == 0)
                                        {
                                            if (sppilLoose.ToString("0.000") != "0.000")
                                            {
                                                sppilLoose = qty - sppilLoose;
                                                sppilPack = (Spilqty + sppilLoose) / qty;
                                            }

                                        }
                                        else if (remainder < Spilqty)
                                        {
                                            sppilLoose = Spilqty - remainder;
                                            sppilPack = sppilLoose % qty;
                                            sppilPack = (sppilLoose - sppilPack) / qty;
                                            sppilLoose = sppilLoose % qty;
                                            if (sppilLoose > remainder)
                                            {
                                                sppilLoose = qty - sppilLoose;
                                                sppilPack = ((Spilqty - remainder) + sppilLoose) / qty;
                                            }

                                            else if (sppilLoose < qty && TruncateDecimal(sppilLoose, 3).ToString() != "0,00")
                                            {
                                                sppilPack = sppilPack + 1;
                                            }

                                        }
                                    }
                                        return sppilPack;


                                    }
                               
                                
                            }


                         
                    }
                    
                }
                return sppilPack;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private double _GetMinDamagedBoxSppil(int BID)
        {
            try
            {
                double sppilPack = 0;
                double sppilLoose = 0;
                int stockId = Convert.ToInt32(hdnStockID.Value);
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

                    DataTable sDt = new DataTable();
                    StockSpillageComp sComp = new StockSpillageComp();
                    sDt = sComp.SelectByStockId(stockId);
                    if (sDt.Rows.Count > 0)
                    {

                        double remainder = 0;
                        double qty = 1;

                        hdnLevel.Value = level.ToString();

                        for (int i = 0; i < sDt.Rows.Count; i++)
                        {
                            if (int.Parse(sDt.Rows[i]["tBatchId"].ToString()) == BID)
                            {//Full Packaging

                                double recQty = Convert.ToDouble(sDt.Rows[i]["tSentQty"].ToString());
                                //if (sDt.Rows[i]["SampleSentQty"].ToString() != "")
                                //{ recQty = recQty + Convert.ToDouble(sDt.Rows[i]["SampleSentQty"].ToString()); }
                                double Spilqty = Convert.ToDouble(sDt.Rows[i]["tSpilqty"].ToString());

                                for (int l = 0; l < level; l++)
                                {
                                    if (fr[l].ToString() != "")
                                    {
                                        qty = qty * Convert.ToDouble(fr[l].ToString());
                                    }
                                }
                                remainder = recQty % qty;//Loose

                                sppilLoose = Spilqty % qty;//Spill loose
                                sppilPack = Spilqty - sppilLoose;
                                sppilPack = sppilPack / qty;
                                if (remainder == 0)
                                {
                                    if (sppilLoose.ToString("0.000") != "0.000")
                                    {
                                        sppilLoose = qty - sppilLoose;
                                        sppilPack = (Spilqty + sppilLoose) / qty;
                                    }

                                }
                                else if (remainder < Spilqty)
                                {
                                    sppilLoose = Spilqty - remainder;
                                    sppilPack = sppilLoose % qty;
                                    sppilPack = (sppilLoose - sppilPack) / qty;
                                    sppilLoose = sppilLoose % qty;
                                    if (sppilLoose > remainder)
                                    {
                                        sppilLoose = qty - sppilLoose;
                                        sppilPack = ((Spilqty - remainder) + sppilLoose) / qty;
                                    }

                                    else if (sppilLoose < qty && TruncateDecimal(sppilLoose, 3).ToString() != "0,00")
                                    {
                                        sppilPack = sppilPack + 1;
                                    }

                                }

                                return sppilPack;


                            }

                        }



                    }

                }
                return sppilPack;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rbtnPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnPacking.SelectedValue == "1")
            {
                rqPMName.Enabled = true;
                divFormat.Visible = false;
                pnlPMName.Visible = true;
                cbxDW.Visible = false;
                lblWeigth.Text = "Weight of single Full PM:";
            }
            else if (rbtnPacking.SelectedValue == "2")
            {
                rqPMName.Enabled = false;
                divFormat.Visible = false;
                pnlPMName.Visible = false;
                cbxDW.Visible = false;
                cbxSubPack.Visible = false;


                lblWeigth.Text = "Weight of particular:";
            }
            else
            {
                rqPMName.Enabled = true;
                divFormat.Visible = true;
                pnlPMName.Visible = true;
                cbxDW.Visible = true;
                lblWeigth.Text = "Weight of single Full PM:";
               
            }
            rbtnPacking.Focus();
        }

        protected void cbxDW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDW.Checked == true)
            {
                divFormat.Visible = false;
               // dvWeight.Visible = false;

                cbxSubPack.Visible = false;
                lblWeigth.Text = "Weight of particular:";

            }
            else
            {
                lblWeigth.Text = "Weight of single Full PM:";
                divFormat.Visible = true;
                dvWeight.Visible = true;
               
                if (txtPMFormat3.Text != "")
                {
                    cbxSubPack.Visible = true;
                }
                else
                { cbxSubPack.Visible = false; }
            }

            if (cbxSubPack.Checked == true)
                pnlSupPack.Visible = true;
            else
                pnlSupPack.Visible = false;
            cbxDW.Focus();
        }

        protected void ddlSubShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 string value = ddlSubShape.SelectedItem.Value.ToString();
                switch (value)
                {
                    case "Sphere":
                        
                        dvSubSphere.Visible = true;
                        dvSubCube.Visible = false;
                        dvSubCuboid.Visible = false;
                        dvSubCylinder.Visible = false;
                        dvSubOther.Visible = false;
                        break;
                    case "Cube":
                        dvSubCube.Visible = true;
                        dvSubSphere.Visible = false;
                        dvSubCuboid.Visible = false;
                        dvSubCylinder.Visible = false;
                        dvSubOther.Visible = false;

                        break;
                    case "Cuboid":
                        dvSubCuboid.Visible = true;
                        dvSubCube.Visible = false;
                        dvSubSphere.Visible = false;

                        dvSubCylinder.Visible = false;
                        dvSubOther.Visible = false;

                        break;
                    case "Cylinder":
                        dvSubCylinder.Visible = true;
                        dvSubCube.Visible = false;
                        dvSubSphere.Visible = false;
                        dvSubCuboid.Visible = false;

                        dvSubOther.Visible = false;


                        break;
                    case "Other":
                        dvSubOther.Visible = true;
                        dvSubCube.Visible = false;
                        dvSubSphere.Visible = false;
                        dvSubCuboid.Visible = false;
                        dvSubCylinder.Visible = false;

                        

                        break;
                }
                _GetddlShapeSub();
                ddlSubShape.SelectedValue = value;
                ddlSubShapeUnit.Visible = true;
                ddlSubShape.Focus();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnSubmitDW_Click(object sender, EventArgs e)
        {
            try
            {
                int SID = int.Parse(hdnStockID.Value);
                foreach (GridDataItem dataItem in rhdDWDefine.MasterTableView.Items)
                    {
                        StockPakagingComp pComp = new StockPakagingComp();
                        StockPakagingEntity pEntiy = new StockPakagingEntity();
                        int BID =Convert.ToInt32(dataItem.GetDataKeyValue("tBatchId"));                       
                        Label lblFormat = (Label)dataItem.FindControl("lblFormat");
                        Label lblQuantity = (Label)dataItem.FindControl("lblQuantity");
                        RadNumericTextBox txtPack = (RadNumericTextBox)dataItem.FindControl("txtPack");
                        pEntiy.PackagingType = "DW";
                        pEntiy.StockBatchId =BID;
                        pEntiy.Format = txtPack.Text+"XDW";
                        pEntiy.RemainingQty = Convert.ToDouble(lblQuantity.Text);
                        int p = pComp.Insert(pEntiy);
                    }
                _UpdateBatchWeigth();
                _BindData();
                _GetDW();
                _GetCRV();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void txtPMFormat3_TextChanged(object sender, EventArgs e)
        {
            if (txtPMFormat3.Text != "")
            {
                cbxSubPack.Visible = true;
            }
            else
            { cbxSubPack.Visible = false; }
            txtPMFormat3.Focus();
        }

        protected void cbxSampleSentB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
                   CheckBox cbxSampleSentB = (CheckBox)footeritem.FindControl("cbxSampleSentB");
                TextBox txtContactNo = (TextBox)footeritem.FindControl("txtContactNo");
                RadNumericTextBox txtSampleSentQty = (RadNumericTextBox)footeritem.FindControl("txtSampleSentQty");
                if (TransferedBY == "None")
                {
                    txtSampleSentQty.Visible = true;
                    txtContactNo.Visible = false;
                }
                else {
                    txtContactNo.Visible = true;
                    txtSampleSentQty.Visible = false;
                }
                cbxSampleSentB.Focus();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void btnSubmitSpillage_Click1(object sender, EventArgs e)
        {
            try
            {
                foreach (GridDataItem dataItem in rgdIfSpillage.MasterTableView.Items)
                {
                    HiddenField hdnIsSent = (HiddenField)dataItem.FindControl("hdnIsSent");

                    RadNumericTextBox txtDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtDamagedBox");
                    Label lblStockId = (Label)dataItem.FindControl("lblStockId");
                    Label lblSentQty = (Label)dataItem.FindControl("lblSentQty");
                    Label lblRecQty = (Label)dataItem.FindControl("lblRecQty");
                    Label lblSpilqty = (Label)dataItem.FindControl("lblSpilledQty");
                    Label lblBatch = (Label)dataItem.FindControl("lblBatch");
                    RadNumericTextBox txtSppilDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtSppilDamagedBox");
                    RadNumericTextBox txtSampleDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtSampleDamagedBox");
                    RadNumericTextBox txtBothDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtBothDamagedBox");
                    double totaSpillPack = _CheckPackagingSppil(Convert.ToInt32(lblBatch.Text), Convert.ToDouble(txtSppilDamagedBox.Text));

                    double totaSamplePAck = _CheckPackagingSample(Convert.ToInt32(lblBatch.Text), Convert.ToDouble(txtSampleDamagedBox.Text));
                    // if (totaFlullPacking == 0)
                  

                    if (totaSpillPack.ToString("0.00") == "0.00")
                    {


                        lblSpilErr.Visible = true;
                        return;
                    }
                    else if (Convert.ToBoolean(hdnIsSent.Value.ToString()) == true && totaSamplePAck.ToString("0.00") == "0.00")
                    {



                        lblSpilErr.Visible = true;
                        return;

                    }
                    else
                    {
                        lblSpilErr.Visible = false;
                        StockSpillageComp sComp = new StockSpillageComp();
                        StockSpillageEntity sEntity = new StockSpillageEntity();
                        sEntity.DamagedBoxes = Convert.ToDouble(txtDamagedBox.Text);
                        sEntity.SampleAffected = Convert.ToDouble(txtSampleDamagedBox.Text);
                        sEntity.SpillageAffected = Convert.ToDouble(txtSppilDamagedBox.Text);
                        sEntity.BothAffected = Convert.ToDouble(txtBothDamagedBox.Text);
                        sEntity.SpilledQty = Convert.ToDouble(lblSpilqty.Text);
                        sEntity.StockBatchId = Convert.ToInt32(lblBatch.Text);
                        sEntity.StockId = Convert.ToInt32(lblStockId.Text);
                        int s = sComp.Insert(sEntity);
                        //_DeleteOnUpdate();
                    }

                }
                Index = 4;
                SpillageAdd = false;
                SpillageList = true;
                sGetPacking = true;
                _GetPackaging();
                _BindData();
                ////
                string stockIDs = "";

                if (Request.QueryString["sId"] != null)
                {
                    stockIDs = Request.QueryString["sId"].ToString();

                }


                if (stockIDs != "")

                    Response.Redirect("~/Forms/stock.aspx?sId=" + stockIDs);
                else
                    Response.Redirect("~/Forms/stock.aspx");
                

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnSubmitSpillage_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridDataItem dataItem in rgdSppilage.MasterTableView.Items)
                {

                    int tBatchId = Convert.ToInt32(dataItem.GetDataKeyValue("tBatchId").ToString());
                    HiddenField hdnIsSent = (HiddenField)dataItem.FindControl("hdnIsSent");
                    RadNumericTextBox txtDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtDamagedBox");
                    Label lblStockId = (Label)dataItem.FindControl("lblStockId");
                    Label lblSentQty = (Label)dataItem.FindControl("lblSentQty");
                    Label lblSampleSentQty = (Label)dataItem.FindControl("lblSampleSentQty");
                    Label lblRecQty = (Label)dataItem.FindControl("lblRecQty");
                    Label lblSpilqty = (Label)dataItem.FindControl("lblSpilqty");
                    RadNumericTextBox txtSppilDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtSppilDamagedBox");
                    RadNumericTextBox txtSampleDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtSampleDamagedBox");
                    RadNumericTextBox txtBothDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtBothDamagedBox");

                    if (lblSpilqty.Text != "No spillage" && lblSpilqty.Text != "")// Convert.ToDouble(lblSpilqty.Text) > 0)
                    {
                        double totaSpillPack = _CheckPackagingSppil(tBatchId, Convert.ToDouble(txtSppilDamagedBox.Text));

                        double totaSamplePAck = _CheckPackagingSample(tBatchId, Convert.ToDouble(txtSampleDamagedBox.Text));
                        // if (totaFlullPacking == 0)
                        if (totaSpillPack.ToString("0.00") == "0.00")
                        {
                            

                            lblSpilErr.Visible = true;
                            return;
                        }
                        else if (Convert.ToBoolean(hdnIsSent.Value.ToString()) == true && totaSamplePAck.ToString("0.00") == "0.00")
                        {

                            

                                lblSpilErr.Visible = true;
                                return;
                            
                        }
                        else
                        {
                            lblSpilErr.Visible = false;
                            // if (Convert.ToDouble(txtDamagedBox.Text) < totaFlullPacking)
                            {
                                StockSpillageComp sComp = new StockSpillageComp();
                                StockSpillageEntity sEntity = new StockSpillageEntity();
                                sEntity.DamagedBoxes = Convert.ToDouble(txtDamagedBox.Text);
                                sEntity.SampleAffected = Convert.ToDouble(txtSampleDamagedBox.Text);
                                sEntity.SpillageAffected = Convert.ToDouble(txtSppilDamagedBox.Text);
                                sEntity.BothAffected = Convert.ToDouble(txtBothDamagedBox.Text);

                                sEntity.SpilledQty = Convert.ToDouble(lblSpilqty.Text);
                                sEntity.StockBatchId = tBatchId;
                                sEntity.StockId = Convert.ToInt32(lblStockId.Text);
                                int s = sComp.Insert(sEntity);
                            }
                            // else
                            //{
                            //    lblSpilErr.Text = "**** Total " + totaFlullPacking.ToString() + " full qty availble !";
                            //    _GetSpillage();
                            //    return;
                            //}
                        }
                    }


                }
               // _GetSpillage();

                Index = 4;
                SpillageAdd = false;
                SpillageList = true;
                sGetPacking = true;

                _BindData();
                _GetPackaging();
                ////
                string stockIDs = "";
                
                if (Request.QueryString["sId"] != null)
                {
                    stockIDs = Request.QueryString["sId"].ToString();
                  
                }

            
                
                    if (stockIDs != "")

                        Response.Redirect("~/Forms/stock.aspx?sId=" + stockIDs);
                    else
                        Response.Redirect("~/Forms/stock.aspx");
                



            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void txtSppilDamagedBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                RadNumericTextBox rdx = (RadNumericTextBox)sender;
                int BID = Convert.ToInt32(rdx.ToolTip);
                foreach (GridDataItem dataItem in rgdSppilage.MasterTableView.Items)
                {

                    int tBatchId = Convert.ToInt32(dataItem.GetDataKeyValue("tBatchId").ToString());
                    if (tBatchId == BID)
                    {
                        RadNumericTextBox txtDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtDamagedBox");
                        RadNumericTextBox txtSppilDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtSppilDamagedBox");
                        RadNumericTextBox txtSampleDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtSampleDamagedBox");
                        RadNumericTextBox txtBothDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtBothDamagedBox");
                        //double QTY = Convert.ToDouble(txtSppilDamagedBox.Text) + Convert.ToDouble(txtSampleDamagedBox.Text) + Convert.ToDouble(txtBothDamagedBox.Text);
                        double QTY = Convert.ToDouble(txtSppilDamagedBox.Text) + Convert.ToDouble(txtBothDamagedBox.Text);
                       
                        txtDamagedBox.Text = QTY.ToString("0");

                    }}

              
                    //foreach (GridDataItem item in rgdSppilage.MasterTableView.Items)
                    //{
                    //    int tBatchId = Convert.ToInt32(item.GetDataKeyValue("tBatchId").ToString());
                    
                 
                    //    Label lbl = (Label)item.FindControl("lblSpilErr");
                    //    Label lblSpillSentBox = (Label)item.FindControl("lblSpillSentBox");
                    //    double sppilmin = _GetMinDamagedBoxSppil(tBatchId);
                    //    lblSpillSentBox.Text = lblSpillSentBox.Text + sppilmin.ToString("0");

                    //    Label lblSampleSentBox = (Label)item.FindControl("lblSampleSentBox");
                    //    double sampleMin = _GetMinDamagedBoxSample(tBatchId);

                    //    lblSampleSentBox.Text = lblSampleSentBox.Text + sampleMin.ToString("0");

                    //    //Total
                    //    lbl.Text = lbl.Text + (sppilmin + sampleMin).ToString("0");

                    //    if (sppilmin == 0 && sampleMin == 0)
                    //    {
                    //        lbl.Text = "No spillage!";
                    //        lbl.ForeColor = System.Drawing.Color.Green;
                    //    }
                    //    else
                    //        lbl.ForeColor = System.Drawing.Color.Blue;
                    //    if (sppilmin == 0)
                    //        lblSpillSentBox.Visible = false;
                    //    if (sampleMin == 0)
                    //        lblSampleSentBox.Visible = false;
                    
                    //}
                 rdx.Focus();
                 return;
            }

            catch (Exception)
            {

                throw;
            }
        }

        protected void txtSppilDamagedBox_TextChanged1(object sender, EventArgs e)
        {
            try
            {
               
                RadNumericTextBox rdx = (RadNumericTextBox)sender;
                int BID = Convert.ToInt32(rdx.ToolTip);
                foreach (GridDataItem dataItem in rgdIfSpillage.MasterTableView.Items)
                {
                     
                    Label lbl = (Label)dataItem.FindControl("lblBatch");
                             int tBatchId = Convert.ToInt32(lbl.Text);
                    if (tBatchId == BID)
                    {
                        RadNumericTextBox txtDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtDamagedBox");
                        RadNumericTextBox txtSppilDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtSppilDamagedBox");
                        RadNumericTextBox txtSampleDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtSampleDamagedBox");
                        RadNumericTextBox txtBothDamagedBox = (RadNumericTextBox)dataItem.FindControl("txtBothDamagedBox");
                      //  double QTY = Convert.ToDouble(txtSppilDamagedBox.Text) + Convert.ToDouble(txtSampleDamagedBox.Text) + Convert.ToDouble(txtBothDamagedBox.Text);
                        double QTY = Convert.ToDouble(txtSppilDamagedBox.Text) +  Convert.ToDouble(txtBothDamagedBox.Text);
                     
                        txtDamagedBox.Text = QTY.ToString("0");
                    }
                }
                rdx.Focus();
                return;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}



