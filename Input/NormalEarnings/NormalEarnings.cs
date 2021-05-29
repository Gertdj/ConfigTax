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
        public decimal TotalNormalEarnings { get; set; }
        public decimal TotalTaxableNormalEarnings { get; set; }

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
        public void SetEarnings(decimal amount)
        {
            Earnings.Amount = amount;
        }

        //Shares
        public void SetShares(decimal amount)
        {
            FringeBenefits.SetAmount(amount);
        }

        //Travel Allowance
        public void SetTravelAllowance(decimal amount)
        {
            TravelAllowance.SetAmount(amount);
        }

        public decimal GetTaxableNormalEarnings()
        {
            decimal TotalNormalEarnings;
            TotalNormalEarnings = Earnings.Amount + FringeBenefits.Amount + TravelAllowance.Amount_Taxable;
            return TotalNormalEarnings;
        }

        public void SetTotalTaxableNormalEarnings(decimal amount)
        {
            TotalTaxableNormalEarnings = amount;
        }
    }
}
