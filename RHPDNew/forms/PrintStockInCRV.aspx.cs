using RHPDDalc;
using RHPDEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using Telerik.Web.UI;
using System.Web.Services;
using System.Configuration;
using System.Text;

namespace RHPDNew.Forms
{
    public partial class PrintStockInCRV : System.Web.UI.Page
    {
        public static int sBID = 0;
        public static int sSID = 0;
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
                        if (Page.Request["sId"] != null)
                        {
                            int id = Convert.ToInt32(Request.QueryString["sId"]);
                            if (id > 0)
                            {

                                _BindData();
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


        private void _BindData()
        {
            try
            {
                if (Request.QueryString["sId"] != null)
                {


                    int stockID = Convert.ToInt32(Request.QueryString["sId"].ToString());

                    DataTable dt = new DataTable();
                    StockComp stockComp = new StockComp();
                    dt = stockComp.Select(stockID);
                    if (dt.Rows.Count > 0)
                    {
                        int sid = Convert.ToInt32(dt.Rows[0]["SID"].ToString());
                        lblCRV.Text = dt.Rows[0]["CRVNo"].ToString();
                        lblATNo.Text = dt.Rows[0]["ATNo"].ToString();
                        lblRate.Text = dt.Rows[0]["CostOfParticular"].ToString();
                        lblAmount.Text = ((Convert.ToDouble(dt.Rows[0]["Quantity"].ToString())) * (Convert.ToDouble(dt.Rows[0]["CostOfParticular"].ToString()))).ToString();
                        lblRecivedFrom.Text = dt.Rows[0]["OtherSupplier"].ToString();
                        int level = int.Parse(dt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                        string[] fr = dt.Rows[0]["PackingMaterialFormat"].ToString().Split('X');
                        dt.Rows.Add("Nos", dt.Rows[0]["OriginalManf"].ToString() + " " + dt.Rows[0]["PackingMaterial"].ToString() + " " + fr[level - 1], 0, 15819, null, null, null, 1, null, "2016-01-12 19:24:47.360", 1, null, null, null, null, "Bis	", "Britani", null, "2016-01-26 00:00:00.000", null, null, "", "IR1", 1, 0, "Box", null, "AT#786", "Local purchase", "Sudhir", "IDT", null, null, 0, "0", "Sphere", 0, 0, "", "");
                        rgdCRV.DataSource = dt;
                        rgdCRV.DataBind();

                                  lblInWords.Text = "(Rupees " + changeToWords((Convert.ToDouble(dt.Rows[0]["Quantity"].ToString()) * Convert.ToDouble(dt.Rows[0]["CostOfParticular"].ToString())).ToString()) + " Only)";
                        GridDataItem item2 = (GridDataItem)rgdCRV.MasterTableView.Items[1];
                        Label lblB = (Label)item2.FindControl("lblB");
                        lblB.Text = "Quantity:";
                        GridDataItem item = (GridDataItem)rgdCRV.MasterTableView.Items[0];
                       
                        RadGrid rgdChild = (RadGrid)item.FindControl("rgdCRVBatch");
                        GridFooterItem footeritemFull = (GridFooterItem)rgdChild.MasterTableView.GetItems(GridItemType.Footer)[0];
                              //    //Packing total

                        StockPakagingComp pComp = new StockPakagingComp();
                        Label lblCount = (Label)footeritemFull.FindControl("lblCount");
                       
                      
                        Label lblTotalQuatity = (Label)footeritemFull.FindControl("lblTotalQuatity");
                        lblTotalQuatity.Text = dt.Rows[0]["Quantity"].ToString();

                  
                        DataTable dtFull = new DataTable();
                        dtFull = pComp.SelectByStockIdFull(stockID);
                        DataTable dtLoose = new DataTable();
                        dtLoose = pComp.SelectByStockIdLoose(stockID);
                        Label lblTotalLooseFormat = (Label)footeritemFull.FindControl("lblTotalLooseFormat");
                        Label lblTotalFullFormat = (Label)footeritemFull.FindControl("lblTotalFullFormat");
                        double totalQty = 0;
                        double formatQty = 0;
                        string formatFull = "";
                        for (int l = 1; l < level; l++)
                        {
                            formatFull = formatFull + "X" + fr[l].ToString();
                        }
                        for (int i = 0; i < dtFull.Rows.Count; i++)
                        {
                            totalQty = totalQty + Convert.ToInt32(dtFull.Rows[i]["RemainingQty"].ToString());
                            string[] arrFull = dtFull.Rows[i]["Format"].ToString().Split(new char[] { 'X' });
                            formatQty = formatQty + Convert.ToDouble(arrFull[0].ToString());

                        }
                        lblTotalFullFormat.Text = (formatQty.ToString() + formatFull).ToString();
                        double totalQtyLoose = 0;
                        string[] totalLooseFormat = new string[level];
                        for (int i = 0; i < dtLoose.Rows.Count; i++)
                        {
                            totalQtyLoose = totalQtyLoose + Convert.ToInt32(dtLoose.Rows[i]["RemainingQty"].ToString());
                            string[] arrLoose = dtLoose.Rows[i]["Format"].ToString().Split(new char[] { '|' });
                            for (int l = 0; l < level; l++)
                            {
                                totalLooseFormat[l] = (Convert.ToDouble(totalLooseFormat[l]) + Convert.ToDouble(arrLoose[l])).ToString();
                            }
                        }
                        string looseFormat = totalLooseFormat[0].ToString();
                        for (int l = 1; l < level; l++)
                        {
                            looseFormat = looseFormat + "|" + totalLooseFormat[l].ToString();
                        }

                        lblTotalLooseFormat.Text = looseFormat;

                        string[] fulQty = (lblTotalFullFormat.Text).Split('X');
                        string[] looseQty = (lblTotalLooseFormat.Text).Split('|');
                        lblB.Text = lblB.Text + (Convert.ToDouble(fulQty[0]) + Convert.ToDouble(looseQty[0])).ToString();
                        lblCount.Text =((( dtFull.Rows.Count + dtLoose.Rows.Count)/2)+(( dtFull.Rows.Count + dtLoose.Rows.Count)%2)).ToString();
                        //Vehicle
                        StockVehicleComp vComp = new StockVehicleComp();
                        DataTable dtVehicle = new DataTable();
                        dtVehicle = vComp.SelectByStockId(stockID);
                        for (int i = 0; i < dtVehicle.Rows.Count; i++)
                        {
                            if (i == dtVehicle.Rows.Count - 1)
                                lblVechicleNo.Text = lblVechicleNo.Text + dtVehicle.Rows[i]["VehicleNo"].ToString();
                            else
                                lblVechicleNo.Text = lblVechicleNo.Text + dtVehicle.Rows[i]["VehicleNo"].ToString() + ",";
                        }




                    }





                }//if ends


            }
            catch (Exception)
            {

                throw;
            }
        }
        public String changeToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = ("point");// just to separate whole numbers from points/Rupees

                    }
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch
            {
                ;
            }
            return val;
        }
        private String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))

                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch
            {
                ;
            }
            return word.Trim();
        }

        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        protected void rgdCRVBatch_ItemCreated(object sender, GridItemEventArgs e)
        {
            //if (!IsPostBack)
            {
                if (e.Item is GridDataItem)
                {
                    int stockId = Convert.ToInt32(Request.QueryString["sId"].ToString());
                    GridDataItem item = (e.Item as GridDataItem);
                    int BactchID = int.Parse(item.GetDataKeyValue("BID").ToString());
                    if (sBID != BactchID)
                    {
                        sBID = BactchID;
                    }
                    else
                    {
                        Label lblBatchNo = (Label)item.FindControl("lblBatchNo");
                        lblBatchNo.Visible = false;
                        Label lblMFGDate = (Label)item.FindControl("lblMFGDate");
                        lblMFGDate.Visible = false;
                        Label lblEsl = (Label)item.FindControl("lblEsl");
                        lblEsl.Visible = false;
                        Label lblEXPDate = (Label)item.FindControl("lblEXPDate");
                        lblEXPDate.Visible = false;
                       
                        

                    }
                   



                }

            }
        }
        protected void rgdCRV_ItemCreated(object sender, GridItemEventArgs e)
        {
            // if (!IsPostBack)
            {
                if (e.Item is GridDataItem)
                {
                    int stockId = Convert.ToInt32(Request.QueryString["sId"].ToString());

                    GridDataItem item = (e.Item as GridDataItem);
                    int keyID = int.Parse(item.GetDataKeyValue("SID").ToString());
                    RadGrid rgdChild = (RadGrid)item.FindControl("rgdCRVBatch");
                    if (keyID != stockId)
                    {
                        rgdChild.Visible = false;

                        Label lblB = (Label)item.FindControl("lblB");
                        lblB.Text = "-";
                       
                         }
                    else if (keyID == stockId)
                    {

                        StockPakagingComp pComp = new StockPakagingComp();
                        DataTable dtChild = new DataTable();
                        dtChild = pComp.SelectByStockId(stockId);
                        rgdChild.DataSource = dtChild;
                        rgdChild.DataBind();
                
                    }


                }

            }
        }



    }
}