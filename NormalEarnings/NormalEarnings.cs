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
        public double TotalNormalEarningsPTD { get; set; }
        public double TotalTaxableNormalEarningsPTD { get; set; }

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
            TravelAllowance.AmountYTD = Amount;
        }


        public double GetTotalNormalEarningsPTD()
        {
            double TotalNormalEarnings;
            TotalNormalEarnings = Earnings.AmountPTD + FringeBenefits.AmountPTD + TravelAllowance.AmountPTD;
            TotalNormalEarningsPTD = TotalNormalEarnings;
            return TotalNormalEarningsPTD;
        }

        public double GetTotalTaxableNormalEarningsPTD()
        {
            double TotalNormalTaxableEarnings;
            TotalNormalTaxableEarnings = Earnings.AmountPTD + FringeBenefits.AmountPTD + TravelAllowance.AmountPTD_Taxable;
            TotalTaxableNormalEarningsPTD = TotalNormalTaxableEarnings;
            return TotalTaxableNormalEarningsPTD;
        }

    }
}
