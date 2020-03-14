using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
   public class IssueVocuherEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private int idtId;

        public int IdtId
        {
            get { return idtId; }
            set { idtId = value; }
        }

        private int toDepuId;

        public int ToDepuId
        {
            get { return toDepuId; }
            set { toDepuId = value; }
        }

        private int toUnitId;

        public int ToUnitId
        {
            get { return toUnitId; }
            set { toUnitId = value; }
        }

        private string vechileNo;

        public string VechileNo
        {
            get { return vechileNo; }
            set { vechileNo = value; }
        }

        private string authority;

        public string Authority
        {
            get { return authority; }
            set { authority = value; }
        }

        private string through;

        public string Through
        {
            get { return through; }
            set { through = value; }
        }


        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        private int addedBy;

        public int AddedBy
        {
            get { return addedBy; }
            set { addedBy = value; }
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
        private DateTime modifiedon;

        public DateTime Modifiedon
        {
            get { return modifiedon; }
            set { modifiedon = value; }
        }
        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }
    }
}
