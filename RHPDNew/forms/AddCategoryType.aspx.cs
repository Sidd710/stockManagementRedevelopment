using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDEntity;
//using BusinessComponent;
using RHPDComponent;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class AddCategory : System.Web.UI.Page
    {
        int catid;
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
                        // griddisplay();
                        lblMessage.Visible = false;
                    }
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

                if (btnSubmit.Text == "Submit")
                {

                    AddCategoryComp objaddcategory;
                    AddCategoryEntity objcategorycomp;

                    objcategorycomp = new AddCategoryEntity();
                    objcategorycomp.Category_name = txtCategoryName.Text;
                    objcategorycomp.Category_desc = txtCategoryDesc.Text;
                    objcategorycomp.Addedby = 123;
                    if (chkIsActive.Checked == true)
                    {
                        objcategorycomp.Isactive = 1;
                    }

                    objaddcategory = new AddCategoryComp();
                    int r = objaddcategory.insertComponent(objcategorycomp);
                    if (r > 0)
                    {
                        Clear();
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
                if (btnSubmit.Text == "Update")
                {
                    AddCategoryComp objaddcategory = new AddCategoryComp();
                    AddCategoryEntity objcategorycomp;

                    objcategorycomp = new AddCategoryEntity();
                    objcategorycomp.Id = Convert.ToInt32(hfid.Value);
                    objcategorycomp.Category_name = txtCategoryName.Text;
                    objcategorycomp.Category_desc = txtCategoryDesc.Text;
                    objcategorycomp.Modificationby = 465;
                    if (chkIsActive.Checked == true)
                    {
                        objcategorycomp.Isactive = 1;
                    }
                    else
                    {
                        objcategorycomp.Isactive = 0;
                    }

                    int r = objaddcategory.updateComponent(objcategorycomp);
                    if (r > 0)
                    {
                        Clear();
                        lblMessage.Text = "Update Sucessful";
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
                // griddisplay();
                RadGrid.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Clear()
        {
            txtCategoryName.Text = string.Empty;
            txtCategoryDesc.Text = string.Empty;
            chkIsActive.Checked = false;
            lblMessage.Visible = false;
        }


        public void griddisplay()
        {
            try
            {
                DataTable dt3 = new DataTable();
                AddCategoryComp objaddcategory = new AddCategoryComp();
                dt3 = objaddcategory.GridDisplayComponent();
                if (dt3.Rows.Count > 0)
                {
                    RadGrid.DataSource = dt3;
                    RadGrid.DataBind();

                }
                else
                {
                    lblMessage.Text = "There is no row in grid";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Editnew")
            {

                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string CategoryName = Convert.ToString(arg[1]);
                string CategoryDesc = Convert.ToString(arg[2]);
                string isactive = Convert.ToString(arg[3]);
                hfid.Value = catid.ToString();

                txtCategoryName.Text = CategoryName;
                txtCategoryDesc.Text = CategoryDesc;
                chkIsActive.Checked = Convert.ToBoolean(isactive);
                btnSubmit.Text = "Update";

            }
            else if (e.CommandName == "Active")
            {
                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string argt = Convert.ToString(arg[1]);
                LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                AddCategoryComp objaddcat = new AddCategoryComp();
                AddCategoryEntity objaddentity = new AddCategoryEntity();
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
                objaddentity.Id = catid;
                objaddcat.ActiveInactivateCategory(objaddentity);
            }
            // griddisplay();
            RadGrid.DataBind();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                RadGrid.ExportSettings.ExportOnlyData = true;
                RadGrid.ExportSettings.IgnorePaging = true;
                RadGrid.ExportSettings.OpenInNewWindow = true;
                RadGrid.ExportSettings.FileName = " CategoryTypeList _" + DateTime.Now.Date.ToString();

                RadGrid.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RadGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtCategoryName.Text = string.Empty;
                txtCategoryDesc.Text = string.Empty;
                chkIsActive.Checked = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}