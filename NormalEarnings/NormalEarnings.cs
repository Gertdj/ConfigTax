using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using ConfigTax.Input;

namespace ConfigTax
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class NormalEarnings
    {
        //Properties
        [ComVisible(true)]
        public Earnings Earnings { get; set; }
        public FringeBenefits FringeBenefits  { get; set; }
        public TravelAllowance TravelAllowance { get; set; }
        public double TotalNormalEarningsYTD { get; set; }
        public double TotalTaxableNormalEarningsYTD { get; set; }

        //Constructor
        public NormalEarnings()
        {
            //Create all sub TaxElements associated with Normal Earnings
            CreateEarnings();
            CreateFringeBenefits();
            CreateTravelAllowance();
        }   
        
        //Methods
        private void CreateEarnings()
        {
            Earnings earnings = new Earnings();
            Earnings = earnings;
        }

        private void CreateFringeBenefits()
        {
            FringeBenefits fringeBenefits = new FringeBenefits();
            FringeBenefits = fringeBenefits;
        }

        private void CreateTravelAllowance()
        {
            TravelAllowance travelAllowance = new TravelAllowance();
            TravelAllowance = travelAllowance; 
        }

        //Set Sub-Element values
        //Earnings
        public void SetEarningsPTD(double Amount)
        {
            Earnings.AmountPTD = Amount;
        }

        public void SetEarningsYTD(double Amount)
        {
            Earnings.AmountYTD = Amount;
        }

        //Shares
        public void SetSharesPTD(double Amount)
        {
            FringeBenefits.SetAmountPTD(Amount);
        }

        public void SetFringeBenefitsYTD(double Amount)
        {
            FringeBenefits.SetAmountYTD(Amount);
        }

        //Travel Allowance
        public void SetTravelAllowancePTD(double Amount)
        {
            TravelAllowance.SetAmountPTD(Amount);
        }

        public void SetTravelAllowanceYTD(double Amount)
        {
            TravelAllowance.SetAmountYTD(Amount);
        }


        public double GetTotalNormalEarningsYTD()
        {
            double TotalNormalEarnings;
            TotalNormalEarnings = Earnings.AmountYTD + FringeBenefits.AmountYTD + TravelAllowance.AmountYTD;
            TotalNormalEarningsYTD = TotalNormalEarnings;
            return TotalNormalEarningsYTD;
        }

        public double GetTotalTaxableNormalEarningsPTD()
        {
            double TotalNormalTaxableEarnings;
            TotalNormalTaxableEarnings = Earnings.AmountYTD + FringeBenefits.AmountYTD + TravelAllowance.AmountYTD_Taxable;
            TotalTaxableNormalEarningsYTD = TotalNormalTaxableEarnings;
            return TotalTaxableNormalEarningsYTD;
        }

    }
}
