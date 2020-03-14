using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
    public class ESLIssueEntity
    {
        private int bid;
        public int Bid
        {
            get { return bid; }
            set { bid = value; }
        }
        private int modifiedBy;
        public int ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }
        private int isactive;
        public int IsActive
        {
            get { return isactive; }
            set { isactive = value; }
        }
        private DateTime recieveddate;
        public DateTime Recieveddate
        {
            get { return recieveddate; }
            set { recieveddate = value; }
        }
        private string overallremarks;
        public string Overallremarks
        {
            get { return overallremarks; }
            set { overallremarks = value; }
        }
        private string issueto;
        public string Issueto
        {
            get { return issueto; }
            set { issueto = value; }
        }
        private string quantitytype;
        public string Quantitytype
        {
            get { return quantitytype; }
            set { quantitytype = value; }
        }        
        private string quantity;
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private int statusid;
        public int Statusid
        {
            get { return statusid; }
            set { statusid = value; }
        }
        private string remarksbynurgp;
        public string Remarksbynurgp
        {
            get { return remarksbynurgp; }
            set { remarksbynurgp = value; }
        }
        private string remarksByjcoigp;
        public string RemarksByjcoigp
        {
            get { return remarksByjcoigp; }
            set { remarksByjcoigp = value; }
        }
        private string remarksbydso;
        public string Remarksbydso
        {
            get { return remarksbydso; }
            set { remarksbydso = value; }
        }

        // No references from down here
        private int eslid;

        public int Eslid
        {
            get { return eslid; }
            set { eslid = value; }
        }

        private int productid;

        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }

        private DateTime senton;

        public DateTime Senton
        {
            get { return senton; }
            set { senton = value; }
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
        
        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }       
    }
 
}
