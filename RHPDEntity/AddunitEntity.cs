using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace RHPDEntity
{
    public class AddunitEntity
    {
        private int depu_id;
        public int Depu_id
        {
            get { return depu_id; }
            set { depu_id = value; }
        }

        private string unit_name;
        public string Unit_name
        {
            get { return unit_name; }
            set { unit_name = value; }
        }

        private string unit_desc;

        public string Unit_desc
        {
            get { return unit_desc; }
            set { unit_desc = value; }
        }


        private int unit_id;

        public int Unit_id
        {
            get { return unit_id; }
            set { unit_id = value; }
        }
        private string unit_type;

        public string Unit_type
        {
            get { return unit_type; }
            set { unit_type = value; }
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
        private string unit_code;

        public string Unit_code
        {
            get { return unit_code; }
            set { unit_code = value; }
        }

        private int _Command;
        public int Command
        {
            get { return _Command; }
            set { _Command = value; }
        }
        private int _Formation;
        public int Formation
        {
            get { return _Formation; }
            set { _Formation = value; }
        }
        private int _UnitType;
        public int UnitType
        {
            get { return _UnitType; }
            set { _UnitType = value; }
        }

    }
}
