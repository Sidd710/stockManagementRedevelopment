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
    public partial class PrintIssueVoucher1 : System.Web.UI.Page
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
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblAuthority.Text = dt.Rows[0]["Authority"].ToString();
                    lblTo.Text = dt.Rows[0]["UnitNo"].ToString();
                    lblThrough.Text = dt.Rows[0]["through"].ToString();
                    lblVoucherNo.Text = dt.Rows[0]["IssueVoucherId"].ToString();
                    _GetSummary(dt);

                    _GetVehicle(id);

                }
            }

        }

        private void _GetVehicle(int id)
        {
            try
            {
                 SqlCommand cmd = new SqlCommand("[usp_GetIssueVoucherVehicle]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                if(con.State.ToString()=="Closed")
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    if (lblVechicleNo.Text == "")
                        lblVechicleNo.Text = dr["VehicleNo"].ToString() + "[" + dr["DriverName"].ToString() + "]";
                    else
                        lblVechicleNo.Text =  lblVechicleNo.Text +", "+ dr["VehicleNo"].ToString() + "[" + dr["DriverName"].ToString() + "]";

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //private void _GetSummary(DataTable dt)
        //{
        //    try
        //    {
                
        //        DataTable dtFull = new DataTable();
        //        DataTable dtPM = new DataTable();
        //        DataTable dtSUBPM = new DataTable();
        //        dtFull = dt.Clone();
        //        dtPM = dt.Clone();
        //        dtSUBPM = dt.Clone();
        //        string PM = "";
        //        string SUBPM = "";
        //        string ATSO = "";
        //        string IDTICT = "";                
        //        var Dom = "";
        //        var Esl = "";
        //        string IV = "";
        //        double pmQty = 0;
        //        double subPMQty = 0;
        //        string sidMin = "";
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            int sid = int.Parse(dr["SID"].ToString());
        //            //sidMin = "-" + (sid + (10 * 10)).ToString();
        //            sidMin = (sid + (10 * 10)).ToString();
        //            rhpdEntities db = new rhpdEntities();
        //            var lstSID = db.StockMasters.Where(s => s.SID == sid).FirstOrDefault();
        //            if (lstSID != null)
        //            {
        //                if (lstSID.IsEmptyPM == true || lstSID.IsWithoutPacking == true || lstSID.IsDW == true)
        //                {

        //                    dtFull.ImportRow(dr);
        //                }
        //                else
        //                {

        //                    dtFull.ImportRow(dr);

        //                    if (PM != lstSID.PackingMaterial)
        //                    {

        //                        if (pmQty > 0)
        //                            dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT,Dom,Esl, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO,"","");

        //                        PM = lstSID.PackingMaterial;

        //                        pmQty = 0;

        //                        string[] full = dr["FormatFull"].ToString().Split('X');
        //                        string[] loose = dr["FormatLoose"].ToString().Split('|');
        //                        if (full.Count() > 0 && full[0].ToString() != "")
        //                            pmQty = pmQty + double.Parse(full[0]);
        //                        if (loose.Count() > 0 && loose[0].ToString() != "")
        //                            pmQty = pmQty + double.Parse(loose[0]);
        //                        ATSO = dr["ATSONo"].ToString();
        //                        IDTICT = dr["IDTICTAWS"].ToString();
        //                        IV = dr["IssueVoucherId"].ToString();

        //                    }
        //                    else
        //                    {

        //                        string[] full = dr["FormatFull"].ToString().Split('X');
        //                        string[] loose = dr["FormatLoose"].ToString().Split('|');
        //                        if (full.Count() > 0 && full[0].ToString() != "")
        //                            pmQty = pmQty + double.Parse(full[0]);
        //                        if (loose.Count() > 0 && loose[0].ToString() != "")
        //                            pmQty = pmQty + double.Parse(loose[0]);
        //                        ATSO = dr["ATSONo"].ToString();
        //                        IDTICT = dr["IDTICTAWS"].ToString();
        //                        IV = dr["IssueVoucherId"].ToString();
        //                    }


        //                    if (lstSID.IsSubPacking == true)
        //                    {
        //                        if (SUBPM != lstSID.SubPMName)
        //                        {

        //                            if (subPMQty > 0)
        //                                dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, Dom, Esl, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

        //                            SUBPM = lstSID.SubPMName;
        //                            subPMQty = 0;

        //                            string[] full = dr["FormatFull"].ToString().Split('X');
        //                            string[] loose = dr["FormatLoose"].ToString().Split('|');
        //                            if (full.Count() > 1 && full[1].ToString() != "")
        //                                subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
        //                            if (loose.Count() > 1 && loose[1].ToString() != "")
        //                                subPMQty = subPMQty + double.Parse(loose[1]);
        //                        }
        //                        else
        //                        {
        //                            string[] full = dr["FormatFull"].ToString().Split('X');
        //                            string[] loose = dr["FormatLoose"].ToString().Split('|');
        //                            if (full.Count() > 1 && full[1].ToString() != "")
        //                                subPMQty = subPMQty + double.Parse(full[1]) * double.Parse(full[0]);
        //                            if (loose.Count() > 1 && loose[1].ToString() != "")
        //                                subPMQty = subPMQty + double.Parse(loose[1]) + double.Parse(loose[0]);

        //                        }
        //                    }
        //                }

        //            }

        //        }
        //        if (pmQty > 0)
        //        {

        //            if (pmQty > 0)
        //                dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, Dom, Esl, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");

        //            PM = "";

        //            pmQty = 0;
        //        }
        //        if (subPMQty > 0)
        //        {
        //            sidMin = (1 + (int.Parse(sidMin))).ToString();
        //            if (subPMQty > 0)
        //                dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, Dom, Esl, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

        //            SUBPM = "";
        //            subPMQty = 0;
        //        }
        //        dtFull.Merge(dtPM);
        //        dtFull.Merge(dtSUBPM);
        //        lblCount.Text = "(items " + dtFull.Rows.Count + " only)";
        //        rgdSummary.DataSource = dtFull;
        //        rgdSummary.DataBind();

        //        foreach (GridDataItem rgd in rgdSummary.MasterTableView.Items)
        //        {
        //            int key = int.Parse(rgd.GetDataKeyValue("ProductId").ToString());
        //            if (key < 0)
        //            {
        //                Table tblBatch = (Table)rgd.FindControl("tblBatch");
        //                tblBatch.Visible = false;
        //            }
        //        }
        //        GridFooterItem footeritemFull = (GridFooterItem)rgdSummary.MasterTableView.GetItems(GridItemType.Footer)[0];
        //        double cost = 0;
        //        double weight = 0;
        //        double qty = 0;
        //        foreach (DataRow dr in dtFull.Rows)
        //        {
        //            cost = cost + double.Parse(dr["VCost"].ToString());
        //            weight = weight + double.Parse(dr["vWeight"].ToString());
        //            qty = qty + double.Parse(dr["stockquantity"].ToString());
        //        }
        //        Label lblWeight = (Label)footeritemFull.FindControl("lblWeight");
        //        Label lblCost = (Label)footeritemFull.FindControl("lblCost");

        //        Label lblTotalQty = (Label)footeritemFull.FindControl("lblTotalQty");
        //        lblTotalQty.Text = qty.ToString("0.000");
        //        lblWeight.Text ="Weight: "+ weight.ToString("0.000");
        //        lblCost.Text = "Cost: "+cost.ToString("0.00");
        //        lblAmount.Text = "Total Amount: " + cost.ToString("0.00");
        //        lblInWords.Text = "(" + ConvertNumberToWord(cost.ToString())+ ")";
        //        lblCatogory.Text = lblCatogory.Text + "&nbsp;" + dtFull.Rows[0]["Cat"].ToString() + " group vide DS No. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt" + Convert.ToDateTime(dtFull.Rows[0]["dateofgenration"].ToString()).ToString("dd/MM/yyyy"); ;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

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
                var Dom = "";
                var Esl = "";
                double pmQty = 0;
                double subPMQty = 0;
                string sidMin = "";
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
                                    dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, Dom, Esl, "", 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");

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
                                Dom = Convert.ToDateTime(dr["DOM"].ToString()).ToString("dd/MM/yyyy");
                                Esl = Convert.ToDateTime(dr["ESL"].ToString()).ToString("dd/MM/yyyy");


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
                                Dom = Convert.ToDateTime(dr["DOM"].ToString()).ToString("dd/MM/yyyy");
                                Esl = Convert.ToDateTime(dr["ESL"].ToString()).ToString("dd/MM/yyyy");

                            }


                            if (lstSID.IsSubPacking == true)
                            {
                                if (SUBPM != lstSID.SubPMName)
                                {

                                    if (subPMQty > 0)
                                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, Dom, Esl, "", 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

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
                        dtPM.Rows.Add(0, int.Parse(sidMin), 0, "", pmQty, IDTICT, "", Dom, Esl, 0, "", "", 0, int.Parse(sidMin), PM, "Nos", IV, ATSO, "", "");

                    PM = "";

                    pmQty = 0;
                }
                if (subPMQty > 0)
                {
                    sidMin = (1 + (int.Parse(sidMin))).ToString();
                    if (subPMQty > 0)
                        dtSUBPM.Rows.Add(0, int.Parse(sidMin), 0, "", subPMQty, IDTICT, "", Dom, Esl, 0, "", "", 0, int.Parse(sidMin), SUBPM, "Nos", IV, ATSO, "", "");

                    SUBPM = "";
                    subPMQty = 0;
                }
                dtFull.Merge(dtPM);
                dtFull.Merge(dtSUBPM);
                //lblItemCount.Text = "(Items " + dtFull.Rows.Count + " only)";
                //gridSummary.DataSource = dtFull;
                //gridSummary.DataBind();
                //lblCategory.Text = dtFull.Rows[0]["Cat"].ToString();
                //lblDOGIV.Text = Convert.ToDateTime(dtFull.Rows[0]["dateofgenration"].ToString()).ToString("dd/MM/yyyy");

                lblCount.Text = "(items " + dtFull.Rows.Count + " only)";
                rgdSummary.DataSource = dtFull;
                rgdSummary.DataBind();

                foreach (GridDataItem rgd in rgdSummary.MasterTableView.Items)
                {
                    int key = int.Parse(rgd.GetDataKeyValue("ProductId").ToString());
                    if (key < 0)
                    {
                        Table tblBatch = (Table)rgd.FindControl("tblBatch");
                        tblBatch.Visible = false;
                    }
                }
                GridFooterItem footeritemFull = (GridFooterItem)rgdSummary.MasterTableView.GetItems(GridItemType.Footer)[0];
                double cost = 0;
                double weight = 0;
                double qty = 0;
                foreach (DataRow dr in dtFull.Rows)
                {
                    cost = cost + double.Parse(dr["VCost"].ToString());
                    weight = weight + double.Parse(dr["vWeight"].ToString());
                    qty = qty + double.Parse(dr["stockquantity"].ToString());
                }
                Label lblWeight = (Label)footeritemFull.FindControl("lblWeight");
                Label lblCost = (Label)footeritemFull.FindControl("lblCost");

                Label lblTotalQty = (Label)footeritemFull.FindControl("lblTotalQty");
                lblTotalQty.Text = qty.ToString("0.000");
                lblWeight.Text = "Weight: " + weight.ToString("0.000");
                lblCost.Text = "Cost: " + cost.ToString("0.00");
                lblAmount.Text = "Total Amount: " + cost.ToString("0.00");
                lblInWords.Text = "(" + ConvertNumberToWord(cost.ToString()) + ")";
                lblCatogory.Text = lblCatogory.Text + "&nbsp;" + dtFull.Rows[0]["Cat"].ToString() + " group vide DS No. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt" + Convert.ToDateTime(dtFull.Rows[0]["dateofgenration"].ToString()).ToString("dd/MM/yyyy"); ;

            }
            catch (Exception)
            {
                throw;
            }
        }
        

    }
}