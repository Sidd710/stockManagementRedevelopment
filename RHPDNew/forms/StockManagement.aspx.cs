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

namespace RHPDNew.Forms
{
    public partial class StockManagement : System.Web.UI.Page
    {
        int catid; private const int ItemsPerRequest = 10;
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

                    ManagestockComp objpro = new ManagestockComp();
                    lblCode.Text = objpro.getCode();
                    DataTable DT = new DataTable();
                    DT = objpro.getrecorddepu();
                    if (DT.Rows.Count > 0)
                    {
                        lblDepuName.Text = Convert.ToString(objpro.getrecorddepu().Rows[0]["Depu_Name"].ToString());
                        lblDepuId.Text = Convert.ToString(objpro.getrecorddepu().Rows[0]["Depu_Id"]);
                    }
                    griddisplay();
                }
                //  cetxMfgDate.StartDate = DateTime.Now;
                cetxtExpirydate.StartDate = DateTime.Now;
            }
        }

        //protected void ddlselectpro_DataBound(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DropDownList list = sender as DropDownList;
        //        if (list != null)
        //            list.Items.Insert(0, "-- Select --");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (btnSubmit.Text == "Submit")
                    {
                        ManageStockEntity objproentity = new ManageStockEntity();
                        ManagestockComp objpro = new ManagestockComp();
                        objproentity.Pid = Convert.ToInt32(ddlselectpro.SelectedValue);
                        objproentity.Mfgdate = Convert.ToDateTime(txMfgDate.Text);
                        objproentity.Expdate = Convert.ToDateTime(txtExpirydate.Text);
                        objproentity.Batchcode = lblCode.Text;
                        objproentity.Batchname = txtBatchname.Text;
                        objproentity.Batchdesc = txtBatchdesc.Text;
                        //objproentity.Quantitytypeid = ddlQuantitytype.SelectedValue=="0"?0:Convert.ToInt32(ddlQuantitytype.SelectedValue);
                        objproentity.Quantitytype = ddlQuantitytype.SelectedValue == "0" ? "0" : ddlQuantitytype.SelectedValue;
                        objproentity.Recievedfrom = ddlRecievedfrom.SelectedValue;
                        objproentity.Depotid = Convert.ToInt32(lblDepuId.Text);
                        objproentity.Batchno = Convert.ToString(txtBatchNo.Text.Trim());
                        objproentity.ATNo = Convert.ToString(txtATNo.Text.Trim());
                        objproentity.VechicleNo = Convert.ToString(txtVechicleNo.Text.Trim());
                        objproentity.Esl = Convert.ToDateTime(txtEsldate.Text.Trim());
                        objproentity.Stockqty = Convert.ToDouble(rntbAddQuantity.Text);
                        objproentity.Isproductstatus = "Pending";
                        if (chkIsSampleSent.Checked == true)
                        {
                            objproentity.IsSampleSent = 4;
                        }
                        else
                        {
                            objproentity.IsSampleSent = 1;
                        }
                        if (chkIsActive.Checked == true)
                        {
                            objproentity.Isactive = 1;
                        }

                        DataTable dt = (DataTable)(Session["UserDetails"]);
                        if (dt.Rows.Count > 0)
                        {
                            objproentity.Addedby = Convert.ToInt32(dt.Rows[0]["User_ID"]);
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        }


                        int bid = objpro.Insertproduct(objproentity);
                        objproentity.Bid = bid;
                        objproentity.Maxquantity = Convert.ToDouble(rntbAddQuantity.Text);
                        objproentity.Stockqty = Convert.ToDouble(rntbAddQuantity.Text);
                        //objproentity.Quantitytypeid = ddlQuantitytype.SelectedValue == "0" ? 0 : Convert.ToInt32(ddlQuantitytype.SelectedValue);
                        objproentity.Quantitytype = ddlQuantitytype.SelectedValue == "0" ? "0" : ddlQuantitytype.SelectedValue;
                        if (chkIsActive.Checked == true)
                        {
                            objproentity.Isstockin1 = 1;
                        }
                        objproentity.SupplierId = Convert.ToInt32(ddlSupplier.SelectedValue);
                        objproentity.GenericName = txtGenericName.Text;
                        objproentity.OriginalManf = txtOrignalManfucture.Text;
                        objproentity.SentQty = Convert.ToDouble(rtxtSentQunatity.Text);

                        objproentity.RecievedOn = Convert.ToDateTime(txtRecivedDate.Text.Trim());
                        objproentity.DriverName = txtDriverName.Text;
                        objproentity.InterTransferId = Convert.ToInt32(rblInterTransferId.SelectedItem.Value);
                        objproentity.Remarks = txtRemarks.Text;
                        //  objproentity.pa
                        objproentity.PackingMaterial = txtPackingMaterial.Text;
                        objproentity.PackingQuantity = Convert.ToDouble(txtPackingQuantity.Text);

                        objproentity.UnitInfo = txtUnitInfo.Text;
                        if (Convert.ToInt32(rblChallanNo.SelectedItem.Value) == 1)
                        {
                            objproentity.IsChallanNo = true;
                            objproentity.IsIrNo = false;
                        }
                        else
                        {
                            objproentity.IsIrNo = true;
                            objproentity.IsChallanNo = false;
                        }
                        objproentity.ChallanOrIrNo = txtrblNo.Text;

                        objpro.Insertproductinstock(objproentity);
                        lblMessage.Text = "Data Entered Successfully";

                        txMfgDate.Text = string.Empty;
                        txtExpirydate.Text = string.Empty;
                        txtBatchname.Text = string.Empty;
                        txtBatchdesc.Text = string.Empty;
                        rntbAddQuantity.Text = string.Empty;
                        ddlQuantitytype.SelectedIndex = -1;
                        ddlselectpro.Text = string.Empty;
                        txtBatchNo.Text = string.Empty;
                        txtATNo.Text = string.Empty;
                        txtVechicleNo.Text = string.Empty;
                        txtEsldate.Text = string.Empty;
                        ddlselectpro.Items.Clear();
                        ddlselectpro.ClearSelection();
                        ddlRecievedfrom.SelectedIndex = -1;
                        ddlSupplier.SelectedIndex = -1;
                        txtGenericName.Text = "";
                        txtOrignalManfucture.Text = "";
                        rtxtSentQunatity.Text = "";
                        txtRecivedDate.Text = "";
                        txtDriverName.Text = "";
                        txtRemarks.Text = "";
                        txtrblNo.Text = "";
                        txtPackingMaterial.Text = "";
                        txtPackingQuantity.Text = "";
                        txtUnitInfo.Text = "";

                    }

                    else if ((btnSubmit.Text == "Update"))
                    {
                        ManageStockEntity objstockentity = new ManageStockEntity();
                        ManagestockComp objstock = new ManagestockComp();

                        objstockentity.Bid = Convert.ToInt32(hfid.Value);
                        objstockentity.Batchname = txtBatchname.Text;
                        objstockentity.Batchdesc = txtBatchdesc.Text;
                        objstockentity.Expdate = Convert.ToDateTime(txtExpirydate.Text);
                        objstockentity.Pid = Convert.ToInt32(ddlselectpro.SelectedValue);
                        objstockentity.Batchno = Convert.ToString(txtBatchNo.Text.Trim());
                        objstockentity.ATNo = Convert.ToString(txtATNo.Text.Trim());
                        objstockentity.VechicleNo = Convert.ToString(txtVechicleNo.Text.Trim());
                        objstockentity.Recievedfrom = Convert.ToString(ddlRecievedfrom.SelectedValue);
                        objstockentity.Esl = Convert.ToDateTime(txtEsldate.Text.Trim());
                        if (chkIsActive.Checked == true)
                        {
                            objstockentity.Isactive = 1;
                        }
                        else
                        {
                            objstockentity.Isactive = 0;
                        }
                        objstockentity.Modificationby = 786;

                        //objstock.updatebatchComponent(objstockentity);

                        objstockentity.Maxquantity = Convert.ToDouble(rntbAddQuantity.Text);
                        objstockentity.Quantitytype = ddlQuantitytype.SelectedValue == "0" ? "0" : ddlQuantitytype.SelectedValue;
                        if (chkIsActive.Checked == true)
                        {
                            objstockentity.Isstockin1 = 1;
                        }
                        else
                        {
                            objstockentity.Isstockin1 = 0;
                        }
                        if (chkIsActive.Checked == true)
                        {
                            objstockentity.Isactive = 1;
                        }
                        else
                        {
                            objstockentity.Isactive = 0;
                        }
                        objstockentity.Sid = Convert.ToInt32(hdstockupd.Value);
                        objstockentity.SupplierId = Convert.ToInt32(ddlSupplier.SelectedValue);
                        objstockentity.GenericName = txtGenericName.Text;
                        objstockentity.OriginalManf = txtOrignalManfucture.Text;
                        objstockentity.SentQty = Convert.ToDouble(rtxtSentQunatity.Text);
                        objstockentity.RecievedOn = Convert.ToDateTime(txtRecivedDate.Text.Trim());
                        objstockentity.DriverName = txtDriverName.Text;
                        objstockentity.InterTransferId = Convert.ToInt32(rblInterTransferId.SelectedItem.Value);
                        objstockentity.Remarks = txtRemarks.Text;
                        objstockentity.PackingMaterial = txtPackingMaterial.Text;
                        objstockentity.PackingQuantity = Convert.ToDouble(txtPackingQuantity.Text);
                        objstockentity.UnitInfo = txtUnitInfo.Text;
                        if (Convert.ToInt32(rblChallanNo.SelectedItem.Value) == 1)
                        {
                            objstockentity.IsChallanNo = true;
                            objstockentity.IsIrNo = false;
                        }
                        else
                        {
                            objstockentity.IsIrNo = true;
                            objstockentity.IsChallanNo = false;
                        }
                        objstockentity.ChallanOrIrNo = txtrblNo.Text;
                        objstock.updatebatchComponent(objstockentity);
                        objstock.UpdateStock(objstockentity);

                        lblMessage.Text = "Data Updated Successfully";
                        btnSubmit.Text = "Submit";

                        txMfgDate.Text = string.Empty;
                        txtExpirydate.Text = string.Empty;
                        txtBatchname.Text = string.Empty;
                        txtBatchdesc.Text = string.Empty;
                        rntbAddQuantity.Text = string.Empty;
                        ddlQuantitytype.SelectedIndex = -1;

                        txtBatchNo.Text = string.Empty;
                        txtATNo.Text = string.Empty;
                        txtVechicleNo.Text = string.Empty;
                        txtEsldate.Text = string.Empty;

                        ddlselectpro.Text = string.Empty;
                        ddlselectpro.Items.Clear();
                        ddlselectpro.ClearSelection();
                        ddlRecievedfrom.SelectedIndex = -1;
                        ddlSupplier.SelectedIndex = -1;
                        txtGenericName.Text = "";
                        txtOrignalManfucture.Text = "";
                        rtxtSentQunatity.Text = "";
                        txtRecivedDate.Text = "";
                        txtDriverName.Text = "";
                        txtRemarks.Text = "";
                        txtrblNo.Text = "";
                        txtUnitInfo.Text = "";
                        txtPackingMaterial.Text = "";
                        txtPackingQuantity.Text = "";
                    }
                    griddisplay();
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
        public void griddisplay()
        {
            try
            {
                DataTable dt3 = new DataTable();
                ManagestockComp objmanagestock = new ManagestockComp();
                dt3 = objmanagestock.GridDisplayComponent();
                RadGrid.DataSource = dt3;
                RadGrid.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [WebMethod]
        public static RadComboBoxData GetCompanyNames(RadComboBoxContext context)
        {
            DataTable data = GetData(context.Text);

            RadComboBoxData comboData = new RadComboBoxData();
            int itemOffset = context.NumberOfItems;
            int endOffset = Math.Min(itemOffset + ItemsPerRequest, data.Rows.Count);
            comboData.EndOfItems = endOffset == data.Rows.Count;

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(endOffset - itemOffset);

            for (int i = itemOffset; i < endOffset; i++)
            {
                RadComboBoxItemData itemData = new RadComboBoxItemData();
                itemData.Text = data.Rows[i]["Product_Name"].ToString();
                itemData.Value = data.Rows[i]["Product_ID"].ToString();

                result.Add(itemData);
            }

            comboData.Message = GetStatusMessage(endOffset, data.Rows.Count);

            comboData.Items = result.ToArray();
            return comboData;
        }
        private static DataTable GetData(string text)
        {
            try
            {
                ManageStockEntity objentity = new ManageStockEntity();
                ManagestockComp objcom = new ManagestockComp();
                objentity.Productname = text.Trim();
                objentity.Action = "GetProduct";
                DataTable dt = objcom.GetProduct(objentity);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static string GetStatusMessage(int offset, int total)
        {
            if (total <= 0)
                return "No matches";

            return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
        }


        protected void RadGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Editnew")
            {

                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string BatchName = Convert.ToString(arg[1]);
                string BatchDesc = Convert.ToString(arg[2]);
                DateTime Mfg = Convert.ToDateTime(arg[3]);
                DateTime EXP = Convert.ToDateTime(arg[4]);

                string isactive = Convert.ToString(arg[5]);
                string QyantityType = Convert.ToString(arg[6]);
                string ProductName = Convert.ToString(arg[7]);
                string recievedfrom = Convert.ToString(arg[8]);
                hfid.Value = catid.ToString();

                string branchno = Convert.ToString(arg[9]);
                string atno = Convert.ToString(arg[10]);
                string vechicleno = Convert.ToString(arg[11]);
                hdstockupd.Value = Convert.ToString(arg[12]);
                if (recievedfrom == "")
                { }
                else
                {
                    ddlRecievedfrom.DataBind();
                    ddlRecievedfrom.SelectedValue = recievedfrom;
                }
                if ((Convert.ToString(arg[13])) == "")
                { }
                else
                {
                    DateTime esldate = (Convert.ToDateTime(arg[13]));
                    txtEsldate.Text = esldate.ToString("dd MMM yyyy");
                }

                txtBatchNo.Text = branchno;
                txtATNo.Text = atno;
                txtVechicleNo.Text = vechicleno;

                txtBatchname.Text = BatchName;
                txtBatchdesc.Text = BatchDesc;
                txMfgDate.Text = Mfg.ToString("dd MMM yyyy");
                txtExpirydate.Text = EXP.ToString("dd MMM yyyy");
                ddlQuantitytype.DataBind();
                ddlQuantitytype.SelectedValue = QyantityType == "" ? "0" : QyantityType;
                rntbAddQuantity.Text = Convert.ToString(arg[14]);
                txtDriverName.Text = Convert.ToString(arg[15]);
                ddlSupplier.SelectedValue = Convert.ToString(arg[16]);
                txtGenericName.Text = Convert.ToString(arg[17]);
                txtOrignalManfucture.Text = Convert.ToString(arg[18]);
                rtxtSentQunatity.Text = Convert.ToString(arg[19]);
                txtRecivedDate.Text = Convert.ToDateTime((arg[20])).ToString("dd MMM yyyy");
                rblInterTransferId.SelectedItem.Value = Convert.ToString(arg[21]);
                if (Convert.ToString(arg[22]) == "True")
                {
                    rblChallanNo.SelectedItem.Value = "1";

                }
                else
                {
                    rblChallanNo.SelectedItem.Value = "2";
                }
                txtrblNo.Text = Convert.ToString(arg[24]);
                txtRemarks.Text = Convert.ToString(arg[25]);
                txtPackingMaterial.Text = Convert.ToString(arg[26]);
                txtPackingQuantity.Text = Convert.ToString(arg[27]);

                //   txtVechicleNo.Text = "";

                ddlselectpro.Text = string.Empty;
                ddlselectpro.Items.Clear();
                ddlselectpro.ClearSelection();

                ddlselectpro.DataSource = GetData("");
                ddlselectpro.DataTextField = "Product_Name";
                ddlselectpro.DataValueField = "Product_ID";
                ddlselectpro.DataBind();



                ddlselectpro.SelectedValue = ProductName;
                btnSubmit.Text = "Update";


            }
            else if (e.CommandName == "Active")
            {
                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string argt = Convert.ToString(arg[1]);
                LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                ManagestockComp managecomp = new ManagestockComp();
                ManageStockEntity objaddentity = new ManageStockEntity();
                if (Convert.ToBoolean(argt) == true)
                {
                    objaddentity.Isactive = 1;
                }
                else
                {
                    objaddentity.Isactive = 0;
                }
                objaddentity.Bid = catid;
                managecomp.updateStockComponentactive(objaddentity);
            }
            griddisplay();

        }




        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RadGrid.ExportSettings.ExportOnlyData = true;
                RadGrid.ExportSettings.IgnorePaging = true;
                RadGrid.ExportSettings.OpenInNewWindow = true;
                RadGrid.ExportSettings.FileName = "StockList_" + DateTime.Now.Date.ToString();
                RadGrid.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RadComboBox1_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
        {

        }



        protected void RadComboBox1_DataBound(object sender, EventArgs e)
        {
            //  binddepotlist();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txMfgDate.Text = string.Empty;
            txtExpirydate.Text = string.Empty;
            txtBatchname.Text = string.Empty;
            txtBatchdesc.Text = string.Empty;
            rntbAddQuantity.Text = string.Empty;
            ddlQuantitytype.SelectedIndex = -1;
            ddlselectpro.Text = string.Empty;
            txtBatchNo.Text = string.Empty;
            txtATNo.Text = string.Empty;
            txtVechicleNo.Text = string.Empty;
            txtEsldate.Text = string.Empty;
            ddlselectpro.Items.Clear();
            ddlselectpro.ClearSelection();
            ddlRecievedfrom.SelectedIndex = -1;

            btnSubmit.Text = "Submit";
        }

        protected void ddlQuantitytype_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlQuantitytype.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //protected void ctmvQtyIssued_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    try
        //    {
        //        if (Convert.ToDouble(rntbAddQuantity.Text) > 0)
        //        {
        //            args.IsValid = true;
        //        }
        //        else
        //        {
        //            if (rntbAddQuantity.Text == "0")
        //            {
        //                args.IsValid = false;

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        protected void ddlRecievedfrom_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlRecievedfrom.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlSupplier_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlSupplier.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (Convert.ToInt32(rtxtSentQunatity.Text) > 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    if (rtxtSentQunatity.Text == "0")
                    {
                        args.IsValid = false;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlQuantitytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlQuantitytype.SelectedValue) == "4")
            {
                rntbAddQuantity.NumberFormat.DecimalDigits = 0;
                rtxtSentQunatity.NumberFormat.DecimalDigits = 0;
            }
            else if (Convert.ToString(ddlQuantitytype.SelectedValue) == "3")
            {
                rntbAddQuantity.NumberFormat.DecimalDigits = 0;
                rtxtSentQunatity.NumberFormat.DecimalDigits = 0;
            }
            else
            {
                rtxtSentQunatity.NumberFormat.DecimalDigits = 3;
                rntbAddQuantity.NumberFormat.DecimalDigits = 0;
            }
        }


    }
}