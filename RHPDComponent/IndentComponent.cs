using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;


using RHPDEntity;
using System.Data;

namespace RHPDComponent
{


    public class IndentComponent
    {
        // IndentDalc objIndentkDalc = new IndentDalc();

        public int InsertIndentCompo(IndentEntity objIndentEntity)
        {
            int r = 0;
            try
            {
                //int r;
                //  RHPDDalc.IndnetDalc
                IndnetDalc objIndentkDalc = new IndnetDalc();
                r = objIndentkDalc.InsertDalc(objIndentEntity);
                // objIndentkDalc.InsertDalc(objIndentEntity);

                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateIndentCompo(IndentEntity objIndentEntity)
        {
            int r;
            try
            {

                IndnetDalc objUpdateIndentDalc = new IndnetDalc();
                r = objUpdateIndentDalc.UpdateIndentDALC(objIndentEntity);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void ActiveInactivateCategory(IndentEntity objIndentEntity)
        {

            try
            {

                IndnetDalc objInactive = new IndnetDalc();
                objInactive.UpdateIndentDALCinactive(objIndentEntity);

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
                IndnetDalc objIndent = new IndnetDalc();
                dt = objIndent.DropdowndisplayDALC();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectIssueVoucherId()
        {
            try
            {
                DataTable dt;
                IndnetDalc objIndent = new IndnetDalc();
                dt = objIndent.SelectIssueVoucherId();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable SelectGateInoutList()
        {
            try
            {
                DataTable dt;
                IndnetDalc objIndent = new IndnetDalc();
                dt = objIndent.SelectGateInoutList();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetResultIndent()
        {


            try
            {
                DataTable dt; dt = new DataTable();
                IndnetDalc objadduser = new IndnetDalc();
                dt = objadduser.GetResultIndent();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable GetResultIndentdetails(int indetntid)
        {


            try
            {
                DataTable dt; dt = new DataTable();
                IndnetDalc objadduser = new IndnetDalc();
                dt = objadduser.GetResultIndentdetails(indetntid);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateIndent(IndentEntity objEntity)
        {
          
            try
            {

                IndnetDalc objaddpro = new IndnetDalc();
                objaddpro.UpdateIndent(objEntity);
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable checkIsapproved(int indetntid)
        {
            try
            {
                DataTable dt=new DataTable();
                IndnetDalc objaddpro = new IndnetDalc();
                dt = objaddpro.checkIsapproved(indetntid);
                return dt;

            }
            catch (Exception)
            {

                throw;
            }

        }   
    }



           
}
