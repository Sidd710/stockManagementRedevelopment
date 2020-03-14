using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;
//using BusinessEntity;


namespace RHPDComponent
{
    public class AddUnitComp
    {
        public DataTable getrecord()
        {
            try
            {
                DataTable dt;
                AddunitDalc objunit = new AddunitDalc();
                dt = objunit.DropdowndisplayDALC();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertUnit(AddunitEntity objentity)
        {
            try
            {
                int r;
                AddunitDalc objaddunit = new AddunitDalc();

                r = objaddunit.insertdalc(objentity);
                return r;
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
                AddunitDalc objunitdalc = new AddunitDalc();
                dt3 = new DataTable();
                dt3 = objunitdalc.GriddisplayDALC();
                return dt3;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void updateComponent(AddunitEntity objentity)
        {
            try
            {

                AddunitDalc objAddunit = new AddunitDalc();
                objAddunit.UpdateUnitCAteDALC(objentity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveInactivate(AddunitEntity objentity)
        {

            try
            {

                AddunitDalc objaddunit = new AddunitDalc();
                objaddunit.UpdateUnitDALCactive(objentity);

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
                AddunitDalc objaddunit = new AddunitDalc();
                string code = objaddunit.generateProductcode();
                return code;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable UnitCheckExist(string st, int depuid)
        {
            DataTable dt3;

            try
            {
                AddunitDalc objunitdalc = new AddunitDalc();
                dt3 = new DataTable();
                dt3 = objunitdalc.UnitCheckExist(st, depuid);
                return dt3;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable updUnitCheckExist(string st, int depuid,int id)
        {
            DataTable dt3;

            try
            {
                AddunitDalc objunitdalc = new AddunitDalc();
                dt3 = new DataTable();
                dt3 = objunitdalc.updUnitCheckExist(st, depuid, id);
                return dt3;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
