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
        public double TotalNormalEarnings { get; set; }
        public static double TotalTaxableNormalEarnings { get; private set; }

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
        public void SetEarnings(double amount)
        {
            Earnings.Amount = amount;
        }

        //Shares
        public void SetShares(double amount)
        {
            FringeBenefits.SetAmount(amount);
        }

        //Travel Allowance
        public void SetTravelAllowance(double amount)
        {
            TravelAllowance.SetAmount(amount);
        }

        public double GetTaxableNormalEarnings()
        {
            double taxableNormalEarnings;
            taxableNormalEarnings = Earnings.Amount + FringeBenefits.Amount + TravelAllowance.Amount_Taxable;
            return TotalNormalEarnings;
        }

        public void SetTotalTaxableNormalEarnings(double amount) => TotalTaxableNormalEarnings = amount;
    }
}
