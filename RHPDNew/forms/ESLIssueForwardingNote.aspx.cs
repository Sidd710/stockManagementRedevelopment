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
    public partial class ESLIssueForwardingNote : System.Web.UI.Page
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
                                        lblForwardNoteProductName.Text = "Forwarding Note for " + dt.Rows[0]["ProductName"].ToString();
                                        txtBatchNumber.Text = dt.Rows[0]["BatchNo"].ToString();
                                        txtManufactureDate.Text = dt.Rows[0]["MfgDate"].ToString();
                                        txtReceiptDate.Text = dt.Rows[0]["ReceiptDate"].ToString();
                                        txtAtNumber.Text = dt.Rows[0]["AtNo"].ToString();
                                        txtSupplySource.Text = dt.Rows[0]["SupplySource"].ToString();
                                        txtContainerSize.Text = "Shape- " + dt.Rows[0]["Shape"].ToString() + " : " + "Dimensions- " + dt.Rows[0]["Size"].ToString();
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

                        /**** Rohit Pundeer - No Need of this code right now ****/
                        //else if (Page.Request["tID"] != null)
                        //{
                        //    if (Request.QueryString["tID"] != null)
                        //    {
                               

                        //        //lblQuantity.Text = Request.QueryString["Quantity"];
                        //        ESLIssueStatusComponent ObjComp = new ESLIssueStatusComponent();
                        //        ESLIssueEntity ObjEntity = new ESLIssueEntity();

                        //        DataTable dt2 = new DataTable();
                        //        ObjEntity.Bid = Convert.ToInt32(Request.QueryString["tID"]);
                        //        dt2 = ObjComp.SelectESLStausComponent(ObjEntity);
                        //        if (dt2.Rows.Count > 0)
                        //        {
                        //            lblForwardNoteProductName.Text = "Forwarding Note for " + dt2.Rows[0]["ProductName"].ToString();
                        //            txtBatchNumber.Text = dt2.Rows[0]["BatchNo"].ToString();
                        //            txtManufactureDate.Text = dt2.Rows[0]["MfgDate"].ToString();
                        //            txtReceiptDate.Text = dt2.Rows[0]["ReceiptDate"].ToString();
                        //            txtAtNumber.Text = dt2.Rows[0]["AtNo"].ToString();
                        //            txtSupplySource.Text = dt2.Rows[0]["SupplySource"].ToString();
                        //            txtContainerSize.Text = "Shape- " + dt2.Rows[0]["Shape"].ToString() + " : " + "Dimensions- " + dt2.Rows[0]["Size"].ToString();                                        
                        //        }
                        //    }
                        //}
                        //QueryStringParameter from ESLIssueStatus page 

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
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
                        int result;
                        ESLIssueComponent ObjESLComp = new ESLIssueComponent();
                        EslForwardingNoteEntity objEslFN = new EslForwardingNoteEntity();                        
                        objEslFN.Adderessee = txtAddressee.Text;
                        objEslFN.AtNoReferences = txtAtNoReferences.Text;
                        objEslFN.BatchId = Convert.ToInt32(lblBatchId.Text);
                        objEslFN.ContainerMarkingDetails = txtContainerMarkingDetails.Text;
                        objEslFN.ContainerType = txtContainerType.Text;
                        objEslFN.DispatchDate = Convert.ToDateTime(txtDispatchDate.SelectedDate);
                        objEslFN.DispatchMethod = txtDispatchMethod.Text;
                        objEslFN.DrawerNameAndRank = txtDrawerNameRank.Text;
                        objEslFN.FillingDate = Convert.ToDateTime(txtFillingDate.SelectedDate);
                        objEslFN.ForwardingNoteNumber = txtForwardingNoteNumber.Text;
                        objEslFN.ForwardNoteDate = Convert.ToDateTime(txtForwardNoteDate.SelectedDate);
                        objEslFN.GoverningSupply = txtGoverningSupply.Text;
                        objEslFN.GovtStock = txtGovtStock.Text;
                        objEslFN.INoteDate = Convert.ToDateTime(txtINoteDate.SelectedDate);
                        objEslFN.INoteNumber = txtINoteNumber.Text;
                        objEslFN.IntendedDestination = txtIntendedDestination.Text;
                        objEslFN.NomenStore = txtNomenStore.Text;
                        objEslFN.OfficerDesignation = txtDesignation.Text;
                        objEslFN.OfficerPostalAddress = txtPostalTeleAddress.Text;
                        objEslFN.PreviousTestReferences = txtPreviousTestReference.Text;
                        objEslFN.QuantityRepressntedBySample = Convert.ToDecimal(txtQuantityRepresentBySample.Text);
                        objEslFN.ReasonForTest = txtTestReason.Text;
                        objEslFN.SampleDrawnDate = Convert.ToDateTime(txtSampleDrawnDate.SelectedDate);
                        objEslFN.SampleIndetityMarks = txtSampleRefIdentityMarks.Text;
                        objEslFN.SampleNumbers = Convert.ToInt32(txtNumberofSamples.Text);
                        objEslFN.SampleQuantity = Convert.ToDecimal(txtSampleQuantity.Text);
                        objEslFN.SampleRefNumber = txtSampleRefNumber.Text;
                        objEslFN.SampleType = txtSampleType.Text;
                        objEslFN.TankNumber = txtTankNumber.Text;
                        objEslFN.TradeGovtAccepted = txtTradeOfferedGovt.Text;
                        objEslFN.TradeOwned = txtTradeOwned.Text;
                        objEslFN.IsForwardNumberActive = 1;

                        result = ObjESLComp.InsertForwardingNoteDetails(objEslFN);

                        if (result > 0)
                        {
                            Clear();
                            lblMessage.Text = "Submitted Sucessfully";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                            Response.Redirect("../Forms/ESLIssueStatus.aspx");
                        }
                        else
                        {
                            if (result == -1)
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", "name();", true);
                                return;
                            }
                        }

                    }


                //    else if (btnSubmit.Text == "Update")
                //    {
                //        lblMessage.Text = "Updated Sucessfully";
                //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                //        Response.Redirect("../Forms/ESLIssueStatus.aspx");
                //   }

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
            txtForwardingNoteNumber.Text = string.Empty;
            txtForwardNoteDate.Clear();
            txtAddressee.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtPostalTeleAddress.Text = string.Empty;
            txtNomenStore.Text = string.Empty;
            txtAtNoReferences.Text = string.Empty;
            txtContainerMarkingDetails.Text = string.Empty;
            txtContainerType.Text = string.Empty;
            txtDispatchDate.Clear();
            txtDispatchMethod.Text = string.Empty;
            txtDrawerNameRank.Text = string.Empty;
            txtFillingDate.Clear();
            txtGoverningSupply.Text = string.Empty;
            txtGovtStock.Text = string.Empty;
            txtINoteDate.Clear();
            txtINoteNumber.Text = string.Empty;
            txtIntendedDestination.Text = string.Empty;
            txtNumberofSamples.Text = string.Empty;
            txtPreviousTestReference.Text = string.Empty;
            txtQuantityRepresentBySample.Text = string.Empty;
            txtSampleDrawnDate.Clear();
            txtSampleQuantity.Text = string.Empty;
            txtSampleRefIdentityMarks.Text = string.Empty;
            txtSampleRefNumber.Text = string.Empty;
            txtSampleType.Text = string.Empty;
            txtTankNumber.Text = string.Empty;
            txtTestReason.Text = string.Empty;
            txtTradeOfferedGovt.Text = string.Empty;
            txtTradeOwned.Text = string.Empty;
        }
        
    }
}