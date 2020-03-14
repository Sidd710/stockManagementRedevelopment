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
    public partial class frmAddExpensePM : System.Web.UI.Page
    {
        static int CID = 0;
        static int BID = 0;
        public static string cpmIDs = "";
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

                    bindgrid();
                    clear();
                }
            }
        }
      
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                rhpdEntities db = new rhpdEntities();
                int pmcID = 0;
               
                if (apPMC.Entries.Count == 0)
                {
                    if (hdnPMC.Value != "")
                        pmcID = int.Parse(hdnPMC.Value);
                }
                else
                    pmcID = int.Parse(apPMC.Entries[0].Value);
               
                    var updPM = db.AddPMContainers.Where(s => s.ID == pmcID).SingleOrDefault();
                    if (updPM.Quantity < Convert.ToDecimal(txtQty.Text))
                    {
                        lblQtyErr.Text ="Only "+ updPM.Quantity.ToString() + " Quantity available!";
                        return;
                    }
               
              
                if (btnSubmit.Text == "Submit")
                {
                    

                    var item = db.tblExpensePMContainers.Where(s => s.AddPMContainer.ID == pmcID).Where(s => s.AddPMContainer.CategoryID == CID).SingleOrDefault();
                    if (item != null)
                    {
                        var query = from emp in db.tblExpensePMContainers
                                    where emp.AddPMContainer.ID == pmcID
                                    select emp;
                        tblExpensePMContainer objcmd = query.Where(s => s.AddPMContainer.CategoryID == CID).SingleOrDefault();
                        objcmd.ExpenseVoucherNo = "";
                       
                            objcmd.Quantity = objcmd.Quantity + Convert.ToDecimal(txtQty.Text);

                            objcmd.IsSentfromCP = false;
                        objcmd.PMContainerId = pmcID;
                        objcmd.Remarks = txtRemarks.Text;                      
                        objcmd.ModifiedOn = DateTime.Now;
                        objcmd.ModifiedBy = 1;
                        db.SaveChanges();
                        if (cpmIDs != "")                        
                          cpmIDs= cpmIDs+"," + objcmd.Id.ToString();  
                        else                       
                            cpmIDs= objcmd.Id.ToString();
                        Response.Redirect("../Forms/frmAddExpensePM.aspx?bID=" + BID + "&cID=" + CID + "&cpmID=" + cpmIDs);
                        //if (!cbxSentFrom.Checked)
                        //{
                        //    var updPM = db.AddPMContainers.Where(s => s.ID==pmcID).SingleOrDefault();
                        //    if (updPM != null)
                        //    {
                        //        var updPMQ = from emp in db.AddPMContainers
                        //                    where emp.ID == pmcID
                        //                    select emp;
                        //        AddPMContainer objupdPM = updPMQ.SingleOrDefault();
                        //        objupdPM.Quantity = (objupdPM.Quantity - Convert.ToDecimal(txtQty.Text)) < 0 ? 0 : (objupdPM.Quantity - Convert.ToDecimal(txtQty.Text));
                        //        objupdPM.ModifiedBy = 1;
                        //        objupdPM.ModidfiedOn = DateTime.Now;


                        //        db.SaveChanges();
                        //    }
                        //}
                    }
                    else
                    {
                        tblExpensePMContainer objcmd = new tblExpensePMContainer();
                        objcmd.ExpenseVoucherNo = "";                        
                        objcmd.Quantity = Convert.ToDecimal(txtQty.Text);
                        objcmd.IsSentfromCP = false;
                        objcmd.PMContainerId = pmcID;
                        objcmd.Remarks = txtRemarks.Text;                      
                        objcmd.AddedBy = 1;
                        objcmd.AddedOn = DateTime.Now;
                        db.tblExpensePMContainers.Add(objcmd); db.SaveChanges();
                        lblMessage.Text = "Record Saved !!";
                        if (cpmIDs != "")
                            cpmIDs = cpmIDs + "," + objcmd.Id.ToString();
                        else
                            cpmIDs = objcmd.Id.ToString();
                        Response.Redirect("../Forms/frmAddExpensePM.aspx?bID=" + BID + "&cID=" + CID + "&cpmID=" + cpmIDs);
                        //if (!cbxSentFrom.Checked)
                        //{
                        //    var updPM = db.AddPMContainers.Where(s => s.ID == pmcID).SingleOrDefault();
                        //    if (updPM != null)
                        //    {
                        //        var updPMQ = from emp in db.AddPMContainers
                        //                     where emp.ID == pmcID 
                        //                     select emp;
                        //        AddPMContainer objupdPM = updPMQ.SingleOrDefault();
                        //        objupdPM.Quantity = (objupdPM.Quantity - Convert.ToDecimal(txtQty.Text)) < 0 ? 0 : (objupdPM.Quantity - Convert.ToDecimal(txtQty.Text));
                        //        objupdPM.ModifiedBy = 1;
                        //        objupdPM.ModidfiedOn = DateTime.Now;


                        //        db.SaveChanges();
                        //    }
                        //}

                    }
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (hfid.Value != "")
                    {
                        var defIndex = Convert.ToInt32(hfid.Value);
                        
                       
                        var query = from emp in db.tblExpensePMContainers
                                    where emp.Id == defIndex
                                    select emp;
                        tblExpensePMContainer objcmd = query.Where(s => s.AddPMContainer.CategoryID == CID).SingleOrDefault();
                        objcmd.ExpenseVoucherNo = "";
                       
                        objcmd.Quantity = objcmd.Quantity + Convert.ToDecimal(txtQty.Text);

                        objcmd.IsSentfromCP = false;
                        objcmd.PMContainerId = pmcID;
                        objcmd.Remarks = txtRemarks.Text;
                        objcmd.ModifiedOn = DateTime.Now;
                        objcmd.ModifiedBy = 1;
                        db.SaveChanges();
                        //if (!cbxSentFrom.Checked)
                        //{
                        //    var updPM = db.AddPMContainers.Where(s => s.ID == pmcID).SingleOrDefault();
                        //    if (updPM != null)
                        //    {
                        //        var updPMQ = from emp in db.AddPMContainers
                        //                     where emp.ID == pmcID
                        //                     select emp;
                        //        AddPMContainer objupdPM = updPMQ.SingleOrDefault();
                        //        objupdPM.Quantity = (objupdPM.Quantity - Convert.ToDecimal(txtQty.Text)) < 0 ? 0 : (objupdPM.Quantity - Convert.ToDecimal(txtQty.Text));
                        //        objupdPM.ModifiedBy = 1;
                        //        objupdPM.ModidfiedOn = DateTime.Now;


                        //        db.SaveChanges();
                        //    }
                        //}

                        string[] stockIDs = Request.QueryString["cpmID"].ToString().Split(',');
                        string qString = "";
                        for (int i = 0; i < stockIDs.Count(); i++)
                        {
                            if (stockIDs[i] != defIndex.ToString())
                                qString = qString + stockIDs[i] + ",";

                        }
                        cpmIDs=qString + defIndex.ToString();
                        Response.Redirect("../Forms/frmAddExpensePM.aspx?bID=" + BID + "&cID=" + CID + "&cpmID=" + cpmIDs);

                        lblMessage.Text = "Record Updated !!";
                    }
                    else
                    {
                        lblMessage.Text = "Select Record First !!";
                    }

                    btnSubmit.Text = "Submit";
                    hfid.Value = "";
                }
                clear();
                bindgrid();

            }
            catch (Exception)
            {

                throw;
            }


        }
      
        private void clear()
        {
           
            bindgrid();
            lblQtyErr.Text = "";
            txtQty.Text = "";
            apPMC.Entries.Clear();
            hfid.Value = "0";
            btnSubmit.Text = "Submit";
            hdnPMC.Value = "";
            lblPMC.Text = "";
            txtRemarks.Text = "";
            rfPMC.Enabled = true;
           
        }  SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private void bindgrid()
        {
            try
            {
                if (Request.QueryString["bID"] != null && Request.QueryString["cID"] != null)
                {
                    CID = Convert.ToInt32(Request.QueryString["cID"].ToString());
                    BID = Convert.ToInt32(Request.QueryString["bID"].ToString());
                    hdnCatID.Value = CID.ToString();
                    if (Request.QueryString["cpmID"] != null)
                        cpmIDs = Request.QueryString["cpmID"].ToString();

                    SqlCommand cmd = new SqlCommand("spExpenseVoucherList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "PendingByIDs");
                    cmd.Parameters.AddWithValue("@IDs", cpmIDs);
                    if (con.State.ToString() == "Closed")
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        btnSubmitAll.Visible = true;
                        grdFormation.DataSource = dt;
                        grdFormation.DataBind();

                    }
                    else
                        btnSubmitAll.Visible = false;

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void grdFormation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            rhpdEntities db = new rhpdEntities();
            if (e.CommandName.ToString() == "UpdateRecord")
            {
                var defIndex = Convert.ToInt16(e.CommandArgument);

                var objcmd = db.tblExpensePMContainers.Single(s => s.Id == defIndex);

                if (objcmd != null)
                {
                    txtRemarks.Text = objcmd.Remarks;
                    if (objcmd.IsSentfromCP == true)
                    {
                        div1.Visible = true;
                        req.Enabled = true;
                    }
                    else
                    {
                        div1.Visible = true;
                        req.Enabled = true;
                        txtQty.Text = objcmd.Quantity.ToString();
                    }
                  
                    lblPMC.Text = "[ " + objcmd.AddPMContainer.PMandContainerMaster.MaterialName + "_" + objcmd.AddPMContainer.PMandContainerMaster.Capacity + "_" + objcmd.AddPMContainer.PMandContainerMaster.Grade + "_" + objcmd.AddPMContainer.PMandContainerMaster.Condition + "]";
                    hdnPMC.Value = objcmd.AddPMContainer.ID.ToString(); 
                    hfid.Value = objcmd.Id.ToString();
                    btnSubmit.Text = "Update";



                }
            }
            else if (e.CommandName.ToString() == "DeleteRecord")
            {

                tblExpensePMContainer objcmd = new tblExpensePMContainer() { Id = Convert.ToInt32(e.CommandArgument) };
                db.tblExpensePMContainers.Attach(objcmd);
                db.tblExpensePMContainers.Remove(objcmd);
                db.SaveChanges();
                bindgrid();
            }
        }

       

        protected void Unnamed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFrom.Checked == true)
            { divEVNo.Visible = true;
            divCPM.Visible = false;
            }
            else
            {
                divEVNo.Visible = false;
                divCPM.Visible = true;
            }
        }
      
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                rhpdEntities db = new rhpdEntities();
                var chexkExist = db.ExpenseVoucherMasters.Where(s => s.ExpenseVoucherNo == txtEXVNo.Text).FirstOrDefault();
                if (chexkExist != null)
                {
                    lblErr.Text = "Expense Voucher No already Exists!";
                    return;
                }
                else
                    lblErr.Text = "";
                 SqlCommand cmd = new SqlCommand("spExpenseVoucherList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "PendingByBID");
            cmd.Parameters.AddWithValue("@BID", BID);   
            if(con.State.ToString()=="Closed")
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);            
                if(dt.Rows.Count>0)
                {
                   
                    string Full = "";
                    double damgeQty = 0;
                    string Loose = "";
                    double formatQty = 1;
                    double numberOfBoxes = 0;
                    if (dt.Rows[0]["FormatFull"].ToString() != "")
                    {
                        string[] fullArr =dt.Rows[0]["FormatFull"].ToString().Split('X');
                        for (int i = 1; i < fullArr.Count(); i++)
                        {
                            formatQty = formatQty * double.Parse(fullArr[i]);
                        }
                     
                        numberOfBoxes = double.Parse(dt.Rows[0]["DamagedBox"].ToString());
                        double qty = 0;
                        if (fullArr.Count() > 1)
                            qty = double.Parse(fullArr[0]) - numberOfBoxes;
                        damgeQty = numberOfBoxes * formatQty;
                        Full = qty.ToString();
                        formatQty = formatQty * qty;
                        for (int i = 1; i < fullArr.Count(); i++)
                        {
                            Full = Full + "X" + fullArr[i];
                            
                        }
                    }
                    else
                        formatQty = 0;

                    damgeQty = damgeQty - double.Parse(dt.Rows[0]["SampleSentQty"].ToString());
                    if (damgeQty < 0)
                        damgeQty = 0;
                    if (dt.Rows[0]["FormatLoose"].ToString() != "")
                    {
                        if (dt.Rows[0]["FormatDW"].ToString() != "")
                        // (PType.Value == "DW") 
                        {
                            double qty = double.Parse(dt.Rows[0]["RemainingQty"].ToString());
                            damgeQty = qty = qty - double.Parse(dt.Rows[0]["SampleSentQty"].ToString());
                            Loose = dt.Rows[0]["FormatLoose"].ToString();
                        }
                        else
                        {
                            double qty = 0;
                            string[] LooseArr = dt.Rows[0]["FormatLoose"].ToString().Split('|');
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
                        if (dt.Rows[0]["FormatDW"].ToString() != "") // (PType.Value == "DW")
                        {
                            double qty = double.Parse(dt.Rows[0]["RemainingQty"].ToString());
                            damgeQty = qty = qty - double.Parse(dt.Rows[0]["SampleSentQty"].ToString());
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
                    objEx.BatchID = BID;
                    objEx.CategoryID = CID;
                    objEx.ProductID = int.Parse(dt.Rows[0]["Product_ID"].ToString());
                    objEx.Remarks =txtRemarksEV.Text;
                    objEx.FormatFull = Full;
                    objEx.FormatLoose = Loose;
                    objEx.UsedFromFullPackets = Convert.ToDecimal(dt.Rows[0]["DamagedBox"].ToString());
                    objEx.UsedQty = Convert.ToDecimal(dt.Rows[0]["SampleSentQty"].ToString());
                    objEx.RemainingQty = Convert.ToDecimal(formatQty + damgeQty);// Convert.ToDecimal(lblSampleSentQty.Text);  
                    db.ExpenseVoucherMasters.Add(objEx);
                    db.SaveChanges();

                    if (Request.QueryString["cpmID"] != null)
                        cpmIDs = Request.QueryString["cpmID"].ToString();
                    string[] cpmID = cpmIDs.Split(',');                   
                    for (int i = 0; i < cpmID.Count(); i++)
                    {
                        int id=int.Parse(cpmID[i].ToString());
                        var item = db.tblExpensePMContainers.Where(s => s.Id == id).FirstOrDefault();
               
                        if (item!=null && item.IsSentfromCP==false)
                        {
                            tblExpensePMContainer upCPM = db.tblExpensePMContainers.Where(s => s.Id == id).FirstOrDefault();
                            upCPM.ExpenseVoucherNo = objEx.ExpenseVoucherNo;
                            upCPM.ModifiedBy = 1;
                            upCPM.ModifiedOn = DateTime.Now;
                            db.SaveChanges();
                            var updPM = db.AddPMContainers.Where(s => s.ID == item.PMContainerId).SingleOrDefault();
                            if (updPM != null)
                            {
                                var updPMQ = from emp in db.AddPMContainers
                                             where emp.ID == item.PMContainerId
                                             select emp;
                                AddPMContainer objupdPM = updPMQ.SingleOrDefault();
                                objupdPM.Quantity = (objupdPM.Quantity - Convert.ToDecimal(item.Quantity)) < 0 ? 0 : (objupdPM.Quantity - Convert.ToDecimal(item.Quantity));
                                objupdPM.ModifiedBy = 1;
                                objupdPM.ModidfiedOn = DateTime.Now;
                                db.SaveChanges();
                            }
                        }
                    }
                    BID = 0; CID = 0; cpmIDs = "";
                    Response.Redirect("../Forms/frmExpenseVoucherList.aspx");

            }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnSubmitAll_Click(object sender, EventArgs e)
        {
            if (btnSubmitAll.Text != "Add PM")
            {
                divEVNo.Visible = true;
                divCPM.Visible = false;
                cbxFrom.Visible = false;
                btnSubmitAll.Text = "Add PM";
            }
            else
            {
                divEVNo.Visible = false;
                divCPM.Visible = true;
                cbxFrom.Visible = true;
                btnSubmitAll.Text = "Submit All";
            }
          

        }
    }
}