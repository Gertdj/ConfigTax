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
        public Pension  Pension { get; private set; }
        public Annuity Annuity { get; private set; }
        public Relief Relief { get; private set; }
        public double TotalPreTaxDeductions { get; private set; }


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

        public void SetPension(double amount)
        {
            Pension.Amount = amount;
        }

        public void SetAnnuity(double amount)
        {
            Annuity.Amount = amount;
        }


        public void SetRelief(double amount)
        {
            Relief.Amount = amount;
        }

        public double GetTotalPreTaxDeductions()
        {
            double PreTaxDeductions;
            PreTaxDeductions = Relief.Amount + Annuity.Amount + Relief.Amount;
            TotalPreTaxDeductions = PreTaxDeductions;
            return TotalPreTaxDeductions;
        }

        public void SetTotalPreTaxDeductions(double amount) => TotalPreTaxDeductions = amount;
    }
}
