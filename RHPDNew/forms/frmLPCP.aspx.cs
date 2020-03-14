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
    public partial class frmLPCP : System.Web.UI.Page
    {
        static int iD = 0;
        static bool ATNo = true;
        static int SuplierID = 0;
        static string ATSONo = "";
        static string SuplierContact = "";
        static decimal LD = 0;
        static DateTime TenderDate = DateTime.Now;
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
                    
                    bindgrid();
                   
                }
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
                        rhpdEntities db = new rhpdEntities();
                        
                        if (e.CommandName == "DeleteA")
                        {
                            int Id = Convert.ToInt32(e.CommandArgument.ToString());
                            tblLPCP obj = new tblLPCP() { ID = Id };
                            db.tblLPCPs.Attach(obj);
                            db.tblLPCPs.Remove(obj);
                            db.SaveChanges();
                            bindgrid();
                           
                        }
                        else if (e.CommandName == "EditA")
                        {
                            int ID = Convert.ToInt32(e.CommandArgument.ToString());
                            var list = db.tblLPCPs.Where(x => x.ID == ID).FirstOrDefault();
                            if (list!=null)
                            {
                                bindgrid();
                                hdnID.Value = ID.ToString();
                                GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
                                DropDownList ddlProduct = (DropDownList)footeritem.FindControl("ddlProduct");
                                RadNumericTextBox txtQuantity = (RadNumericTextBox)footeritem.FindControl("txtQuantity");
                                RadNumericTextBox txtRate = (RadNumericTextBox)footeritem.FindControl("txtRate");
                                DropDownList ddlOM = (DropDownList)footeritem.FindControl("ddlOM");
                                RadDateTimePicker txtDeliveryDate = (RadDateTimePicker)footeritem.FindControl("txtDeliveryDate");
                                RadNumericTextBox txtValue = (RadNumericTextBox)footeritem.FindControl("txtValue");
                                Button btnSubmitBatch = (Button)footeritem.FindControl("btnSubmitBatch");                              
                                btnSubmitBatch.Text = "Update";
                                ddlProduct.SelectedValue = list.ProductId.ToString();
                                txtQuantity.Text = list.Quantity.ToString();
                                txtRate.Text = list.Rate.ToString();
                                ddlOM.SelectedValue = list.OriginalMfgID.ToString();
                                txtDeliveryDate.SelectedDate = list.DeliveryDate;
                                txtValue.Text = list.Value.ToString();
                               

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

      
        protected void ddlWarehouse_DataBound(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "";
               

                GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];

                DropDownList ddlOM = (DropDownList)footeritem.FindControl("ddlOM");
                ddlOM.Items.Insert(0, li);

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
                //if (!IsPostBack)
                {
                    ListItem li = new ListItem();
                    li.Value = "0";
                    li.Text = "-- Select --";
                    GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];

                    DropDownList ddlProduct = (DropDownList)footeritem.FindControl("ddlProduct");
                    ddlProduct.Items.Insert(0, li);


                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void bindgrid()
        {
            try
            {      
                
                    rhpdEntities db = new rhpdEntities();
                    var cmdlist = from cmdlis in db.tblLPCPs select cmdlis;
                    List<tblLPCP> result = cmdlist.Where(l => l.IsATNo == ATNo).Where(l => l.TenderDate == TenderDate).Where(l=>l.SupplierID == SuplierID).Where(l=>l.LDPer==LD && l.ATSONo==ATSONo).ToList(); 
                    rgdBatch.DataSource = result;
                    rgdBatch.DataBind();

                    GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];


                    if (result.Count() > 1)
                    {
                        Label lblTotalValue = (Label)footeritem.FindControl("lblTotalValue");
                        lblTotalValue.Text = "Total Value: " + Convert.ToDecimal( result.Sum(x => x.Value)).ToString("0.000");
                    }
                    DropDownList ddlProduct = (DropDownList)footeritem.FindControl("ddlProduct");
                    var prdt = from pmls in db.ProductMasters select pmls;
                    List<ProductMaster> pm = prdt.ToList();
                    ddlProduct.DataSource = pm;
                    ddlProduct.DataBind();

                    DropDownList ddlOM = (DropDownList)footeritem.FindControl("ddlOM");
                    var omlst = from omls in db.OriginalManufacture_ select omls;
                    List<OriginalManufacture_> om = omlst.ToList();
                    ddlOM.DataSource = om;
                    ddlOM.DataBind();

                  var splst = from spls in db.suppliers select spls;
                    List<supplier> sp = splst.ToList();
                    ddlSupplier.DataSource = sp;
                    ddlSupplier.DataBind();
                  

                    var first = result.FirstOrDefault();
                    if (first != null)
                    {
                        iD = first.ID;
                        SuplierID = first.SupplierID;
                        ddlSupplier.SelectedValue = first.SupplierID.ToString();
                        SuplierContact=txtContact.Text = first.SupplierContactNo;
                        LD = first.LDPer;
                        txtLD.Text = first.LDPer.ToString();
                        TenderDate = first.TenderDate;
                       txtTenderDate.SelectedDate = first.TenderDate;
                    ATSONo=txtATSONo.Text = first.ATSONo;
                    if (first.IsATNo == true)
                    {
                        ATNo = true;
                        rbATNoSupNo.SelectedValue = "1";
                    }
                    else
                    {
                        ATNo = false;
                        rbATNoSupNo.SelectedValue = "2";
                    }
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
                if (txtATSONo.Text == "" || ddlSupplier.SelectedItem.Value == "0" || txtLD.Text == "" || txtTenderDate.SelectedDate.Value == null)
                {
                    txtATSONo.Focus();
                    lblErrorBatch.Text = "** Fill the required fields!";
                    return;
                }

                GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
                DropDownList ddlProduct = (DropDownList)footeritem.FindControl("ddlProduct");
                RadNumericTextBox txtQuantity = (RadNumericTextBox)footeritem.FindControl("txtQuantity");
                RadNumericTextBox txtRate = (RadNumericTextBox)footeritem.FindControl("txtRate");
                DropDownList ddlOM = (DropDownList)footeritem.FindControl("ddlOM");
                RadDateTimePicker txtDeliveryDate = (RadDateTimePicker)footeritem.FindControl("txtDeliveryDate");              
                RadNumericTextBox txtValue = (RadNumericTextBox)footeritem.FindControl("txtValue");
                Button btnSubmitBatch = (Button)footeritem.FindControl("btnSubmitBatch");
                 rhpdEntities db = new rhpdEntities();
                 if (hdnID.Value != "")
                 {
                     var defIndex = Convert.ToInt32(hdnID.Value);
                     var query = from emp in db.tblLPCPs
                                 where emp.ID == defIndex
                                 select emp;
                     tblLPCP obj = query.SingleOrDefault();
                     ATSONo = obj.ATSONo = txtATSONo.Text;
                     obj.DeliveryDate = txtDeliveryDate.SelectedDate.Value;
                     obj.DeliveryTime = txtDeliveryDate.SelectedDate.Value;
                     obj.Dispute = false;
                     if (rbATNoSupNo.SelectedValue == "1")
                     {
                         ATNo = obj.IsATNo = true;
                         obj.IsSONo = false;
                     }
                     else
                     {
                         ATNo = obj.IsATNo = false;
                         obj.IsSONo = true;
                     }
                     obj.Late = false;
                     LD = obj.LDPer = decimal.Parse(txtLD.Text);
                     obj.OriginalMfgID = int.Parse(ddlOM.SelectedItem.Value);
                     obj.Other = false;
                     obj.ProductId = int.Parse(ddlProduct.SelectedItem.Value);
                     obj.Quantity = decimal.Parse(txtQuantity.Text);
                     obj.Rate = decimal.Parse(txtRate.Text);
                     obj.Status = false;
                     SuplierContact = obj.SupplierContactNo = txtContact.Text;
                     SuplierID = obj.SupplierID = int.Parse(ddlSupplier.SelectedItem.Value);
                     TenderDate = obj.TenderDate = txtTenderDate.SelectedDate.Value;
                     obj.Value = decimal.Parse(txtValue.Text);
                     obj.ModifiedOn = DateTime.Now;
                     obj.ModifiedBy = 1;                    
                     db.SaveChanges();
                     hdnID.Value = "";
                     btnSubmitBatch.Text = "Add";
                 }
                 else
                 {
                     tblLPCP obj = new tblLPCP();
                     ATSONo = obj.ATSONo = txtATSONo.Text;
                     obj.DeliveryDate = txtDeliveryDate.SelectedDate.Value;
                     obj.DeliveryTime = txtDeliveryDate.SelectedDate.Value;
                     obj.Dispute = false;
                     if (rbATNoSupNo.SelectedValue == "1")
                     {
                         ATNo = obj.IsATNo = true;
                         obj.IsSONo = false;
                     }
                     else
                     {
                         ATNo = obj.IsATNo = false;
                         obj.IsSONo = true;
                     }
                     obj.Late = false;
                     LD = obj.LDPer = decimal.Parse(txtLD.Text);
                     obj.OriginalMfgID = int.Parse(ddlOM.SelectedItem.Value);
                     obj.Other = false;
                     obj.ProductId = int.Parse(ddlProduct.SelectedItem.Value);
                     obj.Quantity = decimal.Parse(txtQuantity.Text);
                     obj.Rate = decimal.Parse(txtRate.Text);
                     obj.Status = false;
                     SuplierContact = obj.SupplierContactNo = txtContact.Text;
                     SuplierID = obj.SupplierID = int.Parse(ddlSupplier.SelectedItem.Value);
                     TenderDate = obj.TenderDate = txtTenderDate.SelectedDate.Value;
                     obj.Value = decimal.Parse(txtValue.Text);
                         obj.AddedOn = DateTime.Now;
                         obj.AddedBy = 1;
                         db.tblLPCPs.Add(obj);
                         db.SaveChanges();
                     }
                 
                 bindgrid();
                        
                   
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            bindgrid();
        }

        

        protected void ddlSupplier_DataBound(object sender, EventArgs e)
        {
            try
            {
                 if (!IsPostBack)
                {
                    ListItem li = new ListItem();
                    li.Value = "0";
                    li.Text = "-- Select --";
                    ddlSupplier.Items.Insert(0, li);


                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                GridFooterItem footeritem = (GridFooterItem)rgdBatch.MasterTableView.GetItems(GridItemType.Footer)[0];              
                RadNumericTextBox txtQuantity = (RadNumericTextBox)footeritem.FindControl("txtQuantity");
                RadNumericTextBox txtRate = (RadNumericTextBox)footeritem.FindControl("txtRate");
                RadNumericTextBox txtValue = (RadNumericTextBox)footeritem.FindControl("txtValue");
                if (txtRate.Text != "" && txtQuantity.Text != "")
                    txtValue.Text = (decimal.Parse(txtRate.Text) * decimal.Parse(txtQuantity.Text)).ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnSubmitall_Click(object sender, EventArgs e)
        {
            try
            { ATNo = true;
      SuplierID = 0;
     ATSONo = "";
  SuplierContact = "";
      LD = 0;
       TenderDate = DateTime.Now;
       hdnID.Value = "";
       bindgrid();
       Response.Redirect("../Forms/frmLPCPList.aspx?iD="+iD);

            }
            catch (Exception)
            {
                
                throw;
            }

        }

       
       
    }
}