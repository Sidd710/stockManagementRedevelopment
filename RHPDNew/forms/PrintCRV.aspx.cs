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
using System.Globalization;

namespace RHPDNew.Forms
{
    public partial class PrintCRV : System.Web.UI.Page
    {
        public static int sBID = 0;
        public static int sSID = 0;
        public static int sStockID = 0;
        public static string AU = "";
        public static int Case = 0;
        public static string stcokCase = "";
     

        public string ConvertNumberToWord(string MyNumber)
        {
            string DecimalPart, DecimalPartWord, RealPart, RealPartWord;
            int k, RealPartLength;
            //string Place2=" Thousand ", Place3=" Lakh ", Place4=" Crore ", Place5=" Billion ", Place6=" Trillion ";
            MyNumber = MyNumber.Trim();
            //////////////////////////////// Split MyNumber into RealPart and DecimalPart ///////////////////////////////////////
            k = MyNumber.IndexOf(".");
            if (k < 0)
            {
                DecimalPart = ""; //There is no decimal part
                RealPart = MyNumber.Replace(",", ""); //Remove all coma if any
            }
            else if (k == 0)
            {
                DecimalPart = MyNumber.Substring(k, 2);
                RealPart = ""; //There is no real part
            }
            else
            {
                DecimalPart = MyNumber.Substring(k + 1, 2);
                RealPart = MyNumber.Remove(k);
                RealPart = RealPart.Replace(",", ""); //Remove all coma if any
            }
            ////////////////////////////////// Convert DecimalPart into DecimalPartWord ///////////////////////////////////////////////////
            if (DecimalPart != "")
                DecimalPartWord = ConvertDoubleDigit(DecimalPart);
            else
                DecimalPartWord = "";
            ////////////////////////////////////// Convert RealPart into Word /////////////////////////////////////////////////
            RealPartLength = RealPart.Length;
            if (RealPartLength == 1)
                RealPartWord = ConvertSingleDigit(RealPart);
            else if (RealPartLength == 2)
                RealPartWord = ConvertDoubleDigit(RealPart);
            else if (RealPartLength == 3)
                RealPartWord = ConvertHundred(RealPart);
            else if (RealPartLength > 3 && RealPartLength < 6)
                RealPartWord = ConvertThousand(RealPart, RealPartLength);
            else if (RealPartLength > 5 && RealPartLength < 8)
                RealPartWord = ConvertLakh(RealPart, RealPartLength);
            else
                RealPartWord = ConvertCrore(RealPart, RealPartLength);
            // ////////////////Return /////////////////////////
            if (RealPartWord == "" && DecimalPartWord == "")
                return "";
            else if (RealPartWord != "" && DecimalPartWord != "")
                return "Rupees " + RealPartWord + " and Paise " + DecimalPartWord + " only";
            else if (RealPartWord != "" && DecimalPartWord == "")
                return "Rupees " + RealPartWord + " only";
            else
                return " Rupees " + DecimalPartWord+" only";

        }
        ///////////////////////////////////////// Convert Hundred Part into Word ///////////////////////////////////////////////
        private string ConvertHundred(string MyNumber)
        {
            string Result;
            if (MyNumber.Remove(1, 2) != "0")
            {
                if (ConvertSingleDigit(MyNumber.Remove(1, 2)) == "")
                    Result = "";
                else
                    Result = ConvertSingleDigit(MyNumber.Remove(1, 2)) + " Hundred ";
            }
            else
                Result = "";
            Result = Result + ConvertDoubleDigit(MyNumber.Remove(0, 1));
            return Result;
        }
        ///////////////////////////////////////// Convert Thousand Part into Word ///////////////////////////////////////////////
        private string ConvertThousand(string MyNumber, int Ln)
        {
            string Result;
            if (Ln >= 5)
            {
                if (ConvertDoubleDigit(MyNumber.Remove(2, 3)) == "")
                    Result = "";
                else
                    Result = ConvertDoubleDigit(MyNumber.Remove(2, 3)) + " Thousand ";
                Result = Result + ConvertHundred(MyNumber.Remove(0, 2));
            }
            else
            {
                if (ConvertSingleDigit(MyNumber.Remove(1, 3)) == "")
                    Result = "";
                else
                    Result = ConvertSingleDigit(MyNumber.Remove(1, 3)) + " Thousand ";
                Result = Result + ConvertHundred(MyNumber.Remove(0, 1));
            }
            return Result;
        }
        ///////////////////////////////////////// Convert Lakh Part into Word ///////////////////////////////////////////////
        private string ConvertLakh(string MyNumber, int Ln)
        {
            string Result;
            if (Ln >= 7)
            {
                if (ConvertDoubleDigit(MyNumber.Remove(2, 5)) == "")
                    Result = "";
                else
                    Result = ConvertDoubleDigit(MyNumber.Remove(2, 5)) + " Lakh ";
                Result = Result + ConvertThousand(MyNumber.Remove(0, 2), 7);
            }
            else
            {
                if (ConvertSingleDigit(MyNumber.Remove(1, 5)) == "")
                    Result = "";
                else
                    Result = ConvertSingleDigit(MyNumber.Remove(1, 5)) + " Lakh ";
                Result = Result + ConvertThousand(MyNumber.Remove(0, 1), 6);
            }
            return Result;
        }
        ///////////////////////////////////////// Convert Crore Part into Word ///////////////////////////////////////////////
        private string ConvertCrore(string MyNumber, int Ln)
        {
            string Result;
            if (Ln >= 9)
            {
                if (ConvertDoubleDigit(MyNumber.Remove(2, 7)) == "")
                    Result = "";
                else
                    Result = ConvertDoubleDigit(MyNumber.Remove(2, 7)) + " Crore ";
                Result = Result + ConvertLakh(MyNumber.Remove(0, 2), 9);
            }
            else
            {
                if (ConvertSingleDigit(MyNumber.Remove(1, 7)) == "")
                    Result = "";
                else
                    Result = ConvertSingleDigit(MyNumber.Remove(1, 7)) + " Crore ";
                Result = Result + ConvertLakh(MyNumber.Remove(0, 1), 8);
            }
            return Result;
        }
        /////////////////////////////////////////// Convert Double Digit into Word ////////////////////////////////////////////////////
        private string ConvertDoubleDigit(string MyNumber)
        {
            string Result;
            if (MyNumber.Remove(1, 1) == "0")
                Result = ConvertSingleDigit(MyNumber.Remove(0, 1));
            else
            {
                if (MyNumber.Remove(1, 1) == "1") // Is Decimal part between 11 & 19
                {
                    switch (Convert.ToInt16(MyNumber))
                    {
                        case 10: Result = "Ten"; break;
                        case 11: Result = "Eleven"; break;
                        case 12: Result = "Twelve"; break;
                        case 13: Result = "Thirteen"; break;
                        case 14: Result = "Fourteen"; break;
                        case 15: Result = "Fifteen"; break;
                        case 16: Result = "Sixteen"; break;
                        case 17: Result = "Seventeen"; break;
                        case 18: Result = "Eighteen"; break;
                        default: Result = "Nineteen"; break;
                    }
                }
                else //otherwise its between 20 & 99
                {
                    switch (Convert.ToInt16(MyNumber.Remove(1, 1)))
                    {
                        case 2: Result = " Twenty "; break;
                        case 3: Result = " Thirty "; break;
                        case 4: Result = " Fourty "; break;
                        case 5: Result = " Fifty "; break;
                        case 6: Result = " Sixty "; break;
                        case 7: Result = " Seventy "; break;
                        case 8: Result = " Eighty "; break;
                        case 9: Result = " Ninety "; break;
                        default: Result = " "; break;
                    }
                    Result = Result + ConvertSingleDigit(MyNumber.Remove(0, 1)); //Convert one's place digit
                }
            }
            return Result;
        }
        /////////////////////////////////////// Convert Single Digit into Word /////////////////////////////////////////////////////
        private string ConvertSingleDigit(String MyNumber)
        {
            string Result;
            switch (Convert.ToInt16(MyNumber))
            {
                case 1: Result = "One"; break;
                case 2: Result = "Two"; break;
                case 3: Result = "Three"; break;
                case 4: Result = "Four"; break;
                case 5: Result = "Five"; break;
                case 6: Result = "Six"; break;
                case 7: Result = "Seven"; break;
                case 8: Result = "Eight"; break;
                case 9: Result = "Nine"; break;
                default: Result = ""; break;
            }
            return Result;
        }
        
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
                   
                    try
                    {                              _BindData();
                           
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

     
        private void _GetGrid(string crvNo,int ProductID,bool check)
        {
            try
            {StockComp stockComp = new StockComp();
                 DataTable dtCRV = new DataTable();
                 DataTable dtPM = new DataTable();
                 DataTable dtSubPM = new DataTable();
                 DataTable dt = new DataTable();                
                 dt = stockComp.SelectByCRVNo(crvNo, ProductID);
                    
                    dtCRV = dt.Clone();
                    dtPM = dt.Clone();
                    dtSubPM = dt.Clone();
                    string PM = "";
                    string SUBPM = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                      if(dt.Rows.Count<2)
                          dr["Remarks"] =  dr["Remarks1"];
                          else
                          dr["Remarks"] = "[" + (dr["RecievedFrom"].ToString() == "Local purchase" ? "LP" : "CP") + "] " + dr["Remarks1"];
                       

                        if (Convert.ToBoolean(dr["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(dr["IsWithoutPacking"].ToString()) == true)
                        {
                            dr["CatID"] = dr["SID"];
                            dtCRV.ImportRow(dr);
                        }
                        else
                        {
                            dr["CatID"] = dr["SID"];

                            dtCRV.ImportRow(dr);

                            if (PM != dr["PMName"].ToString())
                            {                                
                                PM = dr["PMName"].ToString();
                                dtPM.Rows.Add(dr["SID"], 1, "", "", "", 0, "", "", 0, 0, "", "", "", "", "", 0, "", "Nos", dr["PMName"].ToString() + dr["PackingMaterial"].ToString(), "", 0, 1, "", "", 4, "", 4, "", "", "", "", null, "	", null, null, DateTime.Now.TimeOfDay.Milliseconds, 0, "", "2016-01-19 14:33:00.837", "2016-01-19 14:33:00.837", 0, 0, "");
                            }
                           
                            if (Convert.ToBoolean(dr["IsSubPacking"]) == true)
                            {
                                if (SUBPM != dr["SUBPMName"].ToString())
                                {
                                    SUBPM = dr["SUBPMName"].ToString();
                                    dtSubPM.Rows.Add(dr["SID"], 2, "", "", "", 0, "", "", 0, 0, "", "", "Sub", "", "", 0, "", "Nos", dr["SUBPMName"].ToString(), "", 0, 1, "", "", 4, "", 4, "", "", "", "", null, "	", null, null, DateTime.Now.TimeOfDay.Milliseconds, 0, "", "2016-01-19 14:33:00.837", "2016-01-19 14:33:00.837", 0, 0, "");
                                }
                            }

                        }
                    }
                    dtCRV.Merge(dtPM);
                    dtCRV.Merge(dtSubPM);
                    Boolean amountShow = true;
                    if (dtCRV.Rows.Count > 0)
                    {

                        if (dt.Rows[0]["TransferedBy"].ToString() == "None" && dt.Rows[0]["RecievedFrom"].ToString() == "Local purchase")
                            amountShow = true;
                        else
                            amountShow = false;
                    }

                    if (check == true)
                    {
                        rgdCRVWithouPAcking.Visible = true;
                        rgdCRV.Visible = false;
                        rgdCRVWithouPAcking.DataSource = dtCRV;
                        rgdCRVWithouPAcking.DataBind();
                        foreach (GridColumn myColumn in rgdCRVWithouPAcking.MasterTableView.RenderColumns)
                        {
                            if (myColumn.UniqueName == "Amount")

                                myColumn.Visible =  amountShow;


                        }
                    }
                    else
                    {
                        rgdCRVWithouPAcking.Visible = false;
                        rgdCRV.Visible = true;
                        rgdCRV.DataSource = dtCRV;
                        rgdCRV.DataBind();
                        foreach (GridColumn myColumn in rgdCRV.MasterTableView.RenderColumns)
                        {                           
                            if (myColumn.UniqueName == "Amount")

                                myColumn.Visible =  amountShow;


                        }
                    }
                    lblCountItems.Text = "(Items " + NumWordsWrapper(dtCRV.Rows.Count) + " Only)";

                   
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void _BindData()
        {
            try
            {
                if (Request.QueryString["cNo"] != null)
                {
                    StockComp stockComp = new StockComp();
                    string crvNo = (Request.QueryString["cNo"].ToString());
                    int productID = int.Parse(Request.QueryString["pID"].ToString());
                       
                    DataTable dtCRV = new DataTable();
                    dtCRV = stockComp.SelectByCRVNo(crvNo,productID);
                    DataTable dt = new DataTable();
                    dt = stockComp.SelectByCRVNo(crvNo, productID);
                    if (dtCRV.Rows.Count > 0)
                    {
                        Boolean amountShow = true;
                        if (dt.Rows[0]["TransferedBy"].ToString() == "None" && dt.Rows[0]["RecievedFrom"].ToString() == "Local purchase")
                            amountShow = true;
                        else
                            amountShow = false;
                        AU = dt.Rows[0]["AU"].ToString();

                        if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                        {
                            stcokCase = "Product with packging";
                            Case = 1;
                        }
                        else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == true)
                        {
                            stcokCase = "Product with Packaging with DW";
                            Case = 2;

                        }
                        else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                        {
                            stcokCase = "Product with packaging with Sub packaging"; Case = 3;
                        }
                        else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                        {
                            stcokCase = "Packaging without product"; Case = 4;
                        }
                        else if (Convert.ToBoolean(dt.Rows[0]["IsEmptyPM"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsWithoutPacking"].ToString()) == true && Convert.ToBoolean(dt.Rows[0]["IsSubPacking"].ToString()) == false && Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == false)
                        {
                            stcokCase = "Product without PACKAGING"; Case = 5;
                        }
                        bool check = Convert.ToBoolean(dtCRV.Rows[0]["IsEmptyPM"].ToString());
                        if (check == false)
                        { check = Convert.ToBoolean(dtCRV.Rows[0]["IsWithoutPacking"].ToString()); }
                        _GetGrid(crvNo, productID, check);

                        //  rgdCRVList.DataSource = dtCRV;
                        //  rgdCRVList.DataBind();
                        
                        if (dt.Rows[0]["RecievedFrom"].ToString() == "Local purchase")
                        {
                            lblATSO.InnerText = "SO No:";

                        }
                        else
                        {
                           
                            lblATSO.InnerText = "AT No:";

                        }
                        string cat = "";
                        double inWords = 0;
                        string AtSoNo = "";
                        Boolean AT = false;
                        Boolean SO = false;
                        // lblATNo.Text = dtCRV.Rows[0]["ATSONo"].ToString();
                        for (int i = 0; i < dtCRV.Rows.Count; i++)
                        {
                            inWords = inWords + (Convert.ToDouble(dtCRV.Rows[i]["Quantity"].ToString()) * Convert.ToDouble(dtCRV.Rows[i]["CostOfParticular"].ToString()));
                            cat = cat + dtCRV.Rows[0]["Cat"].ToString() + ",";

                            if (i > 0)
                            {
                                if (dtCRV.Rows[i]["ATNO"].ToString() != "")
                                {
                                    AT = true;
                                    AtSoNo = AtSoNo + "," + dtCRV.Rows[i]["ATNO"].ToString();
                                }
                                if (dtCRV.Rows[i]["SupplierNo"].ToString() != "")
                                {
                                    SO = true;
                                    AtSoNo = AtSoNo + "," + dtCRV.Rows[i]["SupplierNo"].ToString();
                                }
                            }
                            else
                            {
                                if (dtCRV.Rows[i]["ATNO"].ToString() != "")
                                {
                                    AT = true;
                                    AtSoNo = AtSoNo + dtCRV.Rows[i]["ATNO"].ToString();
                                }
                                if (dtCRV.Rows[i]["SupplierNo"].ToString() != "")
                                {
                                    SO   = true;
                                    AtSoNo = AtSoNo + dtCRV.Rows[i]["SupplierNo"].ToString();
                                }
                            }
                        }
                        if(AT ==true && SO==true)
                            lblATSO.InnerText = "AT/SO No:";
                        else
                            if(AT==true)
                                lblATSO.InnerText = "AT No:";
                            else if (SO == true)
                                lblATSO.InnerText = "SO No:";
                        string[] AtSoNoList = AtSoNo.Split(',');

                        AtSoNoList = AtSoNoList.Distinct().ToArray();
                        for (int l = 0; l < AtSoNoList.Count() ; l++)
                        {

                            //lblATNo.Text = lblATNo.Text + AtSoNoList[l] + "/";
                            if (AtSoNoList.Count()-1 == l)
                                lblATNo.Text = lblATNo.Text + AtSoNoList[l];
                            else
                                lblATNo.Text = lblATNo.Text + AtSoNoList[l] + ", ";

                        }
                       
                        string[] catList = cat.Split(',');

                        catList = catList.Distinct().ToArray();

                        for (int l = 0; l < catList.Count() - 1; l++)
                        {

                            lblCRV.Text = lblCRV.Text + catList[l] + "/";
                            if (catList.Count() == l)
                                lblCatogory.Text = lblCatogory.Text + catList[l];
                            else
                                lblCatogory.Text = lblCatogory.Text + catList[l] + ", ";

                        }
                        lblCatogory.Text = lblCatogory.Text + " group vide DS No. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt" + Convert.ToDateTime(dtCRV.Rows[0]["RecievedOn"].ToString()).ToString("dd-MM-yyyy"); ;

                        lblCRV.Text = lblCRV.Text + "CRV/" + dtCRV.Rows[0]["CRVNo"].ToString() + "dt " + Convert.ToDateTime(dtCRV.Rows[0]["RecievedOn"].ToString()).ToString("dd-MM-yyyy");
                       // lblCRVdt.Text = lblCRVdt.Text + Convert.ToDateTime(dtCRV.Rows[0]["RecievedOn"].ToString()).ToString("dd-MM-yyyy");
                        // lblInWords.Text = lblATNo"(Rupees " + NumWordsWrapper(inWords) + " Only)";
                      
                        //

                        //lblRecivedFrom.Text = dtCRV.Rows[0]["OtherSupplier"].ToString();

                        string[] osList = dtCRV.Rows[0]["OtherSupplier"].ToString().Split(',');

                        osList = osList.Distinct().ToArray();

                        for (int l = 0; l < osList.Count(); l++)
                        {
                            if (l == osList.Count() - 1)
                                lblRecivedFrom.Text = lblRecivedFrom.Text + osList[l];
                            else
                                lblRecivedFrom.Text = lblRecivedFrom.Text + osList[l] + ", ";



                        }
                        StockVehicleComp vComp = new StockVehicleComp();
                        DataTable dtVehicle = new DataTable();
                        dtVehicle = vComp.SelectVehicleNoStockId(int.Parse(dtCRV.Rows[0]["SID"].ToString()));
                        DataTable dtv = new DataTable();
                        dtv = vComp.SelectByStockId(int.Parse(dtCRV.Rows[0]["SID"].ToString()));
                        string VNo = "";
                        string CNO = "";
                        string Exist = "";
                        for (int i = 0; i < dtVehicle.Rows.Count; i++)
                        {
                            VNo = dtVehicle.Rows[i]["VehicleNo"].ToString() + "[";
                            CNO = "";
                            foreach (DataRow dr in dtv.Rows)
                            {
                                if (dr["VehicleNo"].ToString() == dtVehicle.Rows[i]["VehicleNo"].ToString())
                                {
                                    if (Exist != dr["ChallanNo"].ToString())
                                    {
                                        Exist = dr["ChallanNo"].ToString();
                                        if (CNO != "")
                                            CNO = CNO + "," + dr["ChallanNo"].ToString();
                                        else
                                            CNO = dr["ChallanNo"].ToString();
                                    }
                                }
                            }
                            VNo = VNo+ CNO + "]";
                            if (i == dtVehicle.Rows.Count - 1)
                                lblVechicleNo.Text = lblVechicleNo.Text + VNo;
                            else
                                lblVechicleNo.Text = lblVechicleNo.Text + VNo + ", ";
                        }

                        bool ESL = true;
                        bool EXP = true;
                        double tottalProductQty = 0;
                        double totalAmount = 0;

                        // foreach (GridDataItem rgdCRVListItem in rgdCRVList.MasterTableView.Items)
                        {
                            // RadGrid rgdCRV = (RadGrid)rgdCRVListItem.FindControl("rgdCRV");
                            double qty = 0;
                            double qtyPack = 0;
                            double fqty = 0;
                            double subQty = 0;
                            int show = 0;
                            
                            if (Convert.ToBoolean(dtCRV.Rows[0]["IsEmptyPM"].ToString()) == true || Convert.ToBoolean(dtCRV.Rows[0]["IsWithoutPacking"].ToString()) == true)
                            {

                                foreach (GridDataItem rgdCRVItem in rgdCRVWithouPAcking.MasterTableView.Items)
                                {
                                    HiddenField hdnBID = (HiddenField)rgdCRVItem.FindControl("hdnBID");
                                    RadGrid rgdBatchWithoutPacking = (RadGrid)rgdCRVItem.FindControl("rgdBatchWithoutPacking");
                                    Label lblCost = (Label)rgdCRVItem.FindControl("lblCost");
                                         int SID = Convert.ToInt32(rgdCRVItem.GetDataKeyValue("SID").ToString());
                                    StockBatchComp bcmp = new StockBatchComp();
                                    DataTable bdt = new DataTable();
                                    bdt = bcmp.SelectByStockId(SID);
                                    rgdBatchWithoutPacking.DataSource = bdt;
                                    rgdBatchWithoutPacking.DataBind();
                                  
                                    foreach (GridDataItem rgdCRVBatchItem in rgdBatchWithoutPacking.MasterTableView.Items)
                                    {
                                        Label lblEsl = (Label)rgdCRVBatchItem.FindControl("lblEsl");
                                        if (lblEsl.Text == "N/A")
                                            ESL = false;
                                        else
                                            ESL = true;
                                        Label lblEXPDate = (Label)rgdCRVBatchItem.FindControl("lblEXPDate");
                                        if (lblEXPDate.Text == "N/A")
                                            EXP = false;
                                        else
                                            EXP = true;
                                    }
                                    double amount = 0;
                                    int count = 0;
                                   
                                     List<int> chkBID = new List<int>();
                                    foreach (DataRow dr in bdt.Rows)
                                    {                                       
                                            int val=int.Parse(dr["BID"].ToString());
                                            var exi = chkBID.Where(x=>x==val).FirstOrDefault();
                                            if (exi != null)
                                               
                                            chkBID.Add(int.Parse(dr["BID"].ToString()));
                                        amount = amount + double.Parse(dr["CostOfParticular"].ToString());
                                    }
                                    if (chkBID.Count==1)
                                    {
                                        rgdBatchWithoutPacking.ShowFooter = false;
                                        rgdBatchWithoutPacking.MasterTableView.ShowFooter = false;
                                    }
                                    else
                                    {
                                        rgdBatchWithoutPacking.ShowFooter = true;
                                        rgdBatchWithoutPacking.MasterTableView.ShowFooter = true;
                                    }
                                    if (amount > 0)
                                        lblCost.Text =TruncateDecimalToString(amount, 2).ToString();
                                    totalAmount = totalAmount + amount;
                                  
                                    foreach (GridColumn myColumn in rgdBatchWithoutPacking.MasterTableView.RenderColumns)
                                    {

                                        if (myColumn.UniqueName == "EXPDate")

                                            myColumn.Visible = EXP;

                                        if (myColumn.UniqueName == "Esl")

                                            myColumn.Visible = ESL;

                                        if (myColumn.UniqueName == "Amount")

                                            myColumn.Visible = amountShow;


                                    }
                                    foreach(DataRow dr in bdt.Rows)
                                    {
                                    tottalProductQty=tottalProductQty+double.Parse(dr["QTY"].ToString());
                                    }
                                }

                            }
                            else
                            {

                                foreach (GridDataItem rgdCRVItem in rgdCRV.MasterTableView.Items)
                                {
                                    RadGrid rgdCRVBatch = (RadGrid)rgdCRVItem.FindControl("rgdCRVBatch");
                                    HiddenField hdnBID = (HiddenField)rgdCRVItem.FindControl("hdnBID");
                                    HiddenField hSID = (HiddenField)rgdCRVItem.FindControl("hdnSID");
                                    HiddenField hdnLevel = (HiddenField)rgdCRVItem.FindControl("hdnLevel");

                                    Label lblCost = (Label)rgdCRVItem.FindControl("lblCost");
                                    //if (lblCost.Text != "")
                                    //    totalAmount = totalAmount + double.Parse(lblCost.Text);
                                    ////  RadGrid rgdBatchWithoutPacking = (RadGrid)item.FindControl("rgdBatchWithoutPacking");

                                    int SID = Convert.ToInt32(rgdCRVItem.GetDataKeyValue("SID").ToString());
                                    Label lblB = (Label)rgdCRVItem.FindControl("lblB");
                                    Label lblSubPacking = (Label)rgdCRVItem.FindControl("lblSubPacking");


                                    if (hdnBID.Value == "")
                                    {

                                        StockPakagingComp pComp = new StockPakagingComp();
                                        DataTable dtChild = new DataTable();
                                        dtChild = pComp.SelectByStockId(SID);
                                        rgdCRVBatch.DataSource = dtChild;
                                        rgdCRVBatch.DataBind();
                                       
                                        double amount = 0;
                                        int count = 0;
                                      //  int chkBID=0;
                                        List<int> chkBID = new List<int>();
                                        foreach (DataRow dr in dtChild.Rows)
                                        {
                                           // amount = amount + double.Parse(dr["Cost"].ToString());
                                            int val=int.Parse(dr["BID"].ToString());
                                            var exi = chkBID.Where(x=>x==val).FirstOrDefault();
                                            if (exi != null)                                               
                                                chkBID.Add(int.Parse(dr["BID"].ToString()));
                                                amount = amount + double.Parse(dr["CostOfParticular"].ToString()) * double.Parse(dr["RemainingQty"].ToString());
                                    
                                        }
                                        if (chkBID.Count==1)
                                        {
                                            rgdCRVBatch.ShowFooter = false;
                                            rgdCRVBatch.MasterTableView.ShowFooter = false;
                                        }
                                        else
                                        {
                                            rgdCRVBatch.ShowFooter = true;
                                            rgdCRVBatch.MasterTableView.ShowFooter = true;
                                        }
                                        if (amount > 0)
                                            lblCost.Text = TruncateDecimalToString(amount, 2).ToString();
                                        totalAmount = totalAmount + amount;
                                        if (show > 0)
                                        {
                                            rgdCRVBatch.ShowHeader = false;
                                            rgdCRVBatch.MasterTableView.ShowHeader = false;
                                        }
                                        show++;
                                    }
                                    else
                                    {
                                        rgdCRVBatch.Visible = false;
                                        lblB.Text = "-";

                                    }
                                    sBID = 0;
                                    foreach (GridDataItem rgdCRVBatchItem in rgdCRVBatch.MasterTableView.Items)
                                    {
                                        int BactchID = int.Parse(rgdCRVBatchItem.GetDataKeyValue("BID").ToString());
                                        if (sBID != BactchID)
                                        {
                                            sBID = BactchID;
                                            Label lblEsl = (Label)rgdCRVBatchItem.FindControl("lblEsl");
                                            if (lblEsl.Text == "N/A")
                                                ESL = false;
                                            else
                                                ESL = true;
                                            Label lblEXPDate = (Label)rgdCRVBatchItem.FindControl("lblEXPDate");
                                            if (lblEXPDate.Text == "N/A")
                                                EXP = false;
                                            else
                                                EXP = true;
                                            
                                        }
                                        else
                                        {
                                            Label lblBatchNo = (Label)rgdCRVBatchItem.FindControl("lblBatchNo");
                                            lblBatchNo.Visible = false;
                                            Label lblMFGDate = (Label)rgdCRVBatchItem.FindControl("lblMFGDate");
                                            lblMFGDate.Visible = false;
                                            Label lblEsl = (Label)rgdCRVBatchItem.FindControl("lblEsl");
                                            lblEsl.Visible = false;
                                            Label lblEXPDate = (Label)rgdCRVBatchItem.FindControl("lblEXPDate");
                                            lblEXPDate.Visible = false;
                                            Label lblCost1 = (Label)rgdCRVBatchItem.FindControl("lblCostAU");
                                            lblCost1.Visible = false;
                                            Label lblWeight = (Label)rgdCRVBatchItem.FindControl("lblWeight");
                                            lblWeight.Visible = false;

                                            DataTable dtQty = new DataTable();
                                            StockPakagingComp cmpP = new StockPakagingComp();
                                            dtQty = cmpP.SelectByBatchId(BactchID);
                                            qtyPack = 0;
                                            if (dtQty.Rows.Count > 0)
                                            {
                                                if (dtQty.Rows[0]["PackagingType"].ToString() == "Full")
                                                {
                                                    string[] arr = dtQty.Rows[0]["Format"].ToString().Split('X');
                                                    qtyPack = qtyPack + double.Parse(arr[0]);
                                                }
                                                qty = qty + double.Parse(dtQty.Rows[0]["RemainingQty"].ToString());
                                                if (dtQty.Rows[0]["PackagingType"].ToString() == "Loose")
                                                {
                                                    string[] arr = dtQty.Rows[0]["Format"].ToString().Split('|');
                                                    qtyPack = qtyPack + double.Parse(arr[0]);
                                                }
                                                //qty = qty + double.Parse(dtQty.Rows[0]["RemainingQty"].ToString());
                                            }
                                            if (dtQty.Rows.Count > 1)
                                            {
                                                if (dtQty.Rows[1]["PackagingType"].ToString() == "Full")
                                                {
                                                    string[] arr = dtQty.Rows[1]["Format"].ToString().Split('X');
                                                    qtyPack = double.Parse(arr[0]);
                                                }
                                                qty = qty + double.Parse(dtQty.Rows[1]["RemainingQty"].ToString());
                                                if (dtQty.Rows[1]["PackagingType"].ToString() == "Loose")
                                                {
                                                    string[] arr = dtQty.Rows[1]["Format"].ToString().Split('|');
                                                    qtyPack = qtyPack + double.Parse((arr[0]));
                                                }
                                            }
                                            Label lblthisFormatQty = (Label)rgdCRVBatchItem.FindControl("lblthisFormatQty");
                                            lblthisFormatQty.Visible = true;
                                            lblthisFormatQty.Text = "Total Packs: " + TruncateDecimal(qtyPack, 3).ToString("0");
                                            Label lblthisFullQty = (Label)rgdCRVBatchItem.FindControl("lblthisFullQty");
                                            lblthisFullQty.Visible = true;
                                            lblthisFullQty.Text = " Total Qty: " + TruncateDecimalToString(qty, 3);


                                            qtyPack = 0;
                                            qty = 0;

                                        }
                                    }
                                    foreach (GridColumn myColumn in rgdCRVBatch.MasterTableView.RenderColumns)
                                    {

                                        if (myColumn.UniqueName == "EXPDate")

                                            myColumn.Visible = EXP;

                                        if (myColumn.UniqueName == "Esl")

                                            myColumn.Visible = ESL;
                                        if (myColumn.UniqueName == "Amount")

                                            myColumn.Visible = amountShow;


                                    }
                                    fqty = 0;
                                     dt = new DataTable();
                                    dt = stockComp.Select(SID);
                                    if (dt.Rows.Count > 0)
                                    {
                                        int sid = Convert.ToInt32(dt.Rows[0]["SID"].ToString());
                                        int level = int.Parse(dt.Rows[0]["PackagingMaterialFormatLevel"].ToString());
                                        string[] fr = dt.Rows[0]["PackingMaterialFormat"].ToString().Split('X');
                                        GridDataItem item2 = (GridDataItem)rgdCRV.MasterTableView.Items[1];

                                        GridDataItem item3 = (GridDataItem)rgdCRV.MasterTableView.Items[0];
                                        // RadGrid rgdChild = (RadGrid)item3.FindControl("rgdCRVBatch");
                                        if (rgdCRVBatch.Visible != false)
                                        {
                                            GridFooterItem footeritemFull = (GridFooterItem)rgdCRVBatch.MasterTableView.GetItems(GridItemType.Footer)[0];
                                            //////    //Packing total

                                            StockPakagingComp pComp = new StockPakagingComp();
                                            Label lblCount = (Label)footeritemFull.FindControl("lblCount");
                                            Label lblTotalQuatity = (Label)footeritemFull.FindControl("lblTotalQuatity");
                                            if (AU == "NOS")
                                                lblTotalQuatity.Text = TruncateDecimal(Convert.ToDouble(dt.Rows[0]["Quantity"]), 3).ToString("0.00");
                                       
                                                else
                                            lblTotalQuatity.Text = TruncateDecimal(Convert.ToDouble(dt.Rows[0]["Quantity"]), 3).ToString("0.000");
                                            Label lblTotalLooseFormat = (Label)footeritemFull.FindControl("lblTotalLooseFormat");
                                            Label lblTotalFullFormat = (Label)footeritemFull.FindControl("lblTotalFullFormat");
                                            if (Convert.ToBoolean(dt.Rows[0]["IsDW"].ToString()) == true)
                                            {
                                                DataTable dtDW = new DataTable();
                                                dtDW = pComp.SelectDWByStockId(SID);
                                                double tottalPack = 0;
                                                foreach (DataRow dr in dtDW.Rows)
                                                {
                                                    fqty = fqty + Convert.ToDouble(dr["RemainingQty"].ToString());

                                                    string[] full = dr["Format"].ToString().Split('X');
                                                    if (full.Count() > 0)
                                                    {
                                                       
                                                        tottalPack = tottalPack + Convert.ToDouble(full[0]);
                                                    }
                                
                                                }
                                                lblTotalFullFormat.Text = tottalPack.ToString("0") + " X DW";
                                                if(AU=="NOS")
                                                    lblTotalQuatity.Text = fqty.ToString("0.00");
                                                else
                                                lblTotalQuatity.Text = fqty.ToString("0.000");
                                            }
                                            else
                                            {
                                                DataTable dtFull = new DataTable();
                                                dtFull = pComp.SelectByStockIdFull(SID);
                                                DataTable dtLoose = new DataTable();
                                                dtLoose = pComp.SelectByStockIdLoose(SID);
                                                double totalQty = 0;
                                                double formatQty = 0;
                                                string formatFull = "";
                                                for (int l = 1; l < level; l++)
                                                {
                                                    formatFull = formatFull + "X" + fr[l].ToString();
                                                }
                                                for (int i = 0; i < dtFull.Rows.Count; i++)
                                                {
                                                    totalQty = totalQty + Convert.ToDouble(dtFull.Rows[i]["RemainingQty"].ToString());
                                                    string[] arrFull = dtFull.Rows[i]["Format"].ToString().Split(new char[] { 'X' });
                                                    formatQty = formatQty + Convert.ToDouble(arrFull[0].ToString());

                                                }
                                                lblTotalFullFormat.Text = TruncateDecimal(formatQty, 3).ToString("0") + formatFull;
                                                double totalQtyLoose = 0;
                                                if (dtLoose.Rows.Count > 0)
                                                {
                                                    string[] totalLooseFormat = new string[level];

                                                    for (int i = 0; i < dtLoose.Rows.Count; i++)
                                                    {
                                                        totalQtyLoose = totalQtyLoose + Convert.ToDouble(dtLoose.Rows[i]["RemainingQty"].ToString());
                                                        string[] arrLoose = dtLoose.Rows[i]["Format"].ToString().Split(new char[] { '|' });
                                                        for (int l = 0; l < level; l++)
                                                        {
                                                            totalLooseFormat[l] = (Convert.ToDouble(totalLooseFormat[l]) + Convert.ToDouble(arrLoose[l])).ToString();
                                                        }
                                                    }
                                                    string looseFormat = TruncateDecimal(Convert.ToDouble(totalLooseFormat[0]), 1).ToString("0");
                                                    for (int l = 1; l < level; l++)
                                                    {
                                                        looseFormat = looseFormat + "|" + totalLooseFormat[l].ToString();
                                                    }

                                                    lblTotalLooseFormat.Text = looseFormat;
                                                }
                                                else
                                                {
                                                    lblTotalLooseFormat.Text = "N/A";
                                                }
                                                string[] fulQty = (lblTotalFullFormat.Text).Split('X');
                                                string[] looseQty = (lblTotalLooseFormat.Text).Split('|');
                                                if (AU == "NOS")
                                                    lblCount.Text = TruncateDecimal((((dtFull.Rows.Count + dtLoose.Rows.Count) / 2) + ((dtFull.Rows.Count + dtLoose.Rows.Count) % 2)), 3).ToString("0.00");

                                                    else
                                                lblCount.Text = TruncateDecimal((((dtFull.Rows.Count + dtLoose.Rows.Count) / 2) + ((dtFull.Rows.Count + dtLoose.Rows.Count) % 2)), 3).ToString("0.000");

                                                if (lblTotalLooseFormat.Text == "N/A")
                                                {
                                                    subQty = fqty = (Convert.ToDouble(fulQty[0]));
                                                    subQty = (Convert.ToDouble(fulQty[1]));
                                                }
                                                else
                                                {
                                                    fqty = (Convert.ToDouble(fulQty[0]) + Convert.ToDouble(looseQty[0]));
                                                    subQty = (Convert.ToDouble(fulQty[1]) + Convert.ToDouble(looseQty[1]));
                                                }
                                                lblTotalLooseFormat.Text = "Loose: " + lblTotalLooseFormat.Text;
                                                lblTotalFullFormat.Text = "Full: " + lblTotalFullFormat.Text;
                                            }
                                        }
                                    }
                                    else
                                    {


                                        //if (count > 0 && SID == int.Parse(hSID.Value))
                                        {
                                            DataTable sdt = new DataTable();
                                            StockComp cmp = new StockComp();
                                            sdt = cmp.Select(int.Parse(hSID.Value));
                                            double pmQty = 0;
                                            double subpmQty = 0;
                                            double productQty = 0;
                                            StockPakagingComp pkcmp = new StockPakagingComp();
                                            DataTable dtPK = new DataTable();
                                            dtPK = pkcmp.SelectByCRVNo(crvNo,productID);
                                            string PM = "";
                                            string SUBPM = "";
                                            foreach (DataRow cdr in dtPK.Rows)
                                            {
                                                if (int.Parse(cdr["StockId"].ToString()) == int.Parse(hSID.Value))
                                                {
                                                    PM = cdr["PM"].ToString();
                                                    SUBPM = cdr["SUBPM"].ToString();

                                                }
                                            }
                                            pmQty = 0;
                                            subpmQty = 0;
                                            foreach (DataRow cdr in dtPK.Rows)
                                            {
                                                if (PM == cdr["PM"].ToString() && SUBPM == cdr["SUBPM"].ToString())
                                                {
                                                    if (cdr["PackagingType"].ToString() == "DW")
                                                    {
                                                        productQty = productQty + double.Parse(cdr["RemainingQty"].ToString());//B
                                                        // pmQty = pmQty + double.Parse(cdr["Format"].ToString());//A
                                                        string[] full = cdr["Format"].ToString().Split('X');
                                                        if (full.Count() > 0)
                                                        {
                                                            pmQty = pmQty + double.Parse(full[0]);//A
                                                        }
                                                    }
                                                    else
                                                        if (cdr["PackagingType"].ToString() == "Full")
                                                        {
                                                            productQty = productQty + double.Parse(cdr["RemainingQty"].ToString());//B
                                                            string[] full = cdr["Format"].ToString().Split('X');
                                                            if (full.Count() > 1)
                                                            {
                                                                pmQty = pmQty + double.Parse(full[0]) * double.Parse(full[1]);//A-D
                                                                subpmQty = subpmQty + double.Parse(full[0]);//C
                                                            }

                                                        }
                                                        else
                                                        {
                                                            productQty = productQty + double.Parse(cdr["RemainingQty"].ToString());//B
                                                            string[] loose = cdr["Format"].ToString().Split('|');
                                                            if (loose.Count() > 1)
                                                            {
                                                                pmQty = pmQty + double.Parse(loose[1]);//A-D                                  
                                                                subpmQty = subpmQty + double.Parse(loose[0]);//C

                                                            }
                                                        }

                                                }
                                            }


                                            lblB.Text = "Quantity: ";
                                            //if (lblSubPacking.Text == "2")
                                            //{
                                            //    lblB.Text = lblB.Text + TruncateDecimalToString(productQty, 3);
                                            //}
                                            //else
                                          
                                            {

                                               
                                                if (Convert.ToBoolean(sdt.Rows[0]["IsSubPacking"]) == true)
                                                {

                                                    //lblB.Text = lblB.Text + TruncateDecimalToString(pmQty, 3);
                                                    if (int.Parse(hdnLevel.Value) == 2)
                                                        lblB.Text = lblB.Text + (pmQty.ToString("0"));
                                                    else if (int.Parse(hdnLevel.Value) == 1)

                                                        lblB.Text = lblB.Text + (subpmQty.ToString("0"));
               
                     
                                                }
                                                else
                                                {
                                                   

                                                    if (Convert.ToBoolean(sdt.Rows[0]["IsDW"]) == true)
                                                    {

                                                        lblB.Text = lblB.Text + (pmQty.ToString("0"));
                                                    }
                                                    else
                                                    {
                                                        lblB.Text = lblB.Text + (subpmQty.ToString("0"));
                                                    }
                                                }
                                                tottalProductQty = tottalProductQty + productQty;
//totalAmount = totalAmount + double.Parse(sdt.Rows[0]["CostOfParticular"].ToString()) * productQty;

                                            }

                                        }
                                    }

                                }
                            }
                        }


                       
                        //Binding footers
                        if (check == false)
                        {
                            GridFooterItem footer = (GridFooterItem)rgdCRV.MasterTableView.GetItems(GridItemType.Footer)[0];
                            Label lblAmt = (Label)footer.FindControl("lblAmount");
                            lblAmt.Text = lblAmt.Text + TruncateDecimal(totalAmount, 2).ToString("0.00");
                            Label lblTotalQty = (Label)footer.FindControl("lblTotalQty");
                            lblTotalQty.Text = TruncateDecimalToString(tottalProductQty, 3);

                            //foreach (GridColumn myColumn in rgdCRV.MasterTableView.RenderColumns)
                            //{



                            //    myColumn.Visible = ESL;
                            //    if (myColumn.UniqueName == "Amount")

                            //        myColumn.Visible = amountShow;


                            //}
                       
                        }
                        else
                        {
                            GridFooterItem footer1 = (GridFooterItem)rgdCRVWithouPAcking.MasterTableView.GetItems(GridItemType.Footer)[0];
                            Label lblAmt1 = (Label)footer1.FindControl("lblAmount");
                            lblAmt1.Text = lblAmt1.Text + TruncateDecimal(totalAmount, 2).ToString("0.00");
                            Label lblTotalQty = (Label)footer1.FindControl("lblTotalQty");
                            lblTotalQty.Text = TruncateDecimalToString(tottalProductQty, 3);
                            //foreach (GridColumn myColumn in rgdCRVWithouPAcking.MasterTableView.RenderColumns)
                            //{



                            //    myColumn.Visible = ESL;
                            //    if (myColumn.UniqueName == "Amount")

                            //        myColumn.Visible = amountShow;


                            //}
                        }
                        if (amountShow)
                        {
                            lblInWords.Text = "(" + ConvertNumberToWord(TruncateDecimalToString(totalAmount, 2)) + ")";
                            lblAmount.Text = "Total Amount: " + TruncateDecimal(totalAmount, 2).ToString("0.00");
                        }


                    }
                }//if ends


            }
            catch (Exception)
            {

                throw;
            }
        }
        public string TruncateDecimalToString(double value, int digit)
        {
            try
            {
                double step = (double)Math.Pow(10, digit);
                double tmp = (double)Math.Truncate(step * value);
                if(digit==2)
                    return (tmp / step).ToString("0.00");
                        else
                return (tmp / step).ToString("0.000");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public double TruncateDecimal(double value, int digit)
        {
            try
            {
                double step = (double)Math.Pow(10, digit);
                double tmp = (double)Math.Truncate(step * value);
                return (tmp / step);
            }
            catch (Exception)
            {

                throw;
            }
        }
      
        public string NumberToText(double number)
        {
            if (number == 0) return "Zero";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };
            num[0] =Convert.ToInt32( number % 1000); // units
            num[1] = Convert.ToInt32(number / 1000);
            num[2] = Convert.ToInt32(number / 100000);
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] =Convert.ToInt32( number / 10000000); // crores
            num[2] = num[2] - 100 * num[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u =Convert.ToInt32(num[i]) % 10; // ones
                t = Convert.ToInt32(num[i]) / 10;
                h = Convert.ToInt32(num[i]) / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    //if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }


            // TextBox2.Text = "Rupees " + sb.ToString().TrimEnd() + " Only";
            return sb.ToString().TrimEnd();
        }
        static String NumWordsWrapper(double n)
        {
            string words = "";
            double intPart;
            double decPart = 0;
            if (n == 0)
                return "zero";
            try
            {
                string[] splitter = n.ToString().Split('.');
                intPart = double.Parse(splitter[0]);
                decPart = double.Parse(splitter[1]);
            }
            catch
            {
                intPart = n;
            }

            words = NumWords(intPart);

            if (decPart > 0)
            {
                if (words != "")
                    words += " and ";
                int counter = decPart.ToString().Length;
                switch (counter)
                {
                    case 1: words += NumWords(decPart) + " tenths"; break;
                    case 2: words += NumWords(decPart) + " hundredths"; break;
                    case 3: words += NumWords(decPart) + " thousandths"; break;
                    case 4: words += NumWords(decPart) + " ten-thousandths"; break;
                    case 5: words += NumWords(decPart) + " hundred-thousandths"; break;
                    case 6: words += NumWords(decPart) + " lakhs"; break;
                    case 7: words += NumWords(decPart) + " ten-lakhs"; break;
                    case 8: words += NumWords(decPart) + " crores"; break;
                    case 9: words += NumWords(decPart) + " ten-crores"; break;
                }
            }
            return words;
        }

        static String NumWords(double n) //converts double to words
        {
            string[] numbersArr = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tensArr = new string[] { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };
            string[] suffixesArr = new string[] { "thousand", "lakh", "crore"};//, "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" };
            string words = "";

            bool tens = false;

            if (n < 0)
            {
                words += "negative ";
                n *= -1;
            }

            int power = (suffixesArr.Length + 1) * 3;

            while (power > 3)
            {
                double pow = Math.Pow(10, power);
                if (n >= pow)
                {
                    if (n % pow > 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1] + ", ";
                    }
                    else if (n % pow == 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1];
                    }
                    n %= pow;
                }
                power -= 3;
            }
            if (n >= 1000)
            {
                if (n % 1000 > 0) words += NumWords(Math.Floor(n / 1000)) + " thousand, ";
                else words += NumWords(Math.Floor(n / 1000)) + " thousand";
                n %= 1000;
            }
            if (0 <= n && n <= 999)
            {
                if ((int)n / 100 > 0)
                {
                    words += NumWords(Math.Floor(n / 100)) + " hundred";
                    n %= 100;
                }
                if ((int)n / 10 > 1)
                {
                    if (words != "")
                        words += " ";
                    words += tensArr[(int)n / 10 - 2];
                    tens = true;
                    n %= 10;
                }

                if (n < 20 && n > 0)
                {
                    if (words != "" && tens == false)
                        words += " ";
                    words += (tens ? "-" + numbersArr[(int)n - 1] : numbersArr[(int)n - 1]);
                    n -= Math.Floor(n);
                }
            }

            return words;

        }

        protected void rgdCRVBatch_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (e.Column is GridGroupSplitterColumn)
            {
                e.Column.Visible = false;
            } 
        }

        protected void rgdCRVBatch_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridGroupHeaderItem)
            {
                (e.Item as GridGroupHeaderItem).Cells[0].Controls.Clear();
            } 
        }

        protected void btnprints_Click(object sender, EventArgs e)
        {
            string crvNo = (Request.QueryString["cNo"].ToString());
            int productID = int.Parse(Request.QueryString["pID"].ToString());

            Response.Redirect("PrintCompactCRV.aspx?cno="+crvNo+"&pid="+productID);
        }
        
    }
}