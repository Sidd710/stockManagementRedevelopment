using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RHPDEntity
{
   public class AddDepuEntity
    {

        public string IDT { get; set; }
        public string ICT { get; set; }
        public string AWS { get; set; } 
        public string UnitName { get; set; }
        private int unit_id;

        public int Unit_id
        {
            get { return unit_id; }
            set { unit_id = value; }
        }

               private int depu_id;
              public int Depu_id
        {
          get { return depu_id; }
          set { depu_id = value; }
        }
        private string depu_name;
   
        public string Depu_name
        {
          get { return depu_name; }
          set { depu_name = value; }
        }

        private string depu_location;
   
   

        public string Depu_location
        {
          get { return depu_location; }
          set { depu_location = value; }
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

        private string depot_code;

        public string Depot_code
        {
            get { return depot_code; }
            set { depot_code = value; }
        }

        private int isparent;

        public int Isparent
        {
            get { return isparent; }
            set { isparent = value; }
        }
        private string status;

        public string Status
        {
          get { return status; }
          set { status = value; }
        }

        private int _FormationId;

        public int FormationId
        {
            get { return _FormationId; }
            set { _FormationId = value; }
        }
        private int _CommandId;

        public int CommandId
        {
            get { return _CommandId; }
            set { _CommandId = value; }
        }

        private string _Corp;
        public string Corp
        {
            get { return _Corp; }
            set { _Corp = value; }
        }
        private string _DepotNo;
        public string DepotNo
        {
            get { return _DepotNo; }
            set { _DepotNo = value; }
        }
   }
}
