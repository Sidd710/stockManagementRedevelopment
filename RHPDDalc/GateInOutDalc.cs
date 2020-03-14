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
  public  class GateInOutDalc
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

      public int insertIntoGateInOut(GateInOutEntity objGateInOutEntity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[20];
              param[0] = new SqlParameter("@vehbano", objGateInOutEntity.Vehbano);
              param[1] = new SqlParameter("@franchiseeno", objGateInOutEntity.Franchiseeno);
              param[2] = new SqlParameter("@ArmyNo", objGateInOutEntity.ArmyNo);
              param[3] = new SqlParameter("@Output", SqlDbType.Int);
              param[3].Direction = ParameterDirection.Output;
              param[4] = new SqlParameter("@Action", objGateInOutEntity.Action);
              param[5] = new SqlParameter("@rank", objGateInOutEntity.Rank);
              param[6] = new SqlParameter("@name", objGateInOutEntity.Name);
              param[7] = new SqlParameter("@timein", objGateInOutEntity.Timein);
              param[8] = new SqlParameter("@typeofvehicle", objGateInOutEntity.Typeofvehicle);
              param[9] = new SqlParameter("@unitQuantityTypeId", objGateInOutEntity.UnitQuantityTypeId);
              param[10] = new SqlParameter("@loadin", objGateInOutEntity.Loadin);
              param[11] = new SqlParameter("@IdtId", objGateInOutEntity.IdtId1);
              param[12] = new SqlParameter("@timeout", objGateInOutEntity.Timeout);
              param[13] = new SqlParameter("@loadout", objGateInOutEntity.Loadout);
              param[14] = new SqlParameter("@fuelintankIn", objGateInOutEntity.FuelintankIn);
              param[15] = new SqlParameter("@fuelintankOut", objGateInOutEntity.FuelintankOut);
              param[16] = new SqlParameter("@AddedBy", objGateInOutEntity.AddedBy1);
              param[17] = new SqlParameter("@IsActive", objGateInOutEntity.IsActive);
              param[18] = new SqlParameter("@stationUnitId", objGateInOutEntity.StationUnitId);
              param[19] = new SqlParameter("@ModifiedBy", objGateInOutEntity.ModifiedBy1);
              StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_GateInOut", param);
              r = Convert.ToInt32(param[3].Value);
              return r;
          }



          catch (Exception)
          {

              throw;
          }
      }


      public Int32 UpdateInGateInOut(GateInOutEntity objGateInOutEntity)
      {
          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[20];
              param[0] = new SqlParameter("@vehbano", objGateInOutEntity.Vehbano);
              param[1] = new SqlParameter("@franchiseeno", objGateInOutEntity.Franchiseeno);
              param[2] = new SqlParameter("@ArmyNo", objGateInOutEntity.ArmyNo);
              param[3] = new SqlParameter("@Output", SqlDbType.Int);
              param[3].Direction = ParameterDirection.Output;
              param[4] = new SqlParameter("@Action", objGateInOutEntity.Action);
              param[5] = new SqlParameter("@rank", objGateInOutEntity.Rank);
              param[6] = new SqlParameter("@name", objGateInOutEntity.Name);
              param[7] = new SqlParameter("@timein", objGateInOutEntity.Timein);
              param[8] = new SqlParameter("@typeofvehicle", objGateInOutEntity.Typeofvehicle);
              param[9] = new SqlParameter("@unitQuantityTypeId", objGateInOutEntity.UnitQuantityTypeId);
              param[10] = new SqlParameter("@loadin", objGateInOutEntity.Loadin);
              param[11] = new SqlParameter("@IdtId", objGateInOutEntity.IdtId1);
              param[12] = new SqlParameter("@timeout", objGateInOutEntity.Timeout);
              param[13] = new SqlParameter("@loadout", objGateInOutEntity.Loadout);
              param[14] = new SqlParameter("@fuelintankIn", objGateInOutEntity.FuelintankIn);
              param[15] = new SqlParameter("@fuelintankOut", objGateInOutEntity.FuelintankOut);
              param[16] = new SqlParameter("@ModifiedBy", objGateInOutEntity.ModifiedBy1);
              param[17] = new SqlParameter("@ModifiedOn", objGateInOutEntity.ModifiedOn1);
              param[18] = new SqlParameter("@IsActive", objGateInOutEntity.IsActive);
              param[19] = new SqlParameter("@stationUnitId", objGateInOutEntity.StationUnitId);
              StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_GateInOut", param);
              r = Convert.ToInt32(param[3].Value);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }



      public void InActiveGateInOut(GateInOutEntity objGateInOutEntity)
      {
          try
          {
              SqlParameter[] parm = new SqlParameter[3];
              parm[0] = new SqlParameter("@Action", "InActiveGateInOut");
              parm[1] = new SqlParameter("@IsActive", objGateInOutEntity.IsActive);
              parm[2] = new SqlParameter("@ID", objGateInOutEntity.Id);

              StarHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "sp_GateInOut", parm);

          }
          catch (Exception)
          {

              throw;
          }
      }

      public DataTable SelectId(int Id)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "SelectId");
              param[1] = new SqlParameter("@Id", Id);

              dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_GateInOut", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }

      }
      public DataTable SelectGateOut(GateInOutEntity objGateInOutEntity)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", objGateInOutEntity.Action);
              param[1] = new SqlParameter("@IdtId", objGateInOutEntity.IdtId1);

              dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_GateInOut", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }

      }
      public DataTable SelectallGate(GateInOutEntity objGateInOutEntity)
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Action", objGateInOutEntity.Action);

              dt = StarHelper.ExecuteDataTable(conn, CommandType.StoredProcedure, "sp_GateInOut", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }

      }   


    }
}
