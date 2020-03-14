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

namespace RHPDNew.StockOutPanel
{
    public partial class frmIssueBatch : System.Web.UI.Page
    {
        int productID = 0;
        int issueOrderId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DOG"] != null)
                {

                    productID = Convert.ToInt32(Request.QueryString["pID"]);
                    issueOrderId = Convert.ToInt32(Request.QueryString["isID"]);

                    GetBatchDetail(productID, issueOrderId);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Kindly mention Date of Generation first !')", true);
                   
                   // Response.Redirect("../StockOutPanel/frmIssueVoucher.aspx?Category_Id=" + Session["CatID"] + "&IssueOrderId=" + issueOrderId);
                }
            }
        }

        protected DataTable getVehicle(string BatchNo,int CatID,int IssueID)
        {

            try
            {
                IssueID = Convert.ToInt32(Request.QueryString["isID"]);
                    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("spSelectTranfer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "GetVehiclebyBatch");
                    cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                    cmd.Parameters.AddWithValue("@CatID", CatID);
                    cmd.Parameters.AddWithValue("@IssuOrderID", IssueID);
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
      protected  DataTable ProcessIT()
        {
            try
            {
                DataTable dtV = new DataTable();
                if (hdnBID.Value != "")
                {
                    int id = int.Parse(hdnBID.Value);
                    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("spSelectTranfer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "GetIDT");
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("spSelectTranfer", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@Action", "GetIDTQtyByIssueOrderID");
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
        public   void GetBatchDetail(int ProductId, int issueorderID)
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
                  System.Text.StringBuilder str=new System.Text.StringBuilder();
                  if (dt.Rows.Count > 0)
                  { str.Append(" <table> <tr> <th>Sr No</th> <th>Batch No</th><th>Product Name</th><th>Issue Qty</th><th></th> </tr></table>"); }
                  for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      str.Append("<tr><td>"+i+1+"</td>");
                      str.Append("<td>" + dt.Rows[i]["BatchName"].ToString() + "</td>");
                      str.Append(" <td>" + dt.Rows[i]["ProductName"].ToString() + "</td>");
                      str.Append(" <td>" + dt.Rows[i]["issueqty"].ToString() + "</td>");
                      str.Append("<td>   <a href=\"#\" onClick=\"pop('popDiv','" + dt.Rows[i]["id"].ToString() + "')\">Add Vehicle</a>  </td></tr>");
                  }
                  if (str.ToString() == "")
                  { str.Append("No batch found to add Vehicle !"); }
                  //ltrBacthList.Text = str.ToString();
                  rgdIssueBatch.DataSource = dt;
                  rgdIssueBatch.DataBind();
                }
            }
            
        }


     

        protected void rgdIssueBatch_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "get")
                {
                    GridDataItem item = (GridDataItem)e.Item;
                          ImageButton add = (ImageButton)item.FindControl("btnAdd");
                    add.Visible = false;
                    Panel pnl = (Panel)item.FindControl("pnlVehicle");
                    pnl.Visible = true;
                    hdnBID.Value = e.CommandArgument.ToString();
                    Label lblPack = (Label)item.FindControl("lblPack");

                      Label lblFormatFull = (Label)item.FindControl("lblFormatFull");


                      Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");


                      Label lblTotalQty = (Label)item.FindControl("lblTotalQty");

                      RadGrid rgdVehicle = (RadGrid)item.FindControl("rgdVehicle");
                      Label lblBatchNo = (Label)item.FindControl("lblBatchNo");

                      rgdVehicle.DataSource = getVehicle(lblBatchNo.Text, int.Parse(Session["CatID"].ToString()), issueOrderId);
                      rgdVehicle.DataBind();
                         
                 

                    DataTable dtV = new DataTable();
                    dtV=ProcessIT();
                    if (dtV.Rows.Count == 2)
                    {
                        string[] frm;
                        string pFrm = "";
                        System.Text.StringBuilder str = new System.Text.StringBuilder();
                        if (dtV.Rows[0]["PackingType"].ToString() == "Full")
                        {
                            frm = dtV.Rows[0]["Format"].ToString().Split('X');
                            for (int i = 1; i < frm.Count(); i++)
                            {
                                pFrm = pFrm + "X" + frm[i].ToString();
 
                            }
                            lblFormatFull.Text = dtV.Rows[0]["Format"].ToString();
                            lblFormatLoose.Text = dtV.Rows[1]["Format"].ToString();
                            lblTotalQty.Text = (double.Parse(dtV.Rows[0]["Quantity"].ToString()) + double.Parse(dtV.Rows[1]["Quantity"].ToString())).ToString();
                                        lblPack.Text = pFrm;
                        }
                        else
                        {
                            frm = dtV.Rows[1]["Format"].ToString().Split('X');
                            for (int i = 1; i < frm.Count(); i++)
                            {
                                pFrm = pFrm + "X" + frm[i].ToString();

                            }
                            lblFormatFull.Text = dtV.Rows[1]["Format"].ToString();
                            lblFormatLoose.Text = dtV.Rows[0]["Format"].ToString();
                            lblTotalQty.Text = (double.Parse(dtV.Rows[0]["Quantity"].ToString()) + double.Parse(dtV.Rows[1]["Quantity"].ToString())).ToString();
                        
                                   lblPack.Text = pFrm;
                        }
                        if (lblTotalQty.Text == "0")
                        {
                            lblFormatFull.Text = "";
                            lblFormatLoose.Text = "";
                        
                        }
                        if(lblFormatLoose.Text!="")
                        { 
                        RadGrid rgdChild = (RadGrid)item.FindControl("rgdChildLoosePAck");
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
                        else {
                            rgdChild.Visible = false;
                            CheckBox cbxLoose = (CheckBox)item.FindControl("cbxLoose");
                            cbxLoose.Enabled = false;
                            
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

        public string getIssuevoucherNumber()
        {
            string str = "";
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);

            using (SqlCommand cmd = new SqlCommand("usp_getissuevoucherNumber", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
               
                    
                cmd.Parameters.AddWithValue("@issueorderid", Convert.ToInt32(Request.QueryString["isID"]));
                cmd.Parameters.AddWithValue("@CatId", int.Parse(Session["CatID"].ToString()));

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        str = dr["IssusevoucherName"].ToString();


                    }
                    else
                    {

                    }
                }
                con.Close();
                return str;
              
            }
        }
     
        protected void btnAddVehicle_Click(object sender, EventArgs e)
        {
            try

            {
                Button btn = (Button)sender;
                foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                {
                    if (item.GetDataKeyValue("id").ToString() == btn.CommandArgument.ToString())
                    {


                        Label lblBatchNo = (Label)item.FindControl("lblBatchNo");
                     
                        TextBox vehicleNo = (TextBox)item.FindControl("txtVehicleNo");
                        RadNumericTextBox txtQty = (RadNumericTextBox)item.FindControl("txtQty");
                        RadNumericTextBox txtPack = (RadNumericTextBox)item.FindControl("txtPack");
                        CheckBox cbxLoose = (CheckBox)item.FindControl("cbxLoose");
                          Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
                          Label lblFormatFull = (Label)item.FindControl("lblFormatFull");
                          Label lblTotalQty = (Label)item.FindControl("lblTotalQty");

                          string FullFormat = "";
                          string LooseFormat = "";
                          string[] full = lblFormatFull.Text.Split('X');
                          string[] loose = lblFormatLoose.Text.Split('|');
                          FullFormat = txtPack.Text;
                        for(int f=1;f<full.Count();f++)
                        {
                            FullFormat = FullFormat+"X" + full[f];
                        }
                        int stockQty = int.Parse(txtQty.Text);
                        if (cbxLoose.Checked)
                        {
                            lblFormatLoose.Text = "";
                        stockQty=(stockQty+int.Parse(loose[loose.Count()-1].ToString()));
                        cbxLoose.Enabled = false;
                        cbxLoose.Checked = false;
                        }
                        RadGrid rgdChild = (RadGrid)item.FindControl("rgdChildLoosePAck");
                                     
                        foreach (GridDataItem gitem in rgdChild.MasterTableView.Items)
                        {
                            int levelID = Convert.ToInt32(gitem.GetDataKeyValue("childID").ToString());
                            RadNumericTextBox txtLevel = (RadNumericTextBox)gitem.FindControl("txtLevel");
                            LooseFormat = LooseFormat + txtLevel.Text + "|";

                        }
                        LooseFormat = LooseFormat + loose[loose.Count() - 1];
                        productID = Convert.ToInt32(Request.QueryString["pID"]);
                        issueOrderId = Convert.ToInt32(Request.QueryString["isID"]);
                       
                        if (Session["CatID"] != null)
                        {
                           
                                string VoucherId = getIssuevoucherNumber();
                                string dog = Session["DOG"].ToString();
                                string authorty = "";
                                int catId = int.Parse(Session["CatID"].ToString());
                                string bthcNo = lblBatchNo.Text;
                                int r = 0;
                                HiddenField hdnVehicleID = (HiddenField)item.FindControl("hdnVehicleID");
                                string msg = "";
                                if (hdnVehicleID.Value != "")
                                {
                                    r = UpdateIssueVoucher(LooseFormat, FullFormat, lblBatchNo.Text, vehicleNo.Text, stockQty, VoucherId, issueOrderId, int.Parse(hdnVehicleID.Value));
                                    msg = "Vehicle updated successfully";
                                }
                                else
                                {
                                    r = insertIssueVoucher(double.Parse(txtQty.Text),lblFormatFull.Text, lblFormatLoose.Text, LooseFormat, FullFormat, lblBatchNo.Text, vehicleNo.Text, "10", stockQty, VoucherId, dog, "", productID, authorty, catId, issueOrderId, bthcNo);
                                     msg = "Vehicle added successfully";
                          
                                } 
                            if (r == 1)
                                {
                                       //   _UpdateDetail(int.Parse(btn.CommandArgument));
                                     string[] Full = lblFormatFull.Text.Split('X');
                                    lblFormatFull.Text = (double.Parse(Full[0])-double.Parse(txtPack.Text)).ToString();
                                    double packValue = 1;
                                    for (int i = 1; i < Full.Count(); i++)
                                    {
                                        lblFormatFull.Text = lblFormatFull.Text + "X" + Full[i];
                                        packValue = packValue * (double.Parse(Full[i]));
                                    }
                                    lblTotalQty.Text = (int.Parse(lblTotalQty.Text) - stockQty).ToString();
                                    if (cbxLoose.Checked)
                                    lblFormatLoose.Text = "N/A";
                                    vehicleNo.Text = "";
                                    txtQty.Text = "";
                                    txtPack.Text = "";
                                    cbxLoose.Checked = false;
                                    RadGrid rgdVehicle = (RadGrid)item.FindControl("rgdVehicle");
                                    rgdVehicle.DataSource = getVehicle(lblBatchNo.Text, catId, issueOrderId);
                                    rgdVehicle.DataBind();
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+msg+" !')", true);

                                    return;
                                }
                           
                        }
                        else return;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }

      
        public DataTable gettbl_IssueOrder(int cat_ID)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);

            DataTable dt = new DataTable();
           

                SqlCommand cmd = new SqlCommand("usp_getdeatilIssuevoucher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@catid", cat_ID);
                cmd.Parameters.AddWithValue("@issueorderid", Convert.ToInt32(Request.QueryString["isID"]));
                SqlDataAdapter da = new SqlDataAdapter(cmd);              
                da.Fill(dt);

              
                con.Close();
            return dt;
           

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            productID = Convert.ToInt32(Request.QueryString["pID"]);
            issueOrderId = Convert.ToInt32(Request.QueryString["isID"]);           
            GetBatchDetail(productID, issueOrderId);
        }
        [WebMethod(EnableSession = true)]
        public int insertIssueVoucher(double FullQty,string LeftFormatFull, string LeftFormatLoose,string FormatLoose ,string FormatFull,string BatchNo,string VehicleNo, string PMQuantity, int StockQuantity, string IssueVoucherId, string dateofgenration, string Through, int ProductId, string Authority, int Cat_Id, int issueorderID, string batchno)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_IssueVoucherVehicleDetail_AddUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    cmd.Parameters.AddWithValue("@dateofgenration", dateofgenration);
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

        public int UpdateIssueVoucher(string FormatLoose, string FormatFull, string BatchNo, string VehicleNo, int StockQuantity, string IssueVoucherId, int Id, int issueorderID)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("spIssueVoucherVehicleUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BatchNo", BatchNo.Trim());
                    cmd.Parameters.AddWithValue("@FormatFull", FormatFull);
                    cmd.Parameters.AddWithValue("@FormatLoose ", FormatLoose);
                  
                    cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo.Trim());
                    
                    cmd.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                    cmd.Parameters.AddWithValue("@IssueVoucherId", IssueVoucherId.Trim());
                    
                    cmd.Parameters.AddWithValue("@issueorderid", issueorderID);
                    cmd.Parameters.AddWithValue("@Id", Id);
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

        [WebMethod(EnableSession = true)]
        public static Vechileautocompete[] GetVechileAutocompete(string mail)
        {
            DataTable dt = new DataTable();
            List<Vechileautocompete> details = new List<Vechileautocompete>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_getvechileAutocompete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();


                    cmd.Parameters.AddWithValue("@SearchText", mail);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        Vechileautocompete vecdetail_ = new Vechileautocompete();
                        vecdetail_.VechileNumber = dtrow["VechileNumber"].ToString();

                        details.Add(vecdetail_);
                    }
                }
            }
            return details.ToArray();
        }
        public class Vechileautocompete
        {
            public string VechileNumber { get; set; }




        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadNumericTextBox box = (RadNumericTextBox)sender;
                int id = int.Parse(box.ToolTip);
                foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                {
                    if (item.GetDataKeyValue("id").ToString() == box.ToolTip)
                    {

                        Label lblissueqty = (Label)item.FindControl("lblissueqty");
                        if (double.Parse(lblissueqty.Text) < double.Parse(box.Text))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Stock Qty can not be greater than Total Issue Qty !')", true);
                            box.Focus();
                            return;
                        
                        }
                   
                        RadNumericTextBox txtPack = (RadNumericTextBox)item.FindControl("txtPack");
                        Label lblFormatFull = (Label)item.FindControl("lblFormatFull");
                        Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
                        Label lblTotalQty = (Label)item.FindControl("lblTotalQty");
                        string[] Full = lblFormatFull.Text.Split('X');
                        double qty = double.Parse(box.Text);
                        double packValue=1;
                        for(int i=1;i<Full.Count();i++)
                        {
                        packValue=packValue*(double.Parse(Full[i]));
                        }
                        box.Text = (double.Parse(box.Text) - (double.Parse(box.Text) % packValue)).ToString();
                        qty =(qty / packValue) ;
                        string[] val = qty.ToString().Split('.');
                        txtPack.Text = val[0];
                       

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
                int id = int.Parse(box.ToolTip);
                foreach (GridDataItem item in rgdIssueBatch.MasterTableView.Items)
                {
                    if (item.GetDataKeyValue("id").ToString() == box.ToolTip)
                    {
                        RadNumericTextBox txtQty = (RadNumericTextBox)item.FindControl("txtQty");
                        Label lblFormatFull = (Label)item.FindControl("lblFormatFull");
                        Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
                        Label lblTotalQty = (Label)item.FindControl("lblTotalQty");
                        string[] Full = lblFormatFull.Text.Split('X');
                        double qty = double.Parse(box.Text);
                        double packValue = 1;
                        for (int i = 1; i < Full.Count(); i++)
                        {
                            packValue = packValue * (double.Parse(Full[i]));
                        }
                        qty = qty * packValue;
                        txtQty.Text = qty.ToString();


                    }

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void rgdVehicle_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    Label lblVehicleNo = (Label)item.FindControl("lblVehicleNo");
                    Label lblStockQuantity = (Label)item.FindControl("lblStockQuantity");
                    string batchNo = e.CommandArgument.ToString();
                    foreach (GridDataItem pitem in rgdIssueBatch.MasterTableView.Items)
                    {
                        Label lblBatchNo = (Label)pitem.FindControl("lblBatchNo");
                        if (batchNo == lblBatchNo.Text)
                        {
                            TextBox vehicleNo = (TextBox)pitem.FindControl("txtVehicleNo");
                            RadNumericTextBox txtQty = (RadNumericTextBox)pitem.FindControl("txtQty");
                            RadNumericTextBox txtPack = (RadNumericTextBox)pitem.FindControl("txtPack");
                            HiddenField hdnVehicleID = (HiddenField)pitem.FindControl("hdnVehicleID");
                            hdnVehicleID.Value = item.GetDataKeyValue("Id").ToString();
                            vehicleNo.Text = lblVehicleNo.Text;
                            txtQty.Text = lblStockQuantity.Text;
                            txtQty_TextChanged(txtQty,e);
                        }

                    }

                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void rgdIssueBatch_ItemCreated(object sender, GridItemEventArgs e)
        {
           // if (sLooseCount > 0)
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (e.Item as GridDataItem);
                    RadGrid rgdChild = (RadGrid)item.FindControl("rgdChildLoosePAck");
                    if (rgdChild != null)
                    {
                       // sLooseCount = sLooseCount - 1;

                        DataTable dtChild = new DataTable();
                        dtChild.Columns.AddRange(new DataColumn[3] { 
                    new DataColumn("childID", typeof(int)),
                    new DataColumn("Level", typeof(string)),
                    new DataColumn("LevelID",typeof(string)) 
                   });
                        Label lblFormatLoose = (Label)item.FindControl("lblFormatLoose");
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

            }
        }

    }
}