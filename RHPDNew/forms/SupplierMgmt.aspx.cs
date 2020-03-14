using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class SupplierMgmt : System.Web.UI.Page
    {
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    rhpdEntities db = new rhpdEntities();
                    supplier objcmd = new supplier();

                    var defIndex = (txtSupplierName.Text).ToString();
                    // txtCommandName.Text=.
                    var item = db.suppliers.SingleOrDefault(s => s.Name == defIndex);
                    if (item != null)
                    {
                        lblMessage.Text = "Name Already Exist !!";
                    }
                    else
                    {
                        objcmd.Name = txtSupplierName.Text;
                        objcmd.Address = txtDesc.Text;
                        objcmd.IsActivated = chkIsActive.Checked;
                        objcmd.ContactNo = Convert.ToInt64(txtContactNo.Text);
                        db.suppliers.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.suppliers
                                    where emp.Id == defIndex
                                    select emp;
                        supplier objcmd = query.SingleOrDefault();

                        //  CommandMaster objcmd = new CommandMaster();
                        objcmd.Id = Convert.ToInt32(hfid.Value);
                        objcmd.Name = txtSupplierName.Text;
                        objcmd.Address = txtDesc.Text;
                        objcmd.IsActivated = chkIsActive.Checked;
                        // objcmd.Addedby = 1;
                        // objcmd.Addedon = System.DateTime.Now;
                        objcmd.ContactNo = Convert.ToInt64(txtContactNo.Text);
                        //  db.CommandMasters.Add(objcmd);
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
                clear();
                bindgrid();

            }
            catch (Exception)
            {

                throw;
            }


        }

        private void clear()
        {
            txtSupplierName.Text = "";
            txtDesc.Text = "";
            txtContactNo.Text = "";
        }
        private void bindgrid()
        {
            try
            {
                rhpdEntities db = new rhpdEntities();
                var cmdlist = from cmdlis in db.suppliers select cmdlis;
                List<supplier> result = cmdlist.ToList();
                grdFormation.DataSource = result;
                grdFormation.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void grdFormation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            rhpdEntities db = new rhpdEntities();
            if (e.CommandName.ToString() == "UpdateRecord")
            {

                //    var cmdlist = from cmdlis in db.CommandMasters where cmdlis.Id==4 select cmdlis;
                //List<CommandMaster> result = cmdlist.ToList();

                var defIndex = Convert.ToInt16(e.CommandArgument);
                // txtCommandName.Text=.
                var item = db.suppliers.Single(s => s.Id == defIndex);
                if (item != null)
                {
                    //Record exists.Let's read the Name property value
                    txtSupplierName.Text = item.Name;
                    txtDesc.Text = item.Address;
                    txtContactNo.Text = item.ContactNo.ToString();
                    chkIsActive.Checked = Convert.ToBoolean(item.IsActivated);
                    hfid.Value = item.Id.ToString();
                    btnSubmit.Text = "Update";
                    // do something with theName now
                }
            }
            else if (e.CommandName.ToString() == "DeleteRecord")
            {

                supplier objcmd = new supplier() { Id = Convert.ToInt32(e.CommandArgument) };
                db.suppliers.Attach(objcmd);
                db.suppliers.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }

    }

}