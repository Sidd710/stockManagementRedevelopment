using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using RHPDEntity;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using StarMethods;

namespace RHPDDalc
{
  public  class AddUserDalc
    {
      SqlConnection con =new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
      SqlCommand cmd = new SqlCommand();
      AdduserEntity objadduser = new AdduserEntity();



      public DataTable GetResultDepot()
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Action", "GetDepot");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUser", param);
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
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[2];
              param[0] = new SqlParameter("@Action", "GetUnitByDID");
              param[1] = new SqlParameter("@Depu_Id", DID);
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUser", param);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }

     
      public int Insert( AdduserEntity objentity)
      {

          int r = 0;
          try
          {
              SqlParameter[] param = new SqlParameter[18];
              param[0] = new SqlParameter("@Action", "Insert");
              param[1] = new SqlParameter("@AddedBy", objentity.AddedBy);
              param[2] = new SqlParameter("@Address", objentity.Address);
              param[9] = new SqlParameter("@City", objentity.City);
              param[3] = new SqlParameter("@ContactNo", objentity.ContactNo);
              param[4] = new SqlParameter("@Country", objentity.Country);
              param[5] = new SqlParameter("@FirstName", objentity.FirstName);
              param[6] = new SqlParameter("@IsActive", objentity.IsActive);
              param[7] = new SqlParameter("@LastName", objentity.LastName);
              param[10] = new SqlParameter("@Password", objentity.Password);
              param[11] = new SqlParameter("@RoleId", objentity.RoleId);
              param[12] = new SqlParameter("@State", objentity.State);
              param[13] = new SqlParameter("@User_name", objentity.User_name);
              param[14] = new SqlParameter("@UserCode", objentity.UserCode);

              param[15] = new SqlParameter("@ArmyNo", objentity.ArmyNo);
              param[16] = new SqlParameter("@StartDate", objentity.StartDate);
              param[17] = new SqlParameter("@EndDate", objentity.EndDate);
              param[8] = new SqlParameter("@Output", SqlDbType.Int);
              param[8].Direction = ParameterDirection.Output;
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUser", param);
              r = Convert.ToInt32(param[8].Value);
              return r;
          }



          catch (Exception)
          {

              throw;
          }
      }

      public DataTable GriddisplayDALC()
      {
          try
          {
              DataTable dt = new DataTable();
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Action", "datadisplay");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUser", param);
              return dt;
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
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Action", "SelectAll");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUser", param);
              return dt;
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
              SqlParameter[] param = new SqlParameter[1];
              param[0] = new SqlParameter("@Action", "SelectActive");
              dt = StarHelper.ExecuteDataTable(con, CommandType.StoredProcedure, "spUser", param);
              return dt;
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
              SqlParameter[] param = new SqlParameter[18];
              param[0] = new SqlParameter("@Action", "Update");
              param[1] = new SqlParameter("@ModifiedBy", objentity.ModifiedBy);
              param[2] = new SqlParameter("@Address", objentity.Address);
              param[8] = new SqlParameter("@City", objentity.City);
              param[3] = new SqlParameter("@ContactNo", objentity.ContactNo);
              param[4] = new SqlParameter("@Country", objentity.Country);
              param[5] = new SqlParameter("@FirstName", objentity.FirstName);
              param[6] = new SqlParameter("@IsActive", objentity.IsActive);
              param[7] = new SqlParameter("@LastName", objentity.LastName);
              param[9] = new SqlParameter("@Password", objentity.Password);
              param[10] = new SqlParameter("@RoleId", objentity.RoleId);
              param[12] = new SqlParameter("@State", objentity.State);
              param[13] = new SqlParameter("@User_name", objentity.User_name);
              param[14] = new SqlParameter("@User_id", objentity.User_id);
              param[15] = new SqlParameter("@ArmyNo", objentity.ArmyNo);
              param[16] = new SqlParameter("@StartDate", objentity.StartDate);
              param[17] = new SqlParameter("@EndDate", objentity.EndDate);
              param[11] = new SqlParameter("@UserCode", objentity.UserCode);
              StarHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spUser", param);

          }
          catch (Exception)
          {

              throw;
          }
      }

      public string getUserCode()
      {
          string uCOde;
          DataTable dt = new DataTable();
          string str = "select User_Id from UserMaster where User_Id=(select max(User_Id) from  UserMaster)";
          dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
          if (dt.Rows.Count > 0)
          {
              int uID = Convert.ToInt32(dt.Rows[0]["User_Id"].ToString());
              uID++;

              uCOde = "UC-" + uID.ToString();

          }
          else
          {
              uCOde = "UC-1";
          }
          return uCOde;



      }

      public Boolean IsUserNameExist(string Username) {
          try
          {
              
          DataTable dt = new DataTable();
          string str = "Select user_name from usermaster where user_name='"+Username+"'";
          dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
          if (dt.Rows.Count > 0)
          {
              return true;

          }
          else
          {
              return false ;
              
          }
        

          }
          catch (Exception)
          {
              
              throw;
          }
      }
      public DataTable getUserToLogin(string Username, string Password)
      {
          try
          {

              DataTable dt = new DataTable();
              string str = "Select us.*,RM.Role from usermaster us inner join RoleMaster RM on RM.Role_ID=us.RoleId where us.user_name='" + Username + "' and us.Password='" + Password + "' and us.IsActive=1";
              dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
              return dt;

          }
          catch (Exception)
          {

              throw;
          }
      }
      //Adress

      public DataTable GetCountryList()
      {
          try
          {
              DataTable dt = new DataTable();
              string str = "   select * from CountryMaster where IsActive=1";
              dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
              return dt;
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
              string str = "select * from StatesMaster where IsActive=1 and CountryID="+cID;
              dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
              return dt;
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
              string str = "select * from CityMaster where IsActive=1 and StateID=" + sID;
              dt = StarHelper.ExecuteDataTable(con, CommandType.Text, str);
              return dt;
          }
          catch (Exception)
          {

              throw;
          }
      }
  //Address ENd
  
  
  }

      
   
}
