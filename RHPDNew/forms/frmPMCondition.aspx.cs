﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class frmPMCondition : System.Web.UI.Page
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
            txtCondition.Text = "";
            cbxActive.Checked = true;
            hfid.Value = "";
            var data = db.PMConditions.ToList();
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
            if (e.CommandName == "pEdit")
            {


                cbxActive.Checked = isA;
                hfid.Value = catid.ToString();
                txtCondition.Text = Name;
                btnSubmit.Text = "Update";

            }
            else if (e.CommandName == "Active")
            {

                LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                {
                    var defIndex = catid;
                    rhpdEntities db = new rhpdEntities();
                    var query = from emp in db.PMConditions
                                where emp.Id == defIndex
                                select emp;
                    PMCondition objcmd = query.Single();
                    objcmd.Id = catid;
                    objcmd.Condition = Name;
                    if (isA == true)
                        objcmd.IsActive = false;
                    else
                        objcmd.IsActive = true;
                    objcmd.ModifiedOn = System.DateTime.Now;
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
                    PMCondition objcmd = new PMCondition();

                    var defIndex = (txtCondition.Text).ToString();
                    var item = db.PMConditions.SingleOrDefault(s => s.Condition == defIndex);
                    if (item != null)
                    {
                        lblMessage.Text = "Condition Already Exist !!";
                    }
                    else
                    {

                        objcmd.Condition = txtCondition.Text;
                        objcmd.IsActive = cbxActive.Checked;

                        objcmd.AddedOn = System.DateTime.Now;

                        db.PMConditions.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.PMConditions
                                    where emp.Id == defIndex
                                    select emp;
                        PMCondition objcmd = query.Single();
                        objcmd.Id = Convert.ToInt32(hfid.Value);
                        objcmd.Condition = txtCondition.Text;
                        objcmd.IsActive = cbxActive.Checked;
                        objcmd.ModifiedOn = System.DateTime.Now;
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
                rgdName.ExportSettings.FileName = "PM_ConditionList_" + DateTime.Now.Date.ToString();

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