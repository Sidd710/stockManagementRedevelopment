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
using System.Web.Script.Services;
using AjaxControlToolkit;
using Telerik.Web.UI;
using RHPDComponent;
using System.Globalization;

namespace RHPDNew.Forms
{
    public partial class frmExpenseVoucherList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserDetails"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {GetList();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetList()
        {
            try
            {

            SqlCommand cmd = new SqlCommand("spExpenseVoucherList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Pending");          
            if(con.State.ToString()=="Closed")
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rgdPendingList.DataSource = dt;
            rgdPendingList.DataBind();
             cmd = new SqlCommand("spExpenseVoucherList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Generated");
            if (con.State.ToString() == "Closed")
                con.Open();
             da = new SqlDataAdapter(cmd);
             dt = new DataTable();
            da.Fill(dt);
            rgdGeneratedList.DataSource = dt;
            rgdGeneratedList.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        protected void rgdPendingList_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                  if (e.CommandName == "Gen")
                        {
                            rhpdEntities db = new rhpdEntities();
                            int bID = Convert.ToInt32(e.CommandArgument.ToString());
                            foreach (GridDataItem dataItem in rgdPendingList.MasterTableView.Items)
                    {
                        int kBID = Convert.ToInt32(dataItem.GetDataKeyValue("BID"));
                        if (kBID == bID)
                        {
                            HiddenField RemainingQty = (HiddenField)dataItem.FindControl("RemainingQty");

                            HiddenField hdnCID = (HiddenField)dataItem.FindControl("CID");
                            HiddenField hdnPID = (HiddenField)dataItem.FindControl("PID");
                            Label lblSampleSentQty = (Label)dataItem.FindControl("lblSampleSentQty");
                            Label lblDamagedBox = (Label)dataItem.FindControl("lblDamagedBox");
                            Label lblFull = (Label)dataItem.FindControl("lblFull");
                            Label lblLoose = (Label)dataItem.FindControl("lblLoose");
                            Label lblDW = (Label)dataItem.FindControl("lblDW");
                            TextBox txtRemarks = (TextBox)dataItem.FindControl("txtRemarks");
                            TextBox txtEXVNo = (TextBox)dataItem.FindControl("txtEXVNo");
                            Label lblErr = (Label)dataItem.FindControl("lblErr");
                            var chexkExist = db.ExpenseVoucherMasters.Where(s => s.ExpenseVoucherNo == txtEXVNo.Text).FirstOrDefault();
                            if (chexkExist != null)
                            {
                                lblErr.Text = "Expense Voucher No already Exists!";
                                return;
                            }
                            else
                                lblErr.Text = "";
                            string Full = "";
                            double damgeQty = 0;
                            string Loose = "";
                            double formatQty = 1;
                            double numberOfBoxes = 0;
                            if (lblFull.Text != "")
                            {
                                string[] fullArr = lblFull.Text.Split('X');
                                for (int i = 1; i < fullArr.Count(); i++)
                                {
                                    formatQty = formatQty * double.Parse(fullArr[i]);
                                }
                                // numberOfBoxes = Math.Round(double.Parse(lblSampleSentQty.Text) / formatQty);
                                numberOfBoxes = double.Parse(lblDamagedBox.Text);
                                double qty = 0;
                                if (fullArr.Count() > 1)
                                    qty = double.Parse(fullArr[0]) - numberOfBoxes;
                                damgeQty = numberOfBoxes * formatQty;
                                Full = qty.ToString();
                                formatQty = formatQty * qty;
                                for (int i = 1; i < fullArr.Count(); i++)
                                {
                                    Full = Full + "X" + fullArr[i];
                                    //damgeQty = damgeQty * double.Parse(fullArr[i]);

                                }
                            }
                            else
                                formatQty = 0;

                            damgeQty = damgeQty - double.Parse(lblSampleSentQty.Text);
                            if (damgeQty < 0)
                                damgeQty = 0;
                            if (lblLoose.Text != "")
                            {
                                if (lblDW.Text != "")
                                // (PType.Value == "DW") 
                                {
                                    double qty = double.Parse(RemainingQty.Value);
                                    damgeQty = qty = qty - double.Parse(lblSampleSentQty.Text);
                                    Loose = lblLoose.Text;
                                }
                                else
                                {
                                    double qty = 0;
                                    string[] LooseArr = lblLoose.Text.Split('|');
                                    if (LooseArr.Count() > 1)
                                        qty = double.Parse(LooseArr[0]);
                                    qty = (damgeQty + qty);
                                    Loose = qty.ToString();
                                    for (int l = 1; l < LooseArr.Count(); l++)
                                    {
                                        Loose = Loose + "|" + LooseArr[l];
                                    }
                                }
                            }
                            else
                            {
                                if (lblDW.Text != "") // (PType.Value == "DW")
                                {
                                    double qty = double.Parse(RemainingQty.Value);
                                    damgeQty = qty = qty - double.Parse(lblSampleSentQty.Text);
                                    Loose = qty.ToString();
                                }
                                else
                                {
                                    Loose = damgeQty.ToString();
                                }


                            }

                            ExpenseVoucherMaster objEx = new ExpenseVoucherMaster();
                            objEx.AddedBy = 1;
                            objEx.ExpenseVoucherNo = txtEXVNo.Text;
                            objEx.AddedOn = DateTime.Now;
                            objEx.BatchID = bID;
                            objEx.CategoryID = int.Parse(hdnCID.Value);
                            objEx.ProductID = int.Parse(hdnPID.Value);
                            objEx.Remarks = txtRemarks.Text;
                            objEx.FormatFull = Full;
                            objEx.FormatLoose = Loose;
                            objEx.UsedFromFullPackets = Convert.ToDecimal(lblDamagedBox.Text);
                            objEx.UsedQty = Convert.ToDecimal(lblSampleSentQty.Text);
                            objEx.RemainingQty = Convert.ToDecimal(formatQty + damgeQty);// Convert.ToDecimal(lblSampleSentQty.Text);  
                            db.ExpenseVoucherMasters.Add(objEx);
                            db.SaveChanges();
                            Response.Redirect("../Forms/frmAddExpensePM.aspx?evNo=" + txtEXVNo.Text + "&cID=" + objEx.CategoryID);
                        }

                       
                              

                    }
                        }
                  GetList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void rgdGeneratedList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("spExpenseVoucherList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Generated");
            if (con.State.ToString() == "Closed")
                con.Open();
          SqlDataAdapter  da = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
            da.Fill(dt);
            rgdGeneratedList.DataSource = dt;
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {GetList();
        }

        protected void lbtnAddContainer_Click(object sender, EventArgs e)
        {
            try
            {
                
            LinkButton btn = (LinkButton)sender;
            int bID = Convert.ToInt32(btn.CommandArgument.ToString());
              foreach (GridDataItem dataItem in rgdPendingList.MasterTableView.Items)
              {
                  int kBID = Convert.ToInt32(dataItem.GetDataKeyValue("BID"));
                  if (kBID == bID)
                  {
                      HiddenField hdnCID = (HiddenField)dataItem.FindControl("CID");
                      HiddenField hdnPID = (HiddenField)dataItem.FindControl("PID");
                      Response.Redirect("../Forms/frmAddExpensePM.aspx?bID=" + bID + "&cID=" + int.Parse(hdnCID.Value));
                      
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