using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Script.Services;
using AjaxControlToolkit;
using Telerik.Web.UI;
using RHPDComponent;
using System.Globalization;

namespace RHPDNew.Forms
{
    public partial class frmSection : System.Web.UI.Page
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
                    var defIndex = (txtSupplierName.Text).ToString();                    
                    var item = db.tblSections.SingleOrDefault(s => s.Section == defIndex);
                    if (item != null)
                    {
                        lblMessage.Text = "Section Already Exist !!";                        
                    }
                    else
                    {
                        tblSection objcmd1 = new tblSection();
                        objcmd1.Section = txtSupplierName.Text;
                        objcmd1.WarehouseID = int.Parse(ddlWarehouse.SelectedItem.Value);
                        objcmd1.SubSection = txtSubSec.Text;
                        objcmd1.Row = int.Parse(txtRows.Text);
                        objcmd1.Col = int.Parse(txtColumns.Text);
                        objcmd1.Drawers = objcmd1.Row * objcmd1.Col;
                        objcmd1.AddedBy = 1;
                        objcmd1.AddedOn = DateTime.Now;
                        db.tblSections.Add(objcmd1); db.SaveChanges();
                       
                    lblMessage.Text = "Record Saved !!";
                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        rhpdEntities db = new rhpdEntities();
                        var query = from emp in db.tblSections
                                    where emp.ID == defIndex
                                    select emp;
                        tblSection objcmd = query.SingleOrDefault();
                        objcmd.Section = txtSupplierName.Text;                     
                        objcmd.WarehouseID = int.Parse(ddlWarehouse.SelectedItem.Value);
                        
                            objcmd.Row = int.Parse(txtRows.Text);
                            objcmd.Col = int.Parse(txtColumns.Text);
                            objcmd.Drawers = objcmd.Row * objcmd.Col;
                            objcmd.SubSection = txtSubSec.Text;
                            objcmd.ModifiedBy = 1;
                        objcmd.ModifiedOn = DateTime.Now;
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
            txtSubSec.Text = "";
            ddlWarehouse.DataBind();
            txtRows.Text = "";
            txtColumns.Text = "";
        }
        private void bindgrid()
        {
            try
            {
              

                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
                SqlCommand cmd = new SqlCommand("spGetWareHouseSections", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Sections");               
                if (con.State.ToString() == "Close")
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rgdWareHouse.DataSource = dt;
                rgdWareHouse.DataBind();

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
               
                var item = db.tblSections.Single(s => s.ID == defIndex);
                if (item != null)
                {
                    //Record exists.Let's read the Name property value
                    txtSupplierName.Text = item.Section; ;
                    txtSubSec.Text = item.SubSection;
                    ddlWarehouse.SelectedValue = item.WarehouseID.ToString();
                    txtRows.Text = item.Row.ToString();
                    txtColumns.Text = item.Col.ToString();
                    hfid.Value = item.ID.ToString();
                    btnSubmit.Text = "Update";
                    // do something with theName now
                }
            }
            else if (e.CommandName.ToString() == "DeleteRecord")
            {

                tblSection objcmd = new tblSection() { ID = Convert.ToInt32(e.CommandArgument) };
                db.tblSections.Attach(objcmd);
                db.tblSections.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }

        protected void ddlWarehouse_DataBound(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "";
                ddl.Items.Insert(0,li);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rgdWareHouse_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            rhpdEntities db = new rhpdEntities();
            if (e.CommandName.ToString() == "UpdateRecord")
            {
                var defIndex = Convert.ToInt16(e.CommandArgument);

                var item = db.tblSections.Single(s => s.ID == defIndex);
                if (item != null)
                {
                    //Record exists.Let's read the Name property value
                    txtSupplierName.Text = item.Section; ;
                    txtSubSec.Text = item.SubSection;
                    ddlWarehouse.SelectedValue = item.WarehouseID.ToString();

                    txtRows.Text = item.Row.ToString();
                    txtColumns.Text = item.Col.ToString();
                    hfid.Value = item.ID.ToString();
                    btnSubmit.Text = "Update";
                    // do something with theName now
                }
            }
            else if (e.CommandName.ToString() == "DeleteRecord")
            {

                tblSection objcmd = new tblSection() { ID = Convert.ToInt32(e.CommandArgument) };
                db.tblSections.Attach(objcmd);
                db.tblSections.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }
    }
}