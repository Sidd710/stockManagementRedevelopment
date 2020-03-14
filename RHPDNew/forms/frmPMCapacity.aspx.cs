using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class frmPMCapacity : System.Web.UI.Page
    {
        rhpdEntities db = new rhpdEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _Bind();
            }
        }

        private void _Bind()
        {
           
            txtUnit.Text = "";
            cbxActive.Checked = true;
            hfid.Value = "";
            var data = db.PMCapacities.ToList();
            rgdName.DataSource = data;
            rgdName.DataBind();
            catid = 0;
        }
        int catid;
        protected void rgdName_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

            catid = Convert.ToInt32(arg[0]);
            string Name = Convert.ToString(arg[1]);

            string Isactive = Convert.ToString(arg[2]);
            bool isA = Convert.ToBoolean(Isactive);
            //decimal capacity = Convert.ToDecimal(arg[3]);
            if (e.CommandName == "pEdit")
            {
                cbxActive.Checked = isA;
                hfid.Value = catid.ToString();
                txtUnit.Text = Name;
                btnSubmit.Text = "Update";
              //  txtCapacity.Text = capacity.ToString();

            }
            else if (e.CommandName == "Active")
            {

                LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                {
                    var defIndex = catid;
                    rhpdEntities db = new rhpdEntities();
                    var query = from emp in db.PMCapacities
                                where emp.Id == defIndex
                                select emp;
                    PMCapacity objcmd = query.Single();
                    objcmd.Id = catid;
                    objcmd.Unit = Name;
                    objcmd.Capacity = 0;
                    if (isA == true)
                        objcmd.IsActive = false;
                    else
                        objcmd.IsActive = true;
                    objcmd.Modified = System.DateTime.Now;
                    db.SaveChanges();
                    lblMessage.Text = "Record Updated !!";
                }
                if (isA == true)
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been inActivated');", true);
                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been activated');", true);
                }
                _Bind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    rhpdEntities db = new rhpdEntities();
                    PMCapacity objcmd = new PMCapacity();

                    var defIndex = (txtUnit.Text).ToString();
                   // decimal cap = Convert.ToDecimal(txtCapacity.Text);
                    var item = db.PMCapacities.SingleOrDefault(s => s.Unit == defIndex);
                    if (item != null)
                    {
                        lblMessage.Text = "Capacity already Exists !!";
                    }
                    else
                    {

                        objcmd.Unit = txtUnit.Text;
                        objcmd.IsActive = cbxActive.Checked;
                        objcmd.Capacity =0;
                        objcmd.AddedOn = System.DateTime.Now;

                        db.PMCapacities.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.PMCapacities
                                    where emp.Id == defIndex
                                    select emp;
                        PMCapacity objcmd = query.Single();
                        objcmd.Id = Convert.ToInt32(hfid.Value);
                        objcmd.Unit = txtUnit.Text;
                        objcmd.IsActive = cbxActive.Checked;
                        objcmd.Capacity = 0;
                        objcmd.Modified = System.DateTime.Now;
                        db.SaveChanges();
                        lblMessage.Text = "Record Updated !!";
                    }
                    else
                    {
                        lblMessage.Text = "Select Record First !!";
                    }

                    btnSubmit.Text = "Submit";
                    hfid.Value = "";

                }
                _Bind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            _Bind();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {

                rgdName.ExportSettings.ExportOnlyData = true;
                rgdName.ExportSettings.IgnorePaging = true;
                rgdName.ExportSettings.OpenInNewWindow = true;
                rgdName.ExportSettings.FileName = "PM_CapacityList_" + DateTime.Now.Date.ToString();

                rgdName.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}