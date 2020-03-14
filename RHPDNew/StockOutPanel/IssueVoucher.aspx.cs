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

namespace RHPDNew.StockOutPanel
{
    public partial class IssueVoucher : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        int catID;
        int issueorderId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                   lblAuthority.Text = "";
                   lblcategory.Text = "";
                   txtthrough.Text = "";
                //btngeIssuvoucher.Visible = false;
                 catID = Convert.ToInt32(Request.QueryString["Category_Id"]);
                 issueorderId = Convert.ToInt32(Request.QueryString["IssueOrderId"]);
                 ViewState["categoryID"] = catID;
                 genrateAutoIssuevoucherNumber(issueorderId, catID);
                 getdetail(catID);
                 bindissuevoucherdetail(catID);
                 bindIssueorderforIssueVoucher(catID);
             //    _GetVehicle(issueorderId);
              
            }
        }

      
        public void _GetVehicle(int issueorderId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spSelectTranfer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "GetIDTQtyByIssueOrderID");
              cmd.Parameters.AddWithValue("@IssuOrderID", issueorderId);
 
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
          //  rgdVehicle.DataSource=dt;
           // rgdVehicle.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public void genrateAutoIssuevoucherNumber(int issueodId,int categoryId)
        {
            SqlCommand cmd = new SqlCommand("usp_creareIssueVoucherNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IssueorderId", issueodId);
            cmd.Parameters.AddWithValue("@CatId", categoryId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void getIssuevoucherNumber()
        {
            using (SqlCommand cmd = new SqlCommand("usp_getissuevoucherNumber", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
               
                cmd.Parameters.AddWithValue("@issueorderid", issueorderId);
                cmd.Parameters.AddWithValue("@CatId", ViewState["categoryID"]);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtissueVoucher.Text = dr["IssusevoucherName"].ToString();
                        

                    }
                    else
                    {

                    }
                }
                con.Close();
            }
        }
        public void getdetail( int cat_ID)
        {
            using (SqlCommand cmd = new SqlCommand("usp_getdeatilIssuevoucher", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@catid", cat_ID);
                cmd.Parameters.AddWithValue("@issueorderid", issueorderId);
               
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        lblAuthority.Text = dr["Authority"].ToString();
                        lblcategory.Text = dr["Category_Name"].ToString();
                        tablefirst.Visible = true;
                        tableSecond.Visible = true;

                    }
                    else
                    {
                        lblmessage.Visible = true;
                        tableSecond.Visible = false;
                        tablefirst.Visible = false;
                        lblmessage.Text = "No Record Found !!!!";

                    }
                }
                con.Close();
            }


        }

        public void bindissuevoucherdetail(int cid)
        {
            getIssuevoucherNumber();
            using (SqlCommand cmd = new SqlCommand("usp_getissuevoucherdetail", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@catid", cid);
                cmd.Parameters.AddWithValue("@issueorderid", issueorderId);
               
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        //txtissueVoucher.Text = dr["issuevoucherid"].ToString();
                        txtdateofgenration.Text = dr["dateofgenration"].ToString();
                        txtthrough.Text = dr["through"].ToString();
                      
                        txtissueVoucher.Enabled = false;
                        txtdateofgenration.Enabled = false;
                        txtthrough.Enabled = false;
                        tablefirst.Visible = true;
                        tableSecond.Visible = true;

                    }
                    else
                    {

                    }
                }
                con.Close();
            }

        }

        private void binddropdown()
        {

            SqlCommand cmd = new SqlCommand("usp_getcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@prdid", prdid);

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlcategory.DataTextField = "Category_Name";
                ddlcategory.DataValueField = "ID";
                ddlcategory.DataSource = dt;
                ddlcategory.DataBind();
                ddlcategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
            else
            {

            }
            con.Close();
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAuthority.Text = "";
            lblcategory.Text = "";
            txtthrough.Text = "";
            lblmessage.Visible = false;
            int catid =Convert.ToInt32(ddlcategory.SelectedValue);
            lblcategory.Text = ddlcategory.SelectedItem.Text;
            getdetail(catid);
            bindIssueorderforIssueVoucher(catid);
           
        }

        private void bindIssueorderforIssueVoucher( int categoryID)
        {

            SqlCommand cmd = new SqlCommand("usp_getisuueorder_forIssueVoucher", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@catID", categoryID);
            cmd.Parameters.AddWithValue("@issueorderid", issueorderId);
          

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                grdproductdata.DataSource = dt;
                grdproductdata.DataBind();
                productgrid.Visible = true;

            }
            else
            {
                grdproductdata.EmptyDataText = "No Record Found !!!!";
                productgrid.Visible = false;
            }
            con.Close();
        }

        protected void grdproductdata_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int prdid = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btn = (Button)e.Row.FindControl("btnvechile");
                LinkButton lnkvechile = (LinkButton)e.Row.FindControl("lnvechiledetail");
                HiddenField hd1 = (HiddenField)e.Row.FindControl("HiddenField1");
                prdid = Convert.ToInt32(hd1.Value);



                SqlCommand cmd = new SqlCommand("usp_getcount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productid", prdid);
                cmd.Parameters.AddWithValue("@catID", catID);
                cmd.Parameters.AddWithValue("@issueorderid", issueorderId);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    btn.Visible = false;
                    lnkvechile.Visible = true;
                    lnkvechile.Style.Add("display", "block");
                    lnkvechile.Text = "Vechile detail Added";
                }
                else
                {
                    btn.Visible = true;
                    lnkvechile.Visible = false;
                    
                }

                if(lnkvechile.Text=="")
                {
                    btngeIssuvoucher.Visible = false;
                }
                

            }

        }

        protected void btngeIssuvoucher_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_GenrateIssueVoucher", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@catId", ViewState["categoryID"]);
                    cmd.Parameters.AddWithValue("@IssueVoucherNumber", txtissueVoucher.Text.Trim());
                    cmd.ExecuteNonQuery();
                    
                }
                Response.Redirect("issueorderlist.aspx");
            }
            con.Close();
        }

        [WebMethod(EnableSession = true)]
        public static Vechile[] getVechiledetail(int ProductId, int issueorderID, string batchno)
        {
            DataTable dt = new DataTable();
            List<Vechile> details = new List<Vechile>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_getvechiledetailbatchwise", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@productid", ProductId);
                    cmd.Parameters.AddWithValue("@issueorderid", issueorderID);
                    cmd.Parameters.AddWithValue("@batchno", batchno);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        Vechile vechiledetail_ = new Vechile();
                        vechiledetail_.VehicleNo = dtrow["VehicleNo"].ToString();
                       // vechiledetail_.PMQuantity = Convert.ToInt32(dtrow["PMQuantity"]);
                        vechiledetail_.StockQuantity = dtrow["StockQuantity"].ToString();
                        details.Add(vechiledetail_);
                    }
                }
            }
            return details.ToArray();
        }
        public class Vechile
        {
            public string VehicleNo { get; set; }
            public int PMQuantity { get; set; }
            public string StockQuantity { get; set; }



        }



        [WebMethod(EnableSession = true)]
        public static Batchdetail[] GetBatchDetail(int ProductId, int issueorderID)
        {
            DataTable dt = new DataTable();
            List<Batchdetail> details = new List<Batchdetail>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetBatchquantity", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@productID", ProductId);
                    cmd.Parameters.AddWithValue("@issueorderid", issueorderID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        Batchdetail Batchdetail_ = new Batchdetail();
                        Batchdetail_.BatchName = dtrow["BatchName"].ToString();
                        Batchdetail_.issueqty = dtrow["issueqty"].ToString();
                        details.Add(Batchdetail_);
                    }
                }
            }
            return details.ToArray();
        }
        public class Batchdetail
        {
            public string BatchName { get; set; }
            public string issueqty { get; set; }




        }

  

        [WebMethod(EnableSession = true)]
        public static Vechileautocompete[] GetVechileAutocompete(string mail)
        {
            DataTable dt = new DataTable();
            List<Vechileautocompete> details = new List<Vechileautocompete>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_getvechileAutocompete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                  
                    cmd.Parameters.AddWithValue("@SearchText", mail);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        Vechileautocompete vecdetail_ = new Vechileautocompete();
                        vecdetail_.VechileNumber = dtrow["VechileNumber"].ToString();

                        details.Add(vecdetail_);
                    }
                }
            }
            return details.ToArray();
        }
        public class Vechileautocompete
        {
            public string VechileNumber { get; set; }
         



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string hdn = hdnBatchNo.Value;
        }



    }
}