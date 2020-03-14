using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI.HtmlControls;

namespace RHPDNew.StockOutPanel
{
    public partial class frmMonitoringStock : System.Web.UI.Page
    {
        int attributetype_ = 0;
        int yearvaluue_ = 0;
        #region Global Variables
        string userId = "123456";
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        { if (Session["UserDetails"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        if (Session["attribute"] != null)
                        {
                            attributetype_ = Convert.ToInt32(Session["attribute"]);
                            yearvaluue_ = Convert.ToInt32(Session["yearvaluue"]);
                            LoadInitialData(attributetype_);
                            if (yearvaluue_ != 0 && attributetype_ != 0)
                            {
                                MyUserInfoBoxControl.setdropdown(attributetype_, yearvaluue_);
                            }

                        }
                    }
            }
        }
        public void LoadInitialData_(int _attributetype, int yearvaluue)
        {
            attributetype_ = _attributetype;
            yearvaluue_ = yearvaluue;
            Session["attribute"] = attributetype_;
            Session["yearvaluue"] = yearvaluue_;
            Response.Redirect("frmMonitoringStock.aspx");

        }
        public void LoadInitialData(int _attributetype)
        {
            int quaterid = 0;
            GetQuarterList();
            GetProductList();
            BindMain(quaterid);
         //   Response.Redirect("frmMonitoringStock.aspx");
        }
        #endregion

        #region StockOut Main

        #region Get Quarters
        public void GetQuarterList()
        {
            rdoBtnLstQuarters.DataSource = GetQuarterListData();
            rdoBtnLstQuarters.DataTextField = "QuarterName";
            rdoBtnLstQuarters.DataValueField = "QuarterId";
            rdoBtnLstQuarters.DataBind();
            if (!String.IsNullOrEmpty(Convert.ToString(Session["sessQuarterId"])))
            {
                rdoBtnLstQuarters.SelectedValue = Session["sessQuarterId"].ToString();
            }
            else
            {
                rdoBtnLstQuarters.SelectedIndex = 0;
            }
            string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));

            if (typeName == "IDT")
            {
                rdoBtnLstQuarters.Visible = true;
            }
            else if (typeName == "Full Year")
            {
                rdoBtnLstQuarters.Visible = false;
            }
            else
            {
                rdoBtnLstQuarters.Visible = false;
            }

        }

        public DataTable GetQuarterListData()
        {
            DataTable dtQuarterList = new DataTable();
            AddProductComp objaddpro = new AddProductComp();
            dtQuarterList = objaddpro.getQuarters(Convert.ToInt32(Session["yearvaluue"]));
            return dtQuarterList;
        }

        protected void rdoBtnLstQuarters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoBtnLstQuarters.SelectedIndex != 0)
            {
                Session["sessQuarterId"] = rdoBtnLstQuarters.SelectedValue.ToString();
            }
            else
            {
                Session["sessQuarterId"] = null;
            }
            Response.Redirect("../StockOutPanel/frmMonitoringStock.aspx");
        }

        #endregion

        #region Get Products
        public void GetProductList()
        {
            ddlProduct.DataSource = GetProductListData();
            ddlProduct.DataTextField = "Product_Name";
            ddlProduct.DataValueField = "Product_ID";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("--Add New Product--", ""));
        }


        public DataTable GetProductListData()
        {
            DataTable dtProductList = new DataTable();
            AddProductComp objaddpro = new AddProductComp();
            int Qid_ = 0;
            string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));
            string IDTIs = "";
            string IDTUpdate = "";

            if (typeName == "IDT")
            {
                Qid_ = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue);
            }
            else if (typeName == "Full Year")
            {
                Qid_ = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue);
            }
            else
            {
                Qid_ = 0;
            }
            dtProductList = objaddpro.getProducts(Qid_, Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]));
            return dtProductList;
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedIndex != 0)
            {
                AddProductComp objaddpro = new AddProductComp();
                string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));
                if (typeName == "IDT")
                {
                    int retValue = objaddpro.StockOutMain_Product_Add(Convert.ToInt32(rdoBtnLstQuarters.SelectedValue), Convert.ToInt32(ddlProduct.SelectedValue), Convert.ToInt32(userId), Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]));
                }
                else if (typeName == "Full Year")
                {
                    int retValue = objaddpro.StockOutMain_Product_Add(Convert.ToInt32(rdoBtnLstQuarters.SelectedValue), Convert.ToInt32(ddlProduct.SelectedValue), Convert.ToInt32(userId), Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]));
                }
                else
                {
                    int retValue = objaddpro.StockOutMain_Product_Add(0, Convert.ToInt32(ddlProduct.SelectedValue), Convert.ToInt32(userId), Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]));
                }
                LoadInitialData(attributetype_);
                Response.Redirect("frmMonitoringStock.aspx");
            }
        }
        #endregion

        #region Bind Main Grid & Add New Depot
        public void BindMain(int Qid)
        {
            string quarterId = "";
            try
            {
                string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));
                string IDTIs = "";
                string IDTUpdate = "";

                if (typeName == "IDT")
                {
                    quarterId = rdoBtnLstQuarters.SelectedValue.ToString();
                }
                else if (typeName == "Full Year")
                {
                    quarterId = rdoBtnLstQuarters.SelectedValue.ToString();
                }
                else
                {
                    quarterId = "0";
                }
                string depotid = "";
                string productid = "";
                DataTable dt = new DataTable();
                AddProductComp objaddpro = new AddProductComp();
                dt = objaddpro.getStockOutMain(Convert.ToInt32(quarterId), Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]));
                int countColumns = dt.Columns.Count;
                int countRows = dt.Rows.Count;
                if (countRows > 0)
                {

                    rowlnkBtnAutoAdd.Visible = false;
                    HtmlTableRow tHeaderRow = new HtmlTableRow();
                    

                    for (int colHeader = 0; colHeader < countColumns; colHeader++)
                    {
                        HtmlTableCell tcolHeader = new HtmlTableCell();
                        string[] arrHeader = dt.Columns[colHeader].ToString().Split('_');
                        if (arrHeader.Count() > 1)
                        {
                            if (arrHeader[1] != "")
                            {
                                if (arrHeader[1] != "0")
                                {
                                    int value;
                                    if (int.TryParse(arrHeader[1], out value))
                                    {
                                        Panel ddPanel = new Panel();
                                        DropDownList dDepot = new DropDownList();
                                        dDepot = GenerateDepots(arrHeader[1].ToString());
                                        ddPanel.Controls.Add(dDepot);
                                        tcolHeader.Controls.Add(ddPanel);
                                        tcolHeader.Controls.Add(IDTOrder((dDepot.SelectedValue)));
                                    }
                                }
                                else
                                {
                                    Panel ddPanel = new Panel();
                                    DropDownList dDepot = new DropDownList();
                                    dDepot = GenerateDepots(arrHeader[1].ToString());
                                    ddPanel.Controls.Add(dDepot);
                                    tcolHeader.Controls.Add(ddPanel);
                                    tcolHeader.Controls.Add(IDTOrder((depotid)));
                                }
                            }
                        }
                        else
                        {
                            if (dt.Columns[colHeader].ToString() == "Id")
                                tcolHeader.InnerText = "S No";
                            else
                                tcolHeader.InnerText = dt.Columns[colHeader].ToString();
                        }
                        tcolHeader.Attributes.Add("class", "headerRow");
                        tHeaderRow.Controls.Add(tcolHeader);

                        //tHeaderRow.Style.Add("class", "headerRow");
                    }
                    tblMain.Rows.Add(tHeaderRow);

                    HtmlTableRow tRow;
                    for (int row = 0; row < countRows; row++)
                    {
                        tRow = new HtmlTableRow();
                        HtmlTableCell newCell = new HtmlTableCell();
                        Button btnRemoveProduct = new Button();
                        btnRemoveProduct.Attributes.Add("onclick", "return btnRemoveProduct_Clicked();");
                        newCell.Controls.Add(btnRemoveProduct);
                        for (int col = 0; col < countColumns; col++)
                        {
                            HtmlTableCell tcol = new HtmlTableCell();
                            string[] arrHeader = dt.Columns[col].ToString().Split('_');
                            if (arrHeader.Count() > 1)
                            {
                                if (arrHeader[1] != "")
                                {
                                    if (arrHeader[1] != "0")
                                    {
                                        int value;
                                        if (int.TryParse(arrHeader[1], out value))
                                        {
                                            IDTIs = dt.Rows[row][col].ToString();
                                            depotid = arrHeader[1].ToString();
                                            productid = dt.Rows[row]["productid"].ToString();
                                            IDTUpdate = "false";
                                            tcol.Controls.Add(IDTBlock(IDTIs, quarterId, depotid, productid, userId, IDTUpdate));                                            
                                        }
                                    }
                                    else
                                    {
                                        //DO NOT ADD ANY CONTROL UNLESS DEPOT IS NOT SELECTED..
                                    }
                                }
                            }
                            else
                            {
                                //if (col == 0)
                                //    tcol.InnerText = (row + 1).ToString();
                                //else
                                tcol.InnerText = dt.Rows[row][col].ToString();
                            }
                            tRow.Controls.Add(tcol);
                            btnRemoveProduct.ID = "btnRemoveProduct" + productid;

                            btnRemoveProduct.CommandArgument = productid;
                            btnRemoveProduct.Text = "Remove";
                            tRow.Controls.Add(newCell);
                        }
                        tblMain.Rows.Add(tRow);
                    }
                    ShowHideData(true);
                }
                else
                {
                    rowlnkBtnAutoAdd.Visible = true;
                    ShowHideData(false);
                }
                GenerateDepotsNew(0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ShowHideData(bool HasData)
        {
            try
            {
                if (HasData)
                {
                    tdMainData.Visible = true;
                    lblMsg.Text = "";
                    trlblMsg.Visible = false;
                }
                else
                {
                    tdMainData.Visible = false;
                    lblMsg.Text = "No Data Exists.";
                    lblMsg.CssClass = "msg";
                    trlblMsg.Visible = true;
                    tdNewDepotSection.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void RemoveProduct(string Id)
        {
            int a = 0;
            int b = 1;
            int c = a + b;
        }

        public DropDownList GenerateDepots(string depotId)
        {
            try
            {
                int quarterId = 0;
                string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));

                if (typeName == "IDT")
                {
                    quarterId = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue);
                }
                else if (typeName == "Full Year")
                {
                    quarterId = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue);
                }
                else
                {
                    quarterId = 0;
                }

                bool isParent = true;
                DataTable dtDepot = new DataTable();
                AddProductComp objaddpro = new AddProductComp();
                if (typeName == "Full Year")
                    dtDepot = objaddpro.getStockOutDepots(quarterId, Convert.ToInt32(depotId), isParent, false, Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]), "");
          
                    else
                dtDepot = objaddpro.getStockOutDepots(quarterId, Convert.ToInt32(depotId), isParent, false, Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]), typeName);
                bool isExists = false;
                DropDownList dDepot = new DropDownList();
                if (dtDepot.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDepot.Rows.Count; i++)
                    {
                        if (isExists != true)
                        {
                            if (dtDepot.Rows[i][0].ToString() == depotId)
                            {
                                isExists = true;
                            }
                        }
                    }
                    dDepot.ID = "ddlDepot_" + depotId;
                    dDepot.DataSource = dtDepot;
                    dDepot.DataTextField = "Depu_Name";
                    dDepot.DataValueField = "Depu_Id";
                    dDepot.DataBind();
                    dDepot.Items.Insert(0, new ListItem("--Select Depot--", "0"));
                    dDepot.SelectedValue = "0";
                    if (isExists)
                    {
                        dDepot.SelectedValue = depotId;
                        dDepot.Enabled = false;
                    }
                    else
                    {
                        dDepot.SelectedValue = "0";
                        dDepot.Enabled = true;
                        dDepot.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        dDepot.Attributes.Add("onchange", "UpdateDepotForProduct(" + "ddlDepot_" + depotId + ");");
                        dDepot.Attributes.Add("UserId", "" + userId + "");
                        tdNewDepotSection.Visible = false;
                    }
                }
                return dDepot;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GenerateDepotsNew(int depotId)
        {
            try
            {
                int quarterId = 0;
                string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));

                if (typeName == "IDT")
                {
                    quarterId = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue);
                }
                else if (typeName == "Full Year")
                {
                    quarterId = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue);
                }
                else
                {
                    quarterId = 0;
                }
                bool isParent = true;
                DataTable dtDepot = new DataTable();
                AddProductComp objaddpro = new AddProductComp();
                if (typeName == "Full Year")
                    dtDepot = objaddpro.getStockOutDepots(quarterId, Convert.ToInt32(depotId), isParent, false, Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]), "");

                else
                    dtDepot = objaddpro.getStockOutDepots(quarterId, Convert.ToInt32(depotId), isParent, false, Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]), typeName);
           
               // dtDepot = objaddpro.getStockOutDepots(quarterId, depotId, isParent, true, Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]), typeName);
                if (dtDepot.Rows.Count > 0)
                {
                    dDepotNew.DataSource = null;
                    dDepotNew.DataSource = dtDepot;
                    dDepotNew.DataTextField = "Depu_Name";
                    dDepotNew.DataValueField = "Depu_Id";
                    dDepotNew.DataBind();
                    dDepotNew.AutoPostBack = true;
                    dDepotNew.Items.Insert(0, new ListItem("--Add New Depot--", ""));
                }
                else
                {
                    tdNewDepotSection.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void dDepotNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int quarterId = 0;
                string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));
                if (typeName == "IDT")
                {
                    quarterId = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue.ToString());
                }
                else if (typeName == "Full Year")
                {
                    quarterId = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue.ToString());
                }
                else
                {
                    quarterId = 0;
                }
                DropDownList dDepot = (DropDownList)sender;
                if (Convert.ToInt32(dDepot.SelectedValue.ToString()) != 0)
                {
                    //quarterId = Convert.ToInt32(rdoBtnLstQuarters.SelectedValue.ToString());
                    int productId = 0;
                    decimal totalIDT = 0;
                    bool IDTUpdate = false;
                    int retrunVal = InsertDepotStockOutMain(quarterId, productId, Convert.ToInt32(dDepot.SelectedValue.ToString()), Convert.ToInt32(userId), totalIDT, IDTUpdate);
                    if (retrunVal > 0)
                    {
                        Response.Redirect("../StockOutPanel/frmMonitoringStock.aspx");

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertDepotStockOutMain(int quarterId, int productId, int depotId, int userId, decimal totalIDT, bool IDTUpdate)
        {
            try
            {
                int retrunVal = 0;
                AddProductComp objaddpro = new AddProductComp();
                retrunVal = objaddpro.addUpdateStockOutMain(quarterId, productId, depotId, userId, totalIDT, IDTUpdate, Convert.ToInt32(Session["attribute"]), Convert.ToInt32(Session["yearvaluue"]));
                return retrunVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public static ProductDetail[] BindBatchproductDetail(string Product_Name)
        {
            DataTable dt = new DataTable();
            List<ProductDetail> details = new List<ProductDetail>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("select (select SUM(sm.Quantity) from StockMaster sm where sm.productID=Product_ID) as Qty,* from  ProductMaster where isActive=1 and Product_Name='" + Product_Name + "'", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        ProductDetail Productdetail_ = new ProductDetail();
                        Productdetail_.Product_Name = dtrow["Product_Name"].ToString();
                        if (dtrow["Qty"].ToString() != "")
                            Productdetail_.StockQty = Convert.ToInt32(dtrow["Qty"]);
                        else
                            Productdetail_.StockQty = 0;
                        Productdetail_.productUnit = dtrow["productUnit"].ToString();
                        Productdetail_.GSreservre = Convert.ToInt32(dtrow["GSreservre"]);
                        details.Add(Productdetail_);
                    }
                }
            }
            return details.ToArray();
        }
        public class ProductDetail
        {
            public string Product_Name { get; set; }
            public int StockQty { get; set; }
            public string productUnit { get; set; }
            public int GSreservre { get; set; }


        }

        [WebMethod]
        public static int insertIDT(int Dipuprd_IDTqty, string Product_Name, string Dipu)
        {

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_InsertPrdIdt_QTY", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DipuIdtQty", Dipuprd_IDTqty);
                    cmd.Parameters.AddWithValue("@prdName", Product_Name);
                    cmd.Parameters.AddWithValue("@Dipuname", Dipu);
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

        #endregion

        #region Bind IDT Events
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public decimal getdremainingIDT(int prdid, int DepuID, int quarterId)
        {

            using (SqlCommand cmd = new SqlCommand("usp_getRemainingIDT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if( con.State.ToString()!="Open")
                con.Open();
                cmd.Parameters.AddWithValue("@productId", prdid);
                cmd.Parameters.AddWithValue("@depuID", DepuID);
                cmd.Parameters.AddWithValue("@quaterID", quarterId);
                cmd.Parameters.AddWithValue("@TypeId", Convert.ToInt32(Session["attribute"]));       

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return decimal.Parse(dr["RemaingIDT"].ToString());

                        con.Close();
                    }
                    else
                        return 0; con.Close();
                }
               
            }


        }

        public Panel IDTBlock(string IDTIs, string quarterId, string depotid, string productid, string userId, string IDTUpdate)
        {
            string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));
            if (IDTIs == "")
            {
                IDTIs = "0";
            }
            decimal IDT = Convert.ToDecimal(IDTIs);
            decimal RemIDT = getdremainingIDT(int.Parse(productid), int.Parse(depotid), int.Parse(quarterId));
            Boolean isIssued = true;
            if (RemIDT < 0)
                RemIDT = 0;
            if (RemIDT == IDT)
            {
                isIssued = false;
                IDT = RemIDT;
            }
            else if (RemIDT < IDT)
                IDT = IDT - RemIDT;
            else
                IDT = RemIDT - IDT;
            Panel pnlIDT = new Panel();
            try
            {
                if (IDT > 0)
                {
                    Label lblIDT = new Label();
                    if (isIssued)
                        lblIDT.Text = RemIDT.ToString() + "[Issued: " + IDT.ToString() + "]";
                    else
                        lblIDT.Text = RemIDT.ToString() + "[Issued: 0]";
                    lblIDT.CssClass = "currentIdt";
                    lblIDT.ToolTip = RemIDT.ToString() + "  is current IDT.";
                    pnlIDT.Controls.Add(lblIDT);
                    Button btnIssueIDTUpdate = new Button();
                    btnIssueIDTUpdate.ID = "btnIssueIDTUpdate_" + productid + "_" + depotid;
                    btnIssueIDTUpdate.CssClass = "clsbtnIssueIDTUpdate";

                    btnIssueIDTUpdate.Attributes.Add("QuarterId", quarterId);
                    btnIssueIDTUpdate.Attributes.Add("ProductId", productid);
                    btnIssueIDTUpdate.Attributes.Add("DepotId", depotid);
                    btnIssueIDTUpdate.Attributes.Add("UserId", userId);
                    btnIssueIDTUpdate.Attributes.Add("IDTUpdate", IDTUpdate);
                    if (RemIDT > 0){
                        btnIssueIDTUpdate.BackColor = System.Drawing.Color.Green; btnIssueIDTUpdate.Enabled=true;}
                    else if (RemIDT == 0)
                    { //btnIssueIDTUpdate.Enabled=false;
                        btnIssueIDTUpdate.BackColor = System.Drawing.Color.Red;}
                    if (typeName == "IDT")
                    {

                        btnIssueIDTUpdate.Text = "Issue IDT";
                        btnIssueIDTUpdate.ToolTip = "Click here to issue IDT";
                    }

                    else if (typeName == "ICT")
                    {
                        btnIssueIDTUpdate.Text = "Issue ICT";
                        btnIssueIDTUpdate.ToolTip = "Click here to issue ICT";
                    }
                    else if (typeName == "AWS")
                    {
                        btnIssueIDTUpdate.Text = "Issue AWS";
                        btnIssueIDTUpdate.ToolTip = "Click here to issue AWS";
                    }
                    else if (typeName == "Full Year")
                    {
                        btnIssueIDTUpdate.Text = "Full Year";
                        btnIssueIDTUpdate.ToolTip = "Click here to issue AWS";
                       // btnIssueIDTUpdate.Enabled = false;
                    }
                        
                    pnlIDT.Controls.Add(btnIssueIDTUpdate);


                    Button btnAddMoreIDT = new Button();
                    btnAddMoreIDT.ID = "btnAddMoreIDT_" + productid + "_" + depotid;
                    btnAddMoreIDT.CssClass = "clsBtnAddMore";
                    btnAddMoreIDT.Attributes.Add("QuarterId", quarterId);
                    btnAddMoreIDT.Attributes.Add("ProductId", productid);
                    btnAddMoreIDT.Attributes.Add("DepotId", depotid);
                    btnAddMoreIDT.Attributes.Add("UserId", userId);
                    btnAddMoreIDT.Attributes.Add("IDTUpdate", IDTUpdate);
                    if (RemIDT > 0)
                    {
                        btnAddMoreIDT.BackColor = System.Drawing.Color.Orange;
                        if (typeName == "IDT")
                        {
                            btnAddMoreIDT.Text = "Update IDT";
                            btnAddMoreIDT.ToolTip = "Click here add IDT";
                        }

                        else if (typeName == "ICT")
                        {
                            btnAddMoreIDT.Text = "Update ICT";
                            btnAddMoreIDT.ToolTip = "Click here add ICT";
                        }
                        else if (typeName == "AWS")
                        {
                            btnAddMoreIDT.Text = "Update AWS";
                            btnAddMoreIDT.ToolTip = "Click here add AWS";
                        }
                        else if (typeName == "Full Year")
                        {
                            btnAddMoreIDT.Text = "Full Year";
                            btnAddMoreIDT.ToolTip = "";
                           btnAddMoreIDT.Enabled = false;
                        }
                    }
                    else if (RemIDT == 0)
                    {
                        btnAddMoreIDT.BackColor = System.Drawing.Color.Yellow;
                        if (typeName == "IDT")
                        {
                            btnAddMoreIDT.Text = "Add IDT";
                            btnAddMoreIDT.ToolTip = "Click here add IDT";
                        }

                        else if (typeName == "ICT")
                        {
                            btnAddMoreIDT.Text = "Add ICT";
                            btnAddMoreIDT.ToolTip = "Click here add ICT";
                        }
                        else if (typeName == "AWS")
                        {
                            btnAddMoreIDT.Text = "Add AWS";
                            btnAddMoreIDT.ToolTip = "Click here add AWS";
                        }
                        else if (typeName == "Full Year")
                        {
                            btnAddMoreIDT.Text = "Full Year";
                            btnAddMoreIDT.ToolTip = "";
                            btnAddMoreIDT.Enabled = false;
                        }
                    }
                    else
                    {
                        if (typeName == "IDT")
                        {
                            btnAddMoreIDT.Text = "Add IDT";
                            btnAddMoreIDT.ToolTip = "Click here add IDT";
                        }

                        else if (typeName == "ICT")
                        {
                            btnAddMoreIDT.Text = "Add ICT";
                            btnAddMoreIDT.ToolTip = "Click here add ICT";
                        }
                        else if (typeName == "AWS")
                        {
                            btnAddMoreIDT.Text = "Add AWS";
                            btnAddMoreIDT.ToolTip = "Click here add AWS";
                        }
                        else if (typeName == "Full Year")
                        {
                            btnAddMoreIDT.Text = "Full Year";
                            btnAddMoreIDT.ToolTip = "";
                            btnAddMoreIDT.Enabled = false;
                        }


                    }


                    pnlIDT.Controls.Add(btnAddMoreIDT);


                    Button btnIdtStatus = new Button();
                    btnIdtStatus.ID = "btnIdtStatus_" + productid + "_" + depotid;
                    btnIdtStatus.CssClass = "clsbtnIssueStatus";

                    btnIdtStatus.Attributes.Add("QuarterId", quarterId);
                    btnIdtStatus.Attributes.Add("ProductId", productid);
                    btnIdtStatus.Attributes.Add("DepotId", depotid);
                    btnIdtStatus.Attributes.Add("UserId", userId);
                    btnIdtStatus.Visible = false;

                    if (typeName == "IDT")
                    {
                        btnIdtStatus.Text = "IDT Status";
                        btnIdtStatus.ToolTip = "Click here to see IDT Status";
                    }

                    else if (typeName == "ICT")
                    {
                        btnIdtStatus.Text = "ICT Status";
                        btnIdtStatus.ToolTip = "Click here to see ICT Status";
                    }
                    else if (typeName == "AWS")
                    {
                        btnIdtStatus.Text = "AWS Status";
                        btnIdtStatus.ToolTip = "Click here to see AWS Status";
                    }
                    else if (typeName == "Full Year")
                    {
                        btnIdtStatus.Text = "Full Year";
                        btnIdtStatus.ToolTip = "";
                        btnIdtStatus.Enabled = false;
                    }




                    pnlIDT.Controls.Add(btnIdtStatus);


                }
                else
                {
                    IDTUpdate = "false"; //Because need to add IDT.

                    TextBox txtIssueIDTNew = new TextBox();
                    txtIssueIDTNew.ID = "txtIssueIDTNew_" + productid + "_" + depotid;
                    txtIssueIDTNew.CssClass = "clstxtIssueIDTNew";
                    txtIssueIDTNew.Attributes.Add("productid", productid);
                    txtIssueIDTNew.Attributes.Add("depotid", depotid);
                    txtIssueIDTNew.ToolTip = IDT.ToString();
                    pnlIDT.Controls.Add(txtIssueIDTNew);


                    /*New IDT*/
                    Button btnIssueIDTNew = new Button();
                    btnIssueIDTNew.ID = "btnIssueIDTNew_" + productid + "_" + depotid;
                    btnIssueIDTNew.CssClass = "clsbtnIssueIDTNew";

                    btnIssueIDTNew.Attributes.Add("QuarterId", quarterId);
                    btnIssueIDTNew.Attributes.Add("ProductId", productid);
                    btnIssueIDTNew.Attributes.Add("DepotId", depotid);
                    btnIssueIDTNew.Attributes.Add("UserId", userId);
                    btnIssueIDTNew.Attributes.Add("IDTUpdate", IDTUpdate);

                    if (typeName == "IDT")
                    {
                        btnIssueIDTNew.Text = "Add IDT";
                        btnIssueIDTNew.ToolTip = "Add IDT";
                    }

                    else if (typeName == "ICT")
                    {
                        btnIssueIDTNew.Text = "Add ICT";
                        btnIssueIDTNew.ToolTip = "Add ICT";
                    }
                    else if (typeName == "AWS")
                    {
                        btnIssueIDTNew.Text = "Add AWS";
                        btnIssueIDTNew.ToolTip = "Add AWS";
                    }
                    else if (typeName == "Full Year")
                    {
                        btnIssueIDTNew.Text = "Full Year";
                        btnIssueIDTNew.ToolTip = "";
                        btnIssueIDTNew.Enabled = false;
                    }





                    pnlIDT.Controls.Add(btnIssueIDTNew);
                }
                return pnlIDT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Bind IDT Events
        public Button IDTOrder(string depotId)
        {
            string typeName = MyUserInfoBoxControl.GetAttributeName(Convert.ToInt32(Session["attribute"]));
            try
            {


                Button objBtnIDTOrder = new Button();
                objBtnIDTOrder.ID = "btnIDTOrder_" + depotId;
                objBtnIDTOrder.CssClass = "clsbtnOrderIDT";
                objBtnIDTOrder.Attributes.Add("DepotId", depotId.ToString());
                objBtnIDTOrder.Attributes.Add("UserId", userId.ToString());

                if (typeName == "IDT")
                {
                    objBtnIDTOrder.Text = "Order IDT";
                    objBtnIDTOrder.ToolTip = "Click here to Order IDT";
                }

                else if (typeName == "ICT")
                {
                    objBtnIDTOrder.Text = "Order ICT";
                    objBtnIDTOrder.ToolTip = "Click here to Order ICT";
                }
                else if (typeName == "AWS")
                {
                    objBtnIDTOrder.Text = "Order AWS";
                    objBtnIDTOrder.ToolTip = "Click here to Order AWS";
                }
                else if (typeName == "Full Year")
                {
                    objBtnIDTOrder.Text = "Full Year";
                    objBtnIDTOrder.ToolTip = "";
                    objBtnIDTOrder.Enabled = false;
                }


                return objBtnIDTOrder;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion


        protected void lnkBtnAutoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoBtnLstQuarters.SelectedValue != "" && userId != "")
                {
                    AddProductComp objaddpro = new AddProductComp();
                    int retrunVal = objaddpro.StockOutMain_QuarterData_AutoAdd(Convert.ToInt32(rdoBtnLstQuarters.SelectedValue), Convert.ToInt32(userId));

                    LoadInitialData(attributetype_);
                }
                else
                    lnkBtnAutoAdd.Text = "Select Quarters first!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        
        #region Extras
        //[WebMethod]
        //public static int testM(string id)
        //{
        //    return 1;
        //}

        //[WebMethod]
        //public static int StockOutMain_AddUpdate_New(string quarterId, string productId, string depotId, string userId, string totalIDT, string IDTUpdate)
        //{

        //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);

        //    {
        //        con.Open();
        //        using (SqlCommand cmd = new SqlCommand("usp_StockOutMain_AddUpdate_New", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@QuarterId", quarterId);
        //            cmd.Parameters.AddWithValue("@ProductId", productId);
        //            cmd.Parameters.AddWithValue("@DepotId", depotId);
        //            cmd.Parameters.AddWithValue("@UserId", userId);
        //            cmd.Parameters.AddWithValue("@IDT", totalIDT);
        //            cmd.Parameters.AddWithValue("@IDTUpdate", IDTUpdate);
        //            cmd.ExecuteNonQuery();
        //            int intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);
        //            con.Close();
        //            if (intResult == 1)
        //            {
        //                return 1;
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //        }
        //    }

        //}
        #endregion
    }
}