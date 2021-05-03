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
    public class PreTaxDeductions
    {
        //Properties
        [ComVisible(true)]
        public Pension  Pension { get; set; }
        public Annuity Annuity { get; set; }
        public Relief Relief { get; set; }
        public double TotalPreTaxDeductions { get; set; }


        //Constructor
        public PreTaxDeductions()
        {
            CreatePension();
            CreateAnnuity();
            CreateRelief();
        }

        //Methods
        private void CreatePension()
        {
            Pension pension = new Pension();
            Pension = pension;
        }

        private void CreateAnnuity()
        {
            Annuity annuity = new Annuity();
            Annuity = annuity;
        }

        private void CreateRelief()
        {
            Relief relief = new Relief();
            Relief = relief;
        }

        //Set Sub-Element values
        //Earnings

        public void SetPensionPTD(double Amount)
        {
            Pension.AmountPTD = Amount;
        }

        public void SetPensionYTD(double Amount)
        {
            Pension.AmountYTD = Amount;
        }

        public void SetAnnuityPTD(double Amount)
        {
            Annuity.AmountPTD = Amount;
        }

        public void SetAnnuityYTD(double Amount)
        {
            Annuity.AmountYTD = Amount;
        }

        public void SetReliefPTD(double Amount)
        {
            Relief.AmountPTD = Amount;
        }

        public void SetReliefYTD(double Amount)
        {
            Relief.AmountYTD = Amount;
        }

        public double GetTotalPreTaxDeductionsYTD()
        {
            double PreTaxDeductions;
            PreTaxDeductions = Relief.AmountYTD + Annuity.AmountPTD + Relief.AmountYTD;
            TotalPreTaxDeductions = PreTaxDeductions;
            return TotalPreTaxDeductions;
        }
    }
}
