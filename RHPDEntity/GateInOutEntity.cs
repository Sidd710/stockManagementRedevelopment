using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
  public  class GateInOutEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string vehbano;

        public string Vehbano
        {
            get { return vehbano; }
            set { vehbano = value; }
        }

        private string franchiseeno;

        public string Franchiseeno
        {
            get { return franchiseeno; }
            set { franchiseeno = value; }
        }

        private string armyNo;

        public string ArmyNo
        {
            get { return armyNo; }
            set { armyNo = value; }
        }

        private string rank;

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime timein;

        public DateTime Timein
        {
            get { return timein; }
            set { timein = value; }
        }
        private string typeofvehicle;

        public string Typeofvehicle
        {
            get { return typeofvehicle; }
            set { typeofvehicle = value; }
        }

        private int unitQuantityTypeId;

        public int UnitQuantityTypeId
        {
            get { return unitQuantityTypeId; }
            set { unitQuantityTypeId = value; }
        }

        private string loadin;

        public string Loadin
        {
            get { return loadin; }
            set { loadin = value; }
        }

        private int IdtId;

        public int IdtId1
        {
            get { return IdtId; }
            set { IdtId = value; }
        }

        private DateTime timeout;

        public DateTime Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        private string loadout;

        public string Loadout
        {
            get { return loadout; }
            set { loadout = value; }
        }

        private int stationDepuID;

        public int StationDepuID
        {
            get { return stationDepuID; }
            set { stationDepuID = value; }
        }

        

        private string fuelintankIn;

        public string FuelintankIn
        {
            get { return fuelintankIn; }
            set { fuelintankIn = value; }
        }

        private string fuelintankOut;

        public string FuelintankOut
        {
            get { return fuelintankOut; }
            set { fuelintankOut = value; }
        }

        private int AddedBy;

        public int AddedBy1
        {
            get { return AddedBy; }
            set { AddedBy = value; }
        }

        private int ModifiedBy;

        public int ModifiedBy1
        {
            get { return ModifiedBy; }
            set { ModifiedBy = value; }
        }

        private int ModifiedOn;

        public int ModifiedOn1
        {
            get { return ModifiedOn; }
            set { ModifiedOn = value; }
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

        private int stationUnitId;

        public int StationUnitId
        {
            get { return stationUnitId; }
            set { stationUnitId = value; }
        }
    }
}
