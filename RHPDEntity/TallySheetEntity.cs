using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
    public class TallySheetEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int depuIdFrom;

        public int DepuIdFrom
        {
            get { return depuIdFrom; }
            set { depuIdFrom = value; }
        }

        private int toDepuId;

        public int ToDepuId
        {
            get { return toDepuId; }
            set { toDepuId = value; }
        }

        private int unitIdFrom;

        public int UnitIdFrom
        {
            get { return unitIdFrom; }
            set { unitIdFrom = value; }
        }


        private int toUnitId;

        public int ToUnitId
        {
            get { return toUnitId; }
            set { toUnitId = value; }
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

        private string vehBaNo;

        public string VehBaNo
        {
            get { return vehBaNo; }
            set { vehBaNo = value; }
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

        private DateTime modifiedOn;

        public DateTime ModifiedOn
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

        private int idtId;

        public int IdtId
        {
            get { return idtId; }
            set { idtId = value; }
        }
        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }
    }
}
