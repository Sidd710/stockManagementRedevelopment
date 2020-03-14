using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class GatInOutView : System.Web.UI.Page
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
                    GateIn.Visible = false;
                    Gatout.Visible = false;
                    btnprints.Attributes.Add("onclick", "window.print();");
                    try
                    {
                        if (Page.Request["id"] != null)
                        {
                            int id = Convert.ToInt32(Request.QueryString["id"]);
                            if (id > 0)
                            {
                                GatEntity objentity = new GatEntity();
                                GatComponent objcom = new GatComponent();
                                objentity.Id = id;
                                objentity.Action = "SelectGatViewDetail";
                                DataTable dt = objcom.SelectGatViewDetail(objentity);
                                if (dt.Rows.Count > 0)
                                {
                                   if((Convert.ToString(dt.Rows[0]["IsLoadIn"]))=="true")
                                   {
                                       GateIn.Visible = true;
                                       Gatout.Visible = false;
                                       lblSelectGate.Text = "Gate In";
                                       lblRecievedFromGateIn.Text = Convert.ToString(dt.Rows[0]["Recievedfrom"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["Recievedfrom"]);
                                       lblVechicleNoGateIn.Text = Convert.ToString(dt.Rows[0]["vehbano"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["vehbano"]);
                                       lblArmyNoGateIn.Text = Convert.ToString(dt.Rows[0]["ArmyNo"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["ArmyNo"]);
                                       lblRankGateIn.Text = Convert.ToString(dt.Rows[0]["Rank"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["Rank"]);
                                       lblNameGateIn.Text = Convert.ToString(dt.Rows[0]["name"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["name"]);

                                       lblTimeInGateIn.Text = Convert.ToString(dt.Rows[0]["timein"]) == "" ? "N/A" : Convert.ToDateTime(dt.Rows[0]["timein"]).ToShortTimeString();
                                       lblTypeofVehicleGateIn.Text = Convert.ToString(dt.Rows[0]["typeofvehicle"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["typeofvehicle"]);
                                       lblQuantityUnitGateIn.Text = Convert.ToString(dt.Rows[0]["unitQuantityTypeId"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["unitQuantityTypeId"]);
                                       lblLoadInGateIn.Text = Convert.ToString(dt.Rows[0]["loadin"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["loadin"]);
                                       lblIRNoGateIn.Text = Convert.ToString(dt.Rows[0]["IdtId"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["IdtId"]);

                                       lblTimeOutGateIn.Text = Convert.ToString(dt.Rows[0]["timeout"]) == "" ? "N/A" : Convert.ToDateTime(dt.Rows[0]["timeout"]).ToShortTimeString();
                                       lblDepoNameGateIn.Text = Convert.ToString(dt.Rows[0]["DepuName"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["DepuName"]);
                                       //lblUnitMasterGateIn.Text = Convert.ToString(dt.Rows[0]["stationUnitId"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["stationUnitId"]);
                                       lblfuelInGateIn.Text = Convert.ToString(dt.Rows[0]["fuelintankIn"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["fuelintankIn"]);
                                       lblfuelOutGateIn.Text = Convert.ToString(dt.Rows[0]["fuelintankOut"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["fuelintankOut"]);

                                   }
                                   else
                                   {
                                       GateIn.Visible = false;
                                       Gatout.Visible = true;
                                       lblSelectGate.Text = "Gat Out";
                                       lblVechicleNo.Text = Convert.ToString(dt.Rows[0]["vehbano"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["vehbano"]);
                                       lblArmyNo.Text = Convert.ToString(dt.Rows[0]["ArmyNo"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["ArmyNo"]);
                                       lblRank.Text = Convert.ToString(dt.Rows[0]["Rank"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["Rank"]);
                                       lblName.Text = Convert.ToString(dt.Rows[0]["name"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["name"]);

                                       lblTimeIn.Text = Convert.ToString(dt.Rows[0]["timein"]) == "" ? "N/A" : Convert.ToDateTime(dt.Rows[0]["timein"]).ToShortTimeString();
                                       lblTypeofVehicle.Text = Convert.ToString(dt.Rows[0]["typeofvehicle"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["typeofvehicle"]);
                                       lblQuantityUnit.Text = Convert.ToString(dt.Rows[0]["unitQuantityTypeId"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["unitQuantityTypeId"]);
                                       //lblLoadInGateIn.Text = Convert.ToString(dt.Rows[0]["loadin"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["loadin"]);
                                       lblIRNo.Text = Convert.ToString(dt.Rows[0]["IdtId"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["IdtId"]);

                                       lblLoadOut.Text = Convert.ToString(dt.Rows[0]["loadout"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["loadout"]);
                                       lblTimeOut.Text = Convert.ToString(dt.Rows[0]["timeout"]) == "" ? "N/A" : Convert.ToDateTime(dt.Rows[0]["timeout"]).ToShortTimeString();
                                       lblDepoName.Text = Convert.ToString(dt.Rows[0]["DepuName"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["DepuName"]);
                                       //lblUnitMasterGateIn.Text = Convert.ToString(dt.Rows[0]["stationUnitId"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["stationUnitId"]);
                                       lblfuelIn.Text = Convert.ToString(dt.Rows[0]["fuelintankIn"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["fuelintankIn"]);
                                       lblfuelOut.Text = Convert.ToString(dt.Rows[0]["fuelintankOut"]) == "" ? "N/A" : Convert.ToString(dt.Rows[0]["fuelintankOut"]);
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
    }
}