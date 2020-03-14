using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDEntity;
using RHPDComponent;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class GateInOutRegister : System.Web.UI.Page
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
                    hdf.Value = string.Empty;
                    try
                    {
                        if ((Page.Request["id"]) != null)
                        {
                            if ((Request.QueryString["id"]) != null)
                            {
                                int id = Convert.ToInt32(Request.QueryString["id"]);
                                if (id > 0)
                                {
                                    hdf.Value = id.ToString();
                                    GateInOutEntity objentity = new GateInOutEntity();
                                    GateInOutComp objcom = new GateInOutComp();
                                    objentity.IdtId1 = id;
                                    objentity.Action = "SelectGateOut";
                                    DataTable dt = objcom.SelectGateOut(objentity);
                                    if (dt.Rows.Count > 0)
                                    {
                                        if ((Convert.ToString(dt.Rows[0]["IsUnit"])) == "true")
                                        {
                                            unit.Visible = true;
                                            rfvddlUnitMaster.ValidationGroup = "grp";
                                            btnSubmit.Visible = true;

                                            ddlDepoName.DataBind();
                                            ddlDepoName.SelectedValue = Convert.ToString(dt.Rows[0]["DepuMasterId"]);
                                            ddlUnitMaster.DataBind();
                                            ddlUnitMaster.SelectedValue = Convert.ToString(dt.Rows[0]["UnitMasterId"]);

                                            txtVechicleNo.Text = Convert.ToString(dt.Rows[0]["VechileNo"]);
                                            txtIRNo.Text = Convert.ToString(dt.Rows[0]["IndentName"]);
                                            lblidentid.Text = Convert.ToString(dt.Rows[0]["IdtId"]);
                                            txtTypeofVehicle.Text = Convert.ToString(dt.Rows[0]["Through"]);

                                        }
                                        else
                                        {
                                            unit.Visible = false;
                                            rfvddlUnitMaster.ValidationGroup = "grpunit";
                                            btnSubmit.Visible = true;

                                            ddlDepoName.DataBind();
                                            ddlDepoName.SelectedValue = Convert.ToString(dt.Rows[0]["DepuMasterId"]);

                                            txtVechicleNo.Text = Convert.ToString(dt.Rows[0]["VechileNo"]);
                                            txtIRNo.Text = Convert.ToString(dt.Rows[0]["IndentName"]);
                                            lblidentid.Text = Convert.ToString(dt.Rows[0]["IdtId"]);
                                            txtTypeofVehicle.Text = Convert.ToString(dt.Rows[0]["Through"]);
                                        }
                                    }
                                    else
                                    {
                                        lblMessage.Visible = true;
                                        lblMessage.Text = "Something went wrong";
                                    }
                                }
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Something went wrong";
                            }
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Something went wrong";
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        private void bindgrid()
        {
            try
            {
                 GateInOutEntity objentity = new GateInOutEntity();
                 GateInOutComp objcom = new GateInOutComp();
                 objentity.Action = "SelectallGate";
                 DataTable dt = objcom.SelectallGate(objentity);
                 if(dt.Rows.Count>0)
                 {
                     radGateout.DataSource = dt;
                     radGateout.DataBind();
                 }
                 else
                 {
                     radGateout.DataSource = null;
                     radGateout.DataBind();
                 }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void ddlQuantitytype_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlQuantitytype.Items.Insert(0, li);
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
                if (Page.Request["id"] != null)
                {
                    lblMessage.Visible = false; lblMessage.Text = string.Empty;
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    if (hdf.Value == id.ToString())
                    {
                        if (id > 0)
                        {
                            GateInOutEntity objentity = new GateInOutEntity();
                            GateInOutComp objcom = new GateInOutComp();
                            objentity.Vehbano = txtVechicleNo.Text;
                            objentity.Franchiseeno = null;
                            objentity.ArmyNo = txtArmyNo.Text;
                            objentity.Rank = txtRank.Text;
                            objentity.Name = txtName.Text;
                            objentity.Timein = radtimein.SelectedDate.Value;
                            objentity.Typeofvehicle = txtTypeofVehicle.Text;
                            objentity.UnitQuantityTypeId = Convert.ToInt32(ddlQuantitytype.SelectedValue);
                            objentity.Loadin = null;
                            objentity.IdtId1 = Convert.ToInt32(lblidentid.Text);
                            objentity.Timeout = radTimeOut.SelectedDate.Value;
                            objentity.Loadout = txtLoadOut.Text;
                            objentity.FuelintankIn = txtfuelIn.Text.Trim();
                            objentity.FuelintankOut = txtfuelOut.Text.Trim();
                            objentity.StationDepuID = Convert.ToInt32(ddlDepoName.SelectedValue);
                            objentity.StationUnitId = ddlUnitMaster.SelectedValue == "" ? 0 : Convert.ToInt32(ddlUnitMaster.SelectedValue);
                            objentity.IsActive = true;
                            objentity.AddedBy1 = 123;
                            objentity.ModifiedBy1 = 123;
                            objentity.Action = "insertIntoGateInOut";
                            int r = objcom.insertIntoGateInOut(objentity);
                            if (r > 0)
                            {
                                hdf.Value = string.Empty;
                                lblMessage.Visible = true;
                                lblMessage.Text = "Registered Sucessfully !";
                                bindgrid();
                                Clear();
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Something went wrong";
                            }
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Something went wrong";
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
                Clear();
            }
            catch (Exception)
            {
               
                throw;
            }
        }

        private void Clear()
        {
            try
            { 
                txtVechicleNo.Text = string.Empty;
                txtArmyNo.Text = string.Empty;
                txtRank.Text = string.Empty;
                txtName.Text = string.Empty;
                radtimein.DbSelectedDate = string.Empty;
                txtTypeofVehicle.Text = string.Empty;
                ddlQuantitytype.SelectedIndex = -1;
                txtIRNo.Text = string.Empty;
                lblidentid.Text = string.Empty;
                radTimeOut.DbSelectedDate = string.Empty;
                ddlDepoName.SelectedIndex = -1;
                ddlUnitMaster.SelectedIndex = -1;
                txtfuelIn.Text = string.Empty;
                txtfuelOut.Text = string.Empty;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void radGateout_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            try
            {
                radGateout.DataBind();
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
                radGateout.ExportSettings.ExportOnlyData = true;
                radGateout.ExportSettings.IgnorePaging = true;
                radGateout.ExportSettings.OpenInNewWindow = true;
                radGateout.ExportSettings.FileName = "Esl_List" + DateTime.Now.Date.ToString();

                radGateout.MasterTableView.ExportToExcel();
                Page.Response.ClearHeaders();
                Page.Response.ClearContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void radGateout_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                GateInOutEntity objentity = new GateInOutEntity();
                GateInOutComp objcom = new GateInOutComp();
                objentity.Action = "SelectallGate";
                DataTable dt = objcom.SelectallGate(objentity);
                if (dt.Rows.Count > 0)
                {
                    radGateout.DataSource = dt;
                }
                else
                {
                    radGateout.DataSource = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}