using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class FrmCommandMaster : System.Web.UI.Page
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
                    CommandMaster objcmd = new CommandMaster();

                      var defIndex = (txtCommandName.Text).ToString();
                    // txtCommandName.Text=.
                    var item = db.CommandMasters.SingleOrDefault(s => s.Name == defIndex);
                    if (item != null)
                    {
                        lblMessage.Text = "Name Already Exist !!";
                    }
                    else
                    {

                        objcmd.Name = txtCommandName.Text;
                        objcmd.Descripition = txDesc.Text;
                        objcmd.IsActive = chkIsActive.Checked;
                        objcmd.Addedby = 1;
                        objcmd.Addedon = System.DateTime.Now;
                        objcmd.Updatedby = 1;
                        objcmd.UndatedOn = System.DateTime.Now;
                        db.CommandMasters.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                    }
                }
                else if(btnSubmit.Text=="Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.CommandMasters
                                    where emp.Id == defIndex
                                       select emp;
                        CommandMaster objcmd = query.Single();

                      //  CommandMaster objcmd = new CommandMaster();
                        objcmd.Id = Convert.ToInt32(hfid.Value);
                        objcmd.Name = txtCommandName.Text;
                        objcmd.Descripition = txDesc.Text;
                        objcmd.IsActive = chkIsActive.Checked;
                        // objcmd.Addedby = 1;
                        // objcmd.Addedon = System.DateTime.Now;
                        objcmd.Updatedby = 1;
                        objcmd.UndatedOn = System.DateTime.Now;
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
            txtCommandName.Text = "";
            txDesc.Text = "";
        }
        private void bindgrid()
        {

            rhpdEntities db = new rhpdEntities();
            var cmdlist = from cmdlis in db.CommandMasters select cmdlis;
           List<CommandMaster> result = cmdlist.ToList();
            GridView1.DataSource = result;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            rhpdEntities db = new rhpdEntities();
            if (e.CommandName.ToString() == "UpdateRecord")
            {

            //    var cmdlist = from cmdlis in db.CommandMasters where cmdlis.Id==4 select cmdlis;
            //List<CommandMaster> result = cmdlist.ToList();

            var defIndex = Convert.ToInt16(e.CommandArgument);
               // txtCommandName.Text=.
            var item = db.CommandMasters.Single(s => s.Id == defIndex);
            if (item != null)
            {
                //Record exists.Let's read the Name property value
                txtCommandName.Text = item.Name;
                txDesc.Text = item.Descripition;
                chkIsActive.Checked = Convert.ToBoolean(item.IsActive);
                hfid.Value = item.Id.ToString();
                btnSubmit.Text = "Update";
                // do something with theName now
            }
            }
            else if (e.CommandName.ToString() == "DeleteRecord")
            {
                
                CommandMaster objcmd = new CommandMaster() { Id=Convert.ToInt32(e.CommandArgument)};
                db.CommandMasters.Attach(objcmd);
                db.CommandMasters.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }
    }
}