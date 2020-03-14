using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RHPDComponent;
using RHPDEntity;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Services;

namespace RHPDNew.StockOutPanel
{
    public partial class MonitoringTool : System.Web.UI.Page
    {

        TemplateField tfield = new TemplateField();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                bindgrid("");
                getdropdownvalue();
                //griddisplay("Oil");
            }
           

        }


        public void bindgrid(string prdName)
        {
            prdName = "Oil";

            try
            {
                DataTable dt3 = new DataTable();
                AddProductComp objaddpro = new AddProductComp();
                dt3 = objaddpro.GriddisplayDALCbyProductComponent("");
                int count = dt3.Rows.Count;
              
                for (int i = count; i > 0; i--)
                {

                    BoundField test = new BoundField();
                    test.DataField = "Depo1_65";
                    test.HeaderText = "DIPU";
                    monitoringtoolGrid_.Columns.Add(test);
                   
                }
                monitoringtoolGrid_.DataSource = dt3;
                monitoringtoolGrid_.DataBind();
               


                //DataRow dr = null;
                //dt3.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                //dt3.Columns.Add(new DataColumn("Column1", typeof(string)));
                //dt3.Columns.Add(new DataColumn("Column2", typeof(string)));
                //dt3.Columns.Add(new DataColumn("Column3", typeof(string)));

                //dr = dt3.NewRow();
                //dr["RowNumber"] = 1;
                //dr["Column1"] = string.Empty;
                //dr["Column2"] = string.Empty;
                //dr["Column3"] = string.Empty;
                //dt3.Rows.Add(dr);

                ////Store the DataTable in ViewState
                //ViewState["CurrentTable"] = dt3;

                //monitoringtoolGrid_.DataSource = dt3;
                //monitoringtoolGrid_.DataBind();
                
            }

            catch (Exception)
            {

                throw;
            }

        }


        protected void monitoringtoolGrid__RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }



        public void griddisplay(string productName)
        {
            try
            {
                DataTable dt3 = new DataTable();
                AddProductComp objaddpro = new AddProductComp();
                dt3 = objaddpro.GriddisplayDALCbyProductComponent(productName);

                monitoringtoolGrid_.DataSource = dt3;
                monitoringtoolGrid_.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static DataTable GetData(string text)
        {
            try
            {
                ManageStockEntity objentity = new ManageStockEntity();
                ManagestockComp objcom = new ManagestockComp();
                objentity.Productname = text.Trim();
                objentity.Action = "GetProduct";
                DataTable dt = objcom.GetProduct(objentity);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void getdropdownvalue()
        {
            ddlProduct.DataSource = GetData("");
            ddlProduct.DataTextField = "Product_Name";
            ddlProduct.DataValueField = "Product_ID";
            ddlProduct.DataBind();
            ListItem li = new ListItem("--Select Product--", "0");



        }

      

        //protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlProduct.SelectedValue != "0")
        //    {
        //        string pname = ddlProduct.SelectedItem.Text;
        //        griddisplay(pname);




        //    }
        //}

        [WebMethod]
        public static ProductDetail[] BindBatchproductDetail(string Product_Name)
        {
            DataTable dt = new DataTable();
            List<ProductDetail> details = new List<ProductDetail>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("select * from  ProductMaster where isActive=1 and Product_Name='" + Product_Name + "'", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        ProductDetail Productdetail_ = new ProductDetail();
                        Productdetail_.Product_Name = dtrow["Product_Name"].ToString();
                        Productdetail_.StockQty = Convert.ToInt32(dtrow["StockQty"]);
                        Productdetail_.productUnit = dtrow["productUnit"].ToString();
                        Productdetail_.GSreservre = Convert.ToInt32(dtrow["GSreservre"]);
                        details.Add(Productdetail_);
                    }
                }
            }
            return details.ToArray();
        }
        public class ProductDetail
        {
            public string Product_Name { get; set; }
            public int StockQty { get; set; }
            public string productUnit { get; set; }
            public int GSreservre { get; set; }


        }



        [WebMethod]
        public static int insertIDT(int Dipuprd_IDTqty, string Product_Name, string Dipu)
        {
           
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_InsertPrdIdt_QTY", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DipuIdtQty", Dipuprd_IDTqty);
                    cmd.Parameters.AddWithValue("@prdName", Product_Name);
                    cmd.Parameters.AddWithValue("@Dipuname", Dipu);
                    cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
                    cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    int intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);

                    con.Close();

                    if (intResult == 1)
                    {

                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

        }












    }
}