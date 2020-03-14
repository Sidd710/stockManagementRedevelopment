using RHPDDalc;
using RHPDEntity;
using System;
using System.Data;

namespace RHPDComponent
{
    public class ManagestockComp
    {
        public int Insertproduct(ManageStockEntity objentity)
        {
            try
            {
                int r;
                ManagestockDalc objmsd = new ManagestockDalc();

                r = objmsd.insertdalc(objentity);
                return r;
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
                ManagestockDalc objmsd = new ManagestockDalc();
                dt = objmsd.DropdowndisplayDALC();
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
                DataTable dt;
                ManagestockDalc objmsd = new ManagestockDalc();
                dt = objmsd.GetProduct(objentity);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insertproductinstock(ManageStockEntity objentity)
        {
            try
            {
                int r;
                ManagestockDalc objmsd = new ManagestockDalc();

                r = objmsd.insertdalcstock(objentity);
                return r;
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
                ManagestockDalc objmsd = new ManagestockDalc();

                objmsd.UpdateStock(objentity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string getCode()
        {
            try
            {
                ManagestockDalc objmsd = new ManagestockDalc();
                string code = objmsd.generatebatchcode();
                return code;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable GridDisplayComponent()
        {
            DataTable dt3;

            try
            {
                ManagestockDalc objmanagestock = new ManagestockDalc();

                dt3 = new DataTable();
                dt3 = objmanagestock.GriddisplayDALC();
                return dt3;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void updatebatchComponent(ManageStockEntity objentity)
        {
            try
            {

                ManagestockDalc objAddbatch = new ManagestockDalc();
                objAddbatch.UpdateBatchDALC(objentity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void updateStockComponent(ManageStockEntity objentity)
        {
            try
            {

                ManagestockDalc objAddstock = new ManagestockDalc();
                objAddstock.UpdateStockDALC(objentity);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void updateStockComponentactive(ManageStockEntity objentity)
        {
            try
            {

                ManagestockDalc objactive = new ManagestockDalc();
                objactive.UpdateStockDALCactive(objentity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable getrecorddepu()
        {
            try
            {
                DataTable dt;
                ManagestockDalc objmsd = new ManagestockDalc();
                dt = objmsd.DropdowndisplaydepuDALC();
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
                DataTable dt;
                ManagestockDalc objmsd = new ManagestockDalc();
                dt = objmsd.SelectRecievedFrom();
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
                DataTable dt;
                ManagestockDalc objmsd = new ManagestockDalc();
                dt = objmsd.getEslData(action);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Selectwithid(string action, Int32 id)
        {
            try
            {
                DataTable dt;
                ManagestockDalc objmsd = new ManagestockDalc();
                dt = objmsd.Selectwithid(action, id);
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
                DataTable dt;
                ManagestockDalc objmsd = new ManagestockDalc();
                dt = objmsd.selectcrv(from, to);
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
                DataTable dt;
                ManagestockDalc objcategorytype = new ManagestockDalc();
                dt = objcategorytype.SelectQuantityType();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetStockByBatch(int id)
        {
            try
            {
                DataTable dt;
                ManagestockDalc objcategorytype = new ManagestockDalc();
                dt = objcategorytype.GetStockByBatch(id);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }



}
