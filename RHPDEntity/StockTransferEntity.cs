using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
   public class StockTransferEntity
    {
       private int ID;

        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }

        private int DepuMasterID;

        public int DepuMasterID1
        {
            get { return DepuMasterID; }
            set { DepuMasterID = value; }
        }

        private bool IsUnit;

        public bool IsUnit1
        {
            get { return IsUnit; }
            set { IsUnit = value; }
        }

        private int UnitMasterID;

        public int UnitMasterID1
        {
            get { return UnitMasterID; }
            set { UnitMasterID = value; }
        }

        private int CategoryMasterID;

        public int CategoryMasterID1
        {
            get { return CategoryMasterID; }
            set { CategoryMasterID = value; }
        }

        private int ProductMasterID;

        public int ProductMasterID1
        {
            get { return ProductMasterID; }
            set { ProductMasterID = value; }
        }

        private float QtyIssued;

        public float QtyIssued1
        {
            get { return QtyIssued; }
            set { QtyIssued = value; }
        }
        private float stockQty;
        public float StockQty
        {
            get { return stockQty; }
            set { stockQty = value; }
        }
        private int AddedBy;

        public int AddedBy1
        {
            get { return AddedBy; }
            set { AddedBy = value; }
        }
        private bool IsActive;

        public bool IsActive1
        {
            get { return IsActive; }
            set { IsActive = value; }
        }


        private int productid;

        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }

        private int CategoryTypeId;

        public int CategoryTypeId1
        {
            get { return CategoryTypeId; }
            set { CategoryTypeId = value; }
        }
        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        private string xmldata;

        public string Xmldata
        {
            get { return xmldata; }
            set { xmldata = value; }
        }
        private int typeOfOrderId;

        public int TypeOfOrderId
        {
            get { return typeOfOrderId; }
            set { typeOfOrderId = value; }
        }
        private int indentId;

        public int IndentId
        {
            get { return indentId; }
            set { indentId = value; }
        }
        private int modifiedBy;

        public int ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }
        private int batchMasterId;

        public int BatchMasterId
        {
            get { return batchMasterId; }
            set { batchMasterId = value; }
        }
        private float issueQty;

        public float IssueQty
        {
            get { return issueQty; }
            set { issueQty = value; }
        }
    }
}
