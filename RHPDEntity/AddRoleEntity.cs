using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RHPDEntity
{
    public class DeptMasterEntity
    {
        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string deptName;

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }
        private string deptCode;
        public string DeptCode
{
  get { return deptCode; }
  set { deptCode = value; }
}
        private string description; 

public string Description
{
  get { return description; }
  set { description = value; }
}

private DateTime addedOn;

public DateTime AddedOn
{
    get { return addedOn; }
    set { addedOn = value; }
}

private int addedBy;

public int AddedBy
{
    get { return addedBy; }
    set { addedBy = value; }
}

private int modifiedby;

public int Modifiedby
{
    get { return modifiedby; }
    set { modifiedby = value; }
}

private int isActive;

public int IsActive
{
    get { return isActive; }
    set { isActive = value; }
}
    
    }
   public class AddRoleEntity
    {
        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        private int deptId;

        public int DeptId
        {
            get { return deptId; }
            set { deptId = value; }
        }
        private int rank;

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
       private int role_id;
       public int Role_id
{
  get { return role_id; }
  set { role_id = value; }
}

private string role_code;

public string Role_code
{
    get { return role_code; }
    set { role_code = value; }
}

private string role_desc;

public string Role_desc
{
    get { return role_desc; }
    set { role_desc = value; }
}


private int isactive;
public int Isactive
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
private int modifiedBy;

public int ModifiedBy
{
    get { return modifiedBy; }
    set { modifiedBy = value; }
}
private int addedBy;

public int AddedBy
{
    get { return addedBy; }
    set { addedBy = value; }
}
   }
}
