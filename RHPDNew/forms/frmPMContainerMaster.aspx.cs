using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class frmPMContainerMaster : System.Web.UI.Page
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
                    PMandContainerMaster objcmd = new PMandContainerMaster();

                    var item = db.PMandContainerMasters.SingleOrDefault(s => s.MaterialName == txtMaterialName.Text && s.Capacity == txtCapacity.Text && s.Grade == txtGrade.Text && s.Condition == txtCondition.Text); 
                    if (item != null)
                    {
                        lblMessage.Text = "PM/Conatainer already exists !!";
                    }
                    else
                    {
                        objcmd.MaterialName = txtMaterialName.Text;
                        objcmd.Capacity = txtCapacity.Text;
                        objcmd.Grade = txtGrade.Text;
                        objcmd.Condition = txtCondition.Text;
                        db.PMandContainerMasters.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.PMandContainerMasters
                                    where emp.Id == defIndex
                                    select emp;
                        PMandContainerMaster objcmd = query.SingleOrDefault();
                       
                        objcmd.MaterialName = txtMaterialName.Text;
                        objcmd.Capacity = txtCapacity.Text;
                        objcmd.Grade = txtGrade.Text;
                        objcmd.Condition = txtCondition.Text;                       
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
            bindgrid();
            txtMaterialName.Text = "";
            txtCapacity.Text = "";
            txtGrade.Text = "";
            txtCondition.Text = "";
            hfid.Value = "0";
            btnSubmit.Text = "Submit";
        }
        private void bindgrid()
        {
            try
            {
                rhpdEntities db = new rhpdEntities();
                var cmdlist = from cmdlis in db.PMandContainerMasters select cmdlis;
                List<PMandContainerMaster> result = cmdlist.ToList();
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

                var objcmd = db.PMandContainerMasters.Single(s => s.Id == defIndex);

                if (objcmd != null)
                {
                   

                    txtMaterialName.Text = objcmd.MaterialName;
              txtCapacity.Text  =    objcmd.Capacity ;
                 txtGrade.Text=   objcmd.Grade ;
               txtCondition.Text=      objcmd.Condition;
               hfid.Value = objcmd.Id.ToString();
                    btnSubmit.Text = "Update";
                    
                }
            }
            else if (e.CommandName.ToString() == "DeleteRecord")
            {

                PMandContainerMaster objcmd = new PMandContainerMaster() { Id = Convert.ToInt32(e.CommandArgument) };
                db.PMandContainerMasters.Attach(objcmd);
                db.PMandContainerMasters.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }

    }
}