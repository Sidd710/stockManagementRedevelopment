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
using Telerik.Web.UI;
using RHPDNew;

namespace Demo1
{
    public partial class issueOrder : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
       static int DepuID;  
       static int quarterId;
       static int typeID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            DepuID = Convert.ToInt32(Request.QueryString["Did"].ToString());
            quarterId = Convert.ToInt32(Request.QueryString["qid"].ToString());
            typeID = Convert.ToInt32(Request.QueryString["TypeId"].ToString());
            if(!IsPostBack)
            {
                txtdateofgenration.SelectedDate = DateTime.Now.Date;
               // GenrateAutoIssueorder();
               // bindIssueorder();
                _GetIssued();
               
            }
        }
        public string GetAttributeName(int TypeId)
        {
            string attributename_ = "";
            if (TypeId != 0)
            {

                SqlCommand cmd = new SqlCommand("usp_GetAttributeName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Typeid", TypeId);
                if(con.State.ToString()=="Closed")
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                attributename_ = dt.Rows[0]["AttributeName"].ToString();
                con.Close();
            }

            return attributename_;


        }
        private void _GetIssued()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_getIssuOrderby_BatchIDT", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Did", DepuID);
                cmd.Parameters.AddWithValue("@Qid", quarterId);
                if (con.State.ToString() == "Close")
                    con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    rgdIssuedList.DataSource = dt;
                    rgdIssuedList.DataBind();

                }
                else
                    rgdIssuedList.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void rgdIssuedList_ItemCreated(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {

                    GridDataItem item = (e.Item as GridDataItem);
                    int idtID = int.Parse(item.GetDataKeyValue("id").ToString());
                    Label lblFullPack = (Label)item.FindControl("lblFullPack");
                    Label lblAU = (Label)item.FindControl("lblAU");
                    Label lblFullPackQty = (Label)item.FindControl("lblFullPackQty");
                    Label lblLoosePack = (Label)item.FindControl("lblLoosePack");
                    Label lblLoosePackQty = (Label)item.FindControl("lblLoosePackQty");
                    rhpdEntities db = new rhpdEntities();
                    var IDTList = db.IDTStockTransfers.Where(x => x.IDTId == idtID).ToList();
                    foreach (var val in IDTList)
                    {

                        if (val.PackingType == "Full")
                        {
                            lblFullPack.Text = val.Format;
                            if (lblAU.Text != "NOS")
                                lblFullPackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.000") + " ]";
                            else
                                lblFullPackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.00") + " ]";
                        }
                        else if (val.PackingType == "Loose" || val.PackingType == "DW")
                        {
                            lblLoosePack.Text = val.Format;
                            if (lblAU.Text != "NOS")
                                lblLoosePackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.000") + " ]";
                            else
                                lblLoosePackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.00") + " ]";
                        }
                        else if (val.PackingType == "")
                        {

                            if (lblAU.Text != "NOS")
                                lblLoosePackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.000") + " ]";
                            else
                                lblLoosePackQty.Text = "[Qty: " + Convert.ToDouble(val.Quantity).ToString("0.00") + " ]";
                        }
                    }





                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void GenrateAutoIssueorder()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_createIssueOrderNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
            cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;
            
            cmd.ExecuteNonQuery();
            String intResult = (cmd.Parameters["@intResult"].Value).ToString();
            if(intResult!="")
            {
                txtissueordno.Text = intResult;
                txtissueordno.Enabled = false;
            }
            else
            {
                txtissueordno.Text = "";
            }
            con.Close();
        }
        private void bindIssueorder()
        {

            SqlCommand cmd = new SqlCommand("usp_getIssuOrderby_BatchIDT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qid", quarterId);
            cmd.Parameters.AddWithValue("@Did", DepuID);
           
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                grdIssueOrder.DataSource = dt;
                grdIssueOrder.DataBind();
                
            }
            else
            {
                grdIssueOrder.EmptyDataText = "No Record Found !!!!";
                btnsubmit.Visible = false;
            }
            con.Close();
        }

       
        //public void insertIssueOrder()
        //{
        //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //    {
        //        con.Open();

        //        using (SqlCommand cmd = new SqlCommand("usp_Insert_IssueOrder", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
                  
        //            cmd.Parameters.AddWithValue("@issueorderNo", txtissueordno.Text.Trim());
        //            cmd.Parameters.AddWithValue("@issueorderdate", txtdateofgenration.Text.Trim());
        //            cmd.Parameters.AddWithValue("@authority", txtAuthority.Text.Trim());
        //            cmd.Parameters.AddWithValue("@depoid", DepuID);
        //            cmd.Parameters.AddWithValue("@qid", quarterId);
        //            cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
        //            cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;

        //            cmd.ExecuteNonQuery();
        //            int intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);

        //            con.Close();

        //            if (intResult == 1)
        //            {
        //                Response.Redirect("loadtally.aspx");
        //                //return 1;
        //            }
        //            else
        //            {
        //               // return 0;
        //            }
        //        }
        //    }


        //}

        //protected void btnsubmit_Click(object sender, EventArgs e)
        //{
        //    insertIssueOrder();
        //}


      //  [WebMethod]
        public int insertIssueOrder(int productID, double issuequantity, string IDTICTAWS)
        {
            //rhpdEntities db = new rhpdEntities();
            //var listIO = db.tbl_IssueOrder.ToList();
            //foreach (var item in listIO)
            //{
            //    string[] IONo = item.IssueOrderNo.Split('/');
            //    if (IONo.Count() > 2)
            //    {
            //        string no = IONo[1];
            //        if (no == txtissueordno.Text)
            //        {
            //            txtissueordno.Focus();
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue Order No already Exists!')", true);
                
            //            return 0;
            //        }

            //    }

            //}
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_Insert_IssueOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //string strDate = txtdateofgenration.SelectedDate.ToString().Split(' ')[0];

                    string[] date = txtdateofgenration.SelectedDate.ToString().Split(' ')[0].Split('-');
                    if (date.Count() < 2)
                    {
                        txtdateofgenration.Focus();
                        return 0;
                    }
                    DateTime dateVal = Convert.ToDateTime(txtdateofgenration.SelectedDate);
                     string dog = date[2].ToString().Split(' ')[0] +"/"+ date[1].ToString() +"/"+ date[0].ToString();

                     string IO = "IO/" + txtissueordno.Text.Trim() + "/DT/" + dog;
                     cmd.Parameters.AddWithValue("@issueorderNo",IO );
                     cmd.Parameters.AddWithValue("@issueorderdate", dateVal);//dog);
                               cmd.Parameters.AddWithValue("@authority", txtAuthority.Text.Trim());
                               cmd.Parameters.AddWithValue("@depoid", DepuID);
                               cmd.Parameters.AddWithValue("@qid", quarterId);
                    cmd.Parameters.AddWithValue("@productid", productID);
                    cmd.Parameters.AddWithValue("@issuequantity", issuequantity);
                         cmd.Parameters.AddWithValue("@userid", Session["UserId"]);
                         cmd.Parameters.AddWithValue("@IDTICTAWS", IDTICTAWS);
                    cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
                    cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    int intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);

                    con.Close();

                    return 1;
                }
            }


        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string typeName = GetAttributeName(typeID);
            SqlCommand cmd = new SqlCommand("usp_getIssuOrderby_BatchIDT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qid", quarterId);
            cmd.Parameters.AddWithValue("@Did", DepuID); 
                if(con.State.ToString()=="Closed")
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();            
            da.Fill(dt);
            DataTable dtNew = dt.Clone();            
                int result = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i <1)
                    {
                        rhpdEntities db = new rhpdEntities();
                        var listIO = db.tbl_IssueOrder.ToList();
                        foreach (var item in listIO)
                        {
                            string[] IONo = item.IssueOrderNo.Split('/');
                            if (IONo.Count() > 2)
                            {
                                string no = IONo[1];
                                if (no == txtissueordno.Text)
                                {
                                    txtissueordno.Focus();
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Issue Order No already Exists!')", true);
                                    return;
                                }

                            }

                        }
                    }
                    if (dtNew.Rows.Count > 0)
                    {
                        for (int y = 0; y < i; y++)
                        {
                            if (dtNew.Rows[y]["productid"].ToString() == dt.Rows[i]["productid"].ToString() && dtNew.Rows[y]["DepuID"].ToString() == dt.Rows[i]["DepuID"].ToString() &&
                                dtNew.Rows[y]["Qid"].ToString() == dt.Rows[i]["Qid"].ToString() && dtNew.Rows[y]["BID"].ToString() == dt.Rows[i]["BID"].ToString() &&
                                dtNew.Rows[y]["StockId"].ToString() == dt.Rows[i]["StockId"].ToString())
                                dtNew.Rows[y]["issueqty"] = decimal.Parse(dtNew.Rows[y]["issueqty"].ToString()) + decimal.Parse(dt.Rows[i]["issueqty"].ToString());
                            else
                                dtNew.ImportRow(dt.Rows[i]);
                        }
                    }
                    else
                    {
                        dtNew.ImportRow(dt.Rows[i]);
                    }                
                }
                for (int i = 0; i < dtNew.Rows.Count; i++ )
                {
                    result = insertIssueOrder(int.Parse(dtNew.Rows[i]["productid"].ToString()), double.Parse(dtNew.Rows[i]["issueqty"].ToString()), typeName);
                }
            }

            if (result == 1)
                Response.Redirect("IssueOrderList.aspx");
            }
               
            catch (Exception)
            {
                
                throw;
            }
        }


       


    }
}