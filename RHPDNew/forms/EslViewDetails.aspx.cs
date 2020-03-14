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
    public partial class EslStatusViewDetails : System.Web.UI.Page
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
                                    int FnId = Convert.ToInt32(lblBatchId.Text);
                                    DataTable dt = new DataTable();
                                    dt = ObjESLComp.SelectForwardNoteViewComponent(FnId);

                                    if (dt.Rows.Count > 0)
                                    {
                                        lblViewDetailsProductName.Text = "Forward Note for " + dt.Rows[0]["ProductName"].ToString();
                                        lblBatchNumberAndDOM.Text = dt.Rows[0]["BatchNo"].ToString() + ", " + dt.Rows[0]["MfgDate"].ToString();
                                        lblReceiptDate.Text = dt.Rows[0]["ReceiptDate"].ToString();
                                        lblAtDetails.Text = dt.Rows[0]["AtNo"].ToString();
                                        lblSupplySource.Text = dt.Rows[0]["SupplySource"].ToString();
                                        lblContainerSize.Text = "Shape- " + dt.Rows[0]["Shape"].ToString() + " : " + "Dimensions- " + dt.Rows[0]["Size"].ToString();
                                        lblCurrentEsl.Text = dt.Rows[0]["EslDate"].ToString();
                                        lblBatchStatus.Text = dt.Rows[0]["batchStatus"].ToString();
                                    //}
                                    //EslForwardingNoteEntity ObjEslFnEntity = new EslForwardingNoteEntity();
                                    //DataTable dt = new DataTable();
                                    //string actionName = "FetchAllDetails";
                                    //dt = ObjESLComp.SelectESLIssueGridComponent(actionName, batchid);
                                    //if (dt.Rows.Count > 0)
                                    //{
                                        lblAddressee.Text = dt.Rows[0]["addressee"].ToString();
                                        lblAtDetails.Text = lblAtDetails.Text + ", " + dt.Rows[0]["atNoReferences"].ToString();
                                        lblContainerType.Text = dt.Rows[0]["containerType"].ToString();
                                        lblDesignationAndPostalAddress.Text = dt.Rows[0]["officerDesignation"].ToString() + dt.Rows[0]["officerPostalAddress"].ToString();
                                        lblDispatchDate.Text = dt.Rows[0]["dispatchDate"].ToString();
                                        lblDispatchMethod.Text = dt.Rows[0]["dispatchMethod"].ToString();
                                        lblDrawrNameAndRank.Text = dt.Rows[0]["drawerNameAndRank"].ToString();
                                        lblFillingDate.Text = dt.Rows[0]["fillingDate"].ToString();
                                        lblFnDate.Text = dt.Rows[0]["forwardNoteDate"].ToString();
                                        lblForwardingNoteNo.Text = dt.Rows[0]["forwardingNoteNumber"].ToString();
                                        lblGoverningSupply.Text = dt.Rows[0]["governingSupply"].ToString();
                                        lblGovtStock.Text = dt.Rows[0]["govtStock"].ToString();
                                        lblINoteNoAndDate.Text = dt.Rows[0]["iNoteNumber"].ToString() + dt.Rows[0]["iNoteDate"].ToString();
                                        lblIntendedDestination.Text = dt.Rows[0]["intendedDestination"].ToString();
                                        lblNomenStore.Text = dt.Rows[0]["nomenStore"].ToString();
                                        lblPrevTestReference.Text = dt.Rows[0]["previousTestReferences"].ToString();
                                        lblSampleDrawnDate.Text = dt.Rows[0]["sampleDrawnDate"].ToString();
                                        lblContainerMarkingDetails.Text = dt.Rows[0]["containerMarkingDetails"].ToString();
                                        lblSampleNumbers.Text = dt.Rows[0]["numberOfSamples"].ToString();
                                        lblSampleQuantity.Text = dt.Rows[0]["sampleQualtity"].ToString();
                                        lblSampleQuantityRepresented.Text = dt.Rows[0]["quantityRepressntedBySample"].ToString();
                                        lblSampleReferenceAndIndentity.Text = dt.Rows[0]["sampleRefNumber"].ToString() + dt.Rows[0]["sampleIdentificationMarks"].ToString();
                                        lblSampleType.Text = dt.Rows[0]["sampleType"].ToString();
                                        lblTankNo.Text = dt.Rows[0]["tankNumber"].ToString();
                                        lblTestReason.Text = dt.Rows[0]["reasonForTest"].ToString();
                                        lblTradeGovtAccepted.Text = dt.Rows[0]["tradeGovtAccepted"].ToString();
                                        lblTradeOwned.Text = dt.Rows[0]["tradeOwned"].ToString();

                                    }
                                    else
                                    {
                                        // error quertstring is not well
                                    }
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

        }
    }
}