using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using RHPDComponent;
using RHPDEntity;

namespace RHPDNew.Forms
{
    public partial class AddUnit : System.Web.UI.Page
    {
        int catid;
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
                        AddUnitComp objunit = new AddUnitComp();
                        lblCode.Text = objunit.getCode();
                        //   griddisplay();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    
    
        protected void ddlselectdepu_DataBound(object sender, EventArgs e)
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
                if (btnSubmit.Text == "Submit")
                {
                  
                 
               
                        AddunitEntity objunitentity = new AddunitEntity();
                        AddUnitComp objdepu = new AddUnitComp();
                        objunitentity.Depu_id = Convert.ToInt32(ddlselectdepu.SelectedValue);
                           objunitentity.Unit_name = txtUnitName.Text;
                        objunitentity.UnitType = Convert.ToInt32( rbtUnitType.SelectedItem.Value);
                        objunitentity.Unit_desc = txUnitDesc.Text;
                        objunitentity.Unit_code = lblCode.Text;
                        if (chkIsActive.Checked == true)
                        {
                            objunitentity.Isactive = 1;
                        }
                        DataTable dt = new DataTable();
                        dt = objdepu.UnitCheckExist(txtUnitName.Text, Convert.ToInt32(ddlselectdepu.SelectedItem.Value));
                        if (dt.Rows.Count > 0)
                        {
                            //labelt.tex= Name already exit
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This unit name is already exsist');", true);
                            return;
                        }
                        else
                        {
                            objdepu.InsertUnit(objunitentity);
                            txtUnitName.Text = string.Empty;

                            ddlselectdepu.SelectedIndex = -1;
                            txUnitDesc.Text = string.Empty;
                            lblMessage.Visible = false;
                              lblMessage.Text = "Submitted Successfully";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);

                      
                    }
                }
                else if ((btnSubmit.Text == "Update"))
                {
                    AddunitEntity objunitentity = new AddunitEntity();
                    AddUnitComp objunit = new AddUnitComp();

                    objunitentity.Unit_id = Convert.ToInt32(hfid.Value);
                    //   objadddepu. = Convert.ToInt32(hfid.Value);
                    objunitentity.Depu_id = Convert.ToInt32(ddlselectdepu.SelectedItem.Value);
                        objunitentity.Unit_name = txtUnitName.Text;
                    objunitentity.UnitType = Convert.ToInt32(rbtUnitType.SelectedItem.Value);
                    objunitentity.Unit_desc = txUnitDesc.Text;
                    
                    if (chkIsActive.Checked == true)
                    {
                        objunitentity.Isactive = 1;
                    }
                    else
                    {
                        objunitentity.Isactive = 0;
                    }
                    DataTable dt = new DataTable();
                    dt = objunit.updUnitCheckExist(txtUnitName.Text, Convert.ToInt32(ddlselectdepu.SelectedItem.Value), Convert.ToInt32(hfid.Value));
                    if (dt.Rows.Count > 0)
                    {
                        //labelt.tex= Name already exit
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This unit name is already exsist');", true);
                        return;
                    }
                    else
                    {
                        objunit.updateComponent(objunitentity);
                        txtUnitName.Text = string.Empty;
                        ddlselectdepu.SelectedIndex = -1;
                        txUnitDesc.Text = string.Empty;
                        lblMessage.Visible = false;
                       
                       
                        lblMessage.Text = "Update Successful";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);

                        btnSubmit.Text = "Submit";
                    }
                  //  griddisplay();
                }
                RadGrid.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void griddisplay()
        {
            try
            {
                DataTable dt3 = new DataTable();
                AddUnitComp objaddunit = new AddUnitComp();
                dt3 = objaddunit.GridDisplayComponent();
                RadGrid.DataSource = dt3;
                RadGrid.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RadGrid_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editnew")
                {
                    ddlselectdepu.DataBind();
                    string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                    catid = Convert.ToInt32(arg[0]);
                    string UnitName = Convert.ToString(arg[1]);
                   
                   
                    string UnitDesc = Convert.ToString(arg[2]);
                    string Isactive = Convert.ToString(arg[3]);
                    string depu_name = Convert.ToString(arg[4]);
                    string unitcode = Convert.ToString(arg[5]);
                    string depu_id = Convert.ToString(arg[6]);
                    hfid.Value = catid.ToString();
                    //ddlselectdepu.SelectedItem.Text = depu_name.ToString();
                    txtUnitName.Text = UnitName;
                    txUnitDesc.Text = UnitDesc;
                    lblCode.Text = unitcode;

                    ddlselectdepu.DataBind();
                    ddlselectdepu.SelectedValue = depu_id.ToString();
                    rbtUnitType.SelectedValue = Convert.ToString(arg[9]);
                    chkIsActive.Checked = Convert.ToBoolean(Isactive);
                    btnSubmit.Text = "Update";

                }
                else if (e.CommandName == "Active")
                {
                    string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                    catid = Convert.ToInt32(arg[0]);
                    string argt = Convert.ToString(arg[1]);
                    LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                    AddUnitComp objaddunit = new AddUnitComp();
                    AddunitEntity objaddentity = new AddunitEntity();
                    if (Convert.ToBoolean(argt) == true)
                    {
                        objaddentity.Isactive = 0;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been inActivated');", true);
                    }
                    else
                    {
                        objaddentity.Isactive = 1;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been Activated');", true);
                    }
                    objaddentity.Unit_id = catid;
                    objaddunit.ActiveInactivate(objaddentity);
                }
                //  griddisplay();
                RadGrid.DataBind();
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
                RadGrid.ExportSettings.ExportOnlyData = true;
                RadGrid.ExportSettings.IgnorePaging = true;
                RadGrid.ExportSettings.OpenInNewWindow = true;
                RadGrid.ExportSettings.FileName = "UnitList_" + DateTime.Now.Date.ToString();

                RadGrid.MasterTableView.ExportToExcel();
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
                txtUnitName.Text = string.Empty;
                txUnitDesc.Text = string.Empty;
                AddUnitComp objunit = new AddUnitComp();
                lblCode.Text = objunit.getCode();
                ddlselectdepu.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}