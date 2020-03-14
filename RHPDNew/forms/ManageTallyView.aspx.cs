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
    public partial class ManageTallyView: System.Web.UI.Page
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
                    btnprints.Attributes.Add("onclick", "window.print();");
                    try
                    {
                        if (Page.Request["id"] != null)
                        {
                            int id = Convert.ToInt32(Request.QueryString["id"]);
                            if (id > 0)
                            {
                                
                                TallySheetEntity objentity = new TallySheetEntity();
                                TallySheetComponent objcom = new TallySheetComponent();
                                objentity.Id = id;
                                objentity.Action = "selecttallydetailview";
                                DataSet ds = objcom.selecttallydetailview(objentity);
                                if (ds.Tables.Count > 0)
                                {
                                    DataTable dt1 = ds.Tables[0];
                                    DataTable dt2 = ds.Tables[1];
                                    if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                                    {
                                        lblFrom.Text = Convert.ToString(dt1.Rows[0]["DepuFROMName"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["DepuFROMName"]);
                                        lblTo.Text = Convert.ToString(dt1.Rows[0]["DepuName"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["DepuName"]);
                                        lblUnitTo.Text = Convert.ToString(dt1.Rows[0]["UnitName"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["UnitName"]);
                                        lblAuthorityNo.Text = Convert.ToString(dt1.Rows[0]["Authority"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["Authority"]);
                                        lblThrough.Text = Convert.ToString(dt1.Rows[0]["Through"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["Through"]);
                                        lblVehicleNo.Text = Convert.ToString(dt1.Rows[0]["VehBaNo"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["VehBaNo"]);

                                        RadGrid.DataSource = dt2;
                                        RadGrid.DataBind();
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