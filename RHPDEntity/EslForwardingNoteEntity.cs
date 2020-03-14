using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RHPDEntity
{
    public class EslForwardingNoteEntity
    {
        private int batchId;
        public int BatchId
        {
            get { return batchId; }
            set { batchId = value; }
        }
        private string forwardingNoteNumber;
        public string ForwardingNoteNumber
        {
            get { return forwardingNoteNumber; }
            set { forwardingNoteNumber = value; }
        }
        private DateTime forwardNoteDate;
        public DateTime ForwardNoteDate
        {
            get { return forwardNoteDate; }
            set { forwardNoteDate = value; }
        }
        private string officerDesignation;
        public string OfficerDesignation
        {
            get { return officerDesignation; }
            set { officerDesignation = value; }
        }
        private string officerPostalAddress;

        private string atNoReferences;

        public string AtNoReferences
        {
            get { return atNoReferences; }
            set { atNoReferences = value; }
        }
        
        public string OfficerPostalAddress
        {
            get { return officerPostalAddress; }
            set { officerPostalAddress = value; }
        }
        private string addressee;

        public string Adderessee
        {
            get { return addressee; }
            set { addressee = value; }
        }
        private string nomenStore;

        public string NomenStore
        {
            get { return nomenStore; }
            set { nomenStore = value; }
        }
        private string containerType;

        public string ContainerType
        {
            get { return containerType; }
            set { containerType = value; }
        }
        private string sampleRefNumber;

        public string SampleRefNumber
        {
            get { return sampleRefNumber; }
            set { sampleRefNumber = value; }
        }
        private string sampleIdentificationMarks;

        public string SampleIndetityMarks
        {
            get { return sampleIdentificationMarks; }
            set { sampleIdentificationMarks = value; }
        }
        private decimal sampleQualtity;

        public decimal SampleQuantity
        {
            get { return sampleQualtity; }
            set { sampleQualtity = value; }
        }

        private int numberOfSamples;

        public int SampleNumbers
        {
            get { return numberOfSamples; }
            set { numberOfSamples = value; }
        }
        private string sampleType;

        public string SampleType
        {
            get { return sampleType; }
            set { sampleType = value; }
        }
        private DateTime dispatchDate;

        public DateTime DispatchDate
        {
            get { return dispatchDate; }
            set { dispatchDate = value; }
        }
        private string dispatchMethod;

        public string DispatchMethod
        {
            get { return dispatchMethod; }
            set { dispatchMethod = value; }
        }
        private DateTime sampleDrawnDate;

        public DateTime SampleDrawnDate
        {
            get { return sampleDrawnDate; }
            set { sampleDrawnDate = value; }
        }
        private string drawerNameAndRank;

        public string DrawerNameAndRank
        {
            get { return drawerNameAndRank; }
            set { drawerNameAndRank = value; }
        }
        private decimal quantityRepressntedBySample;

        public decimal QuantityRepressntedBySample
        {
            get { return quantityRepressntedBySample; }
            set { quantityRepressntedBySample = value; }
        }

        private string intendedDestination;

        public string IntendedDestination
        {
            get { return intendedDestination; }
            set { intendedDestination = value; }
        }
        private DateTime fillingDate;

        public DateTime FillingDate
        {
            get { return fillingDate; }
            set { fillingDate = value; }
        }
        private string iNoteNumber;

        public string INoteNumber
        {
            get { return iNoteNumber; }
            set { iNoteNumber = value; }
        }
        private DateTime iNoteDate;

        public DateTime INoteDate
        {
            get { return iNoteDate; }
            set { iNoteDate = value; }
        }
        private string previousTestReferences;

        public string PreviousTestReferences
        {
            get { return previousTestReferences; }
            set { previousTestReferences = value; }
        }
        private string tankNumber;

        public string TankNumber
        {
            get { return tankNumber; }
            set { tankNumber = value; }
        }
        private string containerMarkingDetails;

        public string ContainerMarkingDetails
        {
            get { return containerMarkingDetails; }
            set { containerMarkingDetails = value; }
        }
        private string tradeOwned;

        public string TradeOwned
        {
            get { return tradeOwned; }
            set { tradeOwned = value; }
        }
        private string govtStock;

        public string GovtStock
        {
            get { return govtStock; }
            set { govtStock = value; }
        }
        private string tradeGovtAccepted;

        public string TradeGovtAccepted
        {
            get { return tradeGovtAccepted; }
            set { tradeGovtAccepted = value; }
        }
        private string reasonForTest;

        public string ReasonForTest
        {
            get { return reasonForTest; }
            set { reasonForTest = value; }
        }
        private string governingSupply;

        public string GoverningSupply
        {
            get { return governingSupply; }
            set { governingSupply = value; }
        }

        private int isForwardNumberActive;

        public int IsForwardNumberActive
        {
            get { return isForwardNumberActive; }
            set { isForwardNumberActive = value; }
        }

        private DateTime eslModifyDate;

        public DateTime EslModifyDate
        {
            get { return eslModifyDate; }
            set { eslModifyDate = value; }
        }

        private DateTime oldEslDate;

        public DateTime OldEslDate
        {
            get { return oldEslDate; }
            set { oldEslDate = value; }
        }
        
    }
}
