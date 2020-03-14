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
    public partial class IssuedVoucherView : System.Web.UI.Page
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
                                IssueVocuherEntity objentity = new IssueVocuherEntity();
                                IssueVoucherComponent objcom = new IssueVoucherComponent();
                                objentity.Id = id;
                                objentity.Action = "SelectIssuedetailview";
                                DataSet ds = objcom.SelectIssuedetailview(objentity);
                                if(ds.Tables.Count>0)
                                {
                                    DataTable dt1 = ds.Tables[0];
                                    DataTable dt2=ds.Tables[1];
                                    if(dt1.Rows.Count>0 && dt2.Rows.Count>0)
                                    {
                                        lbldeponame.Text = Convert.ToString(dt1.Rows[0]["DepuName"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["DepuName"]);
                                        lblunitname.Text = Convert.ToString(dt1.Rows[0]["UnitName"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["UnitName"]);
                                        lblVechicleNo.Text = Convert.ToString(dt1.Rows[0]["VechileNo"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["VechileNo"]);
                                        lblAuthority.Text = Convert.ToString(dt1.Rows[0]["Authority"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["Authority"]);
                                        lblThrough.Text = Convert.ToString(dt1.Rows[0]["Through"]) == "" ? "N/A" : Convert.ToString(dt1.Rows[0]["Through"]);

                                        radStockTransferByIndent.DataSource = dt2;
                                        radStockTransferByIndent.DataBind();
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