using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;
namespace RHPDComponent
{
    public class DeptComp
    {

        public int Insert(DeptMasterEntity objentity)
        {
            try
            {
                int r;
                DeptDalc objDal = new DeptDalc();
                r = objDal.Insert(objentity);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(DeptMasterEntity objEntity)
        {
            try
            {
                 DeptDalc objDal = new DeptDalc();
                 objDal.Update(objEntity);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable SelectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                DeptDalc objDal = new DeptDalc();
               return dt= objDal.SelectAll();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable SelectActive()
        {
            try
            {
                DataTable dt = new DataTable();
                DeptDalc objDal = new DeptDalc();
                return dt = objDal.SelectActive();
            }
            catch (Exception)
            {

                throw;
            }
        }
          public string getDeptCode()
        {
            try
            {
                string dCode = "";
                DeptDalc objDal = new DeptDalc();
                return dCode = objDal.getDeptCode();
            }
            catch (Exception)
            {

                throw;
            }
        }
          public int getDeptByRoleID(int roleID)
        {
            try
            {
                
                DeptDalc objDal = new DeptDalc();
                return objDal.getDeptByRoleID(roleID);
            }
            catch (Exception)
            {

                throw;
            }
        }

          public DataTable CheckDept(string st)
          {
              DataTable dt3;

              try
              {
                  DeptDalc objunitdalc = new DeptDalc();
                  dt3 = new DataTable();
                  dt3 = objunitdalc.CheckDept(st);
                  return dt3;
              }
              catch (Exception)
              {

                  throw;
              }
          }
          public DataTable updCheckDept(string st,int id)
          {
              DataTable dt3;

              try
              {
                  DeptDalc objunitdalc = new DeptDalc();
                  dt3 = new DataTable();
                  dt3 = objunitdalc.updCheckDept(st, id);
                  return dt3;
              }
              catch (Exception)
              {

                  throw;
              }
          }

    }
    public class AddroleComp
    {
        public int InsertRole(AddRoleEntity objentity)
        {
            try
            {
                int r;
                AddroleDalc objaddrole = new AddroleDalc();
                r = objaddrole.insertdalc(objentity);
                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }
          public DataTable GetRoleByDeptID(int dID)
        {
            try
            {
                DataTable dt3;
                AddroleDalc objaddrole = new AddroleDalc();
                dt3 = objaddrole.GetRoleByDeptID(dID);
                return dt3;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable GridDisplayComponent()
        {
            try
            {
                DataTable dt3;
                AddroleDalc objaddrole = new AddroleDalc();
                dt3 = objaddrole.GriddisplayDALC();
                return dt3;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void updatecomponent(AddRoleEntity objentity)
        {

            try
            {
               
                AddroleDalc objaddrole = new AddroleDalc();
                objaddrole.UpdateRoleDALC(objentity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveInactivate(AddRoleEntity objentity)
        {

            try
            {

                AddroleDalc objaddrole = new AddroleDalc();
                objaddrole.UpdateRoleDALCactive(objentity);

            }
            catch (Exception)
            {

                throw;
            }
        }
          public string getRoleCode()
        {
            try
            {

                AddroleDalc objaddrole = new AddroleDalc();
                string rCode = objaddrole.getRoleCode();
                return rCode;
            }
            catch (Exception)
            {

                throw;
            }
        }

          public DataTable checkRolename(string st)
          {
              try
              {
                  AddroleDalc objcheckrole = new AddroleDalc();
                  DataTable dt = new DataTable();
                  dt = objcheckrole.checkRolename(st);
                  return dt;
              }
              catch (Exception)
              {
                  
                  throw;
              }
          }
          public DataTable updcheckRolename(string st,int id)
          {
              try
              {
                  AddroleDalc objcheckrole = new AddroleDalc();
                  DataTable dt = new DataTable();
                  dt = objcheckrole.updcheckRolename(st, id);
                  return dt;
              }
              catch (Exception)
              {

                  throw;
              }
          }
    }
}
