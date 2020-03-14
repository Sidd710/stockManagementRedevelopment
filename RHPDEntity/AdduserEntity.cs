using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RHPDEntity
{
   public class AdduserEntity
    {
        private int user_id;

        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private string user_name;

        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }


        private int roleId;

        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        


        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int country;

        public int Country
        {
            get { return country; }
            set { country = value; }
        }
        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }
        private int city;

        public int City
        {
            get { return city; }
            set { city = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string contactNo;

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }
        private int isactive;
        public int IsActive
        {
            get { return isactive; }
            set { isactive = value; }
        }

        private DateTime modifiedon;

        public DateTime Modifiedon
        {
            get { return modifiedon; }
            set { modifiedon = value; }
        }

        private DateTime addedon;


        public DateTime Addedon
        {
            get { return addedon; }
            set { addedon = value; }
        }
        private int addedBy;

        public int AddedBy
        {
            get { return addedBy; }
            set { addedBy = value; }
        }
        private int modifiedBy;

        public int ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }
        private string userCode;

        public string UserCode
        {
            get { return userCode; }
            set { userCode = value; }
        }

        private string _ArmyNo;

        public string ArmyNo
        {
            get { return _ArmyNo; }
            set { _ArmyNo = value; }
        }

        private DateTime _StartDate;

        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        private DateTime _EndDate;

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
    }


}
