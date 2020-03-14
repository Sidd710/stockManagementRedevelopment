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
    public partial class GateRegister : System.Web.UI.Page
    {
         int catid;
         public static DataTable dtmain = new DataTable();
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
                        bindgrid();

                        lblGateOut.Visible = false;
                     //   lblGateIn.Visible = false;
                    }
                }
                 lblGateIn.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void bindgrid()
        {
            try
            {
                GatEntity objentity = new GatEntity();
                GatComponent objcom = new GatComponent();
                //GateInOutEntity objentity = new GateInOutEntity();
                //GateInOutComp objcom = new GateInOutComp();
                objentity.Action = "Selectall";
                DataTable dt = objcom.SelectallGate(objentity);
                if (dt.Rows.Count > 0)
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
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if(rbtnSelectGate.SelectedValue=="0")
                {
                    Gatout.Visible = true;
                    rbtnSelectGate.Enabled = false;
                    btnSelect.Enabled = false;

                    GateIn.Visible = false;
                }
                else
                {
                    GateIn.Visible = true;
                    rbtnSelectGate.Enabled = false;
                    btnSelect.Enabled = false;

                   Gatout.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCancelSelect_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dtmain = null;
                Response.Redirect("~/Forms/GateRegister.aspx");
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
                objentity.Action = "Selectall";
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
        protected void btnSubmitGateIn_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (btnSubmitGateIn.Text == "Submit")
                {
                    GatEntity objentity = new GatEntity();
                    GatComponent objcom = new GatComponent();
                    objentity.IsLoadIn = rbtnSelectGate.SelectedValue == "0" ? false : true;
                    objentity.Recievedfrom = ddlRecievedfrom.SelectedItem.Text;
                    objentity.Vehbano = txtVechicleNo1.Text.Trim();
                    objentity.Franchiseeno = null;
                    objentity.ArmyNo = txtArmyNo1.Text.Trim();
                    objentity.Rank = txtRank1.Text.Trim();
                    objentity.Name = txtName1.Text.Trim();
                    objentity.Timein = radTimeIn1.SelectedDate.Value;
                    objentity.Typeofvehicle = txtTypeofVehicle1.Text.Trim();
                    objentity.UnitQuantityTypeId = txtQuantityUnit1.Text.Trim();
                    objentity.Loadin = txtLoadIn1.Text;
                    objentity.IdtId1 = txtIRNo1.Text.Trim(); ;
                    objentity.Timeout = radTimeOut1.SelectedDate.Value;
                   // objentity.Loadout = txtLoadOut.Text;
                    objentity.FuelintankIn = txtfuelIn1.Text.Trim();
                    objentity.FuelintankOut = txtfuelOut1.Text.Trim();
                    objentity.StationDepuID = ddlDepoName.SelectedItem.Value;
                    //  objentity.StationUnitId = txtUnitMaster.Text.Trim();
                    objentity.IsActive = true;
                    objentity.AddedBy = 123;
                    objentity.ModifiedBy1 = 123;
                    int r = objcom.GateInInfoComponent(objentity);
                    if (r > 0)
                    {
                        lblGateIn.Visible = true;
                        lblGateIn.Text = "Insert Sucessfully";
                        
                        bindgrid();
                        clearGateIn();
                        
                    }
                }
                else if (btnSubmitGateIn.Text == "Update")
                {
                    GatEntity objentity = new GatEntity();
                    GatComponent objcom = new GatComponent();
                    objentity.IsLoadIn = rbtnSelectGate.SelectedValue == "0" ? false : true;
                   
                    objentity.Recievedfrom = ddlRecievedfrom.SelectedItem.Text;
                    objentity.Vehbano = txtVechicleNo1.Text.Trim();
                    objentity.Franchiseeno = null;
                    objentity.ArmyNo = txtArmyNo1.Text.Trim();
                    objentity.Rank = txtRank1.Text.Trim();
                    objentity.Name = txtName1.Text.Trim();
                    objentity.Timein = radTimeIn1.SelectedDate.Value;
                    objentity.Typeofvehicle = txtTypeofVehicle1.Text.Trim();
                    objentity.UnitQuantityTypeId = txtQuantityUnit1.Text.Trim();
                    objentity.Loadin = txtLoadIn1.Text;
                    objentity.IdtId1 = txtIRNo1.Text.Trim(); ;
                    objentity.Timeout = radTimeOut1.SelectedDate.Value;
                    // objentity.Loadout = txtLoadOut.Text;
                    objentity.FuelintankIn = txtfuelIn1.Text.Trim();
                    objentity.FuelintankOut = txtfuelOut1.Text.Trim();
                    objentity.Id = Convert.ToInt32(hdnGateIn.Value);                  //Hidden field Value
                    objentity.StationDepuID = ddlDepoName.SelectedItem.Value;
                    //  objentity.StationUnitId = txtUnitMaster.Text.Trim();
                    objentity.IsActive = true;
                    objentity.AddedBy = 123;
                    objentity.ModifiedBy1 = 123;
                     objcom.UpdateByGateIn(objentity);
                     lblGateIn.Visible = true;
                        lblGateIn.Text = "Updated Sucessfully";
                        btnSubmitGateIn.Text = "Submit";
                        bindgrid();
                        ddlRecievedfrom.DataBind();
                        clearGateIn();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        protected void btnSubmitGateOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmitGateOut.Text == "Submit")
                {
                    GatEntity objentity = new GatEntity();
                    GatComponent objcom = new GatComponent();
                    objentity.IsLoadIn = rbtnSelectGate.SelectedValue == "0" ? false : true;
                    objentity.Vehbano = txtVechicleNo.Text.Trim();
                    objentity.Franchiseeno = null;
                    objentity.ArmyNo = txtArmyNo.Text.Trim();
                    objentity.Rank = txtRank.Text.Trim();
                    objentity.Name = txtName.Text.Trim();
                    objentity.Timein = radtimein.SelectedDate.Value;
                    objentity.Typeofvehicle = txtTypeofVehicle.Text.Trim();
                    objentity.UnitQuantityTypeId = txtQuantityUnit.Text.Trim();
                    //objentity.Loadin = null;
                    objentity.IdtId1 = txtIRNo.Text.Trim();
                    objentity.Timeout = radTimeOut.SelectedDate.Value;
                    objentity.Loadout = txtLoadOut.Text;
                    objentity.FuelintankIn = txtfuelIn.Text.Trim();
                    objentity.FuelintankOut = txtfuelOut.Text.Trim();
                    objentity.StationDepuID = DdlDepoNameGateOut.SelectedItem.Value;
                  //  objentity.StationUnitId = txtUnitMaster.Text.Trim();
                    objentity.IsActive = true;
                    objentity.AddedBy = 123;
                    objentity.ModifiedBy1 = 123;
                    int r= objcom.GateInfoComponent(objentity);
                    if(r>0)
                    {
                        lblGateOut.Visible = true;
                        lblGateOut.Text = "Inserted Sucessfully";
                        clear();
                        bindgrid();
                    }
                }
                else if (btnSubmitGateOut.Text == "Update")
                {
                    GatEntity objentity = new GatEntity();
                    GatComponent objcom = new GatComponent();
                    objentity.IsLoadIn = rbtnSelectGate.SelectedValue == "0" ? false : true;
                    
                    objentity.Vehbano = txtVechicleNo.Text.Trim();
                    objentity.Franchiseeno = null;
                    objentity.ArmyNo = txtArmyNo.Text.Trim();
                    objentity.Rank = txtRank.Text.Trim();
                    objentity.Name = txtName.Text.Trim();
                    objentity.Timein = radtimein.SelectedDate.Value;
                    objentity.Typeofvehicle = txtTypeofVehicle.Text.Trim();
                    objentity.UnitQuantityTypeId = txtQuantityUnit.Text.Trim();
                    //objentity.Loadin = null;
                    objentity.IdtId1 = txtIRNo.Text.Trim(); ;
                    objentity.Timeout = radTimeOut.SelectedDate.Value;
                    objentity.Loadout = txtLoadOut.Text;
                    objentity.FuelintankIn = txtfuelIn.Text.Trim();
                    objentity.FuelintankOut = txtfuelOut.Text.Trim();
                    objentity.Id = Convert.ToInt32(hdfGateOut.Value);                   //Hidden field Value
                    objentity.StationDepuID = DdlDepoNameGateOut.SelectedItem.Value;
                    //  objentity.StationUnitId = txtUnitMaster.Text.Trim();
                    objentity.IsActive = true;
                    objentity.AddedBy = 123;
                    objentity.ModifiedBy1 = 123;
                   
                     objcom.UpdateGatComponent(objentity);
                     lblGateOut.Visible = true;
                        lblGateOut.Text = "Updated Sucessfully";
                        btnSubmitGateOut.Text = "Submit";
                     
                        bindgrid();
                        clear();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClearGateOut_Click(object sender, EventArgs e)
        {
            try
            {
                txtVechicleNo.Text = string.Empty;
                txtArmyNo.Text = string.Empty;
                txtRank.Text = string.Empty;
                txtName.Text = string.Empty;
                radtimein.Clear();
                txtTypeofVehicle.Text = string.Empty;
                txtQuantityUnit.Text = string.Empty;
                txtIRNo.Text = string.Empty;
                radTimeOut.Clear();
                txtLoadOut.Text = string.Empty;
                txtfuelIn.Text = string.Empty;
                txtfuelOut.Text = string.Empty;
               // ddlDepoName.SelectedIndex = -1;
                DdlDepoNameGateOut.SelectedIndex=-1;
                rbtnSelectGate.Enabled = true;
              //  ddlRecievedfrom.SelectedIndex = -1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void clear()
        {
            
            txtVechicleNo.Text = string.Empty;
            txtArmyNo.Text = string.Empty;
            txtRank.Text = string.Empty;
            txtName.Text = string.Empty;
            radtimein.Clear();
            txtTypeofVehicle.Text = string.Empty;
            txtQuantityUnit.Text = string.Empty;
            txtIRNo.Text = string.Empty;
            radTimeOut.Clear();
            txtLoadOut.Text = string.Empty;
            txtfuelIn.Text = string.Empty;
            txtfuelOut.Text = string.Empty;
            //ddlDepoName.SelectedIndex = -1;
            DdlDepoNameGateOut.SelectedIndex = -1;
            rbtnSelectGate.Enabled = true;



        }


        public void clearGateIn()
        {
            ddlRecievedfrom.SelectedIndex = -1;
           
            txtVechicleNo1.Text = string.Empty;
            txtArmyNo1.Text = string.Empty;
            txtRank1.Text = string.Empty;
            txtName1.Text = string.Empty;
            radTimeIn1.Clear();
            txtTypeofVehicle1.Text = string.Empty;
            txtQuantityUnit1.Text = string.Empty;
            txtIRNo1.Text = string.Empty;
            radTimeOut1.Clear();
            //txtLoadOut.Text = string.Empty;
            txtLoadIn1.Text = string.Empty;
            txtfuelIn1.Text = string.Empty;
            txtfuelOut1.Text = string.Empty;
            ddlDepoName.SelectedIndex = -1;
            rbtnSelectGate.Enabled = true;
            // DdlDepoNameGateOut.SelectedIndex = -1;
           

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

        protected void radGateout_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Editnew")
            {
                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                if (arg[0].ToString() == "Local Purchase" || arg[0].ToString() == "Central Procruitment")// args[0] : take data from IsLoadIn 
                {
                    rbtnSelectGate.Enabled = false;
                    rbtnSelectGate.SelectedValue = "1";
                    // mean gate in or load in 
                    // arrcording to that 
                    GateIn.Visible = true;
                    Gatout.Visible = false;
                    GateIn.Style["display"] = "block";
                    Gatout.Style["display"] = "none";
                 //   ddlRecievedfrom.DataBind();
                    ddlRecievedfrom.SelectedItem.Value = Convert.ToString(arg[0]);
                    ddlRecievedfrom.SelectedItem.Text = Convert.ToString(arg[0]);
                    txtVechicleNo1.Text = Convert.ToString(arg[1]);
                    txtArmyNo1.Text = Convert.ToString(arg[2]);
                    txtRank1.Text = Convert.ToString(arg[3]);
                    txtName1.Text = Convert.ToString(arg[4]);
                    radTimeIn1.SelectedDate = Convert.ToDateTime(arg[5]);
                    txtTypeofVehicle1.Text = Convert.ToString(arg[6]);
                    txtQuantityUnit1.Text = Convert.ToString(arg[7]);
                    txtIRNo1.Text = Convert.ToString(arg[8]);
                    txtLoadIn1.Text = Convert.ToString(arg[9]);
                    radTimeOut1.SelectedDate = Convert.ToDateTime(arg[10]);
                    //ddlDepoName.SelectedItem.Value = Convert.ToString(arg[12]);
                    //ddlDepoName.SelectedItem.Text = Convert.ToString(arg[12]);
                    ddlDepoName.DataBind();
                    ddlDepoName.SelectedValue = Convert.ToString(arg[12]);
                    txtfuelIn1.Text = Convert.ToString(arg[13]);
                    txtfuelOut1.Text = Convert.ToString(arg[14]);
                    hdnGateIn.Value = arg[15].ToString();
                    btnSubmitGateIn.Text = "Update";
                }
                else
                {// mean gate out or load out
                    rbtnSelectGate.Enabled = false;
                    rbtnSelectGate.SelectedValue = "0";
                    GateIn.Visible = false;
                    Gatout.Visible = true;
                    GateIn.Style["display"] = "none";
                    Gatout.Style["display"] = "block";
                    txtVechicleNo.Text = Convert.ToString(arg[1]);
                    txtArmyNo.Text = Convert.ToString(arg[2]);
                    txtRank.Text = Convert.ToString(arg[3]);
                    txtName.Text = Convert.ToString(arg[4]);
                    radtimein.SelectedDate = Convert.ToDateTime(arg[5]);
                    txtTypeofVehicle.Text = Convert.ToString(arg[6]);
                    txtQuantityUnit.Text = Convert.ToString(arg[7]);
                    txtIRNo.Text = Convert.ToString(arg[8]);
                    txtLoadOut.Text = Convert.ToString(arg[11]);
                    radTimeOut.SelectedDate = Convert.ToDateTime(arg[10]);
                    //DdlDepoNameGateOut.SelectedItem.Value = Convert.ToString(arg[12]);
                    //DdlDepoNameGateOut.SelectedItem.Text = Convert.ToString(arg[12]);
                    DdlDepoNameGateOut.DataBind();
                    DdlDepoNameGateOut.SelectedValue = Convert.ToString(arg[12]);
                    txtfuelIn.Text = Convert.ToString(arg[13]);
                    txtfuelOut.Text = Convert.ToString(arg[14]);
                    //catid = Convert.ToInt32(arg[15]);
                    hdfGateOut.Value = arg[15].ToString();
                    btnSubmitGateOut.Text = "Update";
                }

              
            }
            else if (e.CommandName == "Active")
            {
                string[] arg = e.CommandArgument.ToString().Split(new char[] { '<' });

                catid = Convert.ToInt32(arg[0]);
                string argt = Convert.ToString(arg[1]);
                LinkButton lk = (LinkButton)(e.Item.FindControl("lkactive"));

                GatEntity objentity = new GatEntity();
                GatComponent objcom = new GatComponent();
                if (Convert.ToBoolean(argt) == true)
                {
                    objentity.IsActive = true;
                }
                else
                {
                    objentity.IsActive = false;
                }
                objentity.Id = catid;
                objcom.Inactive(objentity);
            }
            bindgrid();

        }

        protected void ddlDepoName_DataBound(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlDepoName.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

       
       
        protected void btnCancelGateIn_Click1(object sender, EventArgs e)
        {
            try
            {
                txtVechicleNo1.Text = string.Empty;
                txtArmyNo1.Text = string.Empty;
                txtRank1.Text = string.Empty;
                txtName1.Text = string.Empty;
                radTimeIn1.Clear();
                txtTypeofVehicle1.Text = string.Empty;
                txtQuantityUnit1.Text = string.Empty;
                txtIRNo1.Text = string.Empty;
                radTimeOut1.Clear();
                //txtLoadOut.Text = string.Empty;
                txtLoadIn1.Text = string.Empty;
                txtfuelIn1.Text = string.Empty;
                txtfuelOut1.Text = string.Empty;
                ddlDepoName.SelectedIndex = -1;
               // DdlDepoNameGateOut.SelectedIndex = -1;
                ddlRecievedfrom.SelectedIndex = -1;
                rbtnSelectGate.Enabled = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlRecievedfrom_DataBound(object sender, EventArgs e)
        {
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "-- Select --";
            ddlRecievedfrom.Items.Insert(0, li);
        }

        protected void DdlDepoNameGateOut_DataBound1(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                DdlDepoNameGateOut.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }

}