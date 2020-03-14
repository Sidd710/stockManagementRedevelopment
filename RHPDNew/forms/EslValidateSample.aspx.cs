using RHPDComponent;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RHPDNew.Forms
{
    public partial class EslValidateBatch : System.Web.UI.Page
    {
        protected void Page_InitComplete(object sender, EventArgs e)
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
                                        lblValidateSampleProductName.Text = "Validate Sample for " + dt.Rows[0]["ProductName"].ToString();
                                        lblBatchNumberAndDOM.Text = dt.Rows[0]["BatchNo"].ToString() + ", " + dt.Rows[0]["MfgDate"].ToString();
                                        lblReceiptDate.Text = dt.Rows[0]["ReceiptDate"].ToString();
                                        lblAtDetails.Text = dt.Rows[0]["AtNo"].ToString();
                                        lblSupplySource.Text = dt.Rows[0]["SupplySource"].ToString();
                                        lblContainerSize.Text = "Shape- " + dt.Rows[0]["Shape"].ToString() + " : " + "Dimensions- " + dt.Rows[0]["Size"].ToString();
                                        lblCurrentEsl.Text = dt.Rows[0]["EslDate"].ToString();
                                    }
                                    else
                                    {
                                        // error it's updated
                                    }
                                    EslForwardingNoteEntity ObjEslFnEntity = new EslForwardingNoteEntity();
                                    DataTable dt1 = new DataTable();
                                    string actionName = "FetchAllDetails";
                                    dt1 = ObjESLComp.SelectESLIssueGridComponent(actionName, batchid);
                                    if (dt.Rows.Count > 0)
                                    {
                                        lblAddressee.Text = dt1.Rows[0]["addressee"].ToString();
                                        lblAtDetails.Text = lblAtDetails.Text + ", " + dt1.Rows[0]["atNoReferences"].ToString();
                                        lblContainerType.Text = dt1.Rows[0]["containerType"].ToString();
                                        lblDesignationAndPostalAddress.Text = dt1.Rows[0]["officerDesignation"].ToString() + dt1.Rows[0]["officerPostalAddress"].ToString();
                                        lblDispatchDate.Text = dt1.Rows[0]["dispatchDate"].ToString();
                                        lblDispatchMethod.Text = dt1.Rows[0]["dispatchMethod"].ToString();
                                        lblDrawrNameAndRank.Text = dt1.Rows[0]["drawerNameAndRank"].ToString();
                                        lblFillingDate.Text = dt1.Rows[0]["fillingDate"].ToString();
                                        lblFnDate.Text = dt1.Rows[0]["forwardNoteDate"].ToString();
                                        lblForwardingNoteNo.Text = dt1.Rows[0]["forwardingNoteNumber"].ToString();
                                        lblGoverningSupply.Text = dt1.Rows[0]["governingSupply"].ToString();
                                        lblGovtStock.Text = dt1.Rows[0]["govtStock"].ToString();
                                        lblINoteNoAndDate.Text = dt1.Rows[0]["iNoteNumber"].ToString() + dt1.Rows[0]["iNoteDate"].ToString();
                                        lblIntendedDestination.Text = dt1.Rows[0]["intendedDestination"].ToString();
                                        lblNomenStore.Text = dt1.Rows[0]["nomenStore"].ToString();
                                        lblPrevTestReference.Text = dt1.Rows[0]["previousTestReferences"].ToString();
                                        lblSampleDrawnDate.Text = dt1.Rows[0]["sampleDrawnDate"].ToString();
                                        lblContainerMarkingDetails.Text = dt1.Rows[0]["containerMarkingDetails"].ToString();
                                        lblSampleNumbers.Text = dt1.Rows[0]["numberOfSamples"].ToString();
                                        lblSampleQuantity.Text = dt1.Rows[0]["sampleQualtity"].ToString();
                                        lblSampleQuantityRepresented.Text = dt1.Rows[0]["quantityRepressntedBySample"].ToString();
                                        lblSampleReferenceAndIndentity.Text = dt1.Rows[0]["sampleRefNumber"].ToString() + dt1.Rows[0]["sampleIdentificationMarks"].ToString();
                                        lblSampleType.Text = dt1.Rows[0]["sampleType"].ToString();
                                        lblTankNo.Text = dt1.Rows[0]["tankNumber"].ToString();
                                        lblTestReason.Text = dt1.Rows[0]["reasonForTest"].ToString();
                                        lblTradeGovtAccepted.Text = dt1.Rows[0]["tradeGovtAccepted"].ToString();
                                        lblTradeOwned.Text = dt1.Rows[0]["tradeOwned"].ToString();
                                        if (dt1.Rows[0]["OldEslDate"].ToString() != null || dt1.Rows[0]["OldEslDate"].ToString() != "")
                                            lblPreviousEsl.Text = dt1.Rows[0]["OldEslDate"].ToString();
                                        else
                                            lblPreviousEsl.Text = "N/A";
                                    }
                                    dpSampleNewEsl.SelectedDate = null;

                                }
                                else
                                {
                                    // error quertstring is not well
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {              
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt32(lblBatchId.Text);
            ESLIssueComponent ObjESLComp = new ESLIssueComponent();
            if (rbtFit.Checked)
            {
                DateTime date = Convert.ToDateTime(dpSampleNewEsl.SelectedDate);
                date = date.Date;
                DateTime preDate = Convert.ToDateTime(lblCurrentEsl.Text);
                preDate = preDate.Date;
                result = ObjESLComp.UpdateESLstatusComponent(id, date,preDate);
            }
            else if (rbtUnfit.Checked)
            {
                DateTime? date = null;
                result = ObjESLComp.UpdateESLstatusComponent(id, date,null);
            }

            if (result > 0)
            {
                lblMessage.Text = "Records modified successfully!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblMessage.Text + "');", true);
                RadAjaxManager.ResponseScripts.Add("CloseModal();");                
            }
        }
    }
}