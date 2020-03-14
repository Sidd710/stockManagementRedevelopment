using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;


namespace RHPDComponent
{
  public class AddUserComp
    {
      public DataTable getrecorddepot()
      {
          try
          {
              DataTable dt;
              AddUserDalc getdepot = new AddUserDalc();
              dt = getdepot.GetResultDepot();
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable GetUnitByDID(int DID)
      {
          try
          {
              DataTable dt;
              AddUserDalc getdepot = new AddUserDalc();
              dt = getdepot.GetUnitByDID(DID);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
     

      public int Insert(AdduserEntity objentity)
      {
          try
          {
              int r;
              AddUserDalc objadduser = new AddUserDalc();
              r = objadduser.Insert(objentity);
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
              AddUserDalc objadduser = new AddUserDalc();
             
              dt3 = new DataTable();
              dt3 = objadduser.GriddisplayDALC();
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }


      public void Update(AdduserEntity objentity)
      {
          try
          {

              AddUserDalc objAdduser = new AddUserDalc();
              objAdduser.Update(objentity);

          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectActive()
      {
          DataTable dt3;

          try
          {
              AddUserDalc objadduser = new AddUserDalc();

              dt3 = new DataTable();
              dt3 = objadduser.SelectActive();
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public DataTable SelectAll()
      {
          DataTable dt3;

          try
          {
              AddUserDalc objadduser = new AddUserDalc();

              dt3 = new DataTable();
              dt3 = objadduser.SelectAll();
              return dt3;
          }
          catch (Exception)
          {

              throw;
          }
      }
      public string getUserCode()
      {
          try
          {
              AddUserDalc objadduser = new AddUserDalc();
              string code = objadduser.getUserCode();
              return code;
          }
          catch (Exception)
          {
              
              throw;
          }
      }
        public Boolean IsUserNameExist(string Username) {
            try
            {
                AddUserDalc objadduser = new AddUserDalc();

                return objadduser.IsUserNameExist(Username);
            }
            catch (Exception)
            {

                throw;
            }
        }
       public DataTable getUserToLogin(string Username, string Password)
        {
            DataTable dt3;

            try
            {
                AddUserDalc objadduser = new AddUserDalc();

                dt3 = new DataTable();
                dt3 = objadduser.getUserToLogin( Username,  Password);
                return dt3;
            }
            catch (Exception)
            {

                throw;
            }
        }
      //Address

      public DataTable GetCountryList()
      {
          try
          {
              DataTable dt = new DataTable();
              AddUserDalc objadduser = new AddUserDalc();

              return dt = objadduser.GetCountryList();
          }
          catch (Exception)
          {

              throw;
          }
      }
         public DataTable GetStateByCountryID(int cID)
      {
          try
          {
              DataTable dt = new DataTable();
              AddUserDalc objadduser = new AddUserDalc();

              return dt = objadduser.GetStateByCountryID(cID);
          }
          catch (Exception)
          {

              throw;
          }
      }
        public DataTable GetCityStateID(int sID)
         {
             try
             {
                 DataTable dt = new DataTable();
                 AddUserDalc objadduser = new AddUserDalc();

                 return dt = objadduser.GetCityStateID(sID);
             }
             catch (Exception)
             {

                 throw;
             }
         }
    }
}
