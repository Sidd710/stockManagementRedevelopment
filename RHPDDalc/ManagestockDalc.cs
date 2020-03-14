using RHPDEntity;
using StarMethods;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace RHPDDalc
{
    public class ManagestockDalc
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        ManageStockEntity objmse = new ManageStockEntity();




        public int insertdalc(ManageStockEntity objentity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[19];
                param[0] = new SqlParameter("@Action", "InsertBatch");
                param[1] = new SqlParameter("@PID", objentity.Pid);
                param[2] = new SqlParameter("@MFGDate", objentity.Mfgdate);
                param[3] = new SqlParameter("@EXPDate", objentity.Expdate);
                param[6] = new SqlParameter("@BatchName", objentity.Batchname);
                param[7] = new SqlParameter("@BatchCode", objentity.Batchcode);
                param[8] = new SqlParameter("@BatchDesc", objentity.Batchdesc);
                param[9] = new SqlParameter("@DepotID", objentity.Depotid);
                param[10] = new SqlParameter("@RecievedFrom", objentity.Recievedfrom);
                param[4] = new SqlParameter("@IsActive", objentity.Isactive);
                param[5] = new SqlParameter("@Output", SqlDbType.Int);
                param[5].Direction = ParameterDirection.Output;
                param[11] = new SqlParameter("@BatchNo", objentity.Batchno);
                param[12] = new SqlParameter("@ATNo", objentity.ATNo);
                param[13] = new SqlParameter("@VechicleNo", objentity.VechicleNo);
                param[14] = new SqlParameter("@ESL", objentity.Esl);
                param[15] = new SqlParameter("@Stockqty", objentity.Stockqty);
                param[16] = new SqlParameter("@IsProductStatus", objentity.Isproductstatus);
                param[17] = new SqlParameter("@AddedBy", objentity.Addedby);
                param[18] = new SqlParameter("@IsSampleSent", objentity.IsSampleSent);
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spManageStock", param);
                r = Convert.ToInt32(param[5].Value);
                return r;

            }
            catch (Exception)
            {

                throw;
            }


        }


        public int insertdalcstock(ManageStockEntity objentity)
        {
            int r = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[21];
                param[0] = new SqlParameter("@Action", "Insertstock");
                param[1] = new SqlParameter("@Quantity", objentity.Maxquantity);
                param[2] = new SqlParameter("@Quantitytype", objentity.Quantitytype);
                param[3] = new SqlParameter("@IsStockIn", objentity.Isstockin1);
                param[4] = new SqlParameter("@IsActive", objentity.Isactive);
                param[5] = new SqlParameter("@BID", objentity.Bid);
                param[6] = new SqlParameter("@Output", SqlDbType.Int);
                param[6].Direction = ParameterDirection.Output;
                param[7] = new SqlParameter("@Stockqty", objentity.Stockqty);
                param[8] = new SqlParameter("@AddedBy", objentity.Addedby);
                param[9] = new SqlParameter("@SupplierId", objentity.SupplierId);
                param[10] = new SqlParameter("@GenericName", objentity.GenericName);
                param[11] = new SqlParameter("@OriginalManf", objentity.OriginalManf);
                param[12] = new SqlParameter("@SentQty", objentity.SentQty);
                param[13] = new SqlParameter("@RecievedOn", objentity.RecievedOn);
                param[14] = new SqlParameter("@DriverName", objentity.DriverName);
                param[15] = new SqlParameter("@InterTransferId", objentity.InterTransferId);
                param[16] = new SqlParameter("@Remarks", objentity.Remarks);
                param[17] = new SqlParameter("@ChallanOrIrNo", objentity.ChallanOrIrNo);
                param[18] = new SqlParameter("@IsChallanNo", objentity.IsChallanNo);
                param[19] = new SqlParameter("@IsIrNo", objentity.IsIrNo);
                param[20] = new SqlParameter("@PackingMaterial", objentity.PackingMaterial);
               // param[20] = new SqlParameter("@PackingQuantity", objentity.PackingQuantity);
                param[20] = new SqlParameter("@UnitInfo", objentity.UnitInfo);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spManageStock", param);
                r = Convert.ToInt32(param[5].Value);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateBatchDALC(ManageStockEntity objAdminEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[17];
                parm[0] = new SqlParameter("@Action", "Updatebatch");
                parm[1] = new SqlParameter("@BatchName", objAdminEntity.Batchname);
                parm[2] = new SqlParameter("@BatchDesc", objAdminEntity.Batchdesc);
                parm[3] = new SqlParameter("@EXPDate", objAdminEntity.Expdate);
                parm[4] = new SqlParameter("@Isactive", objAdminEntity.Isactive);
                parm[5] = new SqlParameter("@BatchNo", objAdminEntity.Batchno);
                parm[6] = new SqlParameter("@ATNo", objAdminEntity.ATNo);
                parm[7] = new SqlParameter("@VechicleNo", objAdminEntity.VechicleNo);
                parm[8] = new SqlParameter("@BID", objAdminEntity.Bid);
                parm[9] = new SqlParameter("@RecievedFrom", objAdminEntity.Recievedfrom);
                parm[10] = new SqlParameter("@ModifiedBy", objAdminEntity.Modificationby);
                parm[11] = new SqlParameter("@ESL", objAdminEntity.Esl);
                parm[12] = new SqlParameter("@Quantity", objAdminEntity.Maxquantity);
                parm[13] = new SqlParameter("@Quantitytype", objAdminEntity.Quantitytype);
                parm[14] = new SqlParameter("@IsStockIn", objAdminEntity.Isstockin1);
                parm[15] = new SqlParameter("@SID", objAdminEntity.Sid);
                parm[16] = new SqlParameter("@PID", objAdminEntity.Pid);

                //parm[16] = new SqlParameter("@BID", objAdminEntity.Bid);
                //parm[15] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
                //parm[18] = new SqlParameter("@ModifiedBy", objAdminEntity.Modificationby);
                //parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spManageStock", parm);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateStock(ManageStockEntity objentity)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[21];
                param[0] = new SqlParameter("@Action", "UpdateStock");
                param[1] = new SqlParameter("@Quantity", objentity.Maxquantity);
                param[2] = new SqlParameter("@Quantitytype", objentity.Quantitytype);
                param[3] = new SqlParameter("@IsStockIn", objentity.Isstockin1);
                param[4] = new SqlParameter("@IsActive", objentity.Isactive);
                param[5] = new SqlParameter("@BID", objentity.Bid);
                param[6] = new SqlParameter("@SID", objentity.Sid);
                param[7] = new SqlParameter("@ModifiedBy", objentity.Modificationby);

                param[8] = new SqlParameter("@SupplierId", objentity.SupplierId);
                param[9] = new SqlParameter("@GenericName", objentity.GenericName);
                param[10] = new SqlParameter("@OriginalManf", objentity.OriginalManf);
                param[11] = new SqlParameter("@SentQty", objentity.SentQty);
                param[12] = new SqlParameter("@RecievedOn", objentity.RecievedOn);
                param[13] = new SqlParameter("@DriverName", objentity.DriverName);
                param[14] = new SqlParameter("@InterTransferId", objentity.InterTransferId);
                param[15] = new SqlParameter("@Remarks", objentity.Remarks);
                param[16] = new SqlParameter("@ChallanOrIrNo", objentity.ChallanOrIrNo);
                param[17] = new SqlParameter("@IsChallanNo", objentity.IsChallanNo);
                param[18] = new SqlParameter("@IsIrNo", objentity.IsIrNo);
                param[19] = new SqlParameter("@PackingMaterial", objentity.PackingMaterial);
                param[20] = new SqlParameter("@PackingQuantity", objentity.PackingQuantity);
                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spManageStock", param);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DropdowndisplayDALC()
        {
            try
            {
                DataTable dt = new DataTable();

                string str = "  select * from ProductMaster where IsActive=1";
                dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@Action", "DropDisplay");
                //dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spManageStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetProduct(ManageStockEntity objentity)
        {
            try
            {
                DataTable dt = new DataTable();

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", objentity.Action);
                param[1] = new SqlParameter("@Productname", objentity.Productname);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spManageStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string generatebatchcode()
        {
            string bCOde;
            DataTable dt = new DataTable();
            string str = "select BID from BatchMaster where BID=(select max(BID) from  BatchMaster)";
            dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
            if (dt.Rows.Count > 0)
            {
                int BID = Convert.ToInt32(dt.Rows[0]["BID"].ToString());
                BID++;

                bCOde = "BC-" + BID.ToString();

            }
            else
            {
                bCOde = "BC-1";
            }
            return bCOde;



        }

        public DataTable GriddisplayDALC()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "griddisplay");
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spManageStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void UpdateStockDALC(ManageStockEntity objAdminEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@Action", "UpdateStock");
                parm[1] = new SqlParameter("@Quantity", objAdminEntity.Batchcode);
                parm[2] = new SqlParameter("@IsStockIn", objAdminEntity.Batchname);
                parm[3] = new SqlParameter("@Isactive", objAdminEntity.Isactive);
                //  parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spManageStock", parm);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void UpdateStockDALCactive(ManageStockEntity objAdminEntity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "updateactive");
                parm[1] = new SqlParameter("@IsActive", objAdminEntity.Isactive);
                parm[2] = new SqlParameter("@Bid", objAdminEntity.Bid);

                // parm[4] = new SqlParameter("@ImageUrl", objAdminEntity.ImageUrl);
                //  parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

                StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spManageStock", parm);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable DropdowndisplaydepuDALC()
        {
            try
            {
                DataTable dt = new DataTable();

                string str = " select * from depumaster where IsParent=1";
                dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@Action", "DropDisplay");
                //dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spManageStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable SelectRecievedFrom()
        {
            try
            {
                DataTable dt = new DataTable();

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectRecievedFrom");
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spManageStock", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable getEslData(string action)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] parm = new SqlParameter[1];
                parm[0] = new SqlParameter("@Action", action);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "speslstatus",parm);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public DataTable Selectwithid(string action, Int32 ID)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@Action", action);
                parm[1] = new SqlParameter("@ID", ID);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "speslstatus", parm);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable selectcrv(DateTime from, DateTime to)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@fromdate", from);
                param[1] = new SqlParameter("@todate", to);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spselectcrv", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectQuantityType()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectQuantityType");
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "sp_StockTransfer", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Vipan 18/2/2015 Get the qty by Batch ID
        public DataTable GetStockByBatch(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Action", "SelectQty");
                param[1] = new SqlParameter("@Id", id);
                dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spManageBatch", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
