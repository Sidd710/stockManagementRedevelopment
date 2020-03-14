using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
    public class IndentEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string indentName;

        public string IndentName
        {
            get { return indentName; }
            set { indentName = value; }
        }

        private bool isApproved;

        public bool IsApproved
        {
            get { return isApproved; }
            set { isApproved = value; }
        }
        private bool isIssueVoucher;

        public bool IsIssueVoucher
        {
            get { return isIssueVoucher; }
            set { isIssueVoucher = value; }
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
        private int modifiedOn;

        public int ModifiedOn
        {
            get { return modifiedOn; }
            set { modifiedOn = value; }
        }

        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

    }
}
