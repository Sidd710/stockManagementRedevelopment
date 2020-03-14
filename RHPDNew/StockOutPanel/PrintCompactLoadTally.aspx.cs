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
using System.Text;

namespace RHPDNew.StockOutPanel
{
    public partial class PrintCompactLoadTally : System.Web.UI.Page
    {
       
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
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

                        _BindData();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        static public string LTNo = "";
        static public string VehicleType = "";
        static public string UnitNio = "";
        static public string Authority = "";
        static public string VechileNumber = "";
        static public string Through = "";
        static public string DriverName = "";
        static public string ArmyNo = "";
        static public string Rank = "";
        static public double StockQty = 0;
        static public int ProductCount = 0;
        private void _BindData()
        {
            try
            {
                if (Request.QueryString["ltNo"] != null)
                {
                    int ltID = Convert.ToInt32(Request.QueryString["ltNo"].ToString());
                    rhpdEntities db = new rhpdEntities();
                    var lt = db.tbl_loadtallydetail.Where(l => l.Id == ltID).FirstOrDefault();
                    if (lt != null)
                    {

                        lblIssueId.Text = LTNo = lt.loadtallyNumber;
                        UnitNio = lt.UnitNo;
                        lblAuthority.Text = Authority = lt.Authority;
                        var sumQty = db.tblIssueVoucherVehicleDetails.Where(v => v.issueorderID == lt.IssueorderId && v.VehicleNo == lt.vechileNo).Sum(v => v.StockQuantity);
                        if (sumQty != null)
                            StockQty = Convert.ToDouble(sumQty);
                        var ltList = db.tbl_loadtaly.Where(l => l.loadtallyNumber == lt.loadtallyNumber && l.IssueorderId == lt.IssueorderId && l.vechileNo == lt.vechileNo).ToList();
                        var vehList = db.tbl_vechileMaster.Where(v => v.VechileNumber == lt.vechileNo).FirstOrDefault();
                        if (vehList != null)
                        {
                            var vType = db.tbl_vechileMaster_Type.Where(vt => vt.VtypeId == vehList.vechileType).FirstOrDefault();
                            if (vType != null)
                                VehicleType = vType.Vtypename;
                            VechileNumber = vehList.VechileNumber;
                              Rank = vehList.Rank;
                            DriverName = vehList.DriverName;
                            lblThrough.Text = Through = vehList.Through;
                            ArmyNo = vehList.ArmyNo;
                            DataTable dt = new DataTable();
                            dt = _GetLoadTallyData(ltID);
                            ProductCount = dt.Rows.Count;
                            lblTo.Text = dt.Rows[0]["DepotName"].ToString();
                            lblFrom.Text = "RHPD Pathankot";
                            _GetSummary(dt);
                        }
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private DataTable _GetLoadTallyData(int ltNo)
        {
            try
            {
                DataTable dt = new DataTable();

                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
                {
                    using (SqlCommand cmd = new SqlCommand("usp_GetLoadTallyData", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@LTId", ltNo);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;
                    }
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
                double pmQty = 0;
                double subPMQty = 0;
                string sidMin = "";
                string dom="";
                   string esl= "";

                foreach (DataRow dr in dt.Rows)
                {

                    int sid = int.Parse(dr["SID"].ToString());
                    sidMin = "-" + (sid + (10 * 10)).ToString();
                    rhpdEntities db = new rhpdEntities();
                    var lstSID = db.StockMasters.Where(s => s.SID == sid).FirstOrDefault();
                    if (lstSID != null)
                    {
                        if (lstSID.IsEmptyPM == true || lstSID.IsWithoutPacking == true || lstSID.IsDW == true)
                        {

                            dtFull.ImportRow(dr);
                        }
                        else
                        {

                            dtFull.ImportRow(dr);

                            if (PM != lstSID.PackingMaterial)
                            {

                                if (pmQty > 0)
                                    dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, dr["DOM"].ToString(), dr["ESL"].ToString());

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
                                 dom = dr["DOM"].ToString();
                                 esl = dr["ESL"].ToString();
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
                            }


                            if (lstSID.IsSubPacking == true)
                            {
                                if (SUBPM != lstSID.SubPMName)
                                {

                                    if (subPMQty > 0)
                                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO,"","");

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
                        dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO,dom,esl);


                    PM = "";

                    pmQty = 0;
                }
                if (subPMQty > 0)
                {
                    sidMin = (1 + (int.Parse(sidMin))).ToString();
                    if (subPMQty > 0)
                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO,"","");

                    SUBPM = "";
                    subPMQty = 0;
                }
                dtFull.Merge(dtPM);
                dtFull.Merge(dtSUBPM);
                lblCount.Text = "(items " + dtFull.Rows.Count + " only)";
                
                _GetTable(dtFull);
                    double cost = 0;
               
                foreach (DataRow dr in dtFull.Rows)
                {
                    cost = cost + double.Parse(dr["VCost"].ToString());
                   
                }
                 lblAmount.Text = "Total Amount: " + cost.ToString("0.00");
                lblInWords.Text = "(" + ConvertNumberToWord(cost.ToString()) + ")";
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void _GetTable(DataTable dt)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table><tr style=\"font-size:14px\">");
                sb.Append("<th> S.NO.</ th >");
                sb.Append("<th > Commodity </ th >");
                sb.Append("  <th > A / U </ th >");
                sb.Append("  <th > Pack </ th >");
                sb.Append(" <th > Qty </ th >");
                sb.Append(" <th > DOM </ th >");
                sb.Append("  <th > ESL </ th >");
                sb.Append("  <th > Remarks </ th ></ tr >");
                int sno = 1;
               
                StringBuilder sbCommodity = new StringBuilder();
                StringBuilder sbAU = new StringBuilder();
                StringBuilder sbPack = new StringBuilder();
                StringBuilder sbQty = new StringBuilder();
                StringBuilder sbDOM = new StringBuilder();
                StringBuilder sbESL = new StringBuilder();
                StringBuilder sbCost = new StringBuilder();

                //New

                StringBuilder sbCommodity1 = new StringBuilder();
                StringBuilder sbAU1 = new StringBuilder();
                StringBuilder sbPack1 = new StringBuilder();
                StringBuilder sbQty1 = new StringBuilder();
                StringBuilder sbDOM1 = new StringBuilder();
                StringBuilder sbESL1 = new StringBuilder();
                StringBuilder sbCost1 = new StringBuilder();
                string pname = "";
                string dom = "";
                string esl = "";

                string spackFull = "";
                string spackLoose = "";
                double sqty = 0;
                string remarks="";
                foreach (DataRow dr in dt.Rows)
                {
                    if (pname == "")
                    {
                        pname = dr["product_name"].ToString();
                        dom = dr["DOM"].ToString();
                        esl = dr["ESL"].ToString();
                        spackFull = dr["FormatFull"].ToString();
                        spackLoose = dr["FormatLoose"].ToString();
                        remarks = dr["Remarks"].ToString();
                        sqty = double.Parse(dr["stockquantity"].ToString());

                    }
                    else if (pname == dr["product_name"].ToString() && dom == dr["DOM"].ToString() && esl == dr["ESL"].ToString())
                    {
                        pname = dr["product_name"].ToString();
                        dom = dr["DOM"].ToString();
                        esl = dr["ESL"].ToString();
                        if (dr["FormatFull"].ToString()!="")
                        spackFull = spackFull + ", " + dr["FormatFull"].ToString();
                        if(dr["FormatLoose"].ToString()!="")
                        spackLoose = spackLoose + ", " + dr["FormatLoose"].ToString();
                        remarks = dr["Remarks"].ToString();
                        sqty = sqty + double.Parse(dr["stockquantity"].ToString());

                    }
                    else
                    {

                        sb.Append("<tr  style=\"font-size:12px\" >");
                        sb.Append(" <td >" + sno.ToString() + "</ td >");
                        sb.Append("<td >" + pname + "</ td >");
                        if (sno > 1)
                            sb.Append("<td >Nos </ td >");
                        else
                            sb.Append("<td > " + dr["productunit"].ToString() + "</ td >");
                        if (spackFull == "")
                            spackFull = "N/A";
                        if (spackLoose != "")
                            spackFull = spackFull + ", " + spackLoose;
                       
                        sb.Append("<td >" + spackFull+ "</ td >");
                        sb.Append("<td >" + TruncateDecimalToString(sqty, 3) + "</ td >");
                        sb.Append("<td >" + dom + "</ td >");
                        sb.Append("<td >" + esl + "</ td >");
                        sb.Append("<td >" + remarks + "</ td >");
                        sb.Append("</tr>");
                        sno++;

                        pname = dr["product_name"].ToString();
                        spackFull  = dr["FormatFull"].ToString();
                        spackLoose =  dr["FormatLoose"].ToString();
                        sqty = double.Parse(dr["stockquantity"].ToString());
                        if (int.Parse(dr["SID"].ToString()) > 0)
                        {
                            dom = dr["DOM"].ToString();
                            esl = dr["ESL"].ToString();
                        }
                        else
                        {
                            dom = "";
                            esl = "";
                        }
                        remarks = dr["Remarks"].ToString();

                    }
                }
                sb.Append("<tr  style=\"font-size:12px\" >");
                sb.Append(" <td >" + sno.ToString() + "</ td >");
                sb.Append("<td >" + pname + "</ td >");
                sb.Append("<td >Nos </ td >");
                if (spackFull == "")
                    spackFull = "N/A";
                if (spackLoose != "")
                    spackFull = spackFull + ", " + spackLoose;

                sb.Append("<td >" + spackFull + "</ td >"); 
                sb.Append("<td >" + TruncateDecimalToString(sqty, 3) + "</ td >");
                sb.Append("<td >" + dom + "</ td >");
                sb.Append("<td >" + esl + "</ td >");
                sb.Append("<td >" + remarks + "</ td >");
                sb.Append("</tr>");
                sb.Append("   </table > ");
                ltrTable.Text = sb.ToString();

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
    
    
        public void getloadtally()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetLoadTallyToPrint", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@LoadtallyNumber", Request.QueryString["no"].ToString());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblAuthority.Text = dt.Rows[0]["Authority"].ToString();
                        lblThrough.Text = dt.Rows[0]["Through"].ToString();
                        lblIssueId.Text = Request.QueryString["no"].ToString();
                    }

                }
            }
        }

        protected void btnprints_Click(object sender, EventArgs e)
        {
            int ltID = Convert.ToInt32(Request.QueryString["ltNo"].ToString());
            Response.Redirect("../StockOutPanel/PrintLoadTally.aspx?ltNo=" + ltID);
           
    
        }
    }
}