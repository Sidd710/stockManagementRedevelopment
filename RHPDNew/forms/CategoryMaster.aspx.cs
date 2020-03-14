using RHPDComponent;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class CategoryMaster : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    // griddisplay();
                }
                AddCategoryComp objcate = new AddCategoryComp();
                lblCode.Text = objcate.getCode();
            }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    CategoryMasterEntity objcatentity = new CategoryMasterEntity();
                    AddCategoryComp objcatcomp = new AddCategoryComp();
                    objcatentity.Category_typeid = Convert.ToInt32(ddlselectCat.SelectedItem.Value);
                    objcatentity.Category_name = txtCategoryName.Text;
                    objcatentity.Categorydesc = txtCategoryDesc.Text;
                    if (ddlparentId.SelectedItem.Text == "-- Select --")
                    {
                        objcatentity.Parentcategory_id = null;
                    }
                    else
                    {
                        objcatentity.Parentcategory_id = Convert.ToInt32(ddlparentId.SelectedItem.Value);
                    }
                    objcatentity.Category_code =lblCode.Text;
                
                    if (chkIsActive.Checked == true)
                    {
                        objcatentity.Isactive = 1;
                    }
                    else
                    {
                        objcatentity.Isactive = 0;
                    }
                    objcatentity.Addedby = 132;

                    int r= objcatcomp.insertComponent(objcatentity);
                    if(r>0)
                    {
                        lblMessage.Text = "Submitted Sucessfully";
                        Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                    }
                    else
                    {
                        if(r==-1)
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "name();", true);
                            return;
                        }
                    }
                }


               else if (btnSubmit.Text == "Update")
                {
                    CategoryMasterEntity objcatentity = new CategoryMasterEntity();
                    AddCategoryComp objcatcomp = new AddCategoryComp();
                  
                    objcatentity.Category_typeid = Convert.ToInt32(ddlselectCat.SelectedItem.Value);
                    objcatentity.Category_name = txtCategoryName.Text;
                    objcatentity.Categorydesc = txtCategoryDesc.Text;
                    if (ddlparentId.SelectedItem.Text == "-- Select --" || ddlparentId.SelectedItem.Value == null)
                    {
                        objcatentity.Parentcategory_id = null;
                    }
                    else
                    {
                        
                        objcatentity.Parentcategory_id = Convert.ToInt32(ddlparentId.SelectedItem.Value);
                    }
                  

                    if (chkIsActive.Checked == true)
                    {
                        objcatentity.Isactive = 1;
                    }
                    else
                    {
                        objcatentity.Isactive = 0;
                    }
                    if (hfid.Value != "")
                    {
                        objcatentity.Id = Convert.ToInt32(hfid.Value);
                    }
                    objcatentity.Modificationby = 132;

                    int r= objcatcomp.updateCategoryMasterComponent(objcatentity);
                    if (r > 0)
                    {
                        lblMessage.Text = "Update Sucessful";
                        Clear();
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
                RadGrid.DataBind();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void Clear()
        {
            ddlselectCat.DataBind();
            ddlparentId.DataBind();
            ddlselectCat.SelectedIndex = -1;
            ddlparentId.SelectedIndex = -1;
            txtCategoryName.Text = string.Empty;
            txtCategoryDesc.Text = string.Empty;
            lblMessage.Visible = false;
        }

        protected void ddlparentId_DataBound(object sender, EventArgs e)
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

        protected void RadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
             if (e.CommandName == "Editnew")
            {

                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string CategoryName = Convert.ToString(arg[1]);
                string CategoryDesc = Convert.ToString(arg[2]);
                string isactive = Convert.ToString(arg[3]);
                string Categorytypeid = Convert.ToString(arg[4]);
                string Parentcatid = Convert.ToString(arg[5]);
                string categorycode = Convert.ToString(arg[6]);
                hfid.Value = catid.ToString();

                txtCategoryName.Text = CategoryName;
                txtCategoryDesc.Text = CategoryDesc;
                 ddlselectCat.SelectedValue = Categorytypeid;
                 lblCode.Text = categorycode;
                 if (Parentcatid == "" || Parentcatid==null)
                 {
                    /// ddlparentId.SelectedValue = "0";
                 }
                 else
                 {
                     ddlparentId.SelectedValue = Parentcatid;
                 }
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
                CategoryMasterEntity cmobj = new CategoryMasterEntity();
                if (Convert.ToBoolean(argt) == true)
                {
                    cmobj.Isactive = 0;
                   ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been inActivated');", true);
                }
                else
                {
                    cmobj.Isactive = 1;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been activated');", true);
                }
                cmobj.Id = catid;
                objaddcat.ActiveInactivateCategoryMaster(cmobj);
               

            }
             RadGrid.DataBind();
           // griddisplay();
        }

        public void griddisplay()
        {
            try
            {
                DataTable dt3 = new DataTable();
                AddCategoryComp objaddcat = new AddCategoryComp();
                dt3 = objaddcat.GridDisplayMasterCategory();
                RadGrid.DataSource = dt3;
                RadGrid.DataBind();
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
                RadGrid.ExportSettings.ExportOnlyData = true;
                RadGrid.ExportSettings.IgnorePaging = true;
                RadGrid.ExportSettings.OpenInNewWindow = true;
                RadGrid.ExportSettings.FileName = "CategoryList_" + DateTime.Now.Date.ToString();

                RadGrid.MasterTableView.ExportToExcel();
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
            txtCategoryName.Text = string.Empty;
            txtCategoryDesc.Text = string.Empty;
            Clear();
        }
    }
}