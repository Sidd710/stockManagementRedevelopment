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
    public partial class IssueVoucherGenrate : System.Web.UI.Page
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
                    hdf.Value = string.Empty;
                    try
                    {
                        if (Page.Request["id"] != null)
                        {
                            int id = Convert.ToInt32(Request.QueryString["id"]);
                            hdf.Value = id.ToString();
                            if (id > 0)
                            {
                                IssueVocuherEntity objentity = new IssueVocuherEntity();
                                IssueVoucherComponent objcom = new IssueVoucherComponent();
                                objentity.IdtId = id;
                                objentity.Action = "SelectStockTransferDetailIndentWise";
                                DataTable dt = objcom.SelectIndentWise(objentity);
                                if (dt.Rows.Count > 0)
                                {
                                    if ((Convert.ToString(dt.Rows[0]["IsUnit"])) == "true")
                                    {
                                        unit.Visible = true;
                                        rfvddlUnitMaster.ValidationGroup = "grp";
                                        btnIssueVoucher.Visible = true;

                                        ddlDepoName.DataBind();
                                        ddlDepoName.SelectedValue = Convert.ToString(dt.Rows[0]["DepuMasterId"]);
                                        ddlUnitMaster.DataBind();
                                        ddlUnitMaster.SelectedValue = Convert.ToString(dt.Rows[0]["UnitMasterId"]);
                                        radStockTransferByIndent.DataSource = dt;
                                        radStockTransferByIndent.DataBind();
                                    }
                                    else
                                    {
                                        unit.Visible = false;
                                        rfvddlUnitMaster.ValidationGroup = "grpunit";
                                        btnIssueVoucher.Visible = true;

                                        ddlDepoName.DataBind();
                                        ddlDepoName.SelectedValue = Convert.ToString(dt.Rows[0]["DepuMasterId"]);
                                        radStockTransferByIndent.DataSource = dt;
                                        radStockTransferByIndent.DataBind();
                                    }

                                }
                                else
                                {
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "Something went wrong";
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        protected void btnIssueVoucher_Click(object sender, EventArgs e)
        {
            try
            {
               if(Page.Request["id"]!=null)
                {
                    lblMessage.Visible = false; lblMessage.Text = string.Empty;
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    if (hdf.Value == id.ToString())
                    {
                        if (id > 0)
                        {
                            if (radStockTransferByIndent.Items.Count>0)
                            {
                                IssueVocuherEntity objentity = new IssueVocuherEntity();
                                IssueVoucherComponent objcom = new IssueVoucherComponent();
                                objentity.ToDepuId = Convert.ToInt32(ddlDepoName.SelectedValue);
                                objentity.ToUnitId = ddlUnitMaster.SelectedValue == "" ? 0 : Convert.ToInt32(ddlUnitMaster.SelectedValue);
                                objentity.IdtId = Convert.ToInt32(Request.QueryString["id"]);
                                objentity.VechileNo = txtVechicleNo.Text.Trim();
                                objentity.Authority = txtAuthority.Text.Trim();
                                objentity.Through = txtThrough.Text.Trim();
                                objentity.AddedBy = 123;
                                objentity.ModifiedBy = 123;
                                objentity.IsActive = true;
                                objentity.Action = "InsertIssueVoucher";
                                int r = objcom.InsertIssueVoucher(objentity);
                                if (r > 0)
                                {
                                    hdf.Value = string.Empty;
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "Voucher is Generated";

                                    txtVechicleNo.Text = string.Empty;
                                    txtAuthority.Text = string.Empty;
                                    txtThrough.Text = string.Empty;

                                    radStockTransferByIndent.DataSource = null;
                                    radStockTransferByIndent.DataBind();
                                    ddlDepoName.SelectedIndex = -1;
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

        protected void btnprints_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "print_page();", true);
        }
    }
}