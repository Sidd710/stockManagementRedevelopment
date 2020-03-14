using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RHPDComponent;

namespace RHPDNew.Forms
{
    public partial class frmPMList : System.Web.UI.Page
    {
        public string TruncateDecimalToString(double value, int digit)
        {
            try
            {
                double step = (double)Math.Pow(10, digit);
                int tmp = (int)Math.Truncate(step * value);
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
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
   
        private void _BindData()
        {
            try
            {
               // DataTable dt = new DataTable();
               // SqlCommand cmd = new SqlCommand("spStock", con);
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.AddWithValue("@Action", "SelectPMList");     
               //// cmd.Parameters.AddWithValue("@IsEmptyPM", 0);                
               // con.Open();
               // SqlDataAdapter da = new SqlDataAdapter(cmd);               
               // da.Fill(dt);
                rgdCRV.DataSource = _GetGrid();
                rgdCRV.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private DataTable _GetGrid()
        {
            try
            {
                DataTable dtCRV = new DataTable();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("spStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SelectPMList");               
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCRV);
                rgdCRV.DataSource = dtCRV; 
               
              
                dt = dtCRV.Clone();
                
                    foreach (DataRow dr in dtCRV.Rows)
                {

                  
                    double pmQty = 0;
                    double subpmQty = 0;
                    double pmFullQty = 0;
                    double pmSubFullQty = 0;
                    double productQty = 0;

                    if (Convert.ToBoolean(dr["IsEmptyPM"]) == false)
                    {
                        StockPakagingComp pkcmp = new StockPakagingComp();
                        DataTable dtPK = new DataTable();
                        dtPK = pkcmp.SelectByStockId(int.Parse(dr["SID"].ToString()));
                         pmQty = 0;
                        foreach (DataRow cdr in dtPK.Rows)
                        {
                            if (cdr["PackagingType"].ToString() == "DW")
                            {
                                productQty = productQty + double.Parse(cdr["RemainingQty"].ToString());//B                             

                                string[] full = cdr["Format"].ToString().Split('X');
                                if (full.Count() > 0)
                                {
                                    pmQty = pmQty + +Convert.ToDouble(full[0]);//A
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
                    
                   
                    if (Convert.ToBoolean(dr["IsSubPacking"]) == true)
                    {
                        dt.Rows.Add(DateTime.Now.TimeOfDay.Milliseconds, dr["SubPMName"], productQty, pmQty, "", "", "", "", dr["SubCapacity"], dr["SubGrade"], dr["SubCondition"], dr["AU"], dr["Product_Name"], dr["Cat"], dr["IsEmptyPM"], dr["IsDW"], 0, dr["RecievedOn"], dr["AddedOn"]);

                        dr["PMQty"] = subpmQty;
                        //dr["Product_Name"] = dr["PackingMaterial"];
                        dr["Product_Name"] = dr["SubPMName"];
                        dr["Quantity"] = pmQty;
                        dt.ImportRow(dr);
                    }
                    else
                    {
                        if (Convert.ToBoolean(dr["IsDW"].ToString()) == true)
                            dr["PMQty"] = pmQty;
                        else
                        dr["PMQty"] = subpmQty;
                        if (Convert.ToBoolean(dr["IsEmptyPM"]) == true)
                        {
                            dr["PMQty"] = dr["Quantity"];
                            dr["Quantity"] = 0;
                        }
                        dt.ImportRow(dr);
                    }

                    
                }
                    return dt;
               
            }
            catch (Exception)
            {

                throw;
            }
        }
 

        protected void rgdCRV_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
          // // _BindData();
          //  DataTable dt = new DataTable();
          //  SqlCommand cmd = new SqlCommand("spStock", con);
          //  cmd.CommandType = CommandType.StoredProcedure;
          //  cmd.Parameters.AddWithValue("@Action", "SelectPMList");
          ////  cmd.Parameters.AddWithValue("@IsEmptyPM", rbtnPacking.SelectedValue);
          //  con.Open();
          //  SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  da.Fill(dt);
            rgdCRV.DataSource = _GetGrid(); 
        }

        protected void rbtnPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            _BindData();
        }

        protected void rgdCRV_PreRender(object sender, EventArgs e)
        {
            int count = 0;
            double qty = 0;
            double tPMQty = 0;
            foreach (GridDataItem dataItem in rgdCRV.MasterTableView.Items)
            {
                Label lblQuantity = (Label)dataItem.FindControl("lblQuantity");
                qty = qty + Convert.ToDouble(lblQuantity.Text);
                count++;
                //PM Qty
                int SID = int.Parse(dataItem.GetDataKeyValue("SID").ToString());
                Label lblPMQty = (Label)dataItem.FindControl("lblPMQty");
                    tPMQty=tPMQty+ Convert.ToDouble(lblPMQty.Text);        
                
            }
            GridFooterItem footeritem = (GridFooterItem)rgdCRV.MasterTableView.GetItems(GridItemType.Footer)[0];
            Label lblQty = (Label)footeritem.FindControl("lblQty");
            Label lblCount = (Label)footeritem.FindControl("lblCount");
            lblQty.Text =TruncateDecimalToString(qty,3);
            lblCount.Text = count.ToString() ;
            Label lblPMQtyF = (Label)footeritem.FindControl("lblPMQtyF");
            lblPMQtyF.Text = tPMQty.ToString("0");
  
        }
    }
}