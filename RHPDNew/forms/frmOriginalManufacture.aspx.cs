using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class frmOriginalManufacture : System.Web.UI.Page
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

                    OriginalManufacture_ objcmd = new OriginalManufacture_();

                    var defIndex = (txtSupplierName.Text).ToString();
                    // txtCommandName.Text=.
                    var item = db.OriginalManufacture_.SingleOrDefault(s => s.Name == defIndex);
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
                        db.OriginalManufacture_.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.OriginalManufacture_
                                    where emp.Id == defIndex
                                    select emp;
                        OriginalManufacture_ objcmd = query.SingleOrDefault();

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
                var cmdlist = from cmdlis in db.OriginalManufacture_ select cmdlis;
                List<OriginalManufacture_> result = cmdlist.ToList();
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
                var item = db.OriginalManufacture_.Single(s => s.Id == defIndex);
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

                OriginalManufacture_ objcmd = new OriginalManufacture_() { Id = Convert.ToInt32(e.CommandArgument) };
                db.OriginalManufacture_.Attach(objcmd);
                db.OriginalManufacture_.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }

    }
}