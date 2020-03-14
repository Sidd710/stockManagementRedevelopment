using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
   public class GatEntity
    {
      
  
      private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


         private bool isLoadIn;

         public bool IsLoadIn
         {
          get { return isLoadIn; }
          set { isLoadIn = value; }
        } 



    private string recievedfrom;

    public string Recievedfrom
    {
      get { return recievedfrom; }
      set { recievedfrom = value; }
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
	 
         private string unitQuantityTypeId;

         public string UnitQuantityTypeId
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


        private string IdtId;

        public string IdtId1
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



        private string stationDepuID;

        public string StationDepuID
        {
            get { return stationDepuID; }
            set { stationDepuID = value; }
        }

	 
	 
	 
	    private string stationUnitId;

         public string StationUnitId
        {
            get { return stationUnitId; }
            set { stationUnitId = value; }
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

        private int addedBy;

        public int AddedBy
        {
          get { return addedBy; }
          set { addedBy = value; }
        }


      private DateTime addedOn;

        public DateTime AddedOn
        {
          get { return addedOn; }
          set { addedOn = value; }
        }

        
        private int ModifiedBy;

        public int ModifiedBy1
        {
            get { return ModifiedBy; }
            set { ModifiedBy = value; }
        }

       
       private DateTime ModifiedOn;

       public DateTime ModifiedOn1
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
       
    }
}



 