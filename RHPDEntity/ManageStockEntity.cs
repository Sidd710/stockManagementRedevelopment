using System;

namespace RHPDEntity
{
    public class ManageStockEntity
    {
        private int bid;

        public int Bid
        {
            get { return bid; }
            set { bid = value; }
        }

        private int pid;

        public int Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        private DateTime mfgdate;

        public DateTime Mfgdate
        {
            get { return mfgdate; }
            set { mfgdate = value; }
        }
        private DateTime expdate;

        public DateTime Expdate
        {
            get { return expdate; }
            set { expdate = value; }
        }


        private string isproductstatus;

        public string Isproductstatus
        {
            get { return isproductstatus; }
            set { isproductstatus = value; }
        }



        private Double maxquantity;

        public Double Maxquantity
        {
            get { return maxquantity; }
            set { maxquantity = value; }
        }

        private string minquantity;

        public string Minquantity
        {
            get { return minquantity; }
            set { minquantity = value; }
        }

        private int Isstockin;

        public int Isstockin1
        {
            get { return Isstockin; }
            set { Isstockin = value; }
        }

        private int sid;

        public int Sid
        {
            get { return sid; }
            set { sid = value; }
        }
        private string batchname;

        public string Batchname
        {
            get { return batchname; }
            set { batchname = value; }
        }

        private string batchcode;

        public string Batchcode
        {
            get { return batchcode; }
            set { batchcode = value; }
        }

        private string batchdesc;

        public string Batchdesc
        {
            get { return batchdesc; }
            set { batchdesc = value; }
        }

        private string quantitytype;

        public string Quantitytype
        {
            get { return quantitytype; }
            set { quantitytype = value; }
        }

        private int quantitytypeid;

        public int Quantitytypeid
        {
            get { return quantitytypeid; }
            set { quantitytypeid = value; }
        }

        private int addedby;

        public int Addedby
        {
            get { return addedby; }
            set { addedby = value; }
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
        private int modificationby;

        public int Modificationby
        {
            get { return modificationby; }
            set { modificationby = value; }
        }

        private int depotid;

        public int Depotid
        {
            get { return depotid; }
            set { depotid = value; }
        }
        private string recievedfrom;

        public string Recievedfrom
        {
            get { return recievedfrom; }
            set { recievedfrom = value; }
        }
        private string batchno;

        public string Batchno
        {
            get { return batchno; }
            set { batchno = value; }
        }
        private string aTNo;

        public string ATNo
        {
            get { return aTNo; }
            set { aTNo = value; }
        }
        private string vechicleNo;

        public string VechicleNo
        {
            get { return vechicleNo; }
            set { vechicleNo = value; }
        }
        private DateTime esl;

        public DateTime Esl
        {
            get { return esl; }
            set { esl = value; }
        }


        private double stockqty;

        public double Stockqty
        {
            get { return stockqty; }
            set { stockqty = value; }
        }
        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        private string productname;

        public string Productname
        {
            get { return productname; }
            set { productname = value; }
        }
        public int SupplierId { get; set; }
        public string GenericName { get; set; }
        public string OriginalManf { get; set; }
        public double SentQty { get; set; }
        public DateTime RecievedOn { get; set; }
        public string DriverName { get; set; }
        public int InterTransferId { get; set; }
        public string Remarks { get; set; }
        public string ChallanOrIrNo { get; set; }
        public bool IsChallanNo { get; set; }
        public bool IsIrNo { get; set; }
        public string PackingMaterial { get; set; }
        public double PackingQuantity { get; set; }
        public string UnitInfo { get; set; }
        public int IsSampleSent { get; set; }
    }







}
