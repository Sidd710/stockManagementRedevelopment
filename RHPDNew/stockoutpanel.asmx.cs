using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Configuration;
using StarMethods;
using System.Web.Script.Serialization;

namespace RHPDNew
{
    /// <summary>
    /// Summary description for stockoutpanel
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class stockoutpanel : System.Web.Services.WebService
    {
        #region Monitoring Screen
        [WebMethod(EnableSession = true)]
        public int StockOutMain_AddUpdateIDT(string QuarterId, string ProductId, string DepotId, string UserId, string IDT, string IDTUpdate)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            string attributename = Gettypename();
            if (attributename == "IDT")
            {

            }
            else if (attributename == "Full Year")
            {

            }
            else
            {
                QuarterId = "0";
            }
            int retrunVal = 0;
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@QuarterId", QuarterId);
            param[1] = new SqlParameter("@ProductId", ProductId);
            param[2] = new SqlParameter("@DepotId", DepotId);
            param[3] = new SqlParameter("@UserId", UserId);
            param[4] = new SqlParameter("@IDT", IDT);
            param[5] = new SqlParameter("@IDTUpdate", IDTUpdate);
            param[6] = new SqlParameter("@TypeId", HttpContext.Current.Session["attribute"]);
            param[7] = new SqlParameter("@Yearvalue", HttpContext.Current.Session["yearvaluue"]);
            retrunVal = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "usp_StockOutMain_AddUpdate", param);
            con.Close();
            if (retrunVal == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        [WebMethod(EnableSession = true)]
        public int StockOutMain_Depot_Update(string QuarterId, string DepotId, string UserId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            int retrunVal = 0;
            string attributename = Gettypename();
            if (attributename == "IDT")
            {

            }
            else if (attributename == "Full Year")
            {

            }
            else
            {
                QuarterId = "0";
            }
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@QuarterId", QuarterId);
            param[1] = new SqlParameter("@DepotId", DepotId);
            param[2] = new SqlParameter("@UserId", UserId);
            param[3] = new SqlParameter("@TypeId", HttpContext.Current.Session["attribute"].ToString());
            param[4] = new SqlParameter("@Yearvalue", HttpContext.Current.Session["yearvaluue"].ToString());
            retrunVal = StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "usp_StockOutMain_Depot_Update", param);
            con.Close();
            if (retrunVal == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        [WebMethod(EnableSession = true)]
        public string Gettypename()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            string attributename_ = "";
            SqlCommand cmd = new SqlCommand("usp_GetAttributeName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Typeid", HttpContext.Current.Session["attribute"].ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            attributename_ = dt.Rows[0]["AttributeName"].ToString();
            con.Close();
            return attributename_;
        }
        #endregion

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string HelloWorld1(string a)
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

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



        }


        [WebMethod(EnableSession = true)]
        public int insertdata(string BatchName, int issueqty, int Did, int prdId, int qid, int TypeId)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_InsertBatchIDT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@prdname", HttpContext.Current.Session["prdname"]);
                    cmd.Parameters.AddWithValue("@BatchName", BatchName.Trim());
                    cmd.Parameters.AddWithValue("@issueqty", issueqty);
                    cmd.Parameters.AddWithValue("@depuID", Did);
                    cmd.Parameters.AddWithValue("@productID", prdId);
                    cmd.Parameters.AddWithValue("@QuaterID", qid);
                    cmd.Parameters.AddWithValue("@TypeId", TypeId);
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


        [WebMethod(EnableSession = true)]
        public int insertIssueOrderNew(string IssueOrderNo, string issueorder_date, string Authority, string DepotProductQuarterQty)
        {
            string[] detail_DepotProductQuarterQty = DepotProductQuarterQty.Split('_');
            if (detail_DepotProductQuarterQty.Count() != 4)
            {
                return 0;
            }

            int depotid = Convert.ToInt32(detail_DepotProductQuarterQty[0]);
            int productID = Convert.ToInt32(detail_DepotProductQuarterQty[1]);
            int quarterid = Convert.ToInt32(detail_DepotProductQuarterQty[2]);
            int issuequantity = Convert.ToInt32(detail_DepotProductQuarterQty[3]);


            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_Insert_IssueOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@prdname", HttpContext.Current.Session["prdname"]);
                    cmd.Parameters.AddWithValue("@issueorderNo", IssueOrderNo.Trim());
                    cmd.Parameters.AddWithValue("@issueorderdate", issueorder_date);
                    cmd.Parameters.AddWithValue("@authority", Authority.Trim());
                    cmd.Parameters.AddWithValue("@depoid", depotid);
                    cmd.Parameters.AddWithValue("@qid", quarterid);
                    cmd.Parameters.AddWithValue("@productid", productID);
                    cmd.Parameters.AddWithValue("@issuequantity", issuequantity);
                    cmd.Parameters.AddWithValue("@userid", HttpContext.Current.Session["UserId"]);
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


        [WebMethod(EnableSession = true)]
        public int insertIssueOrder(string IssueOrderNo, string issueorder_date, string Authority, int depotid, int quarterid, int productID, int issuequantity)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_Insert_IssueOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@prdname", HttpContext.Current.Session["prdname"]);
                    cmd.Parameters.AddWithValue("@issueorderNo", IssueOrderNo.Trim());
                    cmd.Parameters.AddWithValue("@issueorderdate", issueorder_date);
                    cmd.Parameters.AddWithValue("@authority", Authority.Trim());
                    cmd.Parameters.AddWithValue("@depoid", depotid);
                    cmd.Parameters.AddWithValue("@qid", quarterid);
                    cmd.Parameters.AddWithValue("@productid", productID);
                    cmd.Parameters.AddWithValue("@issuequantity", issuequantity);
                    cmd.Parameters.AddWithValue("@userid", HttpContext.Current.Session["UserId"]);
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


        [WebMethod(EnableSession = true)]
        public int insertIssueVoucher(string VehicleNo, string PMQuantity, int StockQuantity, string IssueVoucherId, string dateofgenration, string Through, int ProductId, string Authority, int Cat_Id, int issueorderID, string batchno)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("usp_IssueVoucherVehicleDetail_AddUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo.Trim());
                    cmd.Parameters.AddWithValue("@PMQuantity", PMQuantity);
                    cmd.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                    cmd.Parameters.AddWithValue("@IssueVoucherId", IssueVoucherId.Trim());
                    cmd.Parameters.AddWithValue("@dateofgenration", dateofgenration);
                    cmd.Parameters.AddWithValue("@Through", Through);
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);
                    cmd.Parameters.AddWithValue("@VoucherRemarks", "");
                    cmd.Parameters.AddWithValue("@authority", Authority);
                    cmd.Parameters.AddWithValue("@catid", Cat_Id);
                    cmd.Parameters.AddWithValue("@UserId", HttpContext.Current.Session["UserId"]);
                    cmd.Parameters.AddWithValue("@issueorderid", issueorderID);
                    cmd.Parameters.AddWithValue("@batchno", batchno);


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




        [WebMethod(EnableSession = true)]
        public string checkissueorderNo(string issueorderno)
        {
            // List<classmaster> details = new List<classmaster>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("select Count(1) from tbl_IssueOrder where issueorderno='" + issueorderno + "' and active=1", con))
                {
                    con.Open();
                    string chk = cmd.ExecuteScalar().ToString();
                    con.Close();
                    return chk;
                }
            }

        }

        [WebMethod(EnableSession = true)]
        public static Vechile[] getVechiledetail(int Productid)
        {
            DataTable dt = new DataTable();
            List<Vechile> details = new List<Vechile>();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            {
                using (SqlCommand cmd = new SqlCommand("usp_getVechiledetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@productID", Productid);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        Vechile vechiledetail_ = new Vechile();
                        vechiledetail_.VehicleNo = dtrow["VehicleNo"].ToString();
                        vechiledetail_.PMQuantity = Convert.ToInt32(dtrow["PMQuantity"]);
                        vechiledetail_.StockQuantity = Convert.ToInt32(dtrow["StockQuantity"].ToString());
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
            public int StockQuantity { get; set; }



        }

        [WebMethod(EnableSession = true)]
        public int InsertIntoVechileMaster(string pTableData)
        {
            int intResult = 0;
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                con.Open();
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                VehicleClass oRootObject = new VehicleClass();
                VehicleClass[] tableData = oJS.Deserialize<VehicleClass[]>(pTableData);
                foreach (var obj in tableData)
                {
                    using (SqlCommand cmd = new SqlCommand("usp_VechileMaster_AddUpdate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VechileNumber", obj.VechileNumber.Trim());
                        cmd.Parameters.AddWithValue("@DriverName", obj.DriverName);
                        cmd.Parameters.AddWithValue("@Rank", obj.Rank);
                        cmd.Parameters.AddWithValue("@Through", obj.Through.Trim());
                        cmd.Parameters.AddWithValue("@ArmyNo", obj.ArmyNo.Trim());
                        cmd.Parameters.AddWithValue("@vechileType", obj.vechileType.Trim());
                        cmd.Parameters.AddWithValue("@unitNo", obj.unitNo.Trim());
                        cmd.Parameters.AddWithValue("@LicenseNo", obj.LicenseNo.Trim());
                        cmd.Parameters.AddWithValue("@Remarks", obj.Remarks.Trim());
                        cmd.Parameters.AddWithValue("@userId", HttpContext.Current.Session["UserId"]);
                        cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
                        cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);
                    }
                }
                con.Close();
            }
            return intResult;
        }

        /*** Added by Rohit Pundeer ***/
        public class VehicleClass
        {
            public string Through { get; set; }
            public string vechileType { get; set; }
            public string VechileNumber { get; set; }
            public string DriverName { get; set; }
            public string Rank { get; set; }
            public string ArmyNo { get; set;}
            public string  unitNo { get; set; }
            public string  LicenseNo { get; set; }
            public string Remarks { get; set; }
        }

        //[WebMethod(EnableSession = true)]
        //public int InsertVechileMaster(string VechileNumber, string DriverName, string Rank, string Through, string ArmyNo, string vechileType,string unitNo,string Remarks,string LicenseNo)
        //{
        //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //    {
        //        con.Open();

        //        using (SqlCommand cmd = new SqlCommand("usp_VechileMaster_AddUpdate", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@VechileNumber", VechileNumber.Trim());
        //            cmd.Parameters.AddWithValue("@DriverName", DriverName);
        //            cmd.Parameters.AddWithValue("@Rank", Rank);
        //            cmd.Parameters.AddWithValue("@Through", Through.Trim());
        //            cmd.Parameters.AddWithValue("@ArmyNo", ArmyNo.Trim());
        //            cmd.Parameters.AddWithValue("@vechileType", vechileType.Trim());
        //            cmd.Parameters.AddWithValue("@unitNo", unitNo.Trim());
        //            cmd.Parameters.AddWithValue("@LicenseNo", LicenseNo.Trim());
        //            cmd.Parameters.AddWithValue("@Remarks", Remarks.Trim());
        //            cmd.Parameters.AddWithValue("@userId", HttpContext.Current.Session["UserId"]);
        //            cmd.Parameters.Add("@intResult", SqlDbType.NVarChar, 100, "");
        //            cmd.Parameters["@intResult"].Direction = ParameterDirection.Output;

        //            cmd.ExecuteNonQuery();
        //            int intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value);

        //            con.Close();

        //            if (intResult == 1)
        //            {

        //                return 1;
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //        }
        //    }


        //}


    }
}
