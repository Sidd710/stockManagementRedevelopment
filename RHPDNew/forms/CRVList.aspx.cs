using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;
using Telerik.Web.UI.Skins;
using Telerik.Web.UI;

namespace RHPDNew.Forms
{
    public partial class CRVList : System.Web.UI.Page
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

        private void _BindData()
        {
           
            rgdCRV.DataSource = _GetGrid();
            rgdCRV.DataBind();
            _GetGrid();
        }

        private DataTable _GetGrid()
        {
            try
            {
             DataTable dt = new DataTable();
             DataTable dtCRV = new DataTable();
            StockComp stockComp = new StockComp();
            dt = stockComp.SelectAll();
            dtCRV = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                StockBatchComp cmp = new StockBatchComp();
                DataTable bdt = new DataTable();
                bdt = cmp.SelectByStockId(int.Parse(dr["SID"].ToString()));
                double amount = 0;
                foreach (DataRow bdr in bdt.Rows)
                {
                    amount = amount + double.Parse(bdr["Cost"].ToString());
                }
                dr["Amount"] = amount;
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

            rgdCRV.DataSource = _GetGrid();
        }

        protected void rgdCRV_PreRender(object sender, EventArgs e)
        {
            int count = 0;
            double qty = 0;
            foreach (GridDataItem dataItem in rgdCRV.MasterTableView.Items)
            {
                Label lblQuantity = (Label)dataItem.FindControl("lblamt");
                qty = qty + Convert.ToDouble(lblQuantity.Text);
                count++;
            }
            GridFooterItem footeritem = (GridFooterItem)rgdCRV.MasterTableView.GetItems(GridItemType.Footer)[0];
            Label lblamt = (Label)footeritem.FindControl("lblQty");
            Label lblCount = (Label)footeritem.FindControl("lblCount");
            lblamt.Text = qty.ToString("0.00");
            lblCount.Text = count.ToString();
        }

      

    }
}