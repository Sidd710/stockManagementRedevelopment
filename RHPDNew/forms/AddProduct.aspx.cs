using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class AddProduct : System.Web.UI.Page
    {
        int catid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {

                AddProductComp objpro = new AddProductComp();
                lblCode.Text = objpro.getCode();
                // griddisplay();
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddProductComp objaddprocomp = new AddProductComp();
            AddProductEntity objproentity = new AddProductEntity(); ;
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    //   objroleentity = new AddRoleEntity();
                    objproentity.Product_name = NameTextBox.Text;
                    objproentity.Product_desc = FullDescriptionTextBox.Text;
                    objproentity.Short_product_desc = ShortDescriptionTextBox.Text;
                    objproentity.Admin_remarks = txtAdminComment.Text;
                    objproentity.Product_code = lblCode.Text;
                    objproentity.Product_cost = Convert.ToInt32(txtVarientProductCost.Text);
                    objproentity.Categoryid =Convert.ToInt32(ddlselectCat.SelectedItem.Value);
                    objproentity.Productunit = ddlproductUnit.SelectedItem.Text;
                    objproentity.Cat = txtcat.Text;
                    objproentity.StockQty = double.Parse(txtStock.Text);
                    objproentity.GSServe = int.Parse(txtGSserve.Text);
                    if (chkpublished.Checked == true)
                    {
                        objproentity.Isactive = 1;
                    }
                    objproentity.Addedby = 123;
                    int r= objaddprocomp.InsertUserComp(objproentity);
                    if (r > 0)
                    {
                        Clear();
                        txtcat.Text = "";
                        lblMessage.Text = "Submitted Sucessfully";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                    }
                    else
                    {
                        if (r == -1)
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "name();", true);
                            return;
                        }
                    }
                }
                if ((btnSubmit.Text == "Update"))
                {
                    AddProductComp objaddpro = new AddProductComp();
                    AddProductEntity objaddproentity = new AddProductEntity();
                    objproentity.Product_code = lblCode.Text;
                    objaddproentity.Product_id = Convert.ToInt32(hfid.Value);
                    objaddproentity.Product_name = NameTextBox.Text;
                    objaddproentity.Product_desc = FullDescriptionTextBox.Text;
                    objaddproentity.Short_product_desc = ShortDescriptionTextBox.Text;
                    objaddproentity.Admin_remarks = txtAdminComment.Text;
                    objaddproentity.Categoryid = Convert.ToInt32(ddlselectCat.SelectedItem.Value);
                    objaddproentity.Product_cost = Convert.ToInt32(txtVarientProductCost.Text);
                    objaddproentity.StockQty = double.Parse(txtStock.Text);
                    objaddproentity.GSServe = int.Parse(txtGSserve.Text);
                    objaddproentity.Productunit = ddlproductUnit.SelectedItem.Text;
                    objaddproentity.Cat = txtcat.Text;
                    
                    if (chkpublished.Checked == true)
                    {
                        objaddproentity.Isactive = 1;
                    }
                    else
                    {
                        objaddproentity.Isactive = 0;
                    }
                    objproentity.Modificationby = 123;
                    int r= objaddpro.updatecomponent(objaddproentity);
                    if (r > 0)
                    {
                        Clear();
                        txtcat.Text = "";
                        lblMessage.Text = "Update Successful";
                        btnSubmit.Text = "Submit";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                    }
                    else
                    {
                        if (r == -1)
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "name();", true);
                            return;
                        }
                    }
                }
                //griddisplay();
                rgdProduct.DataBind();
                Response.Redirect("../Forms/addproduct.aspx");
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void Clear()
        {
            ddlselectCat.SelectedIndex = -1;
            NameTextBox.Text = string.Empty;
            FullDescriptionTextBox.Text = string.Empty;
            ShortDescriptionTextBox.Text = string.Empty;
            txtAdminComment.Text = string.Empty;
            txtVarientProductCost.Text = string.Empty;
            chkpublished.Checked = true;
            lblMessage.Visible = false;
            txtStock.Text = "";
            txtGSserve.Text = "";
            ddlproductUnit.SelectedIndex = -1;
            txtcat.Text = "";
            hfid.Value = "0";
                
        }


        public void griddisplay()
        {
            try
            {
                DataTable dt3 = new DataTable();
                AddProductComp objaddpro = new AddProductComp();
                dt3 = objaddpro.GridDisplayComponent();

                rgdProduct.DataSource = dt3;
                rgdProduct.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "pEdit")
            {

                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string Product_Name = Convert.ToString(arg[1]);
                string Product_Desc = Convert.ToString(arg[2]);
                string Short_Product_Desc = Convert.ToString(arg[3]);
                string Admin_Remarks = Convert.ToString(arg[5]);
                int product_cost = Convert.ToInt32(arg[6]);
                string stock = Convert.ToString(arg[10]);
                string gsserve = Convert.ToString(arg[11]);
                string unit = Convert.ToString(arg[12]);
                ddlproductUnit.DataBind();
                ddlproductUnit.SelectedValue = unit;
                int Category_Id = 0;
                if (arg[8].ToString() == "")
                {
                    Category_Id = 0;
                }
                else
                {
                     ddlselectCat.DataBind();
                     Category_Id = Convert.ToInt32(arg[8]);
                     ddlselectCat.SelectedValue = Category_Id.ToString();
                }

                string Isactive = Convert.ToString(arg[4]);
                string productcode = Convert.ToString(arg[7]);
                bool isA = Convert.ToBoolean(Isactive);
                chkpublished.Checked = isA;
                hfid.Value = catid.ToString();
                NameTextBox.Text = Product_Name;
                FullDescriptionTextBox.Text = Product_Desc;
                ShortDescriptionTextBox.Text = Short_Product_Desc;
                txtAdminComment.Text = Admin_Remarks;
                txtVarientProductCost.Text = product_cost.ToString();
                lblCode.Text = productcode;
                txtcat.Text = Convert.ToString(arg[9]);
                txtStock.Text = stock;
                txtGSserve.Text = gsserve;
                
                btnSubmit.Text = "Update";

            }
            else if (e.CommandName == "Active")
            {
                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string argt = Convert.ToString(arg[1]);
                LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                AddProductComp objprounit = new AddProductComp();
                AddProductEntity objaddentity = new AddProductEntity();
                if (Convert.ToBoolean(argt) == true)
                {
                    objaddentity.Isactive = 0;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been inActivated');", true);
                }
                else
                {
                    objaddentity.Isactive = 1;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been activated');", true);
                }
                objaddentity.Product_id = catid;
                objprounit.ActiveInactivate(objaddentity);
            }
          //  griddisplay();
            rgdProduct.DataBind();

        }
        protected void ddlselectCat_DataBound(object sender, EventArgs e)
        {
            try
            {
                DropDownList list = sender as DropDownList;
                if (list != null)
                    list.Items.Insert(0, "-- Select --");
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                rgdProduct.ExportSettings.ExportOnlyData = true;
                rgdProduct.ExportSettings.IgnorePaging = true;
                rgdProduct.ExportSettings.OpenInNewWindow = true;
                rgdProduct.ExportSettings.FileName = "ProductList_" + DateTime.Now.Date.ToString();

                rgdProduct.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            NameTextBox.Text = string.Empty;
            FullDescriptionTextBox.Text = string.Empty;
            ShortDescriptionTextBox.Text = string.Empty;
            txtAdminComment.Text = string.Empty;
            txtVarientProductCost.Text = string.Empty;
            Clear();
        }
    }
}