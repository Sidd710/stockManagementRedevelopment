using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDEntity;
using RHPDComponent;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class AddRole : System.Web.UI.Page
    {
        int roleID;
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
                        getRoleCode();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getRoleCode()
        {
            try
            {
                AddroleComp obj = new AddroleComp();
               lblRoleCode.Text= obj.getRoleCode();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddroleComp objaddrolecomp = new AddroleComp();
            AddRoleEntity objroleentity = new AddRoleEntity(); ;
            try
            {       

                    objroleentity.Role_code = lblRoleCode.Text;
                    objroleentity.Role_desc = txtDesc.Text;
                    objroleentity.DeptId = Convert.ToInt32(ddlDept.SelectedItem.Value);
                    objroleentity.Rank = int.Parse("1");
                    objroleentity.Role = ((txtRole.Text[0]) + txtRole.Text.Substring(1)).ToUpper();// txtRole.Text;
                    objroleentity.AddedBy = 786;//Need changes later
                    objroleentity.ModifiedBy = 786;//need changes later
                    if (chkIsActive.Checked == true)
                    {
                        objroleentity.Isactive = 1;
                    }
                    else
                    { objroleentity.Isactive = 0; }

                 if (btnSubmit.Text == "Submit")
                {

                    DataTable dt = new DataTable();
                    dt = objaddrolecomp.checkRolename(txtRole.Text);
                    if (dt.Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This Role name is already exsist');", true);
                        return;
                    }
                    else
                    {
                        objaddrolecomp.InsertRole(objroleentity);
                        lblMessage.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Role Added Successfully');", true);
                        lblMessage.Text = "Data added Successfully";
                    }
                   
                }
               else if ((btnSubmit.Text == "Update"))
                {
                      DataTable dt = new DataTable();
                      dt = objaddrolecomp.updcheckRolename(txtRole.Text, Convert.ToInt32(hfid.Value));
                    if (dt.Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This Role name is already exsist');", true);
                        return;
                    }
                    else
                    {
                        objroleentity.Role_id = Convert.ToInt32(hfid.Value);
                        objaddrolecomp.updatecomponent(objroleentity);
                        lblMessage.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Role Updated Successfully');", true);
                        lblMessage.Text = "Data Updated Successfully";
                        btnSubmit.Text = "Submit";
                    }
                    
                }
                 _Clear();
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
                rgdRole.ExportSettings.ExportOnlyData = true;
                rgdRole.ExportSettings.IgnorePaging = true;
                rgdRole.ExportSettings.OpenInNewWindow = true;
                rgdRole.ExportSettings.FileName = "RoleList_" + DateTime.Now.Date.Date.ToString();

                rgdRole.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void RadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editnew")
                {
                    string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                    roleID = Convert.ToInt32(arg[0]);
                    string RoleCode = Convert.ToString(arg[1]);
                    string RoleDesc = Convert.ToString(arg[2]);
                    bool isActive = Convert.ToBoolean(arg[3]);
                    int deptID = Convert.ToInt32(arg[5]);
                    string role = Convert.ToString(arg[4]);
                    int Rank = Convert.ToInt32(arg[6]);
                    hfid.Value = roleID.ToString();
                    txtRole.Text = role;
                    txtRank.Text = "1";
                    txtDesc.Text = RoleDesc;
                    ddlDept.SelectedValue = deptID.ToString();
                    chkIsActive.Checked = isActive;
                    lblRoleCode.Text = RoleCode;
                    btnSubmit.Text = "Update";

                }
                else if (e.CommandName == "Active")
                {
                    string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                    roleID = Convert.ToInt32(arg[0]);
                    bool argt = Convert.ToBoolean(arg[1]);
                    LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                    AddroleComp objaddrole = new AddroleComp();
                    AddRoleEntity objaddroleentity = new AddRoleEntity();
                    if (Convert.ToBoolean(argt) == true)
                    {
                        objaddroleentity.Isactive = 0;
                    }
                    else
                    {
                        objaddroleentity.Isactive = 1;
                    }
                    objaddroleentity.Role_id = roleID;
                    objaddrole.ActiveInactivate(objaddroleentity);
                    _Clear();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlDept_DataBound(object sender, EventArgs e)
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
        public void _Clear()
        { 
            try 
	        {
               txtDesc.Text = "";
               txtRole.Text = "";
               getRoleCode();
               rgdRole.DataBind();
               btnSubmit.Text = "Submit";
               ddlDept.DataBind();
               txtRank.Text = "";
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
                _Clear();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}