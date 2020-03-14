using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;


namespace RHPDComponent
{
   public class GatComponent
    {


        public int GateInfoComponent(GatEntity Obj)
        {
            try
            {
                int r;
                GatInOutDALC ObjDALC = new GatInOutDALC();
                r = ObjDALC.InsertInfoDALC(Obj);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable SelectallGate(GatEntity objentity)
        {
            DataTable dt3;

            try
            {
                GatInOutDALC ObjDALC = new GatInOutDALC();

                dt3 = new DataTable();
                dt3 = ObjDALC.SelectallGate(objentity);
                return dt3;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int GateInInfoComponent(GatEntity Obj)
        {
            try
            {
                int r;
                GatInOutDALC ObjDALC = new GatInOutDALC();
                r = ObjDALC.InsertionByGateIn(Obj);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateGatComponent(GatEntity ObjEntity)
        {
            try
            {
                // int r;
                GatInOutDALC Obj = new GatInOutDALC();
                Obj.UpdateGatDALC(ObjEntity);
                //  return r;

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
                // int r;
                GatInOutDALC Obj = new GatInOutDALC();
                Obj.UpdateByGateIn(ObjEntity);
                // return r;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable SelectAllGatComponent(GatEntity ObjEntity)
        {
            try
            {
                DataTable dt = new DataTable();
                GatInOutDALC ObjDALC = new GatInOutDALC();
                dt = ObjDALC.SelectAllGatDALC(ObjEntity);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable getrecord()
        {
            try
            {
                DataTable dt;
                GatInOutDALC objDepuName = new GatInOutDALC();
                dt = objDepuName.DropdowndisplayDALC();
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

                GatInOutDALC ObjInactive = new GatInOutDALC();
                ObjInactive.Inactive(objentity);

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
               GatInOutDALC ObjDALC = new GatInOutDALC();
               dt = ObjDALC.Selectedgateformto(ObjEntity);
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
               GatInOutDALC ObjDALC = new GatInOutDALC();
               dt = ObjDALC.SelectGatViewDetail(ObjEntity);
               return dt;
           }
           catch (Exception)
           {

               throw;
           }
       }
    }
}
