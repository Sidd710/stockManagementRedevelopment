using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RHPDEntity;
using RHPDComponent;
using System.Data;

namespace RHPDNew.Forms
{
    public partial class ESLIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        currentstatus.Visible = false;
                        RecieveDate.Visible = false;
                        Status.Visible = false;


                        if (Page.Request["Id"] != null)
                        {
                            //QueryStringParameter from ESL page
                            if (Request.QueryString["Id"] != null)
                            {
                                lblBatchId.Text = Request.QueryString["Id"];
                                if ((Convert.ToInt32(lblBatchId.Text)) > 0)
                                {
                                    ESLIssueComponent ObjESLComp = new ESLIssueComponent();
                                    ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
                                    int batchid = Convert.ToInt32(lblBatchId.Text);
                                    DataTable dt = new DataTable();
                                    dt = ObjESLComp.SelectStockQtyComponent(batchid);

                                    if (dt.Rows.Count > 0)
                                    {
                                        lbltotalQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                                        lblBatchName.Text = dt.Rows[0]["BatchName"].ToString();

                                        ddlQuantitytype.DataBind();
                                        ddlQuantitytype.SelectedValue = dt.Rows[0]["QuantityType"].ToString();


                                        RecieveDate.Visible = false;
                                        rfvRecieveDate.ValidationGroup = "issued";
                                        Status.Visible = false;
                                        rfvddlddlStatus.ValidationGroup = "issued";

                                        //ddlStatus.Enabled = false;
                                        lblProductName.Text = dt.Rows[0]["ProductName"].ToString();

                                        DropdownlistIssue();
                                    }
                                    else
                                    {
                                        // error it's updated
                                    }
                                }
                                else
                                {
                                    // error quertstring is not well
                                }
                            }
                        }
                        else if (Page.Request["tID"] != null)
                        {
                            if (Request.QueryString["tID"] != null)
                            {
                               

                                //lblQuantity.Text = Request.QueryString["Quantity"];
                                ESLIssueStatusComponent ObjComp = new ESLIssueStatusComponent();
                                ESLIssueEntity ObjEntity = new ESLIssueEntity();

                                DataTable dt2 = new DataTable();
                                ObjEntity.Bid = Convert.ToInt32(Request.QueryString["tID"]);
                                dt2 = ObjComp.SelectESLStausComponent(ObjEntity);
                                if (dt2.Rows.Count > 0)
                                {
                                    lblBatchId.Text = Convert.ToString(Request.QueryString["tID"]);
                                    lblProductName.Text = dt2.Rows[0]["ProductName"].ToString();
                                    lblBatchName.Text = dt2.Rows[0]["BatchCode"].ToString();
                                    //lblBatchId.Text = dt2.Rows[0]["ProductID"].ToString();
                                    ddlIssueTo.SelectedValue = dt2.Rows[0]["IssueTo"].ToString();
                                    ddlIssueTo.Enabled = false;
                                    txtOverallRemark.Text = dt2.Rows[0]["OverallRemarks"].ToString();
                                    txtOverallRemark.Enabled = false;
                                    txtQuantity.Text = dt2.Rows[0]["eslquantity"].ToString();
                                    txtQuantity.Enabled = false;

                                    ddlQuantitytype.DataBind();
                                    ddlQuantitytype.SelectedValue = dt2.Rows[0]["QuantityType"].ToString();
                                    ddlQuantitytype.Enabled = false;
                                    txtRemarkbyDSO.Text = dt2.Rows[0]["RemarksByjDSO"].ToString();
                                    txtRemarkbyDSO.Enabled = false;
                                    txtRemarkbyJCO.Text = dt2.Rows[0]["RemarksByjcoiGP"].ToString();
                                    txtRemarkbyJCO.Enabled = false;
                                    txtRemarkbyNureGP.Text = dt2.Rows[0]["RemarksBynurGP"].ToString();
                                    txtRemarkbyNureGP.Enabled = false;

                                    currentstatus.Visible = true;
                                    lblCurrentStatus.Text = dt2.Rows[0]["Status"].ToString();

                                    btnSubmit.Text = "Update";
                                    lbltotlquantity.Visible = false;
                                    lbltotalQuantity.Visible = false;
                                    //ddlStatus.Enabled = true;
                                    //txtRecieve.Enabled = true;

                                    RecieveDate.Visible = true;
                                    rfvRecieveDate.ValidationGroup = "issue";
                                    Status.Visible = true;
                                    rfvddlddlStatus.ValidationGroup = "issue";

                                    ctmvQtyIssued.ValidationGroup = "issued";
                                    Dropdownlist();
                                }
                            }
                        }
                        //QueryStringParameter from ESLIssueStatus page 

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// bind for ESLIssueStatus page 
        /// </summary>

        public void Dropdownlist()
        {
            DataTable dt = new DataTable();
            ESLIssueComponent Obj = new ESLIssueComponent();
            dt = Obj.SelectDropdownComponent();
            if (dt.Rows.Count > 0)
            {
                ddlStatus.DataSource = dt;
                ddlStatus.DataTextField = "Status";
                ddlStatus.DataValueField = "Id";
                ddlStatus.DataBind();
            }
        }


        /// <summary>
        /// bind for ESL page 
        /// </summary>
        public void DropdownlistIssue()
        {
            DataTable dt = new DataTable();
            ESLIssueComponent Obj = new ESLIssueComponent();
            dt = Obj.SelectDropdownStatusComponent();
            if (dt.Rows.Count > 0)
            {
                ddlStatus.DataSource = dt;
                ddlStatus.DataTextField = "Status";
                ddlStatus.DataValueField = "Id";
                ddlStatus.DataBind();
            }
        }

        protected void ddlStatus_DataBound(object sender, EventArgs e)
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

                if (Page.IsValid)
                {
                    if (btnSubmit.Text == "Submit")
                    {
                        int r;

                        ESLIssueComponent ObjESLComp = new ESLIssueComponent();
                        ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
                        ObjEslEntity.Bid = Convert.ToInt32(lblBatchId.Text);
                        ObjEslEntity.Issueto = ddlIssueTo.SelectedValue;
                        ObjEslEntity.Total = Convert.ToInt32(lbltotalQuantity.Text);

                        ObjEslEntity.Quantitytype = ddlQuantitytype.SelectedValue;
                        ObjEslEntity.Quantity = txtQuantity.Text;

                        ObjEslEntity.Remarksbynurgp = txtRemarkbyNureGP.Text;
                        ObjEslEntity.RemarksByjcoigp = txtRemarkbyJCO.Text;
                        ObjEslEntity.Remarksbydso = txtRemarkbyDSO.Text;
                        ObjEslEntity.Statusid = 4; //Convert.ToInt32(ddlStatus.SelectedValue);
                        ObjEslEntity.Overallremarks = txtOverallRemark.Text;

                        if (chkIsActive.Checked == true)
                        {
                            ObjEslEntity.IsActive = 1;
                        }
                        r = ObjESLComp.InsertproductESLIssue(ObjEslEntity);

                        if (r > 0)
                        {
                            Clear();
                            lblMessage.Text = "Submitted Sucessfully";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                            Response.Redirect("../Forms/ESLIssueStatus.aspx");

                        }
                        else
                        {
                            if (r == -1)
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "name();", true);
                                return;
                            }
                        }


                    }


                    else if (btnSubmit.Text == "Update")
                    {
                        ESLIssueComponent ObjESLComp = new ESLIssueComponent();
                        ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
                        ObjEslEntity.Bid = Convert.ToInt32(lblBatchId.Text);
                        ObjEslEntity.Statusid = Convert.ToInt32(ddlStatus.SelectedValue);
                        ObjEslEntity.Recieveddate = Convert.ToDateTime(txtRecieve.Text);
                        ObjEslEntity.Quantity = txtQuantity.Text;
                        ObjEslEntity.ModifiedBy = 123;
                        DataTable dt = new DataTable();
                        //dt = ObjESLComp.UpdateESLstatusComponent(ObjEslEntity);  // Commented by Rohit Pundeer
                         

                        lblMessage.Text = "Updated Sucessfully";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                        Response.Redirect("../Forms/ESLIssueStatus.aspx");

                    }

                }

                else
                {

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Clear()
        {
            ddlStatus.SelectedIndex = -1;
            //txtIssueTo.Text = string.Empty;
            txtOverallRemark.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            ddlQuantitytype.SelectedIndex = -1;
            //txtQuantitytype.Text = string.Empty;
            txtRecieve.Text = string.Empty;
            txtRemarkbyDSO.Text = string.Empty;
            txtRemarkbyJCO.Text = string.Empty;
            txtRemarkbyNureGP.Text = string.Empty;
           // txtIssueTo.Text = string.Empty;
            lbltotalQuantity.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
        }







        protected void ctmvQtyIssued_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if ((Convert.ToInt32(txtQuantity.Text)) > 0)
                {
                    int BatchId = Convert.ToInt32(lblBatchId.Text);
                    ESLIssueComponent ObjESLComp = new ESLIssueComponent();
                    ESLIssueEntity ObjEslEntity = new ESLIssueEntity();
                    ObjEslEntity.Productid = Convert.ToInt32(lblBatchId.Text);
                    DataTable dt = new DataTable();
                    dt = ObjESLComp.SelectStockQtyComponent(BatchId);

                    int MaxQuantity = 0;
                    if (dt.Rows.Count > 0)
                    {
                        MaxQuantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);


                        if (Convert.ToInt32(txtQuantity.Text) <= MaxQuantity)
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Qunatity you entered is greater');", true);

                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Qunatity not be 0');", true);
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

        protected void ddlStatus_DataBound1(object sender, EventArgs e)
        {
            try
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "-- Select --";
                ddlStatus.Items.Insert(0, li);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}