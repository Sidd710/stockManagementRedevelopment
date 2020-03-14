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
    public partial class DepartmentMaster : System.Web.UI.Page
    {
        static int dID = 0;
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
                        getDeptCode();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void getDeptCode()
        {
            try
            {
                DeptComp obj = new DeptComp();
                lblDeptCode.Text = obj.getDeptCode();
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
                txtName.Text = "";
                txtDesc.Text = "";
                getDeptCode();
                rgdDept.DataBind();
                cbxActive.Checked = true;
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
                 DeptComp obj = new DeptComp();
                 DeptMasterEntity objEntity = new DeptMasterEntity();
                 objEntity.Description = txtDesc.Text;
                 objEntity.DeptName = char.ToUpper(txtName.Text[0]) + txtName.Text.Substring(1); //txtName.Text;
                 objEntity.DeptCode = lblDeptCode.Text;
                 objEntity.AddedBy = 786;//Need to modify
                 objEntity.Modifiedby = 786;//Need to modify
                 if (cbxActive.Checked == true)
                     objEntity.IsActive = 1;
                 else
                     objEntity.IsActive = 0;
                 if (btnSubmit.Text == "Submit")
                 {

                     DataTable dt = new DataTable();
                     dt = obj.CheckDept(txtName.Text);
                     if (dt.Rows.Count > 0)
                     {
                         //labelt.tex= Name already exit
                         ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This Department is already exsist');", true);
                         return;
                     }
                     else
                     {
                         int dID = obj.Insert(objEntity);
                         ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Department added successfully!');", true);
                        
                     }
                 }
                 else if (btnSubmit.Text == "Update")
                 {
                     DataTable dt = new DataTable();
                     dt = obj.updCheckDept(txtName.Text, Convert.ToInt32(hdnID.Value));
                       if (dt.Rows.Count > 0)
                       {
                           ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This Department is already exsist');", true);
                           return;

                       }
                     objEntity.Id = dID;
                     obj.Update(objEntity);
                     ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Department updated successfully!');", true);
                     btnSubmit.Text = "Submit";
                 }
                _Clear();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
       
        protected void rgdDept_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
              if (e.CommandName == "Editnew")
              {
                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });
                dID = Convert.ToInt32(arg[0]);
                string DeptCode = Convert.ToString(arg[1]);
                string DeptName = Convert.ToString(arg[2]);
                string Description = Convert.ToString(arg[3]);
                bool isActive = Convert.ToBoolean(arg[4]);

                hdnID.Value = dID.ToString();
                txtDesc.Text = Description;
                txtName.Text = DeptName;
                cbxActive.Checked = isActive;
                lblDeptCode.Text = DeptCode;
                btnSubmit.Text = "Update";

              }
              else if (e.CommandName == "Active")
              {
                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                dID = Convert.ToInt32(arg[0]);
                string DeptCode = Convert.ToString(arg[1]);
                string DeptName = Convert.ToString(arg[2]);
                string Description = Convert.ToString(arg[3]);
                bool isActive = Convert.ToBoolean(arg[4]);
                LinkButton lk = (LinkButton)(e.Item.FindControl("lbtnActive"));
                DeptComp obj = new DeptComp();
                DeptMasterEntity objEntity = new DeptMasterEntity();
                objEntity.Description = Description;
                objEntity.DeptName = DeptName;
                objEntity.DeptCode = DeptCode;             
                objEntity.Modifiedby = 786;//Need to modify
                if (isActive == true)
                    objEntity.IsActive = 0;
                else
                    objEntity.IsActive = 1;
                objEntity.Id = dID;
                obj.Update(objEntity);

                _Clear();
              }
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
                rgdDept.ExportSettings.ExportOnlyData = true;
                rgdDept.ExportSettings.IgnorePaging = true;
                rgdDept.ExportSettings.OpenInNewWindow = true;
                rgdDept.ExportSettings.FileName = "DepartmentList_"+DateTime.Now.Date.ToString();
            
                rgdDept.MasterTableView.ExportToExcel();
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