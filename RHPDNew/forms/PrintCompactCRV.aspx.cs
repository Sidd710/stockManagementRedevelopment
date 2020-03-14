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
    public partial class PrintCompactCRV : System.Web.UI.Page
    {
        public static int sBID = 0;
        public static int sSID = 0;
        public static int sStockID = 0;
        public static string AU = "";
        public static int Case = 0;
        public static string stcokCase = "";
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
            num[0] = Convert.ToInt32(number % 1000); // units
            num[1] = Convert.ToInt32(number / 1000);
            num[2] = Convert.ToInt32(number / 100000);
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = Convert.ToInt32(number / 10000000); // crores
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
                u = Convert.ToInt32(num[i]) % 10; // ones
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
            string[] suffixesArr = new string[] { "thousand", "lakh", "crore" };//, "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" };
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
                return " Rupees " + DecimalPartWord + " only";

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
                    btnprints.Attributes.Add("onclick", "window.print();");
                    try
                    {


                        _BindData();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }


        private void _GetGrid(string crvNo, int ProductID, bool check)
        {
            try
            {
                StockComp stockComp = new StockComp();
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

                    if (dt.Rows.Count < 2)
                        dr["Remarks"] = dr["Remarks1"];
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

                
               
                  
                    _GetTable(amountShow,dtCRV);
                
                lblCountItems.Text = "(Items " + NumWordsWrapper(dtCRV.Rows.Count) + " Only)";


            }
            catch (Exception)
            {

                throw;
            }
        }
         int rowCount=0;
         int bnoCount = 0;
         string bnoString = "";
        private void _GetTable(bool amountShow,DataTable dt)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table><tr style=\"font-size:14px\">");
                sb.Append("<th> S.NO.</ th >");
                sb.Append("<th > PRODUCT </ th >");
                sb.Append("  <th > A / U </ th >");
                sb.Append("  <th > QUANTITY </ th >");

                sb.Append(" <th > PACK </ th >");
                if(amountShow)
                sb.Append(" <th > AMOUNT </ th >");
                sb.Append("  <th > REMARKS </ th ></ tr >");
                int sno = 1;
                int sid = 0;
                double pmQty = 0;
                double subpmQty = 0;
                double totalAmount = 0;
                double productAmount = 0;
                StringBuilder sbBatchNo = new StringBuilder();

                StringBuilder sbDOM = new StringBuilder();
            
                StringBuilder sbESL = new StringBuilder();
            
                StringBuilder sbEXP = new StringBuilder();
             
                StringBuilder sbCost = new StringBuilder();

                //New

                StringBuilder sbBatchNo1 = new StringBuilder();

                StringBuilder sbDOM1 = new StringBuilder();

                StringBuilder sbESL1 = new StringBuilder();

                StringBuilder sbEXP1 = new StringBuilder();

                StringBuilder sbCost1 = new StringBuilder();

                bool ESLExist = false;
                bool EXPExist = false;    
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<tr  style=\"font-size:12px\" >");
                    //SNO
                    sb.Append(" <td >"+sno.ToString()+"</ td >");
                    sno++;
                    //PRODUCT
                    sb.Append("<td >" + dr["ITEMS"].ToString());
                    sb.Append("</ td >");
                    StockPakagingComp pComp = new StockPakagingComp();
                    string lblCount = "";
                    string lblTotalLooseFormat = "";
                    string lblTotalFullFormat = "";                   
                    if (int.Parse(dr["CatID"].ToString()) == int.Parse(dr["SID"].ToString()))
                    {
                        pmQty = 0;
                        subpmQty = 0;
                        productAmount = 0;
                        sbBatchNo.Clear();

                        sbDOM.Clear();

                        sbESL.Clear();

                        sbEXP.Clear();

                        sbCost.Clear();

                        sbBatchNo.Append("<b>BATCHES</b><br/>");
                       
                        sbDOM.Append("<b>DOM</b><br />");
                       
                        sbESL.Append("<b>ESL</b><br />");
                       
                        sbEXP.Append("<b>EXPIRY</b><br />");                       
                        sbCost.Append("<b>COST</b><br />");

                        //New
                        
                                         
                         sbBatchNo1.Clear();

                        sbDOM1.Clear();
                        sbESL1.Clear();

                        sbEXP1.Clear();

                        sbCost1.Clear();

                        sbBatchNo1.Append("<tr><td style=\"text-align:left\"><b>BATCHES</b></td>");
                        sbDOM1.Append("<tr><td style=\"text-align:left\"><b>DOM</b></td>");
                        sbESL1.Append("<tr><td style=\"text-align:left\"><b>ESL</b></td>");
                        sbEXP1.Append("<tr><td style=\"text-align:left\"><b>EXPIRY</b></td>");
                        sbCost1.Append("<tr><td style=\"text-align:left\"><b>COST</b></td>");

                         rowCount = 0;
                         bnoCount = 0;
                          ESLExist = false;
                          EXPExist = false; 
                        sid = int.Parse(dr["CatID"].ToString());
                        //Batches
                        string BNO = "";
                        bool allExist = false;
                      
                        DateTime DOM = DateTime.Now;
                        DateTime EXP = DateTime.Now;
                        DateTime Esl = DateTime.Now;
                        Double Cost = 0;
                        StockBatchComp bcmp = new StockBatchComp();
                        DataTable bdt = new DataTable();
                        bdt = bcmp.SelectByStockId(sid);
                     
                      
                        foreach (DataRow bdr in bdt.Rows)
                        {
                           
                            productAmount = productAmount + double.Parse(bdr["QTY"].ToString()) * double.Parse(bdr["CostOfParticular"].ToString());
                           
                            
                            if (DOM != Convert.ToDateTime(bdr["MFGDate"].ToString()))
                            {
                               
                               
                               
                            
                                //if (BNO != bdr["BatchNo"].ToString())
                                //{
                                //    if (BNO != "")
                                //    {
                                //        sbBatchNo.Append("<br/>"); bnoString = "";
                                //    }
                                   
                                    bnoString += bdr["BatchNo"].ToString();
                                   BNO = bdr["BatchNo"].ToString();
                                   if (rowCount > 0)
                                   {
                                       sbBatchNo.Append("<br/>");
                                       sbBatchNo.Append("<hr />");
                                       sbCost.Append("<hr />");
                                       sbESL.Append("<hr />");
                                       sbEXP.Append("<hr />");
                                       sbDOM.Append("<hr />");

                                       bnoString = "";
                                   } rowCount++;
                                   DOM = Convert.ToDateTime(bdr["MFGDate"].ToString());
                                   sbDOM.Append(DOM.ToString("dd-MM-yyyy") + "<br />");
                                    sbBatchNo.Append(BNO);
                               // }
                                if (bdr["Esl"].ToString() != "")
                                {
                                    if (Esl != Convert.ToDateTime(bdr["Esl"].ToString()))
                                    {
                                         Esl = Convert.ToDateTime(bdr["Esl"].ToString());
                                        sbESL.Append(Esl.ToString("MMM-yyyy") + "<br />");
                                        ESLExist = true;
                                    }
                                    else
                                        sbESL.Append("<br/>");
                                }
                                else
                                    sbESL.Append("<br/>");
                                
                                if (bdr["EXPDate"].ToString() != "")
                                {
                                    if (EXP != Convert.ToDateTime(bdr["EXPDate"].ToString()))
                                    {
                                       EXP = Convert.ToDateTime(bdr["EXPDate"].ToString());
                                        sbEXP.Append(EXP.ToString("dd-MM-yyyy") + "<br />");
                                        EXPExist = true;
                                    }
                                    else
                                        sbEXP.Append("<br/>");
                                }
                                else
                                    sbEXP.Append("<br/>");
                                
                                if (Cost != double.Parse(bdr["CostOfParticular"].ToString()))
                                {
                                    
                                    Cost = double.Parse(bdr["CostOfParticular"].ToString());
                                    sbCost.Append(Cost.ToString("0.00") + "<br />");
                                    
                                }
                                else
                                    sbCost.Append("<br/>");
                            }
                            else 
                                {
                                    
                                   
                                    allExist = false;


                                    if (bdr["Esl"].ToString() != "")
                                    {
                                        if (Esl != Convert.ToDateTime(bdr["Esl"].ToString()))
                                        {
                                            allExist = true;
                                            ESLExist = true;
                                        }
                                    }
                                if (bdr["EXPDate"].ToString() != "")
                                {
                                    if (EXP != Convert.ToDateTime(bdr["EXPDate"].ToString()))
                                        allExist = true;
                                    EXPExist = true;
                                }
                                if (Cost != double.Parse(bdr["CostOfParticular"].ToString()))
                                {             
                                   
                                    if (amountShow)
                                    allExist = true;
                                }
                                
                                if (allExist == true)
                                {
                                    rowCount++;
                                    sbDOM.Append("<br/>");
                                   
                                    BNO = bdr["BatchNo"].ToString();
                                    sbBatchNo.Append("<br/>"+BNO);
                                    bnoString = "";
                                    if (bdr["Esl"].ToString() != "")
                                    {
                                        if (Esl != Convert.ToDateTime(bdr["Esl"].ToString()))
                                        {

                                            Esl = Convert.ToDateTime(bdr["Esl"].ToString());
                                            sbESL.Append(Esl.ToString("MMM-yyyy") + "<br />");
                                           

                                        }
                                        else
                                        {

                                            sbESL.Append("<br/>");
                                        }
                                    }
                                    else
                                    {

                                        sbESL.Append("<br/>");
                                    }
                                    if (bdr["EXPDate"].ToString() != "")
                                    {
                                        if (EXP != Convert.ToDateTime(bdr["EXPDate"].ToString()))
                                        {

                                            EXP = Convert.ToDateTime(bdr["EXPDate"].ToString());
                                            sbEXP.Append(EXP.ToString("dd-MM-yyyy") + "<br />");
                                           
                                        }
                                        else
                                        {
                                            sbEXP.Append("<br/>");
                                        }
                                    }
                                    else
                                    {
                                        sbEXP.Append("<br/>");
                                    }
                                    if (Cost != double.Parse(bdr["CostOfParticular"].ToString()))
                                    {

                                        Cost = double.Parse(bdr["CostOfParticular"].ToString());
                                        sbCost.Append(Cost.ToString("0.00") + "<br />");
                                        
                                    }
                                    else
                                    {
                                        sbCost.Append("<br/>");
                                    }
                                }
                                else
                                {
                                    BNO = bdr["BatchNo"].ToString();
                                    bnoString += bdr["BatchNo"].ToString();
                                    bnoCount = bnoString.Length;
                                    if (bnoCount > 100)
                                    {
                                        sbBatchNo.Append(", ");
                                   
                                        sbBatchNo.Append("<br />");
                                        sbCost.Append("<br />");
                                        sbESL.Append("<br />");
                                        sbEXP.Append("<br />");
                                        sbDOM.Append("<br />");
                                        sbBatchNo.Append(BNO);
                                   
                                        rowCount++;

                                    }
                                    else
                                        sbBatchNo.Append(", " + BNO);
                                   
                                  
                                   
                                }
                               
                            }

                        }

                         BNO = "";
                         allExist = false;

                         DOM = DateTime.Now;
                         EXP = DateTime.Now;
                         Esl = DateTime.Now;
                         Cost = 0;
                         int colSpanBNo = 0;
                         int colSpanDOM = 0;
                         int colSpanEsl = 0;
                         int colSpanEXp = 0;
                         int colSpanCost = 0;
                        foreach (DataRow bdr in bdt.Rows)
                        {                     

                           // New

                            if (DOM != Convert.ToDateTime(bdr["MFGDate"].ToString()))
                            {

                                DOM = Convert.ToDateTime(bdr["MFGDate"].ToString());
                                sbDOM1.Append("<td colspan=" + colSpanDOM + ">" + DOM.ToString("dd-MM-yyyy") + "</td>");
                                if (BNO != bdr["BatchNo"].ToString())
                                {
                                    if (BNO != "")
                                        colSpanBNo++;
                                       // sbBatchNo1.Append("</td><td></td>");
                                   
                                    BNO = bdr["BatchNo"].ToString();
                                    sbBatchNo1.Append("<td colspan="+colSpanBNo+">"+BNO);
                                }
                                if (bdr["Esl"].ToString() != "")
                                {
                                    if (Esl != Convert.ToDateTime(bdr["Esl"].ToString()))
                                    {
                                        Esl = Convert.ToDateTime(bdr["Esl"].ToString());
                                        sbESL1.Append("<td colspan=" + colSpanEsl + ">" + Esl.ToString("MMM-yyyy") + "</td>");
                                    }
                                    else
                                        colSpanEsl++;// sbESL1.Append("<td></td>");
                                }
                                else
                                    colSpanEsl++;// sbESL1.Append("<td></td>");

                                if (bdr["EXPDate"].ToString() != "")
                                {
                                    if (EXP != Convert.ToDateTime(bdr["EXPDate"].ToString()))
                                    {
                                        EXP = Convert.ToDateTime(bdr["EXPDate"].ToString());
                                        sbEXP1.Append("<td colspan=" + colSpanEXp + ">" + EXP.ToString("dd-MM-yyyy") + "</td>");

                                    }
                                    else
                                        colSpanEXp++;// sbEXP1.Append("<td></td>");
                                }
                                else
                                    colSpanEXp++;// sbEXP1.Append("<td></td>");

                                if (Cost != double.Parse(bdr["CostOfParticular"].ToString()))
                                {

                                    Cost = double.Parse(bdr["CostOfParticular"].ToString());
                                    sbCost1.Append("<td colspan=" + colSpanCost + ">" + Cost.ToString("0.00") + "</td>");


                                }
                                else
                                    colSpanCost++;
                                   // sbCost1.Append("<td></td>");
                            }
                            else
                            {
                                allExist = false;


                                if (bdr["Esl"].ToString() != "")
                                {
                                    if (Esl != Convert.ToDateTime(bdr["Esl"].ToString()))
                                    {
                                        allExist = true;

                                    }
                                }
                                if (bdr["EXPDate"].ToString() != "")
                                {
                                    if (EXP != Convert.ToDateTime(bdr["EXPDate"].ToString()))
                                        allExist = true;
                                }
                                if (Cost != double.Parse(bdr["CostOfParticular"].ToString()))
                                {

                                    if (amountShow)
                                        allExist = true;
                                }

                                if (allExist == true)
                                {
                                    colSpanDOM++;
                                   // sbDOM1.Append("<td></td>");

                                    BNO = bdr["BatchNo"].ToString();
                                    colSpanBNo = 0;
                                    sbBatchNo1.Append("</td><td colspan="+colSpanBNo+">" + BNO);
                                    if (bdr["Esl"].ToString() != "")
                                    {
                                        if (Esl != Convert.ToDateTime(bdr["Esl"].ToString()))
                                        {

                                            Esl = Convert.ToDateTime(bdr["Esl"].ToString());
                                            colSpanEsl = 0;
                                            sbESL1.Append("<td colspan=" + colSpanEsl + ">" + Esl.ToString("MMM-yyyy") + "</td>");                                       
                               

                                        }
                                        else
                                        {

                                            colSpanEsl++;// sbESL1.Append("<td></td>");
                                        }
                                    }
                                    else
                                    {

                                        colSpanEsl++;// sbESL1.Append("<td></td>");
                                    }
                                    if (bdr["EXPDate"].ToString() != "")
                                    {
                                        if (EXP != Convert.ToDateTime(bdr["EXPDate"].ToString()))
                                        {

                                            EXP = Convert.ToDateTime(bdr["EXPDate"].ToString());
                                            colSpanEXp = 0;
                                            sbEXP1.Append("<td colspan=" + colSpanEXp + ">" + EXP.ToString("dd-MM-yyyy") + "</td>");

                                        }
                                        else
                                            colSpanEXp++;// sbEXP1.Append("<td></td>");             
                                        
                                    }
                                    else
                                    {
                                        colSpanEXp++;// sbEXP1.Append("<td></td>");             
                                        
                                    }
                                    if (Cost != double.Parse(bdr["CostOfParticular"].ToString()))
                                    {

                                        Cost = double.Parse(bdr["CostOfParticular"].ToString());
                                        colSpanCost = 0;
                                        sbCost1.Append("<td colspan=" + colSpanCost + ">" + Cost.ToString("0.00") + "</td>");


                                    }
                                    else
                                        colSpanCost++;// sbCost1.Append("<td></td>");
                                }
                                else
                                {
                                    BNO = bdr["BatchNo"].ToString();
                                    sbBatchNo1.Append(", " + BNO);
                                }

                            }
                        }
                        sbBatchNo1.Append("</tr>");
                        sbDOM1.Append("</tr>");
                        sbESL1.Append("</tr>");
                        sbEXP1.Append("</tr>");
                        sbCost1.Append("</tr>");
                        if(!ESLExist)
                        sbESL1.Clear();
                        if(!EXPExist)
                        sbEXP1.Clear();

                        //Packaging
                        int level = int.Parse(dr["PackagingMaterialFormatLevel"].ToString());
                        string[] fr = dr["PackingMaterialFormat"].ToString().Split('X');
                       
                        if (Convert.ToBoolean(dr["IsDW"].ToString()) == true)
                        {
                            DataTable dtDW = new DataTable();
                            dtDW = pComp.SelectDWByStockId(sid);
                            double tottalPack = 0;
                            foreach (DataRow dr1 in dtDW.Rows)
                            {
                                string[] full = dr1["Format"].ToString().Split('X');
                                if (full.Count() > 0)
                                { tottalPack = tottalPack + Convert.ToDouble(full[0]);
                                   pmQty = pmQty + double.Parse(full[0]);//A
                                    
                                }
                               
                            }
                            lblTotalFullFormat = tottalPack.ToString("0") + " X DW";

                        }
                        else
                        {
                            DataTable dtFull = new DataTable();
                            dtFull = pComp.SelectByStockIdFull(sid);
                            DataTable dtLoose = new DataTable();
                            dtLoose = pComp.SelectByStockIdLoose(sid);
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
                                if (arrFull.Count() > 1)
                                {
                                    pmQty = pmQty + double.Parse(arrFull[0]) * double.Parse(arrFull[1]);//A-D
                                    subpmQty = subpmQty + double.Parse(arrFull[0]);//C
                                }
                            }
                            if (formatQty == 0)
                                lblTotalFullFormat = "N/A";
                            else
                            lblTotalFullFormat = TruncateDecimal(formatQty, 3).ToString("0") + formatFull;
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
                                    if (arrLoose.Count() > 1)
                                    {
                                        pmQty = pmQty + double.Parse(arrLoose[1]);//A-D                                  
                                        subpmQty = subpmQty + double.Parse(arrLoose[0]);//C

                                    }
                                }
                                string looseFormat = TruncateDecimal(Convert.ToDouble(totalLooseFormat[0]), 1).ToString("0");
                                for (int l = 1; l < level; l++)
                                {
                                    looseFormat = looseFormat + "|" + totalLooseFormat[l].ToString();
                                }

                                lblTotalLooseFormat = looseFormat;
                            }
                            else
                            {
                                lblTotalLooseFormat = "N/A";
                            }
                            string[] fulQty = (lblTotalFullFormat).Split('X');
                            string[] looseQty = (lblTotalLooseFormat).Split('|');
                            if (AU == "NOS")
                                lblCount = TruncateDecimal((((dtFull.Rows.Count + dtLoose.Rows.Count) / 2) + ((dtFull.Rows.Count + dtLoose.Rows.Count) % 2)), 3).ToString("0.00");

                            else
                            lblCount = TruncateDecimal((((dtFull.Rows.Count + dtLoose.Rows.Count) / 2) + ((dtFull.Rows.Count + dtLoose.Rows.Count) % 2)), 3).ToString("0.000");


                            lblTotalLooseFormat = "Loose: " + lblTotalLooseFormat;
                            if (lblTotalFullFormat == "0")
                                lblTotalFullFormat = "N/A";
                            lblTotalFullFormat = "Full: " + lblTotalFullFormat;
                        }
                    }
                   
                    //A/U
                    sb.Append("  <td >" + dr["AU"].ToString() + "</ td >");
                    //Qty
                    sb.Append("  <td >");
                    if (int.Parse(dr["CatID"].ToString()) == int.Parse(dr["SID"].ToString()))
                    {
                        sb.Append(Convert.ToDouble(dr["Quantity"].ToString()).ToString("0"));
                    }
                    else if (Convert.ToBoolean(dr["IsSubPacking"]) == true)
                    {                     
                        if (int.Parse(dr["SupplierId"].ToString()) == 2)
                            sb.Append(pmQty.ToString("0"));
                        else if (int.Parse(dr["SupplierId"].ToString()) == 1)

                            sb.Append(subpmQty.ToString("0"));
                    }
                    else
                    {
                        if (Convert.ToBoolean(dr["IsDW"]) == true)
                        {

                            sb.Append(pmQty.ToString("0"));
                        }
                        else
                        {
                            if (subpmQty <= 0 && pmQty >= 0) //changes starts here - Shivani
                            {
                                sb.Append(pmQty.ToString("0"));
                            }
                            else
                            {
                                if (dr["SupplierId"].ToString() == "2")
                                {
                                    sb.Append(pmQty.ToString("0"));
                                }
                                else
                                {
                                    sb.Append(subpmQty.ToString("0"));
                                }
                            } //Changed End here
                        }
                    }

                    sb.Append("</ td >");
                    //PAck
                    sb.Append("  <td >");
                    if (Convert.ToBoolean(dr["IsDW"].ToString()) == true)
                    {
                        //DW
                        sb.Append("<br />"+ lblTotalFullFormat);
                        
                        
                     }
                    else
                    {
                        //FULL Loose                      
                        sb.Append("<br />" + lblTotalFullFormat);
                        sb.Append("<br />" + lblTotalLooseFormat);

                    }

                   sb.Append("</ td >");
                    //Amt
                    if (amountShow)
                    {
                        sb.Append(" <td >");
                        if (int.Parse(dr["CatID"].ToString()) == int.Parse(dr["SID"].ToString()))
                        { sb.Append(productAmount.ToString("0.00"));
                            totalAmount = totalAmount + productAmount;
                        }
                       sb.Append( "</ td >");
                    }
                    //Remrks
                    sb.Append(" <td >" + dr["Remarks"].ToString() + "</ td >");
                    sb.Append("   </ tr > ");

                    if (int.Parse(dr["CatID"].ToString()) == int.Parse(dr["SID"].ToString()))
                    {
                        int count = 4;
                        if (amountShow)
                            count= 5;
                        if (rowCount <= count )
                           
                        {
                            sb.Append("<tr  style=\"font-size:12px\">");
                            //SNO
                            sb.Append(" <td ></ td >");

                            //PRODUCT

                            sb.Append("<td >" + sbBatchNo.ToString() + "</ td >");

                            //A/U
                            sb.Append("  <td >" + sbDOM.ToString() + "</ td >");
                            //Qty
                           if(ESLExist)
                            sb.Append("  <td >" + sbESL.ToString() + "</ td >");
                            //PAck
                            if(EXPExist)
                            sb.Append("  <td >" + sbEXP.ToString() + "</ td >");
                            //Amt
                            //if (amountShow)//changes starts here-shivani
                            //{
                                sb.Append(" <td >" + sbCost.ToString() + "</ td >");
                            //}//changes ends here
                            //Remrks
                            sb.Append(" <td ></ td >");
                            sb.Append("   </ tr > ");
                        }
                        else
                        {

                            //New

                            sb.Append("<tr  style=\"font-size:12px\">");
                            //SNO
                            sb.Append(" <td ></ td >");
                            ////PRODUCT
                            if (amountShow)
                            {
                                sb.Append("<td colspan=\"5\"> <table>" + sbBatchNo1.ToString() + sbDOM1.ToString());
                                if (ESLExist)
                                    sb.Append(sbESL1.ToString());
                                if (EXPExist)
                                    sb.Append(sbEXP1.ToString());
                                sb.Append(sbCost1.ToString() + " </table></ td >");

                            }
                            else
                            {
                               // sb.Append("<td colspan=\"4\"> <table>" + sbBatchNo1.ToString() + sbDOM1.ToString() + sbESL1.ToString() + sbEXP1.ToString() + " </table></ td >");
                                sb.Append("<td colspan=\"5\"> <table>" + sbBatchNo1.ToString() + sbDOM1.ToString());
                                if (ESLExist)
                                    sb.Append(sbESL1.ToString());
                                if (EXPExist)
                                    sb.Append(sbEXP1.ToString());
                                sb.Append(" </table></ td >");
                            }
                            //Remrks
                            sb.Append(" <td ></ td >");
                            sb.Append("   </ tr > ");
                        }
                    }
                }
                sb.Append("   </table > ");
                ltrTable.Text = sb.ToString();
                if (amountShow)
                {
                    lblInWords.Text = "(" + ConvertNumberToWord(TruncateDecimalToString(totalAmount, 2)) + ")";
                    lblAmount.Text = "Total Amount: " + TruncateDecimal(totalAmount, 2).ToString("0.00");
                }
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
                    dtCRV = stockComp.SelectByCRVNo(crvNo, productID);
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
                        if (dt.Rows[0]["RecievedFrom"].ToString() == "Local purchase")
                        {
                            lblATSO.InnerText = "SO No:";

                        }
                        else
                        {

                            lblATSO.InnerText = "AT No:";

                        }

                        //  rgdCRVList.DataSource = dtCRV;
                        //  rgdCRVList.DataBind();
                        string cat = "";
                        double inWords = 0;
                        string AtSoNo = ""; Boolean AT = false;
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
                                    AtSoNo = AtSoNo + "," + dtCRV.Rows[i]["ATNO"].ToString();
                                }
                                if (dtCRV.Rows[i]["SupplierNo"].ToString() != "")
                                {
                                    AtSoNo = AtSoNo + "," + dtCRV.Rows[i]["SupplierNo"].ToString();
                                }
                            }
                            else
                            {
                                if (dtCRV.Rows[i]["ATNO"].ToString() != "")
                                {
                                    AtSoNo = AtSoNo + dtCRV.Rows[i]["ATNO"].ToString();
                                }
                                if (dtCRV.Rows[i]["SupplierNo"].ToString() != "")
                                {
                                    AtSoNo = AtSoNo + dtCRV.Rows[i]["SupplierNo"].ToString();
                                }
                            }
                        }
                        if (AT == true && SO == true)
                            lblATSO.InnerText = "AT/SO No:";
                        else
                            if (AT == true)
                                lblATSO.InnerText = "AT No:";
                            else if (SO == true)
                                lblATSO.InnerText = "SO No:";
                        string[] AtSoNoList = AtSoNo.Split(',');

                        AtSoNoList = AtSoNoList.Distinct().ToArray();
                        for (int l = 0; l < AtSoNoList.Count(); l++)
                        {

                            //lblATNo.Text = lblATNo.Text + AtSoNoList[l] + "/";
                            if (AtSoNoList.Count() - 1 == l)
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
                      //  lblCRVdt.Text = lblCRVdt.Text + Convert.ToDateTime(dtCRV.Rows[0]["RecievedOn"].ToString()).ToString("dd-MM-yyyy");
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
                            VNo = VNo + CNO + "]";
                            if (i == dtVehicle.Rows.Count - 1)
                                lblVechicleNo.Text = lblVechicleNo.Text + VNo;
                            else
                                lblVechicleNo.Text = lblVechicleNo.Text + VNo + ", ";
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
                if (digit == 2)
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

            Response.Redirect("PrintCRV.aspx?cno=" + crvNo + "&pid=" + productID);
        }

    }
}