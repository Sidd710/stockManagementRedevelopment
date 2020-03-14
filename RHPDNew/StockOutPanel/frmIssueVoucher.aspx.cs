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
using AjaxControlToolkit;
using Telerik.Web.UI;
using RHPDComponent;
using System.Globalization;
namespace RHPDNew.StockOutPanel
{
    public partial class frmIssueVoucher : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
      static  int catID;
      static  int issueorderId;
     public static int Status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["DOG"] != null)
                {
                    txtdateofgenration.SelectedDate = Convert.ToDateTime(Session["DOG"]);
                }
                else
                    txtdateofgenration.SelectedDate = DateTime.Now;
                if (Session["IVNo"] != null)
                { txtissueVoucher.Text = Session["IVNo"].ToString(); }

                if (Request.QueryString["Status"] != null)
                    Status = Convert.ToInt32(Request.QueryString["Status"]);
                else
                    Status = 0;
                catID = Convert.ToInt32(Request.QueryString["Category_Id"]);
                issueorderId = Convert.ToInt32(Request.QueryString["IssueOrderId"]);
                hdnIssueOrderID.Value = issueorderId.ToString();
                ViewState["categoryID"] = catID;
                Session["CatID"] = catID;
                //genrateAutoIssuevoucherNumber(issueorderId, catID);
                getdetail(catID);
                bindissuevoucherdetail(catID);
                bindIssueorderforIssueVoucher(catID);
                if (Status == 1)
                    btnsubmit.Visible = false;
            }
        }      
        public void genrateAutoIssuevoucherNumber(int issueodId, int categoryId)
        {
            if (txtissueVoucher.Text == "")
            { txtissueVoucher.Focus(); return; }
            SqlCommand cmd = new SqlCommand("usp_creareIssueVoucherNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IssueorderId", issueodId);
            cmd.Parameters.AddWithValue("@CatId", categoryId);
            cmd.Parameters.AddWithValue("@ivNo", txtissueVoucher.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
     public string getIssuevoucherNumber()
        {
            genrateAutoIssuevoucherNumber(issueorderId, catID);
            using (SqlCommand cmd = new SqlCommand("usp_getissuevoucherNumber", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@issueorderid", issueorderId);
                cmd.Parameters.AddWithValue("@CatId", ViewState["categoryID"]);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                       return dr["IssusevoucherName"].ToString();


                    }
                    else
                    {
                        return "";
                    }
                }
                con.Close();
            }
        }
        public void getdetail(int cat_ID)
        {
            using (SqlCommand cmd = new SqlCommand("usp_getdeatilIssuevoucher", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@catid", cat_ID);
                cmd.Parameters.AddWithValue("@issueorderid", issueorderId);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        lblAuthority.Text = dr["Authority"].ToString();
                        lblcategory.Text = dr["Category_Name"].ToString();
                        tablefirst.Visible = true;
                      
                    }
                    else
                    {
                       
                        tablefirst.Visible = false;
                       

                    }
                }
                con.Close();
            }


        }
       public void bindissuevoucherdetail(int cid)
        {
           // getIssuevoucherNumber();
            using (SqlCommand cmd = new SqlCommand("usp_getissuevoucherdetail", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@catid", cid);
                cmd.Parameters.AddWithValue("@issueorderid", issueorderId);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                       
                        txtdateofgenration.SelectedDate =Convert.ToDateTime(dr["dateofgenration"].ToString());
                        txtissueVoucher.Text = dr["issuevoucherid"].ToString();
                        txtissueVoucher.Enabled = false;
                        txtdateofgenration.Enabled = false;
                        btnsubmit.Visible = false;                      
                       
                        tablefirst.Visible = true;
                        
                    }
                    else
                    {
                        txtissueVoucher.Enabled = true;
                        txtdateofgenration.Enabled = true;
                        if (Status==0)
                        btnsubmit.Visible = true;
                        
                    }
                }
                con.Close();
            }

        }


      
       public static int Case = 0;
       public static string stockCase = "";
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

        private void bindIssueorderforIssueVoucher(int categoryID)
        {

            SqlCommand cmd = new SqlCommand("usp_getisuueorder_forIssueVoucher", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@catID", categoryID);
            cmd.Parameters.AddWithValue("@issueorderid", issueorderId);
            if(con.State.ToString()=="Closed")
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                rgdIssueVoucher.DataSource = dt;
                rgdIssueVoucher.DataBind();
                double totalQtyFull = 0;
                double totalIssuedQtyFull = 0;
                RadGrid rgdIssueBatch = new RadGrid();

                foreach (GridDataItem pitem in rgdIssueVoucher.MasterTableView.Items)
                {
                    int productID = int.Parse(pitem.GetDataKeyValue("productID").ToString());
                    //RadGrid rgdIssueBatch = (RadGrid)pitem.FindControl("rgdIssueBatch");
                    rgdIssueBatch = (RadGrid)pitem.FindControl("rgdIssueBatch");
                    GridFooterItem footer = (GridFooterItem)rgdIssueBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
                    
                    Label lblTotalTranfered = (Label)footer.FindControl("lblTotalTranfered");
                    Label lblVQty = (Label)pitem.FindControl("lblVQty");

                    totalQtyFull = totalQtyFull + double.Parse(lblVQty.Text);
                    double totalIssuedQty = 0;
                    bool show = true;
                    string VehicleNos="";
                    RadGrid rgdVehicle = (RadGrid)pitem.FindControl("rgdVehicle");
                    rgdVehicle.DataSource = getVehicle(catID, issueorderId, productID);
                    rgdVehicle.DataBind();
                    foreach (GridDataItem v in rgdVehicle.MasterTableView.Items)
                    {
                        Label lblVehicleNo = (Label)v.FindControl("lblVehicleNo");
                        if (lblVehicleNo.Text != "")
                        {
                            if (VehicleNos == "")
                                //VehicleNos=VehicleNos+"'"+lblVehicleNo.Text+"'";
                                //else
                                //  VehicleNos=",'"+VehicleNos+lblVehicleNo.Text+"'";
                                VehicleNos = VehicleNos + lblVehicleNo.Text;
                            else
                                VehicleNos = "," + VehicleNos + lblVehicleNo.Text;
                        }
                    }
                    foreach (GridColumn myColumn in rgdVehicle.MasterTableView.RenderColumns)
                    {
                        if (myColumn.UniqueName == "Full")
                        {
                            if (Case == 1 || Case == 3)
                                myColumn.Visible = true;
                            else
                                myColumn.Visible = false;
                        }
                        if (myColumn.UniqueName == "Loose")
                        {
                            if (Case == 4 || Case == 5)
                                myColumn.Visible = false;
                            else
                                myColumn.Visible = true;
                        }
                    }
                    foreach (GridDataItem vitem in rgdVehicle.MasterTableView.Items)
                    {
                        Label lblStockQuantity = (Label)vitem.FindControl("lblStockQuantity");
                        totalIssuedQty = totalIssuedQty + double.Parse(lblStockQuantity.Text);
                    }
                    foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                    {
                        Panel pnl = (Panel)item.FindControl("pnlVehicle");
                        Label lblPack = (Label)item.FindControl("lblPack");
                        RadNumericTextBox txtPack = (RadNumericTextBox)item.FindControl("txtPack");
                        Label lblFormatFull = (Label)item.FindControl("lblFormatFull");
                        Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
                        Label lblTotalQty = (Label)item.FindControl("lblTotalQty");
                        Label lblBatchNo = (Label)item.FindControl("lblBatchNo");
                         
                        Label lblissueqty = (Label)item.FindControl("lblissueqty");
                        Label lblEsl = (Label)item.FindControl("lblEsl");
                        if (lblEsl.Text == "")
                            show = false;
                        hdnBID.Value = item.GetDataKeyValue("BatchName").ToString();
                        rhpdEntities db = new rhpdEntities();

                        var listBatch = db.BatchMasters.Where(b => b.BatchNo == hdnBID.Value).FirstOrDefault();
                        if (listBatch != null)
                        {
                            _CheckCase(Convert.ToInt32(listBatch.StockId));

                            DropDownList ddlVehicle = (DropDownList)item.FindControl("ddlVehicle");
                            ddlVehicle.DataSource = getVehicleMaster(VehicleNos);
                            ddlVehicle.DataBind();
                            
                          
                          
                            //if (double.Parse(lblissueqty.Text) == totalIssuedQty)
                            //{
                            //    pnl.Visible = false;
                            //}
                            DataTable dtV = new DataTable();
                            dtV = ProcessIT(productID);
                            if ( pnl.Visible == false)
                            {}
                            else
                                if (dtV.Rows.Count > 0)
                            {
                                if (Case == 1 || Case == 3)
                                {
                                    string[] frm;
                                    string pFrm = "";
                                    System.Text.StringBuilder str = new System.Text.StringBuilder();
                                    if (dtV.Rows.Count == 2)
                                    {
                                        if (dtV.Rows[0]["PackingType"].ToString() == "Full")
                                        {
                                            frm = dtV.Rows[0]["Format"].ToString().Split('X');
                                            for (int i = 1; i < frm.Count(); i++)
                                            {
                                                pFrm = pFrm + "X" + frm[i].ToString();

                                            }
                                            lblFormatFull.Text = dtV.Rows[0]["CurrentFormat"].ToString();
                                            lblFormatLoose.Text = dtV.Rows[1]["CurrentFormat"].ToString();
                                            //lblTotalQty.Text = (double.Parse(dtV.Rows[0]["Quantity"].ToString()) + double.Parse(dtV.Rows[1]["Quantity"].ToString())).ToString();
                                            //lblPack.Text = pFrm;
                                        }
                                        else
                                        {
                                            frm = dtV.Rows[1]["Format"].ToString().Split('X');
                                            for (int i = 1; i < frm.Count(); i++)
                                            {
                                                pFrm = pFrm + "X" + frm[i].ToString();

                                            }
                                            lblFormatFull.Text = dtV.Rows[1]["CurrentFormat"].ToString();
                                            lblFormatLoose.Text = dtV.Rows[0]["CurrentFormat"].ToString();
                                           
                                        }
                                        if (dtV.Rows[0]["Quantity"].ToString() != "" && dtV.Rows[1]["Quantity"].ToString()!="")
                                        lblTotalQty.Text = (double.Parse(dtV.Rows[0]["Quantity"].ToString()) + double.Parse(dtV.Rows[1]["Quantity"].ToString())).ToString();

                                        lblPack.Text = pFrm;
                                    }
                                    else if (dtV.Rows.Count == 1)
                                    {
                                        if (dtV.Rows[0]["PackingType"].ToString() == "Full")
                                        {
                                            frm = dtV.Rows[0]["Format"].ToString().Split('X');
                                            for (int i = 1; i < frm.Count(); i++)
                                            {
                                                pFrm = pFrm + "X" + frm[i].ToString();

                                            }
                                            lblFormatFull.Text = dtV.Rows[0]["CurrentFormat"].ToString();
                                            lblFormatLoose.Text = "";
                                             if (dtV.Rows[0]["Quantity"].ToString() != "" )
                                            lblTotalQty.Text = (double.Parse(dtV.Rows[0]["Quantity"].ToString())).ToString();
                                            lblPack.Text = pFrm;
                                        }
                                        else
                                        {
                                            //frm = dtV.Rows[1]["Format"].ToString().Split('X');
                                            //for (int i = 1; i < frm.Count(); i++)
                                            //{
                                            //    pFrm = pFrm + "X" + frm[i].ToString();

                                            //}
                                            lblFormatFull.Text = "";
                                            lblFormatLoose.Text = dtV.Rows[0]["CurrentFormat"].ToString();
                                             if (dtV.Rows[0]["Quantity"].ToString() != "" )
                                            lblTotalQty.Text = (double.Parse(dtV.Rows[0]["Quantity"].ToString())).ToString();
                                            lblPack.Text = pFrm;
                                        }
                                    
                                    
                                    }
                                    if (lblTotalQty.Text == "0")
                                    {
                                        lblFormatFull.Text = "";
                                        lblFormatLoose.Text = "";
                                        pnl.Visible = false;

                                    }
                                    RadGrid rgdChild = (RadGrid)item.FindControl("rgdChildLoosePAck");
                                    if (lblFormatLoose.Text != "")
                                    {

                                        if (rgdChild != null)
                                        {
                                            // sLooseCount = sLooseCount - 1;

                                            DataTable dtChild = new DataTable();
                                            dtChild.Columns.AddRange(new DataColumn[3] { 
                    new DataColumn("childID", typeof(int)),
                    new DataColumn("Level", typeof(string)),
                    new DataColumn("LevelID",typeof(string)) 
                   });

                                            string[] loose = lblFormatLoose.Text.Split('|');
                                            //int level = Convert.ToInt32(hdnLevel.Value);
                                            for (int l = 1; l < loose.Count(); l++)
                                            {
                                                if (l == 1)
                                                    dtChild.Rows.Add(l, "Main Packet(s)", (l).ToString());
                                                else if (l == loose.Count())
                                                    dtChild.Rows.Add(l, "Pieces/Qty ", (l).ToString());
                                                else
                                                    dtChild.Rows.Add(l, "Level " + (l).ToString(), (l).ToString());
                                            }
                                            rgdChild.DataSource = dtChild;
                                            rgdChild.DataBind();
                                        }
                                    }
                                    else
                                    {
                                        rgdChild.Visible = false;
                                        CheckBox cbxLoose = (CheckBox)item.FindControl("cbxLoose");
                                        cbxLoose.Enabled = false;
                                        // cbxLoose.Visible = false;
                                        cbxLoose.Text = "Loose already taken";

                                    }
                                    // }

                                }

                                else if (Case == 2)
                                {


                                    if (dtV.Rows[0]["PackingType"].ToString() == "DW")
                                    {

                                        lblFormatFull.Text = "N/A";
                                        lblFormatLoose.Text = dtV.Rows[0]["Format"].ToString();

                                        
                                        lblTotalQty.Text = (double.Parse(dtV.Rows[0]["Quantity"].ToString())).ToString("0.000");
                                        lblPack.Text = "XDW";
                                        CheckBox cbxLoose = (CheckBox)item.FindControl("cbxLoose");
                                        cbxLoose.Enabled = false;
                                        // cbxLoose.Visible = false;
                                        cbxLoose.Text = "N/A";

                                    }

                                }
                                else if (Case == 4 || Case == 5)
                                {
                                 lblTotalQty.Text = (double.Parse(dtV.Rows[0]["Quantity"].ToString())).ToString("0.000");
                                 lblFormatFull.Text = "N/A";
                                 lblFormatLoose.Text = "N/A";
                                 CheckBox cbxLoose = (CheckBox)item.FindControl("cbxLoose");
                                 cbxLoose.Enabled = false;
                                 cbxLoose.Text = "N/A";
                                 lblPack.Text = "N/A";
                                 txtPack.Visible = false;
                                }

                               
                            }
                            lblTotalTranfered.Text = totalIssuedQty.ToString("0.00");
                            totalIssuedQtyFull = totalIssuedQtyFull + totalIssuedQty;
                        }
                        foreach (GridColumn myColumn in rgdIssueBatch.MasterTableView.RenderColumns)
                        {
                            if (myColumn.UniqueName == "Esl")

                                myColumn.Visible = show;
                        }
                    }
                    break;
                }
                   
                productgrid.Visible = true;
                if (totalIssuedQtyFull == totalQtyFull)
                {if(Status==0)
                    btnsubmit.Visible = true;
                }
                else
                    btnsubmit.Visible = false;

            }
            else
            {
                    productgrid.Visible = false;
            }
            con.Close();
        }

    
        protected void btngeIssuvoucher_Click(object sender, EventArgs e)
        {
            int result = 1;
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_GenrateIssueVoucher", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@catId", ViewState["categoryID"]);
                    cmd.Parameters.AddWithValue("@catId", catID);
                   string ivNo=getIssuevoucherNumber();
                    if(ivNo=="")
                    {
                        result = 0; return;
                    }
                   // cmd.Parameters.AddWithValue("@issueorderId", issueorderId);
                    cmd.Parameters.AddWithValue("@IssueVoucherNumber", ivNo);
                 
                    cmd.ExecuteNonQuery();

                }
                if(result==1)
                Response.Redirect("issueorderlist.aspx");
            }
            con.Close();
        }

       

       

      
        public DataTable GetBatchDetail(int ProductId, int issueorderID)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetBatchquantity", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@productID", ProductId);
                    cmd.Parameters.AddWithValue("@issueorderid", issueorderID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                         return dt;
                   
                }
            }

        }

        protected void rgdIssueVoucher_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (e.Item as GridDataItem);
                    int productID = int.Parse(item.GetDataKeyValue("productID").ToString());
                    RadGrid rgdIssueBatch = (RadGrid)item.FindControl("rgdIssueBatch");
                    rgdIssueBatch.DataSource = GetBatchDetail(productID, issueorderId);
                    rgdIssueBatch.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        protected DataTable getVehicle(int CatID, int IssueID,int ProductID)
        {

            try
            {
               // IssueID = Convert.ToInt32(Request.QueryString["isID"]);
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlCommand cmd = new SqlCommand("spSelectTranfer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetVehiclebyBatch");
              
                cmd.Parameters.AddWithValue("@CatID", CatID);
                cmd.Parameters.AddWithValue("@IssuOrderID", IssueID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);                
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
        protected DataTable ProcessIT(int productID)
        {
            try
            {
                DataTable dtV = new DataTable();
                if (hdnBID.Value != "")
                {
                    //int id = int.Parse(hdnBID.Value);
                    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("spSelectTranfer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "GetIDT");
                    cmd.Parameters.AddWithValue("@BatchNo", hdnBID.Value);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.Parameters.AddWithValue("@IssuOrderID", issueorderId);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("spSelectTranfer", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        if (Case == 1 || Case == 3)
                            cmd1.Parameters.AddWithValue("@Action", "GetIDTQtyByIssueOrderIDCase13");
                        else 
                            //if(Case==2)
                            cmd1.Parameters.AddWithValue("@Action", "GetIDTQtyByIssueOrderIDCase245");
                        //else if (Case == 4 || Case == 5)
                        //    cmd1.Parameters.AddWithValue("@Action", "GetIDTQtyByIssueOrderIDCase45");
                     
                        cmd1.Parameters.AddWithValue("@IssuOrderID", int.Parse(dt.Rows[0]["Issueorderid"].ToString()));
                        cmd1.Parameters.AddWithValue("@ProductID", int.Parse(dt.Rows[0]["ProductID"].ToString()));
                        cmd1.Parameters.AddWithValue("@BatchNo", (dt.Rows[0]["BatchName"].ToString()));
                        SqlDataAdapter daV = new SqlDataAdapter(cmd1);
                        daV.Fill(dtV);
                    }

                } return dtV;
            }
            catch (Exception)
            {

                throw;
            }

        }
        
        private DataTable getVehicleMaster(string VehicleNos)
        {

            SqlCommand cmd = new SqlCommand("usp_GetVechile_Detail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Todaysdate", "Get");
            //cmd.Parameters.AddWithValue("@productID", productID);
            //cmd.Parameters.AddWithValue("@VehicleNos", VehicleNos);
            //con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           // con.Close();
            return dt;
        }

        protected void ddlVehicle_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "--Select--";
                ddl.Items.Insert(0, li);
        }

        protected void btnAddVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string[] arg=btn.CommandArgument.ToString().Split(',');
                foreach (GridDataItem pitem in rgdIssueVoucher.MasterTableView.Items)
                {
                    int productID = int.Parse(pitem.GetDataKeyValue("productID").ToString());
                    Label lblVQty = (Label)pitem.FindControl("lblVQty");
                    double totalIssuedQty = double.Parse(lblVQty.Text);
                    RadGrid rgdVehicle = (RadGrid)pitem.FindControl("rgdVehicle");
                    rgdVehicle.DataSource = getVehicle(catID, issueorderId, productID);
                    rgdVehicle.DataBind();
                    foreach (GridDataItem v in rgdVehicle.MasterTableView.Items)
                    {
                        Label lblStockQuantity = (Label)v.FindControl("lblStockQuantity");
                        totalIssuedQty = totalIssuedQty - double.Parse(lblStockQuantity.Text);
                    }
                    RadGrid rgdIssueBatch = (RadGrid)pitem.FindControl("rgdIssueBatch");
                    foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                    {
                        Label lblBatchNo = (Label)item.FindControl("lblBatchNo");
                       
                        if (item.GetDataKeyValue("BatchName").ToString() == arg[0] && productID == int.Parse(arg[1]))
                        {

                            DropDownList ddlVehicle = (DropDownList)item.FindControl("ddlVehicle");
                        
                            RadNumericTextBox txtQty = (RadNumericTextBox)item.FindControl("txtQty");
                            RadNumericTextBox txtPack = (RadNumericTextBox)item.FindControl("txtPack");
                            CheckBox cbxLoose = (CheckBox)item.FindControl("cbxLoose");
                            Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
                            Label lblFormatFull = (Label)item.FindControl("lblFormatFull");
                            Label lblTotalQty = (Label)item.FindControl("lblTotalQty");
                            CheckBox cbxFullOccupied = (CheckBox)item.FindControl("cbxFullOccupied");
                            int FullOccupied = 0;
                            if (cbxFullOccupied.Checked)
                                FullOccupied = 1;
                            string FullFormat = "";
                            string LooseFormat = "";
                            string[] full = lblFormatFull.Text.Split('X');
                            string[] loose = lblFormatLoose.Text.Split('|');
                            double stockQty = txtQty.Text!="" ? double.Parse(txtQty.Text):0.0;
                            if (Case == 1 || Case == 3)
                            {
                                FullFormat = txtPack.Text;
                                for (int f = 1; f < full.Count(); f++)
                                {
                                    FullFormat = FullFormat + "X" + full[f];
                                }

                                if (cbxLoose.Checked)
                                {
                                    lblFormatLoose.Text = "";
                                    stockQty = (stockQty + double.Parse(loose[loose.Count() - 1].ToString()));
                                    cbxLoose.Enabled = false;
                                    cbxLoose.Checked = false;

                                    RadGrid rgdChild = (RadGrid)item.FindControl("rgdChildLoosePAck");
                                    foreach (GridDataItem gitem in rgdChild.MasterTableView.Items)
                                    {
                                        int levelID = Convert.ToInt32(gitem.GetDataKeyValue("childID").ToString());
                                        RadNumericTextBox txtLevel = (RadNumericTextBox)gitem.FindControl("txtLevel");
                                        LooseFormat = LooseFormat + txtLevel.Text + "|";

                                    }
                                    LooseFormat = LooseFormat + loose[loose.Count() - 1];

                                }
                            }
                            else if (Case == 2)
                            {

                                FullFormat = "";

                                double leftLoose = 0;
                                if (lblFormatLoose.Text.Split('X')[0] != "")
                                    leftLoose = double.Parse(lblFormatLoose.Text.Split('X')[0]);
                                if (txtPack.Text != "")
                                {
                                    LooseFormat = txtPack.Text + "XDW";
                                    lblFormatLoose.Text = (leftLoose - (double.Parse(txtPack.Text))).ToString() + "XDW";
                                }
                                else
                                    LooseFormat = "0XDW";


                                txtQty.Text = "0";
                                lblFormatFull.Text = "";

                            }
                            else if (Case == 4 || Case == 5)
                            {

                                FullFormat = "";
                                LooseFormat = "";
                                lblFormatFull.Text = "";
                                lblFormatLoose.Text = "";
                                txtQty.Text = "0";

                            }
                            string VoucherId = getIssuevoucherNumber();
                            string dog = txtdateofgenration.SelectedDate.ToString();

                            string authorty = lblAuthority.Text;
                            if (VoucherId == "")
                                VoucherId = txtissueVoucher.Text;
                            if (dog == "" || VoucherId == "")
                            {
                                bindIssueorderforIssueVoucher(catID);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Define DOG & Issue Voucher No first !')", true);
                                return;
                            }

                            string bthcNo = lblBatchNo.Text;
                            int r = 0;
                            string msg = "";
                            if (stockQty > totalIssuedQty)
                            {
                                bindIssueorderforIssueVoucher(catID);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vehicle transfer qty greater than issued Qty!')", true);
                                return;
                            }
                            //r = insertIssueVoucher(stockQty, lblFormatFull.Text, lblFormatLoose.Text, LooseFormat, FullFormat, lblBatchNo.Text, _ddlVehicleText, "10", stockQty, VoucherId, dog, "", productID, authorty, catID, issueorderId, bthcNo, FullOccupied);
                            
                            msg = "Vehicle added successfully";

                            if (r == 1)
                            {

                                //string[] Full = lblFormatFull.Text.Split('X');
                                //lblFormatFull.Text = (double.Parse(Full[0]) - double.Parse(txtPack.Text)).ToString();
                                //double packValue = 1;
                                //for (int i = 1; i < Full.Count(); i++)
                                //{
                                //    lblFormatFull.Text = lblFormatFull.Text + "X" + Full[i];
                                //    packValue = packValue * (double.Parse(Full[i]));
                                //}
                                //lblTotalQty.Text = (int.Parse(lblTotalQty.Text) - stockQty).ToString();
                                //if (cbxLoose.Checked)
                                //{
                                //    cbxLoose.Text = "Loose already taken";
                                //   // lblFormatLoose.Text = "N/A";
                                //}
                                //ddlVehicle.DataBind();
                                //txtQty.Text = "";
                                //txtPack.Text = "";
                                //cbxLoose.Checked = false;

                                //RadGrid rgdVehicle = (RadGrid)item.FindControl("rgdVehicle");
                                //rgdVehicle.DataSource = getVehicle(lblBatchNo.Text, catID, issueorderId, productID);
                                //rgdVehicle.DataBind();
                                bindIssueorderforIssueVoucher(catID);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + msg + " !')", true);

                                return;
                            }

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }

        }
       public int insertIssueVoucher(double FullQty,string LeftFormatFull, string LeftFormatLoose,string FormatLoose ,string FormatFull,string BatchNo,string VehicleNo, string PMQuantity, double StockQuantity, string IssueVoucherId, string dateofgenration, string Through, int ProductId, string Authority, int Cat_Id, int issueorderID, string batchno,int FullOccupied)
        {

            DateTime dogDate = Convert.ToDateTime(dateofgenration);
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_IssueVoucherVehicleDetail_AddUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@FullOccupied", FullOccupied);
                    cmd.Parameters.AddWithValue("@Case", Case);
                    cmd.Parameters.AddWithValue("@BatchNo", BatchNo.Trim());
                    cmd.Parameters.AddWithValue("@FormatFull", FormatFull);
                    cmd.Parameters.AddWithValue("@FormatLoose ", FormatLoose);
                    cmd.Parameters.AddWithValue("@LeftFormatFull", LeftFormatFull);
                    cmd.Parameters.AddWithValue("@LeftFormatLoose ", LeftFormatLoose);
                    cmd.Parameters.AddWithValue("@FullQty", FullQty);                  
                    cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo.Trim());
                    cmd.Parameters.AddWithValue("@PMQuantity", PMQuantity);
                    cmd.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                    cmd.Parameters.AddWithValue("@IssueVoucherId", IssueVoucherId.Trim());
                    cmd.Parameters.AddWithValue("@dateofgenration", dogDate);
                    cmd.Parameters.AddWithValue("@Through", Through);
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    cmd.Parameters.AddWithValue("@VoucherRemarks", "");
                    cmd.Parameters.AddWithValue("@authority", Authority);
                    cmd.Parameters.AddWithValue("@catid", Cat_Id);
                    cmd.Parameters.AddWithValue("@UserId", HttpContext.Current.Session["UserId"]);
                    cmd.Parameters.AddWithValue("@issueorderid", issueorderID);
                    cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
                    cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);

                    con.Close();

                    if (intResult == 1)
                    {

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            bindIssueorderforIssueVoucher(catID);
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadNumericTextBox box = (RadNumericTextBox)sender;
                string[] toolTip = box.ToolTip.ToString().Split(',');
               
                foreach (GridDataItem pitem in rgdIssueVoucher.MasterTableView.Items)
                {
                    int productID = int.Parse(pitem.GetDataKeyValue("productID").ToString());
                    RadGrid rgdIssueBatch = (RadGrid)pitem.FindControl("rgdIssueBatch");
                    foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                    {
                        if (item.GetDataKeyValue("BatchName").ToString() == toolTip[0] && productID == int.Parse(toolTip[1]))
                        {

                            Label lblissueqty = (Label)item.FindControl("lblissueqty");
                            Label lblTotalQty = (Label)item.FindControl("lblTotalQty");
                            if (lblTotalQty.Text != "" && box.Text != "")
                            {
                                if (double.Parse(lblTotalQty.Text) < double.Parse(box.Text))
                                {
                                    bindIssueorderforIssueVoucher(catID);
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Stock Qty can not be greater than Total Issue Qty !')", true);
                                    box.Focus();

                                    return;
                                }
                            }
                            rhpdEntities db = new rhpdEntities();
                            string bno = item.GetDataKeyValue("BatchName").ToString();
                            var listBatch = db.BatchMasters.Where(b => b.BatchNo == bno).FirstOrDefault();
                            if (listBatch != null)
                            {
                                _CheckCase(Convert.ToInt32(listBatch.StockId));

                                if (Case == 1 || Case == 3)
                                {
                                    RadNumericTextBox txtPack = (RadNumericTextBox)item.FindControl("txtPack");
                                    Label lblFormatFull = (Label)item.FindControl("lblFormatFull");

                                    // Label lblTotalQty = (Label)item.FindControl("lblTotalQty");
                                    string[] Full = lblFormatFull.Text.Split('X');
                                    double qty = double.Parse(box.Text);
                                    double packValue = 1;
                                    for (int i = 1; i < Full.Count(); i++)
                                    {
                                        packValue = packValue * (double.Parse(Full[i]));
                                    }
                                    box.Text = (double.Parse(box.Text) - (double.Parse(box.Text) % packValue)).ToString();
                                    qty = (qty / packValue);
                                    string[] val = qty.ToString().Split('.');
                                    txtPack.Text = val[0];
                                }
                                Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
                                if (lblFormatLoose.Text != "")
                                {
                                    RadGrid rgdChild = (RadGrid)item.FindControl("rgdChildLoosePAck");
                                    if (rgdChild != null)
                                    {
                                        DataTable dtChild = new DataTable();
                                        dtChild.Columns.AddRange(new DataColumn[3] { 
                    new DataColumn("childID", typeof(int)),
                    new DataColumn("Level", typeof(string)),
                    new DataColumn("LevelID",typeof(string)) 
                   });

                                        string[] loose = lblFormatLoose.Text.Split('|');

                                        for (int l = 1; l < loose.Count(); l++)
                                        {
                                            if (l == 1)
                                                dtChild.Rows.Add(l, "Main Packet(s)", (l).ToString());
                                            else if (l == loose.Count())
                                                dtChild.Rows.Add(l, "Pieces/Qty ", (l).ToString());
                                            else
                                                dtChild.Rows.Add(l, "Level " + (l).ToString(), (l).ToString());
                                        }
                                        rgdChild.DataSource = dtChild;
                                        rgdChild.DataBind();
                                    }
                                    else
                                    {
                                        rgdChild.Visible = false;
                                        CheckBox cbxLoose = (CheckBox)item.FindControl("cbxLoose");
                                        cbxLoose.Enabled = false;

                                    }

                                }
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtPack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadNumericTextBox box = (RadNumericTextBox)sender;
                string[] toolTip = box.ToolTip.ToString().Split(',');
               
                foreach (GridDataItem pitem in rgdIssueVoucher.MasterTableView.Items)
                {
                    int productID = int.Parse(pitem.GetDataKeyValue("productID").ToString());
                    RadGrid rgdIssueBatch = (RadGrid)pitem.FindControl("rgdIssueBatch");
                    foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                    {
                        if (item.GetDataKeyValue("BatchName").ToString() == toolTip[0] && productID == int.Parse(toolTip[1]))
                        {
                            RadNumericTextBox txtQty = (RadNumericTextBox)item.FindControl("txtQty");
                            Label lblFormatFull = (Label)item.FindControl("lblFormatFull");
                            Label lblTotalQty = (Label)item.FindControl("lblTotalQty");
                            rhpdEntities db = new rhpdEntities();
                            string bno = item.GetDataKeyValue("BatchName").ToString();
                            var listBatch = db.BatchMasters.Where(b => b.BatchNo == bno).FirstOrDefault();
                            if (listBatch != null)
                            {
                                _CheckCase(Convert.ToInt32(listBatch.StockId));
                                if (Case == 1 || Case == 3)
                                {
                                    string[] Full = lblFormatFull.Text.Split('X');
                                    double qty = double.Parse(box.Text);
                                    double packValue = 1;
                                    for (int i = 1; i < Full.Count(); i++)
                                    {
                                        packValue = packValue * (double.Parse(Full[i]));
                                    }
                                    qty = qty * packValue;
                                    if (double.Parse(lblTotalQty.Text) < qty)
                                    {
                                        bindIssueorderforIssueVoucher(catID);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Stock Qty can not be greater than Total Issue Qty !')", true);
                                        box.Focus();

                                      
                                        return;
                                    }
                                    txtQty.Text = qty.ToString();

                                    Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
                                    if (lblFormatLoose.Text != "")
                                    {
                                        RadGrid rgdChild = (RadGrid)item.FindControl("rgdChildLoosePAck");
                                        if (rgdChild != null)
                                        {
                                            DataTable dtChild = new DataTable();
                                            dtChild.Columns.AddRange(new DataColumn[3] { 
                    new DataColumn("childID", typeof(int)),
                    new DataColumn("Level", typeof(string)),
                    new DataColumn("LevelID",typeof(string)) 
                   });

                                            string[] loose = lblFormatLoose.Text.Split('|');

                                            for (int l = 1; l < loose.Count(); l++)
                                            {
                                                if (l == 1)
                                                    dtChild.Rows.Add(l, "Main Packet(s)", (l).ToString());
                                                else if (l == loose.Count())
                                                    dtChild.Rows.Add(l, "Pieces/Qty ", (l).ToString());
                                                else
                                                    dtChild.Rows.Add(l, "Level " + (l).ToString(), (l).ToString());
                                            }
                                            rgdChild.DataSource = dtChild;
                                            rgdChild.DataBind();
                                        }
                                        else
                                        {
                                            rgdChild.Visible = false;
                                            CheckBox cbxLoose = (CheckBox)item.FindControl("cbxLoose");
                                            cbxLoose.Enabled = false;

                                        }

                                    }
                                }
                                else if (Case == 2)
                                {
                                    Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");

                                    double pqty = double.Parse(lblFormatLoose.Text.Split('X')[0]);
                                    if (double.Parse(box.Text) > pqty)
                                    {
                                        bindIssueorderforIssueVoucher(catID);
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only " + pqty.ToString() + " Pack available!')", true);
                                        box.Focus();
                                       
                                        return;
                                    }

                                }


                            }
                        }
                        }}
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cbxLoose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                 CheckBox cbx = (CheckBox)sender;
                 string[] toolTip = cbx.ToolTip.ToString().Split(',');

                foreach (GridDataItem pitem in rgdIssueVoucher.MasterTableView.Items)
                {
                    int productID = int.Parse(pitem.GetDataKeyValue("productID").ToString());
                    RadGrid rgdIssueBatch = (RadGrid)pitem.FindControl("rgdIssueBatch");
                    foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                    {
                        if (item.GetDataKeyValue("BatchName").ToString() == toolTip[0] && productID == int.Parse(toolTip[1]))
                        {

                            RadGrid rgdChildLoosePAck = (RadGrid)item.FindControl("rgdChildLoosePAck");
                            Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
                            if (rgdChildLoosePAck != null)
                            {
                                // sLooseCount = sLooseCount - 1;

                                DataTable dtChild = new DataTable();
                                dtChild.Columns.AddRange(new DataColumn[3] { 
                    new DataColumn("childID", typeof(int)),
                    new DataColumn("Level", typeof(string)),
                    new DataColumn("LevelID",typeof(string)) 
                   });

                                string[] loose = lblFormatLoose.Text.Split('|');
                                //int level = Convert.ToInt32(hdnLevel.Value);
                                for (int l = 1; l < loose.Count(); l++)
                                {
                                    if (l == 1)
                                        dtChild.Rows.Add(l, "Main Packet(s)", (l).ToString());
                                    else if (l == loose.Count())
                                        dtChild.Rows.Add(l, "Pieces/Qty ", (l).ToString());
                                    else
                                        dtChild.Rows.Add(l, "Level " + (l).ToString(), (l).ToString());
                                }
                                rgdChildLoosePAck.DataSource = dtChild;
                                rgdChildLoosePAck.DataBind();

                                if (cbx.Checked)
                                { rgdChildLoosePAck.Visible = true; }
                                else
                                { rgdChildLoosePAck.Visible = false; }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    

        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if(btn.CommandArgument!=null)
                {
                    int Id = int.Parse(btn.CommandArgument);
                    _DeleteVehicle(Id);
                    bindIssueorderforIssueVoucher(catID);
                    
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void _DeleteVehicle(int Id)
        {
            try
            {
                if (con.State.ToString() == "Closed")
                    con.Open();
            SqlCommand cmd = new SqlCommand("usp_DeleteIssuedVehicle", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Case", Case); 
           
            cmd.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

      

        protected void btnDelVehicle_Click(object sender, EventArgs e)
        {
            try
            {
               
                Button btn = (Button)sender;
                string[] toolTip = btn.ToolTip.ToString().Split(',');
                foreach (GridDataItem pitem in rgdIssueVoucher.MasterTableView.Items)
                {
                    int productID = int.Parse(pitem.GetDataKeyValue("productID").ToString());
                    RadGrid rgdIssueBatch = (RadGrid)pitem.FindControl("rgdIssueBatch");
                    foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                    {
                        if (item.GetDataKeyValue("BatchName").ToString() == toolTip[0] && productID == int.Parse(toolTip[1]))
                        {

                            RadGrid rgdVehicle = (RadGrid)item.FindControl("rgdVehicle");
                            foreach (GridDataItem v in rgdVehicle.MasterTableView.Items)
                            {
                                Label lbl = (Label)v.FindControl("lblVehicleNo");
                            
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }

        }
        static string _ddlVehicleText = "";
        protected void ddlVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            //hddVechileNumber.Text = ddl.SelectedItem.Text;
            _ddlVehicleText = ddl.SelectedItem.Text;
        }
    }
}