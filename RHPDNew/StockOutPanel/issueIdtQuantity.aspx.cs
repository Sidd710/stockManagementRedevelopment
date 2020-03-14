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
using System.Web.Script.Services;
using RHPDComponent;
using RHPDEntity;
using Telerik.Web.UI;
using RHPDNew;


namespace Demo1
{
    public partial class issueIdtQuantity : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //string prdname = "OIL";
        // int prdid = 37;
        //Need to get data from querystring and make it in session to use in asmx page
        //string dipuname = "DIPU1";
        // int DepuID=54;
        //Need to get data from querystring and make it in session to use in asmx page

       static int prdid;   //ViewState["dipuID"] need to get data from querystring
        int DepuID;   //ViewState["productId"] need to get data from querystring
        int quarterId;
        int typeID = 0;
         public static DataTable sdt = new DataTable();
         public static bool btnSubmitVisible = false;
         public static int countNext = 0;
         public static int countPrev = 0;
         public static string AU = "";
         public static int Case = 0;
         public static string stockCase = "";
         public static double WOP = 0;
        // public static int SID = 0;
         public static double formatQty = 1;
         public static double remIDT =0;
        protected void Page_Load(object sender, EventArgs e)
        { if (Session["UserDetails"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {
                       
                        lblremainingIDT.Text = "0";
                        btnSubmit.Visible = btnSubmitVisible;
                        txtRemarks.Visible = btnSubmitVisible;
                        sdt = new DataTable();
                        DepuID = Convert.ToInt32(Request.QueryString["Did"].ToString());
                        prdid = Convert.ToInt32(Request.QueryString["prdId"].ToString());
                        quarterId = Convert.ToInt32(Request.QueryString["qid"].ToString());
                        typeID = Convert.ToInt32(Request.QueryString["TypeId"].ToString());
                        rhpdEntities db = new rhpdEntities();
                        var stock = db.StockMasters.Where(x => x.ProductId == prdid).OrderByDescending(x => x.SID).FirstOrDefault();
                        if (stock != null)
                        {
                            int SID = Convert.ToInt32(stock.SID);
                            _CheckCase(SID); ;

                        }
                      _GetIssued();
                        getdremainingIDT();
                        getdproductDetail(prdid);
                        getDepuName(DepuID);
                       
                        if (txtIssuequantity.Text!="")
                        binddropdown(prdid);
                        if (sdt.Columns.Count == 0)
                        {
                           


                            sdt.Columns.Add("BID", typeof(Int32));
                            sdt.Columns.Add("BatchName", typeof(string));
                            sdt.Columns.Add("batchTotalQuantity", typeof(double));
                            sdt.Columns.Add("PackagingType", typeof(string));
                            sdt.Columns.Add("FullPack", typeof(string));
                            sdt.Columns.Add("LoosePack", typeof(string));
                            sdt.Columns.Add("Esl", typeof(string));
                            sdt.Columns.Add("SID", typeof(Int32));
                            sdt.Columns.Add("FullPackQty", typeof(double));
                            sdt.Columns.Add("LoosePackQty", typeof(double));
                            sdt.Columns.Add("txtFullQtyVal", typeof(double));
                            sdt.Columns.Add("txtLooseQtyVal", typeof(double));
                            sdt.Columns.Add("lblLooseQtyText", typeof(string));
                            sdt.Columns.Add("lblLooseRemQtyText", typeof(string));
                            sdt.Columns.Add("lblFullQtyText", typeof(string));
                            sdt.Columns.Add("lblFullRemQtyText", typeof(string));
                            sdt.Columns.Add("txtIssueQtyText", typeof(string));
                            sdt.Columns.Add("WeightofParticular", typeof(double));
                            sdt.Columns.Add("CostOfParticular", typeof(double));
                            sdt.Columns.Add("Remarks", typeof(string));
                            sdt.Columns.Add("CountNext", typeof(Int32));
                            sdt.Columns.Add("CountPrev", typeof(Int32));



                        }
                    } 
            }
            //if (sdt.Rows.Count > 0)
            //    btnSubmit.Visible = true;
            
        }

        private void _GetIssued()
        {
            try
            {
                  SqlCommand cmd = new SqlCommand("spGetIssuedIDT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pID", prdid);
            cmd.Parameters.AddWithValue("@dID", DepuID);
            cmd.Parameters.AddWithValue("@qID", quarterId);  
                 if(con.State.ToString()=="Close")
                    con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rgdIssuedList.DataSource = dt;
                rgdIssuedList.DataBind();

            }
            else
                rgdIssuedList.Visible = false;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       public void getdremainingIDT()
        {

            using (SqlCommand cmd = new SqlCommand("usp_getRemainingIDT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@productId", prdid);
                cmd.Parameters.AddWithValue("@depuID", DepuID);
                cmd.Parameters.AddWithValue("@quaterID", quarterId);
                cmd.Parameters.AddWithValue("@TypeId", typeID);       

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                       // lblRemainingIDTQTY.Text = dr["RemaingIDT"].ToString();

                        remIDT =double.Parse(dr["RemaingIDT"].ToString());
                        if (AU != "NOS")
                            lblRemainingIDTQTY.Text = remIDT.ToString("0.000");
                        else
                            lblRemainingIDTQTY.Text = remIDT.ToString("0.000");
                    }
                }
                con.Close();
            }


        }

        private void _CheckCase(int SID)
        {
            try
            {
                StockComp cmp = new StockComp();
                DataTable dt = new DataTable();
                dt = cmp.Select(SID);
                if (dt.Rows.Count > 0)
                {
                    
                    if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                    {
                        stockCase = "1"; Case = 1;
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == true)
                    {
                        stockCase = "2"; Case = 2;
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                    {
                        stockCase = "3"; Case = 3;
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                    {
                        stockCase = "4"; Case = 4;
                    }
                    else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                    {
                        stockCase = "5"; Case = 5;

                    }
                   
                        
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        public void getdproductDetail(int ProductID)
        {

            using (SqlCommand cmd = new SqlCommand("usp_getStockQuantity", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlParameter custId = cmd.Parameters.AddWithValue("@prdID", ProductID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                       /// SID=int.Parse(dr["SID"].ToString());
                        lblprdName.Text = dr["Product_Name"].ToString();
                       AU= lblunit.Text = dr["productUnit"].ToString();
                        if (AU != "NOS")
                            lblstockbalnace.Text = Convert.ToDouble(dr["StockQty"].ToString()).ToString("0.000");
                            else
                            lblstockbalnace.Text = Convert.ToDouble(dr["StockQty"].ToString()).ToString("0.00");
                       // lblstockbalnace.Text = dr["StockQty"].ToString();
                        if (dr["TotalWeight"].ToString()!="")
                        lblWeight.Text =Convert.ToDouble(dr["TotalWeight"].ToString()).ToString("0.000");
                        if (dr["TotalCost"].ToString() != "")
                        lblAmount.Text =Convert.ToDouble(dr["TotalCost"].ToString()).ToString("0.000");
                        if (dr["WOP"].ToString() != "")
                            WOP = Convert.ToDouble(dr["WOP"].ToString());
                    }
                }
                con.Close();
            }


        }

        public void getDepuName(int DepuID)
        {

            using (SqlCommand cmd = new SqlCommand("usp_getDepuName", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlParameter custId = cmd.Parameters.AddWithValue("@depuid", DepuID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        lbldepoName.Text = dr["Depu_Name"].ToString();


                    }
                }
                con.Close();
            }


        }

        private void binddropdown(int prdid)
        {
           
            SqlCommand cmd = new SqlCommand("usp_getBatch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@prdid", prdid);
            if(Case>3)
                cmd.Parameters.AddWithValue("@Action", "WithoutPacking");
                else
                cmd.Parameters.AddWithValue("@Action", "WithPacking");  
            
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int bcount = dt.Rows.Count;
                if (sdt.Rows.Count > 0)
                {
                    for (int b = 0; b < bcount; b++)
                    {
                        for (int s = 0; s < sdt.Rows.Count; s++)
                        {

                            if (int.Parse(sdt.Rows[s]["BID"].ToString()) == int.Parse(dt.Rows[b]["BID"].ToString()))
                            {
                                dt.Rows.RemoveAt(b);
                                b++;
                            }
                        }
                    }
                }

                ddlBatch.DataTextField = "batchcodeWithQty";
                ddlBatch.DataValueField = "BID";
                ddlBatch.DataSource = dt;
                ddlBatch.DataBind();
                ddlBatch.Items.Insert(0, new ListItem("--Select Batch--", "0"));
               
            }
            else
            {

            }
            con.Close();
        }      

        [WebMethod]
        public static BatchDetail[] BindBatchproductDetail(string BatchNo)
        {
            DataTable dt = new DataTable();
            List<BatchDetail> details = new List<BatchDetail>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {

                using (SqlCommand cmd = new SqlCommand("usp_grdbachwithproductqty", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@BatchCode", BatchNo);
                    cmd.Parameters.Add(param[0]);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        BatchDetail batch = new BatchDetail();
                        batch.BID =int.Parse(dtrow["BID"].ToString());
                        batch.BatchName = dtrow["BatchNo"].ToString();
                        batch.batchTotalQuantity = Convert.ToDouble(dtrow["sQuantity"]);
                        batch.FullPack = dtrow["FullPack"].ToString();
                        batch.LoosePack = dtrow["LoosePack"].ToString();
                        batch.Esl = dtrow["Esl"].ToString();
                        batch.FullPackQty = Convert.ToDouble(dtrow["FullPackQty"].ToString());
                        batch.LoosePackQty = Convert.ToDouble(dtrow["LoosePackQty"].ToString());
                        details.Add(batch);
                       
                    }
                    
                }
            }
          
            return details.ToArray();
        }

        public class BatchDetail
        {
            public int SID { get; set; }
            public int BID { get; set; }
            public string BatchName { get; set; }
            public string Esl { get; set; }
            public double batchTotalQuantity { get; set; }
            public string FullPack { get; set; }
            public string LoosePack { get; set; }
            public double FullPackQty { get; set; }
            public double LoosePackQty { get; set; }             

        }
  
        protected void btnback_Click(object sender, EventArgs e)
        {
             sdt = new DataTable();
        btnSubmitVisible = false;

        countNext = 0;
          countPrev = 0;
         prdid=0;
       
         sdt = new DataTable();
        btnSubmitVisible = false;
          countNext = 0;
         countPrev = 0;
         AU = "";
         Case = 0;
        stockCase = "";
          WOP = 0;
     
        formatQty = 1;
          remIDT =0;
    
            Response.Redirect("frmMonitoringStock.aspx");
        }

        protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlBatch.SelectedValue != "0")
                {
                    if (sdt.Rows.Count > 0)
                    {
                        foreach (GridDataItem item in rgdQty.MasterTableView.Items)
                        {
                            int BID = int.Parse(item.GetDataKeyValue("BID").ToString());
                            RadNumericTextBox txtFullQty = (RadNumericTextBox)item.FindControl("txtFullQty");
                            RadNumericTextBox txtLooseQty = (RadNumericTextBox)item.FindControl("txtLooseQty");
                            Label lblLooseQty = (Label)item.FindControl("lblLooseQty");
                            Label lblLooseRemQty = (Label)item.FindControl("lblLooseRemQty");
                            Label lblFullQty = (Label)item.FindControl("lblFullQty");
                            Label lblFullRemQty = (Label)item.FindControl("lblFullRemQty");
                            TextBox txtIssueQty = (TextBox)item.FindControl("txtIssueQty");
                            Label lblRemarks = (Label)item.FindControl("lblRemarks");
                            ImageButton btnPrev = (ImageButton)item.FindControl("btnPrev");
                            ImageButton btnNext = (ImageButton)item.FindControl("btnNext");

                            foreach (DataRow dr in sdt.Rows)
                            {
                                if (int.Parse(dr["BID"].ToString()) == BID)
                                {
                                    if (Case != 2)
                                    {
                                        if (txtFullQty.Text != "")
                                            dr["txtFullQtyVal"] = Convert.ToDouble(txtFullQty.Text);
                                        dr["lblFullQtyText"] = lblFullQty.Text;
                                        dr["lblFullRemQtyText"] = lblFullRemQty.Text;
                                    }
                                    if (txtLooseQty.Text != "")
                                        dr["txtLooseQtyVal"] = Convert.ToDouble(txtLooseQty.Text);
                                    dr["lblLooseQtyText"] = lblLooseQty.Text;
                                    dr["lblLooseRemQtyText"] = lblLooseRemQty.Text;
                                    if (txtIssueQty.Text != "")
                                        dr["txtIssueQtyText"] = txtIssueQty.Text;
                                    else
                                        dr["txtIssueQtyText"] = "0";
                                    dr["Remarks"] = lblRemarks.Text;
                                    dr["CountNext"] = btnNext.CommandArgument;
                                    dr["CountPrev"] = btnPrev.CommandArgument;
                                }
                            }
                        }
                    }
                    int col = sdt.Columns.Count;
                    int batchNo = int.Parse(ddlBatch.SelectedItem.Value);
                    rhpdEntities db1 = new rhpdEntities();
                    var batch1 = db1.BatchMasters.Where(b => b.BID == batchNo).FirstOrDefault();
                    if (batch1 != null)
                    {
                        int SID = Convert.ToInt32(batch1.StockId);
                        _CheckCase(SID);
                    }
                    StockBatchComp scomp = new StockBatchComp();
                    DataTable dt = new DataTable();

                    switch (stockCase)
                    {
                        case "1": //Product with packging 
                            dt = scomp.SelectByBatchNo(batchNo);
                            //foreach (DataRow dtrow in dt.Rows)
                            if (dt.Rows.Count > 0)
                            {
                                DataRow dtrow = dt.Rows[0];
                                BatchDetail batch = new BatchDetail();

                                string[] res = dtrow["FullPack"].ToString().Split('X');
                                if (res.Count() == 2)
                                {
                                    var packets = Convert.ToDouble(dtrow["FullPackQty"].ToString()) / Convert.ToDouble(res[1].ToString());
                                    batch.FullPack = string.Format("{0}X{1}",int.Parse(packets.ToString()),res[1]);
                                }                                
                                batch.BID = int.Parse(dtrow["BID"].ToString());
                                batch.BatchName = dtrow["BatchNo"].ToString();
                                batch.batchTotalQuantity = Convert.ToDouble(dtrow["sQuantity"].ToString());
                                //batch.FullPack = dtrow["FullPack"].ToString();
                                batch.LoosePack = dtrow["LoosePack"].ToString();

                                batch.Esl = dtrow["Esl"].ToString();
                                batch.SID = int.Parse(dtrow["SID"].ToString());
                                if (dtrow["FullPackQty"].ToString() != "")
                                    batch.FullPackQty = Convert.ToDouble(dtrow["FullPackQty"].ToString());
                                else
                                    batch.FullPackQty = 0;
                                if (dtrow["LoosePackQty"].ToString() != "")
                                    batch.LoosePackQty = Convert.ToDouble(dtrow["LoosePackQty"].ToString());
                                else
                                    batch.LoosePackQty = 0;
                                //  sdt.Columns.Add("BID", "BatchName",        "batchTotalQuantity",  "FullPack",       "LoosePack",    "Esl",    "SID",       "FullPackQty", "LoosePackQty", "txtFullQtyVal","txtLooseQtyVal","lblLooseQtyText","lblLooseRemQtyText","lblFullQtyText", "lblFullRemQtyText", "txtIssueQtyText","WeightofParticular",                                "CostOfParticular", "Remarks");
                                sdt.Rows.Add(batch.BID, batch.BatchName, batch.batchTotalQuantity, "With Packaging", batch.FullPack, batch.LoosePack, batch.Esl, batch.SID, batch.FullPackQty, batch.LoosePackQty, 0, 0, "", "", "", "", "0", Convert.ToDouble(dtrow["WeightofParticular"].ToString()), Convert.ToDouble(dtrow["CostOfParticular"].ToString()), dtrow["Remarks"].ToString(), 0, 0);
                            }
                            break;
                        case "2": //Product With Packaging with DW
                            dt = scomp.SelectByBatchNo(batchNo);
                            foreach (DataRow dtrow in dt.Rows)
                            {
                                BatchDetail batch = new BatchDetail();
                                batch.BID = int.Parse(dtrow["BID"].ToString());
                                batch.BatchName = dtrow["BatchNo"].ToString();
                                batch.batchTotalQuantity = Convert.ToDouble(dtrow["sQuantity"].ToString());
                                batch.FullPack = "";
                                batch.LoosePack = dtrow["DWPack"].ToString();
                                batch.Esl = dtrow["Esl"].ToString();
                                batch.SID = int.Parse(dtrow["SID"].ToString());
                                batch.FullPackQty = 0;
                                if (dtrow["DWPackQty"].ToString() != "")
                                    batch.LoosePackQty = Convert.ToDouble(dtrow["DWPackQty"].ToString());
                                else
                                    batch.LoosePackQty = 0;
                                sdt.Rows.Add(batch.BID, batch.BatchName, batch.batchTotalQuantity, "DW", batch.FullPack, batch.LoosePack, batch.Esl, batch.SID, batch.FullPackQty, batch.LoosePackQty, 0, 0, "", "", "", "", "0", Convert.ToDouble(dtrow["WeightofParticular"].ToString()), Convert.ToDouble(dtrow["CostOfParticular"].ToString()), dtrow["Remarks"].ToString(), 0, 0);

                            }
                            break;
                        case "3": //with packaging  with Sub packaging
                            dt = scomp.SelectByBatchNo(batchNo);
                            //foreach (DataRow dtrow in dt.Rows)
                            if (dt.Rows.Count > 0)
                            {
                                DataRow dtrow = dt.Rows[0];
                                BatchDetail batch = new BatchDetail();
                                string[] res = dtrow["FullPack"].ToString().Split('X');
                                if (res.Count() == 3)
                                {
                                    var temp1 = Convert.ToDouble(res[1].ToString()) * Convert.ToDouble(res[2].ToString());
                                    var mainPackets = Convert.ToDouble(dtrow["FullPackQty"].ToString()) / temp1;
                                    batch.FullPack = string.Format("{0}X{1}X{2}", int.Parse(mainPackets.ToString()), res[1], res[2]);
                                }
                                batch.BID = int.Parse(dtrow["BID"].ToString());
                                batch.BatchName = dtrow["BatchNo"].ToString();
                                batch.batchTotalQuantity = Convert.ToDouble(dtrow["sQuantity"].ToString());
                                //batch.FullPack = dtrow["FullPack"].ToString();
                                batch.LoosePack = dtrow["LoosePack"].ToString();
                                batch.Esl = dtrow["Esl"].ToString();
                                batch.SID = int.Parse(dtrow["SID"].ToString());
                                if (dtrow["FullPackQty"].ToString() != "")
                                    batch.FullPackQty = Convert.ToDouble(dtrow["FullPackQty"].ToString());
                                else
                                    batch.FullPackQty = 0;
                                if (dtrow["LoosePackQty"].ToString() != "")
                                    batch.LoosePackQty = Convert.ToDouble(dtrow["LoosePackQty"].ToString());
                                else
                                    batch.LoosePackQty = 0;
                                sdt.Rows.Add(batch.BID, batch.BatchName, batch.batchTotalQuantity, "Sub Packaging", batch.FullPack, batch.LoosePack, batch.Esl, batch.SID, batch.FullPackQty, batch.LoosePackQty, 0, 0, "", "", "", "", "0", Convert.ToDouble(dtrow["WeightofParticular"].ToString()), Convert.ToDouble(dtrow["CostOfParticular"].ToString()), dtrow["Remarks"].ToString(), 0, 0);
                            }
                            break;
                        case "4": // Packaging without product
                            rhpdEntities db = new rhpdEntities();
                            var batchL = db.BatchMasters.Where(b => b.BID == batchNo).FirstOrDefault();
                            if (batchL != null)
                            {
                                var vehicle = db.StockVehicles.Where(v => v.StockBatchId == batchL.BID && v.StockID == batchL.StockId).ToList();
                                if (vehicle != null)
                                {
                                    BatchDetail batch = new BatchDetail();
                                    batch.BID = batchL.BID;
                                    batch.BatchName = batchL.BatchNo;
                                    batch.batchTotalQuantity = Convert.ToDouble(vehicle.Sum(x => x.RecievedQty));
                                    batch.FullPack = "";
                                    batch.LoosePack = "";
                                    if (batchL.Esl.ToString() != "")
                                        batch.Esl = Convert.ToDateTime(batchL.Esl).ToString("MMM-yyyy");
                                    batch.SID = Convert.ToInt32(batchL.StockId);
                                    batch.FullPackQty = 0;
                                    batch.LoosePackQty = Convert.ToDouble(vehicle.Sum(x => x.RecievedQty));
                                    sdt.Rows.Add(batch.BID, batch.BatchName, batch.batchTotalQuantity, "Without Product", batch.FullPack, batch.LoosePack, batch.Esl, batch.SID, batch.FullPackQty, batch.LoosePackQty, 0, 0, "", "", "", "", "0", Convert.ToDouble(batchL.WeightofParticular), Convert.ToDouble(batchL.CostOfParticular), batchL.Remarks, 0, 0);
                                }
                            }

                            break;
                        case "5": //Product without PACKAGING
                            db = new rhpdEntities();
                            batchL = db.BatchMasters.Where(b => b.BID == batchNo).FirstOrDefault();
                            if (batchL != null)
                            {
                                var vehicle = db.StockVehicles.Where(v => v.StockBatchId == batchL.BID && v.StockID == batchL.StockId).ToList();
                                if (vehicle != null)
                                {
                                    BatchDetail batch = new BatchDetail();
                                    batch.BID = batchL.BID;
                                    batch.BatchName = batchL.BatchNo;
                                    batch.batchTotalQuantity = Convert.ToDouble(vehicle.Sum(x => x.RecievedQty));
                                    batch.FullPack = "";
                                    batch.LoosePack = "";
                                    if (batchL.Esl.ToString() != "")
                                        batch.Esl = Convert.ToDateTime(batchL.Esl).ToString("MMM-yyyy");
                                    batch.SID = Convert.ToInt32(batchL.StockId);
                                    batch.FullPackQty = 0;
                                    batch.LoosePackQty = Convert.ToDouble(vehicle.Sum(x => x.RecievedQty));
                                    sdt.Rows.Add(batch.BID, batch.BatchName, batch.batchTotalQuantity, "Wihtout Packaging", batch.FullPack, batch.LoosePack, batch.Esl, batch.SID, batch.FullPackQty, batch.LoosePackQty, 0, 0, "", "", "", "", "0", Convert.ToDouble(batchL.WeightofParticular), Convert.ToDouble(batchL.CostOfParticular), batchL.Remarks, 0, 0);
                                }
                            }
                            break;
                    }

                    rgdQty.DataSource = sdt;
                    rgdQty.DataBind();
                    foreach (GridColumn myColumn in rgdQty.MasterTableView.RenderColumns)
                    {
                        if (Case == 2 || Case == 4 || Case == 5)
                        {
                            if (myColumn.UniqueName == "FullPack")
                                myColumn.Visible = false;

                            if (myColumn.UniqueName == "IssuQtyFromFull")
                                myColumn.Visible = false;

                            if (myColumn.UniqueName == "ShufflePAcks")
                                myColumn.Visible = false;

                        }
                    }

                    lblremainingIDT.Text = txtIssuequantity.Text;
                    ddlBatch.Items.RemoveAt(ddlBatch.SelectedIndex);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int insertdata(string BatchName, double issueqty,int BID)
        {
            DepuID = Convert.ToInt32(Request.QueryString["Did"].ToString());
            prdid = Convert.ToInt32(Request.QueryString["prdId"].ToString());
            quarterId = Convert.ToInt32(Request.QueryString["qid"].ToString());
            
           
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_InsertBatchIDT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@prdname", HttpContext.Current.Session["prdname"]);
                    cmd.Parameters.AddWithValue("@BatchName", BatchName.Trim());
                    cmd.Parameters.AddWithValue("@BID", BID);
                    cmd.Parameters.AddWithValue("@issueqty", issueqty);
                    cmd.Parameters.AddWithValue("@depuID", DepuID);
                    cmd.Parameters.AddWithValue("@productID", prdid);
                    cmd.Parameters.AddWithValue("@QuaterID", quarterId);
                    cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);                    
                    cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
                    cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);
                    con.Close();
                    if (intResult > 0)
                    {
                        return intResult;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

        }
        
        public void insertTranfer(int SID, int BID, int IDTId, string PackingType, string Format, double Qty , int ToLooseCount,string FormatLeft, double QtyLeft)
        {
           
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();
                if (Qty == 0)
                    Format = "";
                using (SqlCommand cmd = new SqlCommand("spIDTStockTranfer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SID", SID);
                    cmd.Parameters.AddWithValue("@BatchId", BID);
                    cmd.Parameters.AddWithValue("@IDTId", IDTId);
                    cmd.Parameters.AddWithValue("@PackingType", PackingType);
                    cmd.Parameters.AddWithValue("@Quantity", Qty);
                    cmd.Parameters.AddWithValue("@Format", Format);
                    //cmd.Parameters.AddWithValue("@QuantityLeft", QtyLeft);
                    //cmd.Parameters.AddWithValue("@FormatLeft", FormatLeft);
                    cmd.Parameters.AddWithValue("@ToLooseCount", ToLooseCount);
                    cmd.ExecuteNonQuery();
                       
                }
            }

        }
        
       protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int LooseCount = 0;
                double issueQty = double.Parse(txtIssuequantity.Text);
                double totalIssueQty = 0;
            
                foreach (GridDataItem dataItem in rgdQty.MasterTableView.Items)
                {
                    ImageButton btnPrev = (ImageButton)dataItem.FindControl("btnPrev");
                    ImageButton btnNext = (ImageButton)dataItem.FindControl("btnNext");
                    LooseCount =int.Parse(btnNext.CommandArgument.ToString());
                    Label lblFullPack = (Label)dataItem.FindControl("lblFullPack");
                    Label lblLoosePackQty = (Label)dataItem.FindControl("lblLoosePackQty");
                    Label lblLoosePack = (Label)dataItem.FindControl("lblLoosePack");
                    Label lblBID = (Label)dataItem.FindControl("lblBID");
                    Label lblSID = (Label)dataItem.FindControl("lblSID");
                    Label lblBatchName = (Label)dataItem.FindControl("lblBatchName");
                    RadNumericTextBox txtFullQty = (RadNumericTextBox)dataItem.FindControl("txtFullQty");
                    RadNumericTextBox txtLooseQty = (RadNumericTextBox)dataItem.FindControl("txtLooseQty");
                    TextBox txtIssueQty = (TextBox)dataItem.FindControl("txtIssueQty");
                    int IDTID = 0;
                    string[] Full = lblFullPack.Text.Split('X');
                    double fullPackQty = 1;
                    for (int f = 0; f < Full.Count(); f++)
                    {
                        if (Full[f] != "")
                            fullPackQty = fullPackQty * double.Parse(Full[f]);
                    }
                    if (fullPackQty < double.Parse(txtFullQty.Text))
                    {
                        
                    }
                    string[] Loose;
                    if (Case == 2 || Case == 4 || Case == 5)
                    {

                        Loose = lblLoosePackQty.Text.Split(' ');
                        if (Loose.Count() > 2)
                        {
                            if (double.Parse(Loose[Loose.Count() - 2]) < double.Parse(txtLooseQty.Text))
                            {
                                
                            }
                        }
                    }


                    else
                    {

                        Loose = lblLoosePack.Text.Split('|');
                        if (Loose.Count() > 1)
                        {
                            if (double.Parse(Loose[Loose.Count() - 1]) < double.Parse(txtLooseQty.Text))
                            {
                                
                            }
                        }
                    }
                    if (Case == 2 || Case==5||Case==4)
                    {
                       
                        txtIssueQty.Text = double.Parse(txtLooseQty.Text).ToString();
                        totalIssueQty =  double.Parse(txtLooseQty.Text);
                        IDTID = insertdata(lblBatchName.Text, double.Parse(txtLooseQty.Text), int.Parse(lblBID.Text));
                    }
                    else if (Case == 1 || Case == 3)
                    {
                        if (txtFullQty.Text != "" && txtLooseQty.Text != "")
                        {

                            txtIssueQty.Text = (double.Parse(txtFullQty.Text) + double.Parse(txtLooseQty.Text)).ToString();
                            totalIssueQty = (double.Parse(txtFullQty.Text) + double.Parse(txtLooseQty.Text));
                        }
                        IDTID = insertdata(lblBatchName.Text, (double.Parse(txtFullQty.Text) + double.Parse(txtLooseQty.Text)), int.Parse(lblBID.Text));
                    }

                    double fullQtyLeft = 0;
                    string fullFormatLeft = "";
                    if (Case == 1 || Case == 3)
                    {
                        if (txtFullQty.Text != "")
                        {
                           
                            double div = 1;
                            for (int i = 1; i < Full.Count(); i++)
                            {
                                if (Full[i].ToString() != "")
                                    div = div * double.Parse(Full[i]);
                            }
                            string[] f = (double.Parse(txtFullQty.Text) / div).ToString().Split('.');
                            
                            if (Full[0].ToString() != "")
                            {
                                fullFormatLeft = (double.Parse(Full[0].ToString()) - double.Parse(f[0].ToString())).ToString();
                            }
                            if (fullFormatLeft != "")
                                fullQtyLeft = double.Parse(fullFormatLeft);
                            for (int i = 1; i < Full.Count(); i++)
                            {
                                if (fullFormatLeft != "")
                                    fullFormatLeft = fullFormatLeft + "X" + Full[i].ToString();
                                if (Full[i].ToString() != "")
                                    fullQtyLeft = fullQtyLeft * double.Parse(Full[i].ToString());
                            }
                            
                        }
                    }
                     if (Case == 2)
                    {
                        fullFormatLeft = "DW";
                        if (Loose[1] != "")
                            fullQtyLeft = (double.Parse(Loose[1].ToString()) - double.Parse(txtLooseQty.Text));
                          
                    }
                    else if (Case == 4 || Case == 5)
                    {
                        fullFormatLeft = "";
                        if (Loose[1] != "")
                            fullQtyLeft = (double.Parse(Loose[1].ToString()) - double.Parse(txtLooseQty.Text));

                    }
                    else//Loose
                    {

                        fullFormatLeft = Loose[0].ToString();

                        for (int l = 1; l < Loose.Count() - 1; l++)
                        {

                            fullFormatLeft = fullFormatLeft + "|" + Loose[l].ToString();
                        }
                        if (fullFormatLeft != "")
                            fullFormatLeft = fullFormatLeft + "|" + txtLooseQty.Text;
                        if (Loose[Loose.Count() - 1].ToString() != "")
                        {

                            fullQtyLeft = double.Parse(Loose[Loose.Count() - 1].ToString()) - double.Parse(txtLooseQty.Text);
                        }
                    }
                    if (IDTID > 1)
                    {
                        if (Case == 5 || Case == 4)
                        {
                            insertTranfer(int.Parse(lblSID.Text), int.Parse(lblBID.Text), IDTID, "", "", double.Parse(txtLooseQty.Text), LooseCount,fullFormatLeft,fullQtyLeft);
                        }
                        else
                        {
                            StockPakagingComp pComp = new StockPakagingComp();
                            DataTable dt = new DataTable();
                            dt = pComp.SelectByBatchId(int.Parse(lblBID.Text));
                            foreach (DataRow dtrow in dt.Rows)
                            {
                                if (dtrow["PackagingType"].ToString() == "Full")
                                {
                                    Label lblFullQty = (Label)dataItem.FindControl("lblFullQty");
                                    insertTranfer(int.Parse(lblSID.Text), int.Parse(lblBID.Text), IDTID, "Full", lblFullQty.Text, double.Parse(txtFullQty.Text), LooseCount, fullFormatLeft, fullQtyLeft);
                                }
                               
                                //else if (txtLooseQty.Text != "0"||txtLooseQty.Text!="")
                                //{
                                //    Label lblLooseQty = (Label)dataItem.FindControl("lblLooseQty");

                                //    insertTranfer(int.Parse(lblSID.Text), int.Parse(lblBID.Text), IDTID, "Loose", lblLooseQty.Text, double.Parse(txtLooseQty.Text));
                            
                                //}
                                else if (dtrow["PackagingType"].ToString() == "DW")
                                {
                                    Label lblLooseQty = (Label)dataItem.FindControl("lblLooseQty");
                                    rhpdEntities db = new rhpdEntities();
                                    Int32 bID = int.Parse(lblBID.Text);
                                    var batch = db.BatchMasters.Where(b => b.BID == bID).FirstOrDefault();
                                    if (batch != null)
                                    {
                                        var packDW = db.StockPakagings.Where(x => x.StockBatchId == batch.BID).FirstOrDefault();
                                        if (packDW != null)
                                        {
                                            lblLooseQty.Text = packDW.Format.Split('X')[0] + "XDW";
                                        }
                                    }
                                    insertTranfer(int.Parse(lblSID.Text), int.Parse(lblBID.Text), IDTID, "DW", lblLooseQty.Text, double.Parse(txtLooseQty.Text), LooseCount, fullFormatLeft, fullQtyLeft);
                                }
                                else if (dtrow["PackagingType"].ToString() == "Loose" || txtLooseQty.Text != "0" && txtLooseQty.Text != "")
                                {
                                    Label lblLooseQty = (Label)dataItem.FindControl("lblLooseQty");

                                    insertTranfer(int.Parse(lblSID.Text), int.Parse(lblBID.Text), IDTID, "Loose", lblLooseQty.Text, double.Parse(txtLooseQty.Text), LooseCount, fullFormatLeft, fullQtyLeft);
                                }
                            }
                        }
                    }
                }
                btnSubmit.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity submitted successfully !')", true);
                sdt = new DataTable();
                btnSubmitVisible = false;
                countNext = 0;
                countPrev = 0;
                AU = "";
                Case = 0;
                stockCase = "";
                WOP = 0;
                formatQty = 1;
                remIDT = 0;
                Response.Redirect("../StockOutPanel/frmMonitoringStock.aspx",false);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        protected void rgdQty_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Calc")
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    RadNumericTextBox txtFullQty = (RadNumericTextBox)item.FindControl("txtFullQty");
                    RadNumericTextBox txtLooseQty = (RadNumericTextBox)item.FindControl("txtLooseQty");
                    if (txtFullQty.Text != "" && txtLooseQty.Text != "")
                    {                      
                        Label lblFullPack = (Label)item.FindControl("lblFullPack");
                        Label lblLoosePack = (Label)item.FindControl("lblLoosePack");
                        string[] Full = lblFullPack.Text.Split('X');
                        string[] Loose;
                        if(Case==2)
                        Loose= lblLoosePack.Text.Split('X');
                        else
                            Loose = lblLoosePack.Text.Split('|');
                        double div = 1;
                        for (int i = 1; i < Full.Count(); i++)
                        {
                            div=(div* double.Parse(Full[i].ToString()));
                          
                        }
                        if (double.Parse(txtFullQty.Text) % div != 0)
                        {
                            txtFullQty.Text = (double.Parse(txtFullQty.Text) -(double.Parse(txtFullQty.Text) % div)).ToString();
                        }
                       
                    }
                }
                if (e.CommandName=="Prev")
                {

                    GridDataItem item = (GridDataItem)e.Item;
                    //Packing
                    Label lblBID = (Label)item.FindControl("lblBID");
                    Label lblSID = (Label)item.FindControl("lblSID");
                    Label lblBatchName = (Label)item.FindControl("lblBatchName");
                    Label lblFullPack = (Label)item.FindControl("lblFullPack");
                    Label lblLoosePack = (Label)item.FindControl("lblLoosePack");
                    string[] Full = lblFullPack.Text.Split('X');
                    string[] Loose = lblLoosePack.Text.Split('|');
                        Label lblFullPackQty = (Label)item.FindControl("lblFullPackQty");
                    Label lblLoosePackQty = (Label)item.FindControl("lblLoosePackQty");

                    if (Full[0].ToString() != "")
                    lblFullPack.Text = (double.Parse(Full[0]) +1).ToString();
                    double lQty =0;
                    if(Full[0].ToString()!="")
                     lQty = double.Parse(Full[0]) + 1;
                    double remL = 1;
                    for (int i = 1; i < Full.Count(); i++)
                    {
                        lblFullPack.Text = lblFullPack.Text + "X" + Full[i].ToString();
                        lQty = lQty * double.Parse(Full[i].ToString());
                        remL = remL * double.Parse(Full[i].ToString());
                    }
                    lblFullPackQty.Text = " [Qty:" + lQty.ToString() + "]";
                    if (Loose[0].ToString()!="")
                    lblLoosePack.Text = (double.Parse(Loose[0].ToString()) - 1).ToString();
                    for (int l = 1; l < Loose.Count() - 1; l++)
                    {
                        if (l == 1)
                        {
                            if (lblLoosePack.Text != "" && Full[l].ToString()!="")
                                lblLoosePack.Text = lblLoosePack.Text + "|" + (double.Parse(Loose[l].ToString()) - double.Parse(Full[l].ToString())).ToString();
                        }
                        else
                        {
                            if (lblLoosePack.Text != "" && Full[l].ToString() != "" && Full[l - 1].ToString()!="")
                            lblLoosePack.Text = lblLoosePack.Text + "|" + (double.Parse(Loose[l].ToString()) - (double.Parse(Full[l].ToString()) * double.Parse(Full[l - 1].ToString()))).ToString();
                        }

                    }
                    if (lblLoosePack.Text!="")
                    lblLoosePack.Text = lblLoosePack.Text + "|" + (double.Parse(Loose[Loose.Count() - 1].ToString()) - remL).ToString();
                    if (Loose[Loose.Count() - 1].ToString()!="")
                    lblLoosePackQty.Text = "[Qty:" + (double.Parse(Loose[Loose.Count() - 1].ToString()) - remL).ToString() + "]";
                    if ((double.Parse(Loose[Loose.Count() - 1].ToString()) - remL) == 0)
                    {
                        RadNumericTextBox txtLooseQty = (RadNumericTextBox)item.FindControl("txtLooseQty");
                        txtLooseQty.Visible = false;
                    }
                    countNext = countNext -1;
                    countPrev = countPrev - 1;
                    ImageButton btnPrev = (ImageButton)item.FindControl("btnPrev");
                    ImageButton btnNext = (ImageButton)item.FindControl("btnNext");
                    btnNext.CommandArgument = countNext.ToString();
                    btnPrev.CommandArgument = countPrev.ToString();
                    if (countPrev == 0)
                        btnPrev.Enabled = false;
                    else
                        btnPrev.Enabled = true;
                    if ((double.Parse(Full[0]) - 1) < 1)
                        btnNext.Enabled = false;
                    else
                        btnNext.Enabled = true;
                }
                if (e.CommandName == "Next")
                {

                    GridDataItem item = (GridDataItem)e.Item;
                    ImageButton btnPrev = (ImageButton)item.FindControl("btnPrev");
                    ImageButton btnNext = (ImageButton)item.FindControl("btnNext");
                
                    //Packing
                    Label lblBID = (Label)item.FindControl("lblBID");
                    Label lblSID = (Label)item.FindControl("lblSID");
                    Label lblBatchName = (Label)item.FindControl("lblBatchName");
                    Label lblFullPack = (Label)item.FindControl("lblFullPack");
                    Label lblLoosePack = (Label)item.FindControl("lblLoosePack");
                    Label lblFullPackQty = (Label)item.FindControl("lblFullPackQty");
                    Label lblLoosePackQty = (Label)item.FindControl("lblLoosePackQty");              
                
                    string[] Full = lblFullPack.Text.Split('X');
                    string[] Loose = lblLoosePack.Text.Split('|');
                    RadNumericTextBox txtFullQty = (RadNumericTextBox)item.FindControl("txtFullQty");
                    if (txtFullQty.Text!="")
                    { 
                     if (double.Parse(Full[0]) == double.Parse(txtFullQty.Text))
                     {
                         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity from Full can not be greater that Total quantity of batch !')", true);
                         return;
                     }}
                    lblFullPack.Text = (double.Parse(Full[0]) - 1).ToString();
                    double lQty = 1;
                    double efmL = double.Parse(Full[0]) - 1;
                    for (int i = 1; i < Full.Count(); i++)
                    {
                        lblFullPack.Text = lblFullPack.Text+"X" + Full[i].ToString();
                        lQty = lQty * double.Parse(Full[i].ToString());
                        efmL = efmL * double.Parse(Full[i].ToString());
                    }
                    lblFullPackQty.Text = " [Qty:" + efmL.ToString() + "]";
                    if (Loose[0].ToString()!="")
                    lblLoosePack.Text=(double.Parse(Loose[0].ToString())+1).ToString();
                     for (int l = 1; l < Loose.Count() - 1; l++)
                     {
                         if (l == 1)
                         {
                             if (Loose[l].ToString() != "" && Full[l].ToString()!="")
                             lblLoosePack.Text = lblLoosePack.Text + "|" + (double.Parse(Loose[l].ToString()) + double.Parse(Full[l].ToString())).ToString();

                         }
                         else
                         {
                             if (Loose[l].ToString() != "" && Full[l].ToString() != "" && Full[l-1].ToString() != "")
                             lblLoosePack.Text = lblLoosePack.Text + "|" + (double.Parse(Loose[l].ToString()) + (double.Parse(Full[l].ToString()) * double.Parse(Full[l - 1].ToString()))).ToString();
                         }
                    }
                     if (lblLoosePack.Text != "")
                     
                         lblLoosePack.Text = lblLoosePack.Text + "|" + (double.Parse(Loose[Loose.Count() - 1].ToString()) + lQty).ToString();
                     if (Loose[Loose.Count() - 1].ToString() != "")
                     {
                         if ((double.Parse(Loose[Loose.Count() - 1].ToString()) + lQty) == 0)
                         {
                             RadNumericTextBox txtLooseQty = (RadNumericTextBox)item.FindControl("txtLooseQty");
                             txtLooseQty.Visible = false;
                         }
                         lblLoosePackQty.Text = "[Qty:" + (double.Parse(Loose[Loose.Count() - 1].ToString()) + lQty).ToString() + "]";
                     }
                     else
                     {
                         lblLoosePackQty.Text = "[Qty:" + (lQty).ToString() + "]";
                         if (lQty == 0)
                         {
                             RadNumericTextBox txtLooseQty = (RadNumericTextBox)item.FindControl("txtLooseQty");
                             txtLooseQty.Visible = false;
                         }
             
                     }
                    
                   
                    //Button enable/disable
                    countNext = countNext + 1;
                    countPrev = countPrev + 1;
                    btnNext.CommandArgument = countNext.ToString();
                    btnPrev.CommandArgument = countPrev.ToString();
                    if (countPrev == 0)
                        btnPrev.Enabled = false;
                    else
                        btnPrev.Enabled = true;
                    if ((double.Parse(Full[0]) - 1) < 1)
                        btnNext.Enabled = false;
                    else
                        btnNext.Enabled = true;
                }
                _BindData(double.Parse(txtIssuequantity.Text));
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void txtFullQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadNumericTextBox box = (RadNumericTextBox)sender;
                int BID = int.Parse(box.ToolTip);
                 foreach (GridDataItem dataItem in rgdQty.MasterTableView.Items)
                {
                    if (dataItem.GetDataKeyValue("BID").ToString() == box.ToolTip)
                    {
                        Label lblFullPack = (Label)dataItem.FindControl("lblFullPack");
                        //Label lblFullPack = (Label)dataItem.FindControl("lblFullPackQty");
                        string[] Full = lblFullPack.Text.Split('X');                       
                        double div = 1;
                        for (int i = 1; i < Full.Count(); i++)
                        {
                            div = (div * double.Parse(Full[i].ToString()));

                        }
                         double fullPackQty = 1;
                        for (int f = 0; f < Full.Count(); f++)
                        {
                            fullPackQty = fullPackQty * (Full[f] != "" ?double.Parse(Full[f]):0);
                        }                       
                      
                        if (fullPackQty < double.Parse(box.Text))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity of " + box.Text + " from Full can not be greater that Total quantity of Full !')", true);
                            box.Focus();
                            return;
                        }
                        if (double.Parse(box.Text) % div != 0)
                        {
                            box.Text = (double.Parse(box.Text) - (double.Parse(box.Text) % div)).ToString();
                            box.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity " + box.Text + " is not suitable for Packaging Format!')", true);
                          
                         
                            return;
                        }

                         
                    }
                        
                }
                 _BindData(double.Parse(txtIssuequantity.Text));
                
              
            }
            catch (Exception)
            {
                
                throw;
            }
              
        }

        public void _BindData(double Qty)
        {
            try
            {
                double issueQty = Qty;
                double totalIssueQty = 0;
                double totalAmount = 0;
                double totalWeight = 0;
                foreach (GridDataItem dataItem in rgdQty.MasterTableView.Items)
                {
                    RadNumericTextBox txtFullQty = (RadNumericTextBox)dataItem.FindControl("txtFullQty");
                    RadNumericTextBox txtLooseQty = (RadNumericTextBox)dataItem.FindControl("txtLooseQty");
                    Label lblCost = (Label)dataItem.FindControl("lblCost");
                    Label lblWeight = (Label)dataItem.FindControl("lblWeight");
                    Label lblQtyWeight = (Label)dataItem.FindControl("lblQtyWeight");
                    Label lblQtyCost = (Label)dataItem.FindControl("lblQtyCost");
              
                    
                    if (txtLooseQty.Text != "")
                    {
                        
                        TextBox txtIssueQty = (TextBox)dataItem.FindControl("txtIssueQty");
                        if (txtLooseQty.Text != "")
                        {
                            txtIssueQty.Text = (double.Parse(txtFullQty.Text) + double.Parse(txtLooseQty.Text)).ToString();
                            totalIssueQty = totalIssueQty + (double.Parse(txtFullQty.Text) + double.Parse(txtLooseQty.Text));
                        }
                        else
                        {
                            txtIssueQty.Text = (double.Parse(txtFullQty.Text)).ToString();
                            totalIssueQty = totalIssueQty + double.Parse(txtFullQty.Text);
                        }
                         
                            lblQtyWeight.Text = (double.Parse(txtIssueQty.Text) * double.Parse(lblWeight.Text)).ToString("0.000");
                            lblQtyCost.Text = (double.Parse(txtIssueQty.Text) * double.Parse(lblCost.Text)).ToString("0.000");
                        
                        Label lblFullQty = (Label)dataItem.FindControl("lblFullQty");
                        Label lblLooseQty = (Label)dataItem.FindControl("lblLooseQty");
                        Label lblFullRemQty = (Label)dataItem.FindControl("lblFullRemQty");
                        Label lblLooseRemQty = (Label)dataItem.FindControl("lblLooseRemQty");
                        Label lblFullPack = (Label)dataItem.FindControl("lblFullPack");
                        Label lblLoosePack = (Label)dataItem.FindControl("lblLoosePack");
                        Label lblLoosePackQty = (Label)dataItem.FindControl("lblLoosePackQty");

                        string[] Full = lblFullPack.Text.Split('X');
                        double fullPackQty = 1;
                        for (int f = 0; f < Full.Count(); f++)
                        {
                            if (Full[f]!="")
                            fullPackQty = fullPackQty * double.Parse(Full[f]);
                        }
                        if(fullPackQty < double.Parse(txtFullQty.Text))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity from Full can not be greater that Total quantity of Full !')", true);
                            txtFullQty.Focus();
                            return;
                        }
                        string[] Loose;
                        if (Case == 2 || Case == 4 || Case == 5)
                        {
                            
                                Loose = lblLoosePackQty.Text.Split(' ');
                                if (Loose.Count() > 2)
                                {
                                    if (double.Parse(Loose[Loose.Count() - 2]) < double.Parse(txtLooseQty.Text))
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity from Loose can not be greater that Total quantity of Loose !')", true);
                                        txtLooseQty.Focus();
                                        return;
                                    }
                                }
                        }

                            
                        else
                        {
                           
                            Loose = lblLoosePack.Text.Split('|');
                            if (Loose.Count() > 1)
                            {
                                if (double.Parse(Loose[Loose.Count() - 1]) < double.Parse(txtLooseQty.Text))
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity from Loose can not be greater that Total quantity of Loose !')", true);
                                    txtLooseQty.Focus();
                                    return;
                                }
                            }
                        }
                       
                        if (Case ==1 || Case ==3)
                        {
                            if (txtFullQty.Text != "")
                            {
                                double div = 1;
                                for (int i = 1; i < Full.Count(); i++)
                                {
                                    if (Full[i].ToString()!="")
                                    div = div *double.Parse(Full[i]);
                                }
                                string[] f = (double.Parse(txtFullQty.Text) / div).ToString().Split('.');
                                lblFullQty.Text = f[0];
                                if (Full[0].ToString() != "")
                                {

                                    lblFullRemQty.Text = (double.Parse(Full[0].ToString()) - double.Parse(f[0].ToString())).ToString();
                                }
                                double fullQty = 0;
                                if (lblFullRemQty.Text != "")
                                    fullQty = double.Parse(lblFullRemQty.Text);
                                for (int i = 1; i < Full.Count(); i++)
                                {
                                    if (lblFullQty.Text!="")
                                    lblFullQty.Text = lblFullQty.Text + "X" + Full[i].ToString();
                                    if (lblFullRemQty.Text!="")
                                    lblFullRemQty.Text = lblFullRemQty.Text + "X" + Full[i].ToString();
                                    if (Full[i].ToString() != "")
                                    fullQty = fullQty * double.Parse(Full[i].ToString());
                                }
                                lblFullQty.Text = lblFullQty.Text;
                                lblFullRemQty.Text = "Remaining: " + lblFullRemQty.Text + " [Qty:" + fullQty.ToString() + "]";
                            }
                        }
                         if (Case == 2)
                        {
                            lblLooseQty.Text = "DW";
                             if(Loose[1]!="")
                            lblLooseRemQty.Text = "Remaining Qty: " +  (double.Parse(Loose[1].ToString()) - double.Parse(txtLooseQty.Text)).ToString();
                           
                        }
                         else if (Case == 4 || Case == 5)
                         {
                             lblLooseQty.Text = "";
                             if(Loose[1]!="")
                             lblLooseRemQty.Text = "Remaining Qty: " + (double.Parse(Loose[1].ToString()) - double.Parse(txtLooseQty.Text)).ToString();
                   
                         }
                        else
                        {
                            lblLooseQty.Text = Loose[0].ToString();
                            lblLooseRemQty.Text = Loose[0].ToString();
                     
                            for (int l = 1; l < Loose.Count() - 1; l++)
                            {
                                lblLooseQty.Text = lblLooseQty.Text + "|" + Loose[l].ToString();
                                lblLooseRemQty.Text = lblLooseRemQty.Text + "|" + Loose[l].ToString();
                            }
                             if(lblLooseQty.Text!="")
                            lblLooseQty.Text = lblLooseQty.Text + "|" + txtLooseQty.Text;
                             if (Loose[Loose.Count() - 1].ToString() != "")
                             {
                                 if (double.Parse(Loose[Loose.Count() - 1].ToString()) - double.Parse(txtLooseQty.Text)<=0)
                                     lblLooseRemQty.Text = "Remaining Qty:" + (double.Parse(Loose[Loose.Count() - 1].ToString()) - double.Parse(txtLooseQty.Text)).ToString();
                       
                                     else
                                 lblLooseRemQty.Text = "Remaining: " + lblLooseRemQty.Text + "|" + (double.Parse(Loose[Loose.Count() - 1].ToString()) - double.Parse(txtLooseQty.Text)).ToString() + "[Qty:" + (double.Parse(Loose[Loose.Count() - 1].ToString()) - double.Parse(txtLooseQty.Text)).ToString() + "]";
                             }
                        }
                    }
                    //Totals
                    totalWeight = totalWeight + totalIssueQty * Convert.ToDouble(lblWeight.Text);
                    totalAmount = totalAmount + totalIssueQty * Convert.ToDouble(lblCost.Text);

                }
                if (totalIssueQty == issueQty)
                {
                    btnSubmitVisible = btnSubmit.Visible = true;
                }
                else
                    btnSubmitVisible = btnSubmit.Visible = false;
                txtRemarks.Visible = btnSubmitVisible;
                if (totalIssueQty > issueQty)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity should not be greater that Total quantity of batch !')", true);
                    return;
                }
                lblremainingIDT.Text = (issueQty - totalIssueQty).ToString();

                if (sdt.Rows.Count > 0)
                {
                    tblTotal.Visible = true; ;
                    lblTotalAmt.Text = totalAmount.ToString("0.00");
                    if (AU != "NOS")
                    lblTotalQty.Text = totalIssueQty.ToString("0.000");
                    else
                    lblTotalQty.Text = totalIssueQty.ToString("0.00");
                    lblTotalWeight.Text = totalWeight.ToString("0.000");
                }
      
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void txtLooseQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadNumericTextBox box = (RadNumericTextBox)sender;
                int BID = int.Parse(box.ToolTip);
                 foreach (GridDataItem dataItem in rgdQty.MasterTableView.Items)
                {
                    if (dataItem.GetDataKeyValue("BID").ToString() == box.ToolTip)
                    {
                        Label lblLoosePack = (Label)dataItem.FindControl("lblLoosePack");
                        Label lblLoosePackQty = (Label)dataItem.FindControl("lblLoosePackQty");
                        string[] Loose;
                        
                             if( Case == 2 || Case == 5|| Case == 4)
                            {

                                Loose = lblLoosePackQty.Text.Split(' ');
                                if (double.Parse(Loose[Loose.Count() - 2]) < double.Parse(box.Text))
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity from Loose can not be greater that Total quantity of Loose !')", true);
                                    box.Focus();
                                    return;
                                }
                                if (Loose[Loose.Count() - 2].ToString() != "")
                                {
                                    if (double.Parse(Loose[Loose.Count() - 2]) < double.Parse(box.Text))
                                    {
                                        box.Focus();
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity from Loose can not be greater than Total Loose Qty !')", true);
                                        return;
                                    }

                                }


                            }
                            else
                            {

                                Loose = lblLoosePack.Text.Split('|');
                                if (Loose[Loose.Count() - 1] != "")
                                {
                                    if (double.Parse(Loose[Loose.Count() - 1]) < double.Parse(box.Text))
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity from Loose can not be greater that Total quantity of Loose !')", true);
                                        box.Focus();
                                        return;
                                    }
                                    if (Loose[Loose.Count() - 1].ToString() != "")
                                    {
                                        if (double.Parse(Loose[Loose.Count() - 1]) < double.Parse(box.Text))
                                        {
                                            box.Focus();
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue quantity from Loose can not be greater than Total Loose Qty !')", true);
                                            return;
                                        }

                                    }
                                }

                            }
                           
                         
                    }
                        
                }
                _BindData(double.Parse(txtIssuequantity.Text));
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void txtIssuequantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtIssuequantity.Text != "" && int.Parse(txtIssuequantity.Text) != 0)
                {
                    if ((Convert.ToDouble(lblRemainingIDTQTY.Text) < Convert.ToDouble(txtIssuequantity.Text)))
                    {
                        lblApproxWeight.Text = "Issue Qty is greater than remaining qty!";
                        txtIssuequantity.Focus();
                        return;
                    }
                    if (AU != "NOS")
                        lblremainingIDT.Text = (Convert.ToDouble(txtIssuequantity.Text)).ToString("0.00");

                    else
                        lblremainingIDT.Text = (Convert.ToDouble(txtIssuequantity.Text)).ToString("0.000");
                    if (WOP != 0)
                    {
                        lblApproxWeight.Text = "[Approx. Weight: " + (WOP * Convert.ToDouble(txtIssuequantity.Text)).ToString("0.000") + "]";
                    }
                    binddropdown(prdid);
                    sdt.Rows.Clear();
                }      

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void lbtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                if (btn.CommandArgument != null)
                {
                    int BID = int.Parse(btn.CommandArgument);

                    for (int i = 0; i < sdt.Rows.Count;i++ )
                    {
                        if (int.Parse(sdt.Rows[i]["BID"].ToString()) == BID)
                        {
                            sdt.Rows.RemoveAt(i);

                        }
                    }

                    rgdQty.DataSource = sdt;
                    rgdQty.DataBind();
                    foreach (GridColumn myColumn in rgdQty.MasterTableView.RenderColumns)
                    {
                        if (Case == 2 || Case == 4 || Case == 5)
                        {
                            if (myColumn.UniqueName == "FullPack")

                                myColumn.Visible = false;


                            if (myColumn.UniqueName == "IssuQtyFromFull")

                                myColumn.Visible = false;
                            if (myColumn.UniqueName == "ShufflePAcks")

                                myColumn.Visible = false;

                        }



                    }

                    binddropdown(prdid);
                }
                _BindData(double.Parse(txtIssuequantity.Text));
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void rgdIssuedList_ItemCreated(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    
                    GridDataItem item = (e.Item as GridDataItem);
                    int idtID = int.Parse(item.GetDataKeyValue("id").ToString());                    
                        Label lblFullPack = (Label)item.FindControl("lblFullPack");                      
                        Label lblFullPackQty = (Label)item.FindControl("lblFullPackQty");                     
                        Label lblLoosePack = (Label)item.FindControl("lblLoosePack");                       
                        Label lblLoosePackQty = (Label)item.FindControl("lblLoosePackQty");
                        rhpdEntities db = new rhpdEntities();
                        var IDTList = db.IDTStockTransfers.Where(x => x.IDTId == idtID).ToList();
                        foreach (var val in IDTList)
                        {

                            if (val.PackingType == "Full")
                            {
                                lblFullPack.Text = val.Format;
                                if(AU!="NOS")
                                lblFullPackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.000") + " ]";
                                else
                                    lblFullPackQty.Text = "[Qty: " +  Convert.ToDouble(val.Quantity).ToString("0.00") + " ]";
                            }
                            else if (val.PackingType == "Loose" || val.PackingType == "DW")
                            {
                                lblLoosePack.Text = val.Format;
                                if (AU != "NOS")
                                    lblLoosePackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.000") + " ]";
                                else
                                    lblLoosePackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.00") + " ]";
                            }                           
                            else if (val.PackingType == "")
                            {
                               
                                if (AU != "NOS")
                                    lblLoosePackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.000") + " ]";
                                else
                                    lblLoosePackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.00") + " ]";
                            }
                        }
                       



                    
                }
            }
            catch (Exception)
            {
                
                throw;
            }
                   

        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                 LinkButton btn = (LinkButton)sender;
                 if (btn.CommandArgument != null)
                 {
                     int idtID = int.Parse(btn.CommandArgument);
                     rhpdEntities db = new rhpdEntities();

                     var IDT = db.tbl_batchIdt.Where(t => t.id == idtID).FirstOrDefault();
                     if (IDT != null)
                     {
                         var stock = db.BatchMasters.Where(b => b.BID == IDT.BID).FirstOrDefault();
                         if (stock != null)
                         {
                             //UpdateStock
                             int SID = Convert.ToInt32(stock.StockId);
                             double Qty = Convert.ToDouble(IDT.issueqty);
                             using (SqlCommand cmd = new SqlCommand("spUpdateStockOnIDTDelete", con))
                             {
                                 if (con.State.ToString() == "Closed")
                                     con.Open();
                                 cmd.CommandType = CommandType.StoredProcedure;
                                 cmd.Parameters.AddWithValue("@idtID", idtID);
                                 cmd.Parameters.AddWithValue("@SID", SID);
                                 cmd.Parameters.AddWithValue("@Quantity", Qty);
                                 cmd.ExecuteNonQuery();
                                 con.Close();

                             }
                         }
                     }
            

                     _GetIssued();
                     
                 }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
    }
}

