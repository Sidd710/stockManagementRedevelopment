using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDEntity;
using RHPDComponent;
using RHPDDalc;
using System.Data.SqlClient;
using System.Configuration;

namespace RHPDNew.Forms
{
    public partial class AddUser : System.Web.UI.Page
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
                        getUserCode();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getUserCode()
        {
            try
            {
                AddUserComp obj = new AddUserComp();
                lblUserCode.Text = obj.getUserCode();
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

                rgdUser.ExportSettings.ExportOnlyData = true;
                rgdUser.ExportSettings.IgnorePaging = true;
                rgdUser.ExportSettings.OpenInNewWindow = true;
                rgdUser.ExportSettings.FileName = "UserList_" + DateTime.Now.Date.ToString();

                rgdUser.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
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
                if (_CheckUserName() == true)
                { return; }
                else
                {
                    if (Convert.ToDateTime(txtStartDate.Text) >= Convert.ToDateTime(txtEndDate.Text))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('End Date Always Greater Than Start Date!!');", true);
                    }
                    else
                    {
                        // rfvtxtpassword.Enabled = true;
                        // rfvtxtcpassword.Enabled = true;
                        AdduserEntity objEntity = new AdduserEntity();
                        AddUserComp objuser = new AddUserComp();
                        objEntity.AddedBy = 786;//needs to be updated
                        objEntity.ModifiedBy = 786;//needs update
                        objEntity.Address = txtAddress.Text;
                        objEntity.City = 1;// Convert.ToInt32(ddlCity.SelectedItem.Value);
                        objEntity.ContactNo = txtContactNo.Text;
                        objEntity.Country = 97;// int.Parse(ddlCountry.SelectedItem.Value);
                        objEntity.FirstName = char.ToUpper(txtFirstName.Text[0]) + txtFirstName.Text.Substring(1);
                        if (chkIsActive.Checked == true)
                            objEntity.IsActive = 1;
                        else
                            objEntity.IsActive = 0;
                        objEntity.LastName = char.ToUpper(txtLastName.Text[0]) + txtLastName.Text.Substring(1);
                        objEntity.Password = txtpassword.Text;
                        objEntity.RoleId = int.Parse(ddlRole.SelectedItem.Value);
                        objEntity.State = 1743;// int.Parse(ddlState.SelectedItem.Value);
                        objEntity.ArmyNo = txtArmyNumber.Text;
                        objEntity.StartDate = Convert.ToDateTime(txtStartDate.Text);
                        objEntity.EndDate = Convert.ToDateTime(txtEndDate.Text);

                        // objEntity = Convert.ToDateTime(txtEsldate.Text.Trim());
                        if (char.IsWhiteSpace(txtusername.Text[0]) == true)
                        {
                            objEntity.User_name = txtusername.Text.Substring(1);
                        }
                        else
                        {
                            objEntity.User_name = txtusername.Text;
                        }
                        objEntity.UserCode = lblUserCode.Text;
                        if (btnSubmit.Text == "Submit")
                        {
                            objuser.Insert(objEntity);
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User added successfully!');", true);


                        }

                        else if ((btnSubmit.Text == "Update"))
                        {
                            objEntity.User_id = Convert.ToInt32(hfid.Value);
                            objuser.Update(objEntity);
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User updated successfully!');", true);


                        }
                        _Clear();
                    }
                }

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
                ddlDept.DataBind();

                txtAddress.Text = "";

                txtContactNo.Text = "";
            //    ddlCountry.DataBind();
                txtFirstName.Text = "";
                chkIsActive.Checked = false;
                txtLastName.Text = "";
                txtpassword.Text = "";
                ddlRole.DataBind();
              //  ddlState.DataBind();
              //  ddlCity.DataBind();
                txtusername.Text = "";
                txtArmyNumber.Text = "";
                txtStartDate.Text = "";
                txtEndDate.Text = "";
                getUserCode();
                rgdUser.DataBind();
                btnSubmit.Text = "Submit";
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void ddlRole_DataBound(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlSender = (DropDownList)sender;
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlSender.Items.Insert(0, li);
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
                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string FirstName = Convert.ToString(arg[1]);
                string LastName = Convert.ToString(arg[2]);
                string User_name = Convert.ToString(arg[3]);
                string UserCode = Convert.ToString(arg[4]);
                Boolean IsActive = Convert.ToBoolean(arg[5]);
                string password = Convert.ToString(arg[6]);
                int RoleId = Convert.ToInt32(arg[7]);
                int Country = Convert.ToInt32(arg[8]);
                int State = Convert.ToInt32(arg[9]);
                int City = Convert.ToInt32(arg[10]);
                string Address = Convert.ToString(arg[11]);
                string ContactNo = Convert.ToString(arg[12]);
                hfid.Value = catid.ToString();
                txtArmyNumber.Text = Convert.ToString(arg[13]);
                txtStartDate.Text = Convert.ToDateTime(arg[14]).ToString("dd MM yyyy");
                txtEndDate.Text = Convert.ToDateTime(arg[15]).ToString("dd MM yyyy");
                txtAddress.Text = Address;
                txtContactNo.Text = ContactNo;
                txtFirstName.Text = FirstName;
                txtLastName.Text = LastName;
                txtusername.Text = User_name;
                lblUserCode.Text = UserCode;
                chkIsActive.Checked = IsActive;

                txtpassword.Text = password;
                txtcpassword.Text = password;
                ddlDept.DataBind();
                DeptComp objDept = new DeptComp();
                ddlDept.SelectedValue = (objDept.getDeptByRoleID(RoleId)).ToString();
                ddlRole.DataBind();
                ddlRole.SelectedValue = RoleId.ToString();
                //ddlCountry.DataBind();
               // ddlCountry.SelectedValue = Country.ToString();
                //ddlState.DataBind();
               // ddlState.SelectedValue = State.ToString();
                //ddlCity.DataBind();
                //ddlCity.SelectedValue = City.ToString();

                if (e.CommandName == "Editnew")
                {
                    btnSubmit.Text = "Update";
                }
                else if (e.CommandName == "Active")
                {
                    AdduserEntity objEntity = new AdduserEntity();
                    AddUserComp objuser = new AddUserComp();
                    objEntity.AddedBy = 786;//needs to be updated
                    objEntity.ModifiedBy = 786;//needs update
                    objEntity.Address = txtAddress.Text;
                    //objEntity.City = Convert.ToInt32(ddlCity.SelectedItem.Value);
                    objEntity.ContactNo = txtContactNo.Text;
                   // objEntity.Country = int.Parse(ddlCountry.SelectedItem.Value);
                    objEntity.FirstName = char.ToUpper(txtFirstName.Text[0]) + txtFirstName.Text.Substring(1);
                    if (IsActive == true)
                        objEntity.IsActive = 0;
                    else
                        objEntity.IsActive = 1;
                    objEntity.LastName = char.ToUpper(txtLastName.Text[0]) + txtLastName.Text.Substring(1);
                    objEntity.Password = txtpassword.Text;
                    objEntity.RoleId = int.Parse(ddlRole.SelectedItem.Value);
                    //objEntity.State = int.Parse(ddlState.SelectedItem.Value);
                    objEntity.User_name = txtusername.Text;
                    objEntity.UserCode = lblUserCode.Text;



                    objEntity.User_id = Convert.ToInt32(hfid.Value);
                    objuser.Update(objEntity);
                    if (IsActive == true)
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User inactivated successfully!');", true);
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User activated successfully!');", true);

                    _Clear();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean _CheckUserName()
        {
            AddUserComp objuser = new AddUserComp();
            Boolean exist = objuser.IsUserNameExist(txtusername.Text);
            if (exist == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Username already Exists, try another !');", true);

                txtusername.BorderColor = System.Drawing.Color.Red;
                txtusername.Focus();
                return true;
            }
            else
            {
                txtusername.BorderColor = System.Drawing.Color.White;
                return false;
            }
        }
        protected void txtusername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _CheckUserName();
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
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlDept.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtLastName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtusername.Text = txtFirstName.Text + "." + txtLastName.Text + DateTime.Now.Month.ToString();
                _CheckUserName();
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