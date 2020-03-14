using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class frmWarehouse : System.Web.UI.Page
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

                    tblWarehouse objcmd = new tblWarehouse();

                    var defIndex = (txtSupplierName.Text).ToString();
                    // txtCommandName.Text=.
                    var item = db.tblWarehouses.SingleOrDefault(s => s.WareHouseNo == defIndex);
                    if (item != null)
                    {
                        lblMessage.Text = "WareHouse No Already Exist !!";
                    }
                    else
                    {
                        objcmd.WareHouseNo = txtSupplierName.Text;                       
                        objcmd.IsActive = chkIsActive.Checked;
                        objcmd.AddedOn = DateTime.Now;
                        objcmd.AddedBy = 1;
                        db.tblWarehouses.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.tblWarehouses
                                    where emp.ID == defIndex
                                    select emp;
                        tblWarehouse objcmd = query.SingleOrDefault();

                       
                        objcmd.ID = Convert.ToInt32(hfid.Value);
                        objcmd.WareHouseNo = txtSupplierName.Text;
                        objcmd.IsActive = chkIsActive.Checked;
                        objcmd.ModifiedOn = DateTime.Now;
                        objcmd.ModifiedBy = 1;
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
           
        }
        private void bindgrid()
        {
            try
            {
                rhpdEntities db = new rhpdEntities();
                var cmdlist = from cmdlis in db.tblWarehouses select cmdlis;
                List<tblWarehouse> result = cmdlist.ToList();
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

                
                var defIndex = Convert.ToInt16(e.CommandArgument);
                
                var item = db.tblWarehouses.Single(s => s.ID == defIndex);
                if (item != null)
                {
                    //Record exists.Let's read the Name property value
                    txtSupplierName.Text = item.WareHouseNo;
                   
                    chkIsActive.Checked = Convert.ToBoolean(item.IsActive);
                    hfid.Value = item.ID.ToString();
                    btnSubmit.Text = "Update";
                    // do something with theName now
                }
            }
            else if (e.CommandName.ToString() == "DeleteRecord")
            {

                tblWarehouse objcmd = new tblWarehouse() { ID = Convert.ToInt32(e.CommandArgument) };
                db.tblWarehouses.Attach(objcmd);
                db.tblWarehouses.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }

    }
}