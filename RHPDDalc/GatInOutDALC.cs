using RHPDEntity;
using StarMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RHPDDalc
{
   public class GatInOutDALC
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();




        public DataTable SelectallGate(GatEntity objentity)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", objentity.Action);
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_Gat", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int InsertInfoDALC(GatEntity ObjENtity)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[17];
                int r;
                param[0] = new SqlParameter("@Action", "Insert");
                //param[1] = new SqlParameter("@IsLoadIn", ObjENtity.IsLoadIn);
                //param[2] = new SqlParameter("@Recievedfrom", ObjENtity.Recievedfrom);
                param[1] = new SqlParameter("@vehbano", ObjENtity.Vehbano);

                param[2] = new SqlParameter("@ArmyNo", ObjENtity.ArmyNo);
                param[3] = new SqlParameter("@rank", ObjENtity.Rank);
                param[4] = new SqlParameter("@name", ObjENtity.Name);
                param[5] = new SqlParameter("@timein", ObjENtity.Timein);
                param[6] = new SqlParameter("@typeofvehicle", ObjENtity.Typeofvehicle);
                param[7] = new SqlParameter("@unitQuantityTypeId", ObjENtity.UnitQuantityTypeId);

                //  param[11] = new SqlParameter("@loadin", ObjENtity.Loadin);
                param[8] = new SqlParameter("@loadout", ObjENtity.Loadout);
                param[9] = new SqlParameter("@timeout", ObjENtity.Timeout);

                param[10] = new SqlParameter("@stationDepuID", ObjENtity.StationDepuID);
                // param[11] = new SqlParameter("@stationUnitId", ObjENtity.StationUnitId);
                param[11] = new SqlParameter("@fuelintankIn", ObjENtity.FuelintankIn);
                param[12] = new SqlParameter("@fuelintankOut", ObjENtity.FuelintankOut);
                param[13] = new SqlParameter("@AddedBy", ObjENtity.AddedBy);
                param[14] = new SqlParameter("@IsActive", ObjENtity.IsActive);
                param[15] = new SqlParameter("@IdtId", ObjENtity.IdtId1);
                param[16] = new SqlParameter("@IsLoadIn", ObjENtity.IsLoadIn);
                // param[21] = new SqlParameter("@AddedBy", ObjENtity.AddedBy);
                r = StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_Gat", param);
                return r;

            }
            catch (Exception)
            {

                throw;
            }
        }



        public int InsertionByGateIn(GatEntity ObjENtity)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                int r;
                param[0] = new SqlParameter("@Action", "InsertionByGateIn");
                param[1] = new SqlParameter("@IsLoadIn", ObjENtity.IsLoadIn);
                param[2] = new SqlParameter("@Recievedfrom", ObjENtity.Recievedfrom);
                param[3] = new SqlParameter("@vehbano", ObjENtity.Vehbano);

                param[4] = new SqlParameter("@ArmyNo", ObjENtity.ArmyNo);
                param[5] = new SqlParameter("@rank", ObjENtity.Rank);
                param[6] = new SqlParameter("@name", ObjENtity.Name);
                param[7] = new SqlParameter("@timein", ObjENtity.Timein);
                param[8] = new SqlParameter("@typeofvehicle", ObjENtity.Typeofvehicle);
                param[9] = new SqlParameter("@unitQuantityTypeId", ObjENtity.UnitQuantityTypeId);

                //  param[11] = new SqlParameter("@loadin", ObjENtity.Loadin);
                param[10] = new SqlParameter("@loadin", ObjENtity.Loadin);
                param[11] = new SqlParameter("@timeout", ObjENtity.Timeout);

                param[12] = new SqlParameter("@stationDepuID", ObjENtity.StationDepuID);
                // param[11] = new SqlParameter("@stationUnitId", ObjENtity.StationUnitId);
                param[13] = new SqlParameter("@fuelintankIn", ObjENtity.FuelintankIn);
                param[14] = new SqlParameter("@fuelintankOut", ObjENtity.FuelintankOut);
                param[15] = new SqlParameter("@AddedBy", ObjENtity.AddedBy);
                param[16] = new SqlParameter("@IsActive", ObjENtity.IsActive);
                param[17] = new SqlParameter("@IdtId", ObjENtity.IdtId1);

                // param[21] = new SqlParameter("@AddedBy", ObjENtity.AddedBy);
                r = StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_Gat", param);
                return r;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void UpdateGatDALC(GatEntity ObjEntity)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                //    int r;
                param[0] = new SqlParameter("@Action", "Update");
                //param[1] = new SqlParameter("@IsLoadIn", ObjENtity.IsLoadIn);
                //param[2] = new SqlParameter("@Recievedfrom", ObjENtity.Recievedfrom);
                param[1] = new SqlParameter("@vehbano", ObjEntity.Vehbano);

                param[2] = new SqlParameter("@ArmyNo", ObjEntity.ArmyNo);
                param[3] = new SqlParameter("@rank", ObjEntity.Rank);
                param[4] = new SqlParameter("@name", ObjEntity.Name);
                param[5] = new SqlParameter("@timein", ObjEntity.Timein);
                param[6] = new SqlParameter("@typeofvehicle", ObjEntity.Typeofvehicle);
                param[7] = new SqlParameter("@unitQuantityTypeId", ObjEntity.UnitQuantityTypeId);

                //  param[11] = new SqlParameter("@loadin", ObjENtity.Loadin);
                param[8] = new SqlParameter("@loadout", ObjEntity.Loadout);
                param[9] = new SqlParameter("@timeout", ObjEntity.Timeout);

                param[10] = new SqlParameter("@stationDepuID", ObjEntity.StationDepuID);
                // param[11] = new SqlParameter("@stationUnitId", ObjENtity.StationUnitId);
                param[11] = new SqlParameter("@fuelintankIn", ObjEntity.FuelintankIn);
                param[12] = new SqlParameter("@fuelintankOut", ObjEntity.FuelintankOut);
                param[13] = new SqlParameter("@AddedBy", ObjEntity.AddedBy);
                param[14] = new SqlParameter("@IsActive", ObjEntity.IsActive);
                param[15] = new SqlParameter("@IdtId", ObjEntity.IdtId1);
                param[16] = new SqlParameter("@IsLoadIn", ObjEntity.IsLoadIn);
                param[17] = new SqlParameter("@Id", ObjEntity.Id);
                // param[21] = new SqlParameter("@AddedBy", ObjENtity.AddedBy);
                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_Gat", param);
                //return r;

            }
            catch (Exception)
            {

                throw;
            }
        }



        public void UpdateByGateIn(GatEntity ObjEntity)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[19];

                param[0] = new SqlParameter("@Action", "UpdateByGateIn");
                param[1] = new SqlParameter("@IsLoadIn", ObjEntity.IsLoadIn);
                param[2] = new SqlParameter("@Recievedfrom", ObjEntity.Recievedfrom);
                param[3] = new SqlParameter("@vehbano", ObjEntity.Vehbano);

                param[4] = new SqlParameter("@ArmyNo", ObjEntity.ArmyNo);
                param[5] = new SqlParameter("@rank", ObjEntity.Rank);
                param[6] = new SqlParameter("@name", ObjEntity.Name);
                param[7] = new SqlParameter("@timein", ObjEntity.Timein);
                param[8] = new SqlParameter("@typeofvehicle", ObjEntity.Typeofvehicle);
                param[9] = new SqlParameter("@unitQuantityTypeId", ObjEntity.UnitQuantityTypeId);

                //  param[11] = new SqlParameter("@loadin", ObjENtity.Loadin);
                param[10] = new SqlParameter("@loadin", ObjEntity.Loadin);
                param[11] = new SqlParameter("@timeout", ObjEntity.Timeout);

                param[12] = new SqlParameter("@stationDepuID", ObjEntity.StationDepuID);
                // param[11] = new SqlParameter("@stationUnitId", ObjENtity.StationUnitId);
                param[13] = new SqlParameter("@fuelintankIn", ObjEntity.FuelintankIn);
                param[14] = new SqlParameter("@fuelintankOut", ObjEntity.FuelintankOut);
                param[15] = new SqlParameter("@AddedBy", ObjEntity.AddedBy);
                param[16] = new SqlParameter("@IsActive", ObjEntity.IsActive);
                param[17] = new SqlParameter("@IdtId", ObjEntity.IdtId1);
                param[18] = new SqlParameter("@Id", ObjEntity.Id);
                // param[21] = new SqlParameter("@AddedBy", ObjENtity.AddedBy);
                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_Gat", param);


            }
            catch (Exception)
            {

                throw;
            }
        }



        public DataTable SelectAllGatDALC(GatEntity ObjEntity)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "Selectall");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_Gat", param);
                return dt;

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
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Action", "SelectDepot");
                dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_Gat", param);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Inactive(GatEntity objentity)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Action", "Inactive");
                parm[1] = new SqlParameter("@IsActive", objentity.IsActive);
                parm[2] = new SqlParameter("@Id", objentity.Id);

                // parm[4] = new SqlParameter("@ImageUrl", objAdminEntity.ImageUrl);
                //  parm[3] = new SqlParameter("@CategoryName", ObjVRMEntity.CategoryName);

                StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_Gat", parm);

            }
            catch (Exception)
            {

                throw;
            }
        }

       public DataTable Selectedgateformto(GatEntity ObjEntity)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[3];
               param[0] = new SqlParameter("@Action", ObjEntity.Action);
               param[1] = new SqlParameter("@from", ObjEntity.AddedOn);
               param[2] = new SqlParameter("@to", ObjEntity.ModifiedOn1);
               dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_Gat", param);
               return dt;
           }
           catch (Exception)
           {
               throw;
           }
       }
       public DataTable SelectGatViewDetail(GatEntity ObjEntity)
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] param = new SqlParameter[2];
               param[0] = new SqlParameter("@Action", ObjEntity.Action);
               param[1] = new SqlParameter("@Id", ObjEntity.Id);
               dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_Gat", param);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
    }
}
