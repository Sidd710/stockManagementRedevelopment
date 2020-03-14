using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;

namespace RHPDComponent
{
  public  class GateInOutComp
    {

      GateInOutDalc objGateInOutDalc = new GateInOutDalc();

      public int insertIntoGateInOut(GateInOutEntity objGateInOutEntity)
      {
          try
          {
              int r;


              r = objGateInOutDalc.insertIntoGateInOut(objGateInOutEntity);
              return r;
          }
          catch (Exception)
          {

              throw;
          }
      }

      public Int32 UpdateInGateInOut(GateInOutEntity objGateInOutEntity)
      {
          int r;
          try
          {


              r = objGateInOutDalc.UpdateInGateInOut(objGateInOutEntity);
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


              objGateInOutDalc.InActiveGateInOut(objGateInOutEntity);

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

              dt = objGateInOutDalc.SelectId(Id);
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

              dt = objGateInOutDalc.SelectGateOut(objGateInOutEntity);
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

              dt = objGateInOutDalc.SelectallGate(objGateInOutEntity);
              return dt;

          }
          catch (Exception)
          {

              throw;
          }

      }
     
    }
}
