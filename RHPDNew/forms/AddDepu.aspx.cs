using RHPDComponent;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDDalc;

namespace RHPDNew.Forms
{
    public partial class AddDepu : System.Web.UI.Page
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
                        AdddepuComp objdepu = new AdddepuComp();
                        lblCode.Text = objdepu.getCode();
                        // griddisplay();
                    }
                }
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
                txtDepuDesc.Text = string.Empty;
                txtDepuName.Text = string.Empty;
                txtUnitName.Text = "";
                txtdepotNo.Text = "";
                txtCorp.Text = "";
                cbxAWS.Checked = false;
                cbxICT.Checked = false;
                cbxIDT.Checked = false;
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
                    AddDepuEntity objdepuentity = new AddDepuEntity();
                    AdddepuComp objdepu = new AdddepuComp();

                    //bool flag = objdepu.Ischeckparent();
                    //if (flag.ToString() == "True")
                    //{
                    //   // ModalPopupExtender1.Show();
                    //}
                    //else if(flag.ToString()=="False")
                    //{
                   // objdepuentity.CommandId = Convert.ToInt32(ddlCommand.SelectedItem.Value);
                    objdepuentity.FormationId = Convert.ToInt32(ddlformation.SelectedItem.Value);
                    objdepuentity.ICT = ""; if (cbxICT.Checked) objdepuentity.ICT = "ICT";
                    objdepuentity.IDT = ""; if (cbxIDT.Checked) objdepuentity.IDT = "IDT";
                    objdepuentity.AWS = ""; if (cbxAWS.Checked) objdepuentity.AWS = "AWS";
                    objdepuentity.Corp = txtCorp.Text;
                    objdepuentity.DepotNo = txtdepotNo.Text;
                    objdepuentity.Depu_name = txtDepuName.Text;
                    objdepuentity.Depu_location = txtDepuDesc.Text;
                    if (chkIsActive.Checked == true)
                    {
                        objdepuentity.Isactive = 1;
                    }
                    else
                    {
                        objdepuentity.Isactive = 0;
                    }

                    if (chkIsPArent.Checked == true)
                    {
                        objdepuentity.Isparent = 1;
                        objdepuentity.UnitName = txtUnitName.Text;
                    }
                    else
                    {
                        objdepuentity.Isparent = 0;
                    }
                    if (visiblelblmsg.Value.Trim() == "done")
                    {
                        objdepuentity.Status = "done";
                    }
                    else
                    {
                        objdepuentity.Status = "pending";
                    }

                    DataTable dt = (DataTable)(Session["UserDetails"]);
                    if (dt.Rows.Count > 0)
                    {
                        objdepuentity.Addedby = Convert.ToInt32(dt.Rows[0]["User_ID"]);
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    //objdepuentity.Addedby = 123; Default.aspx
                    objdepuentity.Depot_code = lblCode.Text;
                    Int32 r = objdepu.insertcomponent(objdepuentity);
                    if (r > 0)
                    {
                        lblMessage.Text = "Submitted Successfully";
                        Clear();
                    }
                    else
                    {
                        if (r == -1)
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "name();", true);
                        }
                        else if (r == -2)
                        {
                            // open javascript and check and get the value then proceed
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "javascript:return confirm('Are you sure you want to update');",true);
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "example();", true);
                            return;
                        }
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                    //}
                    // griddisplay();
                }


                if ((btnSubmit.Text == "Update"))
                {
                    AdddepuComp objaddde = new AdddepuComp();
                    AddDepuEntity objaddent = new AddDepuEntity();

                    AdddepuComp objadddepu = new AdddepuComp();
                    AddDepuEntity objaddentity = new AddDepuEntity();
                   // objaddentity.CommandId = Convert.ToInt32(ddlCommand.SelectedItem.Value);
                    objaddentity.FormationId = Convert.ToInt32(ddlformation.SelectedItem.Value);
                    objaddentity.Corp = txtCorp.Text;
                    objaddentity.DepotNo = txtdepotNo.Text;
                    objaddentity.Depu_id = Convert.ToInt32(hfid.Value);
                    objaddentity.ICT = ""; if (cbxICT.Checked) objaddentity.ICT = "ICT";
                    objaddentity.IDT = ""; if (cbxIDT.Checked) objaddentity.IDT = "IDT";
                    objaddentity.AWS = ""; if (cbxAWS.Checked) objaddentity.AWS = "AWS";
                    objaddentity.Depu_name = txtDepuName.Text;
                    objaddentity.Depu_location = txtDepuDesc.Text;
                    if (chkIsActive.Checked == true)
                    {
                        objaddentity.Isactive = 1;
                    }
                    else
                    {
                        objaddentity.Isactive = 0;
                    }
                    if (chkIsPArent.Checked == true)
                    {

                        objaddentity.Isparent = 1;
                        objaddentity.UnitName = txtUnitName.Text;
                    }
                    else
                    {
                        objaddentity.Isparent = 0;
                    }

                    if (visiblelblmsg.Value.Trim() == "done")
                    {
                        objaddentity.Status = "done";
                    }
                    else
                    {
                        objaddentity.Status = "pending";
                    }
                    objaddentity.Modificationby = 465;
                    int r = objadddepu.updatecomponent(objaddentity);
                    if (r > 0)
                    {
                        lblMessage.Text = "Update Successful";
                        Clear();
                        btnSubmit.Text = "Submit";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                    }
                    else
                    {
                        if (r == -1)
                        {// name exits
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "name();", true);
                        }
                        else if (r == -2)
                        {
                            // open javascript and check and get the value then proceed
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "javascript:return confirm('Are you sure you want to update');",true);
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "example();", true);
                            return;
                        }
                        else if (r == -3)
                        {
                            // open javascript and check and get the value then proceed
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "javascript:return confirm('Are you sure you want to update');",true);
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "parent();", true);
                            return;
                        }
                    }





                }
                RadGrid.DataBind();
            }

            catch (Exception)
            {

                throw;
            }


        }

        private void Clear()
        {
            txtDepuName.Text = string.Empty;
            txtDepuDesc.Text = string.Empty;
            //chkIsActive.Checked = false;
            lblMessage.Visible = false;
            visiblelblmsg.Value = "";
            ddlformation.SelectedIndex = -1;
           // ddlCommand.SelectedIndex = -1;
            txtCorp.Text="";
            txtdepotNo.Text = "";
            txtUnitName.Text = "";
            cbxICT.Checked = false;
          cbxIDT.Checked= false;
          cbxAWS.Checked = false;
        }


        public void griddisplay()
        {
            try
            {
                DataTable dt3 = new DataTable();
                AdddepuComp objadddepu = new AdddepuComp();
                dt3 = objadddepu.GridDisplayComponent();
                if (dt3.Rows.Count > 0)
                {
                    RadGrid.DataSource = dt3;
                    RadGrid.DataBind();

                }
                else
                {
                    lblMessage.Text = "There is no row in grid";
                }
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


                    string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                    catid = Convert.ToInt32(arg[0]);
                    string DepuName = Convert.ToString(arg[1]);
                    string DepuDesc = Convert.ToString(arg[2]);
                    bool isActive = Convert.ToBoolean(arg[3]);
                    string depotcode = Convert.ToString(arg[4]);
                    bool isparent = Convert.ToBoolean(arg[5]);
                    string UnitName = Convert.ToString(arg[10]);
                    string IDT = Convert.ToString(arg[11]);
                    string ICT = Convert.ToString(arg[12]);
                    string AWS = Convert.ToString(arg[13]);
                    hfid.Value = catid.ToString();
                    if (IDT != "") cbxIDT.Checked = true; else cbxIDT.Checked = false;
                    if (ICT != "") cbxICT.Checked = true; cbxICT.Checked = false;
                    if (AWS != "") cbxAWS.Checked = true; cbxAWS.Checked = false;
                   
                   
                    txtDepuName.Text = DepuName;
                    txtDepuDesc.Text = DepuDesc;
                    chkIsActive.Checked = isActive;
                    lblCode.Text = depotcode;
                    chkIsPArent.Checked = isparent;
                    //ddlCommand.SelectedValue = Convert.ToString(arg[6]);
                    ddlformation.SelectedValue = Convert.ToString(arg[7]);
                    txtCorp.Text = Convert.ToString(arg[8]);
                    txtdepotNo.Text = Convert.ToString(arg[9]);
                    btnSubmit.Text = "Update";

                }
                else if (e.CommandName == "Active")
                {
                    string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                    catid = Convert.ToInt32(arg[0]);
                    string argt = Convert.ToString(arg[1]);
                    LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                    AdddepuComp objadddepu = new AdddepuComp();
                    AddDepuEntity objaddentity = new AddDepuEntity();
                    if (Convert.ToBoolean(argt) == true)
                    {
                        objaddentity.Isactive = 0;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been inActivated');", true);
                    }
                    else
                    {
                        objaddentity.Isactive = 1;
                    }
                    objaddentity.Depu_id = catid;
                    objadddepu.ActiveInactivate(objaddentity);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The record has been Activated');", true);



                }
                // griddisplay();
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
                RadGrid.ExportSettings.FileName = "DepotList_" + DateTime.Now.Date.ToString();

                RadGrid.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click1(object sender, EventArgs e)
        {
            try
            {
                txtDepuName.Text = string.Empty;
                txtDepuDesc.Text = string.Empty;
                AdddepuComp objdepu = new AdddepuComp();
                lblCode.Text = objdepu.getCode();
                txtUnitName.Text = ""; cbxICT.Checked = false;
                cbxIDT.Checked = false;
                cbxAWS.Checked = false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {

                    AddDepuEntity objdepuentity = new AddDepuEntity();
                    AdddepuComp objdepu = new AdddepuComp();
                    objdepu.removeParent();
                    objdepuentity.Depu_name = txtDepuName.Text;
                    objdepuentity.Depu_location = txtDepuDesc.Text;
                    if (chkIsActive.Checked == true)

                        objdepuentity.Isactive = 1;

                    else
                        objdepuentity.Isactive = 0;


                    objdepuentity.Isparent = 1;
                    objdepuentity.UnitName = txtUnitName.Text;
                    objdepuentity.ICT = ""; if (cbxICT.Checked) objdepuentity.ICT = "ICT";
                    objdepuentity.IDT = ""; if (cbxIDT.Checked) objdepuentity.IDT = "IDT";
                    objdepuentity.AWS = ""; if (cbxAWS.Checked) objdepuentity.AWS = "AWS";
                    objdepuentity.Depot_code = lblCode.Text;
                    objdepu.insertcomponent(objdepuentity);

                }
                else if (btnSubmit.Text == "Update")
                {
                    AdddepuComp objadddepu = new AdddepuComp();
                    AddDepuEntity objaddentity = new AddDepuEntity();
                    objadddepu.removeParent();
                    //      if (flag.ToString() == "True")
                    //    {
                    //        ModalPopupExtender1.Show();
                    //   }
                    //   else if (flag.ToString() == "False")
                    //   {
                    objaddentity.Depu_id = Convert.ToInt32(hfid.Value);
                    objaddentity.ICT = ""; if (cbxICT.Checked) objaddentity.ICT = "ICT";
                    objaddentity.IDT = ""; if (cbxIDT.Checked) objaddentity.IDT = "IDT";
                    objaddentity.AWS = ""; if (cbxAWS.Checked) objaddentity.AWS = "AWS";
                    //   objadddepu. = Convert.ToInt32(hfid.Value);
                    objaddentity.Depu_name = txtDepuName.Text;
                    objaddentity.Depu_location = txtDepuDesc.Text;
                    if (chkIsActive.Checked == true)
                    {
                        objaddentity.Isactive = 1;
                    }
                    else
                    {
                        objaddentity.Isactive = 0;
                    }
                    if (chkIsPArent.Checked == true)
                    {

                        objaddentity.Isparent = 1;
                    }
                    else
                    {
                        objaddentity.Isparent = 0;
                    }
                    objadddepu.updatecomponent(objaddentity);
                    txtDepuName.Text = string.Empty;

                    txtDepuDesc.Text = string.Empty;
                    chkIsActive.Checked = false;
                    lblMessage.Visible = false;
                    lblMessage.Text = "Update Successful";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);

                    btnSubmit.Text = "Submit";
                }
                //  }
                RadGrid.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddDepuEntity objdepuentity = new AddDepuEntity();
                AdddepuComp objdepu = new AdddepuComp();

                objdepuentity.Depu_name = txtDepuName.Text;
                objdepuentity.Depu_location = txtDepuDesc.Text;
                objdepuentity.ICT = ""; if (cbxICT.Checked) objdepuentity.ICT = "ICT";
                objdepuentity.IDT = ""; if (cbxIDT.Checked) objdepuentity.IDT = "IDT";
                objdepuentity.AWS = ""; if (cbxAWS.Checked) objdepuentity.AWS = "AWS";
                if (chkIsActive.Checked == true)

                    objdepuentity.Isactive = 1;

                else
                    objdepuentity.Isactive = 0;


                if (chkIsPArent.Checked == true)
                {

                    objdepuentity.Isparent = 1;
                    objdepuentity.UnitName = txtUnitName.Text;
                }
                else
                {
                    objdepuentity.Isparent = 0;
                }

                objdepuentity.Depot_code = lblCode.Text;
                objdepu.insertcomponent(objdepuentity);
                RadGrid.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

    
        protected void ddlformation_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlformation.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

      



    }
}