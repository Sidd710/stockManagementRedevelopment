using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class frmAddPMContainer : System.Web.UI.Page
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
                    clear();
                }
            }
        }
        protected void ddlselectCat_DataBound(object sender, EventArgs e)
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int pmcID = 0;

                if (apPMC.Entries.Count == 0 && hdnPMC.Value=="")
                {
                    lblPMC.Text = "Select PM/Container first!";
                    return;
                }
                else if (apPMC.Entries.Count == 0 && hdnPMC.Value!="")
                {
                    
                        pmcID = int.Parse(hdnPMC.Value);
                }
                else
                    pmcID = int.Parse(apPMC.Entries[0].Value);
                int CID = int.Parse(ddlselectCat.SelectedItem.Value);
                if (btnSubmit.Text == "Submit")
                {
                    rhpdEntities db = new rhpdEntities();

                    var item = db.AddPMContainers.Where(s => s.PMID == pmcID).Where(s=>s.CategoryID==CID).SingleOrDefault();
                    if (item != null)
                    {
                        var query = from emp in db.AddPMContainers
                                    where emp.PMID == pmcID 
                                    select emp;
                        AddPMContainer objcmd = query.Where(s => s.CategoryID == CID).SingleOrDefault();
                        objcmd.PMID = pmcID;
                     
                            objcmd.Quantity = objcmd.Quantity + Convert.ToDecimal(txtQty.Text);
                        
                        objcmd.CategoryID = int.Parse(ddlselectCat.SelectedItem.Value);
                        objcmd.DateOfReceival = txtReceivedDate.SelectedDate;                        
                        objcmd.ModidfiedOn = DateTime.Now;
                       
                      
                        db.SaveChanges();
                    }
                    else
                    {
                        AddPMContainer objcmd = new AddPMContainer();
                        objcmd.PMID = pmcID;
                      
                            objcmd.Quantity = Convert.ToDecimal(txtQty.Text);
                        
                        objcmd.DateOfReceival = txtReceivedDate.SelectedDate;
                        objcmd.CategoryID = int.Parse(ddlselectCat.SelectedItem.Value);
                        objcmd.AddedBy = 1;
                        objcmd.AddedOn = DateTime.Now;                       
                        db.AddPMContainers.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.AddPMContainers
                                    where emp.ID == defIndex
                                    select emp;
                        AddPMContainer objcmd = query.SingleOrDefault();

                        objcmd.PMID = pmcID;
                       
                            objcmd.Quantity = Convert.ToDecimal(txtQty.Text);
                      
                        objcmd.DateOfReceival = txtReceivedDate.SelectedDate;
                                                objcmd.ModidfiedOn = DateTime.Now;
                                                objcmd.CategoryID = int.Parse(ddlselectCat.SelectedItem.Value);
                                              
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
            ddlselectCat.DataBind();
            bindgrid();
            txtReceivedDate.SelectedDate = DateTime.Now;
            txtQty.Text = "";
            apPMC.Entries.Clear();
            hfid.Value = "0";
            btnSubmit.Text = "Submit";
            hdnPMC.Value = "";
            lblPMC.Text = "";
           
        }
        private void bindgrid()
        {
            try
            {
                
                    rhpdEntities db = new rhpdEntities();
                    var cmdlist = from cmdlis in db.AddPMContainers select cmdlis;
                    List<AddPMContainer> result = cmdlist.ToList();
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

                var objcmd = db.AddPMContainers.Single(s => s.ID == defIndex);

                if (objcmd != null)
                {
                    ddlselectCat.SelectedValue = objcmd.CategoryID.ToString();
                    txtQty.Text = objcmd.Quantity.ToString();
                    txtReceivedDate.SelectedDate = objcmd.DateOfReceival;
                    lblPMC.Text = "[ " + objcmd.PMandContainerMaster.MaterialName + "_" + objcmd.PMandContainerMaster.Capacity + "_" + objcmd.PMandContainerMaster.Grade + "_" + objcmd.PMandContainerMaster.Condition + "]";
                    hdnPMC.Value = objcmd.PMID.ToString(); ;
                
                    hfid.Value = objcmd.ID.ToString();
                    btnSubmit.Text = "Update";
                   
                   

                }
            }
            else if (e.CommandName.ToString() == "DeleteRecord")
            {

                AddPMContainer objcmd = new AddPMContainer() { ID = Convert.ToInt32(e.CommandArgument) };
                db.AddPMContainers.Attach(objcmd);
                db.AddPMContainers.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }
    }
}