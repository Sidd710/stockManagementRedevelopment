using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using Telerik.Web.UI;

namespace RHPDNew.StockOutPanel
{
    public partial class IssueVoucherPrintScreen : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        double TotalQuantity = 0.00;
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

                    try
                    {
                        bindgrid();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public void bindgrid()
        {
            if (Request.QueryString["ivNo"].ToString() != "")
            {
                int id = Convert.ToInt32(Request.QueryString["ivNo"].ToString());

                SqlCommand cmd = new SqlCommand("usp_GetIssueVoucherToPrint", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                if (con.State.ToString() == "Closed")
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    lblAuthority.Text = dt.Rows[0]["Authority"].ToString();
                    lblTo.Text = dt.Rows[0]["UnitNo"].ToString();
                    lblThrough.Text = dt.Rows[0]["through"].ToString();
                    lblIssueVoucherNo.Text = dt.Rows[0]["IssueVoucherId"].ToString();
                    _GetSummary(dt);
                    _GetVehicle(id);
                }
            }
        }

        public DataTable getBatch(string ivNo, int productId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("usp_getIssuVoucherBatches", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ivNo", ivNo);
            cmd.Parameters.AddWithValue("@productId", productId);
            if (con.State.ToString() == "Closed")
                con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();

            #region "Shivani Changes"
            ////Changes starts here-Shivani

            //DataTable newdt = new DataTable();
            //if (dt.Rows.Count > 0)
            //{
            //    newdt.Columns.Add("BID");
            //    newdt.Columns.Add("BatchNo");
            //    newdt.Columns.Add("stockquantity");
            //    newdt.Columns.Add("FormatFull");
            //    newdt.Columns.Add("FormatLoose");
            //    newdt.Columns.Add("DOM");
            //    newdt.Columns.Add("ESL");
            //    newdt.Columns.Add("ExpiryDate");
            //    newdt.Columns.Add("vCost");
            //    newdt.Columns.Add("VechileNumber");
            //    newdt.Columns.Add("LicenseNo");
            //    DataRow dr = newdt.NewRow();
            //    dr["BatchNo"] = dt.Rows[0]["BatchNo"];
            //    dr["DOM"] = dt.Rows[0]["DOM"];
            //    dr["BID"] = dt.Rows[0]["BID"];
            //    dr["ESL"] = dt.Rows[0]["ESL"];
            //    dr["ExpiryDate"] = dt.Rows[0]["ExpiryDate"];

            //    double Qty = 0;
            //    double formatFull = 0.00;
            //    double formatLoose = 0.00;
            //    double cost = 0.00;
            //    string vehicle = string.Empty;
            //    string extension = string.Empty;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        Qty = Qty + Convert.ToDouble(dt.Rows[i]["stockquantity"]);
            //        cost = cost + Convert.ToDouble(dt.Rows[i]["vCost"]);
            //        string[] arrFormatFull = (string.IsNullOrEmpty(dt.Rows[i]["FormatFull"].ToString()) ? new string[0] : dt.Rows[i]["FormatFull"].ToString().Split('X'));
            //        string[] arrFormatLoose = (string.IsNullOrEmpty(dt.Rows[i]["FormatLoose"].ToString())?new string[0]: dt.Rows[i]["FormatLoose"].ToString().Split('X')) ;
            //        if(arrFormatFull.Length>1)
            //        {
            //            extension = "X" + arrFormatFull[1];
            //        }
            //        if (arrFormatFull.Length > 2)
            //        {
            //            extension = extension+ "X" + arrFormatFull[2];
            //        }
            //        formatFull = formatFull + (arrFormatFull.Length>0 ?Convert.ToDouble(arrFormatFull[0]):0);
            //        formatLoose = formatLoose + (arrFormatLoose.Length > 0 ? Convert.ToDouble(arrFormatLoose[0]) : 0);
            //        vehicle = vehicle + dt.Rows[i]["VechileNumber"] + ", ";// + (string.IsNullOrEmpty(dt.Rows[i]["LicenseNo"].ToString()) ? string.Empty : "[" + dt.Rows[i]["LicenseNo"].ToString() + "]") 
            //    }
            //    dr["stockquantity"] = Qty;
            //    if (formatFull > 0)
            //    {
            //        dr["FormatFull"] = formatFull + extension;
            //    }
            //    if (formatLoose > 0)
            //    {
            //        dr["FormatLoose"] = formatLoose;
            //    }
            //    TotalQuantity = formatFull + formatLoose;
            //    dr["vCost"] = cost;
            //    dr["VechileNumber"] = vehicle;
            //    newdt.Rows.Add(dr);
            //}
            ////Changes ends here
            #endregion
            return dt;
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


        private void _GetVehicle(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[usp_GetIssueVoucherVehicle]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                if (con.State.ToString() == "Closed")
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    //if (lblVehicleNo.Text == "")
                    //    lblVehicleNo.Text = dr["VehicleNo"].ToString() + "[" + dr["DriverName"].ToString() + "]";
                    //else
                    //    lblVehicleNo.Text = lblVehicleNo.Text + ", " + dr["VehicleNo"].ToString() + "[" + dr["DriverName"].ToString() + "]";
                    if (lblVehicleNo.Text == "")
                        lblVehicleNo.Text = dr["VehicleNo"].ToString();// Changes made by Shivani + "[" + dr["LicenseNo"].ToString() + "]";
                    else
                        lblVehicleNo.Text = lblVehicleNo.Text + ", " + dr["VehicleNo"].ToString(); //Changes made by Shivani + "[" + dr["LicenseNo"].ToString() + "]";

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void _GetSummary(DataTable dt)
        {
            try
            {
                DataTable dtFull = new DataTable();
                DataTable dtPM = new DataTable();
                DataTable dtSUBPM = new DataTable();
                dtFull = dt.Clone();
                dtPM = dt.Clone();
                dtSUBPM = dt.Clone();
                string PM = "";
                string SUBPM = "";
                string ATSO = "";
                string IDTICT = "";
                string IV = "";
                string Dom = "";
                string Esl = "";
                string ExpiryDate = "";
                double pmQty = 0;
                double subPMQty = 0;
                string sidMin = "";
                List<int> lstPID = new List<int>();
                foreach (DataRow dr in dt.Rows)
                {
                    int sid = int.Parse(dr["SID"].ToString());
                    sidMin = "-" + (sid + (10 * 10)).ToString();
                    rhpdEntities db = new rhpdEntities();
                    var lstSID = db.StockMasters.Where(s => s.SID == sid).FirstOrDefault();
                    if (lstSID != null)
                    {
                        int pid = Convert.ToInt32(lstSID.ProductId);
                        if (lstSID.IsEmptyPM == true || lstSID.IsWithoutPacking == true || lstSID.IsDW == true)
                        {

                            var exi = lstPID.Where(x => x == pid).FirstOrDefault();
                            if (exi == 0)
                            {
                                dtFull.ImportRow(dr);
                                lstPID.Add(pid);
                            }
                        }
                        else
                        {


                            var exi = lstPID.Where(x => x == pid).FirstOrDefault();
                            if (exi == 0)
                            {
                                dtFull.ImportRow(dr);
                                lstPID.Add(pid);
                            }
                            if (PM != lstSID.PackingMaterial)
                            {

                                if (pmQty > 0)
                                {

                                    dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, Dom, Esl, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");


                                }
                                PM = lstSID.PackingMaterial;

                                pmQty = 0;

                                string[] full = dr["FormatFull"].ToString().Split('X');
                                string[] loose = dr["FormatLoose"].ToString().Split('|');
                                if (full.Count() > 0 && full[0].ToString() != "")
                                    pmQty = pmQty + double.Parse(full[0]);
                                if (loose.Count() > 0 && loose[0].ToString() != "")
                                    pmQty = pmQty + double.Parse(loose[0]);
                                ATSO = dr["ATSONo"].ToString();
                                IDTICT = dr["IDTICTAWS"].ToString();
                                IV = dr["IssueVoucherId"].ToString();
                                Dom = dr["DOM"].ToString();
                                Esl = dr["ESL"].ToString();
                                ExpiryDate = dr["ExpiryDate"].ToString();


                            }
                            else
                            {

                                string[] full = dr["FormatFull"].ToString().Split('X');
                                string[] loose = dr["FormatLoose"].ToString().Split('|');
                                if (full.Count() > 0 && full[0].ToString() != "")
                                    pmQty = pmQty + double.Parse(full[0]);
                                if (loose.Count() > 0 && loose[0].ToString() != "")
                                    pmQty = pmQty + double.Parse(loose[0]);
                                ATSO = dr["ATSONo"].ToString();
                                IDTICT = dr["IDTICTAWS"].ToString();
                                IV = dr["IssueVoucherId"].ToString();
                                Dom = dr["DOM"].ToString();
                                Esl = dr["ESL"].ToString();
                                ExpiryDate = dr["ExpiryDate"].ToString();

                            }


                            if (lstSID.IsSubPacking == true)
                            {
                                if (SUBPM != lstSID.SubPMName)
                                {

                                    if (subPMQty > 0)
                                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, "Nos", Dom, Esl, ExpiryDate, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

                                    SUBPM = lstSID.SubPMName;
                                    subPMQty = 0;

                                    string[] full = dr["FormatFull"].ToString().Split('X');
                                    string[] loose = dr["FormatLoose"].ToString().Split('|');
                                    if (full.Count() > 1 && full[1].ToString() != "")
                                        subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
                                    if (loose.Count() > 1 && loose[1].ToString() != "")
                                        subPMQty = subPMQty + double.Parse(loose[1]);
                                }
                                else
                                {
                                    string[] full = dr["FormatFull"].ToString().Split('X');
                                    string[] loose = dr["FormatLoose"].ToString().Split('|');
                                    if (full.Count() > 1 && full[1].ToString() != "")
                                        subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
                                    if (loose.Count() > 1 && loose[1].ToString() != "")
                                        subPMQty = subPMQty + double.Parse(loose[1]) + double.Parse(loose[0]);

                                }
                            }
                        }

                    }

                }
                if (pmQty > 0)
                {

                    if (pmQty > 0)
                    {


                        dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", Dom, Esl, ExpiryDate, 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");


                    }
                    PM = "";

                    pmQty = 0;
                }
                if (subPMQty > 0)
                {
                    sidMin = (1 + (int.Parse(sidMin))).ToString();
                    if (subPMQty > 0)
                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, "Nos", "", Dom, Esl, ExpiryDate, 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

                    SUBPM = "";
                    subPMQty = 0;
                }
                dtFull.Merge(dtPM);
                dtFull.Merge(dtSUBPM);
                lblItemCount.Text = "(Items " + dtFull.Rows.Count + " only)";
                rgdSummary.DataSource = dtFull;
                rgdSummary.DataBind();
                double FullQty = 0, LooseQty = 0;
                string FullQtyFormat = string.Empty, LooseQtyFormat = string.Empty;
                foreach (GridDataItem rgdCRVItem in rgdSummary.MasterTableView.Items)
                {
                    Label lblB = (Label)rgdCRVItem.FindControl("lblB");
                    Label lblTotalQty = (Label)rgdCRVItem.FindControl("lblTotalQty");
                    RadGrid rgdCRVBatch = (RadGrid)rgdCRVItem.FindControl("rgdCRVBatch");

                    HiddenField hPID = (HiddenField)rgdCRVItem.FindControl("hdnPID");
                    HiddenField hSID = (HiddenField)rgdCRVItem.FindControl("hdnSID");
                    if (int.Parse(hSID.Value) > 0)
                    {
                        DataTable dtbatch = new DataTable();

                        DataTable newdt = new DataTable();
                        dtbatch = getBatch(lblIssueVoucherNo.Text, int.Parse(hPID.Value));
                        newdt.Columns.Add("BID");
                        newdt.Columns.Add("BatchNo");
                        newdt.Columns.Add("stockquantity");
                        newdt.Columns.Add("FormatFull");
                        newdt.Columns.Add("FormatLoose");
                        newdt.Columns.Add("DOM");
                        newdt.Columns.Add("ESL");
                        newdt.Columns.Add("ExpiryDate");
                        newdt.Columns.Add("vCost");
                        newdt.Columns.Add("VechileNumber");
                        newdt.Columns.Add("LicenseNo");
                        //changes starts here
                        for (int i = 0; i < dtbatch.Rows.Count; i++)
                        {
                            double stockQuantity = 0, stockCost = 0;
                            DataRow dr = newdt.NewRow();
                            string batchid = dtbatch.Rows[i]["BID"].ToString();
                            dr["BID"] = dtbatch.Rows[i]["BID"];
                            dr["BatchNo"] = dtbatch.Rows[i]["BatchNo"];
                            dr["DOM"] = dtbatch.Rows[i]["DOM"];
                            dr["ESL"] = dtbatch.Rows[i]["ESL"];
                            dr["ExpiryDate"] = dtbatch.Rows[i]["ExpiryDate"];
                            dr["VechileNumber"] = dtbatch.Rows[i]["VechileNumber"];
                            dr["LicenseNo"] = dtbatch.Rows[i]["LicenseNo"];
                            stockQuantity = Convert.ToDouble(dtbatch.Rows[i]["stockquantity"]);
                            stockCost = Convert.ToDouble(dtbatch.Rows[i]["vCost"]);

                            string formatExtensionFull = string.Empty;
                            string formatExtensionLoose = string.Empty;
                            string[] arrFormatFull = (string.IsNullOrEmpty(dtbatch.Rows[i]["FormatFull"].ToString()) ? new string[0] : dtbatch.Rows[i]["FormatFull"].ToString().Split('X'));
                            string[] arrFormatLoose = (string.IsNullOrEmpty(dtbatch.Rows[i]["FormatLoose"].ToString()) ? new string[0] : dtbatch.Rows[i]["FormatLoose"].ToString().Split('|'));
                            if (arrFormatFull.Length > 1)
                            {
                                formatExtensionFull = "X" + arrFormatFull[1];
                                FullQtyFormat = formatExtensionFull;
                            }
                            if (arrFormatFull.Length > 2)
                            {
                                formatExtensionFull = formatExtensionFull + "X" + arrFormatFull[2];
                                FullQtyFormat = formatExtensionFull;
                            }
                            if (arrFormatLoose.Length > 1)
                            {
                                formatExtensionLoose = "|" + arrFormatLoose[1];
                                LooseQtyFormat = formatExtensionLoose;
                            }
                            if (arrFormatFull.Length > 2)
                            {
                                formatExtensionLoose = formatExtensionLoose + "|" + arrFormatLoose[2];
                                LooseQtyFormat = formatExtensionLoose;
                            }

                            double FormatFullValue = 0, FormatLooseValue = 0;
                            FormatFullValue = (arrFormatFull.Length > 0 ? Convert.ToDouble(arrFormatFull[0]) : 0);
                            FormatLooseValue = (arrFormatLoose.Length > 0 ? Convert.ToDouble(arrFormatLoose[0]) : 0);

                            for (int j = i + 1; j < dtbatch.Rows.Count; j++)
                            {
                               
                                    if (string.Equals(batchid, dtbatch.Rows[j]["BID"].ToString()))
                                    {
                                        string[] arrmoreFormatFull = (string.IsNullOrEmpty(dtbatch.Rows[j]["FormatFull"].ToString()) ? new string[0] : dtbatch.Rows[j]["FormatFull"].ToString().Split('X'));
                                        string[] arrmoreFormatLosse = (string.IsNullOrEmpty(dtbatch.Rows[j]["FormatLoose"].ToString()) ? new string[0] : dtbatch.Rows[j]["FormatLoose"].ToString().Split('|'));
                                        FormatFullValue = FormatFullValue + (arrmoreFormatFull.Length > 0 ? Convert.ToDouble(arrmoreFormatFull[0]) : 0);
                                        FormatLooseValue = FormatLooseValue + (arrmoreFormatLosse.Length > 0 ? Convert.ToDouble(arrmoreFormatLosse[0]) : 0);
                                        stockQuantity = stockQuantity + Convert.ToDouble(dtbatch.Rows[j]["stockquantity"]);
                                        stockCost = stockCost + Convert.ToDouble(dtbatch.Rows[j]["vCost"]);
                                    }
                            }
                            dr["FormatFull"] = (FormatFullValue == 0 ? null : FormatFullValue + formatExtensionFull);
                            dr["FormatLoose"] = (FormatLooseValue==0? null : FormatLooseValue + formatExtensionLoose);
                            dr["stockquantity"] = stockQuantity;
                            dr["vCost"] = stockCost;
                            bool isAlreadyExists = false;
                            for (int k = 0; k < newdt.Rows.Count; k++)
                            {
                                if (string.Equals(batchid, newdt.Rows[k]["BID"].ToString()))
                                {
                                    isAlreadyExists = true;
                                }
                            }
                            if (!isAlreadyExists)
                            {
                                FullQty = FullQty + FormatFullValue;
                                LooseQty = LooseQty + FormatLooseValue;
                                newdt.Rows.Add(dr);
                            }
                        }
                        //Changes ends here
                        rgdCRVBatch.DataSource = newdt;
                        rgdCRVBatch.DataBind();
                        rgdCRVBatch.Visible = true;
                        lblTotalQty.Visible = false;
                        lblB.Visible = true;
                    }
                    else
                    {
                        rgdCRVBatch.Visible = false;
                        lblB.Visible = false;
                        lblTotalQty.Visible = true;
                    }

                    //Changes by Shivani
                    foreach (GridColumn myColumn in rgdCRVBatch.MasterTableView.RenderColumns)
                    {
                        if (rgdCRVBatch.Visible != false)
                        {
                            GridFooterItem footeritemFull = (GridFooterItem)rgdCRVBatch.MasterTableView.GetItems(GridItemType.Footer)[0];

                            Label lblTotalQuatity = (Label)footeritemFull.FindControl("lblTotalQuatity");

                            Label lblTotalCost = (Label)footeritemFull.FindControl("lblTotalCost");
                            Label lblTotalFullFormat = (Label)footeritemFull.FindControl("lblTotalFullFormat");
                            Label lblTotalLooseFormat = (Label)footeritemFull.FindControl("lblTotalLooseFormat");
                            lblTotalFullFormat.Text = TotalQuantity.ToString();
                            double quantity = 0.00;
                            double cost = 0.00;
                            foreach (GridDataItem rgdCRVBatchItem in rgdCRVBatch.MasterTableView.Items)
                            {
                                Label lblQuantity = (Label)rgdCRVBatchItem.FindControl("lblQuantity");
                                quantity = quantity + Convert.ToDouble(lblQuantity.Text);
                                Label lblCost = (Label)rgdCRVBatchItem.FindControl("lblCost");
                                cost = cost + Convert.ToDouble(lblCost.Text);
                            }

                            lblTotalQuatity.Text = quantity.ToString();
                            lblTotalCost.Text = cost.ToString();
                            lblTotalFullFormat.Text =(FullQty>0? "Full :" + FullQty.ToString() + FullQtyFormat:string.Empty);
                            lblTotalLooseFormat.Text = (LooseQty > 0 ? "Full :" + LooseQty.ToString() + LooseQtyFormat : string.Empty);

                        }
                    }
                    //Changes ends here
                }
                lblCategory.Text = dtFull.Rows[0]["Cat"].ToString();
                lblDOGIV.Text = Convert.ToDateTime(dtFull.Rows[0]["dateofgenration"].ToString()).ToString("dd/MM/yyyy");
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
            int ltID = Convert.ToInt32(Request.QueryString["ivNo"].ToString());
            Response.Redirect("../StockOutPanel/IssueVoucherCompactView.aspx?ivNo=" + ltID);
        }

    }
}